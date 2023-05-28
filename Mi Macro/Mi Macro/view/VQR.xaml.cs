using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using System.Text;
using Mi_Macro.model;
using System.Xml.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Mi_Macro.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VQR : ContentPage
	{
        public double balancee;
        public string codeQR;
        ZXingBarcodeImageView qr;
        UserRepository userRepository = new UserRepository();
        MovementRepository movementRepository = new MovementRepository();
        LineRepository lineRepository = new LineRepository();
		public VQR ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            var (firstName, lastName, balance, target) = await userRepository.GetName(VLogin.CurrentUsername);
            lbBalance.Text = $"${balance}";
            lbBalance2.Text = $"${balance}";
            lbTarget.Text = "Your target: ****" + target.Substring(target.Length - 4);
            lbYourTarget.Text = "$" + balance.ToString();
            balancee = balance;
            await InitializePicker();
        }
            private async void btnCodeGenerate_Clicked(object sender, EventArgs e)
        {
            string balanceText = lbYourTarget.Text.TrimStart('$');
            if (double.TryParse(balanceText, out double balanceValue) && balanceValue < 0)
            {
                await DisplayAlert("Warning", "Insufficient balance", "Try again");
            } else
            {
                if(linePicker.SelectedIndex == -1)
                {
                    await DisplayAlert("Warning", "Line not selected", "Try again");
                } else
                {
                    codeQR = randomCode(15);
                    Movements movements = new Movements();
                    movements.date = DateTime.Now.ToString("dd/MM/yyyy");
                    movements.time = DateTime.Now.ToString("HH:mm:ss");
                    string chargeText = lbCharge.Text.Replace("-$", "");
                    if (double.TryParse(chargeText, out double result))
                    {
                        movements.amount = result;
                    }
                    else
                    {
                        movements.amount = 0;
                    }
                    movements.username = VLogin.CurrentUsername;
                    movements.line = linePicker.SelectedItem.ToString();
                    movements.codeQR = codeQR;
                    var isSaved = await movementRepository.Save(movements);
                    if (isSaved)
                    {
                        if (double.TryParse(balanceText, out double newBalance))
                        {
                            if (await userRepository.UpdateUserBalance(VLogin.CurrentUsername, newBalance))
                            {
                                await DisplayAlert("Information", "Charge made", "Ok");
                                generateCode(codeQR);
                                btnCodeGenerate.IsVisible = false;
                            }
                            else
                            {
                                await DisplayAlert("Error", "Error updating your balance", "Try again");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Error", "Invalid balance format", "Try again");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Charge not made", "Try again");
                    }
                }
            }
        }

        private void generateCode(string codeQR)
        {
            qr = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            qr.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            qr.BarcodeOptions.Width = 500;
            qr.BarcodeOptions.Height = 500;
            qr.BarcodeValue = codeQR;
            stkQR.Children.Add(qr);

            fQR.BorderColor = Color.FromHex("#009BAA");
        }

        public string randomCode(int longitud)
        {
            const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder codigo = new StringBuilder();

            Random random = new Random();
            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteres.Length);
                codigo.Append(caracteres[indice]);
            }

            return codigo.ToString();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async Task InitializePicker()
        {
            var lines = await lineRepository.GetAllLines();
            linePicker.ItemsSource = lines.Select(line => line.name).ToList();
        }

        private async void linePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                string lineName = (string)picker.ItemsSource[selectedIndex];
                double price = await lineRepository.GetPrice(lineName);
                lbCharge.Text = "-$" + price.ToString();
                lbYourTarget.Text = "$" + (balancee - price).ToString();
            }
        }
    }
}

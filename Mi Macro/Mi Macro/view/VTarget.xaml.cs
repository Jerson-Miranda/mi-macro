using Mi_Macro.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mi_Macro.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VTarget : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        public VTarget()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            var (firstName, lastName, balance, target, interbankKey) = await userRepository.GetName(VLogin.CurrentUsername);
            lbFullname.Text = $"{firstName} {lastName}";
            lbCardholder.Text = $"{firstName} {lastName}";
            lbInterbankKey.Text = $"{interbankKey}";
            string cuentaFormateada = InsertarEspacios(target, 4);
            lbAccountNumber.Text = cuentaFormateada;
            lbAccountNumber2.Text = cuentaFormateada;
        }

        private string InsertarEspacios(string input, int intervalo)
        {
            StringBuilder sb = new StringBuilder();
            int contador = 0;

            foreach (char c in input)
            {
                if (contador == intervalo)
                {
                    sb.Append(' ');
                    contador = 0;
                }

                sb.Append(c);
                contador++;
            }

            return sb.ToString();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnInterbankKey_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(lbInterbankKey.Text);
        }

        private async void btnAccountNumber2_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(lbAccountNumber2.Text);
        }
    }
}
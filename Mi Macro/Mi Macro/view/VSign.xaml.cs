using Mi_Macro.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mi_Macro.view
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VSign : ContentPage
	{
        UserRepository userRepository = new UserRepository();
		public VSign ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Warning", "Empty fields", "Cancel");
            } else
            {
                User user = new User();
                user.firstName = firstName.Trim();
                user.lastName = lastName.Trim();
                user.balance = 0;
                user.target = randomCode(16);
                user.interbankKey = randomCode(18);
                user.username = username.Trim();
                user.password = password;
                var isSaved = await userRepository.Save(user);
                if (isSaved)
                {
                    await DisplayAlert("Information", "Account created", "Ok");
                    VLogin.CurrentUsername = username.Trim();
                    await Navigation.PushAsync(new Home());
                }
                else
                {
                    await DisplayAlert("Error", "Account not created", "Try again");
                    await Navigation.PushAsync(new VLogin());
                }
            }
        }

        private string randomCode(int longitud)
        {
            const string caracteres = "1234567890";
            StringBuilder codigo = new StringBuilder();

            Random random = new Random();
            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteres.Length);
                codigo.Append(caracteres[indice]);
            }

            return codigo.ToString();
        }
    }
}
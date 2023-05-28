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
    public partial class VLogin : ContentPage
    {
        public static string CurrentUsername;
        UserRepository userRepository = new UserRepository();
        public VLogin()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VSign());
        }

        private async void btnLogIn_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Warning", "Empty fields", "Try again");
            } else
            {
                if (await userRepository.LogIn(txtUsername.Text.Trim(), txtPassword.Text))
                {
                    CurrentUsername = txtUsername.Text.Trim();
                    await Navigation.PushAsync(new Home());
                } else
                {
                    await DisplayAlert("Error", "Incorrect data", "Try again");
                }
            }
        }
    }
}
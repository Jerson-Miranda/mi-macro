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
    public partial class VProfile : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        public VProfile()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            txtFirstName.IsEnabled = false;
            txtLastName.IsEnabled = false;
            txtPassword.IsEnabled = false;
        }

        protected override async void OnAppearing()
        {
            var (firstName, lastName, username, password) = await userRepository.GetDataProfile(VLogin.CurrentUsername);
            txtFirstName.Text = $"{firstName}";
            txtLastName.Text = $"{lastName}";
            txtUsername.Text = $"{username}";
            txtPassword.Text = $"{password}";
        }

        private async void btnLogOut_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VLogin());
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            txtFirstName.IsEnabled = true;
            txtLastName.IsEnabled = true;
            txtPassword.IsEnabled = true;
            txtPassword.IsPassword = false;
            btnSave.IsVisible = true;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Warning", "Empty fields", "Try again");
            } else
            {
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (await userRepository.UpdateUserProfile(VLogin.CurrentUsername, firstName, lastName, password))
                {
                    await DisplayAlert("Information", "Updated data", "Accept");
                    await Navigation.PopAsync();
                } else
                {
                    await DisplayAlert("Error", "Data not updated", "Try again");
                }
            }
            
        }
    }
}
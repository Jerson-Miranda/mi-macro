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
    public partial class Home : ContentPage
    {
        private bool ban = false;
        private string balancee;
        UserRepository userRepository = new UserRepository();
        MovementRepository movementRepository = new MovementRepository();
        public Home()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            var (firstName, lastName, balance, target) = await userRepository.GetName(VLogin.CurrentUsername);
            lbName.Text = $"{firstName} {lastName}";
            lbBalance.Text = $"${balance}";
            balancee = $"${balance}";
            lbTarget.Text = "****" + target.Substring(target.Length - 4);
            var movements = await movementRepository.GetAll(VLogin.CurrentUsername);
            movementsList.ItemsSource = movements.Take(6);
            if (movements.Count() > 6)
            {
                lbSeeMore.IsVisible = true;
            } else
            {
                lbSeeMore.IsVisible = false;
            }
            ban = false;
            view();
        }

        private async void btnQR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VQR());
        }

        private async void btnNotification_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VNotification());
        }

        private async void btnChat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chat());
        }

        private async void btnMap_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VMap());
        }

        private void movementsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(e.Item == null)
            {
                return;
            }
            var movement = e.Item as Movements;
            Navigation.PushModalAsync(new VDetailsMovement(movement));
            ((ListView)sender).SelectedItem = null;
        }

        private void btnView_Clicked(object sender, EventArgs e)
        {
            view();
        }

        private void view()
        {
            if (ban)
            {
                lbBalance.Text = "****";
                btnView.ImageSource = "hide_20px.png";
                ban = false;
            }
            else
            {
                lbBalance.Text = balancee;
                btnView.ImageSource = "show_20px.png";
                ban = true;
            }
        }

        private async void btnProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VProfile());
        }
    }
}
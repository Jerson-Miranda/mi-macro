using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mi_Macro.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VMap : ContentPage
    {
        public VMap()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            webView.Source = new UrlWebViewSource { Url = "https://www.google.com/maps/d/embed?mid=1XRRKAAFasO6d1RRwLTXSVgZ1aTVG3io&hl=en&ehbc=2E312F" };
            buttonsBackgroundColor();
            buttonsTextColor();
            lbAll.BackgroundColor = Color.FromHex("#009BAA");
            lbAll.TextColor = Color.FromHex("#FFFFFF");
        }

        private void lbL1_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = "https://www.google.com/maps/d/u/0/edit?mid=1Z3NDtfl97z8kyqk44piDIAXPbqZSVAE&usp=sharing" };
            buttonsBackgroundColor();
            buttonsTextColor();
            lbL1.BackgroundColor = Color.FromHex("#009BAA");
            lbL1.TextColor = Color.FromHex("#FFFFFF");
        }

        private void lbL2_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = "https://www.google.com/maps/d/u/0/embed?mid=18hr_DMbiE7m8crEEB5bTod-e6nuTmDQ&ehbc=2E312F" };
            buttonsBackgroundColor();
            buttonsTextColor();
            lbL2.BackgroundColor = Color.FromHex("#009BAA");
            lbL2.TextColor = Color.FromHex("#FFFFFF");
        }

        private void lbL3_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = "https://www.google.com/maps/d/u/0/embed?mid=1Qa0JGlv9OQzMwkW3XIwugCuoAtnl83E&ehbc=2E312F" };
            buttonsBackgroundColor();
            buttonsTextColor();
            lbL3.BackgroundColor = Color.FromHex("#009BAA");
            lbL3.TextColor = Color.FromHex("#FFFFFF");
        }

        private void lbAll_Clicked(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = "https://www.google.com/maps/d/embed?mid=1XRRKAAFasO6d1RRwLTXSVgZ1aTVG3io&hl=en&ehbc=2E312F" };
            buttonsBackgroundColor();
            buttonsTextColor();
            lbAll.BackgroundColor = Color.FromHex("#009BAA");
            lbAll.TextColor = Color.FromHex("#FFFFFF");
        }

        private void buttonsBackgroundColor()
        {
            lbL1.BackgroundColor = Color.FromHex("#F2F2F2");
            lbL2.BackgroundColor = Color.FromHex("#F2F2F2");
            lbL3.BackgroundColor = Color.FromHex("#F2F2F2");
            lbAll.BackgroundColor = Color.FromHex("#F2F2F2");
        }
        private void buttonsTextColor()
        {
            lbL1.TextColor = Color.FromHex("#000");
            lbL2.TextColor = Color.FromHex("#000");
            lbL3.TextColor = Color.FromHex("#000");
            lbAll.TextColor = Color.FromHex("#000");
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
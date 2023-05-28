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
	public partial class Chat : ContentPage
	{
		public Chat ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
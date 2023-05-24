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
	public partial class VQR : ContentPage
	{
		public VQR ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		}

        private void btnCodeGenerate_Clicked(object sender, EventArgs e)
        {

        }
    }
}
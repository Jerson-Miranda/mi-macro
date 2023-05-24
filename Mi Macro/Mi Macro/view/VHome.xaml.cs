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
		public List<Movements> listMovements { get; set; }
		public Home ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
			listMovements = new List<Movements> ();
			listMovements.Add(new Movements { date = "12/04/2023", time = "13:01", amount = 9.50, line ="MiMacro Calzada" });
			listMovements.Add(new Movements { date = "25/06/2022", time = "15:12", amount = 9.50, line = "MiMacro Periferico" });
			listMovements.Add(new Movements { date = "14/12/2022", time = "12:22", amount = 9.50, line = "MiMacro Periferico" });
			listMovements.Add(new Movements { date = "03/03/2023", time = "06:43", amount = 9.50, line = "MiMacro Calzada" });
			listMovements.Add(new Movements { date = "30/07/2022", time = "07:23", amount = 9.50, line = "MiMacro Centro" });
			listMovements.Add(new Movements { date = "23/10/2022", time = "11:34", amount = 9.50, line = "MiMacro Calzada" });
			listMovements.Add(new Movements { date = "15/11/2022", time = "23:45", amount = 9.50, line = "MiMacro Centro" });

            int N = 5; // Número de filas que deseas mostrar
            List<Movements> limitedList = listMovements.Take(6).ToList();

            listMovement.ItemsSource = limitedList;
            BindingContext = this;
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

    }
}
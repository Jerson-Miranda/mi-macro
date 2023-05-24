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
	public partial class VNotification : ContentPage
	{
		public List<Notification> listNotification { get; set; }
		public VNotification ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
            listNotification = new List<Notification> ();
			listNotification.Add(new Notification { id=1, title="Cargo a tu tarjeta", description= "Compraste MiMacro Centro por  $9.50." });
			listNotification.Add(new Notification { id=2, title="Cargo a tu tarjeta", description= "Compraste MiMacro Periferico por  $9.50."});
			listNotification.Add(new Notification { id=3, title="Cargo a tu tarjeta", description= "Compraste MiMacro Calzada por  $9.50."});
			listNotification.Add(new Notification { id=4, title="Cargo a tu tarjeta", description= "Compraste MiMacro Centro por  $9.50."});
			listNotification.Add(new Notification { id=5, title="Cargo a tu tarjeta", description= "Compraste MiMacro Calzada por  $9.50."});
			listNotification.Add(new Notification { id=6, title="Cargo a tu tarjeta", description= "Compraste MiMacro Periferico por  $9.50." });
			listNotification.Add(new Notification { id=7, title="Cargo a tu tarjeta", description= "Compraste MiMacro Periferico por  $9.50." });
			listNotification.Add(new Notification { id=8, title="Cargo a tu tarjeta", description= "Compraste MiMacro Calzada por  $9.50."});
			listNotification.Add(new Notification { id=9, title="Cargo a tu tarjeta", description= "Compraste MiMacro Calzada por  $9.50."});
			listNotification.Add(new Notification { id=10, title="Cargo a tu tarjeta", description= "Compraste MiMacro Centro por  $9.50." });
			listNotification.Add(new Notification { id=11, title="Cargo a tu tarjeta", description= "Compraste MiMacro Periferico por  $9.50." });
			listNotification.Add(new Notification { id=12, title="Cargo a tu tarjeta", description= "Compraste MiMacro Calzada por  $9.50."});
			listNotification.Add(new Notification { id=13, title="Cargo a tu tarjeta", description= "Compraste MiMacro Periferico por  $9.50." });
			
			BindingContext = this;
        }

	}
}
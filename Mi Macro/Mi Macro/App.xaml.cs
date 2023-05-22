using Mi_Macro.view;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mi_Macro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VLogin();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

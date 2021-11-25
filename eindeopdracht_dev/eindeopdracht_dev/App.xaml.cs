using eindeopdracht_dev.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eindeopdracht_dev
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new NavigationPage(new map());
             MainPage = new NavigationPage(new parkinglijst());
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

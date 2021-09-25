using AniAPIPortal.Services;
using AniAPIPortal.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AniAPIPortal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new HomePage(new AniAPIService());
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

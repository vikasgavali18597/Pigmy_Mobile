using G_Pigmy.Services;
using G_Pigmy.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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

using Android.Bluetooth;
using G_Pigmy.Views;
using System;
using Xamarin.Forms;

namespace G_Pigmy
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(CustomerPage), typeof(CustomerPage));
            Routing.RegisterRoute(nameof(CollectionPage), typeof(CollectionPage));
            Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));
            Routing.RegisterRoute(nameof(MiniReportPage), typeof (MiniReportPage));
            Routing.RegisterRoute(nameof(ScrollReportPage), typeof(ScrollReportPage));
            Routing.RegisterRoute(nameof(BalanceReportPage),typeof(BalanceReportPage));
            Routing.RegisterRoute(nameof(CollectionReportPage), typeof(CollectionReportPage));
            Routing.RegisterRoute(nameof(BluetoothPage), typeof(BluetoothPage));

           
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }


        private async void OnBluetooth(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BluetoothPage());
            AppShell.Current.FlyoutIsPresented = false;


            //await Shell.Current.GoToAsync("//BluetoothPage");
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            
        }
    }
}

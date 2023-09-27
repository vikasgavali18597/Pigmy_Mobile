using Android.Bluetooth;
using G_Pigmy.ViewModels;
using G_Pigmy.Views.BluetoothView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace G_Pigmy.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BluetoothPage : ContentPage
	{
        PrintViewBluetoothViewModel viewModel;
       
        public BluetoothPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new PrintViewBluetoothViewModel();
            
        }


        //private void Bt_Char(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new BluetoothCharPage(null, null));
        //}


        //private void Bt_Device(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new BluetoothDevicePage());
        //}

        //private void Bt_Serve(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new BluetoothServicePage(null));
        //}

        async void OnToggled(object sender, ToggledEventArgs e)
        {
            bool isToggled = e.Value;

            //if (isToggled)
            //{
            //    // Enable Bluetooth
               

            //        BluetoothAdapter.Enable().ContinueWith(task =>
            //        {
            //            if (task.Result == AdapterState.On)
            //            {
            //                // Bluetooth is enabled
            //                Device.BeginInvokeOnMainThread(() =>
            //                {
            //                    pairButton.IsEnabled = true;
            //                });
            //            }
            //            else
            //            {
            //                // Bluetooth could not be enabled
            //                Device.BeginInvokeOnMainThread(() =>
            //                {
            //                    pairButton.IsEnabled = false;
            //                    toggleSwitch.IsToggled = false;
            //                });
            //            }
            //        });
            //}
            //else
            //{
            //    // Disable Bluetooth
            //    BluetoothAdapter.DisableAsync();
            //    pairButton.IsEnabled = false;
            //}
        }

        void OnPairClicked(object sender, EventArgs e)
        {
                // Open Bluetooth settings to pair with a device
               // BluetoothAdapter.OpenSettingsAsync();
        }

        
    }
}
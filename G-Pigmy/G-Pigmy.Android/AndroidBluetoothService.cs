using Android.Bluetooth;
using Android.Content.PM;
using G_Pigmy.Droid;
using Java.Time.Temporal;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidBluetoothService))]
namespace G_Pigmy.Droid
{

    public class AndroidBluetoothService : IBluetoothService
    {

        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
        public IList<string> GetDeviceList()
        {
             return bluetoothAdapter?.BondedDevices.Select(x => x.Name).ToList();
        }

        public async Task Print(string deviceName, string text)
        {
            BluetoothDevice device = (from bd in bluetoothAdapter?.BondedDevices where bd?.Name == deviceName select bd).FirstOrDefault();

            try
            {
                await Task.Delay(1000);
                BluetoothSocket bluetoothSocket = device?.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));

                bluetoothSocket.Connect();
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                bluetoothSocket.OutputStream.Write(buffer, 0, buffer.Length);
                bluetoothSocket.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task TurnOnBluetooth()
        {
            var v = bluetoothAdapter.Enable();


             //await Permissions.CheckStatusAsync<Permissions.BasePlatformPermission>();

            await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            // Start scanning for Bluetooth devices
            var current = Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Bluetooth);
            if (current)
            {
                var devices =  GetDeviceList();
                if (devices != null)
                {
                    // Handle the selected device(s)
                    foreach (var device in devices)
                    {
                        // Access device properties (e.g., device.Name, device.Id, etc.)
                    }
                }
            }



            //var status = await Permissions.RequestAsync<Permissions.Bluetooth>();
            //if (status == PermissionStatus.Granted)
            //{
            //    // Bluetooth permission granted, proceed with enabling Bluetooth
            //    try
            //    {
            //        await Bluetooth.RequestEnableAsync();
            //        // Bluetooth is now enabled
            //    }
            //    catch (Exception ex)
            //    {
            //        // An error occurred while enabling Bluetooth
            //    }
            //}
            //else
            //{
            //    // Bluetooth permission denied
            //}
        }




    }
}
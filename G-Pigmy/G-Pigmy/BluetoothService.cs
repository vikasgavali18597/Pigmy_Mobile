using System.Linq;
using Xamarin.Essentials;

namespace G_Pigmy
{
    public static class BluetoothService
    {
        public static bool IsBluetoothEnabled()
        {
            return MainThread.InvokeOnMainThreadAsync(() =>
            {
                var state = Connectivity.ConnectionProfiles.Contains(ConnectionProfile.Bluetooth);
                return state;
            }).Result;
        }
    }
}

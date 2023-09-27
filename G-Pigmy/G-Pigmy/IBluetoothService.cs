using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace G_Pigmy
{
    public interface IBluetoothService
    {
        IList<string> GetDeviceList();
        Task Print(string deviceName, string text);

        Task TurnOnBluetooth();
    }
}

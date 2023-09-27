using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace G_Pigmy.ViewModels
{
    public class PrintViewBluetoothViewModel
    {
        private readonly IBluetoothService _bluetoothService;

        public bool isBluetoothEnabled = false;
        private IList<string> _devicesList;
       
        public IList<string> DeviceList 
        {
            get 
            { 
               if (_devicesList == null)
                    _devicesList = new ObservableCollection<string>();
               return _devicesList;
            } 
            set
            {
                _devicesList = value;
            }
        }


        private string _printMessage;
        public string PrintMessage { get { return _printMessage; } set { _printMessage = value; } }



        private string _selectedDevices;
        public string SelectedDevices { get { return _selectedDevices; } set { _selectedDevices = value; } }

        public ICommand PrintCommand => new Command(async () =>
        {
            PrintMessage += "Connection Department";
            await _bluetoothService.Print(SelectedDevices, PrintMessage);
        });


        public ICommand TurnBluetoothOn => new Command(async () =>
        {
            await _bluetoothService.TurnOnBluetooth();
        });



        public PrintViewBluetoothViewModel()
        {
            isBluetoothEnabled = BluetoothService.IsBluetoothEnabled();
            _bluetoothService = DependencyService.Get<IBluetoothService>();
            var lst = _bluetoothService.GetDeviceList();
            DeviceList.Clear();
            foreach ( var device in lst )
            {
                DeviceList.Add(device);
            }
         }
    }
}

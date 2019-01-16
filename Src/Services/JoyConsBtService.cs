using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace JoyConsPro.Src.Services
{
    class JoyConsBtService
    {
        private static readonly string LeftJoyConName = "Joy-Con (L)";
        private static readonly string RightJoyConName = "Joy-Con (R)";

        private BluetoothClient _client;

        public event Action<List<int>> DevicesRemoved;

        public JoyConsBtService()
        {
            _client = new BluetoothClient();
        }

        public async Task FindControllers()
        {
            var task = new TaskCompletionSource<bool>();
            var findResult = _client.BeginDiscoverDevices(20, true, true, true, true, res => task.TrySetResult(true), _client);

            await task.Task;

            var devices = _client.EndDiscoverDevices(findResult);
            var joyconDevices = devices.Where(dev => dev.DeviceName == LeftJoyConName || dev.DeviceName == RightJoyConName).ToArray();
            await ConnectDevices(joyconDevices);
        }

        private Task ConnectDevices(BluetoothDeviceInfo[] joyConDevices)
        {
            return Task.WhenAll(joyConDevices.Select(device =>
            {
                return Task.Run(() =>
                {
                    if (device.Authenticated)
                    {
                        BluetoothSecurity.RemoveDevice(device.DeviceAddress);
                    }

                    Console.WriteLine(">>>>>>>> Pairing.. : " + device.DeviceName);
                    var isPaired = BluetoothSecurity.PairRequest(device.DeviceAddress, "");
                    
                    Console.WriteLine(">>>>>>>> Paired : " + isPaired + " " + device.DeviceName);
                });
            }));

            /*return Task.Run(() =>
            {
                foreach (var device in joyConDevices)
                {
                    if (device.Authenticated)
                    {
                        BluetoothSecurity.RemoveDevice(device.DeviceAddress);
                    }

                    var isPaired = BluetoothSecurity.PairRequest(device.DeviceAddress, "1234");
                    Console.WriteLine(">>>>>>>> Paired : " + isPaired + " " + device.DeviceName);
                }
            });*/
        }
    }
}

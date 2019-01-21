using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.Foundation;

namespace JoyConsPro.Services.Bluetooth
{
    class JoyConsBtService
    {
        private static readonly string LeftJoyConName = "Joy-Con (L)";
        private static readonly string RightJoyConName = "Joy-Con (R)";

        private bool _isLeftConnected;
        private bool _isRightConnected;

        private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private List<DeviceInformation> _deviceInformations;

        private DeviceWatcher _deviceWatcher;

        public JoyConsBtService()
        {
            _deviceInformations = new List<DeviceInformation>();
        }

        public async Task FindControllers()
        {
            _deviceInformations.Clear();

            _isLeftConnected = false;
            _isRightConnected = false;

            var task = new TaskCompletionSource<bool>();
            var leftSelector = BluetoothDevice.GetDeviceSelectorFromDeviceName(LeftJoyConName);
            var rightSelector = BluetoothDevice.GetDeviceSelectorFromDeviceName(RightJoyConName);

            var selector = $"({leftSelector}) OR ({rightSelector})";
            _deviceWatcher = DeviceInformation.CreateWatcher(selector, null, DeviceInformationKind.AssociationEndpoint);

            _deviceWatcher.Added += AddedDevice;
            _deviceWatcher.Updated += async (watcher, info) =>
            {
                var device = _deviceInformations.FirstOrDefault(dev => dev.Id.Equals(info.Id));
                if (device != null)
                {
                    device.Update(info);
                    await TryPair(device);
                }
            };

            _deviceWatcher.EnumerationCompleted += (watcher, info) => task.SetResult(true);
            _deviceWatcher.Stopped += (watcher, info) => task.SetResult(true);

            _deviceWatcher.Start();

            await task.Task;
        }

        private async Task TryPair(DeviceInformation info)
        {
            await _semaphore.WaitAsync();

            if (info.Name.Equals(LeftJoyConName) && _isLeftConnected ||
                info.Name.Equals(RightJoyConName) && _isRightConnected)
            {
                _semaphore.Release();
                return;
            }

            DevicePairingResult result;
            try
            {
                var pairingKinds = DevicePairingKinds.ConfirmOnly | DevicePairingKinds.ConfirmPinMatch |
                                   DevicePairingKinds.DisplayPin | DevicePairingKinds.ProvidePin;
                var customPairing = info.Pairing.Custom;

                customPairing.PairingRequested += PairRequest;
                result = await customPairing.PairAsync(pairingKinds, DevicePairingProtectionLevel.Default);
                customPairing.PairingRequested -= PairRequest;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (result.Status == DevicePairingResultStatus.AlreadyPaired)
            {
                await info.Pairing.UnpairAsync();
            }
            else if (result.Status == DevicePairingResultStatus.Paired)
            {
                if (info.Name.Equals(LeftJoyConName))
                {
                    _isLeftConnected = true;
                }
                else if (info.Name.Equals(RightJoyConName))
                {
                    _isRightConnected = true;
                }

                if (_isRightConnected && _isLeftConnected)
                {
                    _deviceWatcher.Stop();
                }
            }

            _semaphore.Release();
        }

        private async void AddedDevice(DeviceWatcher watcher, DeviceInformation info)
        {
            _deviceInformations.Add(info);

            await TryPair(info);
        }

        private void PairRequest(DeviceInformationCustomPairing sender, DevicePairingRequestedEventArgs args)
        {
            args.Accept();
        }
    }
}

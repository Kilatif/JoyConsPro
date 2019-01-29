using System;
using Nefarius.ViGEm.Client;
using Nefarius.ViGEm.Client.Targets;

namespace JoyConsPro.Services.Devices
{
    class JoyConsProDevice : IDisposable
    {
        private NintendoSwitchController _proController;

        public JoyConsProDevice()
        {
            var client = new ViGEmClient();
            _proController = new NintendoSwitchController(client);
            _proController.Connect();
        }

        public void Dispose()
        {
            _proController?.Dispose();
        }
    }
}

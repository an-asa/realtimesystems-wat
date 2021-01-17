using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieDrzwiami
{
    public class DrzwiHub : Hub
    {
        DrzwiDevice pDevice;

        public DrzwiHub(DrzwiDevice device)
        {
            pDevice = device;
        }

        public async Task Otworz()
        {
            pDevice.Otworz();
            await Task.CompletedTask;
        }
        public async Task Zamknij()
        {
            pDevice.Zamknij();
            await Task.CompletedTask;
        }

    }
}

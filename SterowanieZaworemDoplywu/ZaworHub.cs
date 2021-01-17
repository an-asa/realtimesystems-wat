using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieZaworemDoplywu
{
    public class ZaworHub : Hub
    {
        ZaworDevice pDevice;

        public ZaworHub(ZaworDevice device)
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

        //TODO: stan otwarcia zaowru
    }
}

using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silnik
{
    public class SilnikHub : Hub
    {
        SilnikDevice pDevice;

        public SilnikHub(SilnikDevice device)
        {
            pDevice = device;
        }

        public async Task Zalacz()
        {
            pDevice.Zalacz();
            await Task.CompletedTask;
        }
        public async Task Wylacz()
        {
            pDevice.Wylacz();
            await Task.CompletedTask;
        }

        public async Task UstawPredkoscKatowa(float predkoscKatowa)
        {
            pDevice.UstawPredkoscKatowa(predkoscKatowa);
            await Task.CompletedTask;
        }

        public async Task UstawKierunekObrotu(int kierunekObrotu)
        {
            pDevice.UstawKierunekObrotu(kierunekObrotu);
            await Task.CompletedTask;
        }
    }
}

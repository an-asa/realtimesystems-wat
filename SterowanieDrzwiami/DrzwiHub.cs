using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieDrzwiami
{
    public class DrzwiHub : Hub
    {
        Drzwi pDevice;
        public DrzwiHub(Drzwi device)
        {
            pDevice = device;
        }

        public async Task SendToAll(string text)
        {
            await Clients.All.SendAsync("Test", text);
        }

    }
}

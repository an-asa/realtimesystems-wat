using Klienci;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sterowanie
{
    public class SterowanieHub : Hub
    {
        SterowanieDevice pDevice;

        public SterowanieHub(SterowanieDevice device)
        {
            pDevice = device;
        }

        public async Task Start(ProgramPrania programPrania)
        {
            await pDevice.Start(programPrania);
        }
    }
}

using Klienci;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sterowanie
{
    public class SterowanieDevice
    {
        Task symTask;
        private readonly IHubContext<SterowanieHub> hubContext;
        private bool czyPierze = false;

        public SterowanieDevice(IHubContext<SterowanieHub> hubContext)
        {
            Console.WriteLine("SterowanieDevice: KONSTRUKTOR");
            this.hubContext = hubContext;
        }

        private async Task ustawEtapPrania(EtapPrania etapPrania)
        {
            await hubContext.Clients.All.SendAsync("ZmianaEtapuPrania", etapPrania);
        }
        private async Task symuluj(ProgramPrania programPrania)
        {
            czyPierze = true;

            Task.Delay(1000).Wait();
            await ustawEtapPrania(EtapPrania.Pranie);

            while (czyPierze)
            {
                Console.WriteLine("SterowanieDevice: Symulowanie");
                
                
                Task.Delay(1000).Wait();
            }
        }

        public async Task Start(ProgramPrania programPrania)
        {
            if (!czyPierze)
            {
                Console.WriteLine("SterowanieDevice: Start, program = " + programPrania);
                symTask = Task.Run(async () => {
                    await symuluj(programPrania);
                });
            }
            
            await Task.CompletedTask;
        }
    }
}

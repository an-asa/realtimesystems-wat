using Klienci;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sterowanie
{
    public class SterowanieDevice
    {
        Task symTask;

        public SterowanieDevice()
        {
            Console.WriteLine("SterowanieDevice: KONSTRUKTOR");
        }

        private void ustawEtapPrania(EtapPrania etapPrania)
        {
            //TODO: SendToClients() + handle on PanelSterowania
        }
        private void symuluj(ProgramPrania programPrania)
        {
            ustawEtapPrania(EtapPrania.Pranie);

            while (true)
            {
                Console.WriteLine("SterowanieDevice: Symulowanie");
                
                
                Task.Delay(1000).Wait();
            }
        }

        public async Task Start(ProgramPrania programPrania)
        {
            Console.WriteLine("SterowanieDevice: Start, program = " + programPrania);
            symTask = Task.Run(() => { symuluj(programPrania); });
            await Task.CompletedTask;
        }
    }
}

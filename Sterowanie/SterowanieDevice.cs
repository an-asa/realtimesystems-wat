﻿using Klienci;
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

        /*public int[,] czasPrania = new int[3, 4] { { 5, 10, 14, 16 }, { 5, 10, 0, 13 }, { 3, 7, 9, 11 } }; //programy prania i etapy prania jako czas rozpoczęcia kolejnego etapu w sekundach
        public int getCzasPrania(ProgramPrania programPrania, EtapPrania etapPrania)
        {
            return czasPrania[(int)programPrania - 1, (int)etapPrania - 1];
        }*/

        private async Task ustawEtapPrania(EtapPrania etapPrania)
        {
            await hubContext.Clients.All.SendAsync("ZmianaEtapuPrania", etapPrania);
        }
        private async Task symuluj(ProgramPrania programPrania)
        {
            //sprawdź ciężar

            czyPierze = true;

            Task.Delay(1000).Wait();

            int i = 0;
            while (czyPierze)
            {
                //Console.WriteLine("SterowanieDevice: Symulowanie");
                switch (i)
                {
                    case 0:
                        await ustawEtapPrania(EtapPrania.Pranie);
                        Console.WriteLine("SterowanieDevice: EtapPrania.Pranie");
                        break;
                    case 5: 
                        await ustawEtapPrania(EtapPrania.Plukanie);
                        Console.WriteLine("SterowanieDevice: EtapPrania.Plukanie");
                        break;
                    case 10:
                        if(programPrania != ProgramPrania.BawelnaBezWirowania)
                        {
                            await ustawEtapPrania(EtapPrania.Wirowanie);
                            Console.WriteLine("SterowanieDevice: EtapPrania.Wirowanie");
                        }
                        break;
                    case 12: 
                        await ustawEtapPrania(EtapPrania.Zakonczone);
                        Console.WriteLine("SterowanieDevice: EtapPrania.Zakonczone");
                        break;
                    case 15:
                        czyPierze = false;
                        Console.WriteLine("SterowanieDevice: Koniec prania");
                        break;
                    default:
                        Console.Write(".");
                        break;
                }

                
                Task.Delay(1000).Wait();
                i++;
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

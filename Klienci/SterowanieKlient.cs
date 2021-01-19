using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klienci
{
    public enum EtapPrania {
        Pranie = 1,
        Plukanie = 2,
        Wirowanie = 3,
        Zakonczone = 4
    }

    public enum ProgramPrania {
        Bawelna = 1,
        BawelnaBezWirowania = 2,
        Syntetyki = 3
    }

    public class SterowanieKlient : IAsyncDisposable
    {
        HubConnection pSterowanieSerwer;
        public event EventHandler<EtapPrania> ZmianaEtapuPrania;

        public SterowanieKlient()
        {
            pSterowanieSerwer = new HubConnectionBuilder()
                .WithUrl(@"http://localhost:4005/pralka/sterowanie")
                .AddMessagePackProtocol()
                .Build();

            pSterowanieSerwer.Closed += async (error) =>
            {
                Console.WriteLine("Połączenie zamknięte...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await pSterowanieSerwer.StartAsync();
            };

            pSterowanieSerwer.On<EtapPrania>("ZmianaEtapuPrania", (etapPrania) =>
            {
                Console.WriteLine("ZmianaEtapuPrania {0}", etapPrania);
                ZmianaEtapuPrania?.Invoke(this, etapPrania);
            });

            pSterowanieSerwer.StartAsync().Wait();
        }

        public ValueTask DisposeAsync()
        {
            return pSterowanieSerwer.DisposeAsync();
        }

        public async Task Start(ProgramPrania programPrania)
        {
            await pSterowanieSerwer.SendAsync("Start", programPrania);
        }
    }
}

using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klienci
{
    class SilnikKlient : IAsyncDisposable
    {
        HubConnection pSilnikSerwer;

        public SilnikKlient()
        {
            pSilnikSerwer = new HubConnectionBuilder()
                .WithUrl(@"http://localhost:4002/pralka/silnik")
                .AddMessagePackProtocol()
                .Build();

            pSilnikSerwer.Closed += async (error) =>
            {
                Console.WriteLine("Połączenie zamknięte...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await pSilnikSerwer.StartAsync();
            };

            pSilnikSerwer.StartAsync().Wait();
        }

        public ValueTask DisposeAsync()
        {
            return pSilnikSerwer.DisposeAsync();
        }

        public async Task Zalacz()
        {
            await pSilnikSerwer.SendAsync("Zalacz");
        }

        public async Task Wylacz()
        {
            await pSilnikSerwer.SendAsync("Wylacz");
        }

        public async Task UstawPredkoscKatowa(float predkoscKatowa)
        {
            await pSilnikSerwer.SendAsync("UstawPredkoscKatowa", predkoscKatowa);
        }

        public async Task UstawKierunek(int kierunekObrotu)
        {
            await pSilnikSerwer.SendAsync("UstawKierunekObrotu", kierunekObrotu);
        }
    }
}

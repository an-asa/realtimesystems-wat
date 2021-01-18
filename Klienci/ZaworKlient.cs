using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klienci
{
    class ZaworKlient : IAsyncDisposable
    {

        HubConnection pZaworSerwer;

        public ZaworKlient()
        {
            pZaworSerwer = new HubConnectionBuilder()
                .WithUrl(@"http://localhost:4003/pralka/zawor")
                .AddMessagePackProtocol()
                .Build();

            pZaworSerwer.Closed += async (error) =>
            {
                Console.WriteLine("Połączenie zamknięte...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await pZaworSerwer.StartAsync();
            };

            pZaworSerwer.StartAsync().Wait();
        }
        public async Task Otworz()
        {
            await pZaworSerwer.SendAsync("Otworz");
        }

        public async Task Zamknij()
        {
            await pZaworSerwer.SendAsync("Zamknij");
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}

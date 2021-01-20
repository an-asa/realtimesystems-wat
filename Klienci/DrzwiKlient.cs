using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klienci
{
    public enum StatusDrzwi : int
    {
        Zamkniete = 1,
        Otwarte = 0
    }

    class DrzwiKlient : IAsyncDisposable
    {
        HubConnection pDrzwiSerwer;

        public DrzwiKlient()
        {
            pDrzwiSerwer = new HubConnectionBuilder()
                .WithUrl(@"http://localhost:4001/pralka/drzwi")
                .AddMessagePackProtocol()
                .Build();

            pDrzwiSerwer.Closed += async (error) =>
            {
                Console.WriteLine("Połączenie zamknięte...");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await pDrzwiSerwer.StartAsync();
            };

            pDrzwiSerwer.StartAsync().Wait();
        }
        public async Task Otworz()
        {
            await pDrzwiSerwer.SendAsync("Otworz");
        }

        public async Task Zamknij()
        {
            await pDrzwiSerwer.SendAsync("Zamknij");
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}

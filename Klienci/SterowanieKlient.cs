using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klienci
{
    class SterowanieKlient : IAsyncDisposable
    {
        HubConnection pSterowanieSerwer;

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

            pSterowanieSerwer.StartAsync().Wait();
        }

        public ValueTask DisposeAsync()
        {
            return pSterowanieSerwer.DisposeAsync();
        }

        public async Task Start()
        {
            await pSterowanieSerwer.SendAsync("Start");
        }
    }
}

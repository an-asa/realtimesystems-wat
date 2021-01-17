using Sterowanie.Klienci;
using System;
using System.Threading;

namespace TestKonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SilnikKlient silnik = new SilnikKlient();
            ZaworKlient zawor = new ZaworKlient();

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            Console.WriteLine("[1 - silnik wlacz  ]");
            Console.WriteLine("[2 - silnik wylacz ]");

            Console.WriteLine("[5 - zawor otworz  ]");
            Console.WriteLine("[6 - zawor zamknij ]");

            ConsoleKey klawisz;
            while (!cts.IsCancellationRequested)
            {

                klawisz = Console.ReadKey(true).Key;
                switch (klawisz)
                {
                    case ConsoleKey.D1:
                        silnik.Zalacz().Wait();
                        break;
                    case ConsoleKey.D2:
                        silnik.Wylacz().Wait();
                        break;
                    case ConsoleKey.D5:
                        zawor.Otworz().Wait();
                        break;
                    case ConsoleKey.D6:
                        zawor.Zamknij().Wait();
                        break;
                    case (ConsoleKey)ConsoleSpecialKey.ControlC:
                        break;

                }
            };

            silnik.DisposeAsync();
            zawor.DisposeAsync();
        }
    }
}

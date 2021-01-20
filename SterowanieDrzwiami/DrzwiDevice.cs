using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Klienci;

namespace SterowanieDrzwiami
{
    public class DrzwiDevice : IAsyncDisposable
    {
        Random status_drzwi = new Random();
        

        public DrzwiDevice()
        {
            Console.WriteLine("DrzwiDevice: KONSTRUKTOR");
        }

        public void Otworz()
        {
            Console.WriteLine("DrzwiDevice.Otworz()");
        }
        public void Zamknij()
        {
            Console.WriteLine("DrzwiDevice.Zamknij()");
        }

        public int Status()
        {
            return status_drzwi.Next(10) > 8 ? 0 : 1; //(int)Klienci.StatusDrzwi.Otwarte: (int)StatusDrzwi.Zamkniete ;
        }
        
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }


    }
}

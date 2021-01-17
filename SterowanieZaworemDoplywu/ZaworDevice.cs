using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieZaworemDoplywu
{
    public class ZaworDevice
    {
        public ZaworDevice()
        {
            Console.WriteLine("ZaworDevice: KONSTRUKTOR");
        }

        public void Otworz()
        {
            Console.WriteLine("ZaworDevice.Otworz()");
        }
        public void Zamknij()
        {
            Console.WriteLine("ZaworDevice.Zamknij()");
        }

        //TODO: Informacja o stanie otwarcia zaworu???

    }
}

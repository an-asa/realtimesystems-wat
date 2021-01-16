using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silnik
{
    public class SilnikDevice
    {
        public SilnikDevice()
        {
            Console.WriteLine("SilnikDevice: KONSTRUKTOR");
        }
        public void Zalacz()
        {
            Console.WriteLine("SilnikDevice.Zalacz()");
        }
        public void Wylacz()
        {
            Console.WriteLine("SilnikDevice.Wylacz()");
        }
        public void UstawPredkoscKatowa(float predkoscKatowa)
        {
            Console.WriteLine("SilnikDevice.UstawPredkoscKatowa(" + predkoscKatowa + ")");
        }
        public void UstawKierunekObrotu(int kierunekObrotu)
        {
            Console.WriteLine("SilnikDevice.UstawKierunekObrotu(" + kierunekObrotu + ")");
        }
    }
}

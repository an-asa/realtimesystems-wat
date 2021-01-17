using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieDrzwiami
{
    public class DrzwiDevice : IAsyncDisposable
    {
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
        
        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }


    }
}

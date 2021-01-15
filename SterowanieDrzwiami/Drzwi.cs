using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SterowanieDrzwiami
{
    public class Drzwi : IAsyncDisposable
    {
        public Drzwi()
        {

        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }


    }
}

using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsReals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Standard.Reals
{
    public class YRRealNumber : IYRRealNumber
    {
        public IValueTask<bool> Contains(IYRRealNumber element)
        {
            throw new NotImplementedException();
        }

        public IValueTask<bool> Contains(IYRSet element)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<IYRSet> Enumerate()
        {
            throw new NotImplementedException();
        }

        public IValueTask<IYRSet> Pair(IYRSet other)
        {
            throw new NotImplementedException();
        }

        public IValueTask<IYRSet> Power()
        {
            throw new NotImplementedException();
        }

        public IValueTask<IYRSet> Union()
        {
            throw new NotImplementedException();
        }

        public IValueTask<bool> ZFEquals(IYRSet other)
        {
            throw new NotImplementedException();
        }
    }
}

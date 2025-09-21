using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Core.Async.MorseCode;
using Kaleidoscope.Math.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaleidoscope.Math.Set.Abstractions
{
    public interface IYRSet
    {
        IValueTask<bool> Contains(IYRSet element);
        IValueTask<bool> ZFEquals(IYRSet other);
        IValueTask<IYRSet> Pair(IYRSet other);
        IValueTask<IYRSet> Union();
        IValueTask<IYRSet> Power();
        IAsyncEnumerable<IYRSet> Enumerate();

    }

    public interface IYRSet<TElement> : IYRSet
        where TElement : IYRSet
    {

    }
}

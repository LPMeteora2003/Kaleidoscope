using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Abstractions.Infinite
{
    public interface IYRInfiniteSet : IYRSet
    {
    }

    public interface IYRInfiniteSet<TElement> : IYRSet<TElement>, IYRInfiniteSet
        where TElement : IYRSet
    {
    }
}

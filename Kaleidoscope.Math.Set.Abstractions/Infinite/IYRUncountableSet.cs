using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Abstractions.Infinite
{
    public interface IYRUncountableSet : IYRInfiniteSet
    {
    }

    public interface IYRUncountableSet<TElement> : IYRInfiniteSet<TElement>, IYRUncountableSet
        where TElement : IYRSet
    {
    }
}

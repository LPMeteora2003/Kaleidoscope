using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Abstractions.Finite
{
    public interface IYRFiniteSet : IYRSet
    {
    }

    public interface IYRFiniteSet<TElement> : IYRSet<TElement>, IYRFiniteSet
        where TElement : IYRSet
    {
    }
}

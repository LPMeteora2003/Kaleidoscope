using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaleidoscope.Math.Set.Abstractions.Infinite.Countable
{
    public interface IYRCountableSet : IYRInfiniteSet
    {
    }

    public interface IYRCountableSet<TElement> : IYRInfiniteSet<TElement>, IYRCountableSet
        where TElement : IYRSet
    {
    }
}

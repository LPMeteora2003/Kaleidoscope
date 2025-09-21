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
    public interface IYRIndexableSet : IYRCountableSet
    {
        IValueTask<IYRSet> GetIndex(IYRSet element);
    }

    public interface IYRIndexableSet<TElement, TIndex> : IYRCountableSet<TElement>, IYRIndexableSet
        where TElement : IYRSet
        where TIndex : IYRSet
    {
        IValueTask<TElement> GetElement(TIndex index);
        IValueTask<TIndex> GetIndex(TElement element);
    }
}

using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Infinite.Countable;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Standard.AbstractionsIntegers
{
    public interface IYRIntegerNumberSet : IYRIndexableSet<IYRIntegerNumber, IYRNaturalNumber>
    {
    }
}

using Kaleidoscope.Core.Async;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Operator.Abstractions
{
    public interface IYRUnaryOperator : IYROperator
    {
    }
    public interface IYRUnaryOperator<in TIn, out TOut> : IYRUnaryOperator
        where TIn : IYRSet
        where TOut : IYRSet
    {
        IValueTask<TOut> Apply(TIn element);
    }
}

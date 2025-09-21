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
    public interface IYRBinaryOperator : IYROperator
    {
    }
    public interface IYRBinaryOperator<in TIn1, in TIn2, out TOut> : IYRBinaryOperator
        where TIn1 : IYRSet
        where TIn2 : IYRSet
        where TOut : IYRSet
    {
        IValueTask<TOut> Apply(TIn1 element1, TIn2 element2);
    }
}

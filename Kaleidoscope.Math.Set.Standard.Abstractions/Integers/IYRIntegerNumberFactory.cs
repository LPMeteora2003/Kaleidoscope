using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Standard.Abstractions.Integers
{
    public interface IYRIntegerNumberFactory
    {
        IValueTask<IYRIntegerNumber> GenerateZero();
        IValueTask<IYRIntegerNumber> Generate(BigInteger value);
        IValueTask<IYRIntegerNumber> GeneratePredecessor(IYRIntegerNumber successor);
        IValueTask<IYRIntegerNumber> GenerateSuccessor(IYRIntegerNumber predecessor);
    }
}

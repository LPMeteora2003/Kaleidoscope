using System;
using System.Numerics;
using System.Threading.Tasks;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Math.Set.Abstractions;

namespace Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers
{
    public interface IYRNaturalNumberFactory
    {
        IValueTask<IYRNaturalNumber> GenerateZero();
        IValueTask<IYRNaturalNumber> Generate(BigInteger value);
        IValueTask<IYRNaturalNumber> GenerateSuccessor(IYRNaturalNumber predecessor);
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Infinite.Countable;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using Kaleidoscope.Math.Set.Standard.Integers.Kuratowski;
using Kaleidoscope.Math.Set.Standard.Abstractions.Integers;

namespace Kaleidoscope.Math.Set.Standard.Integers
{
    public class YRIntegerNumberSet : YRSet, IYRIntegerNumberSet
    {
        private readonly IYRIntegerNumberFactory _factory;

        public YRIntegerNumberSet(IYRIntegerNumberFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));            
        }


        public override async IValueTask<bool> Contains(IYRSet element)
        {
            if (element is null) return false;
            return element is IYRIntegerNumber;
        }

        public override async IAsyncEnumerable<IYRIntegerNumber> Enumerate()
        {
            var zero = await _factory.GenerateZero();
            var currentNegative = zero;
            var currentPositive = zero;
            yield return zero;
            while (true)
            {
                currentPositive = await _factory.GeneratePredecessor(currentPositive);
                yield return currentPositive;
                currentNegative = await _factory.GenerateSuccessor(currentNegative);
                yield return currentNegative;                 
            }
        }

        public async IValueTask<IYRIntegerNumber> GetElement(IYRNaturalNumber index)
        {
            throw new NotImplementedException();
        }

        public IValueTask<IYRIntegerNumber> GetElement(IYRSet index)
        {
            throw new NotImplementedException();
        }

        public async IValueTask<IYRNaturalNumber> GetIndex(IYRIntegerNumber element)
        {
            throw new NotImplementedException();
        }

        public override IValueTask<bool> ZFEquals(IYRSet other)
        {
            throw new NotImplementedException();
        }

        public override IValueTask<IYRSet> Union()
        {
            throw new NotImplementedException();
        }

        public override IValueTask<IYRSet> Power()
        {
            throw new NotImplementedException();
        }

        public IValueTask<IYRSet> GetIndex(IYRSet element)
        {
            throw new NotImplementedException();
        }
    }
}

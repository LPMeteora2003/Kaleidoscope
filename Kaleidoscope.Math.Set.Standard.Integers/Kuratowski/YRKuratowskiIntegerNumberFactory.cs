using System;
using System.Numerics;
using System.Threading.Tasks;
using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.Abstractions.Integers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using Kaleidoscope.Math.Set.Standard.Integers.Kuratowski;

namespace Kaleidoscope.Math.Set.Standard.Integers
{
    public class YRKuratowskiIntegerNumberFactory : IYRIntegerNumberFactory
    {
        private readonly IYRNaturalNumberFactory _naturalFactory;

        public YRKuratowskiIntegerNumberFactory(IYRNaturalNumberFactory naturalFactory)
        {
            _naturalFactory = naturalFactory ?? throw new ArgumentNullException(nameof(naturalFactory));
        }

        public async IValueTask<IYRIntegerNumber> Generate(BigInteger value)
        {
            var leftValue = value > BigInteger.Zero ? value : BigInteger.Zero;
            var rightValue = value < BigInteger.Zero ? BigInteger.Negate(value) : BigInteger.Zero;

            var left = await _naturalFactory.Generate(leftValue);
            var right = await _naturalFactory.Generate(rightValue);

            return new YRKuratowskiIntegerNumber(left, right);
        }

        public async IValueTask<IYRIntegerNumber> GeneratePredecessor(IYRIntegerNumber successor)
        {
            if (successor is null) 
                throw new ArgumentNullException(nameof(successor));
            if (successor is not YRKuratowskiIntegerNumber kur)
                throw new NotImplementedException("GeneratePredecessor supports only YRKuratowskiIntegerNumber instances.");
            
            var left = kur.Left;
            if (left == YRSet.Empty)
                return new YRKuratowskiIntegerNumber(await _naturalFactory.Generate(0), await _naturalFactory.Generate(1));
            var right = kur.Right;
            var newRight = await _naturalFactory.GenerateSuccessor(right);
            return new YRKuratowskiIntegerNumber(left, newRight);            
        }

        public async IValueTask<IYRIntegerNumber> GenerateSuccessor(IYRIntegerNumber predecessor)
        {
            if (predecessor is null)
                throw new ArgumentNullException(nameof(predecessor));
            if (predecessor is not YRKuratowskiIntegerNumber kur)
                throw new NotImplementedException("GeneratePredecessor supports only YRKuratowskiIntegerNumber instances.");

            var left = kur.Left;
            if (left == YRSet.Empty)
                return new YRKuratowskiIntegerNumber(await _naturalFactory.Generate(1), await _naturalFactory.Generate(0));
            var right = kur.Right;
            var newLeft = await _naturalFactory.GenerateSuccessor(left);
            return new YRKuratowskiIntegerNumber(newLeft, right);
        }

        public async IValueTask<IYRIntegerNumber> GenerateZero()
        {
            return await Generate(BigInteger.Zero);
        }
    }
}

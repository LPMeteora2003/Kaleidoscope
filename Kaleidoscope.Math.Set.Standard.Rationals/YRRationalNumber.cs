using System.Numerics;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Finite;
using Kaleidoscope.Math.Set.Standard.AbstractionsRationals;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using System.Collections.Generic;
using System.Linq;

namespace Kaleidoscope.Math.Set.Standard.Rationals
{
    public class YRRationalNumber : YRFiniteSet, IYRRationalNumber
    {
        public IYRIntegerNumber Numerator { get; }
        public IYRNaturalNumber Denominator { get; }

        public YRRationalNumber(IYRIntegerNumber numerator, IYRNaturalNumber denominator)
            : base(new IYRSet[] { numerator, denominator })
        {
            Numerator = numerator ?? throw new System.ArgumentNullException(nameof(numerator));
            Denominator = denominator ?? throw new System.ArgumentNullException(nameof(denominator));
        }

        public override string ToString()
        {
            var numeratorString = Numerator?.ToString() ?? "null";
            var denominatorString = Denominator?.ToString() ?? "null";
            return $"{numeratorString}/{denominatorString}";
        }
    }
}

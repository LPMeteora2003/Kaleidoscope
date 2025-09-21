using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using System.Xml.Linq;
using Kaleidoscope.Math.Set.Finite;

namespace Kaleidoscope.Math.Set.Standard.Integers.Kuratowski
{
    public class YRKuratowskiIntegerNumber : YRFiniteSet, IYRIntegerNumber
    {
        public IYRNaturalNumber Left => (_elements[0] as YRFiniteSet).Elements[0] as IYRNaturalNumber;
        public IYRNaturalNumber Right => (_elements[1] as YRFiniteSet).Elements[1] as IYRNaturalNumber;
        public YRKuratowskiIntegerNumber(IYRNaturalNumber x, IYRNaturalNumber y)
            : base([new YRFiniteSet([x]), new YRFiniteSet([x,y])])
        {
        }

        public async ValueTask<string> ToStringAsync()
        {
            var lastElement = _elements.Last();
            if (_elements.Last() == YRSet.Empty)
                return "0";
            var countRight = await Right.Enumerate().CountAsync() - 1;
            var countLeft = await Left.Enumerate().CountAsync() - 1;
            return (countLeft - countRight).ToString();
        }
        public override string ToString()
        {
            if(Left == YRSet.Empty)
                return "0";
            var countRight = (Right as YRFiniteSet).Elements.Count;
            var countLeft = (Left as YRFiniteSet).Elements.Count;
            return (countLeft - countRight).ToString();
        }
    }
}

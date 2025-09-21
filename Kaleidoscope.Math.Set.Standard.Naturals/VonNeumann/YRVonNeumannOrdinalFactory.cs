using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;

namespace Kaleidoscope.Math.Set.Standard.Naturals.VonNeumann
{
    public class YRVonNeumannOrdinalFactory : IYRNaturalNumberFactory
    {

        public YRVonNeumannOrdinalFactory()
        {
        }

        public async IValueTask<IYRNaturalNumber> Generate(BigInteger value)
        {
            BigInteger counter = 0;
            var current = (YRVonNeumannOrdinal) await GenerateZero();
            while(counter < value)
            {
                current = new YRVonNeumannOrdinal([.. current.Elements, current]);
            }
            return current;
        }

        public async IValueTask<IYRNaturalNumber> GenerateSuccessor(IYRNaturalNumber predecessor)
        {
            if (predecessor is null)
                throw new ArgumentNullException(nameof(predecessor));
            if (predecessor is not YRVonNeumannOrdinal vonNeumannOrdinal)
                throw new NotImplementedException();

            var enumeratedPredecessor = vonNeumannOrdinal.Elements;
            return new YRVonNeumannOrdinal([..enumeratedPredecessor, predecessor]);
        }

        public async IValueTask<IYRNaturalNumber> GenerateZero()
        {
            return new YRVonNeumannOrdinal([YRSet.Empty]);
        }

    }
}

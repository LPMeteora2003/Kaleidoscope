using System;
using System.Numerics;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Infinite.Countable;
using Kaleidoscope.Math.Set.Standard.AbstractionsRationals;
using Kaleidoscope.Math.Set.Standard.AbstractionsIntegers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using Kaleidoscope.Math.Set.Standard.Naturals.VonNeumann;
using System.Linq;
using Kaleidoscope.Math.Set.Finite;
using Kaleidoscope.Math.Set.Standard.Abstractions.Integers;
using Kaleidoscope.Math.Set.Standard.Integers.Kuratowski;

namespace Kaleidoscope.Math.Set.Standard.Rationals
{
    public class YRRationalNumberSet : YRSet, IYRRationalNumberSet
    {
        private readonly IYRIntegerNumberFactory _integerFactory;
        private readonly IYRNaturalNumberFactory _naturalFactory;

        public YRRationalNumberSet(IYRIntegerNumberFactory integerFactory, IYRNaturalNumberFactory naturalFactory)
        {
            _integerFactory = integerFactory ?? throw new ArgumentNullException(nameof(integerFactory));
            _naturalFactory = naturalFactory ?? throw new ArgumentNullException(nameof(naturalFactory));
        }
        public override async IAsyncEnumerable<IYRRationalNumber> Enumerate()
        {
            var zeroNatural = await _naturalFactory.GenerateZero();
            var zeroInteger = await _integerFactory.GenerateZero();

            var integerByNaturalIndex = new Dictionary<int, IYRIntegerNumber>();
            integerByNaturalIndex[0] = zeroInteger;

            IYRIntegerNumber lastPositive = zeroInteger;
            IYRIntegerNumber lastNegative = zeroInteger;

            async Task<int> NaturalIndex(IYRNaturalNumber nat)
            {
                int count = 0;
                await foreach (var _ in nat.Enumerate())
                    count++;
                return System.Math.Max(0, count - 1);
            }

            async Task EnsureIntegerForIndex(int index)
            {
                if (integerByNaturalIndex.ContainsKey(index)) return;
                for (int i = integerByNaturalIndex.Count; i <= index; i++)
                {
                    if (i == 0)
                    {
                        integerByNaturalIndex[0] = zeroInteger;
                        continue;
                    }
                    if ((i & 1) == 1)
                    {
                        lastNegative = await _integerFactory.GeneratePredecessor(lastNegative);
                        integerByNaturalIndex[i] = lastNegative;
                    }
                    else
                    {
                        lastPositive = await _integerFactory.GenerateSuccessor(lastPositive);
                        integerByNaturalIndex[i] = lastPositive;
                    }
                }
            }

            int Gcd(int a, int b)
            {
                a = System.Math.Abs(a);
                b = System.Math.Abs(b);
                if (a == 0) return b;
                if (b == 0) return a;
                while (b != 0)
                {
                    int t = a % b;
                    a = b;
                    b = t;
                }
                return a;
            }

            async Task<int> IntegerValue(IYRIntegerNumber integer)
            {
                if (integer is YRKuratowskiIntegerNumber kur)
                {
                    int leftCount = 0;
                    await foreach (var _ in kur.Left.Enumerate()) leftCount++;
                    leftCount = System.Math.Max(0, leftCount - 1);

                    int rightCount = 0;
                    await foreach (var _ in kur.Right.Enumerate()) rightCount++;
                    rightCount = System.Math.Max(0, rightCount - 1);

                    return leftCount - rightCount;
                }

                int count = 0;
                await foreach (var _ in integer.Enumerate()) count++;
                return System.Math.Max(0, count - 1);
            }

            var visited = new HashSet<(int, int)>();
            var queue = new Queue<(IYRNaturalNumber, IYRNaturalNumber)>();
            queue.Enqueue((zeroNatural, zeroNatural));

            while (true)
            {
                var (aNat, bNat) = queue.Dequeue();

                int aIndex = await NaturalIndex(aNat);
                int bIndex = await NaturalIndex(bNat);

                if (!visited.Add((aIndex, bIndex)))
                {
                    if (queue.Count == 0)
                    {
                        var succA = await _naturalFactory.GenerateSuccessor(aNat);
                        var succB = await _naturalFactory.GenerateSuccessor(bNat);
                        queue.Enqueue((succA, bNat));
                        queue.Enqueue((aNat, succB));
                    }
                    continue;
                }

                await EnsureIntegerForIndex(aIndex);
                var numerator = integerByNaturalIndex[aIndex];
                var denominator = await _naturalFactory.GenerateSuccessor(bNat);

                int p = await IntegerValue(numerator);
                int q = bIndex + 1;

                if (Gcd(System.Math.Abs(p), q) == 1)
                    yield return new Kaleidoscope.Math.Set.Standard.Rationals.YRRationalNumber(numerator, denominator);

                var succA1 = await _naturalFactory.GenerateSuccessor(aNat);
                var succB1 = await _naturalFactory.GenerateSuccessor(bNat);

                if (!visited.Contains((await NaturalIndex(succA1), bIndex)))
                    queue.Enqueue((succA1, bNat));
                if (!visited.Contains((aIndex, await NaturalIndex(succB1))))
                    queue.Enqueue((aNat, succB1));
                if (queue.Count == 0)
                    queue.Enqueue((succA1, succB1));
            }
        }



        public IValueTask<IYRSet> GetElement(IYRSet index)
        {
            if (index is null)
                throw new System.ArgumentNullException(nameof(index));
            if (index is IYRNaturalNumber nat)
                return GetElement(nat);
            throw new System.InvalidOperationException("Index must be a IYRNaturalNumber");
        }

        public IValueTask<IYRSet> GetIndex(IYRSet element)
        {
            if (element is null)
                throw new System.ArgumentNullException(nameof(element));
            if (element is IYRNaturalNumber nat)
                return GetIndex(nat);
            throw new System.InvalidOperationException("Element must be a IYRNaturalNumber");
        }

        public async IValueTask<IYRNaturalNumber> GetElement(IYRNaturalNumber index)
        {
            return index;
        }

        public async IValueTask<IYRNaturalNumber> GetIndex(IYRNaturalNumber element)
        {
            return element;
        }

        public override async IValueTask<bool> Contains(IYRSet element)
        {
            if (element is IYRNaturalNumber nat)
                return true;
            return false;
        }

        public override async IValueTask<bool> ZFEquals(IYRSet other)
        {
            return other is IYRNaturalNumberSet;
        }

        public override IValueTask<IYRSet> Union()
        {
            throw new NotImplementedException();
        }

        public override IValueTask<IYRSet> Power()
        {
            throw new NotImplementedException();
        }

    }
}

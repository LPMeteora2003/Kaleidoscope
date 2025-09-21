using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Infinite.Countable;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;

namespace Kaleidoscope.Math.Set.Standard.NaturalNumbers
{
    public class YRNaturalNumberSet : YRSet, IYRNaturalNumberSet
    {
        IYRNaturalNumberFactory _factory;
        public YRNaturalNumberSet(IYRNaturalNumberFactory factory)
        {
            _factory = factory;
        }

        public override async IAsyncEnumerable<IYRSet> Enumerate()
        {
            var current = await _factory.GenerateZero();
            while (true)
            {
                yield return current;
                current = await _factory.GenerateSuccessor(current);
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

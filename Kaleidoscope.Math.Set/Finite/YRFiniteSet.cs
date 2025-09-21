using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaleidoscope.Math.Set.Finite
{
    public class YRFiniteSet : YRSet, IYRFiniteSet
    {
        protected IReadOnlyList<IYRSet> _elements;
        public List<IYRSet> Elements => _elements.ToList();
        protected YRFiniteSet()
        {

        }
        public YRFiniteSet(IEnumerable<IYRSet> elements)
        {
            if (elements is null) 
                throw new ArgumentNullException(nameof(elements));
            var potential = elements.Distinct().ToArray();
            if(potential.Length == 0)
                throw new ArgumentNullException("Impossible");
            _elements = potential;
        }

        public override async IValueTask<bool> Contains(IYRSet element)
        {
            foreach(var e in _elements)
            {
                if(e.Equals(element)) 
                    return true;
            }
            return false;
        }

        public override async IValueTask<bool> ZFEquals(IYRSet other)
        {
            if (other is not IYRFiniteSet finiteSet)
                return false;

            await foreach (var otherElement in finiteSet.Enumerate())
            {
                if (await Contains(otherElement))
                    return true;
            }
            return false;
        }
        public override IAsyncEnumerable<IYRSet> Enumerate()
        {
            return _elements.ToAsyncEnumerable();
        }

        public override IValueTask<IYRSet> Union()
        {
            throw new NotImplementedException();
        }

        public override IValueTask<IYRSet> Power()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"FiniteSet[{string.Join(", ", _elements.Select(e => e?.ToString() ?? "null"))}]";
        }

    }
}

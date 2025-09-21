using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Finite;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Standard.Naturals.VonNeumann
{
    public class YRVonNeumannOrdinal : YRFiniteSet, IYRNaturalNumber
    {
        public List<IYRSet> Elements => _elements.ToList();
        public YRVonNeumannOrdinal(IEnumerable<IYRSet> elements) : base(elements)
        {
        }

        public async ValueTask<string> ToStringAsync()
        {
            var lastElement = _elements.Last();
            if (_elements.Last() == YRSet.Empty)
                return "0";
            var count = await _elements.Last().Enumerate().CountAsync() - 1;
            return count.ToString();
        }
        public override string ToString()
        {
            return (_elements.Count - 1).ToString();
        }
    }
}

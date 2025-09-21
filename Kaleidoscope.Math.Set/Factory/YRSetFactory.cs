using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using Kaleidoscope.Math.Set.Finite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set.Factory
{
    public static class YRSetFactory
    {
        public static async ValueTask<IYRFiniteSet> CreateSet(IEnumerable<IYRSet> sets)
        {
            if (sets == null || sets.Count() == 0)
                return YRSet.Empty;
            return new YRFiniteSet(sets);
        }
    }
}

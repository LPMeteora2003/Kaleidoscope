using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using Kaleidoscope.Math.Set.Abstractions.Infinite;
using Kaleidoscope.Math.Set.Factory;
using Kaleidoscope.Math.Set.Finite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set
{
    public abstract class YRSet : IYRSet
    {
        public abstract IValueTask<bool> Contains(IYRSet element);
        public abstract IValueTask<bool> ZFEquals(IYRSet other);

        public virtual async IValueTask<IYRSet> Pair(IYRSet other)
        {
            return await this.ZFEquals(other) 
                ? await YRSet.CreateSet(new IYRSet[] { this })
                : await YRSet.CreateSet(new IYRSet[] { this, other });
        }

        public abstract IValueTask<IYRSet> Union();
        public abstract IValueTask<IYRSet> Power();
        public abstract IAsyncEnumerable<IYRSet> Enumerate();

        public static IAxiomaticSystem AxiomaticSystem { get; set;}
        public static IYREmptySet Empty => AxiomaticSystem.ExistanceAxioms.OfType<IYREmptySet>().FirstOrDefault() ?? new YREmptySet();
        public static IYRInfiniteSet Infinity => AxiomaticSystem.ExistanceAxioms.OfType<IYRInfiniteSet>().First();
        public static ValueTask<IYRFiniteSet> CreateSet(IEnumerable<IYRSet> sets) => YRSetFactory.CreateSet(sets);

    }
}

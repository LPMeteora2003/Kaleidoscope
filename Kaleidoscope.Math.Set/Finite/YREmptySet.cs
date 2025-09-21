using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using Kaleidoscope.Math.Set.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaleidoscope.Math.Set.Finite
{
    public struct YREmptySet : IYREmptySet, IYRFiniteSet
    {
        public async IValueTask<bool> Contains(IYRSet element) => false;

        public IAsyncEnumerable<IYRSet> Enumerate() => AsyncEnumerable.Empty<IYRSet>(); 

        public async IValueTask<IYRSet> Pair(IYRSet other)
        {
            return other is IYREmptySet
                ? await YRSet.CreateSet(new IYRSet[] { this })
                : await YRSet.CreateSet(new IYRSet[] { this, other });
        }

        public async IValueTask<IYRSet> Power() => this;

        public async IValueTask<IYRSet> Union() => this;

        public async IValueTask<bool> ZFEquals(IYRSet other) => other is YREmptySet;        
        public static bool operator ==(YREmptySet left, IYRSet right) => right is YREmptySet;
        public static bool operator ==(IYRSet left, YREmptySet right) => left is YREmptySet;
        public static bool operator !=(YREmptySet left, IYRSet right) => right is not YREmptySet;
        public static bool operator !=(IYRSet left, YREmptySet right) => left is not YREmptySet;
    }
}

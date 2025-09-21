using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using Kaleidoscope.Math.Set.Abstractions.Finite;
using Kaleidoscope.Math.Set.Finite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Set
{
    public struct YREmptyAxiomSet : IYREmptySet, IYRAxiomSet
    {
        YREmptySet _emptySet;
        public YREmptySet EmptySet => _emptySet;
        public IValueTask<bool> Contains(IYRSet element) => _emptySet.Contains(element);


        public IValueTask<IYRSet> Pair(IYRSet other) => _emptySet.Pair(other);
        public IValueTask<IYRSet> Power() => _emptySet.Power();
        public IValueTask<IYRSet> Union() => _emptySet.Union();
        public IValueTask<bool> ZFEquals(IYRSet other) => _emptySet.ZFEquals(other);
        public IAsyncEnumerable<IYRSet> Enumerate() => _emptySet.Enumerate();
        public static bool operator ==(YREmptyAxiomSet left, IYRSet right) => right is IYRAxiom;
        public static bool operator ==(IYRSet left, YREmptyAxiomSet right) => left is IYRAxiom;
        public static bool operator !=(YREmptyAxiomSet left, IYRSet right) => right is not IYRAxiom;
        public static bool operator !=(IYRSet left, YREmptyAxiomSet right) => left is not IYRAxiom;

    }
}

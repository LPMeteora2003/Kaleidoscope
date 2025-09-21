using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Predicates
{
    public class YRTarskiMetaPredicate : YRSingleton<YRTarskiMetaPredicate>, IYRBinaryPredicate, IYRAnnotatedPredicate
    {
        public string Name => "⊢";
        public string Description => "TarskiMetaPredicate";
    }
}

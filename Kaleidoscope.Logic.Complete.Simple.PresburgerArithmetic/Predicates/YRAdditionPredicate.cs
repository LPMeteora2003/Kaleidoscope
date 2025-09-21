using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Predicates
{
    public class YRAdditionPredicate : YRSingleton<YRAdditionPredicate>, IYRBinaryPredicate, IYRAnnotatedPredicate
    {
        public string Name => "+";

        public string Description => "AdditionPredicate";
    }
}

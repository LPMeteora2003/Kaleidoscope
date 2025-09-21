using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Predicates;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Statements
{
    public class YRStatementAddZeroRight : YRSingleton<YRStatementAddZeroRight>, IYRAnnotatedStatement
    {
        public string Name => "ZeroIsRightIdentityForAddition";

        public string Description => "For all x, x + 0 = x.";

        public IYRPredicate ConstructorPredicate => YRAdditionPredicate.Instance;
    }
}

using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Predicates;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Statements
{
    public class YRStatementAddZeroLeft : YRSingleton<YRStatementAddZeroLeft>, IYRAnnotatedStatement
    {
        public string Name => "ZeroIsLeftIdentityForAddition";

        public string Description => "For all x, 0 + x = x.";

        public IYRPredicate ConstructorPredicate => YRAdditionPredicate.Instance;
    }
}

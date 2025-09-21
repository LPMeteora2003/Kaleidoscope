using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Predicates;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Statements
{
    public class YRTarskiPhiStatement : YRSingleton<YRTarskiPhiStatement>, IYRAnnotatedStatement
    {
        public string Name => "Phi";
        public string Description => "Consequent statement";
        public IYRPredicate ConstructorPredicate => YRTarskiMetaPredicate.Instance;
    }
}

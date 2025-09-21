using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Contexts
{
    public class YRTarskiGammaContext : YRSingleton<YRTarskiGammaContext>, IYRAnnotatedContext
    {
        public IYRContext Context => YRTarskiGammaContext.Instance;
        public IYRStatement Statement => YRTarskiPhiStatement.Instance;
        public string Name => "Gamma";
        public string Description => "Assumptions containing Phi";
    }
}

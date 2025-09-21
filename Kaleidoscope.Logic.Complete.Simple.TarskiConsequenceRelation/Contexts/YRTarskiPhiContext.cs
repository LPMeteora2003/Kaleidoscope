using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Contexts
{
    public class YRTarskiPhiContext : YRSingleton<YRTarskiPhiContext>, IYRAnnotatedContext
    {
        public IYRContext Context => YRTarskiPhiContext.Instance;
        public IYRStatement Statement => YRTarskiPhiStatement.Instance;
        public string Name => "PhiContext";
        public string Description => "Conclusion Phi";
    }
}

using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Verdicts
{
    public class YRNoConsequenceVerdict : YRSingleton<YRNoConsequenceVerdict>, IYRVerdict
    {
        public IYRVerdict Verdict => YRNoConsequenceVerdict.Instance;
    }
}

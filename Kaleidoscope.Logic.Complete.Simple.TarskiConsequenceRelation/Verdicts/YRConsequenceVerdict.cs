using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Verdicts
{
    public class YRConsequenceVerdict : YRSingleton<YRConsequenceVerdict>, IYRVerdict
    {
        public IYRVerdict Verdict => YRConsequenceVerdict.Instance;
    }
}

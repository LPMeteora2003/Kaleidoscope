using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Contexts;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Judgements
{
    public class YRTarskiConsequenceJudgement : YRSingleton<YRTarskiConsequenceJudgement>, IYRJudgement
    {
        public IYRJudgement Judgement => YRTarskiConsequenceJudgement.Instance;
        public IYRContext Premise => YRTarskiGammaContext.Instance;
        public IYRVerdict Verdict => YRConsequenceVerdict.Instance;
    }
}

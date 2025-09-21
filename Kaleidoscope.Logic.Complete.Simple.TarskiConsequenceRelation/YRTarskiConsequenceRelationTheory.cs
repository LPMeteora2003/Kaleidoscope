using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Judgements;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation
{
    public class YRTarskiConsequenceRelationTheory : YRSingleton<YRTarskiConsequenceRelationTheory>, IYRLogicConstruct
    {
        public IYRJudgement Judgement => YRTarskiConsequenceJudgement.Instance;
        public IYRVerdict Verdict => YRConsequenceVerdict.Instance;
    }
}

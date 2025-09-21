using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Judgements;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements
{
    public class YRPureEqualityExactlyNElementsTheory : YRSingleton<YRPureEqualityExactlyNElementsTheory>, IYRLogicConstruct
    {
        public IYRJudgement Judgement => YRPureEqualityExactlyNElementsJudgement.Instance;

        public IYRVerdict Verdict => EqualVerdict.Instance;
    }
}

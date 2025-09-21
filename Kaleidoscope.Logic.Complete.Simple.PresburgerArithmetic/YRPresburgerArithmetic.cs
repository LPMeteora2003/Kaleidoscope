using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Judgements;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic
{
    public class YRPresburgerArithmetic : YRSingleton<YRPresburgerArithmetic>, IYRLogicConstruct
    {
        public IYRJudgement Judgement => YRPresburgerArithmeticJudgement.Instance;

        public IYRVerdict Verdict => YRNullVerdict.Instance;
    }
}

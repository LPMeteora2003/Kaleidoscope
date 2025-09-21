using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Contexts;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Judgements
{
    public class YRPresburgerArithmeticJudgement : YRSingleton<YRPresburgerArithmeticJudgement>, IYRJudgement
    {
        public IYRJudgement Judgement => YRPresburgerArithmeticJudgement.Instance;

        public IYRContext Premise => YRContextAddZeroLeft.Instance;

        public IYRVerdict Verdict => YRNullVerdict.Instance;
    }
}

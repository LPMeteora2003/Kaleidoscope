using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Verdicts;
using Kaleidoscope.Logic.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Judgements
{
    public class YRPureEqualityExactlyNElementsJudgement : YRSingleton<YRPureEqualityExactlyNElementsJudgement>, IYRJudgement
    {
        public IYRContext Judgement => YRPureEqualityExactlyNElementsJudgement.Instance;

        public IYRContext Premise => throw new NotImplementedException();

        public IYRContext Conclusion => throw new NotImplementedException();

        public IYRVerdict Verdict => throw new NotImplementedException();
    }
}

using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Verdicts
{
    public class YRNullVerdict : YRSingleton<YRNullVerdict>, IYRVerdict
    {
        public IYRVerdict Verdict => YRNullVerdict.Instance;
    }
}

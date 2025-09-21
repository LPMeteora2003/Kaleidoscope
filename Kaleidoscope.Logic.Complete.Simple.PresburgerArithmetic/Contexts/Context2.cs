using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Contexts
{
    public class YRContextAddZeroRight : YRSingleton<YRContextAddZeroRight>, IYRAnnotatedContext
    {
        public IYRContext Context => YRContextAddZeroRight.Instance;

        public IYRStatement Statement => YRStatementAddZeroRight.Instance;

        public string Name => "PresburgerIdentityObservation";

        public string Description => "Zero is a right identity for addition.";
    }
}

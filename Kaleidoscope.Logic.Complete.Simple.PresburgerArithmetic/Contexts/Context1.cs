using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Contexts
{
    public class YRContextAddZeroLeft : YRSingleton<YRContextAddZeroLeft>, IYRAnnotatedContext
    {
        public IYRContext Context => YRContextAddZeroLeft.Instance;

        public IYRStatement Statement => YRStatementAddZeroLeft.Instance;

        public string Name => "PresburgerAxiomZeroLeftIdentity";

        public string Description => "Zero is a left identity for addition.";
    }
}

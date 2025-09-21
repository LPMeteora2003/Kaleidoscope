using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Judgements;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Contexts
{
    public class Context1 : YRSingleton<Context1>, IYRAnnotatedContext
    {
        public IYRContext Context => Context1.Instance;

        public IYRStatement Statement => Statement1.Instance;

        public string Name => "AxiomContext";

        public string Description => "Axioms: There exist exactly n distinct elements.";
    }
}

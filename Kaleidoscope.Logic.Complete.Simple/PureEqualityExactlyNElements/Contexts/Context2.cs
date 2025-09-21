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
    public class Context2 : YRSingleton<Context2>, IYRAnnotatedContext
    {
        public IYRContext Context => Context2.Instance;

        public IYRStatement Statement => Statement2.Instance;

        public string Name => "Some other Context";

        public string Description => "Some other Context.";
    }
}

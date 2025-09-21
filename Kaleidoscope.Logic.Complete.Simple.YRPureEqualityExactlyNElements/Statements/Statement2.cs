using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Predicates;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Statements
{
    public class Statement2 : YRSingleton<Statement2>, IYRAnnotatedStatement
    {
        public string Name => "No more than n distinc elements.";

        public string Description => "There exist no more than n distinct elements.";

        public IYRPredicate ConstructorPredicate => EqualityPredicate.Instance;
    }
}

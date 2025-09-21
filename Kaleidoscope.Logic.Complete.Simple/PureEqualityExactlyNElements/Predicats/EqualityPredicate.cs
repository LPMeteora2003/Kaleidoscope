using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Judgements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Predicats
{
    public class EqualityPredicate : YRSingleton<EqualityPredicate>, IYRBinaryPredicate, IYRAnnotatedPredicate
    {
        public string Name => "=";

        public string Description => "EqualityPredicate";
    }
}

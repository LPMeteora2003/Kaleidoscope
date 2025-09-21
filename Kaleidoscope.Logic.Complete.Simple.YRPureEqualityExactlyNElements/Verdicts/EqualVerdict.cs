using Kaleidoscope.Core;
using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Verdicts
{
    public class EqualVerdict : YRSingleton<EqualVerdict>, IYRVerdict
    {
        public IYRVerdict Verdict => NotEqualVerdict.Instance;
    }
}

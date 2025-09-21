using Kaleidoscope.Core;
using Kaleidoscope.Logic.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Verdicts
{
    public class NotEqualVerdict : YRSingleton<NotEqualVerdict>, IYRVerdict
    {
        public IYRVerdict Verdict => NotEqualVerdict.Instance;
    }
}

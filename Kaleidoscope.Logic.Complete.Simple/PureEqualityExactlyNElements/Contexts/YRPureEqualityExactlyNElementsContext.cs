using Kaleidoscope.Core;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Judgements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Contexts
{
    public class YRPureEqualityExactlyNElementsContext : YRSingleton<YRPureEqualityExactlyNElementsContext>, IYRContext
    {
        public IYRContext IYRContext => throw new NotImplementedException();

        public IYRStatement Statement => throw new NotImplementedException();

        public IYRContext Judgement => throw new NotImplementedException();

        public IYRContext Premise => throw new NotImplementedException();

        public IYRContext Conclusion => throw new NotImplementedException();

        public IYRVerdict Verdict => throw new NotImplementedException();
    }
}

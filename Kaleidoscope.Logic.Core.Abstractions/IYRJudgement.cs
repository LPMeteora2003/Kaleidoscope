using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    public interface IYRJudgement : IYRSingleton
    {
        IYRJudgement Judgement { get; }
        IYRContext Premise { get; }
        IYRContext Conclusion {  get; }
        IYRVerdict Verdict { get; }
    }
}

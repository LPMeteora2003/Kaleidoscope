using Kaleidoscope.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    public interface IYRLogicConstruct : IYRSingleton
    {
        IYRJudgement Judgement { get; }
        IYRVerdict Verdict { get; }
    }
}

using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    public interface IYRVerdict : IYRSingleton
    {
        IYRVerdict Verdict { get; }
    }
}

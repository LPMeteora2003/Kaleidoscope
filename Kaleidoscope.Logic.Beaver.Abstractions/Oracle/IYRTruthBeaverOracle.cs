using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Beaver.Abstractions.Oracle
{
    public interface IYRTruthBeaverOracle
    {
        ValueTask<bool> Forsee(IYRStatement y);
    }
}

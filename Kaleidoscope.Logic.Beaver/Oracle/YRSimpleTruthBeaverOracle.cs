using Kaleidoscope.Logic.Beaver.Abstractions.Oracle;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Beaver.Oracle
{
    public class YRSimpleTruthBeaverOracle : IYRTruthBeaverOracle
    {
        public ValueTask<bool> Forsee(IYRStatement y)
        {
            throw new NotImplementedException();
        }
    }
}

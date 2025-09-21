using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Beaver.Abstractions.Oracle;
using Kaleidoscope.Logic.Beaver.Abstractions.Oracle.Magic;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Beaver.Oracle
{
    public class YRSimpleEqualityBeaverOracle : IYREqualityBeaverOracle
    {
        private readonly IYRBeaverOracleMagic _oracleMagic;

        public YRSimpleEqualityBeaverOracle(IYRBeaverOracleMagic oracleMagic)
        {
            _oracleMagic = oracleMagic;
        }
        public async IValueTask<bool> Forsee(IYRStatement y, IYRStatement x)
        {
            if (y == x)
                return true;

            return await _oracleMagic.AreStatementsEqual(y, x);
        }
    }
}

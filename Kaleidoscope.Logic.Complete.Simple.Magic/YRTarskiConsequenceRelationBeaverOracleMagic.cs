using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Beaver.Abstractions.Oracle.Magic;
using Kaleidoscope.Logic.Complete.Simple.TarskiConsequenceRelation.Statements;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.Magic
{
    public class YRTarskiConsequenceRelationBeaverOracleMagic : IYRBeaverOracleMagic
    {
        public async IValueTask<bool> AreStatementsEqual(IYRStatement x, IYRStatement y)
        {
            if (x == y) return true;
            if (x is YRTarskiPhiStatement && y is YRTarskiPhiStatement) return true;
            return false;
        }

        public async IValueTask<bool> IsTrue(IYRStatement x)
        {
            if (x is YRTarskiPhiStatement) return true;
            return false;
        }
    }
}

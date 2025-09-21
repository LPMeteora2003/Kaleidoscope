using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Beaver.Abstractions.Oracle.Magic;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using Kaleidoscope.Logic.Complete.Simple.PresburgerArithmetic.Statements;

namespace Kaleidoscope.Logic.Complete.Simple.Magic
{
    public class YRPresburgerArithmeticBeaverOracleMagic : IYRBeaverOracleMagic
    {
        public async IValueTask<bool> AreStatementsEqual(IYRStatement x, IYRStatement y)
        {
            if (x == y)
                return true;

            if (x is YRStatementAddZeroLeft && y is YRStatementAddZeroRight)
                return true;

            if (x is YRStatementAddZeroRight && y is YRStatementAddZeroLeft)
                return true;

            return false;
        }

        public async IValueTask<bool> IsTrue(IYRStatement x)
        {
            if (x is YRStatementAddZeroLeft)
                return true;

            if (x is YRStatementAddZeroRight)
                return true;

            return false;
        }
    }
}

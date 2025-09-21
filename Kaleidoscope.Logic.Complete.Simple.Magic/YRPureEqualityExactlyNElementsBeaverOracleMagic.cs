using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Beaver.Abstractions.Oracle.Magic;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Statements;
using Kaleidoscope.Logic.Core.Abstractions.Statement;

namespace Kaleidoscope.Logic.Complete.Simple.Magic
{
    public class YRPureEqualityExactlyNElementsBeaverOracleMagic : IYRBeaverOracleMagic
    {
        public async IValueTask<bool> AreStatementsEqual(IYRStatement x, IYRStatement y)
        {
            if (x == y)
                return true;

            if (x is Statement1 && y is Statement2)
                return true;

            if (x is Statement2 && y is Statement1)
                return true;

            return false;
        }

        public async IValueTask<bool> IsTrue(IYRStatement x)
        {
            if (x is Statement1)
                return true;

            if (x is Statement2)
                return true;

            return false;
        }
    }
}

using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Beaver.Abstractions.Oracle.Magic
{
    public interface IYRBeaverOracleMagic
    {
        IValueTask<bool> AreStatementsEqual(IYRStatement x, IYRStatement y);
        IValueTask<bool> IsTrue(IYRStatement x);
    }
}

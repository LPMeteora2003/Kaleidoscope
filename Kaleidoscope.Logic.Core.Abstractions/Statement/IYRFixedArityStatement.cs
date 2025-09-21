using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions.Statement
{
    public interface IYRFixedArityStatement : IYRStatement
    {
        new IYRFixedArityPredicate Predicate { get; }
    }
}

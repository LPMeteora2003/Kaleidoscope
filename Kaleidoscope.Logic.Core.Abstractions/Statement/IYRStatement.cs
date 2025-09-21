using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions.Statement
{
    public interface IYRStatement : IYRSingleton
    {
        IYRPredicate Predicate { get; }
    }
}

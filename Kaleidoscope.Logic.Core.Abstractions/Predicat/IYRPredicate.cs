using Kaleidoscope.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions.Predicat
{
    public interface IYRPredicate : IYRSingleton
    {
    }
    public interface IYRAnnotatedPredicate : IYRPredicate
    {
        string Name { get; }
        string Description { get; }
    }
}

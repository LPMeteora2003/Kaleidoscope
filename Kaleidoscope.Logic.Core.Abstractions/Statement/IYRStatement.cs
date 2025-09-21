using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;

namespace Kaleidoscope.Logic.Core.Abstractions.Statement
{
    public interface IYRStatement : IYRSingleton
    {
        IYRPredicate ConstructorPredicate { get; }
    }
    public interface IYRAnnotatedStatement : IYRStatement
    {
        string Name { get; }
        string Description { get; }
    }
}

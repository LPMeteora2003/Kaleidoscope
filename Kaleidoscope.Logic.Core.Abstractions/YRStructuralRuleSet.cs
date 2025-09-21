using System;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    [Flags]
    public enum YRStructuralRuleSet
    {
        NULL = 0,
        NONE = 1,
        WEAKENING = 2,
        CONTRACTION = 3,
        EXCHANGE = 4
    }
}

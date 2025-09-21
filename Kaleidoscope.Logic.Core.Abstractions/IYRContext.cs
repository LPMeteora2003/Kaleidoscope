using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    public interface IYRContext : IYRSingleton
    {
        IYRContext IYRContext { get; }
        IYRStatement Statement { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Abstractions
{
    public interface IYRSingleton
    {
    }

    public interface IYRSingleton<T> where T : IYRSingleton<T>
    {
        abstract static T Instance { get; }
    }
}

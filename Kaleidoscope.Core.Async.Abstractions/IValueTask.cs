using Kaleidoscope.Core.Async.Abstractions.YRValueTask;
using Kaleidoscope.Core.Async.MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions
{
    [AsyncMethodBuilder(typeof(ValueTaskInterfaceAsyncMethodBuilder))]
    public interface IValueTask
    {
        IAwaiter GetAwaiter();
        IConfiguredTask ConfigureAwait(bool continueOnCapturedContext);        
    }
}

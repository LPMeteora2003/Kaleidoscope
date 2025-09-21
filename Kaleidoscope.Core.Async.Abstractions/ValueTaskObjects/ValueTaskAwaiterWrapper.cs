using Kaleidoscope.Core.Async.MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    public class ValueTaskAwaiterWrapper : ICriticalNotifyCompletion, IAwaiter
    {
        private ValueTaskAwaiter awaiter;
        public ValueTaskAwaiterWrapper(ValueTaskAwaiter awaiter) => this.awaiter = awaiter;
        bool IAwaiter.IsCompleted => awaiter.IsCompleted;
        void INotifyCompletion.OnCompleted(Action continuation) => awaiter.OnCompleted(continuation);
        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => awaiter.UnsafeOnCompleted(continuation);
        void IAwaiter.GetResult() => awaiter.GetResult();
    }
}

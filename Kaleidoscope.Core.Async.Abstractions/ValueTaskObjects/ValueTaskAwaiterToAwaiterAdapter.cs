using Kaleidoscope.Core.Async.MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    internal class ValueTaskAwaiterToAwaiterAdapter<TResult> : IAwaiter
    {
        private readonly ValueTaskAwaiter<TResult> awaiter;

        public ValueTaskAwaiterToAwaiterAdapter(ValueTaskAwaiter<TResult> awaiter)
        {
            this.awaiter = awaiter;
        }

        bool IAwaiter.IsCompleted => this.awaiter.IsCompleted;

        void INotifyCompletion.OnCompleted(Action continuation) => this.awaiter.OnCompleted(continuation);

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation) => this.awaiter.UnsafeOnCompleted(continuation);

        void IAwaiter.GetResult() => this.awaiter.GetResult();
    }
}

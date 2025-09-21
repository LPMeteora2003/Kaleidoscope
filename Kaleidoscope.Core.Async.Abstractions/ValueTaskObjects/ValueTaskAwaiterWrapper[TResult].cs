using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Kaleidoscope.Core.Async.MorseCode;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    internal class ValueTaskAwaiterWrapper<TResult> : IAwaiter<TResult>
    {
        private ValueTaskAwaiter<TResult> awaiter;

        public ValueTaskAwaiterWrapper(ValueTaskAwaiter<TResult> awaiter)
        {
            this.awaiter = awaiter;
        }

        bool IAwaiter<TResult>.IsCompleted
        {
            get
            {
                return this.awaiter.IsCompleted;
            }
        }

        void INotifyCompletion.OnCompleted(Action continuation)
        {
            this.awaiter.OnCompleted(continuation);
        }

        void ICriticalNotifyCompletion.UnsafeOnCompleted(Action continuation)
        {
            this.awaiter.UnsafeOnCompleted(continuation);
        }

        TResult IAwaiter<TResult>.GetResult()
        {
            return this.awaiter.GetResult();
        }
    }
}

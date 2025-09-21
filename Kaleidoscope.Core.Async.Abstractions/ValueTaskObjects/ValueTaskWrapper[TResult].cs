using Kaleidoscope.Core.Async.MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    internal class ValueTaskWrapper<TResult> : IValueTask<TResult>
    {
        private readonly ValueTask<TResult> valueTask;

        public ValueTaskWrapper(ValueTask<TResult> valueTask) => this.valueTask = valueTask;

        IAwaiter IValueTask.GetAwaiter() => new ValueTaskAwaiterToAwaiterAdapter<TResult>(this.valueTask.GetAwaiter());

        IAwaiter<TResult> IValueTask<TResult>.GetAwaiter() => new ValueTaskAwaiterWrapper<TResult>(this.valueTask.GetAwaiter());

        IConfiguredTask IValueTask.ConfigureAwait(bool continueOnCapturedContext) => new ConfiguredTaskWrapper(this.valueTask.AsTask(), continueOnCapturedContext);

        IConfiguredTask<TResult> IValueTask<TResult>.ConfigureAwait(bool continueOnCapturedContext) => new ConfiguredTaskWrapper<TResult>(this.valueTask.AsTask(), continueOnCapturedContext);
    }
}

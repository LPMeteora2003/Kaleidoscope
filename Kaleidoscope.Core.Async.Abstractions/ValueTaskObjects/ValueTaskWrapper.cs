using Kaleidoscope.Core.Async.MorseCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    internal class ValueTaskWrapper : IValueTask
    {
        private readonly ValueTask valueTask;

        public ValueTaskWrapper(ValueTask valueTask)
        {
            this.valueTask = valueTask;
        }

        IAwaiter IValueTask.GetAwaiter()
        {
            return new ValueTaskAwaiterWrapper(this.valueTask.GetAwaiter());
        }

        IConfiguredTask IValueTask.ConfigureAwait(bool continueOnCapturedContext)
        {
            return new ConfiguredTaskWrapper(this.valueTask.AsTask(), continueOnCapturedContext);
        }
    }
}

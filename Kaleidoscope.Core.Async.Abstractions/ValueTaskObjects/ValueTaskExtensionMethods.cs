using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    public static class ValueTaskExtensionMethods
    {
        public static IValueTask AsIValueTask(this ValueTask valueTask) => new ValueTaskWrapper(valueTask);
        public static IValueTask AsIValueTask(this Task task) => new ValueTaskWrapper(new ValueTask(task));
        public static IValueTask<TResult> AsIValueTask<TResult>(this ValueTask<TResult> valueTask) => new ValueTaskWrapper<TResult>(valueTask);
        public static IValueTask<TResult> AsIValueTask<TResult>(this Task<TResult> task) => new ValueTaskWrapper<TResult>(new ValueTask<TResult>(task));
    }
}

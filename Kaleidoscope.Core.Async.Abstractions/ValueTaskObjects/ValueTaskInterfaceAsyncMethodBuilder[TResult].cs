using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Core.Async.Abstractions.YRValueTask
{
    [StructLayout(LayoutKind.Auto)]
    public struct ValueTaskInterfaceAsyncMethodBuilder<TResult>
    {
        private AsyncTaskMethodBuilder<TResult> builder;
        public IValueTask<TResult> Task => builder.Task.AsIValueTask();
        ValueTaskInterfaceAsyncMethodBuilder(AsyncTaskMethodBuilder<TResult> builder) => this.builder = builder;
        public static ValueTaskInterfaceAsyncMethodBuilder<TResult> Create() => new ValueTaskInterfaceAsyncMethodBuilder<TResult>(AsyncTaskMethodBuilder<TResult>.Create());
        public void SetException(Exception exception) => builder.SetException(exception);
        public void SetResult(TResult result) => builder.SetResult(result);
        public void SetStateMachine(IAsyncStateMachine stateMachine) => builder.SetStateMachine(stateMachine);
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine => builder.Start(ref stateMachine);
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : INotifyCompletion
            where TStateMachine : IAsyncStateMachine => builder.AwaitOnCompleted(ref awaiter, ref stateMachine);
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion
            where TStateMachine : IAsyncStateMachine => builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
    }
}

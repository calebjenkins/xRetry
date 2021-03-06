using System.Threading.Tasks;
using xRetry;

namespace UnitTests.SingleThreaded.Facts
{
    public class AsyncNonDeadlocking
    {
        [RetryFact(1)]
        public async Task AwaitWithinAsyncTask_RunsToCompletion()
        {
            // If .Result is being used further up the call stack and there is only a single thread available, this will cause a deadlock
            await Task.Delay(10);
        }

        [RetryFact(1)]
        public async void AwaitWithinAsyncVoid_RunsToCompletion()
        {
            // If .Result is being used further up the call stack and there is only a single thread available, this will cause a deadlock
            await Task.Delay(10);
        }
    }
}

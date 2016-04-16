using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;

namespace VotingSystemTests.Dependencies
{
    [TestClass]
    public class PCQueueCallEnqueueItem : IPCQueue
    {
        public int EnqueueItemCallCount { get; private set; }

        public PCQueueCallEnqueueItem()
        {
            EnqueueItemCallCount = 0;
        }

        public void enqueueItem(Work item)
        {
            EnqueueItemCallCount++;
        }

        public Work dequeueItem()
        {

            // Can be left as an empty stub since it is not called but must return something 
            return null;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;

namespace VotingSystemTests.Dependencies
{
    [TestClass]
    public class PCQueueNullDequeued : IPCQueue
    {
        public void enqueueItem(Work item)
        {
            // Can be left as an empty stub since it is not called 
        }

        public Work dequeueItem()
        {
            // A null is dequeued
            return null;
        }
    }
}

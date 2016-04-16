using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using System.IO;

namespace VotingSystemTests.Dependencies
{
    [TestClass]
    public class PCQueueKnownDequeued : IPCQueue
    {
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        public void enqueueItem(Work item)
        {
            // Can be left as an empty stub since it is not called 
        }

        public Work dequeueItem()
        {
            // Dequeue a dummy Work instance
            var work = new Work(new ConfigRecord(path, "Constituency-03.xml"), new ConstituencyFileReaderReturnKnownConstituency03());
            return work;
        }
    }
}

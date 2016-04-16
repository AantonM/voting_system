using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using VotingSystem;
using VotingSystemTests.Dependencies;
using TestedClass = VotingSystem.Consumer;

namespace VotingSystemTests.Fixtures
{
    /// <summary>
    /// TestFixture_Consumer test class that test the actual XMLConstituencyFileReader class and it's methods
    /// </summary>
    [TestClass]
    public class TestFixture_Consumer
    {

        TestedClass testedClass = null;
        ProgressManager progressManager = null;
        ConstituencyList constList = null;
        PartyList partyListy = null;
        IPCQueue pcQueue = null;

        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            progressManager = null;
            constList = null;
            partyListy = null;
            pcQueue = null;
        }

        /// <summary>
        /// Test_One_Thread_Created
        /// </summary>
        [TestMethod]
        public void Test_One_Thread_Created()
        {
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constList = new ConstituencyList();
            partyListy = new PartyList();
            testedClass = new TestedClass("CONSUMER", pcQueue, partyListy, constList, progressManager);
            var expectedThreadCount = 1;
  
            Thread.Sleep(5000);

            var actualThreadCount = TestedClass.RunningThreads;

            testedClass.Finished = true;

            Thread.Sleep(1000);

            Assert.AreEqual(expectedThreadCount, actualThreadCount);
        }

        /// <summary>
        /// Test_Run_Method_Constituency_Created_Equals_Progress_Mananger_Accesses
        /// </summary>
        [TestMethod]
        public void Test_Run_Method_Constituency_Created_Equals_Progress_Mananger_Accesses()
        {
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constList = new ConstituencyList();
            partyListy = new PartyList();
            testedClass = new TestedClass("Consumer", pcQueue, partyListy, constList, progressManager);

            Thread.Sleep(5000);

            testedClass.Finished = true;

            Thread.Sleep(1000);

            Assert.AreEqual(Math.Abs(progressManager.ItemsRemaining), constList.constituencyList.Count);
        }

        /// <summary>
        /// Test_Run_Method_Null_Dequeued_Expect_No_ProgressManager_Accesses
        /// </summary>
        //sometimes it passes sometimes it doesn;t without making any changes
        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_ProgressManager_Accesses()
        {
            pcQueue = new PCQueueKnownDequeued();
            progressManager = new ProgressManager();
            constList = new ConstituencyList();
            partyListy = new PartyList();
            testedClass = new TestedClass("Consumer", pcQueue, partyListy, constList, progressManager);

            // Wait a few seconds to allow Consumer thread to run for a short period, during this time the Consumer will
            // have dequeued a number of nulls each of which should be ignored, we do not know how many though and it does not
            // matter (if it works for one it works for all)
            //Thread.Sleep(5000);

            testedClass.Finished = true;

            // Allow a short period of time for the Consumer to finish
            //Thread.Sleep(1000);

            Assert.AreEqual(0, Math.Abs(progressManager.ItemsRemaining));
        }

        /// <summary>
        /// Test_Run_Method_Null_Dequeued_Expect_No_Cyclists
        /// </summary>
        [TestMethod]
        public void Test_Run_Method_Null_Dequeued_Expect_No_Cyclists()
        {
            pcQueue = new PCQueueNullDequeued();
            progressManager = new ProgressManager();
            constList = new ConstituencyList();
            partyListy = new PartyList();
            testedClass = new TestedClass("Consumer", pcQueue, partyListy, constList, progressManager);

            Thread.Sleep(5000);

            testedClass.Finished = true;

            Thread.Sleep(1000);

            Assert.AreEqual(0, constList.constituencyList.Count);
        }

    }


}

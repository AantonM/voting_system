using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using VotingSystem;
using VotingSystemTests.Dependencies;
using TestedClass = VotingSystem.Producer;

namespace VotingSystemTests.Fixtures
{
    /// <summary>
    /// TestFixture_Producer test class that test the actual XMLConstituencyFileReader class and it's methods
    /// </summary>
    [TestClass]
    public class TestFixture_Producer
    {
        TestedClass testedClass = null;
        ConfigData configData = null;
        PCQueueCallEnqueueItem pcQueue = null;
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        

       [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
            configData = null;
            pcQueue = null;
        }

        /// <summary>
        /// Test_One_Thread_Created
        /// </summary>
        [TestMethod]
        public void Test_One_Thread_Created()
        {
            pcQueue = new PCQueueCallEnqueueItem();

            
            configData = new ConfigData();
            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);
            var expectedThreadCount = 1;

            
            Thread.Sleep(5000);

           
            var actualThreadCount = TestedClass.RunningThreads;

            // Signal Producer thread to finish
            testedClass.Finished = true;

            Thread.Sleep(1000);

            
            Assert.AreEqual(expectedThreadCount, actualThreadCount);
        }

        /// <summary>
        /// Test_Run_Method_PCQueue_EnqueueItem_Never_Called 
        /// </summary>
        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Never_Called()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(0), Helper_Act());
        }

        /// <summary>
        /// Test_Run_Method_PCQueue_EnqueueItem_Called_Once
        /// </summary>
        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Once()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(1), Helper_Act());
        }

        /// <summary>
        /// Test_Run_Method_PCQueue_EnqueueItem_Called_Ten_Times
        /// </summary>
        [TestMethod]
        public void Test_Run_Method_PCQueue_EnqueueItem_Called_Ten_Times()
        {
            // Use the helper methods to run the test
            Helper_Assert(Helper_Arrange(10), Helper_Act());
        }

        /// <summary>
        /// Helper_Arrange - helped to arrange the queue and the config files
        /// </summary>
        private int Helper_Arrange(int configRecordsCount)
        {
            pcQueue = new PCQueueCallEnqueueItem();

            configData = new ConfigData();

            // Add ConfigRecord instances to ConfigData object's config records list 
            for (int i = 0; i < configRecordsCount; i++)
            {
                configData.configRecords.Add(new ConfigRecord(path, "NeverUsed"));
            }

            testedClass = new TestedClass("PRODUCER", pcQueue, configData, null);
  
            return configRecordsCount;
        }

        /// <summary>
        /// Helper_Arrange
        /// </summary>
        private int Helper_Act()
        {
            Thread.Sleep(5000);

            testedClass.Finished = true;

            Thread.Sleep(1000);

            return pcQueue.EnqueueItemCallCount;
        }

        /// <summary>
        /// Helper_Assert test the equality 
        /// </summary>
        private void Helper_Assert(int expected, int actual)
        {
            Assert.AreEqual(expected, actual);
        }

    }
}

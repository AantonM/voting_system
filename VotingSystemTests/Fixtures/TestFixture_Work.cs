using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystemTests.Dependencies;
using VotingSystemTests.Helpers;
using TestedClass = VotingSystem.Work;

namespace VotingSystemTests.Fixtures
{

    /// <summary>
    /// TestFixture_Work test class
    /// </summary>
    [TestClass]
    public class TestFixture_Work
    {

        /// <summary>
        /// Test_ReadData_Method_Correct_Constituency_Returned test class - test if the data is read 
        /// correctly
        /// </summary> 
        [TestMethod]
        public void Test_ReadData_Method_Correct_Constituency_Returned()
        {
           
            var ioHandler = new ConstituencyFileReaderReturnKnownConstituency03();

            var testedClass = new TestedClass(null, ioHandler);

            var expectedConstituency = Helper_KnownConstituencyDataRepository.GetKnownConstituency03();

            
            var actualConstituency = testedClass.ReadData();

            // test the name of the constituency
            Assert.AreEqual(expectedConstituency.Name, actualConstituency.Name);

            // test the number of the candidates in each constituency
            Assert.AreEqual(expectedConstituency.candidates.Count, actualConstituency.candidates.Count);

            // Finally chech if the data in the expected candidates and the actual is the same
            for (var i = 0; i < expectedConstituency.candidates.Count; i++)
            {
                Assert.AreEqual(expectedConstituency.candidates[i].FirstName, actualConstituency.candidates[i].FirstName);
                Assert.AreEqual(expectedConstituency.candidates[i].LastName, actualConstituency.candidates[i].LastName);
                Assert.AreEqual(expectedConstituency.candidates[i].party.Name, actualConstituency.candidates[i].party.Name);
                Assert.AreEqual(expectedConstituency.candidates[i].party.PartyVotes, actualConstituency.candidates[i].party.PartyVotes);
                Assert.AreEqual(expectedConstituency.candidates[i].Votes, actualConstituency.candidates[i].Votes);
            }

        }
    }
}

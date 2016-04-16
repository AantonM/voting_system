using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using VotingSystemTests.Helpers;
using TestedClass = VotingSystem.ConstituencyList;
using System.Collections.Generic;
using System.Linq;

namespace VotingSystemTests.Fixtures
{
    [TestClass]
    public class TestFixture_ConstituencyList
    {
        [TestMethod]
        public void Test_GetConstWinner_Method_Invalid_Report()
        {
            var testedClass = new TestedClass();

            var actualCandidates = testedClass.printConstDetails("INVALID");

            // Assert
            // Actual data measures list should be null
            Assert.IsNull(actualCandidates);
        }

        [TestMethod]
        public void Test_GetConstWinner_Method_No_Const()
        {
            var testedClass = new TestedClass();

            var actualWinnerCandidates = new List<Candidates>();

            foreach (var constituency in testedClass.constituencyList)
            {
               actualWinnerCandidates.Add(testedClass.printConstWinner(constituency.Name).First());
            }

            Assert.AreEqual(0, actualWinnerCandidates.Count);
        }

        [TestMethod]
        public void Test_GetConstituencyDetails_Method_Three_Const()
        {
            Helper_Test_GetWinnerCandidates_Method_Three_Constituencies(Helper_KnownConstituencyDataRepository.GetKnownWinners());
        }

        [TestMethod]
        public void Test_GetConstWinner_Method_Three_Const()
        {
            Helper_Test_GetWinnerCandidates_Method_Three_Constituencies(Helper_KnownConstituencyDataRepository.GetKnownWinners());
        }

        private void Helper_Test_GetConstituencyDetails_Method_Three_Constituencies(List<Candidates> expectedWinnerCandidates)
        {
            // Arrange
            // Instantiate a CyclistList object
            var testedClass = new TestedClass();

            // Add the three cyclists Cyclist-01, Cyclist-03, Cyclist-05 to the cyclist list
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency05());


            var actualWinnerCandidates = new List<Candidates>();
            // Act
            // Has cyclists in the list so expected to return an populated data measures list
            foreach (var constituency in testedClass.constituencyList)
            {
                actualWinnerCandidates = testedClass.printConstDetails(constituency.Name);
            }

            // Assert
            // Expected data measures list should contain the same number of items as the actual data measures list
            Assert.AreEqual(expectedWinnerCandidates.Count, actualWinnerCandidates.Count);

            for (var i = 0; i < expectedWinnerCandidates.Count; i++)
            {
                Assert.AreEqual(expectedWinnerCandidates[i].FirstName, actualWinnerCandidates[i].FirstName);
                Assert.AreEqual(expectedWinnerCandidates[i].LastName, actualWinnerCandidates[i].LastName);
                Assert.AreEqual(expectedWinnerCandidates[i].party.Name, actualWinnerCandidates[i].party.Name);
                Assert.AreEqual(expectedWinnerCandidates[i].party.PartyVotes, actualWinnerCandidates[i].party.PartyVotes);
                Assert.AreEqual(expectedWinnerCandidates[i].Votes, actualWinnerCandidates[i].Votes);
            }

        }

        private void Helper_Test_GetWinnerCandidates_Method_Three_Constituencies(List<Candidates> expectedWinnerCandidates)
        {
            // Arrange
            // Instantiate a CyclistList object
            var testedClass = new TestedClass();

            // Add the three cyclists Cyclist-01, Cyclist-03, Cyclist-05 to the cyclist list
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
            testedClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency05());


            var actualWinnerCandidates = new List<Candidates>();
            // Act
            // Has cyclists in the list so expected to return an populated data measures list
            foreach (var constituency in testedClass.constituencyList)
            {
                actualWinnerCandidates.Add(testedClass.printConstWinner(constituency.Name).First());
            }

            // Assert
            // Expected data measures list should contain the same number of items as the actual data measures list
            Assert.AreEqual(expectedWinnerCandidates.Count, actualWinnerCandidates.Count);

            for (var i = 0; i < expectedWinnerCandidates.Count; i++)
            {
                Assert.AreEqual(expectedWinnerCandidates[i].FirstName, actualWinnerCandidates[i].FirstName);
                Assert.AreEqual(expectedWinnerCandidates[i].LastName, actualWinnerCandidates[i].LastName);
                Assert.AreEqual(expectedWinnerCandidates[i].party.Name, actualWinnerCandidates[i].party.Name);
                Assert.AreEqual(expectedWinnerCandidates[i].party.PartyVotes, actualWinnerCandidates[i].party.PartyVotes);
                Assert.AreEqual(expectedWinnerCandidates[i].Votes, actualWinnerCandidates[i].Votes);
            }

        }
    }
}

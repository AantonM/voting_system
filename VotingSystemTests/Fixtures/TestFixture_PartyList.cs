using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using VotingSystemTests.Helpers;
using HelperClass = VotingSystem.ConstituencyList;
using TestedClass = VotingSystem.PartyList;
using System.Collections.Generic;
using System.Linq;

namespace VotingSystemTests.Fixtures
{
    [TestClass]
    public class TestFixture_PartyList
    {
        [TestMethod]
        public void Test_PartyList_Method_Three_Const_Seven_Parties() {
            var testedClass = Helper_Test_PartyList_Method_Three_Const_Seven_Parties();
            var SumPartiesResult = testedClass.SumParties();

            var expectedPartyList = Helper_KnownPartiesDataRepository.GetKnownPartyList();

            Assert.AreEqual(testedClass.partiesList.Count, expectedPartyList.partiesList.Count);

        }

        [TestMethod]
        public void Test_SumParties_Method_Three_Const_Seven_Parties()
        {
            var testedClass = Helper_Test_PartyList_Method_Three_Const_Seven_Parties();
            var SumPartiesResult = testedClass.SumParties();

            var expectedPartyList = Helper_KnownPartiesDataRepository.GetKnownSumPartyList();

            Assert.AreEqual(SumPartiesResult.Count, expectedPartyList.partiesList.Count);

            for (var i = 0; i < expectedPartyList.partiesList.Count; i++)
            {
                Assert.AreEqual(expectedPartyList.partiesList[i].Name, SumPartiesResult[i].Name);
                Assert.AreEqual(expectedPartyList.partiesList[i].PartyVotes, SumPartiesResult[i].PartyVotes);

            }
        }

        [TestMethod]
        public void Test_WinnerParty_Method_Three_Const_Seven_Parties()
        {
            var testedClass = Helper_Test_PartyList_Method_Three_Const_Seven_Parties();
            var SumPartiesResult = testedClass.SumParties();

            var expectedParty = Helper_KnownPartiesDataRepository.GetKnownPartyWinner();

            var WinnerParty = testedClass.SumParties().First();

            Assert.AreEqual(WinnerParty.Name, expectedParty.Name);
            Assert.AreEqual(WinnerParty.PartyVotes, expectedParty.PartyVotes);
        }

        public TestedClass Helper_Test_PartyList_Method_Three_Const_Seven_Parties()
        {
            var helperClass = new HelperClass();

            helperClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
            helperClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
            helperClass.constituencyList.Add(Helper_KnownConstituencyDataRepository.GetKnownConstituency05());

            var testedClass = new TestedClass();
            foreach (var constituency in helperClass.constituencyList)
                foreach (var candidate in constituency.candidates)
                    testedClass.partiesList.Add(candidate.party);

            return testedClass;
        }

        
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using System.Collections.Generic;

namespace VotingSystemTests.Helpers
{
    /// <summary>
    /// Helper_KnownPartiesDataRepository class that constains the predicted / expected parties data
    /// </summary>
    [TestClass]
    public class Helper_KnownPartiesDataRepository
    {

        /// <summary>
        /// GetKnownPartyList - an expected list of all parties
        /// </summary>
        [TestMethod]
        public static PartyList GetKnownPartyList()
        {
            var partyList = new PartyList();

            partyList.partiesList.Add(new Party("Conservative", 135));
            partyList.partiesList.Add(new Party("Green", 200));
            partyList.partiesList.Add(new Party("Liberal", 102));
            partyList.partiesList.Add(new Party("Green", 316));
            partyList.partiesList.Add(new Party("SNP", 170));
            partyList.partiesList.Add(new Party("Conservative", 170));
            partyList.partiesList.Add(new Party("Green", 251));

            return partyList;
        }

        /// <summary>
        /// GetKnownSumPartyList - an expected list of grouped parties and the sum of their votes
        /// </summary>
        [TestMethod]
        public static PartyList GetKnownSumPartyList()
        {
            var partyList = new PartyList();

            partyList.partiesList.Add(new Party("Green", 767));
            partyList.partiesList.Add(new Party("Conservative", 305));
            partyList.partiesList.Add(new Party("SNP", 170));
            partyList.partiesList.Add(new Party("Liberal", 102));

            return partyList;
        }

        /// <summary>
        /// GetKnownPartyWinner - an expected result of the selected party - the one with the highest number of votes
        /// </summary>
        [TestMethod]
        public static Party GetKnownPartyWinner() {

            var PartyWinnes = new Party("Green", 767);

            return PartyWinnes;
        }

    }
}

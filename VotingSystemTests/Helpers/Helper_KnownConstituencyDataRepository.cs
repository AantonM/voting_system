using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using System.Collections.Generic;

namespace VotingSystemTests.Helpers
{
    /// <summary>
    /// Helper_KnownConstituencyDataRepository class that constains the predicted / expected constituency data
    /// </summary>
    [TestClass]
    public class Helper_KnownConstituencyDataRepository
    {
        /// <summary>
        /// GetKnownConstituency01 - expected constituency01
        /// </summary>
        public static Constituency GetKnownConstituency01()
        {
            var constituency = new Constituency("Sunderland North");

            constituency.candidates = new List<Candidates>();
            constituency.candidates.Add(new Candidates("Fred","Bloggs",135,new Party("Conservative", 135)));
            constituency.candidates.Add(new Candidates("Jane", "Smith", 200, new Party("Green", 200)));

            return constituency;
        }

        /// <summary>
        /// GetKnownConstituency03 - expected constituency03
        /// </summary>
        public static Constituency GetKnownConstituency03()
        {
            var constituency = new Constituency("Newcastle");

            constituency.candidates = new List<Candidates>();
            constituency.candidates.Add(new Candidates("Rob", "Miles", 102, new Party("Liberal", 102)));
            constituency.candidates.Add(new Candidates("Harry", "Smith", 316, new Party("Green", 316)));
            constituency.candidates.Add(new Candidates("Christophers", "Randolf", 170, new Party("SNP", 170)));
            
            return constituency;
        }

        /// <summary>
        /// GetKnownConstituency05 - expected constituency05
        /// </summary>
        public static Constituency GetKnownConstituency05()
        {
            var constituency = new Constituency("Sunderland West");

            constituency.candidates = new List<Candidates>();
            constituency.candidates.Add(new Candidates("John", "Johnson", 170, new Party("Conservative", 170)));
            constituency.candidates.Add(new Candidates("Dinies","Naidu", 251, new Party("Green",251)));

            return constituency;
        }

        /// <summary>
        /// GetKnownWinners - expected elected candidates for the three constituencies
        /// </summary>
        public static List<Candidates> GetKnownWinners()
        {
            var winnerCandidates = new List<Candidates>();

            winnerCandidates.Add(new Candidates("Jane", "Smith", 200, new Party("Green", 200)));
            winnerCandidates.Add(new Candidates("Harry", "Smith", 316, new Party("Green", 316)));
            winnerCandidates.Add(new Candidates("Dinies", "Naidu", 251, new Party("Green", 251)));

            return winnerCandidates;


        }
        
    }
}

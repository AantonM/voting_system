using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using VotingSystemTests.Helpers;

namespace VotingSystemTests.Dependencies
{
   
    public class ConstituencyFileReaderReturnKnownConstituency03 : IConstituencyFileReader
    {
        
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            //use helper class to get a known constituency 03 instances
            return Helper_KnownConstituencyDataRepository.GetKnownConstituency03();
        }
    }
}

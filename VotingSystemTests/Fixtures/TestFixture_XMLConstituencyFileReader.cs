using Microsoft.VisualStudio.TestTools.UnitTesting;
using VotingSystem;
using VotingSystemTests.Helpers;
using TestedClass = VotingSystem.XMLConstituencyFileReader;
using System.Reflection;
using System.IO;
using System;

namespace VotingSystemTests.Fixtures
{

    /// <summary>
    /// TestFixture_XMLConstituencyFileReader test class -  test the actual XMLConstituencyFileReader class and it's methods
    /// </summary>
    [TestClass]
    public class TestFixture_XMLConstituencyFileReader
    {
        TestedClass testedClass = null;

        String path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        [TestCleanup]
        public void TestsCleanup()
        {
            testedClass = null;
        }

        /// <summary>
        /// Test_ReadCyclistDataFromFile_Method_File_Not_Exist - test to read a file that doesn't exist
        /// </summary>      
        [TestMethod]
        public void Test_ReadCyclistDataFromFile_Method_File_Not_Exist()
        {
            var fileName = "DOES_NOT_EXIST";

            testedClass = new TestedClass();

            var actualCyclist = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(path, fileName));

            Assert.IsNull(actualCyclist);
        }

        /// <summary>
        /// Test_ReadConstituencyDataFromFile_Method_File_Constituency01_Exists_Is_Valid check the result for the
        /// first constituency
        /// </summary>
        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Constituency01_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Constituecy-01.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency01());
        }

        /// <summary>
        /// Test_ReadConstituencyDataFromFile_Method_File_Constituency03_Exists_Is_Valid check the result for the
        /// third constituency
        /// </summary>
        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Constituency03_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Constituecy-03.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency03());
        }

        /// <summary>
        /// Test_ReadConstituencyDataFromFile_Method_File_Constituency05_Exists_Is_Valid check the result for the
        /// fifth constituency
        /// </summary>
        [TestMethod]
        public void Test_ReadConstituencyDataFromFile_Method_File_Constituency05_Exists_Is_Valid()
        {
            Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid("Constituecy-05.xml", Helper_KnownConstituencyDataRepository.GetKnownConstituency05());

        }

        /// <summary>
        /// Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid - check the results from the read file and the
        /// expected data if they are the same.
        /// </summary>
        private void Helper_Test_ReadConstituencyDataFromFile_Method_File_Exists_Is_Valid(string fileName, Constituency expectedConstituency)
        {
            testedClass = new TestedClass();

            // Act
            // Call the ReadCyclistDataFromFile() method to load and process the known cyclist from the XML format
            var actualConstituency = testedClass.ReadConstituencyDataFromFile(new ConfigRecord(path, fileName));

           
            // check the name of the constituency
            Assert.AreEqual(expectedConstituency.Name, actualConstituency.Name);

            // Next check lengths of the candidates in the constituency
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

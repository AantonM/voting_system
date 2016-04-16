using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace VotingSystem
{
    /// <summary>
    /// XMLConstituencyFileReader class that open the file to read from on the local file system.
    /// </summary>
    public class XMLConstituencyFileReader : IConstituencyFileReader
    {
        /// <summary>
        /// ReadConstituencyDataFromFile method
        /// </summary>
        /// <returns>Extract the data from file</returns>
        /// <param name="configRecord">The name of the file that should be read</param>
        public Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord)
        {
            if (!File.Exists(configRecord.Filename))
            {
                return null;
            }

            // Open file and load into memory as XML
            XDocument xmlDoc = XDocument.Load(configRecord.Path + configRecord.Filename);

            // Create constituency
            var constName = (from c in xmlDoc.Descendants("Constituency")
                              select c.Attribute("name").Value).First();

            Constituency constituency = new Constituency(constName);

            // Create initial candidate for this consituency
            constituency.candidates = new List<Candidates>();

            // Retrieve data for measures and add to candidates
            constituency.candidates = SelectData(xmlDoc, constName);
                                                   
            return constituency;
        }

        /// <summary>
        /// SelectData method
        /// </summary>
        /// <returns>Read the candidates data from the file</returns>
        /// <param name="xmlDoc">The XML file</param>
        /// <param name="constName">The curent constituency name</param>
        private List<Candidates> SelectData(XDocument xmlDoc, String constName)
        {
            var candidateData = (from constituency in xmlDoc.Descendants("Constituency")
                           from candidate in constituency.Descendants("Candidate")
                           //from party in candidate.Attribute("party").Value
                           from fname in candidate.Descendants("Firstname")
                           from lname in candidate.Descendants("Lastname")
                           from votes in candidate.Descendants("Votes")
                           select new Candidates((String)fname, (String)lname, (Int32)votes, new Party(candidate.Attribute("party").Value,(int)votes))).ToList();

            return candidateData;
        }
    }
}

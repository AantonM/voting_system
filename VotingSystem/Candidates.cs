using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// Cadidates class that stores the Cadidates details.
    /// </summary>
    public class Candidates
    {
        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// First name
        /// </value>
        public String FirstName { get; set; }
        
        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// Last name
        /// </value>
        public String LastName { get; set; }

        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// Votes
        /// </value>
        public int Votes { get; set; }

        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// Party
        /// </value>
        public Party party { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fName">The first name of the candidate</param>
        /// <param name="lName">The last name of the candidate</param>
        /// <param name="Votes">The number of votes that the candidates has</param>
        /// <param name="part">An object of the party that the candidates is in</param>
        public Candidates(String fName, String lName, int Votes,Party party)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Votes = Votes;
            this.party = party;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Return the Candidates details</returns>
        public override String ToString()
        {
            return FirstName + LastName + " - " + Votes + " - " + party.Name;
        }
    }
}

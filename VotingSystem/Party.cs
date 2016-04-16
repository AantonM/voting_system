using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VotingSystem
{
    /// <summary>
    /// Party class that stores the Party details.
    /// </summary>
    public class Party
    {
        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// Candidate's details
        /// </summary>
        /// <value>
        /// PartyVotes
        /// </value>
        public int PartyVotes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the party</param>
        /// <param name="partyVotes">The votes that curent party has</param>
        public Party(String name, int partyVotes)
        {
            this.Name = name;
            this.PartyVotes = partyVotes;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Return the Party details</returns>
        public override String ToString()
        {
            return Name + " - " + PartyVotes;
        }
    }
}

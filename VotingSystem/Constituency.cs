using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{

    /// <summary>
    /// Constituency class that stores the Constituency details.
    /// </summary>
    public class Constituency
    {
        /// <summary>
        /// The constituency name
        /// </summary>
        /// <value>
        /// Name
        /// </value>
        public String Name { get; set; }

        /// <summary>
        /// A list of all candidates in this constituency
        /// </summary>
        /// <value>
        /// candidates
        /// </value>
        public List<Candidates> candidates { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the constituency</param>
        public Constituency(String name)
        {
            this.Name = name;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Return the Constituecy name</returns>
        public override String ToString()
        {
            return Name;
        }
    }
}

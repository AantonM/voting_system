using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// PartyList class that stores all Party objects in a list
    /// </summary>
    public class PartyList
    {
        /// <summary>
        /// A list of all Parties objects.
        /// </summary>
        /// <value>
        /// constituencyList
        /// </value>
        public List<Party> partiesList { set; get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PartyList()
        {
            partiesList = new List<Party>();
        }

        /// <summary>
        /// SumParties method.
        /// </summary>
        /// <remarks>
        /// This method contains a LINQ that returns a list of all parties grouped by name and sum of the votes
        /// </remarks>
        public List<Party> SumParties()
        {
            var Result = (from party in partiesList
                         group party by party.Name into g // group the same names
                         orderby g.Sum(_ => _.PartyVotes) descending //sum the votes of the same parties and orderby it
                         select new Party(g.First().Name.ToString(), g.Sum(_ => _.PartyVotes))).ToList();

            //return null if the list is empty instead of zero
            if (!Result.Any())
                return null;
            else
                return Result;

        }
    }
}

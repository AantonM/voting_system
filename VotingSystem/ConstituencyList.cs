using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// ConstituencyList class that stores all Constituency objects in a list
    /// </summary>
    public class ConstituencyList
    {
        /// <summary>
        /// A list of all Constituency objects.
        /// </summary>
        /// <value>
        /// constituencyList
        /// </value>
        public List<Constituency> constituencyList { set; get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConstituencyList()
        {
            constituencyList = new List<Constituency>();
        }

        /// <summary>
        /// printConstDetails method.
        /// </summary>
        /// <remarks>
        /// This method contains a LINQ that returns a list of all candidates in a certain constituency according to it's name
        /// </remarks>
        /// <param name="ConstName">The constituency name that you want to get the candidates for</param>
        public List<Candidates> printConstDetails(String ConstName) {

            var Result = (from constituency in constituencyList
                    from candidates in constituency.candidates
                    where constituency.Name == ConstName
                    select new Candidates(candidates.FirstName, candidates.LastName, candidates.Votes, candidates.party)).ToList();

            //return null if the list is empty instead of zero
            if (!Result.Any())
                return null;
            else
                return Result;
        }

        /// <summary>
        /// printConstWinner method.
        /// </summary>
        /// <remarks>
        /// This method contains a LINQ that returns an ordered list of all candidates in a certain constituency 
        /// according to it's name.When this method is called the only thing that should be added is the .First() method 
        /// that will get the first candidate a.k.a the candidates with highest number of votes.
        /// </remarks>
        /// <param name="ConstName">The constituency name that you want to get the candidates for.</param>
        public List<Candidates> printConstWinner(String ConstName)
        {

            var Result = (from constituency in constituencyList
                    from candidates in constituency.candidates
                    where constituency.Name == ConstName
                    orderby candidates.Votes descending // order the list by number of votes - a.k.a the virst has highest votes
                    select new Candidates(candidates.FirstName, candidates.LastName, candidates.Votes, candidates.party)).ToList();

            //return null if the list is empty instead of zero
            if (!Result.Any())
                return null;
            else
                return Result;
        }
    }
}

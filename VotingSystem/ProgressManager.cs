using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// ProgressManager class that follow the prograss of the work
    /// </summary>
    public class ProgressManager
    {
        private int itemsRemaining;

        /// <summary>
        /// The number of remained items
        /// </summary>
        /// <value>
        /// ItemsRemaining
        /// </value>
        public int ItemsRemaining
        {
            get
            {
                return itemsRemaining;
            }

            set
            {
                lock (this)
                {
                    // MUTEX control for potential multiple thread access to this property
                    itemsRemaining = value;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProgressManager()
        {
            this.ItemsRemaining = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The number of items</param>
        public ProgressManager(int items)
        {
            this.ItemsRemaining = items;
        }
    }
}

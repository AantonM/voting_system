using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// IPCQueue interface.
    /// </summary>
    public interface IPCQueue
    {
        /// <summary>
        /// enqueueItem method
        /// </summary>
        /// <remarks>
        /// Enqueue the provided item
        /// </remarks>
        /// <param name="item">The work item</param>
        void enqueueItem(Work item);

        /// <summary>
        /// dequeueItem method
        /// </summary>
        Work dequeueItem();
    }
}

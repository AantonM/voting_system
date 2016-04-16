using System;
using System.Collections.Generic;
using System.Threading;

namespace VotingSystem
{
    /// <summary>
    /// PCQueue class
    /// </summary>
    /// <remarks>
    /// enqueue and dequeue items preparing them for the consumer
    /// </remarks>
	public class PCQueue : IPCQueue
	{
		private Queue<Work> queue = new Queue<Work>(); // Embedded queue collection to hold work items

        /// <summary>
        /// Maximum number of work items allowed on the queue, or 0 to have an unbounded queue size
        /// </summary>
        /// <value>
        /// Capacity
        /// </value>
		public int Capacity { get; private set; }

        /// <summary>
        /// Only allows enqueue and dequeue of work items when active
        /// </summary>
        /// <value>
        /// Active
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <value>
        /// Defaults to an unbounded queue size, so capacity = 0
        /// </value>
        public PCQueue()
		{ 
			Capacity = 0;
			Active = true;
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <value>
        /// Sets a bounded queue size = capacity, or an unbounded queue size if capacity is passed in as < 1
        /// </value>
        /// <param name="capacity">bounded queue size</param>
		public PCQueue(int capacity)
		{	
			this.Capacity = Math.Max(capacity, 0); // ie. cannot be a negative capacity
			Active = true;
		}

        /// <summary>
        /// enqueueItem method
        /// </summary>
        /// <value>
        /// Putting the item = Work in the queue
        /// </value>
        /// <param name="item">Work object</param>
		public void enqueueItem(Work item)
		{
			// Use this instance of the PCQueue as the locking object for the concurrency related critical regions
			// and thread synchronisation
			lock (this)
			{
				// While this PCQueue is active and full, wait (remember a capacity = 0 means never full)
				while(Active && (Capacity != 0) && (queue.Count == Capacity))
				{
					Monitor.Wait(this);
				}

				// If this PCQueue is active it now has space for a work item so enqueue it 
				if(Active)
				{
					queue.Enqueue(item);

					// Use pulse to inform that the queue is now not empty
					Monitor.Pulse(this);
				}
			}
		}

        /// <summary>
        /// dequeueItem method
        /// </summary>
        /// <value>
        /// Removing the item = Work from the queue
        /// </value>
        public Work dequeueItem()
		{
			Work item = null;

			// Use this instance of the PCQueue as the locking object for the concurrency related critical regions
			// and thread synchronisation
			lock(this)
			{
				// While this PCQueue is active and empty, wait
				while(Active && (queue.Count == 0))
				{
					Monitor.Wait(this);
				}

				// If this PCQueue is active it now has a work item so dequeue a work item and return its reference
				// or return null if the PCQueue is not active
				if(Active)
				{
					item = queue.Dequeue();

					// Use pulse to inform that the queue is now not full
					Monitor.Pulse(this);
				}
			}

			return item;
		}
	}
}

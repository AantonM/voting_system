using System;
using System.Collections.Generic;
using System.Threading;

namespace VotingSystem
{
    /// <summary>
    /// Consumer class that runs on its own thread and continues to run until instructed to finish
    /// </summary>
    /// <remarks>
    /// Create the Lists of Parties and Constituencies
    /// </remarks>
    public class Consumer
	{
		private static int runningThreads = 0; 
		private static object locker = new object(); 
		private const int duration = 1000; 

		private string id;

        /// <summary>
        /// The treads
        /// </summary>
        /// <value>
        /// T
        /// </value>
        public Thread T { get; private set; } 
		private bool finished; 

		private IPCQueue pcQueue; 

        private PartyList partylist; // List of partyies which will be added to
        private Constituency constituency; //Certain constituency
        private ConstituencyList consituencyList; //List of all constituencies

        private ProgressManager progManager;

        /// <summary>
        /// RunningThreads method
        /// </summary>
        /// <value>
        /// RunningThreads a number of running threads
        /// </value>
        public static int RunningThreads 
		{
			get
			{
				return runningThreads;
			}

			private set
			{
				lock (locker)
				{
                    // MUTEX control for potential multiple thread access to the finished flag
                    runningThreads = value;
				}
			}
		}

        /// <summary>
        /// Finished method
        /// </summary>
        /// <value>
        /// A bool value that represent the finish flag
        /// </value>
		public bool Finished 
		{
			get
			{
				return finished;
			}

			set
			{
				lock (this)
				{
					// MUTEX control for potential multiple thread access to the finished flag
					finished = value;
				}
			}
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier for this consumer</param>
        /// <param name="pcQueue">Shared PCQueue that this consumer is consuming work items from</param>
        /// <param name="partyList">List of all parties</param>
        /// <param name="constituencylist">List of all constituencies</param>
        /// <param name="progManager">Prograss Manager</param>
		public Consumer(string id, IPCQueue pcQueue, PartyList partyList, ConstituencyList constituencylist, ProgressManager progManager)
		{
			this.id = id;
			finished = false; 
			this.pcQueue = pcQueue;
            this.partylist = partyList;
            this.consituencyList = constituencylist;
            this.progManager = progManager;
			(T = new Thread(run)).Start(); // Create a new thread for this consumer and get it started
			RunningThreads++; 
		}

        /// <summary>
        /// The code that actually runs on a thread. Create a list of parties and constituencies from the read file
        /// </summary>
        public void run()
		{
			while(!Finished)
			{
				var item = pcQueue.dequeueItem();

				if(!ReferenceEquals(null, item))
				{
                    // Invoke the work item's ReadData() method, to returns the constituency
                    constituency = item.ReadData();
                    
                    // Ensure null returns are ignored (will happen if data not in correct format or can't open file)
                    if (!ReferenceEquals(null, constituency))
                    {
                        // Add this constituency to the constituencyList
                        lock (consituencyList)
                        {
                                //Add this each party of all candidates in this constituency in the partyList
                                foreach (Candidates cand in constituency.candidates)
                                {
                                    partylist.partiesList.Add(cand.party);
                                }                       
                            consituencyList.constituencyList.Add(constituency);
                        }
                        Console.WriteLine("Consumer:{0} has consumed Work Item:{1}", id, item.configRecord.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Consumer:{0} has rejected Work Item:{1}", id, item.configRecord.ToString());
                    }

					// Simulate consumer activity running for duration milliseconds
					//Thread.Sleep(duration);

                    progManager.ItemsRemaining--;
				}
			}

			RunningThreads--;

			Console.WriteLine("Consumer:{0} has finished", id);
		}
	}
}

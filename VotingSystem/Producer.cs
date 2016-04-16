using System;
using System.Threading;

namespace VotingSystem
{
    /// <summary>
    /// Producer class runs on its own thread and continues to run until instructed to finish
    /// </summary>
    /// <remarks>
    /// Read the data from the Config files
    /// </remarks>
    public class Producer
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
        public Thread T { get; private set; } // Thread upon which this instance of a producer runs
		private bool finished; 

		private IPCQueue pcQueue; 

        private ConfigData configFile; 
        private IConstituencyFileReader IOhandler;

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
					// MUTEX control for potential multiple thread access to this property
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
				lock(this)
				{
					// MUTEX control for potential multiple thread access to this property
					finished = value;
				}
			}
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Identifier for this consumer</param>
        /// <param name="pcQueue">Shared PCQueue that this consumer is consuming work items from</param>
        /// <param name="configFile">configFile with the XMLfile names</param>
        /// <param name="IOhandler">Interface for the file reader</param>
		public Producer(string id, IPCQueue pcQueue, ConfigData configFile, IConstituencyFileReader IOhandler)
		{
			this.id = id;
			finished = false; 
			this.pcQueue = pcQueue;
			//counter = 0; // Initial value for the work item counter]
            this.configFile = configFile;
            this.IOhandler = IOhandler;
			(T = new Thread(run)).Start(); // Create a new thread for this producer and get it started
			RunningThreads++;
		}


        /// <summary>
        /// The code that actually runs on a thread. Read the data from files
        /// </summary>
        public void run()
		{
            ConfigRecord configRecord = null;

           
            while (!Finished)
			{
                
                lock (configFile)
                {
                    if (configFile.NextRecord < configFile.configRecords.Count)
                    {
                        configRecord = configFile.configRecords[configFile.NextRecord++];
                    }
                    else
                    {
                        configRecord = null;
                    }
                }

                if (configRecord != null)
                {
                    pcQueue.enqueueItem(new Work(configRecord, IOhandler));

                    Console.WriteLine("Producer:{0} has created and enqueued Work Item:{1}", id, configRecord.ToString());
                }

                // Simulate producer activity running for duration milliseconds
               // Thread.Sleep(duration);
            }

			RunningThreads--;

			Console.WriteLine("Producer:{0} has finished", id);
		}
	}
}

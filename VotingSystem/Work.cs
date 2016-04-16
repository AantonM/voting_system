using System;

namespace VotingSystem
{
    /// <summary>
    /// Work class
    /// </summary>
	public class Work
	{
        /// <summary>
        /// Data used when this work is processed - config record
        /// </summary>
        /// <value>
        /// configRecord
        /// </value>
        public ConfigRecord configRecord { get; private set; } 
        private IConstituencyFileReader IOhandler;

        /// <summary>
        /// Result of the work, when null indicates that the work has not yet been completed
        /// </summary>
        /// <value>
        /// party
        /// </value>
        public Party party { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">The filename</param>
        /// <param name="IOhandler">The interface for the filereader</param>
        public Work(ConfigRecord data, IConstituencyFileReader IOhandler)
		{
			party = null; // Result of the work is initially null, this shows that the work has not yet been completed
			this.configRecord = data; // Data is initialised when the work is instantiated
            this.IOhandler = IOhandler;
		}

        /// <summary>
        /// ReadData method
        /// </summary>
        /// <returns>Reads the specified file and extracts the constituency data from it to store in a constituency object.</returns>
		public Constituency ReadData()
		{
            return IOhandler.ReadConstituencyDataFromFile(configRecord);
		} 
	}
}

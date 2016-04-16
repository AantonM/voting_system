using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// ConfigData class that stores a list of the Cofiguration Records - the filenames.
    /// </summary>
    public class ConfigData
    {
        /// <summary>
        /// configRecords
        /// </summary>
        /// <value>
        /// A list of ConfigRecods / filenames
        /// </value>
        public List<ConfigRecord> configRecords { get; set; }

        /// <summary>
        /// The record number 
        /// </summary>
        /// <value>
        /// NextRecord
        /// </value>
        public int NextRecord {get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigData()
        {
            this.NextRecord = 0;
            configRecords = new List<ConfigRecord>();
        }
    }
}

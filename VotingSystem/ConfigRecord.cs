using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    /// <summary>
    /// ConfigRecord class
    /// </summary>
    public class ConfigRecord
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        /// <value>
        ///Filename
        /// </value>
        public String Filename { get; private set; }
        public String Path { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Filename">The name of the xml file with the data</param>
        public ConfigRecord(String path, String Filename)
        {
            this.Path = Path;
            this.Filename = Filename;
        }

        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>Return the filename</returns>
        public override String ToString()
        {
            return String.Format("{0}", Filename);
        }

    }
}

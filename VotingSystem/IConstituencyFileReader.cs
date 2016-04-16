
namespace VotingSystem
{
    /// <summary>
    /// IConstituencyFileReader interface.
    /// </summary>
    public interface IConstituencyFileReader
    {
        /// <summary>
        /// ReadConstituencyDataFromFile method
        /// </summary>
        /// <remarks>
        /// Read the data from the XML with the provided name
        /// </remarks>
        /// <param name="configRecord">The name of the file that should be read</param>
        Constituency ReadConstituencyDataFromFile(ConfigRecord configRecord);
    }
}

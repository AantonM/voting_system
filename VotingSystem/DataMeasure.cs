using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class DataMeasure
    {
        public String Title { get; private set; }
        public double Value { get; private set; }

        public DataMeasure(String title, double value)
        {
            this.Title = title;
            this.Value = value;
        }

        public override String ToString()
        {
            return String.Format("{0}: {1}", Title, Value);
        }
    }
}

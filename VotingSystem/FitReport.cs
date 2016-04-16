using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class FitReport
    {
        public string ReportType { get; set; }

        public List<DataMeasure> DataMeasuresLeft { get; set; }
        public List<DataMeasure> DataMeasuresRight { get; set; }
        public List<DataMeasure> DataMeasuresAsymmetry { get; set; }

        public FitReport(String reportType)
        {
            this.ReportType = reportType;
            this.DataMeasuresLeft = null;
            this.DataMeasuresRight = null;
            this.DataMeasuresAsymmetry = null;
        }

        public override String ToString()
        {
            String str = String.Format("\tLeft: ");

            // Include the measures for left side
            foreach (var m in DataMeasuresLeft)
            {
                str += String.Format("\n\t\t{0}", m.ToString());
            }


            //include the measures for right side
            str += "\n\tRight: ";
            foreach (var m in DataMeasuresRight)
            {
                str += String.Format("\n\t\t{0}", m.ToString());
            }

            //include the measures for asymmetry
            str += "\n\tAsymmetry: ";
            foreach (var m in DataMeasuresAsymmetry)
            {
                str += String.Format("\n\t\t{0}", m.ToString());
            }

            return String.Format("Cyclist Report {0}:\n{1}", ReportType, str);
        }
    }
}

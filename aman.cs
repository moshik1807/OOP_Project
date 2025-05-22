using System;
using System.Collections.Generic;
using System.Linq;

namespace IDF.model
{
    public class AMAN
    {
        public List<IntelligenceMessage> IntelligenceReports { get; set; } = new List<IntelligenceMessage>();

        public void AddReport(IntelligenceMessage report)
        {
            IntelligenceReports.Add(report);
        }

        public List<IntelligenceMessage> GetAllReports()
        {
            return IntelligenceReports;
        }

        //public Terrorist GetMostReportedTerrorist()
        //{

        //}

    }
}

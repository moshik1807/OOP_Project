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

        public Terrorist GetMostReportedTerrorist()
        {
            if (IntelligenceReports.Count == 0)
                return null;

            Dictionary<Terrorist, int> countMap = new Dictionary<Terrorist, int>();

            foreach (var report in IntelligenceReports)
            {
                if (countMap.ContainsKey(report.Target))
                    countMap[report.Target]++;
                else
                    countMap[report.Target] = 1;
            }

            Terrorist mostReported = null;
            int maxReports = 0;

            foreach (var pair in countMap)
            {
                if (pair.Value > maxReports)
                {
                    maxReports = pair.Value;
                    mostReported = pair.Key;
                }
            }

            return mostReported;
        }

    }
}

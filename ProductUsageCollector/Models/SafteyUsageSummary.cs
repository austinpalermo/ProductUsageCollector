using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductUsageCollector.Models
{
    public class SafetyUsageRecord
    {
        [JsonProperty("CompanyID")]
        public string CompanyID { get; set; }
        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Count_of_RecorderID")]
        public int CountofRecordID { get; set; }
        [JsonProperty("Incidents")]
        public int Incidents { get; set; }
        [JsonProperty("Inspections")]
        public int Inspections { get; set; }
        [JsonProperty("JHAs")]
        public int JHAs { get; set; }
        [JsonProperty("Meetings")]
        public int Meetings { get; set; }
        [JsonProperty("Near_Miss")]
        public int NearMiss { get; set; }
        [JsonProperty("Observations")]
        public int Observations { get; set; }
        [JsonProperty("Count_of_Jobs")]
        public int CountofJobs { get; set; }
    }

    public interface iSafetyUsageSummary
    {
        List<SafetyUsageRecord> SafetyUsageList { get; set; }
    }
    public class SafetyUsageSummary : iSafetyUsageSummary
    {
        public List<SafetyUsageRecord> SafetyUsageList { get; set; }
    }
}

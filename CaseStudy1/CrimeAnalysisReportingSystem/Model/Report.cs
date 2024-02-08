using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.Model
{
    internal class Report
    {
        private int reportId;
        private int incidentId;
        private int reportingOfficer;
        private DateTime reportDate;
        private string reportDetails;
        private string status;

        public List<Officers> OfficerList { get; set; }

        public int ReportId {  get { return reportId; } set {  reportId = value; } }
        public int IncidentId { get { return incidentId; } set { incidentId = value; } }
        public int ReportingOfficer { get {  return reportingOfficer; } set { reportingOfficer = value; } }
        public DateTime ReportDate { get {  return reportDate; } set { reportDate = value; } }

        public string ReportDetails { get { return reportDetails; } set { reportDetails = value; } }
        public string Status { get { return status; } set { status = value; } }
    }
}

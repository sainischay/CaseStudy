using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.Model
{
    public class Incident
    {
        private int incidentId;
        private string incidentType;
        private DateTime incidentdate;
        private string location;
        private string description;
        private string status;
        private int victimId;
        private int suspectId;

        public int IncidentId {  get { return incidentId; } set {  incidentId = value; } }
        public string IncidentType { get { return incidentType; } set { incidentType = value; } }
        public DateTime Incidentdate { get {  return incidentdate; } set { incidentdate = value; } }
        public string Location { get { return location; } set { location = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Status { get { return status; } set { status = value; } }
        public int VictimId { get { return victimId; } set {  victimId = value; } }
        public int SuspectId { get { return suspectId; } set {  suspectId = value; } }

    }
}

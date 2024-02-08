using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.Model
{
    internal class LawEnforcementAgencies
    {
        private int agencyId;
        private string agencyName;
        private string jurisdiction;
        private string contactInformation;

        public int AgencyId {  get { return agencyId; } set {  agencyId = value; } }
        public string AgencyName { get {  return agencyName; } set { agencyName = value; } }
        public string Jurisdiction { get {  return jurisdiction; } set {  jurisdiction = value; } }
        public string ContactInformation { get {  return contactInformation; } set {  contactInformation = value; } }

    }
}

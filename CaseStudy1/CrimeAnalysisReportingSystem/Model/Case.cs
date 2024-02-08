using CrimeAnalysisAndReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Model
{
    internal class Case
    {
        private int caseId;
        private string caseDescription;
        private Incident incident;

        public int CaseId {  get { return caseId; } set { caseId = value; } } 

        public string CaseDescription { get { return caseDescription; } set { caseDescription = value; } }

        public Incident Incident { get {  return incident; } set {  incident = value; } }
    }
}

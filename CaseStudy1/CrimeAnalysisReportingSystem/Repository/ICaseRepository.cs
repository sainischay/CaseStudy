using CrimeAnalysisReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Repository
{
    internal interface ICaseRepository
    {
        int CreateCase(string caseDescription,List<int> incidentIds);

        List<Case> GetCaseDetails(int caseId);

        int UpdateCaseDetails(int caseId,string description);

        List<Case> GetAllCases();
    }
}

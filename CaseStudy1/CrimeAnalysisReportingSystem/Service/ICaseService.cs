using CrimeAnalysisReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Service
{
    internal interface ICaseService
    {
        string CreateCase();

        List<Case> GetCaseDetails();

        string UpdateCaseDetails();

        List<Case> GetAllCases();
    }
}

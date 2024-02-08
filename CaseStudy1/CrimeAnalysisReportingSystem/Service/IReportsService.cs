using CrimeAnalysisAndReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Service
{
    internal interface IReportsService
    {
        List<Report> GenerateIncidentReport();
    }
}

using CrimeAnalysisAndReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Repository
{
    internal interface IReportsRepository
    {
        List<Report> GenerateIncidentReport(int incidentId);
    }
}

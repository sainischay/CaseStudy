using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisReportingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Service
{
    internal class ReportsService:IReportsService
    {
        IReportsRepository _reportsrepository;
        public ReportsService()
        {
            _reportsrepository = new ReportsRepository();
        }
        public List<Report> GenerateIncidentReport()
        {
            Console.WriteLine("Enter IncidentID");
            int incidentId = int.Parse(Console.ReadLine());
            return _reportsrepository.GenerateIncidentReport(incidentId);

        }
    }
}

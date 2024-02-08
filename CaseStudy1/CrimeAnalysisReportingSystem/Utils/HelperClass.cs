using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Utils
{
    internal static class HelperClass
    {
        public static void PrintIncidents(List<Incident> incidents)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-15} {4,-15} {5,-15} {6,-15} {7,-15}", "IncidentId", "IncidentType", "Incidentdate", "Location", "Status", "Description", "VictimId", "SuspectId");
            foreach (Incident incident in incidents)
            {
                DateTime date = incident.Incidentdate;
                string formattedDate = date.ToString("yyyy-MM-dd");
                Console.WriteLine($"{incident.IncidentId,-15} {incident.IncidentType,-15} {formattedDate,-15} {incident.Location,-15} {incident.Status,-15} {incident.Description,-15} {incident.VictimId,-15} {incident.SuspectId,-15}");
            }
        }


        public static void PrintReports(List<Report> reports)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-20} {3,-15} {4,-15} {5,-15} {6,-25} {7,-15}", "ReportId", "IncidentId", "ReportingOfficer", "FirstName", "LastName", "ReportDate", "ReportDetails", "Status");
            foreach (Report report in reports)
            {
                Console.Write($"{report.ReportId,-15} {report.IncidentId,-15} {report.ReportingOfficer,-20} ");
                if (report.OfficerList != null)
                {
                    foreach (Officers officer in report.OfficerList)
                    {
                        Console.Write($"{officer.FirstName,-15} {officer.LastName,-15} ");
                    }
                }
                DateTime date = report.ReportDate;
                string formattedDate = date.ToString("yyyy-MM-dd");
                Console.WriteLine($"{formattedDate,-15} {report.ReportDetails,-25} {report.Status,-15}");
            }
        }

        static public void PrintCases(List<Case> cases)
        {
            Console.WriteLine("{0,-15} {1,-25} {2,-15} {3,-15} {4,-25} {5,-15}", "CaseId", "CaseDescription", "IncidentType", "IncidentDate", "IncidentLocation", "IncidentStatus");

            foreach (Case cs in cases)
            {

                Console.Write($"{cs.CaseId,-15} {cs.CaseDescription,-25} ");
                if (cs.Incident != null)
                {
                    DateTime date = cs.Incident.Incidentdate;
                    string formattedDate = date.ToString("yyyy-MM-dd");
                    Console.WriteLine($"{cs.Incident.IncidentType,-15} {formattedDate,-15} {cs.Incident.Location,-25} {cs.Incident.Status,-15}");
                }
            }
        }
    }
}

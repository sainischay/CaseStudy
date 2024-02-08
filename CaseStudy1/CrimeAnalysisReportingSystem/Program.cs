using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisReportingSystem.Model;
using CrimeAnalysisReportingSystem.Service;
using CrimeAnalysisReportingSystem.Utils;
using System.Text.RegularExpressions;

namespace CrimeAnalysisReportingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IIncidentService incidentService = new IncidentService();
            IReportsService reportsService = new ReportsService();
            ICaseService caseService = new CaseService();
            List<Incident> incidents = new List<Incident>();
            List<Case> cases= new List<Case>();
            bool a = true;


            while (a)
            {
                Console.WriteLine("Enter 1 for Creating a new Incident\n" +
                    "Enter 2 for Updating the status of the Incident\n" +
                    "Enter 3 for getting the list of all Incidents within certain date range\n" +
                    "Enter 4 for Search for incidents based on various criteria\n" +
                    "Enter 5 for generating Incident Reports\n" +
                    "Enter 6 for creating a new case and associating it with Incidents\n" +
                    "Enter 7 for getting details os specific Case\n" +
                    "Enter 8 for updating CaseDescription of a specific Case\n" +
                    "Enter 9 for getting list of all cases\n" +
                    "Enter 0 to exit");

                int userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine(incidentService.CreateIncident());
                        break;
                    case 2:
                        Console.WriteLine(incidentService.UpdateIncidentStatus());
                        break;
                    case 3:
                        incidents = incidentService.GetIncidentsInDateRange();
                        HelperClass.PrintIncidents(incidents);
                        break;
                    case 4:
                        incidents = incidentService.SearchIncidents();
                        if (incidents.Count > 0)
                            HelperClass.PrintIncidents(incidents);
                        break;
                    case 5:
                        List<Report> reports = reportsService.GenerateIncidentReport();
                        if (reports.Count > 0)
                            HelperClass.PrintReports(reports);
                        break;
                    case 6:
                        Console.WriteLine(caseService.CreateCase());
                        break;
                    case 7:
                        cases = caseService.GetCaseDetails();
                        if (cases.Count > 0)
                            HelperClass.PrintCases(cases);
                        break;
                    case 8:
                        Console.WriteLine(caseService.UpdateCaseDetails());
                        break;
                    case 9:
                        cases = caseService.GetAllCases();
                        if (cases.Count > 0)

                            HelperClass.PrintCases(cases);
                        break;
                    case 0:
                        a = false;
                        break;
                    default:
                        Console.WriteLine("You have entered a wrong choice");
                        break;
                }
            }

        }
        }

    }


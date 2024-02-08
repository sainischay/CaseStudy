using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisAndReportingSystem.Repositories;
using CrimeAnalysisReportingSystem.Model;
using CrimeAnalysisReportingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Service
{
    internal class CaseService:ICaseService
    {
        ICaseRepository _caseRepository;
        IIncidentRepository _incidentRepository;
        public CaseService()
        {
            _caseRepository= new CaseRepository();
            _incidentRepository= new IncidentRepository();
        }

        public string CreateCase()
        {
            try
            {
                List<Incident> incidents = _incidentRepository.GetListOfIncidents();
                Console.WriteLine("Enter CaseDescription");
                string caseDescription = Console.ReadLine();
                Console.WriteLine("Enter the no of Incident Ids which you want to associate with the case");
                int noIds = int.Parse(Console.ReadLine());

                foreach (Incident incident in incidents)
                {
                    Console.WriteLine($"{incident.IncidentId} {incident.IncidentType} {incident.Incidentdate} {incident.Location} {incident.Status} {incident.Description} {incident.VictimId} {incident.SuspectId}");
                }

                Console.WriteLine("Choose from the above list of IncidentIds");
                List<int> incidentIds = new List<int>();
                for (int i = 0; i < noIds; i++)
                {
                    incidentIds.Add(int.Parse(Console.ReadLine()));
                }

                int creationStatus = _caseRepository.CreateCase(caseDescription, incidentIds);

                if (creationStatus != 0)
                    return "Case Created";
                else
                    return "Case creation Failed";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Case creation Failed";

            }
        }

        public List<Case> GetCaseDetails()
        {
            Console.WriteLine("Enter CaseId");
            int caseId=int.Parse(Console.ReadLine());   
            return _caseRepository.GetCaseDetails(caseId);
        }


        public string UpdateCaseDetails()
        {
            try
            {
                Console.WriteLine("Enter the CaseID");
                int caseId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter updated CaseDescription");
                string description = Console.ReadLine();
                int caseUpdationStatus = _caseRepository.UpdateCaseDetails(caseId, description);
                if (caseUpdationStatus != 0)
                    return "Case Updation Successful";
                return "Case Updation Not Successful";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Case Updation Not Successful";

            }
        }


        public List<Case> GetAllCases()
        {
            return _caseRepository.GetAllCases();
        }
    }
}

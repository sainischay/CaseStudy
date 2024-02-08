using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisAndReportingSystem.Repositories;
using CrimeAnalysisReportingSystem.Exceptions;


namespace CrimeAnalysisReportingSystem.Service
{
    internal class IncidentService:IIncidentService
    {
        IIncidentRepository _incidentrepository;

        public IncidentService()
        {
            _incidentrepository = new IncidentRepository();
        }

        public string CreateIncident()
        {
            try
            {
            Console.WriteLine("Enter IncidentType");
            string incidentType=Console.ReadLine();
            Console.WriteLine("Enter IncidentDate in yyyy/mm/dd");
            DateTime incidentDate=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Location");
            string location=Console.ReadLine();
            Console.WriteLine("Enter Description");
            string description=Console.ReadLine();
            Console.WriteLine("Enter Status");
            string status= Console.ReadLine();
            Console.WriteLine("Enter VictimId");
            int victimId=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter SuspectId");
            int suspectId = int.Parse(Console.ReadLine());
            Incident incident = new Incident() { IncidentType=incidentType,Incidentdate=incidentDate,Location=location,Description=description,Status=status,VictimId=victimId,SuspectId=suspectId};

                int incidentCreationStatus = _incidentrepository.CreateIncident(incident);
                if (incidentCreationStatus > 0)
                    return "Incident Creation Successful";
                else
                    return "Incident Creation Not Successful";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Incident Creation Not Successful";
            }
        }

        public string UpdateIncidentStatus()
        {
            try
            {
                Console.WriteLine("Enter status: Robbery, Theft, Homicide");
                string status=Console.ReadLine();
                Console.WriteLine("Enter IncidentId");
                int incidentId=int.Parse(Console.ReadLine());
          
                int updateStatus = _incidentrepository.UpdateIncidentStatus(status, incidentId);
                if (updateStatus > 0)
                    return "Incident Updated";
                else
                    return "Incident Not Updated";
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return "Incident Not Updated";
            }
        }


        public List<Incident> GetIncidentsInDateRange()
        {
            Console.WriteLine("Enter StartDate");
            DateTime startDate=DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter EndDate");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            return _incidentrepository.GetIncidentsInDateRange(startDate, endDate);

        }


        public List<Incident> SearchIncidents()
        {
            try
            {
                Console.WriteLine("Enter IncidentType");
                string incidentType = Console.ReadLine();
                return _incidentrepository.SearchIncidents(incidentType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Incident>();
            }
        }

 
    }
}

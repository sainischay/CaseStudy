using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrimeAnalysisAndReportingSystem.Model;

namespace CrimeAnalysisAndReportingSystem.Repositories
{
    public interface IIncidentRepository
    {
        int CreateIncident(Incident incident);

        int UpdateIncidentStatus(string Status, int incidentId);

        List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);

        List<Incident> SearchIncidents(string incidentType);


        List<Incident> GetListOfIncidents();

        Incident GetIncidentByIncidentId(int incidentId);
    }
}

using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisAndReportingSystem.Repositories;
using CrimeAnalysisReportingSystem.Repository;
using CrimeAnalysisReportingSystem.Exceptions;
using System.Globalization;

namespace CrimeAnalysisReportingSystem.Test
{
    public class Tests
    {
        IIncidentRepository _incidentRepository;
        [SetUp]
        public void Setup()
        {
            _incidentRepository = new IncidentRepository();
        }

        [Test]
        public void Test_To_Check_Incident_Creation()
        {
            Incident incident = new Incident();
            incident.IncidentType = "Theft";
            incident.Incidentdate = DateTime.Parse("2023/05/01");
            incident.Location = "Sample Location";
            incident.Description = "Sample Description";
            incident.Status = "Open";
            incident.VictimId = 1;
            incident.SuspectId = 1;

            int result = _incidentRepository.CreateIncident(incident);
            Assert.IsTrue(result>0);

            Incident retrievedIncident = _incidentRepository.GetIncidentByIncidentId(result);

            Assert.AreEqual(incident.IncidentType, retrievedIncident.IncidentType);
            Assert.AreEqual(incident.Incidentdate, retrievedIncident.Incidentdate);
            Assert.AreEqual(incident.Location, retrievedIncident.Location);
            Assert.AreEqual(incident.Description, retrievedIncident.Description);
            Assert.AreEqual(incident.Status, retrievedIncident.Status);
            Assert.AreEqual(incident.VictimId, retrievedIncident.VictimId);
            Assert.AreEqual(incident.SuspectId, retrievedIncident.SuspectId);

        }

        [Test]
        public void Test_To_Check_Update_Status()
        {
            string status = "Closed";
            int incidentId = 1;
            int updationStatus = _incidentRepository.UpdateIncidentStatus(status, incidentId);
            Assert.IsTrue (updationStatus > 0);

            Incident incident = _incidentRepository.GetIncidentByIncidentId(incidentId);
            Assert.AreEqual(status,incident.Status);
        }
    }
}
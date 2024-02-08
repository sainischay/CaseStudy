using CARS_CrimeAnalysisReportingSystem_.Utils;
using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisReportingSystem.Exceptions;
using CrimeAnalysisReportingSystem.Model;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace CrimeAnalysisAndReportingSystem.Repositories
{
    public class IncidentRepository:IIncidentRepository
    {
        List<string> incidentType= new List<string> { "Homicide", "Theft", "Robbery"};
        List<string> incidentStatus= new List<string> { "Open", "Closed", "Under Investigation"};
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public IncidentRepository()
        {   
            command = new SqlCommand();
        }

        public int CreateIncident(Incident incident)
        {
            int status = 0;
            if (!incidentType.Contains(incident.IncidentType))
                throw new IncidentTypeViolation("Wrong IncidentType Option Choose from Robbery,Theft,Homicide");
            if (!incidentStatus.Contains(incident.Status))
                throw new IncidentStatusViolation("Wrong Status Option Choose from Open,Closed,Under Investigation");
           
            try
            {
                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    connection.Open();
                    command.Connection = connection;
                    command.Parameters.Clear();
                    command.CommandText = "insert into Incidents values(@IncidentType,@IncidentDate,@Location,@Description,@Status,@VictimId,@SuspectId); select scope_identity()";
                    command.Parameters.AddWithValue("@IncidentType", incident.IncidentType);
                    command.Parameters.AddWithValue("@IncidentDate", incident.Incidentdate);
                    command.Parameters.AddWithValue("@Location", incident.Location);
                    command.Parameters.AddWithValue("@Description", incident.Description);
                    command.Parameters.AddWithValue("@Status", incident.Status);
                    command.Parameters.AddWithValue("@VictimId", incident.VictimId);
                    command.Parameters.AddWithValue("@SuspectId", incident.SuspectId);

                    status= Convert.ToInt32(command.ExecuteScalar());
                    return status;
                }
            }
            catch  (SqlException ex)
            {
                throw new VictimNumberNotFound("Error: You have entered wrong VictimId or SuspectId which does not exist in the Database");
            }
        }

        public int UpdateIncidentStatus(String status,int incidentId) {
            if (!incidentStatus.Contains(status))
                throw new IncidentStatusViolation("Wrong Status Option Choose from Open,Closed,Under Investigation");
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection= connection;
                command.Parameters.Clear();
                command.CommandText = "update Incidents set Status=@status where IncidentId=@incidentId";
                command.Parameters.AddWithValue("@incidentId", incidentId);
                command.Parameters.AddWithValue("@status", status);
                
                return command.ExecuteNonQuery();

            }
        }

        public List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incident> incidents = new List<Incident>();
            using(SqlConnection connection = new SqlConnection(databaseConnectionString)) {
                connection.Open();
                command.Connection= connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Incidents where IncidentDate between @startDate and @endDate";
                command.Parameters.AddWithValue("@startDate",startDate);
                command.Parameters.AddWithValue("@endDate",endDate);
                
                SqlDataReader reader= command.ExecuteReader();
                while (reader.Read())
                {
                    Incident incident = new Incident {
                        IncidentId = (int)reader["IncidentID"],
                        IncidentType = (string)reader["IncidentType"],
                        Incidentdate = (DateTime)reader["IncidentDate"],
                        Status = (string)reader["Status"],
                        Description = (string)reader["Description"],
                        Location = (string)reader["Location"],
                        VictimId = (int)reader["VictimID"],
                        SuspectId = (int)reader["SuspectID"],
                    };
                    incidents.Add(incident);

                }
                return incidents;
            }
        }


        public List<Incident> SearchIncidents(string incidentType)
        {
            if (!incidentStatus.Contains(incidentType))
                throw new IncidentTypeViolation("Wrong IncidentType Option Choose from Robbery,Theft,Homicide");
            List<Incident> incidents = new List<Incident>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection= connection;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@incidentType", incidentType);
                command.CommandText = "select * from Incidents where IncidentType=@incidentType";
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Incident incident = new Incident
                    {
                        IncidentId = (int)reader["IncidentID"],
                        IncidentType = (string)reader["IncidentType"],
                        Incidentdate = (DateTime)reader["IncidentDate"],
                        Status = (string)reader["Status"],
                        Description = (string)reader["Description"],
                        Location = (string)reader["Location"],
                        VictimId = (int)reader["VictimID"],
                        SuspectId = (int)reader["SuspectID"],
                    };
                    incidents.Add(incident);

                }
                return incidents;
            }
        }


        public List<Incident> GetListOfIncidents()
        {
            List<Incident> incidents = new List<Incident> ();
            using(SqlConnection connection = new SqlConnection(databaseConnectionString)) {
                connection.Open();
                command.Connection= connection;
                command.CommandText = "select * from Incidents";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Incident incident = new Incident
                    {
                        IncidentId = (int)reader["IncidentID"],
                        IncidentType = (string)reader["IncidentType"],
                        Incidentdate = (DateTime)reader["IncidentDate"],
                        Status = (string)reader["Status"],
                        Description = (string)reader["Description"],
                        Location = (string)reader["Location"],
                        VictimId = (int)reader["VictimID"],
                        SuspectId = (int)reader["SuspectID"],
                    };
                    incidents.Add(incident);
                }
                return incidents;
            }
        }

        public Incident GetIncidentByIncidentId(int incidentId)
        {
            Incident incident = new Incident();
            using(SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection= connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Incidents where IncidentID=@incidentId";
                command.Parameters.AddWithValue("@incidentId", incidentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    incident.IncidentId = (int)reader["IncidentID"];
                    incident.IncidentType = (string)reader["IncidentType"];
                    incident.Incidentdate = (DateTime)reader["IncidentDate"];
                    incident.Status = (string)reader["Status"];
                    incident.Description = (string)reader["Description"];
                    incident.Location = (string)reader["Location"];
                    incident.VictimId = (int)reader["VictimID"];
                    incident.SuspectId = (int)reader["SuspectID"];
                }
                return incident;
            }
        }

    }
}

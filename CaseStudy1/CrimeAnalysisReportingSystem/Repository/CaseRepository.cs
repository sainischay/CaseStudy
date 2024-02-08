using CARS_CrimeAnalysisReportingSystem_.Utils;
using CrimeAnalysisAndReportingSystem.Model;
using CrimeAnalysisReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Repository
{
    internal class CaseRepository:ICaseRepository
    {
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public CaseRepository()
        {
            command = new SqlCommand();
        }
        public int CreateCase(string caseDescription, List<int> incidentIds)
        {
            int caseId = 0;
            using(SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Parameters.Clear();
                command.Transaction = transaction;

                try
                {

                    command.CommandText = "insert into [Case] values(@caseDescription); select scope_identity()";
                    command.Parameters.AddWithValue("@caseDescription", caseDescription);

                    caseId = Convert.ToInt32(command.ExecuteScalar());

                    foreach (int incidentId in incidentIds)
                    {
                        command.CommandText = "insert into CaseIncidents values(@caseId,@incidentId)";
                        command.Parameters.AddWithValue("@caseId", caseId);
                        command.Parameters.AddWithValue("@incidentId", incidentId);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return 0;
                }
            }

            return caseId;
        }


        public List<Case> GetCaseDetails(int caseId)
        {
            List<Case> cases = new List<Case>();
            using(SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                StringBuilder st = new StringBuilder();
                connection.Open ();
                command.Connection = connection;
                command.Parameters.Clear();
                st.Append("select * from [Case] C join CaseIncidents CI on CI.CaseID=C.CaseID");
                st.Append("join Incidents I on I.IncidentID = CI.IncidentID where C.CaseID = @caseId");
                //command.CommandText = "select * from [Case] C join CaseIncidents CI on CI.CaseID=C.CaseID join Incidents I on I.IncidentID=CI.IncidentID where C.CaseID=@caseId";
                command.CommandText = st.ToString();
                command.Parameters.AddWithValue("@caseId", caseId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Case cs = new Case();
                    cs.CaseId = (int)reader["CaseID"];
                    cs.CaseDescription = (string)reader["Description"];
                    Incident incident = new Incident();
                    incident.IncidentId = (int)reader["IncidentID"];
                    incident.IncidentType = (string)reader["IncidentType"];
                    incident.Location = (string)reader["Location"];
                    incident.Status = (string)reader["Status"];

                    cs.Incident = incident;
                    cases.Add(cs);
                }
                command.Parameters.Clear();
                return cases;
            }
        }


        public int UpdateCaseDetails(int caseId,string description)
        {
            using(SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open ();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "update [Case] set Description=@description where CaseID=@caseId";
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@caseId", caseId);
                int caseUpdationStatus = command.ExecuteNonQuery();

                return caseUpdationStatus;
            }
        }


        public List<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from [Case] C join CaseIncidents CI on CI.CaseID=C.CaseID join Incidents I on I.IncidentID=CI.IncidentID";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Case cs = new Case();
                    cs.CaseId = (int)reader["CaseID"];
                    cs.CaseDescription = (string)reader["Description"];
                    Incident incident = new Incident();
                    incident.IncidentId = (int)reader["IncidentID"];
                    incident.IncidentType = (string)reader["IncidentType"];
                    incident.Location = (string)reader["Location"];
                    incident.Status = (string)reader["Status"];
                    incident.Incidentdate = (DateTime)reader["IncidentDate"];
                    cs.Incident = incident;
                    cases.Add(cs);
                }
                return cases;
            }
        }
    }
}

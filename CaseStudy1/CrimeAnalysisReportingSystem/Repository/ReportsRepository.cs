using CARS_CrimeAnalysisReportingSystem_.Utils;
using CrimeAnalysisAndReportingSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisReportingSystem.Repository
{
    internal class ReportsRepository:IReportsRepository
    {
        string databaseConnectionString = DbConnUtil.GetConnectionString();
        SqlCommand command;

        public ReportsRepository()
        {
            command = new SqlCommand();
        }
        public List<Report> GenerateIncidentReport(int incidentId)
        {
            List<Report> reports = new List<Report>();
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                connection.Open();
                command.Connection = connection;
                command.Parameters.Clear();
                command.CommandText = "select * from Reports join Officers on Officers.OfficerID=Reports.ReportingOfficer where IncidentID = @incidentId";
                command.Parameters.AddWithValue("@incidentId", incidentId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Report report = new Report();
                    report.ReportId = (int)reader["ReportID"];
                    report.IncidentId = (int)reader["IncidentID"];
                    report.ReportingOfficer = (int)reader["ReportingOfficer"];
                    report.ReportDate = (DateTime)reader["ReportDate"];
                    report.ReportDetails = (string)reader["ReportDetails"];
                    report.Status = (string)reader["Status"];

                    Officers officer = new Officers();

                    officer.FirstName = (string)reader["FirstName"];
                    officer.LastName = (string)reader["LastName"];

                    report.OfficerList ??= new List<Officers>();

                    //this below code is same as the above line
                    //if(report.OfficerList is null)
                    //    {
                    //    report.OfficerList = new List<Officers>();
                    //    }

                    report.OfficerList.Add(officer);
                    reports.Add(report);
                }
                return reports;
            }
        }
    }
}

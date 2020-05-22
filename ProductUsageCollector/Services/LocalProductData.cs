using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Autofac;
using ProductUsageCollector.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;

namespace ProductUsageCollector.Services
{
    public interface iLocalProductData
    {

    }

    public class LocalProductData : iLocalProductData
    {
        private iSafetyUsageSummary _safetyUsageSummary;

        public LocalProductData(iSafetyUsageSummary safetyUsageSummary)
        {
            _safetyUsageSummary = safetyUsageSummary;
        }

        private string GetConnectionString()
        {
            string conn = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_SQLConnectionString");

            if (conn != null)
            {
                return conn;
            }
            else
            {
                conn = Environment.GetEnvironmentVariable("SQLConnectionString");
            }

            return conn;
        }

        public async Task<SafetyUsageSummary> GetSafetyUsageDataLastWeek()
        {
            var safetyUsageData = new SafetyUsageSummary();

            string connectionString = GetConnectionString();
            string query = "Select * FROM SafetyUsageData WHERE [Date] " +
                "BETWEEN DATEADD(wk, -1, DATEADD(DAY, 1-DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE()))) " +
                "and DATEADD(wk, 0, DATEADD(DAY, 0 - DATEPART(WEEKDAY, GETDATE()), DATEDIFF(dd, 0, GETDATE()))) ";

            return await Task.Run(() =>
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    safetyUsageData.SafetyUsageList = connection.Query<SafetyUsageRecord>(query).ToList();
                }
                return safetyUsageData;
            });            
        }
    }
}

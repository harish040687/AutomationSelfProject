using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelfProject.Utilities
{
    class SqlDataAccess:IDatabaseLibrary
    {
        
          public string SqlDatabaseFormatString  = string.Format(@"Data Source={0}\instance1;database={1};Integrated Security=SSPI;connection timeout=120", "dbservername","databasename");

        private SqlConnection _conn;
        private string _connectionString;
        public string DatabaseName { get; set; }
        public string DbEnvironment { get; set; }
        

        public SqlDataAccess(string dbName)
        {
            DbEnvironment = TestContext.Parameters["ProjectEnvironment"];
            DatabaseName = dbName;

        }

        public void Connect()
        {
            _connectionString = string.Format(SqlDatabaseFormatString, DbEnvironment);
            _conn = new SqlConnection(_connectionString);
            _conn.Open();
        }

        public bool ExecuteNonQuery(string sql, string database)
        {
            if (!string.IsNullOrEmpty(database)) _conn.ChangeDatabase(database);
            try
            {
                var cmd = new SqlCommand(sql, _conn);
                cmd.ExecuteNonQuery();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable RetrieveData(string sql, string database)
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            throw new NotImplementedException();
        }
    }
}

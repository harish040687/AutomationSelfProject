using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AutomationSelfProject.Utilities
{

    public interface IDatabaseLibrary
    {
        void Connect();
        bool ExecuteNonQuery(string sql, string database);
        DataTable RetrieveData(string sql, string database);
        void CloseConnection();

    }
}

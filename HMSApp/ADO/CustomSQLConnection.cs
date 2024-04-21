using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSApp.ADO
{
    internal class CustomSQLConnection
    {
        const string connectionString =
          "Data Source=MOON00\\NEW;Initial Catalog=HMSDB;"
          + "Integrated Security=true";
        public static SqlConnection Connect()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}

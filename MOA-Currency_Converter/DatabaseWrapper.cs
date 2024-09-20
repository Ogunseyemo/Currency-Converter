using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOA_Currency_Converter
{
    internal class DatabaseWrapper
    {
        private readonly string _connectionString;

        public DatabaseWrapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                connection.Open();
                da.Fill(dt);
                connection.Close();

                return dt;
            }
        }
    }
}

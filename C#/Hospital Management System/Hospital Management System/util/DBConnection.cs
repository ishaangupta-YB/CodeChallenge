using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Hospital_Management_System.util
{
    public static class DBConnection
    {
        private static readonly string connectionString;

        // constructor to initialize the connection string
        static DBConnection()
        {
            connectionString = PropertyUtil.GetConnectionString();
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'HMSDB' is not configured correctly.");
            }
        }


        // Method to establish and return a new SQL connection
        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();

                if (con == null || con.State != System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("Failed to establish db connection.");
                }

                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}

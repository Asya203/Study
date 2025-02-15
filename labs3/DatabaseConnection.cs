using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace labs3
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private readonly string _connectionString;

        private DatabaseConnection()
        {

            _connectionString = "name of connectoin";
        }

        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }
                return _instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

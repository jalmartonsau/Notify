using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Service
{
    public class Database
    {
        // Connection to the database.
        private static string Username = "tonsau";
        private static string Password = "uhbvfewshg";
        private static string Host = "tonsau.eu";
        private static string Db = "data";
        private static int Port = 3306;
        private static string ConnectionString {
            get{ return string.Format("Server={0};Port={1};Database={2};Uid={3};password={4}", Host, Port, Db, Username, Password); }
        }

        private MySqlConnection Connection {
            get {
                return new MySqlConnection(ConnectionString);
            }
        }

        public void test() {
            try
            {
                Connection.Open();
            }
            catch (Exception ex) {
                Debug.WriteLine(ex);
            }
        }


    }
}

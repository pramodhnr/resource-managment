using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;



namespace databaseproject
{
    public static class utilities
    {
        public static string connectionString;
        public static MySqlConnection connection;
        public static void openConnection()
        {
            try
            {
                string connectionString = "datasource=localhost;port=3305;username=root;password=root";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

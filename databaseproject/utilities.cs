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
                connectionString = "datasource=localhost;port=3306;username=root;password=root";
                connection = new MySqlConnection(connectionString);
                //MySqlCommand selectcommand = new MySqlCommand("select * from database.login where username='" + textBox_username.Text + "' and password='" + passwordBox_password.Password + "')", myconn);
                //MySqlDataReader myreader;
                connection.Open();
                //myreader = selectcommand.ExecuteReader();
                //int count = 0;
                //while (myreader.Read())
                //{
                //    count += 1;
                //}
                //if (count == 1)
                //{
                //    MessageBox.Show("correct");
                //}
                //else
                //{
                //    MessageBox.Show("incorrect");
                //}
               
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace databaseproject
{
    public  class utilities
    {
        public  string connectionString;
        public  MySqlConnection connection;
        public  MySqlConnection openConnection()
        {
            try
            {
                string connectionString = "datasource=db4free.net;port=3306;username=shilppramodh;password=asdfzxcv";
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public  void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

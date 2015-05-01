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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace databaseproject
{
    /// <summary>
    /// Interaction logic for profile.xaml
    /// </summary>
    public partial class profile : Window
    {
        public profile()
        {
            InitializeComponent();
        }
        public profile(string username)
        {
            InitializeComponent();
            ComboBox profile_resources = comboBox_profile_resources;
            utilities.openConnection();
            MySqlCommand fetch_manager = new MySqlCommand("select is_manager from schema1.login where name='" + username + "';", utilities.connection);
            MySqlDataReader reader;
            reader = fetch_manager.ExecuteReader();
            if (reader[0].ToString()=="1")
            {
                profile_resources.Visibility =System.Windows.Visibility.Visible;

            }
        }
    }
}

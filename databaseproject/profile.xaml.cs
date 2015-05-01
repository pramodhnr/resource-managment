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
            MySqlCommand fetch_manager = new MySqlCommand("select is_manager,id from schema1.login where name='" + username + "';", utilities.connection);
            MySqlDataReader reader;
            try
            {
                reader = fetch_manager.ExecuteReader();
                if (reader[0].ToString() == "1")
                {
                    string manager_id = reader[1].ToString();
                    profile_resources.Visibility = System.Windows.Visibility.Visible;
                    reader.Close();
                    MySqlCommand fetch_resource = new MySqlCommand("select name from schema1.login where manager_id='" + manager_id + "';", utilities.connection);
                    MySqlDataReader reader2;
                    reader2 = fetch_resource.ExecuteReader();
                    while (reader2.Read())
                    {
                        profile_resources.Items.Add(reader2[0].ToString());
                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
                Console.WriteLine(e1.StackTrace);
            }
        }

        private void comboBox_profile_resources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void profile_name_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            TextBox profile_name_value = profile_name;
            profile_name_value.IsReadOnly = false;
            
        }

        private void profile_email_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            TextBox profile_email_value = profile_email;
            profile_email_value.IsReadOnly = false;
            
        }

        private void profile_work_hours_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            TextBox profile_work_hours_value = profile_work_hours;
            profile_work_hours_value.IsReadOnly = false;

        }
        
    }
}

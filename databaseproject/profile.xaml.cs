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
        TextBox profile_name_value;
        TextBox profile_email_value;
        TextBox profile_work_hours_value;

        private string session_username;
        public profile()
        {
            InitializeComponent();
        }
        public profile(string username)
        {
            InitializeComponent();

            profile_name_value = profile_name;
            profile_email_value = profile_email;
            profile_work_hours_value = profile_work_hours;

            session_username = username;
            ComboBox profile_resources = comboBox_profile_resources;
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();
            
            MySqlCommand fetch_manager = new MySqlCommand("select is_manager,id from schema1.login where name='" + username + "';", conn);
            MySqlDataReader reader;
            try
            {
                reader = fetch_manager.ExecuteReader();
                reader.Read();
                if (reader[0].ToString() == "1")
                {
                    string manager_id = reader[1].ToString();
                    profile_resources.Visibility = System.Windows.Visibility.Visible;
                    reader.Close();
                    MySqlCommand fetch_resource = new MySqlCommand("select name from schema1.login where manager_id='" + manager_id + "';", conn);
                    MySqlDataReader reader2;
                    reader2 = fetch_resource.ExecuteReader();
                    while (reader2.Read())
                    {
                        profile_resources.Items.Add(reader2[0].ToString());
                    }
                    reader2.Close();

                }
            }
            catch (Exception e1)
            {
               // MessageBox.Show(e1.Message + "e1");
                MessageBox.Show(e1.StackTrace);
                Console.WriteLine(e1.StackTrace);
            }
        }

        private void comboBox_profile_resources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();
            MySqlCommand select_resource = new MySqlCommand("select * from schema1.login where name ='" + comboBox_profile_resources.SelectedItem.ToString() + "';", conn);
            MySqlDataReader reader ; 
            reader = select_resource.ExecuteReader();
            reader.Read();
            profile_name_value.Text = reader[1].ToString();
            profile_email_value.Text = reader[2].ToString();
            reader.Close();

        }

        private void profile_name_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
            profile_name_value.IsReadOnly = false;
            this.Visibility = System.Windows.Visibility.Hidden;


        }

        private void profile_email_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
            profile_email_value.IsReadOnly = false;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void profile_work_hours_edit_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            
            profile_work_hours_value.IsReadOnly = false;
            this.Visibility = System.Windows.Visibility.Hidden;
        }

        private void profile_change_password_Click(object sender, RoutedEventArgs e)
        {
            changePassword changepassword = new changePassword(session_username);
            changepassword.Show();
            
            
        }
        
    }
}

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

            manager_textbox.TextChanged += new TextChangedEventHandler(manager_textchange);

            session_username = username;
            ComboBox profile_resources = comboBox_profile_resources;
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();

            MySqlCommand fetch_manager = new MySqlCommand("select is_manager,id from resourcemanage.login where name='" + username + "';", conn);
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
                    MySqlCommand fetch_resource = new MySqlCommand("select name from resourcemanage.login where manager_id='" + manager_id + "';", conn);
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
                MessageBox.Show(e1.Message);
                Console.WriteLine(e1.StackTrace);
            }
        }

        private void comboBox_profile_resources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();
            MySqlCommand select_resource = new MySqlCommand("select * from resourcemanage.login where name ='" + comboBox_profile_resources.SelectedItem.ToString() + "';", conn);
            MySqlDataReader reader ; 
            reader = select_resource.ExecuteReader();
            reader.Read();
            profile_name_value.Text = reader[1].ToString();
            profile_email_value.Text = reader[3].ToString();
            reader.Close();
            conn.Close();

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
            UserControl changepassword = new changePassword(session_username);
            
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            profile_name.IsReadOnly = true;
            this.Visibility = System.Windows.Visibility.Hidden;
            button5.Visibility = System.Windows.Visibility.Hidden;
            button1.Visibility = System.Windows.Visibility.Visible;
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            MySqlDataReader reader;
            MySqlCommand comm = new MySqlCommand("update  ",conn);
            reader = comm.ExecuteReader();
            reader.Read();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.Visibility = System.Windows.Visibility.Hidden;
            button4.Visibility = System.Windows.Visibility.Visible;
            button5.Visibility = System.Windows.Visibility.Visible;
            profile_name.IsReadOnly = false;

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2.Visibility = System.Windows.Visibility.Hidden;
            button6.Visibility = System.Windows.Visibility.Visible;
            button7.Visibility = System.Windows.Visibility.Visible;
            profile_email.IsReadOnly = false;

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {

        }
        private void manager_textchange(object sender, TextChangedEventArgs e)
        {
            
            string text = manager_textbox.Text;
            List<string> autolist = new List<String>();
            autolist.Clear();

            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();
            MySqlDataReader reader;
            MySqlCommand comm = new MySqlCommand("select name from resourcemanage.login where name like '%" + text + "%';", conn);
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() != null)
                    autolist.Add(reader[0].ToString());

            }
            if (autolist.Count > 0)
            {
                autocomplete_manager.ItemsSource = autolist;
                autocomplete_manager.Visibility = Visibility.Visible;
            }
            else
            {
                autocomplete_manager.ItemsSource = null;
                autocomplete_manager.Visibility = Visibility.Hidden;
            }
        

        }
        private void autocomplete_manager_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (autocomplete_manager.ItemsSource != null)
            {
                autocomplete_manager.Visibility = Visibility.Collapsed;
                manager_textbox.TextChanged -= new TextChangedEventHandler(manager_textchange);
                if (autocomplete_manager.SelectedIndex != -1)
                {
                    manager_textbox.Text = autocomplete_manager.SelectedItem.ToString();
                }
                manager_textbox.TextChanged +=new TextChangedEventHandler(manager_textchange);
            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}

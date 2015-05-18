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
        string current_name;
        string current_email;
        string current_manager;

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
                    conn.Close();

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message + "e1");
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
            MySqlDataReader reader1;
            reader = select_resource.ExecuteReader();
            reader.Read();
            MySqlCommand select_manager = new MySqlCommand("select name from resourcemanage.login where id='" + reader[0].ToString() + "'", conn);

            profile_name_value.Text =current_name= reader[1].ToString();
            profile_email_value.Text =current_email= reader[2].ToString();
            reader.Close();
            reader1 = select_manager.ExecuteReader();
            reader1.Read();
            manager_textbox.Text =current_manager= reader1[0].ToString();
            reader1.Close();
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
            button4.Visibility = System.Windows.Visibility.Hidden;
            button5.Visibility = System.Windows.Visibility.Hidden;
            button1.Visibility = System.Windows.Visibility.Visible;

            try
            {
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand comm = new MySqlCommand("update resourcemanage.login set name = '" + profile_name.Text + "' where name = '"+ comboBox_profile_resources.SelectedItem.ToString() + "' ", conn);
                reader = comm.ExecuteReader();
                reader.Read();
                reader.Close();
                conn.Close();
                current_name = profile_name.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ex");
            }
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
            button3.Visibility = Visibility.Hidden;
            button8.Visibility = Visibility.Visible;
            button9.Visibility = Visibility.Visible;
            profile_work_hours.IsReadOnly = false;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            profile_email.IsReadOnly = true;
            button6.Visibility = Visibility.Hidden;
            button7.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Visible;
            try
            {
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand comm = new MySqlCommand("update resourcemanage.login set email = '" + profile_email.Text + "' where name = '" + comboBox_profile_resources.SelectedItem.ToString() + "' ", conn);
                reader = comm.ExecuteReader();
                reader.Read();
                reader.Close();
                conn.Close();
                current_email = profile_email.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            profile_name.IsReadOnly = true;
            profile_name.Text = current_name;

        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            profile_email.IsReadOnly = true;
            profile_email.Text = current_email;
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
            if (manager_textbox.IsReadOnly == false)
            {
                try
                {
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
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }
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
            manager_textbox.IsReadOnly = false;
            button10.Visibility = Visibility.Hidden;
            button11.Visibility = Visibility.Visible;
            button12.Visibility = Visibility.Visible;
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            button11.Visibility = Visibility.Hidden;
            button12.Visibility = Visibility.Hidden;
            button10.Visibility = Visibility.Visible;
            manager_textbox.IsReadOnly = true;
            try
            {
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand fetch_managerid = new MySqlCommand(" select manager_id from resourcemanage.login where name='" + manager_textbox.Text + "';", conn);
                reader = fetch_managerid.ExecuteReader();
                reader.Read();
                string managerid = reader[0].ToString();
                reader.Close();
                
                MySqlCommand comm = new MySqlCommand("update resourcemanage.login set manager_id = '" + managerid + "' where name = '" + comboBox_profile_resources.SelectedItem.ToString() + "' ", conn);
                reader = comm.ExecuteReader();
                reader.Read();
                reader.Close();
                conn.Close();
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message + "ex1");
            }

        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            manager_textbox.IsReadOnly = true;
            manager_textbox.Text = current_manager;
            autocomplete_manager.Visibility = Visibility.Collapsed;
        }

        
        
    }
}

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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            try
            {
                ComboBox signup_manager = comboBox_signup_manager;
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlCommand comm = new MySqlCommand("select name from resourcemanage.login where is_manager=1 order by name asc;", conn);
                //comm.Connection = utilities.connection;
                MySqlDataReader reader;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    signup_manager.Items.Add(reader[0].ToString());
                }
                reader.Close();
                conn.Close();
                // utilities.closeConnection();
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message + "ex4");
                Console.WriteLine(ex4.StackTrace);
            }
            finally
            {
               // utilities.closeConnection();
            }
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {

                string login_username = textBox_username.Text;
                string login_password = passwordBox_password.Password;
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                //utilities.openConnection();
                MySqlCommand command = new MySqlCommand("select * from resourcemanage.login where name='" + login_username + "' and user_password=sha1('" + login_password + "');", conn);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count += 1;
                }
                if (count == 1)
                {
                    //MessageBox.Show("correct");
                    Window user_profile = new profile(myreader[1].ToString());
                    this.Hide();
                    user_profile.Show();
                }
                else
                {
                    MessageBox.Show("incorrect");
                }
                //utilities.closeConnection();
                conn.Close();
         }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ex");
                Console.WriteLine(ex.StackTrace);
            }
        }

       

        private void button_signup_register_Click(object sender, RoutedEventArgs e)
        {


            string signup_username = textBox_signup_username.Text;
            string signup_password = textBox_signup_password.Password;
            string signup_email = textBox_signup_email.Text;

            string signup_manager ;
           /* if (comboBox_signup_manager.SelectedItem.ToString() = "null")
                signup_manager = null;
            else */
            signup_manager= comboBox_signup_manager.SelectedItem.ToString();


            try
            {
                //utilities.openConnection();
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlDataReader reader1, reader2;
                // MessageBox.Show(manager_selected);
                MySqlCommand fetch_manager_id = new MySqlCommand("select * from resourcemanage.login where name='" + signup_manager + "'", conn);
                
                reader1 = fetch_manager_id.ExecuteReader();

                while (reader1.Read())
                {
                    // MessageBox.Show(reader1.GetValue(0).ToString());
                }

                string managerid = reader1.GetValue(0).ToString();
                reader1.Close();
                MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.login(name,user_password,email,manager_id,is_manager) values ('" + signup_username + "',sha1('" + signup_password + "'),'" + signup_email + "','" + managerid + "',0);", conn);

                reader2 = insertnew.ExecuteReader();
                reader2.Read();
                MessageBox.Show("Successfully inserted");
                reader2.Close();
                //utilities.closeConnection();
                conn.Close();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + "ex2");
                Console.WriteLine(ex2.StackTrace);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            employee_details _emp = new employee_details();
            _emp.ShowDialog();
        }
    }
}

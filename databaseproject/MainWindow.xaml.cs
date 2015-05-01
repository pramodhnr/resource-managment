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
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            
            
            try
            {
                string login_username = textBox_username.Text.ToString();
                string login_password = passwordBox_password.Password.ToString();
                utilities.openConnection();
                MySqlCommand command = new MySqlCommand("select * from schema1.login where name='" + login_username + "' and user_password=sha1('" + login_password + "');", utilities.connection);
                MySqlDataReader myreader;
                myreader = command.ExecuteReader();
                int count = 0;
                while (myreader.Read())
                {
                    count += 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("correct");
                }
                else
                {
                    MessageBox.Show("incorrect");
                }
                utilities.closeConnection();

         }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void button_signup_register_Click(object sender, RoutedEventArgs e)
        {

            string signup_username = textBox_signup_username.Text.ToString();
            string signup_password = passwordBox1.Password;
            string signup_email = textBox_signup_email.Text.ToString();
            string signup_manager = comboBox_signup_manager.SelectedItem.ToString();


            try
            {
                utilities.openConnection();
                MySqlDataReader reader1, reader2;
                // MessageBox.Show(manager_selected);
                MySqlCommand fetch_manager_id = new MySqlCommand("select * from schema1.login where name='" + signup_manager + "'", utilities.connection);
                
                reader1 = fetch_manager_id.ExecuteReader();

                while (reader1.Read())
                {
                    // MessageBox.Show(reader1.GetValue(0).ToString());
                }

                string managerid = reader1.GetValue(0).ToString();
                reader1.Close();
                MySqlCommand insertnew = new MySqlCommand("insert into schema1.login(name,user_password,email,manager_id,is_manager) values ('" + signup_username + "',sha1('" + signup_password + "'),'" + signup_email + "','" + managerid + "',0);", utilities.connection);

                reader2 = insertnew.ExecuteReader();
                reader2.Read();
                MessageBox.Show("Successfully inserted");
                reader2.Close();
                utilities.closeConnection();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
    }
}

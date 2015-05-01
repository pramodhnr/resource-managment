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
                utilities.openConnection();
                MySqlCommand selectcommand = new MySqlCommand("select * from database.login where username='" + textBox_username.Text + "' and password='" + passwordBox_password.Password + "' ;", utilities.connection);
                MySqlDataReader myreader;
                myreader = selectcommand.ExecuteReader();
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

        private void button_signup_Click(object sender, RoutedEventArgs e)
        {
            signup_form _signupform = new signup_form();
            _signupform.ShowDialog();
        }
    }
}

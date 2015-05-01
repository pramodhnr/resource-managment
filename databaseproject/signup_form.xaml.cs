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
    /// Interaction logic for signup_form.xaml
    /// </summkkary>
    public partial class signup_form : Window
    {
        public signup_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                utilities.openConnection();
                MySqlCommand insertCommand = new MySqlCommand("INSERT INTO `database`.`login` (`username`, `password`, `First name`, `Last name`, `Employee id`) VALUES ('" + textBox_username.Text + "', '" + passwordBox_password.Password + "', '" + textBox_firstname.Text + "', '" + textBox_lastname.Text + "', '" + textBox_employeeid.Text + "');", utilities.connection);
                insertCommand.ExecuteNonQuery();
                utilities.closeConnection();
                MessageBox.Show("created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

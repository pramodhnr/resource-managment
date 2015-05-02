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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    
    
    public partial class changePassword : UserControl
    {
        private string username;
        public changePassword()
        {
            InitializeComponent();
           
           
        }
        public changePassword(string session_username)
        {
            username = session_username;
            
        }

        private void reset_password_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox change_password_box = change_password;
            PasswordBox confirm_password_box = confirm_change_password;
            if (change_password_box.Password.Equals(confirm_change_password.Password))
            {
                try
                {

                    MySqlCommand changepassword = new MySqlCommand("update schema1.login set user_password=sha1('" + change_password_box.Password + "') where name='" + username + "'; ", utilities.connection);
                    MySqlDataReader reader;
                    reader = changepassword.ExecuteReader();
                    reader.Read();
                    MessageBox.Show("Password Changed successfully");
                    reader.Close();
                    
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                    Console.WriteLine(e1.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }
    }
}

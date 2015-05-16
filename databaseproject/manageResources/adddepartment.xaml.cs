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
    /// Interaction logic for adddepartment.xaml
    /// </summary>
    public partial class adddepartment : Window
    {
        #region variables
        string _deptName;
        MySqlDataReader reader;
        #endregion variables
        public adddepartment()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               l1: if (textBox_deptName.Text != "\0")
                {
                    _deptName = textBox_deptName.Text;
                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.department(dept_name) values ('" + _deptName + "');", conn);
                    reader = insertnew.ExecuteReader();
                    utilities._emp.comboBox_department.Items.Add(_deptName);
                    utilities._emp.comboBox_department.SelectedItem = _deptName;
                    MessageBox.Show("Department " + _deptName + " is successfully added");
                    this.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Add the department name and press ok");
                    goto l1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}

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
using databaseproject.manageResources;
using MySql.Data.MySqlClient;


namespace databaseproject
{
    /// <summary>
    /// Interaction logic for employee_details.xaml
    /// </summary>
    public partial class employee_details : Window
    {
        public employee_details()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();

        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            Window_addGroup _addGroup = new Window_addGroup();
            _addGroup.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Window_addteam _addTeam = new Window_addteam();
            _addTeam.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window_AddProject _addProject = new Window_AddProject();
            _addProject.ShowDialog();
        }

        

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();
        }

        private void button_manageresources_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_deletedepartment_Click(object sender, RoutedEventArgs e)
        {
            MySqlDataReader reader;
            string _dept = comboBox_department.SelectedItem.ToString();
            try
            {
            l1: if (_dept != "\0")
                {
                   
                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand deleteDepartment = new MySqlCommand("DELETE FROM resourcemanage.department WHERE dept_name = '"+_dept+"'", conn);
                    reader = deleteDepartment.ExecuteReader();
                    utilities._emp.comboBox_project.Items.Remove(_dept);
                  
                    MessageBox.Show("Department " + _dept + " is successfully deleted");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Select the department to be delted");
                    goto l1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

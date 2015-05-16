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


namespace databaseproject.manageResources
{
    /// <summary>
    /// Interaction logic for Window_AddProject.xaml
    /// </summary>
    public partial class Window_AddProject : Window
    {
        #region variables
        string _projectName;
        MySqlDataReader reader;
        #endregion variables
        public Window_AddProject()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            l1: if (textBox_projectName.Text != "\0")
                {
                    _projectName = textBox_projectName.Text;
                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.project(project_name) values ('" + _projectName + "');", conn);
                    reader = insertnew.ExecuteReader();
                    utilities._emp.comboBox_project.Items.Add(_projectName);
                    utilities._emp.comboBox_project.SelectedItem = _projectName;
                    MessageBox.Show("Project " + _projectName + " is successfully added");
                    this.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Add the Project name and press ok");
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

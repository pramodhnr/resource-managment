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
        string _groupName;
        string _teamName;
        MySqlDataReader reader;
        #endregion variables
        public Window_AddProject()
        {
            InitializeComponent();
        }

        public Window_AddProject(string group, string team)
        {
            _groupName = group;
            _teamName = team;
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
                    MySqlCommand getgroupName = new MySqlCommand("select id from resourcemanage.groups where group_name='" + _groupName + "'", conn);
                    MySqlCommand getteamName = new MySqlCommand("select id from resourcemanage.team where team_name='" + _teamName + "'", conn);

                    int _groupid = Convert.ToInt32(getgroupName.ExecuteScalar());
                    int _teamid = Convert.ToInt32(getteamName.ExecuteScalar());


                    MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.project(project_name,team_id,group_id) values ('" + _projectName + "','" + _teamid + "','" + _groupid + "');", conn);
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

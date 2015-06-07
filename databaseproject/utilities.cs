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
    public  class utilities
    {
        public  string connectionString;
        public  MySqlConnection connection;
        public static employee_details _emp = new employee_details();
        public  MySqlConnection openConnection()
        {
            try
            {
                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=root";
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }
        public  void closeConnection()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void populate_comboboxes()
        {
            utilities util = new utilities();
            MySqlDataReader reader;
            MySqlConnection conn = util.openConnection();
            try
            {
                conn.Open();
                MySqlCommand fetchDeptNames = new MySqlCommand("select dept_name from resourcemanage.department;", conn);
                reader = fetchDeptNames.ExecuteReader();
                while (reader.Read())
                {
                    _emp.comboBox_department.Items.Add(reader[0].ToString());
                }
                MySqlCommand fetchGroupNames = new MySqlCommand("select group_name from resourcemanage.groups;", conn);
                reader.Close();
                reader = fetchGroupNames.ExecuteReader();
                while (reader.Read())
                {
                    _emp.comboBox_group.Items.Add(reader[0].ToString());
                }
                reader.Close();
                MySqlCommand fetchTeamNames = new MySqlCommand("select team_name from resourcemanage.team;", conn);
                reader = fetchTeamNames.ExecuteReader();
                while (reader.Read())
                {
                    _emp.comboBox_team.Items.Add(reader[0].ToString());
                }
                reader.Close();
                MySqlCommand fetchProjectNames = new MySqlCommand("select project_name from resourcemanage.project;", conn);
                reader = fetchProjectNames.ExecuteReader();
                while (reader.Read())
                {
                    _emp.comboBox_project.Items.Add(reader[0].ToString());
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

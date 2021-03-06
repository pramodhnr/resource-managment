﻿using System;
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
            populate_comboboxes();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();

        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            
            Window_addGroup _addGroup = new Window_addGroup(comboBox_department.SelectedItem.ToString());
            _addGroup.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Window_addteam _addTeam = new Window_addteam(comboBox_group.SelectedItem.ToString());
            _addTeam.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window_AddProject _addProject = new Window_AddProject(comboBox_group.SelectedItem.ToString(),comboBox_team.SelectedItem.ToString());
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
            
            Window_manageResources _mr = new Window_manageResources();
            this.Close();
            _mr.ShowDialog();
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
                    //utilities._emp.comboBox_project.Items.Remove(_dept);
                    comboBox_department.Items.Remove(_dept);
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

        private void button1_deletegroup_Click(object sender, RoutedEventArgs e)
        {
            MySqlDataReader reader;
            string _group = comboBox_group.SelectedItem.ToString();
            try
            {
            l1: if (_group != "\0")
                {

                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand deleteGroup = new MySqlCommand("DELETE FROM resourcemanage.groups WHERE group_name = '" + _group + "'", conn);
                    reader = deleteGroup.ExecuteReader();
                    comboBox_group.Items.Remove(_group);
                    reader.Close();
                    MessageBox.Show("Group " + _group + " is successfully deleted");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Select the group to be delted");
                    goto l1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_deleteteam_Click(object sender, RoutedEventArgs e)
        {
            MySqlDataReader reader;
            string _team = comboBox_team.SelectedItem.ToString();
            try
            {
            l1: if (_team != "\0")
                {

                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand deleteTeam = new MySqlCommand("DELETE FROM resourcemanage.team WHERE team_name = '" + _team + "'", conn);
                    reader = deleteTeam.ExecuteReader();
                   // utilities._emp.comboBox_project.Items.Remove(_team);
                    comboBox_team.Items.Remove(_team);
                    reader.Close();
                    MessageBox.Show("Team " + _team + " is successfully deleted");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Select the team to be delted");
                    goto l1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_deleteProject_Click(object sender, RoutedEventArgs e)
        {
            MySqlDataReader reader;
            string _project = comboBox_project.SelectedItem.ToString();
            try
            {
            l1: if (_project != "\0")
                {

                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand deleteProject = new MySqlCommand("DELETE FROM resourcemanage.project WHERE project_name = '" + _project + "'", conn);
                    reader = deleteProject.ExecuteReader();
                    //utilities._emp.comboBox_project.Items.Remove(_project);
                    comboBox_project.Items.Remove(_project);
                    reader.Close();
                    MessageBox.Show("Project " + _project + " is successfully deleted");
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Select the project to be delted");
                    goto l1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    this.comboBox_department.Items.Add(reader[0].ToString());
                }
                if(this.comboBox_department.Items!=null)
                {
                    this.comboBox_department.SelectedItem = this.comboBox_department.Items[0];
                }

                MySqlCommand fetchGroupNames = new MySqlCommand("select group_name from resourcemanage.groups;", conn);
                reader.Close();
                reader = fetchGroupNames.ExecuteReader();
                while (reader.Read())
                {
                    this.comboBox_group.Items.Add(reader[0].ToString());
                }
                if (this.comboBox_group.Items != null)
                {
                    this.comboBox_group.SelectedItem = this.comboBox_group.Items[0];
                }
                reader.Close();
                
                MySqlCommand fetchTeamNames = new MySqlCommand("select team_name from resourcemanage.team;", conn);
                reader = fetchTeamNames.ExecuteReader();
                while (reader.Read())
                {
                    this.comboBox_team.Items.Add(reader[0].ToString());
                }

                if (this.comboBox_team.Items != null)
                {
                    this.comboBox_team.SelectedItem = this.comboBox_team.Items[0];
                }
                reader.Close();
                MySqlCommand fetchProjectNames = new MySqlCommand("select project_name from resourcemanage.project;", conn);
                reader = fetchProjectNames.ExecuteReader();
                while (reader.Read())
                {
                    this.comboBox_project.Items.Add(reader[0].ToString());
                }

                if (this.comboBox_project.Items != null)
                {
                    this.comboBox_project.SelectedItem = this.comboBox_project.Items[0];
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

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
using MySql.Data.MySqlClient;


namespace databaseproject.manageResources
{
    /// <summary>
    /// Interaction logic for Window_addteam.xaml
    /// </summary>
    public partial class Window_addteam : Window
    {
        #region variables
        string _teamName;
        string _groupName;
        MySqlDataReader reader;
        #endregion variables
        public Window_addteam()
        {
            InitializeComponent();
        }

        public Window_addteam(string group)
        {
            _groupName = group;
            InitializeComponent();
        }
        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            l1: if (textBox_teamName.Text != "\0")
                {
                    _teamName = textBox_teamName.Text;
                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand getgroupName = new MySqlCommand("select id from resourcemanage.groups where group_name='" + _groupName + "'", conn);

                    int _group_id = Convert.ToInt32(getgroupName.ExecuteScalar());
                    MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.team(team_name,group_id) values ('" + _teamName + "','"+_group_id+"');", conn);
                    reader = insertnew.ExecuteReader();
                    utilities._emp.comboBox_team.Items.Add(_teamName);
                    utilities._emp.comboBox_team.SelectedItem = _teamName;
                    MessageBox.Show("Team " + _teamName + " is successfully added");
                    this.Close();
                    conn.Close();
                }
                
                else
                {
                    MessageBox.Show("Add the team name and press ok");
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

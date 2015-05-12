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
    /// Interaction logic for Window_addGroup.xaml
    /// </summary>
    public partial class Window_addGroup : Window
    {
        #region variables
        string _groupName;
        MySqlDataReader reader;
        #endregion variables
        public Window_addGroup()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            l1: if (textBox_groupName.Text != "\0")
                {
                    _groupName = textBox_groupName.Text;
                    utilities util = new utilities();
                    MySqlConnection conn = util.openConnection();
                    conn.Open();
                    MySqlCommand insertnew = new MySqlCommand("insert into resourcemanage.groups(group_name) values ('" + _groupName + "');", conn);
                    reader = insertnew.ExecuteReader();
                    utilities._emp.comboBox_group.Items.Add(_groupName);
                    MessageBox.Show("Group "+ _groupName+" is successfully added");
                    this.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Add the group name and press ok");
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

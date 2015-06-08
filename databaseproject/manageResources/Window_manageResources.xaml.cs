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
using System.Data;


namespace databaseproject
{
    /// <summary>
    /// Interaction logic for Window_manageResources.xaml
    /// </summary>
    public partial class Window_manageResources : Window
    {
        public static int numberofemployees=0;
        public Window_manageResources()
        {
            InitializeComponent();
            bindToEmployeeTable();
        }
        public void bindToEmployeeTable()
        {
            utilities _util = new utilities();
            DataTable _dt = new DataTable();
            MySqlConnection conn;
            string query = "select emp_name,project_id,loading,email_id from resourcemanage.employee";
            try
            {
                _util.openConnection();
                conn = _util.openConnection();
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(_dt);
                    dataGrid_manageresources.ItemsSource = _dt.DefaultView;
                    numberofemployees = dataGrid_manageresources.Items.Count;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button_addResource_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            List<int> indices = new List<int>();
            foreach (DataRowView item in window_manageresources.dataGrid_manageresources.SelectedItems)
            {
                string email = item.Row[3].ToString();
                utilities util = new utilities();
                MySqlConnection conn = util.openConnection();
                conn.Open();
                MySqlCommand deleteResource = new MySqlCommand("DELETE FROM resourcemanage.employee WHERE email_id = '" + email + "'", conn);
                MySqlDataReader reader = deleteResource.ExecuteReader();
                conn.Close();
                indices.Add(window_manageresources.dataGrid_manageresources.SelectedIndex);
            }
            foreach (int index in indices)
            {
                DataRowView r = (DataRowView)window_manageresources.dataGrid_manageresources.Items[index];
                r.Delete();
            }
            
         }
    }
}

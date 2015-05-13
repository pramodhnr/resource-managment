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
        public Window_manageResources()
        {
            InitializeComponent();
        }
        public void bindToEmployeeTable()
        {
            utilities _util = new utilities();
            MySqlConnection conn;
            try
            {
                _util.openConnection();
                conn = _util.openConnection();
                conn.Open();
                MySqlCommand fetchEmpDetails = new MySqlCommand("select emp_name,project_id,loading,email_id from resourcemanage.employee", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(fetchEmpDetails);
                DataSet _ds = new DataSet();
                adp.Fill(_ds, "resourcemanage.employee");
                dataGrid_manageresources.DataContext = _ds;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

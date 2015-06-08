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

namespace databaseproject
{
    /// <summary>
    /// Interaction logic for choose.xaml
    /// </summary>
    public partial class choose : Window
    {
        public choose()
        {
            InitializeComponent();
        }

        private void button_manageResources_Click(object sender, RoutedEventArgs e)
        {
            employee_details _emp = new employee_details();
            this.Close();
            _emp.ShowDialog();
        }
    }
}

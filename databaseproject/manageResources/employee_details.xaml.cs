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

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            adddepartment _adddepartment = new adddepartment();
            _adddepartment.ShowDialog();
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
    }
}

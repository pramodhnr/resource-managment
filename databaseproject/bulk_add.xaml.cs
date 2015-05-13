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
using System.IO;
using MySql.Data.MySqlClient;

namespace databaseproject
{
    /// <summary>
    /// Interaction logic for bulk_add.xaml
    /// </summary>

   


    public partial class bulk_add : Window
    {
        
        public bulk_add()
        {
            InitializeComponent();
            
        }
        public List<Person> ReadCSV(string fileName)
        {

            var reader = new StreamReader(File.OpenRead(fileName));
            List<Person> listA = new List<Person>();
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                Person p = new Person(values[0], values[1]);
                listA.Add(p);
                
            }
            return listA;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            utilities util = new utilities();
            MySqlConnection conn = util.openConnection();
            conn.Open();
            var filepicker = new System.Windows.Forms.OpenFileDialog();
            var result = filepicker.ShowDialog();
            var filename = filepicker.FileName.ToString();
            filepath.Text = filename;
            filepath.ToolTip = filename;
            List<Person> person = ReadCSV(filename);
            
            foreach (Person p in person)
            {
                try
                {
                    MySqlCommand comm = new MySqlCommand("insert into resourcemanage.employee(emp_name,email_id) values('" + p.Username + "','" + p.email + "')", conn);
                    MySqlDataReader reader;
                    reader = comm.ExecuteReader();
                    reader.Read();
                    reader.Close();
                    MessageBox.Show("Upload succeeded");
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }

            }
        }
    }

}

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
        public IEnumerable<Person> ReadCSV(string fileName)
        {

            //FileStream fs = new FileStream(fileName, FileMode.Open());
            string[] lines = File.ReadAllLines(fileName);


            // lines.Select allows me to project each line as a Person. 
            // This will give me an IEnumerable<Person> back.
            return lines.Select(line =>
            {
                string[] data = line.Split(';');
                // We return a person with the data in order.
                return new Person(data[0], data[1]);
            });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var filepicker = new System.Windows.Forms.OpenFileDialog();
            var result = filepicker.ShowDialog();
            var filename = filepicker.FileName.ToString();
            filepath.Text = filename;
            filepath.ToolTip = filename;
            IEnumerable<Person> person = ReadCSV(filename);
            IEnumerator<Person> values=  person.GetEnumerator();
            //values.Reset();
            MessageBox.Show(values.Current.Username);
            values.MoveNext();
            MessageBox.Show(values.Current.Username);

           /* foreach (Person p in values)
            {
                MessageBox.Show(p.Username, p.email);
            }*/
        }
    }

}

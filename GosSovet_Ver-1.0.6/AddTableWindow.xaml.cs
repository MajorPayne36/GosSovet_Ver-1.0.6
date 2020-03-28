using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GosSovet_Ver_1._0._6
{
    /// <summary>
    /// Логика взаимодействия для AddTableWindow.xaml
    /// </summary>
    public partial class AddTableWindow : Window
    {
        public AddTableWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if( !string.IsNullOrEmpty(tbName.Text) ||
                !string.IsNullOrEmpty(tbType.Text))
            {
                string str = tbName.Text
                    + " " + tbType.Text
                    + ((bool)rb.IsChecked ? " NOT NULL " : "  ")
                    + ((bool)rb_Copy.IsChecked ? " PRIMARY KEY IDENTITY(1,1) " : " ,");
                listBox.Items.Add(str);
                    
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] arr = listBox.SelectedItem.ToString().Split(' ');
            tbName.Text = arr[0];
            tbType.Text = arr[1];
            if (string.Equals(arr[2], "not", StringComparison.OrdinalIgnoreCase)) rb.IsChecked = true;
            else rb.IsChecked = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = "";
            foreach (object obj in listBox.Items)
            {
                str += obj.ToString() + " ";

            }
            MessageBox.Show(str);
            int lastIndex = str.Count();
            str.Remove(--lastIndex);
            new AddTableWindow2().Show();
        }
    }
}

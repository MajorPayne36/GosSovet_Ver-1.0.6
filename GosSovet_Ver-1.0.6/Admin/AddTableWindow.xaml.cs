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
        int selectedItemIndex = -1;
        private static SQLWork sqlWork { get; set; }
        public AddTableWindow (SQLWork work)
        {
            sqlWork = work;
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
                    + ((bool)rb_Copy.IsChecked ? " PRIMARY KEY IDENTITY(1,1) " : " ");
                listBox.Items.Add(str);
                    
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                selectedItemIndex = listBox.SelectedIndex;
                string[] arr = listBox.SelectedItem.ToString().Split(' ');
                tbName.Text = arr[0];
                tbType.Text = arr[1];
                foreach (string s in arr)
                {
                    if (string.Equals(s, "not", StringComparison.OrdinalIgnoreCase)) { rb.IsChecked = true; break; }
                    else rb.IsChecked = false;
                }
                foreach (string s in arr)
                {
                    if (string.Equals(s, "identity(1,1)", StringComparison.OrdinalIgnoreCase)) { rb_Copy.IsChecked = true; break; }
                    else rb_Copy.IsChecked = false;
                }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = "CREATE TABLE " + tableName.Text + " ( ";
            foreach (object obj in listBox.Items)
            {
                str += obj.ToString() + ", ";

            }
            MessageBox.Show(str);
            int lastIndex = str.Count();
            str.Remove(--lastIndex);
            str += " ); ";
            sqlWork.AddTable(str);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (selectedItemIndex == -1) MessageBox.Show("Выберите из элемент списка");
            else listBox.Items.RemoveAt(selectedItemIndex);
        }
    }
}

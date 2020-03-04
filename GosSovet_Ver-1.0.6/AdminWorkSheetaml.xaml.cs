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
using System.Data.SqlClient;
//using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
//using System.Drawing;

namespace GosSovet_Ver_1._0._6
{
    /// <summary>
    /// Логика взаимодействия для AdminWorkSheetaml.xaml
    /// </summary>
    public partial class AdminWorkSheetaml : Window
    {
        SolidColorBrush red = new SolidColorBrush(Color.FromRgb(200, 00, 00));
        SolidColorBrush blue = new SolidColorBrush(Color.FromRgb(00, 00, 200));
        public AdminWorkSheetaml()
        {
            InitializeComponent();
        }

        private void AddConvas_MouseEnter(object sender, MouseEventArgs e)
        {
            AddCan.Background    = red;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }
        

        private void ChangeCan_MouseEnter(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = red;
            OtchetCan.Background = blue;
        }

        private void DeleteCan_MouseEnter(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = red;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }

        private void OtchetCan_MouseEnter(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = red;
        }

        private void OtchetCan_MouseLeave(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }

        private void DeleteCan_MouseLeave(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }

        private void ChangeCan_MouseLeave(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }

        private void AddCan_MouseLeave(object sender, MouseEventArgs e)
        {
            AddCan.Background = blue;
            DeleteCan.Background = blue;
            ChangeCan.Background = blue;
            OtchetCan.Background = blue;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            {
                //меняем цвета
                AddCan.Background = blue;
                DeleteCan.Background = blue;
                ChangeCan.Background = blue;
                OtchetCan.Background = blue;
            }

            SQLWork work = new SQLWork();
            DataTable data = new DataTable();
            data = work.GetDboTables(data);

            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                comboBox1.Items.Add(cells[0].ToString());
            }
            comboBox1.Items.Remove("sysdiagrams");

        }

        private void AddCan_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ChangeCan_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteCan_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableName = comboBox1.SelectedItem.ToString();


        }
    }
}

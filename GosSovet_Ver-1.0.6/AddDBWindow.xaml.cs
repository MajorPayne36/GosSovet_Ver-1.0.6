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
    /// Логика взаимодействия для AddDBWindow.xaml
    /// </summary>
    public partial class AddDBWindow : Window
    {
        public AddDBWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var work = new SQLWork();
            work.AddDB(tbox.Text);
            this.Hide();
            MessageBox.Show("БД создан");
            this.Close();
        }
    }
}

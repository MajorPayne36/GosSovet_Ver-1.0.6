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
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            var regwindow = new Registr();
            regwindow.Show();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string constr = @"Data Source=DESKTOP-GM2O70F\MSSQLDEV;Initial Catalog=GosSoviet;Integrated Security=True";
            SQLWork work = new SQLWork();
            if (work.FindUser(tbLog.Text, tbPass.Text))
            {
                Loading ld = new Loading();
                this.Hide();
                ld.Show();

            }
            else MessageBox.Show("Неправильный логин или пороль", "",MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
    }
}

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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
            comboBox1.Items.Add("wtf12");
            comboBox1.Items.Add("wtf123");

            comboBox1.Items.Add("wtf1234");

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show("closing"); //Срабатывает перед закрытием
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //MessageBox.Show("closed"); //Срабатывает после закрытия
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            tbWhat.Visibility = Visibility.Hidden;
            tbWhat2.Visibility = Visibility.Hidden;
            tbWhat3.Visibility = Visibility.Hidden;
            btnNext_Copy.Visibility = Visibility.Hidden;

            if (String.IsNullOrEmpty(tbN.Text)
                || String.IsNullOrEmpty(tbF.Text)
                || String.IsNullOrEmpty(tbS.Text)
                || comboBox1.SelectedItem == null
                || !dataPicker.SelectedDate.HasValue) tbWhat.Visibility = Visibility.Visible;
            else
            {
                btnNext_Copy.Visibility = Visibility.Visible;
                Step1.Visibility = Visibility.Hidden;
                Step2.Visibility = Visibility.Visible;
            }

            if (String.IsNullOrEmpty(tbN.Text)
                || String.IsNullOrEmpty(tbN.Text)
                || String.IsNullOrEmpty(tbN.Text)) tbWhat2.Visibility = Visibility.Visible;
            else if (tbpas.Text != tbpastopas.Text) tbWhat2.Visibility = Visibility.Visible;
            else
            {
                //регистрация
            }
            

        }

        private void btnNext_Copy_Click(object sender, RoutedEventArgs e)
        {
            Step2.Visibility = Visibility.Hidden;
            Step1.Visibility = Visibility.Visible;
            btnNext_Copy.Visibility = Visibility.Hidden;
        }
    }
}

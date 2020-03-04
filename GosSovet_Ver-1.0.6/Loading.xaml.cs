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
using System.Windows.Threading;

namespace GosSovet_Ver_1._0._6
{
    /// <summary>
    /// Логика взаимодействия для Loading.xaml
    /// </summary>
    public partial class Loading : Window
    {
        public Loading()
        {
            Loading1();
            InitializeComponent();
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            //Вызов рабочего окна
            this.Close();
        }

        void Loading1()
        {
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 6);
            timer.Start();
        }
    }
}

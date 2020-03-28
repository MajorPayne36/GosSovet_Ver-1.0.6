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
    /// Логика взаимодействия для AddTableWindow2.xaml
    /// </summary>
    public partial class AddTableWindow2 : Window
    {
        string parametres;
        public AddTableWindow2(string str)
        {
            parametres = str;
        }

        public AddTableWindow2()
        {
            InitializeComponent();
        }
    }
}

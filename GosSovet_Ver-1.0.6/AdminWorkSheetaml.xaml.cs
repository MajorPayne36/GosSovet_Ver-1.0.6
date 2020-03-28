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
        SQLWork work = new SQLWork();
        GosSovietContext db = new GosSovietContext();

        public AdminWorkSheetaml()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable data = new DataTable();
            data = work.GetDboTables(data);

            foreach (DataRow row in data.Rows)
            {
                var cells = row.ItemArray;
                comboBox1.Items.Add(cells[0].ToString());
            }
            comboBox1.Items.Remove("sysdiagrams");

            var profiles = db.Profile.ToList();
            foreach (var profile in profiles)
            {
                comboBoxProfile.Items.Add(profile.IdProfile + profile.ProfileName);
            }

            var meets = db.Meeting.ToList();
            foreach (var meet in meets)
            {
                comboBoxMeet.Items.Add(meet.IdMeeting + " " + meet.Date + " " + meet.City);
            }
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tableName = comboBox1.SelectedItem.ToString();
            work.FillDataGrid(dataGrid1, tableName);

            switch (tableName)
            {
                case "Deput_and_Com":
                    {
                        GridAddMeet.Visibility = Visibility.Hidden;
                        GridAddPost.Visibility = Visibility.Hidden;
                        GridAddProfile.Visibility = Visibility.Hidden;
                        GridAddDep.Visibility = Visibility.Hidden;
                        GridAddComis.Visibility = Visibility.Hidden;
                        GridAddDepNCom.Visibility = Visibility.Visible;
                    }
                    break;
                case "Comission":
                    {
                        GridAddMeet.Visibility = Visibility.Hidden;
                        GridAddPost.Visibility = Visibility.Hidden;
                        GridAddProfile.Visibility = Visibility.Hidden;
                        GridAddDep.Visibility = Visibility.Hidden;
                        GridAddComis.Visibility = Visibility.Visible;
                        GridAddDepNCom.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Meeting":
                    {
                        GridAddMeet.Visibility = Visibility.Visible;
                        GridAddPost.Visibility = Visibility.Hidden;
                        GridAddProfile.Visibility = Visibility.Hidden;
                        GridAddDep.Visibility = Visibility.Hidden;
                        GridAddComis.Visibility = Visibility.Hidden;
                        GridAddDepNCom.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Post":
                    {
                        GridAddMeet.Visibility = Visibility.Hidden;
                        GridAddPost.Visibility = Visibility.Visible;
                        GridAddProfile.Visibility = Visibility.Hidden;
                        GridAddDep.Visibility = Visibility.Hidden;
                        GridAddComis.Visibility = Visibility.Hidden;
                        GridAddDepNCom.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Profile":
                    {
                        GridAddMeet.Visibility = Visibility.Hidden;
                        GridAddPost.Visibility = Visibility.Hidden;
                        GridAddProfile.Visibility = Visibility.Visible;
                        GridAddDep.Visibility = Visibility.Hidden;
                        GridAddComis.Visibility = Visibility.Hidden;
                        GridAddDepNCom.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Deputy":
                    {
                        GridAddMeet.Visibility = Visibility.Hidden;
                        GridAddPost.Visibility = Visibility.Hidden;
                        GridAddProfile.Visibility = Visibility.Hidden;
                        GridAddDep.Visibility = Visibility.Visible;
                        GridAddComis.Visibility = Visibility.Hidden;
                        GridAddDepNCom.Visibility = Visibility.Hidden;
                    }
                    break;
            }
        }

        private void dataGrid1_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            string tableName = comboBox1.SelectedItem.ToString();
            work.SaveDboChanges(tableName);
        }

        #region MenuItemClick

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            new AddDBWindow().Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            new AddTableWindow().Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region btn_click

        private void btnDepNCom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComis_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxProfile.SelectedItem == null) MessageBox.Show("Выберите профиль комиссии");
            else
            {
                try
                {
                    Comission comission = new Comission
                    {
                        ComissionName = tbNameComis.Text,
                        IdProfile = comboBoxProfile.SelectedIndex
                    };
                    db.Add(comission);
                    db.SaveChanges();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
            
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSurname.Text) ||
                string.IsNullOrEmpty(tbFathername.Text) ||
                string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrEmpty(tbLogin.Text) ||
                string.IsNullOrEmpty(tbPass.Text) ||
                dataPickerDeputy.SelectedDate == null)
                MessageBox.Show("Введите все данные");
            else if (work.FindUser(tbLogin.Text))
                MessageBox.Show("Такой логин уже существует");
            else
            {
                Deputy deputy = new Deputy
                {
                    Surname = tbSurname.Text,
                    Fathername = tbFathername.Text,
                    Name = tbName.Text,
                    Login = tbLogin.Text,
                    Password = tbPass.Text,
                    Birthday = dataPickerDeputy.SelectedDate,
                    Dostup = (bool)checkBoxDeputy.IsChecked
                };
                db.Add(deputy);
                db.SaveChanges();
                MessageBox.Show("Депутат успешно добавлен");

                tbSurname.Text = "";
                tbFathername.Text = "";
                tbName.Text = "";
                tbLogin.Text = "";
                dataPickerDeputy.SelectedDate = null;
                tbPass.Text = "";
            }
        }

        private void btnProf_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNameProf.Text))
                MessageBox.Show("Введите название профиля!");
            else
            {
                Profile pr = new Profile
                {
                    ProfileName = tbNameProf.Text
                };
                db.Add(pr);
                db.SaveChanges();
            }
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            decimal slr;
            if (string.IsNullOrEmpty(tbNamePost.Text))
                MessageBox.Show("Введите название должности!");
            else if (!decimal.TryParse(tbSalaryPost.Text, out slr))
                MessageBox.Show("Введена некорректная зарплата!");
            else
            {
                Post pt = new Post
                {
                    PostName = tbNameProf.Text,
                    Salary = decimal.Parse(tbSalaryPost.Text)
                };
                db.Add(pt);
                db.SaveChanges();
            }
        }

        private void btnMeet_Click(object sender, RoutedEventArgs e)
        {
            if (datapickerMeet.SelectedDate == null) MessageBox.Show("Выберите дату!");
            else if (string.IsNullOrEmpty(tbCityMeet.Text)) MessageBox.Show("Введите город!");
            else if (comboBoxMeet.SelectedItem == null) MessageBox.Show("Выберите комиссию!");
            else
            {
                string[] arr = new string[3];
                arr = comboBoxMeet.SelectedItem.ToString().Split(' ');

                Meeting meeting = new Meeting
                {
                    City = tbCityMeet.Text,
                    Date = (DateTime)datapickerMeet.SelectedDate,
                    IdComission = Convert.ToInt32(arr[2])
                };

                db.Add(meeting);
                db.SaveChanges();
            }
        }

        #endregion

        #region IsVisibleChanged

        private void GridAddMeet_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            comboBoxMeet.Items.Clear();
            var comissions = db.Comission.ToList();
            foreach (var comission in comissions)
            {
                comboBoxMeet.Items.Add(comission.IdComission + " " + comission.ComissionName);
            }
        }

        private void GridAddComis_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            comboBoxProfile.Items.Clear();
            var profiles = db.Profile.ToList();
            foreach (var profile in profiles)
            {
                comboBoxProfile.Items.Add(profile.IdProfile + profile.ProfileName);
            }

        }

        private void GridAddDepNCom_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            comboBoxPost.Items.Clear();
            comboBoxDeput.Items.Clear();
            comboBoxComis.Items.Clear();

            var table = db.Deputy.ToList();
            foreach (var row in table)
            {
                comboBoxDeput.Items.Add(row.IdDeputy + " | " + row.Surname + " " + row.Name + " " + row.Fathername);
            }
            
            var table1 = db.Comission.ToList();
            foreach (var row in table1)
            {
                comboBoxComis.Items.Add(row.IdComission + " | " + row.ComissionName);
            }

            var table2 = db.Post.ToList();
            foreach (var row in table2)
            {
                comboBoxPost.Items.Add(row.IdPost + " | " + row.PostName);
            }

        }



        #endregion

        private void DateIn_CalendarClosed(object sender, RoutedEventArgs e)
        {
            DateOut.SelectedDate = DateIn.SelectedDate + new TimeSpan(730, 0, 0, 0, 0); //new DateTime(year: 2, month: 0, day: 0);
        }
    }
}

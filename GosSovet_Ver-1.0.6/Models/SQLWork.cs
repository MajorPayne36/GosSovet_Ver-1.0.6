using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;

namespace GosSovet_Ver_1._0._6
{
    public partial class SQLWork
    {
        public string connectionstr = @"Data Source=DESKTOP-GM2O70F\MSSQLDEV;Initial Catalog=GosSoviet;Integrated Security=True"; //{get; set;}
        
        private static SqlCommand sqlCommand { get; set; } = new SqlCommand();

        /// <summary>
        /// Создает таблицу
        /// </summary>
        public void AddTable (string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                sqlConnection.Open();
                try
                {
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Таблица успешно создана!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Creat DB
        /// </summary>
        /// <param name="name"></param>
        public void AddDB(string name) 
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                sqlConnection.Open();
                try
                {
                    string query = "CREATE DATABASE " + name + ";";
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                                 
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
            
        }

        /// <summary>
        /// Заполняет передаваемый датагрид
        /// </summary>
        public void FillDataGrid (DataGrid grid, string tableName)
        {
            grid.AllowDrop = true;
           

            grid.Columns.Clear();
            grid.ItemsSource = null;
            grid.Items.Clear();
            grid.Items.Refresh();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter;

            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                sqlConnection.Open();
                try
                {
                    string query = "SELECT * FROM " + tableName;
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = sqlConnection;

                    adapter = new SqlDataAdapter(query, sqlConnection);

                    adapter.Fill(dt);

                    grid.ItemsSource = dt.DefaultView;
                    adapter.Dispose();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            dt.Dispose();
        }

        /// <summary>
        /// Выводит список всех таблиц из БД
        /// </summary>
        public DataTable GetDboTables(DataTable dt)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                sqlConnection.Open();
                try
                {
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE table_type='BASE TABLE'";
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = sqlConnection;

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connectionstr);

                    adapter.Fill(dt);
                    sqlCommand.ExecuteNonQuery();
                    adapter.Dispose();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        /// <summary>
        /// Отправляет передаваемый запрос
        /// </summary>
        public void SendQuery (string str)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                sqlConnection.Open();
                try
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        sqlCommand.CommandText = str;
                        sqlCommand.Connection = sqlConnection;
                    }
                    else MessageBox.Show("Пустой запрос");
                    int number = sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Добавлено "+number.ToString()+" параметров");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Обновляет БД
        /// </summary>
        public void SaveDboChanges (string tableName)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM " + tableName, sqlConnection);

                sqlConnection.Open();
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.UpdateCommand = builder.GetUpdateCommand();
                adapter.Update(dt);
                builder.Dispose();

            }
        }

        /// <summary>
        /// Проверка на существование пользователя
        /// </summary>
        public Boolean FindUser (string Login, string Password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                try
                {
                    sqlConnection.Open();

                    //SqlParameter logP = new SqlParameter("@Login", Login);
                    //SqlParameter pasP = new SqlParameter("@Password", Password);
                    //sqlCommand.Parameters.Add(logP);
                    //sqlCommand.Parameters.Add(pasP);

                    string cmd = "SELECT COUNT(*) FROM Deputy WHERE Login = '" + Login + "' AND Password = '" + Password + "'";
                    sqlCommand.CommandText = cmd;
                    sqlCommand.Connection = sqlConnection;
                    object count = sqlCommand.ExecuteScalar();

                    if (Convert.ToInt32(count) > 0) return true;
                    else return false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            
        }
        /// <summary>
        /// Нахождение юзера по логину
        /// </summary>
        public Boolean FindUser(string Login)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                try
                {
                    sqlConnection.Open();

                    string cmd = "SELECT COUNT(*) FROM Deputy WHERE Login = '" + Login + "'";
                    sqlCommand.CommandText = cmd;
                    sqlCommand.Connection = sqlConnection;
                    object count = sqlCommand.ExecuteScalar();

                    if (Convert.ToInt32(count) > 0) return true;
                    else return false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

        }

        /// <summary>
        /// Проверка на роль админа
        /// </summary>
        public Boolean IsAdmin (string Login, string Password)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionstr))
            {
                try
                {

                    sqlConnection.Open();
                    SqlParameter logP = new SqlParameter("@Login", Login);
                    SqlParameter pasP = new SqlParameter("@Password", Password);
                    string cmd = "SELECT Dostup FROM Deputy WHERE Login = @Login AND Password = @Password";
                    sqlCommand.CommandText = cmd;
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    object count = sqlCommand.ExecuteNonQuery();
                    if (reader.GetBoolean(0)) return true;
                    else return false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

    }
}

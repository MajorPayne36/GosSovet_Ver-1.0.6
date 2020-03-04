using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace GosSovet_Ver_1._0._6
{
    class SQLWork
    {
        public string connectionstr = @"Data Source=DESKTOP-GM2O70F\MSSQLDEV;Initial Catalog=GosSoviet;Integrated Security=True"; //{get; set;}
        
        private static SqlCommand sqlCommand { get; set; } = new SqlCommand();

        //public void SQLWork(string str)
        //{
        //   connectionstr = str;
        //}

        //Update Insert Delete
        //public void Insert (string str)
        //{
        //    sqlConnection.Open();
        //    try
        //    {
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            sqlCommand.CommandText = str;
        //            sqlCommand.Connection = sqlConnection;
        //        }
        //        else MessageBox.Show("Пустой запрос");
        //        int number = sqlCommand.ExecuteNonQuery();
        //        MessageBox.Show("Добавлено {0} параметров", number.ToString());
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        //public void Update (string str)
        //{
        //    sqlConnection.Open();
        //    try
        //    {
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            sqlCommand.CommandText = str;
        //            sqlCommand.Connection = sqlConnection;
        //        }
        //        else MessageBox.Show("Пустой запрос");
        //        int number = sqlCommand.ExecuteNonQuery();
        //        MessageBox.Show("Добавлено {0} параметров", number.ToString());
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        //public void Delete (string str)
        //{
        //    sqlConnection.Open();
        //    try
        //    {
        //        if (string.IsNullOrEmpty(str))
        //        {
        //            sqlCommand.CommandText = str;
        //            sqlCommand.Connection = sqlConnection;
        //        }
        //        else MessageBox.Show("Пустой запрос");
        //        int number = sqlCommand.ExecuteNonQuery();
        //        MessageBox.Show("Добавлено {0} параметров", number.ToString());
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //    }
        //}

        //Заполняет датагрид
        public void FillDataGrid (System.Windows.Controls.DataGrid grid, string tableName)
        {

        }
        //находит список всех таблиц
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

                    //DataSet ds = new DataSet();
                    //dt = new DataTable();
                    adapter.Fill(dt);
                    int number = sqlCommand.ExecuteNonQuery();
                    //MessageBox.Show("Добавлено " + number.ToString() + " параметров");
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        //незнаю что это
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

        //Проверка на существования юзера
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

        //Проверка на админа
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

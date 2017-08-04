using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace EMSclient
{
    class InitConnect
    {
        [DllImport("kernel32.dll")]
        private static extern bool GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnValue, int nSize, string lpFileName);

        /// <summary>
        /// 实例化一个SQL连接
        /// </summary>
        /// <returns>返回一个SqlConnection实例</returns>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("WorkStation ID=" + GetServer() + ";User ID=" + GetUser() + ";Password=" + GetPwd() + ";Database=" + GetDatabaseName());
        }

        /// <summary>
        /// 获取服务器名称
        /// </summary>
        /// <returns>服务器名称</returns>
        public static string GetServer()
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            StringBuilder str = new StringBuilder(30);
            GetPrivateProfileString("Connection", "Server", "(local)", str, str.Capacity, FileName);
            string server = str.ToString().Trim();
            return server;
        }

        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <returns>数据库用户名</returns>
        public static string GetUser()
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            StringBuilder str = new StringBuilder(30);
            GetPrivateProfileString("Connection", "User ID", "sa", str, str.Capacity, FileName);
            string user = str.ToString().Trim();
            return user;
        }

        /// <summary>
        /// 获取数据库密码
        /// </summary>
        /// <returns>连接数据库的密码</returns>
        public static string GetPwd()
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            StringBuilder str = new StringBuilder(30);
            GetPrivateProfileString("Connection", "Password", "", str, str.Capacity, FileName);
            string pwd = str.ToString().Trim();
            return pwd;
        }

        /// <summary>
        /// 获取数据库的名称
        /// </summary>
        /// <returns>数据库名称</returns>
        public static string GetDatabaseName()
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            StringBuilder str = new StringBuilder(30);
            GetPrivateProfileString("Connection", "Database", "book", str, str.Capacity, FileName);
            string database = str.ToString().Trim();
            return database;
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="selectstring">选择导出数据的SQL选择语句</param>
        public static void DataOut(SaveFileDialog dialog, string selectstring)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Excel.ApplicationClass excel = new Excel.ApplicationClass();
                // Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                // Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets.Add(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                //worksheet.Cells.NumberFormatLocal = "@";
                ///////////////////////////////////
                SqlConnection connect = InitConnect.GetConnection();
                SqlDataReader read = null;
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(selectstring, connect);
                    read = cmd.ExecuteReader();
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        //worksheet.Cells[1, i + 1] = read.GetName(i).Trim();
                    }
                    int row = 2;
                    int count = 0;
                    while (read.Read())
                    {
                        count++;
                        for (int i = 0; i < read.FieldCount; i++)
                        {
                            //worksheet.Cells[row, i + 1] = read[i].ToString().Trim();
                        }
                        row++;
                    }
                    MessageBox.Show("成功导出" + count.ToString() + "条记录！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("错误：" + ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    read.Close();
                    connect.Close();
                    object change = false, filename = dialog.FileName;
                    // workbook.SaveCopyAs(filename);
                    //workbook.Close(change, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    //excel.Quit();
                }
            }
        }

        /// <summary>
        /// 获取是否有商品超过系统上限
        /// </summary>
        /// <param name="Flag">Flag为true表示图书，为false表示光盘</param>
        /// <returns>返回超过系统上限的数量</returns>
        public static string GetWareUp(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("WareUpCount", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            if (Flag)
            {
                cmd.Parameters.AddWithValue("@Flag", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Flag", 2);
            }
            string count = (cmd.ExecuteScalar().ToString().Trim() != "") ? cmd.ExecuteScalar().ToString().Trim() : "0";
            connect.Close();
            return count;
        }

        /// <summary>
        /// 获取是否有商品低于系统下限
        /// </summary>
        /// <param name="Flag">Flag为true表示图书，为false表示光盘</param>
        /// <returns>返回低于系统下限的数量</returns>
        public static string GetWareDown(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("WareDownCount", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            if (Flag)
            {
                cmd.Parameters.AddWithValue("@Flag", 1);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Flag", 2);
            }
            string count = (cmd.ExecuteScalar().ToString().Trim() != "") ? cmd.ExecuteScalar().ToString().Trim() : "0";
            connect.Close();
            return count;
        }
    }
}

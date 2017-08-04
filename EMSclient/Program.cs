using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace EMSclient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool exists;
            System.Threading.Mutex myform = new System.Threading.Mutex(true, "OnlyOnce", out exists);
            if (exists)
            {
                if (TestConnection())
                {
                    FmLogin login = new FmLogin();
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        myform.ReleaseMutex();
                        login.Close();
                        Application.Run(new FmMain());

                    }
                }
                else
                {
                    FmSet set = new FmSet();
                    set.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("程序已经运行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        [DllImport("kernel32.dll")]
        private static extern bool GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnValue, int nSize, string lpFileName);

        /// <summary>
        /// 测试是否能连接到数据库
        /// </summary>
        /// <returns>true表示能连接，false表示不能连接到数据库</returns>
        private static bool TestConnection()
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            StringBuilder str = new StringBuilder(30);
            if (File.Exists(FileName))
            {
                GetPrivateProfileString("Connection", "Server", "(local)", str, str.Capacity, FileName);
                string server = str.ToString().Trim();
                GetPrivateProfileString("Connection", "User ID", "ZXC", str, str.Capacity, FileName);
                string user = str.ToString().Trim();
                GetPrivateProfileString("Connection", "Password", "", str, str.Capacity, FileName);
                string pwd = str.ToString().Trim();
                GetPrivateProfileString("Connection", "Database", "book", str, str.Capacity, FileName);
                string database = str.ToString().Trim();
                SqlConnection connect = new SqlConnection("WorkStation ID=" + server + ";User ID=" + user + ";Password=" + pwd + ";Database=" + database);
                try
                {
                    connect.Open();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("数据库服务器配置出现错误：" + e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return false;
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("数据库服务器配置文件config.ini不存在，无法连接数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return false;
            }
        }
    }
}

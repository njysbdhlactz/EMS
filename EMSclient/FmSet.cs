using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;

namespace EMSclient
{
    public partial class FmSet : Form
    {
        public FmSet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        [DllImport("kernel32.dll")]
        private static extern bool WritePrivateProfileString(string lpApplicationName,string lpKeyName,string lpString,string lpFileName);

        private void button1_Click(object sender, EventArgs e)//确定设置
        {
            string FileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\config.ini";
            WritePrivateProfileString("Connection", "Server", this.server.Text.Trim(), FileName);
            WritePrivateProfileString("Connection","User ID",this.user.Text.Trim(),FileName);
            WritePrivateProfileString("Connection","Password",this.pwd.Text.Trim(),FileName);
            WritePrivateProfileString("Connection","Database",this.database.Text.Trim(),FileName);
            MessageBox.Show("数据库服务器配置成功，请重新启动应用程序！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            Application.Exit();
        }

        private void FrmSet_Load(object sender, EventArgs e)//初始化
        {
            this.server.Items.Add(Environment.MachineName.Trim());
        }

        private void comboBox2_DropDown(object sender, EventArgs e)//列出所有本机上的数据库
        {
            SqlConnection connect = new SqlConnection("Server=" + this.server.Text.Trim() + ";Database=master;User ID=" + this.user.Text.Trim() + ";Password=" + this.pwd.Text.Trim());
            try
            {
                this.database.Items.Clear();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select name from sysdatabases", connect);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    this.database.Items.Add(read["name"].ToString());
                }
                read.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("连接错误：" + ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            finally
            {
                connect.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)//测试连接
        {
            SqlConnection connect = new SqlConnection("Server="+this.server.Text.Trim()+";Database="+this.database.Text.Trim()+";User ID="+this.user.Text.Trim()+";Password="+this.pwd.Text.Trim());
            try
            {
                connect.Open();
                MessageBox.Show("连接成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch
            {
                MessageBox.Show("连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
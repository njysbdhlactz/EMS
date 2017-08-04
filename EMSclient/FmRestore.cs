using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMSclient
{
    public partial class FmRestore : Form
    {
        public FmRestore()
        {
            InitializeComponent();
        }

        private void look_Click(object sender, EventArgs e)//浏览
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.filename.Text = this.openFileDialog1.FileName;
            }
        }

        private void cancel_Click(object sender, EventArgs e)//取消
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)//还原数据库
        {
            this.UseOtherDatabase();
            /////////////////////////////////
            SqlConnection connect = new SqlConnection("Server=" + InitConnect.GetServer() + ";Database=master;User ID=" + InitConnect.GetUser() + ";Password=" + InitConnect.GetPwd());
            connect.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("restore database " + InitConnect.GetDatabaseName() + " from disk='" + this.filename.Text.Trim() + "' with replace", connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功还原数据库\"" + InitConnect.GetDatabaseName() + "\"！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            catch (Exception ee)
            {
                MessageBox.Show("还原数据库\"" + InitConnect.GetDatabaseName() + "\"失败！\n错误信息：" + ee.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// 还原数据库前use其它数据库
        /// </summary>
        private void UseOtherDatabase()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("use master",connect);
            cmd.ExecuteNonQuery();
            connect.Close();

        }
    }
}
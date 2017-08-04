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
    public partial class FmBackUp : Form
    {
        public FmBackUp()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void look_Click(object sender, EventArgs e)//浏览
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.filename.Text = this.saveFileDialog1.FileName;
            }
        }

        private void ok_Click(object sender, EventArgs e)//备份
        {
            if (this.filename.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("backup database " + InitConnect.GetDatabaseName() + " to disk='" + this.filename.Text.Trim() + "' with init", connect);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("您成功备份了数据库！","恭喜",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("备份失败！\n错误信息："+ee.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("请输入正确的路径及备份文件名称！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }
    }
}
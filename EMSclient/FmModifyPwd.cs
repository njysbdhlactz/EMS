using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using MD5Method;

namespace EMSclient
{
    public partial class FmModifyPwd : Form
    {
        public FmModifyPwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//修改密码
        {
            if (this.GetPwd() == MD5.MD5String(this.oldpwd.Text.Trim()).Trim())
            {
                if (this.newpwd.Text.Trim() != "" && this.pwdok.Text.Trim() != "")
                {
                    if (this.newpwd.Text.Trim() == this.pwdok.Text.Trim())
                    {
                        SqlConnection connect = InitConnect.GetConnection();
                        connect.Open();
                        SqlCommand cmd = new SqlCommand("update book_user set user_pwd=@pwd where user_id=@id", connect);
                        cmd.Parameters.AddWithValue("@id", UserInfo.UserID.Trim());
                        cmd.Parameters.AddWithValue("@pwd", MD5Method.MD5.MD5String(this.newpwd.Text.Trim()));
                        cmd.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("两次输入的密码不一致！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        this.newpwd.Text = "";
                        this.pwdok.Text = "";
                        this.newpwd.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("为了安全起见系统规定用户的密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("原密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.oldpwd.Text = "";
                this.oldpwd.Focus();
            }
        }

        /// <summary>
        /// 获取当前用户的当前密码
        /// </summary>
        /// <returns>当前密码</returns>
        private string GetPwd()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select user_pwd from book_user where user_id=@id", connect);
            cmd.Parameters.AddWithValue("@id", UserInfo.UserID.Trim());
            string password = cmd.ExecuteScalar().ToString().Trim();
            connect.Close();
            return password;
        }
        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }
    }
}
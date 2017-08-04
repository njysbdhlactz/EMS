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
    public partial class FmReturnDate : Form
    {
        public FmReturnDate()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//修改设置
        {
            if (this.comboBox1.Text.Trim() != "" && this.comboBox2.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("SetBackReturn", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book", int.Parse(this.comboBox1.Text.Trim()));
                cmd.Parameters.AddWithValue("@cd", int.Parse(this.comboBox2.Text.Trim()));
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("设置成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入退货期限值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.comboBox1.Focus();
                return;
            }
        }

        private void FrmReturnDate_Load(object sender, EventArgs e)//初始化
        {
            this.GetReturnDate();
        }

        /// <summary>
        /// 获取当前退货的期限
        /// </summary>
        private void GetReturnDate()
        {
            if (this.IsConfig())
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select back_return_count from back_return where back_return_name='图书'", connect);
                this.comboBox1.Text = cmd.ExecuteScalar().ToString().Trim();
                cmd = new SqlCommand("select back_return_count from back_return where back_return_name='光盘'", connect);
                this.comboBox2.Text = cmd.ExecuteScalar().ToString().Trim();
                connect.Close();
            }
            else
            {
                MessageBox.Show("您还没有进行退货期限的设置，系统自动设置为0值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.comboBox1.Text = "0";
                this.comboBox2.Text = "0";
                this.DefaultConfig();
            }
        }

        /// <summary>
        /// 退货期限是否已经设置
        /// </summary>
        /// <returns>true表示已经设置，false表示未设置</returns>
        private bool IsConfig()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from back_return",connect);
            string result = cmd.ExecuteScalar().ToString().Trim();
            connect.Close();
            return (result != "0");
        }

        /// <summary>
        /// 默认设置
        /// </summary>
        private void DefaultConfig()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into back_return(back_return_name,back_return_count) values('光盘',0)", connect);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into back_return(back_return_name,back_return_count) values('图书',0)", connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
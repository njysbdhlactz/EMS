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
    public partial class FmUpdown : Form
    {
        public FmUpdown()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void up_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void FrmUpdown_Load(object sender, EventArgs e)//初始化
        {
            this.DisplayCurrent();
        }

        /// <summary>
        /// 获取当前上下限设置
        /// </summary>
        private void DisplayCurrent()
        {
            if (this.IsConfig())
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select updown_count from book_updown where updown_style='上限'", connect);
                this.up.Text = cmd.ExecuteScalar().ToString().Trim();
                cmd = new SqlCommand("select updown_count from book_updown where updown_style='下限'", connect);
                this.down.Text = cmd.ExecuteScalar().ToString().Trim();
                connect.Close();
            }
            else
            {
                MessageBox.Show("您还没有进行系统上下限设置，系统自动设置为0值！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.up.Text = "0";
                this.down.Text = "0";
                this.DefaultConfig();
            }
        }

        private void button1_Click(object sender, EventArgs e)//设置上下限
        {
            if (this.up.Text.Trim() != "" && this.down.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("SetUpDown", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@up", int.Parse(this.up.Text.Trim()));
                cmd.Parameters.AddWithValue("@down", int.Parse(this.down.Text.Trim()));
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("修改成功！","恭喜",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("商品上限和下限不能为空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// 是否设置了系统的上下限
        /// </summary>
        /// <returns>返回true表示设置了，否则表示没有设置</returns>
        private bool IsConfig()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from book_updown",connect);
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
            SqlCommand cmd = new SqlCommand("insert into book_updown(updown_style,updown_count) values('上限',0)", connect);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into book_updown(updown_style,updown_count) values('下限',0)",connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
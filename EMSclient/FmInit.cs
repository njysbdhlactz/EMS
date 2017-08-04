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
    public partial class FmInit : Form
    {
        public FmInit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//系统初始化
        {
            if (!this.checkBox1.Checked && !this.checkBox2.Checked && !this.checkBox3.Checked && !this.checkBox4.Checked)
            {
                MessageBox.Show("请选择要初始化的项后再进行系统初始化！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                if (MessageBox.Show("你确定进行系统初始化吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
                {
                    SqlConnection connect = InitConnect.GetConnection();
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (this.checkBox1.Checked)
                    {
                        cmd = new SqlCommand("ClearBaseData", connect);
                        cmd.ExecuteNonQuery();
                    }
                    if (this.checkBox2.Checked)
                    {
                        cmd = new SqlCommand("ClearConfigData", connect);
                        cmd.ExecuteNonQuery();
                    }
                    if (this.checkBox3.Checked)
                    {
                        cmd = new SqlCommand("ClearCurrencyData", connect);
                        cmd.ExecuteNonQuery();
                    }
                    if (this.checkBox4.Checked)
                    {
                        cmd = new SqlCommand("ClearBookAndDiscData", connect);
                        cmd.ExecuteNonQuery();
                    }
                    connect.Close();
                    MessageBox.Show("系统初始化成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
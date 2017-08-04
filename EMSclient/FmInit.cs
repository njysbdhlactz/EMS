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

        private void button2_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//ϵͳ��ʼ��
        {
            if (!this.checkBox1.Checked && !this.checkBox2.Checked && !this.checkBox3.Checked && !this.checkBox4.Checked)
            {
                MessageBox.Show("��ѡ��Ҫ��ʼ��������ٽ���ϵͳ��ʼ����","����",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                if (MessageBox.Show("��ȷ������ϵͳ��ʼ����", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
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
                    MessageBox.Show("ϵͳ��ʼ���ɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
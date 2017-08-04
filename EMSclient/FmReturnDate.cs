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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)//����ֻ����������
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//�޸�����
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
                MessageBox.Show("���óɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("�������˻�����ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.comboBox1.Focus();
                return;
            }
        }

        private void FrmReturnDate_Load(object sender, EventArgs e)//��ʼ��
        {
            this.GetReturnDate();
        }

        /// <summary>
        /// ��ȡ��ǰ�˻�������
        /// </summary>
        private void GetReturnDate()
        {
            if (this.IsConfig())
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select back_return_count from back_return where back_return_name='ͼ��'", connect);
                this.comboBox1.Text = cmd.ExecuteScalar().ToString().Trim();
                cmd = new SqlCommand("select back_return_count from back_return where back_return_name='����'", connect);
                this.comboBox2.Text = cmd.ExecuteScalar().ToString().Trim();
                connect.Close();
            }
            else
            {
                MessageBox.Show("����û�н����˻����޵����ã�ϵͳ�Զ�����Ϊ0ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.comboBox1.Text = "0";
                this.comboBox2.Text = "0";
                this.DefaultConfig();
            }
        }

        /// <summary>
        /// �˻������Ƿ��Ѿ�����
        /// </summary>
        /// <returns>true��ʾ�Ѿ����ã�false��ʾδ����</returns>
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
        /// Ĭ������
        /// </summary>
        private void DefaultConfig()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into back_return(back_return_name,back_return_count) values('����',0)", connect);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into back_return(back_return_name,back_return_count) values('ͼ��',0)", connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
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

        private void button2_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        private void up_KeyPress(object sender, KeyPressEventArgs e)//����ֻ����������
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void FrmUpdown_Load(object sender, EventArgs e)//��ʼ��
        {
            this.DisplayCurrent();
        }

        /// <summary>
        /// ��ȡ��ǰ����������
        /// </summary>
        private void DisplayCurrent()
        {
            if (this.IsConfig())
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("select updown_count from book_updown where updown_style='����'", connect);
                this.up.Text = cmd.ExecuteScalar().ToString().Trim();
                cmd = new SqlCommand("select updown_count from book_updown where updown_style='����'", connect);
                this.down.Text = cmd.ExecuteScalar().ToString().Trim();
                connect.Close();
            }
            else
            {
                MessageBox.Show("����û�н���ϵͳ���������ã�ϵͳ�Զ�����Ϊ0ֵ��", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.up.Text = "0";
                this.down.Text = "0";
                this.DefaultConfig();
            }
        }

        private void button1_Click(object sender, EventArgs e)//����������
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
                MessageBox.Show("�޸ĳɹ���","��ϲ",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
            {
                MessageBox.Show("��Ʒ���޺����޲���Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// �Ƿ�������ϵͳ��������
        /// </summary>
        /// <returns>����true��ʾ�����ˣ������ʾû������</returns>
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
        /// Ĭ������
        /// </summary>
        private void DefaultConfig()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("insert into book_updown(updown_style,updown_count) values('����',0)", connect);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("insert into book_updown(updown_style,updown_count) values('����',0)",connect);
            cmd.ExecuteNonQuery();
            connect.Close();
        }
    }
}
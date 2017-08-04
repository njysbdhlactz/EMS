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
    public partial class FmBookcase : Form
    {
        public FmBookcase()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private SqlDataAdapter bookcase = new SqlDataAdapter();
        private BindingSource source = new BindingSource();

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void InitData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            bookcase.SelectCommand = select;
            bookcase.SelectCommand.Connection = connect;
            bookcase.SelectCommand.CommandText = "select bookcase_place as ���λ�� from bookcase where 1=0";
            //////////////////////////////////////////////////////////
            bookcase.InsertCommand = insert;
            bookcase.InsertCommand.Connection = connect;
            bookcase.InsertCommand.CommandText = "insert into bookcase(bookcase_place) values(@place)";
            bookcase.InsertCommand.Parameters.Add("@place",SqlDbType.VarChar,0,"���λ��");
            //////////////////////////////////////////////////////////
            bookcase.DeleteCommand = delete;
            bookcase.DeleteCommand.Connection = connect;
            bookcase.DeleteCommand.CommandText = "delete bookcase where bookcase_place=@place";
            bookcase.DeleteCommand.Parameters.Add("@place",SqlDbType.VarChar,0,"���λ��");
            //////////////////////////////////////////////////////////
            bookcase.Fill(data,"bookcase");
            source.DataSource = data;
            source.DataMember = "bookcase";
            this.dataGridView1.DataSource = source;
            ///////////////////////////////////////////////////////////
            this.place.DataBindings.Add("Text",source,"���λ��",true);
        }

        private void FrmBookcase_Load(object sender, EventArgs e)//��DataGridView
        {
            this.InitData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//��һ��
        {
            source.MoveFirst();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//��һ��
        {
            source.MovePrevious();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//��һ��
        {
            source.MoveNext();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//���һ��
        {
            source.MoveLast();
        }

        private void ToolButtonEnabled(bool Flag)
        {
            if (Flag)
            {
                this.toolStripButton5.Enabled = false;
                this.toolStripButton7.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
                this.place.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                ///////////////////////////////////////
                this.place.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//���
        {
            this.ToolButtonEnabled(true);
            //////////////////////////////////////////////////////
            source.AddNew();
            this.place.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//ɾ��
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
                /////////////////////////////////////////////////////////////
                this.toolStripButton5.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
            }
            else
            {
                MessageBox.Show("û�п�ɾ���ļ�¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// ���ظ�ʽ����Ĵ�����Ϣ
        /// </summary>
        /// <param name="message">ϵͳ�Ĵ�����Ϣ</param>
        /// <returns>��ʽ����Ĵ�����Ϣ</returns>
        private string ErrorMessage(string message)
        {
            string result = message.Replace("bookcase", "��ܱ�");
            result = result.Replace("bookcase_key","��\"��ܱ��\"���ܴ�����ͬ��ֵ");
            result = result.Replace("bookcase_place", "���λ��");
            result = result.Replace("NULL", "\"��ֵ\"");
            result = result.Replace("INSERT", "���");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.place.Text.Trim() != ""||this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    bookcase.Update(data, "bookcase");
                    ///////////////////////////////////////////////////////
                    this.ToolButtonEnabled(false);
                }
                else
                {
                    if (!this.toolStripButton7.Enabled)
                    {
                        MessageBox.Show("��\"*\"��Ϊ������Ϣ������д������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("����"+this.ErrorMessage(ee.Message),"����",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)//ȡ��
        {
            source.CancelEdit();
            data.RejectChanges();
            //////////////////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        /// <summary>
        /// ��ʾ������Ϣ���ѯ��Ϣ
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ʾ������Ϣ��Ϊfalse��ʾ��ѯ��Ϣ</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            bookcase.SelectCommand.CommandText = "select bookcase_place as ���λ�� from bookcase";
            bookcase.Fill(data,"bookcase");
            source.DataSource = data;
            source.DataMember = "bookcase";
            if (!Flag)
            {
                source.Filter = "���λ�� like '%"+this.queryplace.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "���λ�� like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//��ѯ
        {
            this.DisplayAll(false);
        }

        private void button2_Click(object sender, EventArgs e)//��ʾȫ��
        {
            this.DisplayAll(true);
        }
    }
}
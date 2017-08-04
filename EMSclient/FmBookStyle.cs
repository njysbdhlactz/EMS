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
    public partial class FmBookStyle : Form
    {
        public FmBookStyle()
        {
            InitializeComponent();
        }

        private BindingSource source = new BindingSource();
        private SqlDataAdapter book_style = new SqlDataAdapter();
        private DataSet data = new DataSet();

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void InitData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand update = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            book_style.SelectCommand = select;
            book_style.SelectCommand.Connection = connect;
            book_style.SelectCommand.CommandText = "select bookstyle_name as ��Ʒ����,bookstyle_style as �������� from book_style where 1=0";
            //////////////////////////////////////////////////////////////////////////
            book_style.InsertCommand = insert;
            book_style.InsertCommand.Connection = connect;
            book_style.InsertCommand.CommandText = "insert into book_style(bookstyle_name,bookstyle_style) values(@name,@style)";
            book_style.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ʒ����");
            book_style.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��������");
            /////////////////////////////////////////////////////////////////////////////
            book_style.UpdateCommand = update;
            book_style.UpdateCommand.Connection = connect;
            book_style.UpdateCommand.CommandText = "update book_style set bookstyle_style=@style where bookstyle_name=@name";
            book_style.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ʒ����");
            book_style.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��������");
            ////////////////////////////////////////////////////////////////////////////////////
            book_style.DeleteCommand = delete;
            book_style.DeleteCommand.Connection = connect;
            book_style.DeleteCommand.CommandText = "delete book_style where bookstyle_name=@name";
            book_style.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ʒ����");
            //////////////////////////////////////////////////////////////////////////////
            book_style.Fill(data,"book_style");
            source.DataSource = data;
            source.DataMember = "book_style";
            this.dataGridView1.DataSource = source;
            ////////////////////////////////////////////////////////////////////
            this.style.DataBindings.Add("Text",source,"��Ʒ����",true);
            this.ware.DataBindings.Add("SelectedItem",source,"��������",true);
        }

        private void FrmBookStyle_Load(object sender, EventArgs e)//��ʼ��
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
                this.toolStripButton6.Enabled = false;
                this.toolStripButton7.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//���
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            this.style.Enabled = true;
            this.ware.Enabled = true;
            this.style.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//�޸�
        {
            if (source.Position != -1)
            {
                this.style.Enabled = false;
                this.ware.Enabled = true;
                this.ToolButtonEnabled(true);
                this.ware.Focus();
            }
            else
            {
                MessageBox.Show("û�п��޸ĵļ�¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//ɾ��
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
                this.toolStripButton5.Enabled = false;
                this.toolStripButton6.Enabled = false;
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
            string result = message.Replace("book_style_name","��\"��Ʒ����\"���ܴ�����ͬ��ֵ");
            result = result.Replace("book_style","��Ʒ���ͱ�");
            result = result.Replace("bookstyle_name","��Ʒ����");
            result = result.Replace("bookstyle_style","��������");
            result = result.Replace("NULL","\"��ֵ\"");
            result = result.Replace("INSERT","���");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.style.Text.Trim() != "" && this.ware.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    book_style.Update(data, "book_style");
                    /////////////////////////////////////////////////////////////////////
                    this.style.Enabled = false;
                    this.ware.Enabled = false;
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
            this.style.Enabled = false;
            this.ware.Enabled = false;
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        /// <summary>
        /// ��ʾ�������ݻ��ѯ����
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ʾ�������ݣ�Ϊfalse��ʾ��ѯ����</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            book_style.SelectCommand.CommandText = "select bookstyle_name as ��Ʒ����,bookstyle_style as �������� from book_style";
            book_style.Fill(data,"book_style");
            source.DataSource = data;
            source.DataMember = "book_style";
            if (!Flag)
            {
                source.Filter = "��Ʒ���� like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "��Ʒ���� like '%'";
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
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
    public partial class FmUser : Form
    {
        public FmUser()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private BindingSource source = new BindingSource();
        private SqlDataAdapter book_user = new SqlDataAdapter();

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
            book_user.SelectCommand = select;
            book_user.SelectCommand.Connection = connect;
            book_user.SelectCommand.CommandText = "select user_id as �û���,user_pwd as ����,user_name as ����,user_sex as �Ա�,user_tel as �绰,user_address as ��ַ,user_style as �û����� from book_user where 1=0";
            ///////////////////////////////////////////////////////////////
            book_user.InsertCommand = insert;
            book_user.InsertCommand.Connection = connect;
            book_user.InsertCommand.CommandText = "insert into book_user(user_id,user_pwd,user_name,user_sex,user_tel,user_address,user_style) values(@id,@pwd,@name,@sex,@tel,@address,@style)";
            book_user.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "�û���");
            book_user.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 0, "����");
            book_user.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "����");
            book_user.InsertCommand.Parameters.Add("@sex", SqlDbType.Char, 0, "�Ա�");
            book_user.InsertCommand.Parameters.Add("@tel", SqlDbType.VarChar, 0, "�绰");
            book_user.InsertCommand.Parameters.Add("@address", SqlDbType.VarChar, 0, "��ַ");
            book_user.InsertCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "�û�����");
            /////////////////////////////////////////////////////////////////
            book_user.UpdateCommand = update;
            book_user.UpdateCommand.Connection = connect;
            book_user.UpdateCommand.CommandText = "update book_user set user_pwd=@pwd,user_name=@name,user_sex=@sex,user_tel=@tel,user_address=@address,user_style=@style where user_id=@id";
            book_user.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "�û���");
            book_user.UpdateCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 0, "����");
            book_user.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "����");
            book_user.UpdateCommand.Parameters.Add("@sex", SqlDbType.Char, 0, "�Ա�");
            book_user.UpdateCommand.Parameters.Add("@tel", SqlDbType.VarChar, 0, "�绰");
            book_user.UpdateCommand.Parameters.Add("@address", SqlDbType.VarChar, 0, "��ַ");
            book_user.UpdateCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "�û�����");
            ///////////////////////////////////////////////////////////////////
            book_user.DeleteCommand = delete;
            book_user.DeleteCommand.Connection = connect;
            book_user.DeleteCommand.CommandText = "delete book_user where user_id=@id";
            book_user.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "�û���");
            ///////////////////////////////////////////////////////////////////
            book_user.Fill(data, "book_user");
            source.DataSource = data;
            source.DataMember = "book_user";
            this.dataGridView1.DataSource = source;
            //////////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text", source, "�û���", true);
            this.pwd.DataBindings.Add("Text", source, "����", true);
            this.name.DataBindings.Add("Text", source, "����", true);
            this.sex.DataBindings.Add("Text", source, "�Ա�", true);
            this.tel.DataBindings.Add("Text", source, "�绰", true);
            this.address.DataBindings.Add("Text", source, "��ַ", true);
            this.style.DataBindings.Add("SelectedValue", source, "�û�����", true);
            
        }

        private void FrmUser_Load(object sender, EventArgs e)//��DataGridView
        {
            this.BindUserStyle();
            ////////////////////////////////////////////////////////
            this.InitData();
        }

        /// <summary>
        /// ���û�����
        /// </summary>
        private void BindUserStyle()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from user_style", connect);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "user_style");
            this.style.DataSource = dataset.Tables["user_style"];
            this.style.DisplayMember = "userstyle_name";
            this.style.ValueMember = "userstyle_name";
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
                /////////////////////////////////////////////////////////////
                this.pwd.Enabled = true;
                this.name.Enabled = true;
                this.tel.Enabled = true;
                this.address.Enabled = true;
                this.sex.Enabled = true;
                this.style.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                /////////////////////////////////////////////////////////////
                this.id.Enabled = false;
                this.pwd.Enabled = false;
                this.name.Enabled = false;
                this.tel.Enabled = false;
                this.address.Enabled = false;
                this.sex.Enabled = false;
                this.style.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//���
        {
            source.AddNew();
            ////////////////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.id.Enabled = true;
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//�޸�
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                this.id.Enabled = false;
                this.pwd.Focus();
            }
            else
            {
                MessageBox.Show("û�п��޸ĵļ�¼��","����",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//ɾ��
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
                ////////////////////////////////////////////////////
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
            string result = message.Replace("book_user_key", "��\"�û���\"���ܴ�����ͬ��ֵ");
            result = result.Replace("user_id", "�û���");
            result = result.Replace("user_style","�û�����");
            result = result.Replace("book_user", "�û���");
            result = result.Replace("INSERT", "���");
            result = result.Replace("NULL", "\"��ֵ\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.id.Text.Trim() != "" && this.pwd.Text.Trim() != "" && this.style.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                   /* if (this.id.Enabled)
                    {
                        this.pwd.Text = MD5.MD5String(this.pwd.Text.Trim());
                    }*/
                    this.pwd.Text = MD5.MD5String(this.pwd.Text.Trim());
                    source.EndEdit();
                    book_user.Update(data, "book_user");
                    ///////////////////////////////////////////
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
            ////////////////////////////////////////////////////
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
            book_user.SelectCommand.CommandText = "select user_id as �û���,user_pwd as ����,user_name as ����,user_sex as �Ա�,user_tel as �绰,user_address as ��ַ,user_style as �û����� from book_user";
            book_user.Fill(data,"book_user");
            source.DataSource = data;
            source.DataMember = "book_user";
            if (!Flag)
            {
                source.Filter = "�û��� like '%"+this.queryid.Text.Trim()+"%' and isnull(����,'') like '%"+this.queryname.Text.Trim()+"%' and isnull(��ַ,'') like '%"+this.queryaddress.Text.Trim()+"%' and isnull(�绰,'') like '%"+this.querytel.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "�û��� like '%'";
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

        private void querytel_KeyPress(object sender, KeyPressEventArgs e)//����ֻ����������
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void style_DropDown(object sender, EventArgs e)
        {
            this.BindUserStyle();
        }
    }
}
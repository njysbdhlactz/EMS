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
    public partial class FmUserStyle : Form
    {
        public FmUserStyle()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private BindingSource source = new BindingSource();
        private SqlDataAdapter user_style = new SqlDataAdapter();

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void InitData()
        {
            SqlConnection connect=InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            user_style.SelectCommand = select;
            user_style.SelectCommand.Connection = connect;
            user_style.SelectCommand.CommandText = "select userstyle_name as �û����� from user_style where 1=0";
            ///////////////////////////////////////////////////////////////
            user_style.InsertCommand = insert;
            user_style.InsertCommand.Connection = connect;
            user_style.InsertCommand.CommandText = "insert into user_style(userstyle_name) values(@name)";
            user_style.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"�û�����");
            /////////////////////////////////////////////////////////////
            user_style.DeleteCommand = delete;
            user_style.DeleteCommand.Connection = connect;
            user_style.DeleteCommand.CommandText = "delete user_style where userstyle_name=@name";
            user_style.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"�û�����");
            /////////////////////////////////////////////////////////
            user_style.Fill(data,"user_style");
            source.DataSource = data;
            source.DataMember = "user_style";
            this.dataGridView1.DataSource = source;
            ////////////////////////////////////////////////////////////
            this.style.DataBindings.Add("Text",source,"�û�����",true);
        }

        private void FrmUserStyle_Load(object sender, EventArgs e)
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
            }
            else
            {

                this.toolStripButton5.Enabled = true;
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
            this.style.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//ɾ��
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
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
            string result = message.Replace("key_user_style", "��\"�û�����\"���ܴ�����ͬ��ֵ");
            result = result.Replace("user_style","�û����ͱ�");
            result = result.Replace("userstyle_name","�û�����");
            result = result.Replace("PRIMARY KEY","����Լ��");
            result = result.Replace("INSERT","���");
            result = result.Replace("NULL","\"��ֵ\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.style.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    user_style.Update(data, "user_style");
                    ////////////////////////////////////////////////////////////////////
                    this.style.Enabled = false;
                    this.ToolButtonEnabled(false);
                }
                else
                {
                    if (!this.toolStripButton7.Enabled)
                    {
                        MessageBox.Show("��\"*\"��Ϊ������Ϣ������д������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        this.style.Focus();
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
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        /// <summary>
        /// ��ʾȫ����Ϣ���ѯ��Ϣ
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ʾȫ����Ϣ��Ϊfalse��ʾ��ѯ��Ϣ</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            user_style.SelectCommand.CommandText = "select userstyle_name as �û����� from user_style";
            user_style.Fill(data,"user_style");
            source.DataSource = data;
            source.DataMember = "user_style";
            if (!Flag)
            {
                source.Filter = "�û����� like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "�û����� like '%'";
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
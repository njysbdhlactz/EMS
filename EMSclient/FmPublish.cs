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
    public partial class FmPublish : Form
    {
        public FmPublish()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private SqlDataAdapter publish = new SqlDataAdapter();
        private BindingSource source = new BindingSource();

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
            publish.SelectCommand = select;
            publish.SelectCommand.Connection = connect;
            publish.SelectCommand.CommandText = "select publish_name as ����������,publish_style as �������� from publish where 1=0";
            ////////////////////////////////////////////////////////////////
            publish.InsertCommand = insert;
            publish.InsertCommand.Connection = connect;
            publish.InsertCommand.CommandText = "insert into publish(publish_name,publish_style) values(@name,@style)";
            publish.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"����������");
            publish.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��������");
            ///////////////////////////////////////////////////////////////
            publish.UpdateCommand = update;
            publish.UpdateCommand.Connection = connect;
            publish.UpdateCommand.CommandText = "update publish set publish_style=@style where publish_name=@name";
            publish.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"����������");
            publish.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��������");
            /////////////////////////////////////////////////////////////
            publish.DeleteCommand = delete;
            publish.DeleteCommand.Connection = connect;
            publish.DeleteCommand.CommandText = "delete publish where publish_name=@name";
            publish.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"����������");
            ///////////////////////////////////////////////////////////////
            publish.Fill(data,"publish");
            source.DataSource = data;
            source.DataMember = "publish";
            this.dataGridView1.DataSource = source;
            /////////////////////////////////////////////////////////////
            this.publishname.DataBindings.Add("Text",source,"����������",true);
            this.ware.DataBindings.Add("SelectedItem",source,"��������",true);
        }

        private void FrmPulish_Load(object sender, EventArgs e)//��DataGridView
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
            ////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.publishname.Enabled = true;
            this.ware.Enabled = true;
            this.publishname.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//�޸�
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                this.publishname.Enabled = false;
                this.ware.Enabled = true;
                this.ware.Focus();
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
            string result = message.Replace("publish_key","��\"����������\"���ܴ�����ͬ��ֵ");
            result = result.Replace("publish_name","����������");
            result = result.Replace("publish_style","��������");
            result = result.Replace("publish","�������");
            result = result.Replace("NULL","\"��ֵ\"");
            result = result.Replace("INSERT","���");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.publishname.Text.Trim() != "" && this.ware.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    publish.Update(data, "publish");
                    //////////////////////////////////////////////////////////////////////////
                    this.ToolButtonEnabled(false);
                    this.publishname.Enabled = false;
                    this.ware.Enabled = false;
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
            this.ToolButtonEnabled(false);
            this.publishname.Enabled = false;
            this.ware.Enabled = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        /// <summary>
        /// ��ʾ�������ݻ��ѯ����
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ʾ������Ϣ��Ϊfalse��ʾ��ѯ��Ϣ</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            publish.SelectCommand.CommandText = "select publish_name as ����������,publish_style as �������� from publish";
            publish.Fill(data,"publish");
            source.DataSource = data;
            source.DataMember = "publish";
            if (!Flag)
            {
                source.Filter = "���������� like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "���������� like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//��ѯ
        {
            this.DisplayAll(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DisplayAll(true);
        }
    }
}
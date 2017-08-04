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
    public partial class FmProvider : Form
    {
        public FmProvider()
        {
            InitializeComponent();
        }
        private DataSet data = new DataSet();
        private SqlDataAdapter provider = new SqlDataAdapter();
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
            provider.SelectCommand = select;
            provider.SelectCommand.Connection = connect;
            provider.SelectCommand.CommandText = "select provider_id as ��Ӧ�̺�,provider_name as ��Ӧ������,provider_address as ��ַ,provider_post as ��������,provider_tel as �绰,provider_fax as ���� from provider where 1=0";
            ////////////////////////////////////////////////////////////////////
            provider.InsertCommand = insert;
            provider.InsertCommand.Connection = connect;
            provider.InsertCommand.CommandText = "insert into provider(provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax) values(@id,@name,@address,@post,@tel,@fax)";
            provider.InsertCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ӧ�̺�");
            provider.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ӧ������");
            provider.InsertCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"��ַ");
            provider.InsertCommand.Parameters.Add("@post",SqlDbType.Char,0,"��������");
            provider.InsertCommand.Parameters.Add("@tel",SqlDbType.Char,0,"�绰");
            provider.InsertCommand.Parameters.Add("@fax",SqlDbType.Char,0,"����");
            ////////////////////////////////////////////////////////////////////
            provider.UpdateCommand = update;
            provider.UpdateCommand.Connection = connect;
            provider.UpdateCommand.CommandText = "update provider set provider_name=@name,provider_address=@address,provider_post=@post,provider_tel=@tel,provider_fax=@fax where provider_id=@id";
            provider.UpdateCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ӧ�̺�");
            provider.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ӧ������");
            provider.UpdateCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"��ַ");
            provider.UpdateCommand.Parameters.Add("@post",SqlDbType.Char,0,"��������");
            provider.UpdateCommand.Parameters.Add("@tel",SqlDbType.Char,0,"�绰");
            provider.UpdateCommand.Parameters.Add("@fax",SqlDbType.Char,0,"����");
            ////////////////////////////////////////////////////////////////////////
            provider.DeleteCommand = delete;
            provider.DeleteCommand.Connection = connect;
            provider.DeleteCommand.CommandText = "delete provider where provider_id=@id";
            provider.DeleteCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ӧ�̺�");
            ////////////////////////////////////////////////////////////////////////////////
            provider.Fill(data,"provider");
            source.DataSource = data;
            source.DataMember = "provider";
            this.dataGridView1.DataSource = source;
            ///////////////////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text",source,"��Ӧ�̺�",true);
            this.name.DataBindings.Add("Text",source,"��Ӧ������",true);
            this.address.DataBindings.Add("Text",source,"��ַ",true);
            this.post.DataBindings.Add("Text",source,"��������",true);
            this.tel.DataBindings.Add("Text",source,"�绰",true);
            this.fax.DataBindings.Add("Text",source,"����",true);
        }

        private void FrmProvider_Load(object sender, EventArgs e)//��DataGridView
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
                ////////////////////////////////////////////////////////////
                this.name.Enabled = true;
                this.address.Enabled = true;
                this.post.Enabled = true;
                this.tel.Enabled = true;
                this.fax.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                ////////////////////////////////////////////////////////////
                this.id.Enabled = false;
                this.name.Enabled = false;
                this.address.Enabled = false;
                this.post.Enabled = false;
                this.tel.Enabled = false;
                this.fax.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//���
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            this.id.Enabled = true;
            ///////////////////////////////////////////////////////
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//�޸�
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                this.id.Enabled = false;
                ///////////////////////////////////////////////////
                this.name.Focus();
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
                MessageBox.Show("û�п��޸ĵļ�¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
            string result = message.Replace("provider_key","��\"��Ӧ�̺�\"���ܴ�����ͬ��ֵ");
            result = result.Replace("provider_id","��Ӧ�̺�");
            result = result.Replace("provider","��Ӧ�̱�");
            result = result.Replace("NULL","\"��ֵ\"");
            result = result.Replace("INSERT","���");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                source.EndEdit();
                provider.Update(data, "provider");
                ////////////////////////////////////////////////////////
                this.ToolButtonEnabled(false);
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
            ////////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        /// <summary>
        /// ��ʾ������Ϣ���ѯ��Ϣ
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ʾ������Ϣ��Ϊfalse��ʾ��ѯ��Ϣ</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            provider.SelectCommand.CommandText = "select provider_id as ��Ӧ�̺�,provider_name as ��Ӧ������,provider_address as ��ַ,provider_post as ��������,provider_tel as �绰,provider_fax as ���� from provider";
            provider.Fill(data,"provider");
            source.DataSource = data;
            source.DataMember = "provider";
            if (!Flag)
            {
                source.Filter = "isnull(��Ӧ�̺�,'') like '%" + this.queryid.Text.Trim() + "%' and isnull(��Ӧ������,'') like '%" + this.queryname.Text.Trim() + "%' and isnull(��ַ,'') like '%" + this.queryaddress.Text.Trim() + "%' and isnull(��������,'') like '%" + this.querypost.Text.Trim() + "%' and isnull(�绰,'') like '%" + this.querytel.Text.Trim() + "%' and isnull(����,'') like '%" + this.queryfax.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "isnull(��Ӧ�̺�,'') like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//��ѯ
        {
            this.DisplayAll(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//��ʾȫ��
        {
            this.DisplayAll(true);
        }

        private void querypost_KeyPress(object sender, KeyPressEventArgs e)//ֻ����������
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
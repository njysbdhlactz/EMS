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
    public partial class FmVip : Form
    {
        public FmVip()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private SqlDataAdapter vip = new SqlDataAdapter();
        private BindingSource source = new BindingSource();

        private void InitData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand update = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            vip.SelectCommand = select;
            vip.SelectCommand.Connection = connect;
            vip.SelectCommand.CommandText = "select vip_id as ��Ա��,vip_name as ��Ա����,vip_sex as �Ա�,vip_tel as �绰,vip_address as ��ַ,vip_identity as ���֤��,vip_style as ��Ա����,vip_date as ����ʱ�� from vip where 1=0";
            /////////////////////////////////////////////////////////
            vip.InsertCommand = insert;
            vip.InsertCommand.Connection = connect;
            vip.InsertCommand.CommandText = "insert into vip(vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date) values(@id,@name,@sex,@tel,@address,@identity,@style,@date)";
            vip.InsertCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ա��");
            vip.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ա����");
            vip.InsertCommand.Parameters.Add("@sex",SqlDbType.Char,0,"�Ա�");
            vip.InsertCommand.Parameters.Add("@tel",SqlDbType.VarChar,0,"�绰");
            vip.InsertCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"��ַ");
            vip.InsertCommand.Parameters.Add("@identity",SqlDbType.Char,0,"���֤��");
            vip.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��Ա����");
            vip.InsertCommand.Parameters.Add("@date",SqlDbType.DateTime,0,"����ʱ��");
            //////////////////////////////////////////////////////////
            vip.UpdateCommand = update;
            vip.UpdateCommand.Connection = connect;
            vip.UpdateCommand.CommandText = "update vip set vip_name=@name,vip_sex=@sex,vip_tel=@tel,vip_address=@address,vip_identity=@identity,vip_style=@style,vip_date=@date where vip_id=@id";
            vip.UpdateCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ա��");
            vip.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"��Ա����");
            vip.UpdateCommand.Parameters.Add("@sex",SqlDbType.Char,0,"�Ա�");
            vip.UpdateCommand.Parameters.Add("@tel",SqlDbType.VarChar,0,"�绰");
            vip.UpdateCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"��ַ");
            vip.UpdateCommand.Parameters.Add("@identity",SqlDbType.Char,0,"���֤��");
            vip.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"��Ա����");
            vip.UpdateCommand.Parameters.Add("@date",SqlDbType.DateTime,0,"����ʱ��");
            ///////////////////////////////////////////////////
            vip.DeleteCommand = delete;
            vip.DeleteCommand.Connection = connect;
            vip.DeleteCommand.CommandText = "delete vip where vip_id=@id";
            vip.DeleteCommand.Parameters.Add("@id",SqlDbType.Char,0,"��Ա��");
            //////////////////////////////////////////////////////////////
            vip.Fill(data,"vip");
            source.DataSource = data;
            source.DataMember = "vip";
            this.dataGridView1.DataSource = source;
            /////////////////////////////////////////////
            this.id.DataBindings.Add("Text",source,"��Ա��",true);
            this.name.DataBindings.Add("Text",source,"��Ա����",true);
            this.sex.DataBindings.Add("Text",source,"�Ա�",true);
            this.tel.DataBindings.Add("Text",source,"�绰",true);
            this.address.DataBindings.Add("Text",source,"��ַ",true);
            this.identity.DataBindings.Add("Text",source,"���֤��",true);
            this.style.DataBindings.Add("SelectedValue",source,"��Ա����",true);
            this.date.DataBindings.Add("Value",source,"����ʱ��",true);
        }

        private void FrmVip_Load(object sender, EventArgs e)//��DataGridView
        {
            this.BindVipStyle();
            ///////////////////////////////////////////////////////////
            this.InitData();
        }

        /// <summary>
        /// �󶨻�Ա����
        /// </summary>
        private void BindVipStyle()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from vip_style", connect);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "vip_style");
            this.style.DataSource = dataset.Tables["vip_style"];
            this.style.DisplayMember = "vipstyle_name";
            this.style.ValueMember = "vipstyle_name";
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
                ////////////////////////////////////////////////////////
                this.name.Enabled = true;
                this.sex.Enabled = true;
                this.tel.Enabled = true;
                this.address.Enabled = true;
                this.identity.Enabled = true;
                this.style.Enabled = true;
                this.date.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                ////////////////////////////////////////////////////////
                this.id.Enabled = false;
                this.name.Enabled = false;
                this.sex.Enabled = false;
                this.tel.Enabled = false;
                this.address.Enabled = false;
                this.identity.Enabled = false;
                this.style.Enabled = false;
                this.date.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//���
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            //////////////////////////////////////////////////////
            this.id.Enabled = true;
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//�޸�
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                //////////////////////////////////////////////////
                this.id.Enabled = false;
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
                //////////////////////////////////////////////////////
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
            string result = message.Replace("vip_key", "��\"��Ա��\"���ܴ�����ͬ��ֵ");
            result = result.Replace("vip_id", "��Ա��");
            result = result.Replace("vip_style", "��Ա����");
            result = result.Replace("vip_date", "��Ա����ʱ��");
            result = result.Replace("vip", "��Ա��");
            result = result.Replace("INSERT", "���");
            result = result.Replace("NULL", "\"��ֵ\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//����
        {
            try
            {
                if (this.id.Text.Trim() != "" && this.style.Text.Trim() != "" && this.date.Value != null || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    vip.Update(data, "vip");
                    ////////////////////////////////////////////////////////////////////////////////////
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
            //////////////////////////////////////////////////////
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
            vip.SelectCommand.CommandText = "select vip_id as ��Ա��,vip_name as ��Ա����,vip_sex as �Ա�,vip_tel as �绰,vip_address as ��ַ,vip_identity as ���֤��,vip_style as ��Ա����,vip_date as ����ʱ�� from vip";
            vip.Fill(data,"vip");
            source.DataSource = data;
            source.DataMember = "vip";
            if (!Flag)
            {
                source.Filter = "��Ա�� like '%"+this.queryid.Text.Trim()+"%' and isnull(��Ա����,'') like '%"+this.queryname.Text.Trim()+"%' and isnull(��ַ,'') like '%"+this.queryaddress.Text.Trim()+"%' and isnull(�绰,'') like '%"+this.querytel.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "��Ա�� like '%'";
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
            this.BindVipStyle();
        }

     
    }
}
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
        /// 初始化数据
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
            provider.SelectCommand.CommandText = "select provider_id as 供应商号,provider_name as 供应商名称,provider_address as 地址,provider_post as 邮政编码,provider_tel as 电话,provider_fax as 传真 from provider where 1=0";
            ////////////////////////////////////////////////////////////////////
            provider.InsertCommand = insert;
            provider.InsertCommand.Connection = connect;
            provider.InsertCommand.CommandText = "insert into provider(provider_id,provider_name,provider_address,provider_post,provider_tel,provider_fax) values(@id,@name,@address,@post,@tel,@fax)";
            provider.InsertCommand.Parameters.Add("@id",SqlDbType.Char,0,"供应商号");
            provider.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"供应商名称");
            provider.InsertCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"地址");
            provider.InsertCommand.Parameters.Add("@post",SqlDbType.Char,0,"邮政编码");
            provider.InsertCommand.Parameters.Add("@tel",SqlDbType.Char,0,"电话");
            provider.InsertCommand.Parameters.Add("@fax",SqlDbType.Char,0,"传真");
            ////////////////////////////////////////////////////////////////////
            provider.UpdateCommand = update;
            provider.UpdateCommand.Connection = connect;
            provider.UpdateCommand.CommandText = "update provider set provider_name=@name,provider_address=@address,provider_post=@post,provider_tel=@tel,provider_fax=@fax where provider_id=@id";
            provider.UpdateCommand.Parameters.Add("@id",SqlDbType.Char,0,"供应商号");
            provider.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"供应商名称");
            provider.UpdateCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"地址");
            provider.UpdateCommand.Parameters.Add("@post",SqlDbType.Char,0,"邮政编码");
            provider.UpdateCommand.Parameters.Add("@tel",SqlDbType.Char,0,"电话");
            provider.UpdateCommand.Parameters.Add("@fax",SqlDbType.Char,0,"传真");
            ////////////////////////////////////////////////////////////////////////
            provider.DeleteCommand = delete;
            provider.DeleteCommand.Connection = connect;
            provider.DeleteCommand.CommandText = "delete provider where provider_id=@id";
            provider.DeleteCommand.Parameters.Add("@id",SqlDbType.Char,0,"供应商号");
            ////////////////////////////////////////////////////////////////////////////////
            provider.Fill(data,"provider");
            source.DataSource = data;
            source.DataMember = "provider";
            this.dataGridView1.DataSource = source;
            ///////////////////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text",source,"供应商号",true);
            this.name.DataBindings.Add("Text",source,"供应商名称",true);
            this.address.DataBindings.Add("Text",source,"地址",true);
            this.post.DataBindings.Add("Text",source,"邮政编码",true);
            this.tel.DataBindings.Add("Text",source,"电话",true);
            this.fax.DataBindings.Add("Text",source,"传真",true);
        }

        private void FrmProvider_Load(object sender, EventArgs e)//绑定DataGridView
        {
            this.InitData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//第一条
        {
            source.MoveFirst();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//上一条
        {
            source.MovePrevious();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//下一条
        {
            source.MoveNext();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//最后一条
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

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            this.id.Enabled = true;
            ///////////////////////////////////////////////////////
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
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
                MessageBox.Show("没有可修改的记录！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
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
                MessageBox.Show("没有可修改的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// 返回格式化后的错误信息
        /// </summary>
        /// <param name="message">系统的错误信息</param>
        /// <returns>格式化后的错误信息</returns>
        private string ErrorMessage(string message)
        {
            string result = message.Replace("provider_key","列\"供应商号\"不能存在相同的值");
            result = result.Replace("provider_id","供应商号");
            result = result.Replace("provider","供应商表");
            result = result.Replace("NULL","\"空值\"");
            result = result.Replace("INSERT","添加");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
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
                MessageBox.Show("错误："+this.ErrorMessage(ee.Message),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)//取消
        {
            source.CancelEdit();
            data.RejectChanges();
            ////////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        /// <summary>
        /// 显示所有信息或查询信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有信息，为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            provider.SelectCommand.CommandText = "select provider_id as 供应商号,provider_name as 供应商名称,provider_address as 地址,provider_post as 邮政编码,provider_tel as 电话,provider_fax as 传真 from provider";
            provider.Fill(data,"provider");
            source.DataSource = data;
            source.DataMember = "provider";
            if (!Flag)
            {
                source.Filter = "isnull(供应商号,'') like '%" + this.queryid.Text.Trim() + "%' and isnull(供应商名称,'') like '%" + this.queryname.Text.Trim() + "%' and isnull(地址,'') like '%" + this.queryaddress.Text.Trim() + "%' and isnull(邮政编码,'') like '%" + this.querypost.Text.Trim() + "%' and isnull(电话,'') like '%" + this.querytel.Text.Trim() + "%' and isnull(传真,'') like '%" + this.queryfax.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "isnull(供应商号,'') like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            this.DisplayAll(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//显示全部
        {
            this.DisplayAll(true);
        }

        private void querypost_KeyPress(object sender, KeyPressEventArgs e)//只能输入数字
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
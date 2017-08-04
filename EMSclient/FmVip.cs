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
            vip.SelectCommand.CommandText = "select vip_id as 会员号,vip_name as 会员姓名,vip_sex as 性别,vip_tel as 电话,vip_address as 地址,vip_identity as 身份证号,vip_style as 会员类型,vip_date as 办理时间 from vip where 1=0";
            /////////////////////////////////////////////////////////
            vip.InsertCommand = insert;
            vip.InsertCommand.Connection = connect;
            vip.InsertCommand.CommandText = "insert into vip(vip_id,vip_name,vip_sex,vip_tel,vip_address,vip_identity,vip_style,vip_date) values(@id,@name,@sex,@tel,@address,@identity,@style,@date)";
            vip.InsertCommand.Parameters.Add("@id",SqlDbType.Char,0,"会员号");
            vip.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"会员姓名");
            vip.InsertCommand.Parameters.Add("@sex",SqlDbType.Char,0,"性别");
            vip.InsertCommand.Parameters.Add("@tel",SqlDbType.VarChar,0,"电话");
            vip.InsertCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"地址");
            vip.InsertCommand.Parameters.Add("@identity",SqlDbType.Char,0,"身份证号");
            vip.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"会员类型");
            vip.InsertCommand.Parameters.Add("@date",SqlDbType.DateTime,0,"办理时间");
            //////////////////////////////////////////////////////////
            vip.UpdateCommand = update;
            vip.UpdateCommand.Connection = connect;
            vip.UpdateCommand.CommandText = "update vip set vip_name=@name,vip_sex=@sex,vip_tel=@tel,vip_address=@address,vip_identity=@identity,vip_style=@style,vip_date=@date where vip_id=@id";
            vip.UpdateCommand.Parameters.Add("@id",SqlDbType.Char,0,"会员号");
            vip.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"会员姓名");
            vip.UpdateCommand.Parameters.Add("@sex",SqlDbType.Char,0,"性别");
            vip.UpdateCommand.Parameters.Add("@tel",SqlDbType.VarChar,0,"电话");
            vip.UpdateCommand.Parameters.Add("@address",SqlDbType.VarChar,0,"地址");
            vip.UpdateCommand.Parameters.Add("@identity",SqlDbType.Char,0,"身份证号");
            vip.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"会员类型");
            vip.UpdateCommand.Parameters.Add("@date",SqlDbType.DateTime,0,"办理时间");
            ///////////////////////////////////////////////////
            vip.DeleteCommand = delete;
            vip.DeleteCommand.Connection = connect;
            vip.DeleteCommand.CommandText = "delete vip where vip_id=@id";
            vip.DeleteCommand.Parameters.Add("@id",SqlDbType.Char,0,"会员号");
            //////////////////////////////////////////////////////////////
            vip.Fill(data,"vip");
            source.DataSource = data;
            source.DataMember = "vip";
            this.dataGridView1.DataSource = source;
            /////////////////////////////////////////////
            this.id.DataBindings.Add("Text",source,"会员号",true);
            this.name.DataBindings.Add("Text",source,"会员姓名",true);
            this.sex.DataBindings.Add("Text",source,"性别",true);
            this.tel.DataBindings.Add("Text",source,"电话",true);
            this.address.DataBindings.Add("Text",source,"地址",true);
            this.identity.DataBindings.Add("Text",source,"身份证号",true);
            this.style.DataBindings.Add("SelectedValue",source,"会员类型",true);
            this.date.DataBindings.Add("Value",source,"办理时间",true);
        }

        private void FrmVip_Load(object sender, EventArgs e)//绑定DataGridView
        {
            this.BindVipStyle();
            ///////////////////////////////////////////////////////////
            this.InitData();
        }

        /// <summary>
        /// 绑定会员类型
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

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            //////////////////////////////////////////////////////
            this.id.Enabled = true;
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
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
                MessageBox.Show("没有可修改的记录！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
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
                MessageBox.Show("没有可删除的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
            string result = message.Replace("vip_key", "列\"会员号\"不能存在相同的值");
            result = result.Replace("vip_id", "会员号");
            result = result.Replace("vip_style", "会员类型");
            result = result.Replace("vip_date", "会员办理时间");
            result = result.Replace("vip", "会员表");
            result = result.Replace("INSERT", "添加");
            result = result.Replace("NULL", "\"空值\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
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
                        MessageBox.Show("带\"*\"的为必填信息，请填写完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
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
            //////////////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示所有信息或查询信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有信息，为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            vip.SelectCommand.CommandText = "select vip_id as 会员号,vip_name as 会员姓名,vip_sex as 性别,vip_tel as 电话,vip_address as 地址,vip_identity as 身份证号,vip_style as 会员类型,vip_date as 办理时间 from vip";
            vip.Fill(data,"vip");
            source.DataSource = data;
            source.DataMember = "vip";
            if (!Flag)
            {
                source.Filter = "会员号 like '%"+this.queryid.Text.Trim()+"%' and isnull(会员姓名,'') like '%"+this.queryname.Text.Trim()+"%' and isnull(地址,'') like '%"+this.queryaddress.Text.Trim()+"%' and isnull(电话,'') like '%"+this.querytel.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "会员号 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            this.DisplayAll(false);
        }

        private void button2_Click(object sender, EventArgs e)//显示全部
        {
            this.DisplayAll(true);
        }

        private void querytel_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
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
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
        /// 初始化数据
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
            publish.SelectCommand.CommandText = "select publish_name as 出版社名称,publish_style as 类型所属 from publish where 1=0";
            ////////////////////////////////////////////////////////////////
            publish.InsertCommand = insert;
            publish.InsertCommand.Connection = connect;
            publish.InsertCommand.CommandText = "insert into publish(publish_name,publish_style) values(@name,@style)";
            publish.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"出版社名称");
            publish.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"类型所属");
            ///////////////////////////////////////////////////////////////
            publish.UpdateCommand = update;
            publish.UpdateCommand.Connection = connect;
            publish.UpdateCommand.CommandText = "update publish set publish_style=@style where publish_name=@name";
            publish.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"出版社名称");
            publish.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"类型所属");
            /////////////////////////////////////////////////////////////
            publish.DeleteCommand = delete;
            publish.DeleteCommand.Connection = connect;
            publish.DeleteCommand.CommandText = "delete publish where publish_name=@name";
            publish.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"出版社名称");
            ///////////////////////////////////////////////////////////////
            publish.Fill(data,"publish");
            source.DataSource = data;
            source.DataMember = "publish";
            this.dataGridView1.DataSource = source;
            /////////////////////////////////////////////////////////////
            this.publishname.DataBindings.Add("Text",source,"出版社名称",true);
            this.ware.DataBindings.Add("SelectedItem",source,"类型所属",true);
        }

        private void FrmPulish_Load(object sender, EventArgs e)//绑定DataGridView
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

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            ////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.publishname.Enabled = true;
            this.ware.Enabled = true;
            this.publishname.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
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
            string result = message.Replace("publish_key","列\"出版社名称\"不能存在相同的值");
            result = result.Replace("publish_name","出版社名称");
            result = result.Replace("publish_style","类型所属");
            result = result.Replace("publish","出版社表");
            result = result.Replace("NULL","\"空值\"");
            result = result.Replace("INSERT","添加");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
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
            this.ToolButtonEnabled(false);
            this.publishname.Enabled = false;
            this.ware.Enabled = false;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示所有数据或查询数据
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有信息，为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            publish.SelectCommand.CommandText = "select publish_name as 出版社名称,publish_style as 类型所属 from publish";
            publish.Fill(data,"publish");
            source.DataSource = data;
            source.DataMember = "publish";
            if (!Flag)
            {
                source.Filter = "出版社名称 like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "出版社名称 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            this.DisplayAll(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DisplayAll(true);
        }
    }
}
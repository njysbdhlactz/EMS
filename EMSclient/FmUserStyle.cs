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
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            SqlConnection connect=InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            user_style.SelectCommand = select;
            user_style.SelectCommand.Connection = connect;
            user_style.SelectCommand.CommandText = "select userstyle_name as 用户类型 from user_style where 1=0";
            ///////////////////////////////////////////////////////////////
            user_style.InsertCommand = insert;
            user_style.InsertCommand.Connection = connect;
            user_style.InsertCommand.CommandText = "insert into user_style(userstyle_name) values(@name)";
            user_style.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"用户类型");
            /////////////////////////////////////////////////////////////
            user_style.DeleteCommand = delete;
            user_style.DeleteCommand.Connection = connect;
            user_style.DeleteCommand.CommandText = "delete user_style where userstyle_name=@name";
            user_style.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"用户类型");
            /////////////////////////////////////////////////////////
            user_style.Fill(data,"user_style");
            source.DataSource = data;
            source.DataMember = "user_style";
            this.dataGridView1.DataSource = source;
            ////////////////////////////////////////////////////////////
            this.style.DataBindings.Add("Text",source,"用户类型",true);
        }

        private void FrmUserStyle_Load(object sender, EventArgs e)
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

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            this.ToolButtonEnabled(true);
            this.style.Enabled = true;
            this.style.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
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
            string result = message.Replace("key_user_style", "列\"用户类型\"不能存在相同的值");
            result = result.Replace("user_style","用户类型表");
            result = result.Replace("userstyle_name","用户类型");
            result = result.Replace("PRIMARY KEY","主键约束");
            result = result.Replace("INSERT","添加");
            result = result.Replace("NULL","\"空值\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
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
                        MessageBox.Show("带\"*\"的为必填信息，请填写完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        this.style.Focus();
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
            this.style.Enabled = false;
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示全部信息或查询信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示全部信息，为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            user_style.SelectCommand.CommandText = "select userstyle_name as 用户类型 from user_style";
            user_style.Fill(data,"user_style");
            source.DataSource = data;
            source.DataMember = "user_style";
            if (!Flag)
            {
                source.Filter = "用户类型 like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "用户类型 like '%'";
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
    }
}
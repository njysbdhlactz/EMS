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
        /// 初始化数据
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
            book_user.SelectCommand.CommandText = "select user_id as 用户名,user_pwd as 密码,user_name as 姓名,user_sex as 性别,user_tel as 电话,user_address as 地址,user_style as 用户类型 from book_user where 1=0";
            ///////////////////////////////////////////////////////////////
            book_user.InsertCommand = insert;
            book_user.InsertCommand.Connection = connect;
            book_user.InsertCommand.CommandText = "insert into book_user(user_id,user_pwd,user_name,user_sex,user_tel,user_address,user_style) values(@id,@pwd,@name,@sex,@tel,@address,@style)";
            book_user.InsertCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "用户名");
            book_user.InsertCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 0, "密码");
            book_user.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "姓名");
            book_user.InsertCommand.Parameters.Add("@sex", SqlDbType.Char, 0, "性别");
            book_user.InsertCommand.Parameters.Add("@tel", SqlDbType.VarChar, 0, "电话");
            book_user.InsertCommand.Parameters.Add("@address", SqlDbType.VarChar, 0, "地址");
            book_user.InsertCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "用户类型");
            /////////////////////////////////////////////////////////////////
            book_user.UpdateCommand = update;
            book_user.UpdateCommand.Connection = connect;
            book_user.UpdateCommand.CommandText = "update book_user set user_pwd=@pwd,user_name=@name,user_sex=@sex,user_tel=@tel,user_address=@address,user_style=@style where user_id=@id";
            book_user.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "用户名");
            book_user.UpdateCommand.Parameters.Add("@pwd", SqlDbType.VarChar, 0, "密码");
            book_user.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "姓名");
            book_user.UpdateCommand.Parameters.Add("@sex", SqlDbType.Char, 0, "性别");
            book_user.UpdateCommand.Parameters.Add("@tel", SqlDbType.VarChar, 0, "电话");
            book_user.UpdateCommand.Parameters.Add("@address", SqlDbType.VarChar, 0, "地址");
            book_user.UpdateCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "用户类型");
            ///////////////////////////////////////////////////////////////////
            book_user.DeleteCommand = delete;
            book_user.DeleteCommand.Connection = connect;
            book_user.DeleteCommand.CommandText = "delete book_user where user_id=@id";
            book_user.DeleteCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "用户名");
            ///////////////////////////////////////////////////////////////////
            book_user.Fill(data, "book_user");
            source.DataSource = data;
            source.DataMember = "book_user";
            this.dataGridView1.DataSource = source;
            //////////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text", source, "用户名", true);
            this.pwd.DataBindings.Add("Text", source, "密码", true);
            this.name.DataBindings.Add("Text", source, "姓名", true);
            this.sex.DataBindings.Add("Text", source, "性别", true);
            this.tel.DataBindings.Add("Text", source, "电话", true);
            this.address.DataBindings.Add("Text", source, "地址", true);
            this.style.DataBindings.Add("SelectedValue", source, "用户类型", true);
            
        }

        private void FrmUser_Load(object sender, EventArgs e)//绑定DataGridView
        {
            this.BindUserStyle();
            ////////////////////////////////////////////////////////
            this.InitData();
        }

        /// <summary>
        /// 绑定用户类型
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

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            ////////////////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.id.Enabled = true;
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                this.id.Enabled = false;
                this.pwd.Focus();
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
                ////////////////////////////////////////////////////
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
            string result = message.Replace("book_user_key", "列\"用户名\"不能存在相同的值");
            result = result.Replace("user_id", "用户名");
            result = result.Replace("user_style","用户类型");
            result = result.Replace("book_user", "用户表");
            result = result.Replace("INSERT", "添加");
            result = result.Replace("NULL", "\"空值\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
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
            ////////////////////////////////////////////////////
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
            book_user.SelectCommand.CommandText = "select user_id as 用户名,user_pwd as 密码,user_name as 姓名,user_sex as 性别,user_tel as 电话,user_address as 地址,user_style as 用户类型 from book_user";
            book_user.Fill(data,"book_user");
            source.DataSource = data;
            source.DataMember = "book_user";
            if (!Flag)
            {
                source.Filter = "用户名 like '%"+this.queryid.Text.Trim()+"%' and isnull(姓名,'') like '%"+this.queryname.Text.Trim()+"%' and isnull(地址,'') like '%"+this.queryaddress.Text.Trim()+"%' and isnull(电话,'') like '%"+this.querytel.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "用户名 like '%'";
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
            this.BindUserStyle();
        }
    }
}
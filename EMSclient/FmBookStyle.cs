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
    public partial class FmBookStyle : Form
    {
        public FmBookStyle()
        {
            InitializeComponent();
        }

        private BindingSource source = new BindingSource();
        private SqlDataAdapter book_style = new SqlDataAdapter();
        private DataSet data = new DataSet();

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
            book_style.SelectCommand = select;
            book_style.SelectCommand.Connection = connect;
            book_style.SelectCommand.CommandText = "select bookstyle_name as 商品类型,bookstyle_style as 类型所属 from book_style where 1=0";
            //////////////////////////////////////////////////////////////////////////
            book_style.InsertCommand = insert;
            book_style.InsertCommand.Connection = connect;
            book_style.InsertCommand.CommandText = "insert into book_style(bookstyle_name,bookstyle_style) values(@name,@style)";
            book_style.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"商品类型");
            book_style.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"类型所属");
            /////////////////////////////////////////////////////////////////////////////
            book_style.UpdateCommand = update;
            book_style.UpdateCommand.Connection = connect;
            book_style.UpdateCommand.CommandText = "update book_style set bookstyle_style=@style where bookstyle_name=@name";
            book_style.UpdateCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"商品类型");
            book_style.UpdateCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"类型所属");
            ////////////////////////////////////////////////////////////////////////////////////
            book_style.DeleteCommand = delete;
            book_style.DeleteCommand.Connection = connect;
            book_style.DeleteCommand.CommandText = "delete book_style where bookstyle_name=@name";
            book_style.DeleteCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"商品类型");
            //////////////////////////////////////////////////////////////////////////////
            book_style.Fill(data,"book_style");
            source.DataSource = data;
            source.DataMember = "book_style";
            this.dataGridView1.DataSource = source;
            ////////////////////////////////////////////////////////////////////
            this.style.DataBindings.Add("Text",source,"商品类型",true);
            this.ware.DataBindings.Add("SelectedItem",source,"类型所属",true);
        }

        private void FrmBookStyle_Load(object sender, EventArgs e)//初始化
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
            this.ToolButtonEnabled(true);
            this.style.Enabled = true;
            this.ware.Enabled = true;
            this.style.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
        {
            if (source.Position != -1)
            {
                this.style.Enabled = false;
                this.ware.Enabled = true;
                this.ToolButtonEnabled(true);
                this.ware.Focus();
            }
            else
            {
                MessageBox.Show("没有可修改的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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
            string result = message.Replace("book_style_name","列\"商品类型\"不能存在相同的值");
            result = result.Replace("book_style","商品类型表");
            result = result.Replace("bookstyle_name","商品类型");
            result = result.Replace("bookstyle_style","类型所属");
            result = result.Replace("NULL","\"空值\"");
            result = result.Replace("INSERT","添加");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
        {
            try
            {
                if (this.style.Text.Trim() != "" && this.ware.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    book_style.Update(data, "book_style");
                    /////////////////////////////////////////////////////////////////////
                    this.style.Enabled = false;
                    this.ware.Enabled = false;
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
            this.style.Enabled = false;
            this.ware.Enabled = false;
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示所有数据或查询数据
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有数据，为false表示查询数据</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            book_style.SelectCommand.CommandText = "select bookstyle_name as 商品类型,bookstyle_style as 类型所属 from book_style";
            book_style.Fill(data,"book_style");
            source.DataSource = data;
            source.DataMember = "book_style";
            if (!Flag)
            {
                source.Filter = "商品类型 like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "商品类型 like '%'";
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
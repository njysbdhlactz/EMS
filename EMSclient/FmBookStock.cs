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
    public partial class FmBookStock : Form
    {
        public FmBookStock()
        {
            InitializeComponent();
        }

        SqlDataAdapter book_info = new SqlDataAdapter();
        DataSet data = new DataSet();
        BindingSource source = new BindingSource();

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
            book_info.SelectCommand = select;
            book_info.SelectCommand.Connection = connect;
            book_info.SelectCommand.CommandText = "SELECT book_id as 图书编号, book_code as 条形码, book_name as 图书名称, book_style as 图书类型, book_author as 作者, book_publish as 出版社, book_isbn as ISBN, book_inprice as 进价, book_outprice as 售价, book_page as 页码, book_bookcase as 书架, book_count as 库存量, book_date as 出版时间, book_in as 入库时间, book_memo as 图书简介, book_cd_case as 光盘所在书架 FROM book_info where 1=0";
            //////////////////////////////////////
            book_info.InsertCommand = insert;
            book_info.InsertCommand.Connection = connect;
            book_info.InsertCommand.CommandText = "insert into book_info(book_id,book_code,book_name,book_style,book_author,book_publish,book_isbn,book_inprice,book_outprice,book_page,book_bookcase,book_count,book_date,book_in,book_memo,book_cd_case) values(@id,@code,@name,@style,@author,@publish,@isbn,@inprice,@outprice,@page,@bookcase,@count,@date,@indate,@memo,@cdcase)";
            book_info.InsertCommand.Parameters.Add("@id",SqlDbType.VarChar,0,"图书编号");
            book_info.InsertCommand.Parameters.Add("@code", SqlDbType.VarChar, 0, "条形码");
            book_info.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "图书名称");
            book_info.InsertCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "图书类型");
            book_info.InsertCommand.Parameters.Add("@author", SqlDbType.VarChar, 0, "作者");
            book_info.InsertCommand.Parameters.Add("@publish", SqlDbType.VarChar, 0, "出版社");
            book_info.InsertCommand.Parameters.Add("@isbn", SqlDbType.VarChar, 0, "ISBN");
            book_info.InsertCommand.Parameters.Add("@inprice", SqlDbType.Decimal, 0, "进价");
            book_info.InsertCommand.Parameters.Add("@outprice", SqlDbType.Decimal, 0, "售价");
            book_info.InsertCommand.Parameters.Add("@page", SqlDbType.Int, 0, "页码");
            book_info.InsertCommand.Parameters.Add("@bookcase", SqlDbType.VarChar, 0, "书架");
            book_info.InsertCommand.Parameters.Add("@count", SqlDbType.Int, 0, "库存量");
            book_info.InsertCommand.Parameters.Add("@date", SqlDbType.DateTime, 0, "出版时间");
            book_info.InsertCommand.Parameters.Add("@indate", SqlDbType.DateTime, 0, "入库时间");
            book_info.InsertCommand.Parameters.Add("@memo", SqlDbType.VarChar, 0, "图书简介");
            book_info.InsertCommand.Parameters.Add("@cdcase", SqlDbType.VarChar, 0, "光盘所在书架");
            //////////////////////////////////////////////////////////////////////////////
            book_info.UpdateCommand = update;
            book_info.UpdateCommand.Connection = connect;
            book_info.UpdateCommand.CommandText = "update book_info set book_code=@code,book_name=@name,book_style=@style,book_author=@author,book_publish=@publish,book_isbn=@isbn,book_inprice=@inprice,book_outprice=@outprice,book_page=@page,book_bookcase=@bookcase,book_count=@count,book_date=@date,book_in=@indate,book_memo=@memo,book_cd_case=@cdcase where book_id=@id";
            book_info.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "图书编号");
            book_info.UpdateCommand.Parameters.Add("@code", SqlDbType.VarChar, 0, "条形码");
            book_info.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "图书名称");
            book_info.UpdateCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "图书类型");
            book_info.UpdateCommand.Parameters.Add("@author", SqlDbType.VarChar, 0, "作者");
            book_info.UpdateCommand.Parameters.Add("@publish", SqlDbType.VarChar, 0, "出版社");
            book_info.UpdateCommand.Parameters.Add("@isbn", SqlDbType.VarChar, 0, "ISBN");
            book_info.UpdateCommand.Parameters.Add("@inprice", SqlDbType.Decimal, 0, "进价");
            book_info.UpdateCommand.Parameters.Add("@outprice", SqlDbType.Decimal, 0, "售价");
            book_info.UpdateCommand.Parameters.Add("@page", SqlDbType.Int, 0, "页码");
            book_info.UpdateCommand.Parameters.Add("@bookcase", SqlDbType.VarChar, 0, "书架");
            book_info.UpdateCommand.Parameters.Add("@count", SqlDbType.Int, 0, "库存量");
            book_info.UpdateCommand.Parameters.Add("@date", SqlDbType.DateTime, 0, "出版时间");
            book_info.UpdateCommand.Parameters.Add("@indate", SqlDbType.DateTime, 0, "入库时间");
            book_info.UpdateCommand.Parameters.Add("@memo", SqlDbType.VarChar, 0, "图书简介");
            book_info.UpdateCommand.Parameters.Add("@cdcase", SqlDbType.VarChar, 0, "光盘所在书架");
            ////////////////////////////////////////////////////////////////////////
            book_info.DeleteCommand = delete;
            book_info.DeleteCommand.Connection = connect;
            book_info.DeleteCommand.CommandText = "delete book_info where book_id=@id";
            book_info.DeleteCommand.Parameters.Add("@id",SqlDbType.VarChar,0,"图书编号");
            ///////////////////////////////////////////////////////////////
            book_info.Fill(data,"book_info");
            source.DataSource = data;
            source.DataMember = "book_info";
            this.dataGridView1.DataSource = source;
            ////////////////////////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text", source, "图书编号", true);
            this.code.DataBindings.Add("Text", source, "条形码", true);
            this.name.DataBindings.Add("Text", source, "图书名称", true);
            this.style.DataBindings.Add("SelectedValue", source, "图书类型", true);
            this.author.DataBindings.Add("Text", source, "作者", true);
            this.publish.DataBindings.Add("Text", source, "出版社", true);
            this.isbn.DataBindings.Add("Text", source, "ISBN", true);
            this.inprice.DataBindings.Add("Text", source, "进价", true);
            this.outprice.DataBindings.Add("Text", source, "售价", true);
            this.page.DataBindings.Add("Text", source, "页码", true);
            this.bookcase.DataBindings.Add("SelectedValue", source, "书架", true);
            this.count.DataBindings.Add("Text", source, "库存量", true);
            this.date.DataBindings.Add("Value", source, "出版时间", true);
            this.indate.DataBindings.Add("Value", source, "入库时间", true);
            this.memo.DataBindings.Add("Text", source, "图书简介", true);
            this.cdcase.DataBindings.Add("SelectedValue", source, "光盘所在书架", true);
        }

        /// <summary>
        /// 绑定图书类型
        /// </summary>
        /// <param name="Flag">为true表示绑定querystyle,为false表示绑定style</param>
        private void BindStyle(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='图书'",connect);
            DataSet data = new DataSet();
            adapter.Fill(data,"book_style");
            if (Flag)
            {
                this.querystyle.DataSource = data.Tables["book_style"];
                this.querystyle.DisplayMember = "bookstyle_name";
                this.querystyle.ValueMember = "bookstyle_name";
            }
            else
            {
                this.style.DataSource = data.Tables["book_style"];
                this.style.DisplayMember = "bookstyle_name";
                this.style.ValueMember = "bookstyle_name";
            }
        }

        /// <summary>
        /// 绑定出版社
        /// </summary>
        /// <param name="Flag">为true表示绑定querypublish,为false表示绑定publish</param>
        private void BindPublish(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from publish where publish_style='图书'",connect);
            DataSet data = new DataSet();
            adapter.Fill(data,"publish");
            if (Flag)
            {
                this.querypublish.DataSource = data.Tables["publish"];
                this.querypublish.DisplayMember = "publish_name";
                this.querypublish.ValueMember = "publish_name";
            }
            else
            {
                this.publish.DataSource=data.Tables["publish"];
                this.publish.DisplayMember = "publish_name";
                this.publish.ValueMember = "publish_name";
            }
        }

        /// <summary>
        /// 绑定书架
        /// </summary>
        /// <param name="Flag">为1表示绑定querybookcase,为2表示绑定bookcase,为3表示绑定cdcase</param>
        private void BindBookcase(int Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase",connect);
            DataSet data = new DataSet();
            bookcase.Fill(data,"bookcase");
            if (Flag==1)
            {
                this.querybookcase.DataSource = data.Tables["bookcase"];
                this.querybookcase.DisplayMember = "bookcase_place";
                this.querybookcase.ValueMember = "bookcase_place";
            }
            else if (Flag == 2)
            {
                this.bookcase.DataSource = data.Tables["bookcase"];
                this.bookcase.DisplayMember = "bookcase_place";
                this.bookcase.ValueMember = "bookcase_place";
            }
            else
            {
                this.cdcase.DataSource = data.Tables["bookcase"];
                this.cdcase.DisplayMember = "bookcase_place";
                this.cdcase.ValueMember = "bookcase_place";
            }
        }

        private void querystyle_DropDown(object sender, EventArgs e)//绑定图书类型(查询)
        {
            this.BindStyle(true);
        }

        private void querypublish_DropDown(object sender, EventArgs e)//绑定出版社(查询)
        {
            this.BindPublish(true);
        }

        private void querybookcase_DropDown(object sender, EventArgs e)//绑定书架(查询)
        {
            this.BindBookcase(1);
        }

        private void publish_DropDown(object sender, EventArgs e)//绑定出版社
        {
            this.BindPublish(false);
        }

        private void style_DropDown(object sender, EventArgs e)//绑定图书类型
        {
            this.BindStyle(false);
        }

        private void bookcase_DropDown(object sender, EventArgs e)//绑定书架
        {
            this.BindBookcase(2);
        }

        private void FrmBookStock_Load(object sender, EventArgs e)//绑定图书信息
        {
            this.InitData();
            ////////////////////////////////////////////
            this.BindStyle(false);
            this.BindPublish(false);
            this.BindBookcase(2);
            this.BindBookcase(3);
        }

        /// <summary>
        /// 显示图书的全部信息及查询图书信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有，为false表示查询</param>
        private void QueryInfo(bool Flag)
        {
            data.Clear();
            book_info.SelectCommand.CommandText = "SELECT book_id as 图书编号, book_code as 条形码, book_name as 图书名称, book_style as 图书类型, book_author as 作者, book_publish as 出版社, book_isbn as ISBN, book_inprice as 进价, book_outprice as 售价, book_page as 页码, book_bookcase as 书架, book_count as 库存量, book_date as 出版时间, book_in as 入库时间, book_memo as 图书简介, book_cd_case as 光盘所在书架 FROM book_info";
            book_info.Fill(data, "book_info");
            source.DataSource = data;
            source.DataMember = "book_info";
            if (!Flag)
            {
                source.Filter = "图书编号 like '%" + this.queryid.Text.Trim() + "%' and isnull(条形码,'') like '%" + this.querycode.Text.Trim() + "%' and 图书名称 like '%" + this.queryname.Text.Trim() + "%' and 图书类型 like '%" + this.querystyle.Text.Trim() + "%' and isnull(作者,'') like '%" + this.queryauthor.Text.Trim() + "%' and 出版社 like '%" + this.querypublish.Text.Trim() + "%' and ISBN like '%" + this.queryisbn.Text.Trim() + "%' and isnull(书架,'') like '%" + this.querybookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "图书编号 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            this.QueryInfo(false);
        }

        private void button2_Click(object sender, EventArgs e)//显示全部
        {
            this.QueryInfo(true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)//是否附加光盘
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                if (this.dataGridView1.SelectedRows[0].Cells["光盘所在书架"].Value.ToString().Trim() == "")
                {
                    this.radioButton2.Checked = true;
                }
                else
                {
                    this.radioButton1.Checked = true;
                }
            }
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
                //////////////////////////////////////////////
                this.name.Enabled = true;
                this.style.Enabled = true;
                this.author.Enabled = true;
                this.publish.Enabled = true;
                this.isbn.Enabled = true;
                this.inprice.Enabled = true;
                this.outprice.Enabled = true;
                this.page.Enabled = true;
                this.bookcase.Enabled = true;
                this.count.Enabled = true;
                this.date.Enabled = true;
                this.indate.Enabled = true;
                this.memo.Enabled = true;
                this.radioButton1.Enabled = true;
                this.radioButton2.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                //////////////////////////////////////////////
                this.id.Enabled = false;
                this.code.Enabled = false;
                this.name.Enabled = false;
                this.style.Enabled = false;
                this.author.Enabled = false;
                this.publish.Enabled = false;
                this.isbn.Enabled = false;
                this.inprice.Enabled = false;
                this.outprice.Enabled = false;
                this.page.Enabled = false;
                this.bookcase.Enabled = false;
                this.count.Enabled = false;
                this.date.Enabled = false;
                this.indate.Enabled = false;
                this.memo.Enabled = false;
                this.radioButton1.Enabled = false;
                this.radioButton2.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            ///////////////////////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.id.Enabled = true;
            this.code.Enabled = true;
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
        {
            if (source.Position != -1)
            {
                this.ToolButtonEnabled(true);
                ///////////////////////////////////////////////////////
                this.id.Enabled = false;
                this.code.Enabled = false;
                this.name.Focus();
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
                this.toolStripButton5.Enabled = false;
                this.toolStripButton6.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
                ///////////////////////////////////////////
                source.RemoveAt(source.Position);
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
            string result = message.Replace("book_info_key", "列\"图书编号\"不能存在相同的值");
            result = result.Replace("book_code_key", "列\"图书条形码\"不能存在相同的值");
            result = result.Replace("checkbookprice","\"售价\"不能大于\"进价\"");
            result = result.Replace("book_id", "图书编号");
            result = result.Replace("book_code", "图书条形码");
            result = result.Replace("book_name", "图书名称");
            result = result.Replace("book_style", "图书类型");
            result = result.Replace("book_isbn", "ISBN");
            result = result.Replace("book_inprice", "进价");
            result = result.Replace("book_outprice", "售价");
            result = result.Replace("book_count", "库存量");
            result = result.Replace("book_info", "图书表");
            result = result.Replace("NULL", "\"空值\"");
            result = result.Replace("INSERT", "添加");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
        {
            try
            {
                if (this.id.Text.Trim() != "" && this.code.Text.Trim() != "" && this.style.Text.Trim() != "" && this.name.Text.Trim() != "" && this.isbn.Text.Trim() != "" && this.inprice.Text.Trim() != "" && this.outprice.Text.Trim() != "" && this.count.Text.Trim() != ""||this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    book_info.Update(data, "book_info");
                    ///////////////////////////////////////////////
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
            catch(Exception ee)
            {
                MessageBox.Show("错误："+this.ErrorMessage(ee.Message),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                this.id.Focus();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)//取消
        {
            source.CancelEdit();
            data.RejectChanges();
            ////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void outprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != '.')
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)
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
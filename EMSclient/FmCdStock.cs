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
    public partial class FmCdStock : Form
    {
        public FmCdStock()
        {
            InitializeComponent();
        }

        private SqlDataAdapter cd_info = new SqlDataAdapter();
        private DataSet data = new DataSet();
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
            cd_info.SelectCommand = select;
            cd_info.SelectCommand.Connection = connect;
            cd_info.SelectCommand.CommandText = "select cd_id as 光盘编号,cd_code as 条形码,cd_name as 光盘名称,cd_style as 光盘类型,cd_author as 作者,cd_publish as 出版社,cd_isbn as ISBN,cd_inprice as 进价,cd_outprice as 售价,cd_bookcase as 书架,cd_count as 库存量,cd_date as 出版时间,cd_in as 入库时间,cd_memo as 光盘简介 from cd_info where 1=0";
            ////////////////////////////////////////////////////////
            cd_info.InsertCommand = insert;
            cd_info.InsertCommand.Connection = connect;
            cd_info.InsertCommand.CommandText = "insert into cd_info(cd_id,cd_code,cd_name,cd_style,cd_author,cd_publish,cd_isbn,cd_inprice,cd_outprice,cd_bookcase,cd_count,cd_date,cd_in,cd_memo) values(@id,@code,@name,@style,@author,@publish,@isbn,@inprice,@outprice,@bookcase,@count,@date,@indate,@memo)";
            cd_info.InsertCommand.Parameters.Add("@id",SqlDbType.VarChar,0,"光盘编号");
            cd_info.InsertCommand.Parameters.Add("@code",SqlDbType.VarChar,0,"条形码");
            cd_info.InsertCommand.Parameters.Add("@name",SqlDbType.VarChar,0,"光盘名称");
            cd_info.InsertCommand.Parameters.Add("@style",SqlDbType.VarChar,0,"光盘类型");
            cd_info.InsertCommand.Parameters.Add("@author",SqlDbType.VarChar,0,"作者");
            cd_info.InsertCommand.Parameters.Add("@publish",SqlDbType.VarChar,0,"出版社");
            cd_info.InsertCommand.Parameters.Add("@isbn",SqlDbType.VarChar,0,"ISBN");
            cd_info.InsertCommand.Parameters.Add("@inprice",SqlDbType.Decimal,0,"进价");
            cd_info.InsertCommand.Parameters.Add("@outprice",SqlDbType.Decimal,0,"售价");
            cd_info.InsertCommand.Parameters.Add("@bookcase",SqlDbType.VarChar,0,"书架");
            cd_info.InsertCommand.Parameters.Add("@count",SqlDbType.Int,0,"库存量");
            cd_info.InsertCommand.Parameters.Add("@date",SqlDbType.DateTime,0,"出版时间");
            cd_info.InsertCommand.Parameters.Add("@indate",SqlDbType.DateTime,0,"入库时间");
            cd_info.InsertCommand.Parameters.Add("@memo",SqlDbType.VarChar,0,"光盘简介");
            ///////////////////////////////////////////////////////////
            cd_info.UpdateCommand = update;
            cd_info.UpdateCommand.Connection = connect;
            cd_info.UpdateCommand.CommandText = "update cd_info set cd_code=@code,cd_name=@name,cd_style=@style,cd_author=@author,cd_publish=@publish,cd_isbn=@isbn,cd_inprice=@inprice,cd_outprice=@outprice,cd_bookcase=@bookcase,cd_count=@count,cd_date=@date,cd_in=@indate,cd_memo=@memo where cd_id=@id";
            cd_info.UpdateCommand.Parameters.Add("@id", SqlDbType.VarChar, 0, "光盘编号");
            cd_info.UpdateCommand.Parameters.Add("@code", SqlDbType.VarChar, 0, "条形码");
            cd_info.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "光盘名称");
            cd_info.UpdateCommand.Parameters.Add("@style", SqlDbType.VarChar, 0, "光盘类型");
            cd_info.UpdateCommand.Parameters.Add("@author", SqlDbType.VarChar, 0, "作者");
            cd_info.UpdateCommand.Parameters.Add("@publish", SqlDbType.VarChar, 0, "出版社");
            cd_info.UpdateCommand.Parameters.Add("@isbn", SqlDbType.VarChar, 0, "ISBN");
            cd_info.UpdateCommand.Parameters.Add("@inprice", SqlDbType.Decimal, 0, "进价");
            cd_info.UpdateCommand.Parameters.Add("@outprice", SqlDbType.Decimal, 0, "售价");
            cd_info.UpdateCommand.Parameters.Add("@bookcase", SqlDbType.VarChar, 0, "书架");
            cd_info.UpdateCommand.Parameters.Add("@count", SqlDbType.Int, 0, "库存量");
            cd_info.UpdateCommand.Parameters.Add("@date", SqlDbType.DateTime, 0, "出版时间");
            cd_info.UpdateCommand.Parameters.Add("@indate", SqlDbType.DateTime, 0, "入库时间");
            cd_info.UpdateCommand.Parameters.Add("@memo", SqlDbType.VarChar, 0, "光盘简介");
            ////////////////////////////////////////////////////////////////
            cd_info.DeleteCommand = delete;
            cd_info.DeleteCommand.Connection = connect;
            cd_info.DeleteCommand.CommandText = "delete cd_info where cd_id=@id";
            ////////////////////////////////////////////////////////////////
            cd_info.Fill(data,"cd_info");
            source.DataSource = data;
            source.DataMember = "cd_info";
            this.dataGridView1.DataSource = source;
            //////////////////////////////////////////////////////////
            this.id.DataBindings.Add("Text",source,"光盘编号",true);
            this.code.DataBindings.Add("Text",source,"条形码",true);
            this.name.DataBindings.Add("Text",source,"光盘名称",true);
            this.style.DataBindings.Add("SelectedValue",source,"光盘类型",true);
            this.author.DataBindings.Add("Text",source,"作者",true);
            this.publish.DataBindings.Add("SelectedValue",source,"出版社",true);
            this.isbn.DataBindings.Add("Text",source,"ISBN",true);
            this.inprice.DataBindings.Add("Text",source,"进价",true);
            this.outprice.DataBindings.Add("Text",source,"售价",true);
            this.bookcase.DataBindings.Add("SelectedValue",source,"书架",true);
            this.count.DataBindings.Add("Text",source,"库存量",true);
            this.date.DataBindings.Add("Value",source,"出版时间",true);
            this.indate.DataBindings.Add("Value",source,"入库时间",true);
            this.memo.DataBindings.Add("Text",source,"光盘简介",true);
        }

        /// <summary>
        /// 绑定光盘类型
        /// </summary>
        /// <param name="Flag">为true表示绑定querystyle,为false表示绑定style</param>
        private void BindStyle(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='光盘'", connect);
            DataSet data = new DataSet();
            adapter.Fill(data, "book_style");
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
            SqlDataAdapter adapter = new SqlDataAdapter("select * from publish where publish_style='光盘'", connect);
            DataSet data = new DataSet();
            adapter.Fill(data, "publish");
            if (Flag)
            {
                this.querypublish.DataSource = data.Tables["publish"];
                this.querypublish.DisplayMember = "publish_name";
                this.querypublish.ValueMember = "publish_name";
            }
            else
            {
                this.publish.DataSource = data.Tables["publish"];
                this.publish.DisplayMember = "publish_name";
                this.publish.ValueMember = "publish_name";
            }
        }

        /// <summary>
        /// 绑定书架
        /// </summary>
        /// <param name="Flag">Flag为true表示绑定querybookcase,为false表示绑定bookcase</param>
        private void BindBookcase(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase", connect);
            DataSet data = new DataSet();
            bookcase.Fill(data, "bookcase");
            if (Flag)
            {
                this.querybookcase.DataSource = data.Tables["bookcase"];
                this.querybookcase.DisplayMember = "bookcase_place";
                this.querybookcase.ValueMember = "bookcase_place";
            }
            else
            {
                this.bookcase.DataSource = data.Tables["bookcase"];
                this.bookcase.DisplayMember = "bookcase_place";
                this.bookcase.ValueMember = "bookcase_place";
            }
        }

        private void FrmCdStock_Load(object sender, EventArgs e)//初始化
        {
            this.BindStyle(false);
            this.BindPublish(false);
            this.BindBookcase(false);
            /////////////////////////////////////////////
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
                //////////////////////////////////////////////
                this.name.Enabled = true;
                this.style.Enabled = true;
                this.author.Enabled = true;
                this.publish.Enabled = true;
                this.isbn.Enabled = true;
                this.inprice.Enabled = true;
                this.outprice.Enabled = true;
                this.bookcase.Enabled = true;
                this.count.Enabled = true;
                this.date.Enabled = true;
                this.indate.Enabled = true;
                this.memo.Enabled = true;
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
                this.bookcase.Enabled = false;
                this.count.Enabled = false;
                this.date.Enabled = false;
                this.indate.Enabled = false;
                this.memo.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            /////////////////////////////////////////////
            this.id.Enabled = true;
            this.code.Enabled = true;
            this.ToolButtonEnabled(true);
            this.id.Focus();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
        {
            if (source.Position != -1)
            {
                this.id.Enabled = false;
                this.code.Enabled = false;
                this.ToolButtonEnabled(true);
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
                source.RemoveAt(source.Position);
                //////////////////////////////////////////////
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
            string result = message.Replace("cd_info_key", "列\"光盘编号\"不能存在相同的值");
            result = result.Replace("cd_code_key", "列\"光盘条形码\"不能存在相同的值");
            result = result.Replace("checkcdprice", "\"售价\"不能大于\"进价\"");
            result = result.Replace("cd_id", "光盘编号");
            result = result.Replace("cd_code","光盘条形码");
            result = result.Replace("cd_name", "光盘名称");
            result = result.Replace("cd_style", "光盘类型");
            result = result.Replace("cd_isbn", "ISBN");
            result = result.Replace("cd_inprice", "进价");
            result = result.Replace("cd_outprice", "售价");
            result = result.Replace("cd_count", "库存量");
            result = result.Replace("cd_info", "光盘表");
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
                    cd_info.Update(data, "cd_info");
                    /////////////////////////////////////////////////////////
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
            //////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示所有信息或查询信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有信息,为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            cd_info.SelectCommand.CommandText = "select cd_id as 光盘编号,cd_code as 条形码,cd_name as 光盘名称,cd_style as 光盘类型,cd_author as 作者,cd_publish as 出版社,cd_isbn as ISBN,cd_inprice as 进价,cd_outprice as 售价,cd_bookcase as 书架,cd_count as 库存量,cd_date as 出版时间,cd_in as 入库时间,cd_memo as 光盘简介 from cd_info";
            cd_info.Fill(data,"cd_info");
            source.DataSource = data;
            source.DataMember = "cd_info";
            if (!Flag)
            {
                source.Filter = "光盘编号 like '%" + this.queryid.Text.Trim()+"%' and isnull(条形码,'') like '%"+this.querycode.Text.Trim()+"%' and isnull(光盘名称,'') like '%"+this.queryname.Text.Trim()+"%' and isnull(出版社,'') like '%"+this.querypublish.Text.Trim()+"%' and isnull(光盘类型,'') like '%"+this.querystyle.Text.Trim()+"%' and isnull(书架,'') like '%"+this.querybookcase.Text.Trim()+"%' and isnull(作者,'') like '%"+this.queryauthor.Text.Trim()+"%' and isnull(ISBN,'') like '%"+this.queryisbn.Text.Trim()+"%'" ;
            }
            else
            {
                source.Filter = "光盘编号 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void query_Click(object sender, EventArgs e)//查询
        {
            this.DisplayAll(false);
        }

        private void all_Click(object sender, EventArgs e)//显示全部
        {
            this.DisplayAll(true);
        }

        private void inprice_KeyPress(object sender, KeyPressEventArgs e)
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
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
    public partial class FmBookIn : Form
    {
        public FmBookIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//选择不同的tabcontrol页
        {
            if (this.tabControl1.SelectedTab == this.book)
            {
                this.bookid.Focus();
            }
            else
            {
                this.cdid.Focus();
            }
        }

        /// <summary>
        /// 判断商品类型是否存在
        /// </summary>
        /// <param name="style">style为true表示图书类型,为false表示光盘类型</param>
        /// <returns>为true表示存在,否则表示不存在</returns>
        private bool IsBookStyleExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from book_style where bookstyle_name=@name and bookstyle_style=@style", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@name", this.bookstyle.Text.Trim());
                cmd.Parameters.AddWithValue("@style","图书");
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", this.cdstyle.Text.Trim());
                cmd.Parameters.AddWithValue("@style","光盘");
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// 出版社是否存在
        /// </summary>
        /// <param name="style">style为true表示图书出版社,为false表示光盘出版社</param>
        /// <returns>为true表示存在,否则表示不存在</returns>
        private bool IsPublishExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from publish where publish_name=@name and publish_style=@style", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@name", this.bookpublish.Text.Trim());
                cmd.Parameters.AddWithValue("@style","图书");
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", this.cdpublish.Text.Trim());
                cmd.Parameters.AddWithValue("@style","光盘");
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// 出版社是否存在
        /// </summary>
        /// <param name="style">style为true表示图书书架,为false表示光盘书架</param>
        /// <returns>为true表示存在,否则表示不存在</returns>
        private bool IsBookcaseExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from bookcase where bookcase_place=@place", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@place", this.bookcase.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@place", this.cdcase.Text.Trim());
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// 清除添加图书信息入库的历史记录
        /// </summary>
        private void BookClear(bool Flag)
        {
            if (Flag)
            {
                this.bookid.Text = "";
            }
            this.bookcode.Text = "";
            this.bookstyle.Text = "";
            this.bookname.Text = "";
            this.bookauthor.Text = "";
            this.bookpublish.Text = "";
            this.bookisbn.Text = "";
            this.bookpage.Text = "";
            this.bookinprice.Text = "";
            this.bookoutprice.Text = "";
            this.bookcount.Text = "";
            this.bookcase.SelectedIndex = -1;
            this.bookmemo.Text = "";
            this.Height = 500;
            this.bookid.Focus();
        }

        /// <summary>
        /// 格式化错误信息
        /// </summary>
        private string ErrorMessage(string error)
        {
            string result = error.Replace("checkbookprice","图书进价不能大于售价");
            result = result.Replace("checkcdprice","光盘城里人不能大于售价");
            result = result.Replace("book_info","图书信息表");
            result = result.Replace("cd_info","光盘信息表");
            return result;
        }

        private void button1_Click(object sender, EventArgs e)//图书入库
        {
            if (this.bookid.Text.Trim() != "" && this.bookcode.Text.Trim() != "" && this.bookstyle.Text.Trim() != "" && this.bookname.Text.Trim() != "" && this.bookisbn.Text.Trim() != "" && this.bookinprice.Text.Trim() != "" && this.bookoutprice.Text.Trim() != "" && this.bookcount.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (this.IsBookStyleExists(true))
                    {
                        if (MessageBox.Show("你输入的商品的类型在系统中不存在，是否要把该新类型导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into book_style(bookstyle_name,bookstyle_style) values(@style,'图书')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@style", this.bookstyle.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsPublishExists(true))
                    {
                        if (MessageBox.Show("你输入的出版社在系统中不存在，是否要把该新出版社导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into publish(publish_name,publish_style) values(@publish,'图书')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@publish", this.bookpublish.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsBookcaseExists(true))
                    {
                        if (MessageBox.Show("你输入的书架在系统中不存在，是否要把该新书架导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into bookcase(bookcase_place) values(@place)", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@place", this.bookcase.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("InsertBook", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.bookid.Text.Trim());
                    cmd.Parameters.AddWithValue("@code", this.bookcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", this.bookname.Text.Trim());
                    cmd.Parameters.AddWithValue("@style", this.bookstyle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", this.bookauthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish", this.bookpublish.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", this.bookisbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@inprice", decimal.Parse(this.bookinprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@outprice", decimal.Parse(this.bookoutprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@page", int.Parse(this.bookpage.Text.Trim()));
                    cmd.Parameters.AddWithValue("@bookcase", this.bookcase.Text.Trim());
                    cmd.Parameters.AddWithValue("@count", int.Parse(this.bookcount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(this.bookdate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@indate", DateTime.Parse(this.bookindate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@memo", this.bookmemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookcdcase", this.yes.Checked ? this.bookcdcase.Text.Trim() : "");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("图书已经成功入库！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (!bookadd.Checked)
                    {
                        this.Close();
                    }
                    this.BookClear(true);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("入库失败！\n错误信息：" + this.ErrorMessage(ee.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("带\"*\"的为必填信息，请填写完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 绑定出版社
        /// </summary>
        /// <param name="style">style为true绑定图书的出版社，为false绑定光盘的出版社</param>
        private void BindPublish(bool style)//绑定出版社
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (style)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='图书'",connect);
                adapter.Fill(data,"publish");
                this.bookpublish.DataSource = data.Tables["publish"];
                this.bookpublish.DisplayMember = "publish_name";
                this.bookpublish.ValueMember = "publish_name";
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='光盘'",connect);
                adapter.Fill(data,"publish");
                this.cdpublish.DataSource = data.Tables["publish"];
                this.cdpublish.DisplayMember = "publish_name";
                this.cdpublish.ValueMember = "publish_name";
            }
        }

        /// <summary>
        /// 绑定商品类型
        /// </summary>
        /// <param name="style">style为true绑定图书的类型，为false绑定光盘的类型</param>
        private void BindBookStyle(bool style)//绑定类型
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (style)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='图书'", connect);
                adapter.Fill(data,"book_style");
                this.bookstyle.DataSource = data.Tables["book_style"];
                this.bookstyle.DisplayMember = "bookstyle_name";
                this.bookstyle.ValueMember = "bookstyle_name";
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='光盘'",connect);
                adapter.Fill(data,"book_style");
                this.cdstyle.DataSource = data.Tables["book_style"];
                this.cdstyle.DisplayMember = "bookstyle_name";
                this.cdstyle.ValueMember = "bookstyle_name";
            }
        }

        private void BindBookcase(int style)//绑定书架
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase",connect);
            DataSet data = new DataSet();
            bookcase.Fill(data,"bookcase");
            if (style==1)
            {
                this.bookcase.DataSource = data.Tables["bookcase"];
                this.bookcase.DisplayMember = "bookcase_place";
                this.bookcase.ValueMember = "bookcase_place";
            }
            else if(style==2)
            {
                this.bookcdcase.DataSource = data.Tables["bookcase"];
                this.bookcdcase.DisplayMember = "bookcase_place";
                this.bookcdcase.ValueMember = "bookcase_place";
            }
            else
            {
                this.cdcase.DataSource = data.Tables["bookcase"];
                this.cdcase.DisplayMember = "bookcase_place";
                this.cdcase.ValueMember = "bookcase_place";
            }
        }

        private void bookstyle_DropDown(object sender, EventArgs e)//绑定图书类型
        {
            this.BindBookStyle(true);
        }

        private void bookpublish_DropDown(object sender, EventArgs e)//绑定出版社
        {
            this.BindPublish(true);
        }

        private void bookcase_DropDown(object sender, EventArgs e)//绑定书架
        {
            this.BindBookcase(1);
        }

        private void bookcdcase_DropDown(object sender, EventArgs e)//绑定书架(光盘)
        {
            this.BindBookcase(2);
        }

        private void cdstyle_DropDown(object sender, EventArgs e)//光盘绑定商品类型
        {
            this.BindBookStyle(false);
        }

        private void cdpublish_DropDown(object sender, EventArgs e)//光盘绑定出版社
        {
            this.BindPublish(false);
        }

        private void cdcase_DropDown(object sender, EventArgs e)//光盘绑定书架
        {
            this.BindBookcase(3);
        }

        /// <summary>
        /// 清除光盘信息入库的历史信息
        /// </summary>
        private void CdClear(bool Flag)
        {
            if (Flag)
            {
                this.cdid.Text = "";
            }
            this.cdcode.Text = "";
            this.cdstyle.Text = "";
            this.cdname.Text = "";
            this.cdauthor.Text = "";
            this.cdpublish.Text = "";
            this.cdisbn.Text = "";
            this.cdinprice.Text = "";
            this.cdoutprice.Text = "";
            this.cdcount.Text = "";
            this.cdcase.SelectedIndex = -1;
            this.cdmemo.Text = "";
            this.cdid.Focus();
        }

        private void button4_Click(object sender, EventArgs e)//光盘入库
        {
            if (this.cdid.Text.Trim() != "" && this.cdcode.Text.Trim() != "" && this.cdstyle.Text.Trim() != "" && this.cdname.Text.Trim() != "" && this.cdisbn.Text.Trim() != "" && this.cdinprice.Text.Trim() != "" && this.cdoutprice.Text.Trim() != "" && this.cdcount.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (this.IsBookStyleExists(false))
                    {
                        if (MessageBox.Show("你输入的商品的类型在系统中不存在，是否要把该新类型导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into book_style(bookstyle_name,bookstyle_style) values(@style,'光盘')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@style", this.cdstyle.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsPublishExists(false))
                    {
                        if (MessageBox.Show("你输入的出版社在系统中不存在，是否要把该新出版社导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into publish(publish_name,publish_style) values(@publish,'光盘')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@publish", this.cdpublish.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsBookcaseExists(false))
                    {
                        if (MessageBox.Show("你输入的书架在系统中不存在，是否要把该新书架导入到系统中？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into bookcase(bookcase_place) values(@place)", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@place", this.cdcase.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("InsertCd", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim());
                    cmd.Parameters.AddWithValue("@code", this.cdcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", this.cdname.Text.Trim());
                    cmd.Parameters.AddWithValue("@style", this.cdstyle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", this.cdauthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", this.cdisbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish", this.cdpublish.Text.Trim());
                    cmd.Parameters.AddWithValue("@inprice", decimal.Parse(this.cdinprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@outprice", decimal.Parse(this.cdoutprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@bookcase", this.cdcase.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@count", int.Parse(this.cdcount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(this.cddate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@indate", DateTime.Parse(this.cddatein.Text.Trim()));
                    cmd.Parameters.AddWithValue("@memo", this.cdmemo.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("光盘成功入库！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (!cdadd.Checked)
                    {
                        this.Close();
                    }
                    this.CdClear(true);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("入库失败！\n错误信息：" + this.ErrorMessage(ee.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("带\"*\"的为必填信息，请填写完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void bookpage_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void bookinprice_KeyPress(object sender, KeyPressEventArgs e)//判断只能输入浮点型
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
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

        private void yes_CheckedChanged(object sender, EventArgs e)//该图书存在附加光盘
        {
            if (this.yes.Checked)
            {
                this.bookcdcase.Enabled = true;
            }
            else
            {
                this.bookcdcase.Enabled = false;
            }
        }

        private void bookid_TextChanged(object sender, EventArgs e)//相同编号的图书自动显示详细信息
        {
            if (this.DisplayBookInfo())
            {
                this.bookshow.Visible = true;
                this.BindBook();
                this.DisplayBook();
            }
            else
            {
                this.bookshow.Visible = false;
            }
        }

        /// <summary>
        /// 显示图书的详细信息
        /// </summary>
        private void DisplayBook()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from book_info where book_id=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.bookid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.bookcode.Text = read["book_code"].ToString().Trim();
                this.bookname.Text = read["book_name"].ToString().Trim();
                this.bookstyle.Text = read["book_style"].ToString().Trim();
                this.bookauthor.Text = read["book_author"].ToString().Trim();
                this.bookpublish.Text = read["book_publish"].ToString().Trim();
                this.bookisbn.Text = read["book_isbn"].ToString().Trim();
                this.bookpage.Text = read["book_page"].ToString().Trim();
                this.bookdate.Value = DateTime.Parse(read["book_date"].ToString().Trim());
                this.bookinprice.Text = read["book_inprice"].ToString().Trim();
                this.bookoutprice.Text = read["book_outprice"].ToString().Trim();
                this.bookcase.Text = read["book_bookcase"].ToString().Trim();
                this.bookindate.Value = DateTime.Parse(read["book_in"].ToString().Trim());
                this.bookmemo.Text = read["book_memo"].ToString().Trim();
                if (read["book_cd_case"].ToString().Trim() != "")
                {
                    this.yes.Checked = true;
                    this.bookcdcase.Enabled = true;
                    this.bookcdcase.Text = read["book_cd_case"].ToString().Trim();
                }
                else
                {
                    this.no.Checked = true;
                    this.bookcdcase.Enabled = false;
                }
            }
            else
            {
                this.BookClear(false);
            }
            read.Close();
            connect.Close();
        }

        BindingSource booksource;

        /// <summary>
        /// 显示图书的详细信息
        /// </summary>
        private void BindBook()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select book_id as 图书编号,book_code as 条形码,book_name as 图书名称,book_style as 图书类型,book_publish as 出版社,book_count as 库存量 from book_info", connect);
            data.Clear();
            adapter.Fill(data,"book_info");
            booksource = new BindingSource(data,"book_info");
            booksource.Filter = "图书编号 like '" + this.bookid.Text.Trim() + "%'";
            this.bookshowinfo.DataSource = booksource;
        }

        /// <summary>
        /// 什么时候显示图书信息
        /// </summary>
        /// <returns>true表示显示,反之表示不显示</returns>
        private bool DisplayBookInfo()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from book_info where book_id like @id",connect);
            cmd.Parameters.AddWithValue("@id",this.bookid.Text.Trim()+"%");
            int count = int.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return count > 0;
        }

        private void bookid_Leave(object sender, EventArgs e)//离开焦点时隐藏图书信息列表
        {
            if (this.bookid.Text.Trim() != "")
            {
                this.bookshow.Visible = false;
                if (this.bookcode.Text.Trim() != "")
                {
                    this.bookcount.Focus();
                }
            }
        }

        private void FrmBookIn_Shown(object sender, EventArgs e)
        {
            this.bookid.Focus();
        }

        private void bookshowinfo_DoubleClick(object sender, EventArgs e)//双击图书列表中的某一记录
        {
            if (this.bookshowinfo.SelectedRows.Count != 0)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
        }

        private void cdid_TextChanged(object sender, EventArgs e)//相同编号的光盘显示详细信息
        {
            if (this.DisplayCdInfo())
            {
                this.cdshow.Visible = true;
                this.BindCd();
                this.DisplayCd();
            }
            else
            {
                this.cdshow.Visible = false;
            }
        }

        /// <summary>
        /// 显示光盘的详细信息
        /// </summary>
        private void DisplayCd()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from cd_info where cd_id=@id", connect);
            cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.cdcode.Text = read["cd_code"].ToString().Trim();
                this.cdname.Text = read["cd_name"].ToString().Trim();
                this.cdstyle.Text = read["cd_style"].ToString().Trim();
                this.cdauthor.Text = read["cd_author"].ToString().Trim();
                this.cdpublish.Text = read["cd_publish"].ToString().Trim();
                this.cdisbn.Text = read["cd_isbn"].ToString().Trim();
                this.cddate.Value = DateTime.Parse(read["cd_date"].ToString().Trim());
                this.cdinprice.Text = read["cd_inprice"].ToString().Trim();
                this.cdoutprice.Text = read["cd_outprice"].ToString().Trim();
                this.cdcase.Text = read["cd_bookcase"].ToString().Trim();
                this.cddatein.Value = DateTime.Parse(read["cd_in"].ToString().Trim());
                this.cdmemo.Text = read["cd_memo"].ToString().Trim();
            }
            else
            {
                this.CdClear(false);
            }
            read.Close();
            connect.Close();
        }

        BindingSource cdsource;

        /// <summary>
        /// 显示光盘的详细信息
        /// </summary>
        private void BindCd()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select cd_id as 光盘编号,cd_code as 条形码,cd_name as 光盘名称,cd_style as 光盘类型,cd_publish as 出版社,cd_count as 库存量 from cd_info", connect);
            data.Clear();
            adapter.Fill(data, "cd_info");
            cdsource = new BindingSource(data, "cd_info");
            cdsource.Filter = "光盘编号 like '" + this.cdid.Text.Trim() + "%'";
            this.cdshowinfo.DataSource = cdsource;
        }

        /// <summary>
        /// 什么时候显示光盘信息
        /// </summary>
        /// <returns>true表示显示,反之表示不显示</returns>
        private bool DisplayCdInfo()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from cd_info where cd_id like @id", connect);
            cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim() + "%");
            int count = int.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return count > 0;
        }

        private void cdid_Leave(object sender, EventArgs e)//离开时隐藏光盘列表
        {
            if (this.cdid.Text.Trim() != "")
            {
                this.cdshow.Visible = false;
                if (this.cdcode.Text.Trim() != "")
                {
                    this.cdcount.Focus();
                }
            }
        }

        private void cdshowinfo_DoubleClick(object sender, EventArgs e)//双击时选择当前的记录
        {
            if (this.cdshowinfo.SelectedRows.Count != 0)
            {
                this.cdid.Text = this.cdshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.cdshow.Visible = false;
            }
        }

        private void bookid_KeyDown(object sender, KeyEventArgs e)//按Enter选择当前选择的图书信息
        {
            if (e.KeyValue == 13 && this.bookshow.Visible == true)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
            else if (e.KeyValue == 38 && this.bookshow.Visible == true)
            {
                booksource.MovePrevious();
            }
            else if (e.KeyValue == 40 && this.bookshow.Visible == true)
            {
                booksource.MoveNext();
            }
        }

        private void cdid_KeyDown(object sender, KeyEventArgs e)//按Enter选择当前选择的光盘信息
        {
            if (e.KeyValue == 13 && this.bookshow.Visible == true)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
            else if (e.KeyValue == 38 && this.bookshow.Visible == true)
            {
                cdsource.MovePrevious();
            }
            else if (e.KeyValue == 40 && this.bookshow.Visible == true)
            {
                cdsource.MoveNext();
            }
        }

        private void bookalert_Click(object sender, EventArgs e)//弹出图书列表
        {
            if (this.bookshow.Visible)
            {
                this.bookshow.Visible = false;
            }
            else
            {
                this.bookshow.Visible = true;
                this.BindBook();
                this.bookid.Focus();
            }
        }

        private void cdalert_Click(object sender, EventArgs e)//弹出光盘列表
        {
            if (this.cdshow.Visible)
            {
                this.cdshow.Visible = false;
            }
            else
            {
                this.cdshow.Visible = true;
                this.BindCd();
                this.cdid.Focus();
            }
        }
    }
}
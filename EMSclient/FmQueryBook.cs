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
    public partial class FmQueryBook : Form
    {
        public FmQueryBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 绑定商品类型
        /// </summary>
        /// <param name="Flag">为true表示绑定图书类型,为false表示绑定光盘类型</param>
        private void BindStyle(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (Flag)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='图书'",connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='光盘'", connect);
            }
            adapter.Fill(data, "book_style");
            style.DataSource = data.Tables["book_style"];
            style.DisplayMember = "bookstyle_name";
            style.ValueMember = "bookstyle_name";
        }

        /// <summary>
        /// 绑定商品位置
        /// </summary>
        private void BindCase()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter place = new SqlDataAdapter("select * from bookcase",connect);
            place.Fill(data,"bookcase");
            bookcase.DataSource = data.Tables["bookcase"];
            bookcase.DisplayMember = "bookcase_place";
            bookcase.ValueMember = "bookcase_place";
        }

        /// <summary>
        /// 绑定出版社
        /// </summary>
        /// <param name="Flag">Flag为true表示绑定图书的出版社,为false表示绑定光盘出版社</param>
        private void BindPublish(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (Flag)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='图书'",connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='光盘'", connect);
            }
            adapter.Fill(data, "publish");
            publish.DataSource = data.Tables["publish"];
            publish.DisplayMember = "publish_name";
            publish.ValueMember = "publish_name";
        }

        /// <summary>
        /// 绑定图书信息
        /// </summary>
        /// <param name="Flag">Flag为true表示正常加载图书信息,false表示查询图书信息</param>
        private void BindBook(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookinfo = new SqlDataAdapter("select 图书编号,条形码,图书名称,图书类型,作者,出版社,ISBN,售价,页码,书架,库存量,出版时间,入库时间,图书简介,光盘所在书架 from bookinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            bookinfo.Fill(data,"bookinfo");
            source.DataSource = data;
            source.DataMember = "bookinfo";
            if (!Flag)
            {
                source.Filter = "图书编号 like '%" + this.id.Text.Trim() + "%' and 条形码 like '%" + this.code.Text.Trim() + "%' and 图书名称 like '%" + this.name.Text.Trim() + "%' and 图书类型 like '%" + this.style.Text.Trim() + "%' and 作者 like '%" + this.author.Text.Trim() + "%' and 书架 like '%" + this.bookcase.Text.Trim() + "%' and 出版社 like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "图书编号 like '%'";
            }
            this.dataGridView1.DataSource = source; 
        }

        /// <summary>
        /// 绑定光盘信息
        /// </summary>
        /// <param name="Flag">Flag为true表示正常加载光盘信息,false表示查询光盘信息</param>
        private void BindCd(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter cdinfo = new SqlDataAdapter("select 光盘编号,条形码,光盘名称,光盘类型,作者,出版社,ISBN,售价,书架,库存量,出版时间,入库时间,光盘简介 from cdinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            cdinfo.Fill(data,"cdinfo");
            source.DataSource = data;
            source.DataMember = "cdinfo";
            if (!Flag)
            {
                source.Filter = "光盘编号 like '%" + this.id.Text.Trim() + "%' and 条形码 like '%" + this.code.Text.Trim() + "%' and 光盘名称 like '%" + this.name.Text.Trim() + "%' and 光盘类型 like '%" + this.style.Text.Trim() + "%' and 作者 like '%" + this.author.Text.Trim() + "%' and 书架 like '%" + this.bookcase.Text.Trim() + "%' and 出版社 like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "光盘编号 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        /// <summary>
        /// 显示图书的详细信息
        /// </summary>
        private void DisplayBookInfo()
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                FmBookInfo bookinfo = new FmBookInfo(false);
                bookinfo.bookid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                bookinfo.ShowDialog();
            }
        }

        /// <summary>
        /// 显示光盘的详细信息
        /// </summary>
        private void DisplayCdInfo()
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                FmCdInfo cdinfo = new FmCdInfo(false);
                cdinfo.cdid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                cdinfo.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            if (this.book.Checked)
            {
                this.BindBook(false);
            }
            else
            {
                this.BindCd(false);
            }
            this.timer1.Enabled = true;
        }

        private void style_DropDown(object sender, EventArgs e)//绑定类型
        {
            if (this.book.Checked)
            {
                this.BindStyle(true);
            }
            else
            {
                this.BindStyle(false);
            }
        }

        private void bookcase_DropDown(object sender, EventArgs e)//绑定书架
        {
            this.BindCase();
        }

        private void publish_DropDown(object sender, EventArgs e)//绑定出版社
        {
            if (this.book.Checked)
            {
                this.BindPublish(true);
            }
            else
            {
                this.BindPublish(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)//显示全部
        {
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//显示查询结果
        {
            if (this.Height > 590)
            {
                this.timer1.Enabled = false;
            }
            else
            {
                this.Height = this.Height + 10;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//显示详细信息
        {
            if (this.book.Checked)
            {
                this.DisplayBookInfo();
            }
            else
            {
                this.DisplayCdInfo();
            }
        }
    }
}
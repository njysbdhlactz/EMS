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
    public partial class FmPrintWare : Form
    {
        private BindingSource source = new BindingSource();

        public FmPrintWare()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        /// <summary>
        /// 获取查询字符串
        /// </summary>
        private string GetSelectString()
        {
            string result = "";
            
            return result;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void Query()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand select = new SqlCommand();
            adapter.SelectCommand = select;
            adapter.SelectCommand.Connection = connect;
            if (this.book.Checked)
            {
                adapter.SelectCommand.CommandText = "select 图书名称,图书类型,作者,出版社,ISBN,进价,售价,页码,书架,库存量,convert(varchar(10),出版时间,120) as 出版时间,光盘所在书架 from bookinfo where 图书名称 like @name and 图书类型 like @style and 作者 like @author and 出版社 like @publish and 书架 like @bookcase";
            }
            else
            {
                adapter.SelectCommand.CommandText = "select 光盘名称,光盘类型,作者,出版社,ISBN,进价,售价,书架,库存量,convert(varchar(10),出版时间,120) as 出版时间 from cdinfo where 光盘名称 like @name and 光盘类型 like @style and 作者 like @author and 出版社 like @publish and 书架 like @bookcase";
            }
            adapter.SelectCommand.Parameters.AddWithValue("@name", "%" + this.name.Text.Trim() + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@style", "%" + this.style.Text.Trim() + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@author", "%" + this.author.Text.Trim() + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@publish", "%" + this.publish.Text.Trim() + "%");
            adapter.SelectCommand.Parameters.AddWithValue("@bookcase", "%" + this.bookcase.Text.Trim() + "%");
            if (this.book.Checked)
            {
                adapter.Fill(data.book_info);
                source.DataSource = data;
                source.DataMember = "book_info";
            }
            else
            {
                adapter.Fill(data.cd_info);
                source.DataSource = data;
                source.DataMember = "cd_info";
            }
            this.dataGridView1.DataSource = source;
        }

        private void ok_Click(object sender, EventArgs e)//查询
        {
            this.Query();
        }

        /// <summary>
        /// 绑定商品类型
        /// </summary>
        private void BindStyle()
        {
            string ware = this.book.Checked ? "图书" : "光盘";
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='"+ware+"'",connect);
            data.Clear();
            adapter.Fill(data,"book_style");
            this.style.DataSource = data.Tables["book_style"];
            this.style.DisplayMember = "bookstyle_name";
            this.style.ValueMember = "bookstyle_name";
        }

        /// <summary>
        /// 绑定出版社
        /// </summary>
        private void BindPublish()
        {
            string ware = this.book.Checked ? "图书" : "光盘";
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from publish where publish_style='"+ware+"'",connect);
            data.Clear();
            adapter.Fill(data,"publish");
            this.publish.DataSource = data.Tables["publish"];
            this.publish.DisplayMember = "publish_name";
            this.publish.ValueMember = "publish_name";
        }

        /// <summary>
        /// 绑定书架
        /// </summary>
        private void BindBookcase()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from bookcase",connect);
            data.Clear();
            adapter.Fill(data,"bookcase");
            this.bookcase.DataSource = data.Tables["bookcase"];
            this.bookcase.DisplayMember = "bookcase_place";
            this.bookcase.ValueMember = "bookcase_place";
        }

        private void style_DropDown(object sender, EventArgs e)//显示商品类型
        {
            this.BindStyle();
        }

        private void publish_DropDown(object sender, EventArgs e)//显示出版社
        {
            this.BindPublish();
        }

        private void bookcase_DropDown(object sender, EventArgs e)//显示书架
        {
            this.BindBookcase();
        }

        private void print_Click(object sender, EventArgs e)//打印
        {
            if (this.dataGridView1.Rows.Count != 0)
            {
                PrintWare print = new PrintWare(source.DataSource, this.book.Checked ? this.book.Text.Trim() : this.cd.Text.Trim());
                print.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }
    }
}
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
    public partial class FmBookInfo : Form
    {

        private bool show;

        public FmBookInfo()
        {
            InitializeComponent();
        }

        public FmBookInfo(bool isshow)
        {
            InitializeComponent();
            show = isshow;
        }

        private void FrmBookInfo_Load(object sender, EventArgs e)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from bookinfo where 图书编号=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.bookid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.bookcode.Text = read["条形码"].ToString().Trim();
                this.bookname.Text = "《"+read["图书名称"].ToString().Trim()+"》";
                this.bookstyle.Text = read["图书类型"].ToString().Trim();
                this.bookauthor.Text = read["作者"].ToString().Trim();
                this.bookpublish.Text = read["出版社"].ToString().Trim();
                this.bookisbn.Text = read["ISBN"].ToString().Trim();
                if (show)
                {
                    this.inprice.Text = read["进价"].ToString().Trim() + " 元";
                }
                else
                {
                    this.inprice.Text = "您无权查看";
                }
                this.outprice.Text = read["售价"].ToString().Trim()+" 元";
                this.page.Text = read["页码"].ToString().Trim()+" 页";
                this.bookcase.Text = read["书架"].ToString().Trim();
                this.count.Text = read["库存量"].ToString().Trim()+" 本";
                this.publishtime.Text = DateTime.Parse(read["出版时间"].ToString().Trim()).ToShortDateString();
                this.intime.Text = DateTime.Parse(read["入库时间"].ToString().Trim()).ToShortDateString();
                this.bookmemo.Text = read["图书简介"].ToString().Trim();
                if (read["光盘所在书架"].ToString().Trim() == "")
                {
                    this.radioButton2.Checked = true;
                    this.cdcase.Visible = false;
                }
                else
                {
                    this.radioButton1.Checked = true;
                    this.bookcdcase.Text = read["光盘所在书架"].ToString().Trim();
                }
            }
            read.Close();
            connect.Close();
        }
    }
}
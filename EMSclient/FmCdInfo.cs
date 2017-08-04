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
    public partial class FmCdInfo : Form
    {
        private bool show;

        public FmCdInfo()
        {
            InitializeComponent();
        }

        public FmCdInfo(bool isshow)
        {
            InitializeComponent();
            show = isshow;
        }

        private void FrmCdInfo_Load(object sender, EventArgs e)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from cdinfo where 光盘编号=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.cdid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.cdcode.Text = read["条形码"].ToString().Trim();
                this.cdname.Text = read["光盘名称"].ToString().Trim();
                this.cdstyle.Text = read["光盘类型"].ToString().Trim();
                this.cdauthor.Text = read["作者"].ToString().Trim();
                this.cdpublish.Text = read["出版社"].ToString().Trim();
                this.cdisbn.Text = read["ISBN"].ToString().Trim();
                if (show)
                {
                    this.cdinprice.Text = read["进价"].ToString().Trim() + " 元";
                }
                else
                {
                    this.cdinprice.Text = "您无权查看";
                }
                this.cdoutprice.Text = read["售价"].ToString().Trim() + " 元";
                this.cdcase.Text = read["书架"].ToString().Trim();
                this.cdcount.Text = read["库存量"].ToString().Trim() + " 张";
                this.cdpublishtime.Text = DateTime.Parse(read["出版时间"].ToString().Trim()).ToShortDateString();
                this.intime.Text = DateTime.Parse(read["入库时间"].ToString().Trim()).ToShortDateString();
                this.cdmemo.Text = read["光盘简介"].ToString().Trim();
            }
            read.Close();
            connect.Close();
        }
    }
}
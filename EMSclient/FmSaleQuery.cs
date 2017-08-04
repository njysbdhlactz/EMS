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
    public partial class FmSaleQuery : Form
    {
        public FmSaleQuery()
        {
            InitializeComponent();
        }

        private void range1_ValueChanged(object sender, EventArgs e)//确定什么时候显示方向按钮
        {
            this.SetDirectStatus();
        }

        private void button1_Click(object sender, EventArgs e)//图书销售情况查询
        {
            if (this.btn1.Checked)
            {
                this.DisplayNameStatus();
            }
            else if (this.btn2.Checked)
            {
                this.DisplayStyleStatus();
            }
            else if (this.btn3.Checked)
            {
                this.DisplayPublishStatus();
            }
            else if (this.btn4.Checked)
            {
                this.DisplayAuthorStatus();
            }
            else
            {
                MessageBox.Show("您还没有选择任何条件无法执行查询！！！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
            this.GetResult();
        }

        /// <summary>
        /// 设置图书中方向按钮的状态
        /// </summary>
        private void SetDirectStatus()
        {
            if (this.range1.Value.ToShortDateString() == this.range2.Value.ToShortDateString())
            {
                this.direct.Enabled = true;
            }
            else
            {
                this.direct.Enabled = false;
            }
        }

        /// <summary>
        /// 显示商品的类型
        /// </summary>
        private void DisplayStyle()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter=new SqlDataAdapter();
            if (this.booksale.Checked)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='图书'", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='光盘'", connect);
            }
            adapter.Fill(data, "book_style");
            this.style.DataSource = data.Tables["book_style"];
            this.style.DisplayMember = "bookstyle_name";
            this.style.ValueMember = "bookstyle_name";
        }

        /// <summary>
        /// 显示商品的出版社
        /// </summary>
        private void DisplayPublish()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (this.booksale.Checked)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='图书'", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='光盘'", connect);
            }
            adapter.Fill(data,"publish");
            this.publish.DataSource=data.Tables["publish"];
            this.publish.DisplayMember = "publish_name";
            this.publish.ValueMember = "publish_name";
        }

        private void direct_Click(object sender, EventArgs e)//设置方向改变
        {
            if (this.direct.Text == "-->")
            {
                this.direct.Text = "<--";
            }
            else
            {
                this.direct.Text = "-->";
            }
        }

        private void style_DropDown(object sender, EventArgs e)//显示商品类型
        {
            this.DisplayStyle();
        }

        private void publish_DropDown(object sender, EventArgs e)//显示商品出版社
        {
            this.DisplayPublish();
        }

        /// <summary>
        /// 以商品名称为条件进行查询
        /// </summary>
        private void DisplayNameStatus()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.booksale.Checked)
            {
                cmd = new SqlCommand("BookNameOrder", connect);
            }
            else
            {
                cmd = new SqlCommand("CdNameOrder",connect);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",this.name.Text.Trim()==""?"%":this.name.Text.Trim());
            cmd.Parameters.AddWithValue("@flag",this.GetQueryStatus());
            cmd.Parameters.AddWithValue("@date1",DateTime.Parse(this.range1.Value.ToShortDateString())>DateTime.Parse(this.range2.Value.ToShortDateString())?DateTime.Parse(this.range2.Value.ToShortDateString()):DateTime.Parse(this.range1.Value.ToShortDateString()));
            cmd.Parameters.AddWithValue("@date2", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range1.Value.ToShortDateString()) : DateTime.Parse(this.range2.Value.ToShortDateString()));
            this.DisplayView(cmd.ExecuteReader());
            connect.Close();
        }

        /// <summary>
        /// 以商品类型为条件进行查询
        /// </summary>
        private void DisplayStyleStatus()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.booksale.Checked)
            {
                cmd = new SqlCommand("BookStyleOrder",connect);
            }
            else
            {
                cmd = new SqlCommand("CdStyleOrder",connect);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@style",this.style.Text.Trim()==""?"%":this.style.Text.Trim());
            cmd.Parameters.AddWithValue("@flag", this.GetQueryStatus());
            cmd.Parameters.AddWithValue("@date1", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range2.Value.ToShortDateString()) : DateTime.Parse(this.range1.Value.ToShortDateString()));
            cmd.Parameters.AddWithValue("@date2", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range1.Value.ToShortDateString()) : DateTime.Parse(this.range2.Value.ToShortDateString()));
            this.DisplayView(cmd.ExecuteReader());
            connect.Close();
        }

        /// <summary>
        /// 以商品出版社为条件进行查询
        /// </summary>
        private void DisplayPublishStatus()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.booksale.Checked)
            {
                cmd = new SqlCommand("BookPublishOrder", connect);
            }
            else
            {
                cmd = new SqlCommand("CdPublishOrder", connect);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@publish", this.publish.Text.Trim() == "" ? "%" : this.publish.Text.Trim());
            cmd.Parameters.AddWithValue("@flag", this.GetQueryStatus());
            cmd.Parameters.AddWithValue("@date1", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range2.Value.ToShortDateString()) : DateTime.Parse(this.range1.Value.ToShortDateString()));
            cmd.Parameters.AddWithValue("@date2", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range1.Value.ToShortDateString()) : DateTime.Parse(this.range2.Value.ToShortDateString()));
            this.DisplayView(cmd.ExecuteReader());
            connect.Close();
        }

        /// <summary>
        /// 以作者为条件进行查询
        /// </summary>
        private void DisplayAuthorStatus()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.booksale.Checked)
            {
                cmd = new SqlCommand("BookAuthorOrder", connect);
            }
            else
            {
                cmd = new SqlCommand("CdAuthorOrder", connect);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@author", this.author.Text.Trim() == "" ? "%" : "%" + this.author.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@flag", this.GetQueryStatus());
            cmd.Parameters.AddWithValue("@date1", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range2.Value.ToShortDateString()) : DateTime.Parse(this.range1.Value.ToShortDateString()));
            cmd.Parameters.AddWithValue("@date2", DateTime.Parse(this.range1.Value.ToShortDateString()) > DateTime.Parse(this.range2.Value.ToShortDateString()) ? DateTime.Parse(this.range1.Value.ToShortDateString()) : DateTime.Parse(this.range2.Value.ToShortDateString()));
            this.DisplayView(cmd.ExecuteReader());
            connect.Close();
        }

        /// <summary>
        /// 将查询数据显示在DataView中
        /// </summary>
        private void DisplayView(SqlDataReader read)
        {
            this.queryresult.Columns.Clear();
            this.queryresult.Items.Clear();
            for (int i = 0; i < read.FieldCount; i++)
            {
                this.queryresult.Columns.Add(read.GetName(i),150);
            }
            this.queryresult.Columns.Add("排名",100);
            int index = 1;
            while (read.Read())
            {
                ListViewItem item = this.queryresult.Items.Add(read[0].ToString().Trim());
                for (int i = 1; i < read.FieldCount; i++)
                {
                    item.SubItems.Add(read[i].ToString().Trim());
                }
                item.SubItems.Add(index.ToString());
                index++;
            }
            read.Close();
        }

        /// <summary>
        /// 返回查询结果
        /// </summary>
        private void GetResult()
        {
            int count = 0;
            decimal salemoney = 0, money = 0;
            for (int i = 0; i < this.queryresult.Items.Count; i++)
            {
                count = count + int.Parse(this.queryresult.Items[i].SubItems[1].Text.Trim());
                salemoney = salemoney + decimal.Parse(this.queryresult.Items[i].SubItems[2].Text.Trim());
                money = money + decimal.Parse(this.queryresult.Items[i].SubItems[3].Text.Trim());
            }
            this.result.Text = "共查询出" + this.queryresult.Items.Count.ToString().Trim() + "条记录,总销售商品" + count.ToString().Trim() + "件,总销售额" + salemoney.ToString().Trim() + "元,总利润额" + money.ToString().Trim()+"元";
        }

        /// <summary>
        /// 获取当前要查询的状态
        /// </summary>
        /// <returns>返回为1表示查询当前选择的日期之前的数据，为2表示查询当前选择的日期之后的数据，为3表示查询在一个时间段中的数据</returns>
        private int GetQueryStatus()
        {
            if (this.range1.Value.ToShortDateString().Trim() == this.range2.Value.ToShortDateString().Trim())
            {
                if (this.direct.Text.Trim() == "<--")
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 3;
            }
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }
    }
}
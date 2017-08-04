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
    public partial class FmBookReturn : Form
    {
        public FmBookReturn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取商品的退货期限
        /// </summary>
        /// <param name="Flag">Flag为true表示图书的退货期限，为false表示光盘的退货期限</param>
        /// <returns>返回图书退货的天数</returns>
        private int GetLimit(bool Flag)
        {
            int count = 0;
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (Flag)
            {
                cmd = new SqlCommand("select back_return_count from back_return where back_return_name='图书'", connect);
            }
            else
            {
                cmd = new SqlCommand("select back_return_count from back_return where back_return_name='光盘'", connect);
            }
            count = int.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return count;
        }

        /// <summary>
        /// 顾客购买的商品是否超过了商品的退货期限
        /// </summary>
        /// <returns>返回true表示超过了商品的退货期限，返回false表示没有超过商品的退货期限</returns>
        private bool IsOverLimit()
        {
            DateTime nowDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime saleDate = DateTime.Parse(this.saledate.Value.ToShortDateString());
            TimeSpan span=nowDate.Subtract(saleDate);
            int Limit = this.book.Checked ? this.GetLimit(true) : this.GetLimit(false);
            if (span.Days >= Limit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void isover_Click(object sender, EventArgs e)//商品是否超限
        {
            this.WareReturnLimit();
        }

        /// <summary>
        /// 判断是否超过期限
        /// </summary>
        private void WareReturnLimit()
        {
            if (DateTime.Now < this.saledate.Value)
            {
                MessageBox.Show("购买日期不可能大于当前日期！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.saledate.Value = DateTime.Now;
                return;
            }
            else
            {
                if (this.IsOverLimit())
                {
                    string str = this.book.Checked ? "图书" : "光盘";
                    this.saleinfo.Text = "对不起，你购买的" + str + "已经超过了退货的期限！";
                    int Limit = this.book.Checked ? this.GetLimit(true) : this.GetLimit(false);
                    MessageBox.Show(str + "的期货期限为：" + Limit.ToString() + "天！");
                    this.isbn.Enabled = false;
                    this.count.Enabled = false;
                    this.reason.Enabled = false;
                }
                else
                {
                    this.saleinfo.Text = "恭喜您，你可以进行退货！";
                    this.isbn.Enabled = true;
                    this.count.Enabled = true;
                    this.reason.Enabled = true;
                    this.isbn.Focus();
                }
            }
        }

        private void FrmBookReturn_Shown(object sender, EventArgs e)
        {
            if (this.GetLimit(true) == 0)
            {
                if (this.GetLimit(false) == 0)
                {
                    MessageBox.Show("系统规定：不允许任何商品退货，此功能暂时关闭！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {
                    this.cd.Checked = true;
                }
            }
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)//限制数量只能输入整数
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void bookstyle_CheckedChanged(object sender, EventArgs e)//退货类型为图书
        {
            int Limit1 = this.book.Checked ? this.GetLimit(true) : this.GetLimit(false);
            int Limit2 = this.book.Checked ? this.GetLimit(false) : this.GetLimit(true);
            string str = this.book.Checked ? "图书" : "光盘";
            if (Limit1 == 0)
            {
                if (Limit2 == 0)
                {
                    MessageBox.Show("系统规定：不允许任何商品退货，此功能暂时关闭！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("系统规定：" + str + "不允许退货！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    if (this.book.Checked)
                    {
                        this.cd.Checked = true;
                    }
                    else
                    {
                        this.book.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// 获取顾客共退还的图书数量
        /// </summary>
        /// <returns>退还的图书的数量</returns>
        private string ReturnCount()
        {
            int result = 0;
            for (int i = 0; i < this.view.Items.Count; i++)
            {
                result = result + int.Parse(this.view.Items[i].SubItems[5].Text.Trim());
            }
            return result.ToString().Trim() != "0"?result.ToString().Trim():"0";
        }

        /// <summary>
        /// 获取应退还给顾客的金额
        /// </summary>
        /// <returns>退还顾客的金额</returns>
        private string ReturnMoney()
        {
            decimal result = 0;
            for (int i = 0; i < this.view.Items.Count; i++)
            {
                result = result + decimal.Parse(this.view.Items[i].SubItems[6].Text.Trim());
            }
            return result.ToString().Trim() != "0" ? result.ToString().Trim() : "0.0";
        }

        /// <summary>
        /// 判断输入的书存在与否
        /// </summary>
        /// <returns>true表示存在,否则表示不存在</returns>
        private bool WareExists()
        {
            bool exists = false;
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.book.Checked)
            {
                cmd = new SqlCommand("select count(*) from book_info where book_isbn=@isbn",connect);
            }
            else
            {
                cmd = new SqlCommand("select count(*) from cd_info where cd_isbn=@isbn",connect);
            }
            cmd.Parameters.AddWithValue("@isbn", this.isbn.Text.Trim());
            exists = (int.Parse(cmd.ExecuteScalar().ToString().Trim()) != 0);
            connect.Close();
            return exists;
        }

        private void view_DoubleClick(object sender, EventArgs e)//取消退货
        {
            if (this.view.SelectedItems.Count != 0)
            {
                this.view.Items.Remove(this.view.SelectedItems[0]);
                ////////////////////////////////////////////////////
                this.ReturnCount();
                this.ReturnMoney();
            }
            else
            {
                MessageBox.Show("请选择你要取消的项！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }

        private void warereturn_Click(object sender, EventArgs e)//顾客退货
        {
            if (this.view.Items.Count != 0)
            {
                for (int i = 0; i < this.view.Items.Count; i++)
                {
                    SqlConnection connect = InitConnect.GetConnection();
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("WareReturn",connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@style",this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
                    cmd.Parameters.AddWithValue("@id",this.view.Items[i].SubItems[1].Text.Trim());
                    cmd.Parameters.AddWithValue("@sale",DateTime.Parse(this.saledate.Value.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@date",DateTime.Parse(DateTime.Now.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@count",int.Parse(this.count.Text.Trim()));
                    cmd.Parameters.AddWithValue("@who",UserInfo.UserID);
                    cmd.Parameters.AddWithValue("@memo",this.reason.Text.Trim());
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                this.view.Items.Clear();
                this.ReturnCount();
                this.ReturnMoney();
                MessageBox.Show("顾客退货成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("没有顾客来退货！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void FrmBookReturn_Load(object sender, EventArgs e)
        {
            this.count.SelectedIndex = 0;
        }

        private void FrmBookReturn_FormClosing(object sender, FormClosingEventArgs e)//关闭窗体
        {
            this.view.Items.Clear();
        }

        private void close_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)//确定退货
        {
            if (this.WareExists())
            {
                bool exists=false;
                for (int i = 0; i < this.view.Items.Count; i++)
                {
                    if (this.view.Items[i].Text.Trim() == (this.book.Checked ? this.book.Text.Trim() : this.cd.Text.Trim()) && this.view.Items[i].SubItems[3].Text.Trim() == this.isbn.Text.Trim())
                    {
                        exists = true;
                        int all = int.Parse(this.view.Items[i].SubItems[5].Text.Trim()) + int.Parse(this.count.Text.Trim());
                        this.view.Items[i].SubItems[5].Text = all.ToString().Trim();
                        decimal price=decimal.Parse(this.view.Items[i].SubItems[4].Text.Trim())*all;
                        this.view.Items[i].SubItems[6].Text = price.ToString().Trim();
                        break;
                    }
                }
                if (exists == false)
                {
                    SqlConnection connect = InitConnect.GetConnection();
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("select book_id,book_name,book_isbn,book_outprice from book_info where book_isbn=@isbn",connect);
                    cmd.Parameters.AddWithValue("@isbn",this.isbn.Text.Trim());
                    SqlDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        ListViewItem item = this.view.Items.Add(this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
                        item.SubItems.Add(read["book_id"].ToString().Trim());
                        item.SubItems.Add(read["book_name"].ToString().Trim());
                        item.SubItems.Add(read["book_isbn"].ToString().Trim());
                        item.SubItems.Add(read["book_outprice"].ToString().Trim());
                        item.SubItems.Add(this.count.Text.Trim());
                        decimal price = decimal.Parse(read["book_outprice"].ToString().Trim())*int.Parse(this.count.Text.Trim());
                        item.SubItems.Add(price.ToString().Trim());
                    }
                    read.Close();
                    connect.Close();
                }
                this.ReturnCount();
                this.ReturnMoney();
                this.isbn.Text = "";
                this.isbn.Focus();
            }
            else
            {
                MessageBox.Show("该商品不存在！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                this.isbn.Text = "";
                this.isbn.Focus();
            }
        }

        private void cancelall_Click(object sender, EventArgs e)//取消全部的退货
        {
            this.view.Items.Clear();
            this.ReturnCount();
            this.ReturnMoney();
        }
    }
}
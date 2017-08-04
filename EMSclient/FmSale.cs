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
    public partial class FmSale : Form
    {
        public FmSale()
        {
            InitializeComponent();
        }

        private void sale_Click(object sender, EventArgs e)//确定交易
        {
            if (this.yes.Checked)
            {
                if (this.vipinfo.Text.Trim()!="")
                {
                    this.VipUpgrade();
                }
                else
                {
                    MessageBox.Show("该会员不存在！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            else
            {
                this.OverFirst();
            }
            this.SaleOk();
        }

        /// <summary>
        /// 判断顾客是否可升级为会员,如果可以则确定后升级成为会员
        /// </summary>
        private void OverFirst()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select vipstyle_request from vip_style where vipstyle_level=(select min(vipstyle_level) from vip_style)",connect);
            decimal upmoney = decimal.Parse(cmd.ExecuteScalar().ToString());
            connect.Close();
            if (decimal.Parse(this.money.Text.Trim())>=upmoney)
            {
                if (MessageBox.Show("该顾客可升级成为会员，确定升级成为会员吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    FmVip vip = new FmVip();
                    vip.MdiParent = this.MdiParent;
                    vip.Show();
                }
            }
        }

        /// <summary>
        /// 获取该会员加上这次消费和已经消费的金额的和
        /// </summary>
        private decimal GetVipSaleMoney()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("GetVipSale",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",this.vip.Text.Trim());
            decimal price = decimal.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return price + decimal.Parse(this.money.Text.Trim());
        }

        /// <summary>
        /// 判断该会员是否能升级
        /// </summary>
        /// <returns>为true表示能升级，为false表示不能升级</returns>
        private bool IsUpgrade()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("GetVipUpgradeRequest",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",this.vip.Text.Trim());
            decimal price = decimal.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return this.GetVipSaleMoney() > price;
        }

        /// <summary>
        /// 计算会员以会员价购买的最后价格
        /// </summary>
        private void GetCalculate()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select vip_style.vipstyle_rebate from vip inner join vip_style on vip_style.vipstyle_name=vip.vip_style where vip.vip_id=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.vip.Text.Trim());
            decimal price = decimal.Parse(cmd.ExecuteScalar().ToString());
            connect.Close();
            price = price * decimal.Parse(this.money.Text.Trim());
            this.money.Text = price.ToString("#.#").Trim();
        }

        /// <summary>
        /// 如果该会员能升级，则同意升级后升级会员
        /// </summary>
        private void VipUpgrade()
        {
            if (this.IsUpgrade())
            {
                if (MessageBox.Show("该会员已经达到升级的要求，是否要升级？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SqlConnection connect = InitConnect.GetConnection();
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("VipUpgrade",connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",this.vip.Text.Trim());
                    cmd.Parameters.AddWithValue("@date",DateTime.Parse(DateTime.Now.ToShortDateString()));
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
        }

        /// <summary>
        /// 确定交易
        /// </summary>
        private void SaleOk()
        {
            if (this.listView1.Items.Count != 0)
            {
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    SqlConnection connect = InitConnect.GetConnection();
                    connect.Open();
                    SqlCommand cmd = new SqlCommand("SaleWare", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag",this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
                    cmd.Parameters.AddWithValue("@id",this.listView1.Items[i].SubItems[1].Text.Trim());
                    cmd.Parameters.AddWithValue("@count",int.Parse(this.listView1.Items[i].SubItems[4].Text.Trim()));
                    cmd.Parameters.AddWithValue("@date",DateTime.Parse(DateTime.Now.ToShortDateString()));
                    cmd.Parameters.AddWithValue("@who",UserInfo.UserID);
                    cmd.Parameters.AddWithValue("@vip", this.yes.Checked ? this.vip.Text.Trim() : "");
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
                MessageBox.Show("恭喜您，交易成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                this.listView1.Items.Clear();
                this.money.Text = "0.0";
            }
            else
            {
                MessageBox.Show("没有购买任何商品无法交易！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void cancelsale_Click(object sender, EventArgs e)//取消交易
        {
            if (this.listView1.Items.Count != 0)
            {
                this.listView1.Items.Clear();
                this.CalculatePrice();
            }
            else
            {
                MessageBox.Show("您还没有交易任何商品！！！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void cancel_Click(object sender, EventArgs e)//取消购买
        {
            if (this.listView1.SelectedItems.Count!=0)
            {
                this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
                this.CalculatePrice();
            }
            else
            {
                MessageBox.Show("请选择要取消购买的商品！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void quit_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)//限制输入数量只能为整数
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 购买商品
        /// </summary>
        private void Sale()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.book.Checked)
            {
                cmd = new SqlCommand("select book_id,book_name,book_outprice from book_info where book_id=@id",connect);
            }
            else
            {
                cmd = new SqlCommand("select cd_id,cd_name,cd_outprice from cd_info where cd_id=@id",connect);
            }
            cmd.Parameters.AddWithValue("@id",this.id.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                bool exists = false;
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    if (this.listView1.Items[i].Text.Trim() == (this.book.Checked ? this.book.Text.Trim() : this.cd.Text.Trim()) && this.listView1.Items[i].SubItems[1].Text.Trim() == this.id.Text.Trim())
                    {
                        exists = true;
                        int allcount = int.Parse(this.listView1.Items[i].SubItems[4].Text.Trim()) + int.Parse(this.count.Text.Trim());
                        this.listView1.Items[i].SubItems[4].Text = allcount.ToString().Trim();
                        decimal allprice=int.Parse(this.listView1.Items[i].SubItems[4].Text.Trim())*decimal.Parse(this.listView1.Items[i].SubItems[3].Text.Trim());
                        this.listView1.Items[i].SubItems[5].Text = allprice.ToString().Trim();
                        break;
                    }
                }
                if (exists == false)
                {
                    ListViewItem item = this.listView1.Items.Add(this.book.Checked ? this.book.Text.Trim() : this.cd.Text.Trim());
                    item.SubItems.Add(read[0].ToString().Trim());
                    item.SubItems.Add(read[1].ToString().Trim());
                    item.SubItems.Add(read[2].ToString().Trim());
                    item.SubItems.Add(this.count.Text.Trim());
                    decimal price = int.Parse(this.count.Text.Trim()) * decimal.Parse(read[2].ToString().Trim());
                    item.SubItems.Add(price.ToString().Trim());
                }
            }
            read.Close();
            connect.Close();
            ////////////////////
            this.CalculatePrice();
        }

        /// <summary>
        /// 计算总的交易金额
        /// </summary>
        private void CalculatePrice()
        {
            decimal result=0;
            for (int i = 0; i < this.listView1.Items.Count; i++)
            {
                result = result + decimal.Parse(this.listView1.Items[i].SubItems[5].Text.Trim());
            }
            this.money.Text = result.ToString().Trim()!="0"?result.ToString().Trim():"0.0";
        }

        /// <summary>
        /// 是否超过库存数量
        /// </summary>
        /// <returns>true表示超过了库存量，false反之</returns>
        private bool IsOverCount(out int stocks)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.book.Checked)
            {
                cmd = new SqlCommand("select book_count from book_info where book_id=@id", connect);
            }
            else
            {
                cmd = new SqlCommand("select cd_count from cd_info where cd_id=@id",connect);
            }
            cmd.Parameters.AddWithValue("@id",this.id.Text.Trim());
            stocks = int.Parse(cmd.ExecuteScalar().ToString());
            connect.Close();
            return (stocks<int.Parse(this.count.Text.Trim()));
        }

        /// <summary>
        /// 判断商品是否存在
        /// </summary>
        private bool IsWareExists()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            if (this.book.Checked)
            {
                cmd = new SqlCommand("select count(*) from book_info where book_id=@id", connect);
            }
            else
            {
                cmd = new SqlCommand("select count(*) from cd_info where cd_id=@id",connect);
            }
            cmd.Parameters.AddWithValue("@id", this.id.Text.Trim());
            bool result = cmd.ExecuteScalar().ToString().Trim() != "0";
            connect.Close();
            return result;
        }

        private void ok_Click(object sender, EventArgs e)//确定
        {
            if (this.id.Text.Trim() != "")
            {
                if (this.IsWareExists())
                {
                    int stock;
                    if (!this.IsOverCount(out stock))
                    {
                        this.Sale();
                        this.id.Text = "";
                        this.id.Focus();
                    }
                    else
                    {
                        MessageBox.Show("对不起仓库只有" + stock.ToString().Trim() + "件商品了！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        this.count.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("对不起，不存在编号为\""+this.id.Text.Trim()+"\"的商品！！！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("请输入编号！！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.id.Focus();
            }
        }

        private void FrmSale_Load(object sender, EventArgs e)
        {
            this.count.SelectedIndex = 0;
        }

        private void computer_Click(object sender, EventArgs e)//会员金额计算
        {
            if (this.vipinfo.Text.Trim() != "")
            {
                this.GetCalculate();
            }
            else
            {
                MessageBox.Show("请输入有效的会员编号！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                this.vip.Focus();
            }
        }

        private void yes_CheckedChanged(object sender, EventArgs e)//会员购物
        {
            if (this.yes.Checked)
            {
                this.vip.Enabled = true;
                this.computer.Enabled = true;
                this.vip.Focus();
            }
        }

        private void no_CheckedChanged(object sender, EventArgs e)//普通人购物
        {
            if (this.no.Checked)
            {
                if (this.listView1.Items.Count != 0)
                {
                    this.CalculatePrice();
                }
                this.vip.Enabled = false;
                this.computer.Enabled = false;
                this.vip.Text = "";
            }
        }

        /// <summary>
        /// 显示会员信息
        /// </summary>
        private void DisplayVipInfo()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select vip.vip_id,vip.vip_name,vip.vip_style,vip_style.vipstyle_rebate from vip inner join vip_style on vip.vip_style=vip_style.vipstyle_name where vip.vip_id=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.vip.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.vipinfo.Text = "会员编号：" + this.vip.Text.Trim() + "；会员姓名：" + ((read["vip_name"].ToString().Trim() != "") ? read["vip_name"].ToString().Trim() : "无名") + "；会员类型：" + read["vip_style"].ToString() + "；会员优惠：" + read["vipstyle_rebate"].ToString().Trim() + "；";
            }
            else
            {
                this.vipinfo.Text = "";
            }
            read.Close();
            connect.Close();
        }

        private void vip_TextChanged(object sender, EventArgs e)//显示会员信息
        {
            this.DisplayVipInfo();
        }

        private void FrmSale_FormClosing(object sender, FormClosingEventArgs e)//关闭时清空ListView
        {
            this.listView1.Items.Clear();
        }
    }
}
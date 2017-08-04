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
    public partial class FmSaleIndex : Form
    {
        public FmSaleIndex()
        {
            InitializeComponent();
        }

        private void style_SelectedIndexChanged(object sender, EventArgs e)//选择不同的排行方式
        {
            if (this.style.Text.Trim() != "")
            {
                this.Display();
                this.result.Text = "共查询 " + this.index.Items.Count.ToString().Trim() + " 条记录；共销售商品数量 " + this.GetAllCount() + " 件；销售额共计 " + this.GetAllPrice() + " 元；利润额共计 " + this.GetAllGain() + " 元；";
            }
            else
            {
                this.index.Items.Clear();
                this.result.Text = "在此显示统计结果";
            }
        }


        /// <summary>
        /// 显示排行
        /// </summary>
        private void Display()
        {
            this.index.Items.Clear();
            //////////////////////////////////////////
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("SaleIndex",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ware",this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
            cmd.Parameters.AddWithValue("@flag",this.style.SelectedIndex);
            SqlDataReader read = cmd.ExecuteReader();
            int count = 1;
            while (read.Read())
            {
                ListViewItem item = this.index.Items.Add(read[0].ToString().Trim());
                for (int i = 1; i < read.FieldCount; i++)
                {
                    item.SubItems.Add(read[i].ToString().Trim());
                }
                item.SubItems.Add(count.ToString().Trim());
                count++;
            }
            read.Close();
            connect.Close();
        }

        /// <summary>
        /// 获取销售商品的数量
        /// </summary>
        private string GetAllCount()
        {
            int result = 0;
            for (int i = 0; i < this.index.Items.Count; i++)
            {
                result = result + int.Parse(this.index.Items[i].SubItems[1].Text.Trim());
            }
            return result.ToString().Trim();
        }

        /// <summary>
        /// 获取总销售额
        /// </summary>
        private string GetAllPrice()
        {
            decimal result = 0;
            for (int i = 0; i < this.index.Items.Count; i++)
            {
                result = result + decimal.Parse(this.index.Items[i].SubItems[2].Text.Trim());
            }
            return result.ToString().Trim();
        }

        /// <summary>
        /// 获取总利润额
        /// </summary>
        private string GetAllGain()
        {
            decimal result = 0;
            for (int i = 0; i < this.index.Items.Count; i++)
            {
                result = result + decimal.Parse(this.index.Items[i].SubItems[3].Text.Trim());
            }
            return result.ToString().Trim();
        }
    }
}
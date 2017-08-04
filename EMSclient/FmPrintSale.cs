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
    public partial class FmPrintSale : Form
    {
        public FmPrintSale()
        {
            InitializeComponent();
        }

        private void cancel_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)//确定
        {
            if (this.HaveData())
            {
                DateTime begindate = DateTime.Parse(this.date1.Value.ToShortDateString()) > DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString());
                DateTime enddate = DateTime.Parse(this.date1.Value.ToShortDateString()) < DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString());
                string ware = this.book.Checked ? this.book.Text.Trim() : this.cd.Text.Trim();
                PrintWareSale waresale = new PrintWareSale(begindate, enddate, ware);
                waresale.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 判断是否有数据可打印
        /// </summary>
        private bool HaveData()
        {
            if (this.book.Checked)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "PrintBookSale";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@date1", DateTime.Parse(this.date1.Value.ToShortDateString()) > DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString()));
                adapter.SelectCommand.Parameters.AddWithValue("@date2", DateTime.Parse(this.date1.Value.ToShortDateString()) < DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString()));
                data.Clear();
                adapter.Fill(data.book_sale);
                if (data.book_sale.DefaultView.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "PrintCdSale";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@date1", DateTime.Parse(this.date1.Value.ToShortDateString()) > DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString()));
                adapter.SelectCommand.Parameters.AddWithValue("@date2", DateTime.Parse(this.date1.Value.ToShortDateString()) < DateTime.Parse(this.date2.Value.ToShortDateString()) ? DateTime.Parse(this.date2.Value.ToShortDateString()) : DateTime.Parse(this.date1.Value.ToShortDateString()));
                data.Clear();
                adapter.Fill(data.cd_sale);
                if (data.cd_sale.DefaultView.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
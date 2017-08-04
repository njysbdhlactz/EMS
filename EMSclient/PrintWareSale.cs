using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace EMSclient
{
    public partial class PrintWareSale : Form
    {
        private DateTime begindate, enddate;
        private string ware;
        public PrintWareSale()
        {
            InitializeComponent();
        }

        public PrintWareSale(DateTime date1, DateTime date2, string paramware)
        {
            InitializeComponent();
            begindate = date1;
            enddate = date2;
            ware = paramware;
        }
        private void PrintWareSale_Load(object sender, EventArgs e)
        {
            if (ware.Trim() == "图书")
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "PrintBookSale";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@date1", begindate);
                adapter.SelectCommand.Parameters.AddWithValue("@date2", enddate);
                data.Clear();
                adapter.Fill(data.book_sale);
                PrintBookSale booksale = new PrintBookSale();
                booksale.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = booksale;
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
                adapter.SelectCommand.Parameters.AddWithValue("@date1", begindate);
                adapter.SelectCommand.Parameters.AddWithValue("@date2", enddate);
                data.Clear();
                adapter.Fill(data.cd_sale);
                PrintCdSale cdsale = new PrintCdSale();
                cdsale.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cdsale;
            }

        }
    }
}

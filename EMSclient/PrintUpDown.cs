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
    public partial class PrintUpDown : Form
    {
        private int flag;
        private string ware;
        public PrintUpDown()
        {
            InitializeComponent();
        }
        public PrintUpDown(int paramflag, string paramware)
        {
            InitializeComponent();
            flag = paramflag;
            ware = paramware;
        }
        private void PrintUpDown_Load(object sender, EventArgs e)
        {

            if (flag == 1 && ware == "图书")
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "WareUp";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Flag", 1);
                data.Clear();
                adapter.Fill(data.book_info);
                PrintBookUpDown bookup = new PrintBookUpDown();
                bookup.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = bookup;
            }
            else if (flag == 2 && ware == "光盘")
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "WareUp";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Flag", 2);
                data.Clear();
                adapter.Fill(data.cd_info);
                PrintCdUpDown cdup = new PrintCdUpDown();
                cdup.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cdup;
            }
            else if (flag == 3 && ware == "图书")
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "WareDown";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Flag", 1);
                data.Clear();
                adapter.Fill(data.book_info);
                PrintBookUpDown bookdown = new PrintBookUpDown();
                bookdown.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = bookdown;
            }
            else if (flag == 4 && ware == "光盘")
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand select = new SqlCommand();
                adapter.SelectCommand = select;
                adapter.SelectCommand.Connection = connect;
                adapter.SelectCommand.CommandText = "WareDown";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@Flag", 2);
                data.Clear();
                adapter.Fill(data.cd_info);
                PrintCdUpDown cddown = new PrintCdUpDown();
                cddown.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cddown;
            }
        }
    }
}

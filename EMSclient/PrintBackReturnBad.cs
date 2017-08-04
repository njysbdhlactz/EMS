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
    public partial class PrintBackReturnBad : Form
    {
        private int flag;
        public PrintBackReturnBad()
        {
            InitializeComponent();
        }
        public PrintBackReturnBad(int Flag)
        {
            InitializeComponent();
            flag = Flag;
        }

        private void PrintBackReturnBad_Load(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from bookbackprovider", connect);
                data.Clear();
                adapter.Fill(data.book_back);
                PrintBookBack bookback = new PrintBookBack();
                bookback.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = bookback;
            }
            else if (flag == 2)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from cdbackprovider", connect);
                data.Clear();
                adapter.Fill(data.cd_back);
                PrintCdBack cdback = new PrintCdBack();
                cdback.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cdback;
            }
            else if (flag == 3)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from bookreturnme", connect);
                data.Clear();
                adapter.Fill(data.book_return);
                PrintBookReturn bookreturn = new PrintBookReturn();
                bookreturn.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = bookreturn;
            }
            else if (flag == 4)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from cdreturnme", connect);
                data.Clear();
                adapter.Fill(data.cd_return);
                PrintCdReturn cdreturn = new PrintCdReturn();
                cdreturn.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cdreturn;
            }
            else if (flag == 5)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from bookbadme", connect);
                data.Clear();
                adapter.Fill(data.book_bad);
                PrintBookBad bookbad = new PrintBookBad();
                bookbad.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = bookbad;
            }
            else if (flag == 6)
            {
                SqlConnection connect = InitConnect.GetConnection();
                MyDataSet data = new MyDataSet();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from cdbadme", connect);
                data.Clear();
                adapter.Fill(data.cd_bad);
                PrintCdBad cdbad = new PrintCdBad();
                cdbad.SetDataSource(data);
                this.crystalReportViewer1.ReportSource = cdbad;
            }
        }
    }
}

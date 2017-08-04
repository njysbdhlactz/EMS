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
    public partial class FmBookBack : Form
    {
        public FmBookBack()
        {
            InitializeComponent();
        }

        private void FrmBookBack_Load(object sender, EventArgs e)//绑定DataGridView
        {
            this.BindBook(false);
            /////////////////////////////////////////////////
            if (this.dataGridView1.Rows.Count != 0)
            {
                this.count.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim();
            }
        }

        /// <summary>
        /// 绑定图书数据
        /// </summary>
        /// <param name="Flag">Flag为true表示绑定,为false表示查询</param>
        private void BindBook(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter book = new SqlDataAdapter("select * from bookinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            book.Fill(data,"bookinfo");
            source.DataSource = data;
            source.DataMember = "bookinfo";
            if (Flag)
            {
                source.Filter = "图书编号 like '%" + this.id.Text.Trim() + "%' and 图书名称 like '%" + this.name.Text.Trim() + "%' and 图书类型 like '%" + this.style.Text.Trim() + "%' and 出版社 like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%' and 书架 like '%" + this.bookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "图书名称 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        /// <summary>
        /// 绑定光盘数据
        /// </summary>
        /// <param name="Flag">Flag为true表示绑定,为false表示查询</param>
        private void BindCd(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter cd = new SqlDataAdapter("select * from cdinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            cd.Fill(data,"cdinfo");
            source.DataSource = data;
            source.DataMember = "cdinfo";
            if (Flag)
            {
                source.Filter = "光盘编号 like '%" + this.id.Text.Trim() + "%' and 光盘名称 like '%" + this.name.Text.Trim() + "%' and 光盘类型 like '%" + this.style.Text.Trim() + "%' and 出版社 like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%' and 书架 like '%" + this.bookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "光盘名称 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void all_CheckedChanged(object sender, EventArgs e)//图书退还全部
        {
            if (this.all.Checked)
            {
                this.count.Enabled = false;
            }
        }

        private void part_CheckedChanged(object sender, EventArgs e)//图书退还一部分
        {
            if (this.part.Checked)
            {
                this.count.Enabled = true;
                this.count.Focus();
            }
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)//限制退还数量只能输入数字
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        ///<summary>
        ///绑定商品类型
        ///</summary>
        ///<param name="param">param为true时绑定图书类型，为false绑定光盘类型</param>
        private void BindStyle(bool param)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (param)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='图书'",connect);
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

        ///<summary>
        ///绑定出版社
        ///</summary>
        ///<param name="param">param为true绑定图书出版社，为false绑定光盘出版社</param>
        private void BindPublish(bool param)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (param)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='图书'", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='光盘'", connect);
            }
            adapter.Fill(data, "publish");
            this.publish.DataSource = data.Tables["publish"];
            this.publish.DisplayMember = "publish_name";
            this.publish.ValueMember = "publish_name";
        }

        ///<summary>
        ///绑定书架
        ///</summary>
        private void BindBookcase()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase",connect);
            bookcase.Fill(data,"bookcase");
            this.bookcase.DataSource = data.Tables["bookcase"];
            this.bookcase.DisplayMember = "bookcase_place";
            this.bookcase.ValueMember = "bookcase_place";
        }

        private void button1_Click(object sender, EventArgs e)//图书信息查询
        {
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)//退还图书
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                string str;
                str = this.all.Checked ? "您确定把商品全部退还吗？" : "您确定要退还这" + this.count.Text.Trim() + "件商品吗？";
                if (MessageBox.Show(str, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.WareBack();
                }
            }
            else
            {
                MessageBox.Show("请选择要退还给供应商的商品！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }

        ///<summary>
        /// 把商品退还给供应商
        ///</summary>
        private void WareBack()
        {
            try
            {
                int.Parse(this.count.Text.Trim());
            }
            catch
            {
                MessageBox.Show("你输入的数字的格式不正确！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                return;
            }
            if (int.Parse(this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim()) < int.Parse(this.count.Text.Trim()))
            {
                MessageBox.Show("您输入的商品的数量大于该商品的库存量！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("WareBack", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@style",this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
            cmd.Parameters.AddWithValue("@id", this.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim());
            cmd.Parameters.AddWithValue("@code", this.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim());
            cmd.Parameters.AddWithValue("@count", int.Parse(this.count.Text.Trim()));
            cmd.Parameters.AddWithValue("@date",DateTime.Parse(DateTime.Now.ToShortDateString()));
            cmd.ExecuteNonQuery();
            connect.Close();
            /////////////////////////////////////////////////////////////////
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
            this.all.Checked = true;
            this.count.Enabled = false;
            this.count.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim();
        }

        private void style_DropDown(object sender, EventArgs e)//绑定商品类型
        {
            if (this.book.Checked)
            {
                this.BindStyle(true);
            }
            else
            {
                this.BindStyle(false);
            }
        }

        private void publish_DropDown(object sender, EventArgs e)//绑定出版社
        {
            if (this.book.Checked)
            {
                this.BindPublish(true);
            }
            else
            {
                this.BindPublish(false);
            }
        }

        private void bookcase_DropDown(object sender, EventArgs e)//绑定商品书架
        {
            this.BindBookcase();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)//显示库存量
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                if (this.book.Checked)
                {
                    this.count.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim();
                }
                else
                {
                    this.count.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString().Trim();
                }
            } 
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//双击显示详细信息
        {
            if (this.book.Checked)
            {
                if (this.dataGridView1.SelectedRows.Count != 0)
                {
                    FmBookInfo bookinfo = new FmBookInfo(true);
                    bookinfo.bookid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                    bookinfo.ShowDialog();
                }
            }
            else
            {
                if (this.dataGridView1.SelectedRows.Count != 0)
                {
                    FmCdInfo cdinfo = new FmCdInfo(true);
                    cdinfo.cdid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                    cdinfo.ShowDialog();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)//显示全部信息
        {
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
        }
    }
}
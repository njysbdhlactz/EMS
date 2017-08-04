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
    public partial class FmWareBad : Form
    {
        public FmWareBad()
        {
            InitializeComponent();
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
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
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_id=1", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_id=2", connect);
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
                adapter = new SqlDataAdapter("select * from publish where publish_style=1", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style=2", connect);
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
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase",connect);
            DataSet data = new DataSet();
            bookcase.Fill(data,"bookcase");
            this.bookcase.DataSource = data.Tables["bookcase"];
            this.bookcase.DisplayMember = "bookcase_place";
            this.bookcase.ValueMember = "bookcase_place";
        }

        /// <summary>
        /// 绑定图书信息
        /// </summary>
        private void BindBook(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter book = new SqlDataAdapter("select * from bookinfo", connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            data.Clear();
            book.Fill(data,"bookinfo");
            source.DataSource = data;
            source.DataMember = "bookinfo";
            if (!Flag)
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
        /// 绑定光盘信息
        /// </summary>
        private void BindCd(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter cd = new SqlDataAdapter("select * from cdinfo", connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            data.Clear();
            cd.Fill(data,"cdinfo");
            source.DataSource = data;
            source.DataMember = "cdinfo";
            if (!Flag)
            {
                source.Filter = "光盘编号 like %'" + this.id.Text.Trim() + "%' and 光盘名称 like '%" + this.name.Text.Trim() + "%' and 光盘类型 like '%" + this.style.Text.Trim() + "%' and 出版社 like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%' and 书架 like '%" + this.bookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "光盘名称 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void style_DropDown(object sender, EventArgs e)//显示商品类型
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

        private void publish_DropDown(object sender, EventArgs e)//显示商品出版社
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

        private void bookcase_DropDown(object sender, EventArgs e)//显示书架
        {
            this.BindBookcase();
        }

        private void query_Click(object sender, EventArgs e)//信息查询
        {
            if (this.book.Checked)
            {
                this.BindBook(false);
            }
            else
            {
                this.BindCd(false);
            }
        }

        private void all_Click(object sender, EventArgs e)//显示全部
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)//当选择不同时显示库存量
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                if (this.book.Checked)
                {
                    this.count.Text = this.dataGridView1.SelectedRows[0].Cells[11].Value.ToString().Trim();
                }
                else
                {
                    this.count.Text = this.dataGridView1.SelectedRows[0].Cells[10].Value.ToString().Trim();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//商品损坏
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                try
                {
                    int.Parse(this.count.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("您输入的数字的格式不正确！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.count.Focus();
                    return;
                }
                //////////////////////////////////////////////////
                if (int.Parse(this.count.Text.Trim()) > int.Parse(this.dataGridView1.SelectedRows[0].Cells[this.book.Checked ? 11 : 10].Value.ToString().Trim()))
                {
                    MessageBox.Show("仓库中没有这么多损坏的商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    this.WareBad();
                }
            }
            else
            {
                MessageBox.Show("请选择已经损坏的商品！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// 商品损坏
        /// </summary>
        private void WareBad()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("WareBad",connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@style",this.book.Checked?this.book.Text.Trim():this.cd.Text.Trim());
            cmd.Parameters.AddWithValue("@id", this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim());
            cmd.Parameters.AddWithValue("@code", this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString().Trim());
            cmd.Parameters.AddWithValue("@count", int.Parse(this.count.Text.Trim()));
            cmd.Parameters.AddWithValue("@memo", this.memo.Text.Trim());
            cmd.ExecuteNonQuery();
            connect.Close();
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
        }

        private void FrmWareBad_Load(object sender, EventArgs e)
        {
            this.BindBook(true);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//显示商品详细信息
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
    }
}
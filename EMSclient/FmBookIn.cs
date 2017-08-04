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
    public partial class FmBookIn : Form
    {
        public FmBookIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//�˳�
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//ѡ��ͬ��tabcontrolҳ
        {
            if (this.tabControl1.SelectedTab == this.book)
            {
                this.bookid.Focus();
            }
            else
            {
                this.cdid.Focus();
            }
        }

        /// <summary>
        /// �ж���Ʒ�����Ƿ����
        /// </summary>
        /// <param name="style">styleΪtrue��ʾͼ������,Ϊfalse��ʾ��������</param>
        /// <returns>Ϊtrue��ʾ����,�����ʾ������</returns>
        private bool IsBookStyleExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from book_style where bookstyle_name=@name and bookstyle_style=@style", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@name", this.bookstyle.Text.Trim());
                cmd.Parameters.AddWithValue("@style","ͼ��");
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", this.cdstyle.Text.Trim());
                cmd.Parameters.AddWithValue("@style","����");
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// �������Ƿ����
        /// </summary>
        /// <param name="style">styleΪtrue��ʾͼ�������,Ϊfalse��ʾ���̳�����</param>
        /// <returns>Ϊtrue��ʾ����,�����ʾ������</returns>
        private bool IsPublishExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from publish where publish_name=@name and publish_style=@style", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@name", this.bookpublish.Text.Trim());
                cmd.Parameters.AddWithValue("@style","ͼ��");
            }
            else
            {
                cmd.Parameters.AddWithValue("@name", this.cdpublish.Text.Trim());
                cmd.Parameters.AddWithValue("@style","����");
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// �������Ƿ����
        /// </summary>
        /// <param name="style">styleΪtrue��ʾͼ�����,Ϊfalse��ʾ�������</param>
        /// <returns>Ϊtrue��ʾ����,�����ʾ������</returns>
        private bool IsBookcaseExists(bool style)
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from bookcase where bookcase_place=@place", connect);
            if (style)
            {
                cmd.Parameters.AddWithValue("@place", this.bookcase.Text.Trim());
            }
            else
            {
                cmd.Parameters.AddWithValue("@place", this.cdcase.Text.Trim());
            }
            bool result = (cmd.ExecuteScalar().ToString().Trim() == "0");
            connect.Close();
            return result;
        }

        /// <summary>
        /// ������ͼ����Ϣ������ʷ��¼
        /// </summary>
        private void BookClear(bool Flag)
        {
            if (Flag)
            {
                this.bookid.Text = "";
            }
            this.bookcode.Text = "";
            this.bookstyle.Text = "";
            this.bookname.Text = "";
            this.bookauthor.Text = "";
            this.bookpublish.Text = "";
            this.bookisbn.Text = "";
            this.bookpage.Text = "";
            this.bookinprice.Text = "";
            this.bookoutprice.Text = "";
            this.bookcount.Text = "";
            this.bookcase.SelectedIndex = -1;
            this.bookmemo.Text = "";
            this.Height = 500;
            this.bookid.Focus();
        }

        /// <summary>
        /// ��ʽ��������Ϣ
        /// </summary>
        private string ErrorMessage(string error)
        {
            string result = error.Replace("checkbookprice","ͼ����۲��ܴ����ۼ�");
            result = result.Replace("checkcdprice","���̳����˲��ܴ����ۼ�");
            result = result.Replace("book_info","ͼ����Ϣ��");
            result = result.Replace("cd_info","������Ϣ��");
            return result;
        }

        private void button1_Click(object sender, EventArgs e)//ͼ�����
        {
            if (this.bookid.Text.Trim() != "" && this.bookcode.Text.Trim() != "" && this.bookstyle.Text.Trim() != "" && this.bookname.Text.Trim() != "" && this.bookisbn.Text.Trim() != "" && this.bookinprice.Text.Trim() != "" && this.bookoutprice.Text.Trim() != "" && this.bookcount.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (this.IsBookStyleExists(true))
                    {
                        if (MessageBox.Show("���������Ʒ��������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ������͵��뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into book_style(bookstyle_name,bookstyle_style) values(@style,'ͼ��')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@style", this.bookstyle.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsPublishExists(true))
                    {
                        if (MessageBox.Show("������ĳ�������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ��³����絼�뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into publish(publish_name,publish_style) values(@publish,'ͼ��')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@publish", this.bookpublish.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsBookcaseExists(true))
                    {
                        if (MessageBox.Show("������������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ�����ܵ��뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into bookcase(bookcase_place) values(@place)", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@place", this.bookcase.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("InsertBook", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.bookid.Text.Trim());
                    cmd.Parameters.AddWithValue("@code", this.bookcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", this.bookname.Text.Trim());
                    cmd.Parameters.AddWithValue("@style", this.bookstyle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", this.bookauthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish", this.bookpublish.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", this.bookisbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@inprice", decimal.Parse(this.bookinprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@outprice", decimal.Parse(this.bookoutprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@page", int.Parse(this.bookpage.Text.Trim()));
                    cmd.Parameters.AddWithValue("@bookcase", this.bookcase.Text.Trim());
                    cmd.Parameters.AddWithValue("@count", int.Parse(this.bookcount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(this.bookdate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@indate", DateTime.Parse(this.bookindate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@memo", this.bookmemo.Text.Trim());
                    cmd.Parameters.AddWithValue("@bookcdcase", this.yes.Checked ? this.bookcdcase.Text.Trim() : "");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("ͼ���Ѿ��ɹ���⣡", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (!bookadd.Checked)
                    {
                        this.Close();
                    }
                    this.BookClear(true);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("���ʧ�ܣ�\n������Ϣ��" + this.ErrorMessage(ee.Message), "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("��\"*\"��Ϊ������Ϣ������д������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// �󶨳�����
        /// </summary>
        /// <param name="style">styleΪtrue��ͼ��ĳ����磬Ϊfalse�󶨹��̵ĳ�����</param>
        private void BindPublish(bool style)//�󶨳�����
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (style)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='ͼ��'",connect);
                adapter.Fill(data,"publish");
                this.bookpublish.DataSource = data.Tables["publish"];
                this.bookpublish.DisplayMember = "publish_name";
                this.bookpublish.ValueMember = "publish_name";
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='����'",connect);
                adapter.Fill(data,"publish");
                this.cdpublish.DataSource = data.Tables["publish"];
                this.cdpublish.DisplayMember = "publish_name";
                this.cdpublish.ValueMember = "publish_name";
            }
        }

        /// <summary>
        /// ����Ʒ����
        /// </summary>
        /// <param name="style">styleΪtrue��ͼ������ͣ�Ϊfalse�󶨹��̵�����</param>
        private void BindBookStyle(bool style)//������
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (style)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='ͼ��'", connect);
                adapter.Fill(data,"book_style");
                this.bookstyle.DataSource = data.Tables["book_style"];
                this.bookstyle.DisplayMember = "bookstyle_name";
                this.bookstyle.ValueMember = "bookstyle_name";
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='����'",connect);
                adapter.Fill(data,"book_style");
                this.cdstyle.DataSource = data.Tables["book_style"];
                this.cdstyle.DisplayMember = "bookstyle_name";
                this.cdstyle.ValueMember = "bookstyle_name";
            }
        }

        private void BindBookcase(int style)//�����
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookcase = new SqlDataAdapter("select * from bookcase",connect);
            DataSet data = new DataSet();
            bookcase.Fill(data,"bookcase");
            if (style==1)
            {
                this.bookcase.DataSource = data.Tables["bookcase"];
                this.bookcase.DisplayMember = "bookcase_place";
                this.bookcase.ValueMember = "bookcase_place";
            }
            else if(style==2)
            {
                this.bookcdcase.DataSource = data.Tables["bookcase"];
                this.bookcdcase.DisplayMember = "bookcase_place";
                this.bookcdcase.ValueMember = "bookcase_place";
            }
            else
            {
                this.cdcase.DataSource = data.Tables["bookcase"];
                this.cdcase.DisplayMember = "bookcase_place";
                this.cdcase.ValueMember = "bookcase_place";
            }
        }

        private void bookstyle_DropDown(object sender, EventArgs e)//��ͼ������
        {
            this.BindBookStyle(true);
        }

        private void bookpublish_DropDown(object sender, EventArgs e)//�󶨳�����
        {
            this.BindPublish(true);
        }

        private void bookcase_DropDown(object sender, EventArgs e)//�����
        {
            this.BindBookcase(1);
        }

        private void bookcdcase_DropDown(object sender, EventArgs e)//�����(����)
        {
            this.BindBookcase(2);
        }

        private void cdstyle_DropDown(object sender, EventArgs e)//���̰���Ʒ����
        {
            this.BindBookStyle(false);
        }

        private void cdpublish_DropDown(object sender, EventArgs e)//���̰󶨳�����
        {
            this.BindPublish(false);
        }

        private void cdcase_DropDown(object sender, EventArgs e)//���̰����
        {
            this.BindBookcase(3);
        }

        /// <summary>
        /// ���������Ϣ������ʷ��Ϣ
        /// </summary>
        private void CdClear(bool Flag)
        {
            if (Flag)
            {
                this.cdid.Text = "";
            }
            this.cdcode.Text = "";
            this.cdstyle.Text = "";
            this.cdname.Text = "";
            this.cdauthor.Text = "";
            this.cdpublish.Text = "";
            this.cdisbn.Text = "";
            this.cdinprice.Text = "";
            this.cdoutprice.Text = "";
            this.cdcount.Text = "";
            this.cdcase.SelectedIndex = -1;
            this.cdmemo.Text = "";
            this.cdid.Focus();
        }

        private void button4_Click(object sender, EventArgs e)//�������
        {
            if (this.cdid.Text.Trim() != "" && this.cdcode.Text.Trim() != "" && this.cdstyle.Text.Trim() != "" && this.cdname.Text.Trim() != "" && this.cdisbn.Text.Trim() != "" && this.cdinprice.Text.Trim() != "" && this.cdoutprice.Text.Trim() != "" && this.cdcount.Text.Trim() != "")
            {
                SqlConnection connect = InitConnect.GetConnection();
                try
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    if (this.IsBookStyleExists(false))
                    {
                        if (MessageBox.Show("���������Ʒ��������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ������͵��뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into book_style(bookstyle_name,bookstyle_style) values(@style,'����')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@style", this.cdstyle.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsPublishExists(false))
                    {
                        if (MessageBox.Show("������ĳ�������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ��³����絼�뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into publish(publish_name,publish_style) values(@publish,'����')", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@publish", this.cdpublish.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (this.IsBookcaseExists(false))
                    {
                        if (MessageBox.Show("������������ϵͳ�в����ڣ��Ƿ�Ҫ�Ѹ�����ܵ��뵽ϵͳ�У�", "��Ϣ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("insert into bookcase(bookcase_place) values(@place)", connect);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@place", this.cdcase.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cmd = new SqlCommand("InsertCd", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim());
                    cmd.Parameters.AddWithValue("@code", this.cdcode.Text.Trim());
                    cmd.Parameters.AddWithValue("@name", this.cdname.Text.Trim());
                    cmd.Parameters.AddWithValue("@style", this.cdstyle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", this.cdauthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", this.cdisbn.Text.Trim());
                    cmd.Parameters.AddWithValue("@publish", this.cdpublish.Text.Trim());
                    cmd.Parameters.AddWithValue("@inprice", decimal.Parse(this.cdinprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@outprice", decimal.Parse(this.cdoutprice.Text.Trim()));
                    cmd.Parameters.AddWithValue("@bookcase", this.cdcase.SelectedValue.ToString().Trim());
                    cmd.Parameters.AddWithValue("@count", int.Parse(this.cdcount.Text.Trim()));
                    cmd.Parameters.AddWithValue("@date", DateTime.Parse(this.cddate.Text.Trim()));
                    cmd.Parameters.AddWithValue("@indate", DateTime.Parse(this.cddatein.Text.Trim()));
                    cmd.Parameters.AddWithValue("@memo", this.cdmemo.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("���̳ɹ���⣡", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (!cdadd.Checked)
                    {
                        this.Close();
                    }
                    this.CdClear(true);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("���ʧ�ܣ�\n������Ϣ��" + this.ErrorMessage(ee.Message), "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("��\"*\"��Ϊ������Ϣ������д������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void bookpage_KeyPress(object sender, KeyPressEventArgs e)//����ֻ����������
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void bookinprice_KeyPress(object sender, KeyPressEventArgs e)//�ж�ֻ�����븡����
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != '.')
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void yes_CheckedChanged(object sender, EventArgs e)//��ͼ����ڸ��ӹ���
        {
            if (this.yes.Checked)
            {
                this.bookcdcase.Enabled = true;
            }
            else
            {
                this.bookcdcase.Enabled = false;
            }
        }

        private void bookid_TextChanged(object sender, EventArgs e)//��ͬ��ŵ�ͼ���Զ���ʾ��ϸ��Ϣ
        {
            if (this.DisplayBookInfo())
            {
                this.bookshow.Visible = true;
                this.BindBook();
                this.DisplayBook();
            }
            else
            {
                this.bookshow.Visible = false;
            }
        }

        /// <summary>
        /// ��ʾͼ�����ϸ��Ϣ
        /// </summary>
        private void DisplayBook()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from book_info where book_id=@id",connect);
            cmd.Parameters.AddWithValue("@id",this.bookid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.bookcode.Text = read["book_code"].ToString().Trim();
                this.bookname.Text = read["book_name"].ToString().Trim();
                this.bookstyle.Text = read["book_style"].ToString().Trim();
                this.bookauthor.Text = read["book_author"].ToString().Trim();
                this.bookpublish.Text = read["book_publish"].ToString().Trim();
                this.bookisbn.Text = read["book_isbn"].ToString().Trim();
                this.bookpage.Text = read["book_page"].ToString().Trim();
                this.bookdate.Value = DateTime.Parse(read["book_date"].ToString().Trim());
                this.bookinprice.Text = read["book_inprice"].ToString().Trim();
                this.bookoutprice.Text = read["book_outprice"].ToString().Trim();
                this.bookcase.Text = read["book_bookcase"].ToString().Trim();
                this.bookindate.Value = DateTime.Parse(read["book_in"].ToString().Trim());
                this.bookmemo.Text = read["book_memo"].ToString().Trim();
                if (read["book_cd_case"].ToString().Trim() != "")
                {
                    this.yes.Checked = true;
                    this.bookcdcase.Enabled = true;
                    this.bookcdcase.Text = read["book_cd_case"].ToString().Trim();
                }
                else
                {
                    this.no.Checked = true;
                    this.bookcdcase.Enabled = false;
                }
            }
            else
            {
                this.BookClear(false);
            }
            read.Close();
            connect.Close();
        }

        BindingSource booksource;

        /// <summary>
        /// ��ʾͼ�����ϸ��Ϣ
        /// </summary>
        private void BindBook()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select book_id as ͼ����,book_code as ������,book_name as ͼ������,book_style as ͼ������,book_publish as ������,book_count as ����� from book_info", connect);
            data.Clear();
            adapter.Fill(data,"book_info");
            booksource = new BindingSource(data,"book_info");
            booksource.Filter = "ͼ���� like '" + this.bookid.Text.Trim() + "%'";
            this.bookshowinfo.DataSource = booksource;
        }

        /// <summary>
        /// ʲôʱ����ʾͼ����Ϣ
        /// </summary>
        /// <returns>true��ʾ��ʾ,��֮��ʾ����ʾ</returns>
        private bool DisplayBookInfo()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from book_info where book_id like @id",connect);
            cmd.Parameters.AddWithValue("@id",this.bookid.Text.Trim()+"%");
            int count = int.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return count > 0;
        }

        private void bookid_Leave(object sender, EventArgs e)//�뿪����ʱ����ͼ����Ϣ�б�
        {
            if (this.bookid.Text.Trim() != "")
            {
                this.bookshow.Visible = false;
                if (this.bookcode.Text.Trim() != "")
                {
                    this.bookcount.Focus();
                }
            }
        }

        private void FrmBookIn_Shown(object sender, EventArgs e)
        {
            this.bookid.Focus();
        }

        private void bookshowinfo_DoubleClick(object sender, EventArgs e)//˫��ͼ���б��е�ĳһ��¼
        {
            if (this.bookshowinfo.SelectedRows.Count != 0)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
        }

        private void cdid_TextChanged(object sender, EventArgs e)//��ͬ��ŵĹ�����ʾ��ϸ��Ϣ
        {
            if (this.DisplayCdInfo())
            {
                this.cdshow.Visible = true;
                this.BindCd();
                this.DisplayCd();
            }
            else
            {
                this.cdshow.Visible = false;
            }
        }

        /// <summary>
        /// ��ʾ���̵���ϸ��Ϣ
        /// </summary>
        private void DisplayCd()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from cd_info where cd_id=@id", connect);
            cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                this.cdcode.Text = read["cd_code"].ToString().Trim();
                this.cdname.Text = read["cd_name"].ToString().Trim();
                this.cdstyle.Text = read["cd_style"].ToString().Trim();
                this.cdauthor.Text = read["cd_author"].ToString().Trim();
                this.cdpublish.Text = read["cd_publish"].ToString().Trim();
                this.cdisbn.Text = read["cd_isbn"].ToString().Trim();
                this.cddate.Value = DateTime.Parse(read["cd_date"].ToString().Trim());
                this.cdinprice.Text = read["cd_inprice"].ToString().Trim();
                this.cdoutprice.Text = read["cd_outprice"].ToString().Trim();
                this.cdcase.Text = read["cd_bookcase"].ToString().Trim();
                this.cddatein.Value = DateTime.Parse(read["cd_in"].ToString().Trim());
                this.cdmemo.Text = read["cd_memo"].ToString().Trim();
            }
            else
            {
                this.CdClear(false);
            }
            read.Close();
            connect.Close();
        }

        BindingSource cdsource;

        /// <summary>
        /// ��ʾ���̵���ϸ��Ϣ
        /// </summary>
        private void BindCd()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select cd_id as ���̱��,cd_code as ������,cd_name as ��������,cd_style as ��������,cd_publish as ������,cd_count as ����� from cd_info", connect);
            data.Clear();
            adapter.Fill(data, "cd_info");
            cdsource = new BindingSource(data, "cd_info");
            cdsource.Filter = "���̱�� like '" + this.cdid.Text.Trim() + "%'";
            this.cdshowinfo.DataSource = cdsource;
        }

        /// <summary>
        /// ʲôʱ����ʾ������Ϣ
        /// </summary>
        /// <returns>true��ʾ��ʾ,��֮��ʾ����ʾ</returns>
        private bool DisplayCdInfo()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from cd_info where cd_id like @id", connect);
            cmd.Parameters.AddWithValue("@id", this.cdid.Text.Trim() + "%");
            int count = int.Parse(cmd.ExecuteScalar().ToString().Trim());
            connect.Close();
            return count > 0;
        }

        private void cdid_Leave(object sender, EventArgs e)//�뿪ʱ���ع����б�
        {
            if (this.cdid.Text.Trim() != "")
            {
                this.cdshow.Visible = false;
                if (this.cdcode.Text.Trim() != "")
                {
                    this.cdcount.Focus();
                }
            }
        }

        private void cdshowinfo_DoubleClick(object sender, EventArgs e)//˫��ʱѡ��ǰ�ļ�¼
        {
            if (this.cdshowinfo.SelectedRows.Count != 0)
            {
                this.cdid.Text = this.cdshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.cdshow.Visible = false;
            }
        }

        private void bookid_KeyDown(object sender, KeyEventArgs e)//��Enterѡ��ǰѡ���ͼ����Ϣ
        {
            if (e.KeyValue == 13 && this.bookshow.Visible == true)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
            else if (e.KeyValue == 38 && this.bookshow.Visible == true)
            {
                booksource.MovePrevious();
            }
            else if (e.KeyValue == 40 && this.bookshow.Visible == true)
            {
                booksource.MoveNext();
            }
        }

        private void cdid_KeyDown(object sender, KeyEventArgs e)//��Enterѡ��ǰѡ��Ĺ�����Ϣ
        {
            if (e.KeyValue == 13 && this.bookshow.Visible == true)
            {
                this.bookid.Text = this.bookshowinfo.SelectedRows[0].Cells[0].Value.ToString().Trim();
                this.bookshow.Visible = false;
            }
            else if (e.KeyValue == 38 && this.bookshow.Visible == true)
            {
                cdsource.MovePrevious();
            }
            else if (e.KeyValue == 40 && this.bookshow.Visible == true)
            {
                cdsource.MoveNext();
            }
        }

        private void bookalert_Click(object sender, EventArgs e)//����ͼ���б�
        {
            if (this.bookshow.Visible)
            {
                this.bookshow.Visible = false;
            }
            else
            {
                this.bookshow.Visible = true;
                this.BindBook();
                this.bookid.Focus();
            }
        }

        private void cdalert_Click(object sender, EventArgs e)//���������б�
        {
            if (this.cdshow.Visible)
            {
                this.cdshow.Visible = false;
            }
            else
            {
                this.cdshow.Visible = true;
                this.BindCd();
                this.cdid.Focus();
            }
        }
    }
}
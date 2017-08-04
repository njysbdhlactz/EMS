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
    public partial class FmQueryBook : Form
    {
        public FmQueryBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ����Ʒ����
        /// </summary>
        /// <param name="Flag">Ϊtrue��ʾ��ͼ������,Ϊfalse��ʾ�󶨹�������</param>
        private void BindStyle(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (Flag)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='ͼ��'",connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='����'", connect);
            }
            adapter.Fill(data, "book_style");
            style.DataSource = data.Tables["book_style"];
            style.DisplayMember = "bookstyle_name";
            style.ValueMember = "bookstyle_name";
        }

        /// <summary>
        /// ����Ʒλ��
        /// </summary>
        private void BindCase()
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter place = new SqlDataAdapter("select * from bookcase",connect);
            place.Fill(data,"bookcase");
            bookcase.DataSource = data.Tables["bookcase"];
            bookcase.DisplayMember = "bookcase_place";
            bookcase.ValueMember = "bookcase_place";
        }

        /// <summary>
        /// �󶨳�����
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��ͼ��ĳ�����,Ϊfalse��ʾ�󶨹��̳�����</param>
        private void BindPublish(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (Flag)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='ͼ��'",connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='����'", connect);
            }
            adapter.Fill(data, "publish");
            publish.DataSource = data.Tables["publish"];
            publish.DisplayMember = "publish_name";
            publish.ValueMember = "publish_name";
        }

        /// <summary>
        /// ��ͼ����Ϣ
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��������ͼ����Ϣ,false��ʾ��ѯͼ����Ϣ</param>
        private void BindBook(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter bookinfo = new SqlDataAdapter("select ͼ����,������,ͼ������,ͼ������,����,������,ISBN,�ۼ�,ҳ��,���,�����,����ʱ��,���ʱ��,ͼ����,����������� from bookinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            bookinfo.Fill(data,"bookinfo");
            source.DataSource = data;
            source.DataMember = "bookinfo";
            if (!Flag)
            {
                source.Filter = "ͼ���� like '%" + this.id.Text.Trim() + "%' and ������ like '%" + this.code.Text.Trim() + "%' and ͼ������ like '%" + this.name.Text.Trim() + "%' and ͼ������ like '%" + this.style.Text.Trim() + "%' and ���� like '%" + this.author.Text.Trim() + "%' and ��� like '%" + this.bookcase.Text.Trim() + "%' and ������ like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "ͼ���� like '%'";
            }
            this.dataGridView1.DataSource = source; 
        }

        /// <summary>
        /// �󶨹�����Ϣ
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ�������ع�����Ϣ,false��ʾ��ѯ������Ϣ</param>
        private void BindCd(bool Flag)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter cdinfo = new SqlDataAdapter("select ���̱��,������,��������,��������,����,������,ISBN,�ۼ�,���,�����,����ʱ��,���ʱ��,���̼�� from cdinfo",connect);
            DataSet data = new DataSet();
            BindingSource source = new BindingSource();
            cdinfo.Fill(data,"cdinfo");
            source.DataSource = data;
            source.DataMember = "cdinfo";
            if (!Flag)
            {
                source.Filter = "���̱�� like '%" + this.id.Text.Trim() + "%' and ������ like '%" + this.code.Text.Trim() + "%' and �������� like '%" + this.name.Text.Trim() + "%' and �������� like '%" + this.style.Text.Trim() + "%' and ���� like '%" + this.author.Text.Trim() + "%' and ��� like '%" + this.bookcase.Text.Trim() + "%' and ������ like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "���̱�� like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        /// <summary>
        /// ��ʾͼ�����ϸ��Ϣ
        /// </summary>
        private void DisplayBookInfo()
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                FmBookInfo bookinfo = new FmBookInfo(false);
                bookinfo.bookid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                bookinfo.ShowDialog();
            }
        }

        /// <summary>
        /// ��ʾ���̵���ϸ��Ϣ
        /// </summary>
        private void DisplayCdInfo()
        {
            if (this.dataGridView1.SelectedRows.Count != 0)
            {
                FmCdInfo cdinfo = new FmCdInfo(false);
                cdinfo.cdid.Text = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
                cdinfo.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)//��ѯ
        {
            if (this.book.Checked)
            {
                this.BindBook(false);
            }
            else
            {
                this.BindCd(false);
            }
            this.timer1.Enabled = true;
        }

        private void style_DropDown(object sender, EventArgs e)//������
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

        private void bookcase_DropDown(object sender, EventArgs e)//�����
        {
            this.BindCase();
        }

        private void publish_DropDown(object sender, EventArgs e)//�󶨳�����
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

        private void button3_Click(object sender, EventArgs e)//��ʾȫ��
        {
            if (this.book.Checked)
            {
                this.BindBook(true);
            }
            else
            {
                this.BindCd(true);
            }
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)//��ʾ��ѯ���
        {
            if (this.Height > 590)
            {
                this.timer1.Enabled = false;
            }
            else
            {
                this.Height = this.Height + 10;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//��ʾ��ϸ��Ϣ
        {
            if (this.book.Checked)
            {
                this.DisplayBookInfo();
            }
            else
            {
                this.DisplayCdInfo();
            }
        }
    }
}
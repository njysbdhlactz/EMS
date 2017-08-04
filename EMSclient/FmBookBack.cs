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

        private void FrmBookBack_Load(object sender, EventArgs e)//��DataGridView
        {
            this.BindBook(false);
            /////////////////////////////////////////////////
            if (this.dataGridView1.Rows.Count != 0)
            {
                this.count.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim();
            }
        }

        /// <summary>
        /// ��ͼ������
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��,Ϊfalse��ʾ��ѯ</param>
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
                source.Filter = "ͼ���� like '%" + this.id.Text.Trim() + "%' and ͼ������ like '%" + this.name.Text.Trim() + "%' and ͼ������ like '%" + this.style.Text.Trim() + "%' and ������ like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%' and ��� like '%" + this.bookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "ͼ������ like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        /// <summary>
        /// �󶨹�������
        /// </summary>
        /// <param name="Flag">FlagΪtrue��ʾ��,Ϊfalse��ʾ��ѯ</param>
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
                source.Filter = "���̱�� like '%" + this.id.Text.Trim() + "%' and �������� like '%" + this.name.Text.Trim() + "%' and �������� like '%" + this.style.Text.Trim() + "%' and ������ like '%" + this.publish.Text.Trim() + "%' and ISBN like '%" + this.isbn.Text.Trim() + "%' and ��� like '%" + this.bookcase.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "�������� like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void all_CheckedChanged(object sender, EventArgs e)//ͼ���˻�ȫ��
        {
            if (this.all.Checked)
            {
                this.count.Enabled = false;
            }
        }

        private void part_CheckedChanged(object sender, EventArgs e)//ͼ���˻�һ����
        {
            if (this.part.Checked)
            {
                this.count.Enabled = true;
                this.count.Focus();
            }
        }

        private void count_KeyPress(object sender, KeyPressEventArgs e)//�����˻�����ֻ����������
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')
            {
                if (e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)//�ر�
        {
            this.Close();
        }

        ///<summary>
        ///����Ʒ����
        ///</summary>
        ///<param name="param">paramΪtrueʱ��ͼ�����ͣ�Ϊfalse�󶨹�������</param>
        private void BindStyle(bool param)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (param)
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='ͼ��'",connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from book_style where bookstyle_style='����'", connect);
            }
            adapter.Fill(data, "book_style");
            this.style.DataSource = data.Tables["book_style"];
            this.style.DisplayMember = "bookstyle_name";
            this.style.ValueMember = "bookstyle_name";
        }

        ///<summary>
        ///�󶨳�����
        ///</summary>
        ///<param name="param">paramΪtrue��ͼ������磬Ϊfalse�󶨹��̳�����</param>
        private void BindPublish(bool param)
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet data = new DataSet();
            if (param)
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='ͼ��'", connect);
            }
            else
            {
                adapter = new SqlDataAdapter("select * from publish where publish_style='����'", connect);
            }
            adapter.Fill(data, "publish");
            this.publish.DataSource = data.Tables["publish"];
            this.publish.DisplayMember = "publish_name";
            this.publish.ValueMember = "publish_name";
        }

        ///<summary>
        ///�����
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

        private void button1_Click(object sender, EventArgs e)//ͼ����Ϣ��ѯ
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

        private void button2_Click(object sender, EventArgs e)//�˻�ͼ��
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                string str;
                str = this.all.Checked ? "��ȷ������Ʒȫ���˻���" : "��ȷ��Ҫ�˻���" + this.count.Text.Trim() + "����Ʒ��";
                if (MessageBox.Show(str, "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.WareBack();
                }
            }
            else
            {
                MessageBox.Show("��ѡ��Ҫ�˻�����Ӧ�̵���Ʒ��","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
        }

        ///<summary>
        /// ����Ʒ�˻�����Ӧ��
        ///</summary>
        private void WareBack()
        {
            try
            {
                int.Parse(this.count.Text.Trim());
            }
            catch
            {
                MessageBox.Show("����������ֵĸ�ʽ����ȷ��","����",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                return;
            }
            if (int.Parse(this.dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim()) < int.Parse(this.count.Text.Trim()))
            {
                MessageBox.Show("���������Ʒ���������ڸ���Ʒ�Ŀ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
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

        private void style_DropDown(object sender, EventArgs e)//����Ʒ����
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

        private void bookcase_DropDown(object sender, EventArgs e)//����Ʒ���
        {
            this.BindBookcase();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)//��ʾ�����
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//˫����ʾ��ϸ��Ϣ
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

        private void button4_Click(object sender, EventArgs e)//��ʾȫ����Ϣ
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
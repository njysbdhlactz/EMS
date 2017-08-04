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
    public partial class FmBookcase : Form
    {
        public FmBookcase()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private SqlDataAdapter bookcase = new SqlDataAdapter();
        private BindingSource source = new BindingSource();

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            bookcase.SelectCommand = select;
            bookcase.SelectCommand.Connection = connect;
            bookcase.SelectCommand.CommandText = "select bookcase_place as 书架位置 from bookcase where 1=0";
            //////////////////////////////////////////////////////////
            bookcase.InsertCommand = insert;
            bookcase.InsertCommand.Connection = connect;
            bookcase.InsertCommand.CommandText = "insert into bookcase(bookcase_place) values(@place)";
            bookcase.InsertCommand.Parameters.Add("@place",SqlDbType.VarChar,0,"书架位置");
            //////////////////////////////////////////////////////////
            bookcase.DeleteCommand = delete;
            bookcase.DeleteCommand.Connection = connect;
            bookcase.DeleteCommand.CommandText = "delete bookcase where bookcase_place=@place";
            bookcase.DeleteCommand.Parameters.Add("@place",SqlDbType.VarChar,0,"书架位置");
            //////////////////////////////////////////////////////////
            bookcase.Fill(data,"bookcase");
            source.DataSource = data;
            source.DataMember = "bookcase";
            this.dataGridView1.DataSource = source;
            ///////////////////////////////////////////////////////////
            this.place.DataBindings.Add("Text",source,"书架位置",true);
        }

        private void FrmBookcase_Load(object sender, EventArgs e)//绑定DataGridView
        {
            this.InitData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//第一条
        {
            source.MoveFirst();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//上一条
        {
            source.MovePrevious();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)//下一条
        {
            source.MoveNext();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//最后一条
        {
            source.MoveLast();
        }

        private void ToolButtonEnabled(bool Flag)
        {
            if (Flag)
            {
                this.toolStripButton5.Enabled = false;
                this.toolStripButton7.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
                this.place.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                ///////////////////////////////////////
                this.place.Enabled = false;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            this.ToolButtonEnabled(true);
            //////////////////////////////////////////////////////
            source.AddNew();
            this.place.Focus();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
                /////////////////////////////////////////////////////////////
                this.toolStripButton5.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
            }
            else
            {
                MessageBox.Show("没有可删除的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        /// <summary>
        /// 返回格式化后的错误信息
        /// </summary>
        /// <param name="message">系统的错误信息</param>
        /// <returns>格式化后的错误信息</returns>
        private string ErrorMessage(string message)
        {
            string result = message.Replace("bookcase", "书架表");
            result = result.Replace("bookcase_key","列\"书架编号\"不能存在相同的值");
            result = result.Replace("bookcase_place", "书架位置");
            result = result.Replace("NULL", "\"空值\"");
            result = result.Replace("INSERT", "添加");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
        {
            try
            {
                if (this.place.Text.Trim() != ""||this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    bookcase.Update(data, "bookcase");
                    ///////////////////////////////////////////////////////
                    this.ToolButtonEnabled(false);
                }
                else
                {
                    if (!this.toolStripButton7.Enabled)
                    {
                        MessageBox.Show("带\"*\"的为必填信息，请填写完整！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("错误："+this.ErrorMessage(ee.Message),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)//取消
        {
            source.CancelEdit();
            data.RejectChanges();
            //////////////////////////////////////////////////////////
            this.ToolButtonEnabled(false);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        /// <summary>
        /// 显示所有信息或查询信息
        /// </summary>
        /// <param name="Flag">Flag为true表示显示所有信息，为false表示查询信息</param>
        private void DisplayAll(bool Flag)
        {
            data.Clear();
            bookcase.SelectCommand.CommandText = "select bookcase_place as 书架位置 from bookcase";
            bookcase.Fill(data,"bookcase");
            source.DataSource = data;
            source.DataMember = "bookcase";
            if (!Flag)
            {
                source.Filter = "书架位置 like '%"+this.queryplace.Text.Trim()+"%'";
            }
            else
            {
                source.Filter = "书架位置 like '%'";
            }
            this.dataGridView1.DataSource = source;
        }

        private void button1_Click(object sender, EventArgs e)//查询
        {
            this.DisplayAll(false);
        }

        private void button2_Click(object sender, EventArgs e)//显示全部
        {
            this.DisplayAll(true);
        }
    }
}
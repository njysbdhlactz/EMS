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
    public partial class FmUserPower : Form
    {
        public FmUserPower()
        {
            InitializeComponent();
        }

        private void userstyle_SelectedIndexChanged(object sender, EventArgs e)//选择不同的用户
        {
            this.ShowUserName();
            this.ShowPower();
        }

        private void BindUserStyle()//绑定用户类型
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlDataAdapter book_user = new SqlDataAdapter("select * from user_style", connect);
            DataSet data = new DataSet();
            data.Clear();
            book_user.Fill(data, "user_style");
            this.userstyle.DataSource = data.Tables["user_style"];
            this.userstyle.DisplayMember = "userstyle_name";
            this.userstyle.ValueMember = "userstyle_name";
        }

        private void ShowUserName()//显示该类型的用户
        {
            SqlConnection connect = InitConnect.GetConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand select = new SqlCommand();
            adapter.SelectCommand = select;
            adapter.SelectCommand.Connection = connect;
            adapter.SelectCommand.CommandText = "select user_id from book_user where user_style=@style";
            adapter.SelectCommand.Parameters.AddWithValue("@style", userstyle.Text.Trim());
            data.Clear();
            adapter.Fill(data, "book_user");
            this.username.DataSource = data.Tables["book_user"];
            this.username.DisplayMember = "user_id";
            this.username.ValueMember = "user_id";
        }

        private void ShowPower()//列出用户的权限
        {
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemCheckState(i,CheckState.Unchecked);
            }
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from power where power_style=@style", connect);
            cmd.Parameters.AddWithValue("@style", this.userstyle.Text.Trim());
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
                {
                    if (this.checkedListBox1.Items[i].ToString().Trim() == read["power_name"].ToString().Trim())
                    {
                        this.checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                        break;
                    }
                }
            }
            read.Close();
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)//退出
        {
            this.Close();
        }

        private void userstyle_DropDown(object sender, EventArgs e)//下拉时绑定
        {
            this.BindUserStyle();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)//设置权限
        {
            if (this.checkedListBox1.SelectedIndex != -1)
            {
                SqlConnection connect = InitConnect.GetConnection();
                connect.Open();
                SqlCommand cmd = new SqlCommand();
                if (this.checkedListBox1.GetItemCheckState(this.checkedListBox1.SelectedIndex) == CheckState.Checked)
                {
                    cmd = new SqlCommand("delete power where power_style=@style and power_name=@name", connect);
                }
                else if (this.checkedListBox1.GetItemCheckState(this.checkedListBox1.SelectedIndex) == CheckState.Unchecked)
                {
                    cmd = new SqlCommand("insert into power(power_style,power_name) values(@style,@name)", connect); 
                }
                cmd.Parameters.AddWithValue("@style", userstyle.Text.Trim());
                cmd.Parameters.AddWithValue("@name", this.checkedListBox1.SelectedItem.ToString().Trim());
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }
    }
}
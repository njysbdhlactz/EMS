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
    public partial class FmVipStyle : Form
    {
        public FmVipStyle()
        {
            InitializeComponent();
        }

        private DataSet data = new DataSet();
        private BindingSource source = new BindingSource();
        private SqlDataAdapter vip_style = new SqlDataAdapter();

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            SqlCommand select = new SqlCommand();
            SqlCommand insert = new SqlCommand();
            SqlCommand update = new SqlCommand();
            SqlCommand delete = new SqlCommand();
            vip_style.SelectCommand = select;
            vip_style.SelectCommand.Connection = connect;
            vip_style.SelectCommand.CommandText = "select vipstyle_name as 会员类型,vipstyle_rebate as 优惠政策,vipstyle_request as 升级要求,vipstyle_level as 会员级别 from vip_style where 1=0";
            ///////////////////////////////////////////////////////////////
            vip_style.InsertCommand = insert;
            vip_style.InsertCommand.Connection = connect;
            vip_style.InsertCommand.CommandText = "insert into vip_style(vipstyle_name,vipstyle_rebate,vipstyle_request,vipstyle_level) values(@name,@rebate,@request,@level)";
            vip_style.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "会员类型");
            vip_style.InsertCommand.Parameters.Add("@rebate", SqlDbType.Decimal, 0, "优惠政策");
            vip_style.InsertCommand.Parameters.Add("@request", SqlDbType.Decimal, 0, "升级要求");
            vip_style.InsertCommand.Parameters.Add("@level", SqlDbType.Int, 0, "会员级别");
            ///////////////////////////////////////////////////////////////////
            vip_style.UpdateCommand = update;
            vip_style.UpdateCommand.Connection = connect;
            vip_style.UpdateCommand.CommandText = "update vip_style set vipstyle_rebate=@rebate,vipstyle_request=@request where vipstyle_name=@name";
            vip_style.UpdateCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "会员类型");
            vip_style.UpdateCommand.Parameters.Add("@rebate", SqlDbType.Decimal, 0, "优惠政策");
            vip_style.UpdateCommand.Parameters.Add("@request", SqlDbType.Decimal, 0, "升级要求");
            ////////////////////////////////////////////////////////////////////////////////////
            vip_style.DeleteCommand = delete;
            vip_style.DeleteCommand.Connection = connect;
            vip_style.DeleteCommand.CommandText = "delete vip_style where vipstyle_name=@name";
            vip_style.DeleteCommand.Parameters.Add("@name", SqlDbType.VarChar, 0, "会员类型");
            ///////////////////////////////////////////////////////////////////////
            vip_style.Fill(data, "vip_style");
            source.DataSource = data;
            source.DataMember = "vip_style";
            this.dataGridView1.DataSource = source;
            /////////////////////////////////////////////////////////////////////////////////
            this.style.DataBindings.Add("Text", source, "会员类型", true);
            this.request.DataBindings.Add("Text", source, "升级要求", true);
            this.rebate.DataBindings.Add("Text", source, "优惠政策", true);
            this.level.DataBindings.Add("Text", source, "会员级别", true);
        }

        private void FrmVipStyle_Load(object sender, EventArgs e)//初始化
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
                this.toolStripButton6.Enabled = false;
                this.toolStripButton7.Enabled = false;
                this.toolStripButton8.Enabled = true;
                this.toolStripButton9.Enabled = true;
                this.request.Enabled = true;
                this.rebate.Enabled = true;
                this.level.Enabled = true;
            }
            else
            {
                this.toolStripButton5.Enabled = true;
                this.toolStripButton6.Enabled = true;
                this.toolStripButton7.Enabled = true;
                this.toolStripButton8.Enabled = false;
                this.toolStripButton9.Enabled = false;
                ////////////////////////////////////////
                this.style.Enabled = false;
                this.request.Enabled = false;
                this.rebate.Enabled = false;
                this.level.Enabled = false;
                this.InitLevel();
                this.InitRebate();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)//添加
        {
            source.AddNew();
            this.style.Enabled = true;
            ////////////////////////////////////////////////
            this.ToolButtonEnabled(true);
            this.style.Focus();
            this.level.Items.Clear();
            this.rebate.Items.Clear();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//修改
        {
            if (source.Position != -1)
            {
                this.style.Enabled = false;
                ////////////////////////////////////////////
                this.ToolButtonEnabled(true);
                this.request.Focus();
            }
            else
            {
                MessageBox.Show("没有可修改的记录！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
        {
            if (source.Position != -1)
            {
                source.RemoveAt(source.Position);
                this.toolStripButton5.Enabled = false;
                this.toolStripButton6.Enabled = false;
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
            string result = message.Replace("vip_style_key", "列\"会员类型\"不能存在相同的值");
            result = result.Replace("vipstyle_request", "升级要求");
            result = result.Replace("vipstyle_rebate", "优惠政策");
            result = result.Replace("vipstyle_name", "会员类型");
            result = result.Replace("vipstyle_level", "会员级别");
            result = result.Replace("vip_style", "会员类型表");
            result = result.Replace("INSERT", "添加");
            result = result.Replace("NULL", "\"空值\"");
            return result;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)//更新
        {
            try
            {
                if (this.style.Text.Trim() != "" && this.request.Text.Trim() != "" && this.level.Text.Trim() != "" && this.rebate.Text.Trim() != "" || this.toolStripButton7.Enabled)
                {
                    source.EndEdit();
                    vip_style.Update(data, "vip_style");
                    //////////////////////////////////////////
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
                MessageBox.Show("错误：" + this.ErrorMessage(ee.Message), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)//取消
        {
            this.ToolButtonEnabled(false);
            /////////////////////////////////////////////////////
            source.CancelEdit();
            data.RejectChanges();
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
            vip_style.SelectCommand.CommandText = "select vipstyle_name as 会员类型,vipstyle_rebate as 优惠政策,vipstyle_request as 升级要求,vipstyle_level as 会员级别 from vip_style";
            vip_style.Fill(data, "vip_style");
            source.DataSource = data;
            source.DataMember = "vip_style";
            if (!Flag)
            {
                source.Filter = "会员类型 like '%" + this.query.Text.Trim() + "%'";
            }
            else
            {
                source.Filter = "会员类型 like '%'";
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

        private void request_KeyPress(object sender, KeyPressEventArgs e)//限制只能输入数字
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
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

        /// <summary>
        /// 当添加或修改时自动设置会员可用的级别
        /// </summary>
        private void SetLevel()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("SetVipLevel", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = cmd.ExecuteReader();
            this.level.Items.Clear();
            if (this.style.Enabled==false)
            {
                this.level.Items.Add(((DataRowView)source.Current).Row.ItemArray[3].ToString().Trim());
            }
            while (read.Read())
            {
                this.level.Items.Add(read["viplevel"].ToString().Trim());
            }
            read.Close();
            connect.Close();
        }

        /// <summary>
        /// 添加或修改时自动设置会员可用的优惠政策
        /// </summary>
        private void SetRebate()
        {
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("SetVipRebate", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            if (this.style.Enabled == false)
            {
                cmd.Parameters.AddWithValue("@rebate", decimal.Parse(((DataRowView)source.Current).Row.ItemArray[1].ToString().Trim()));
            }
            else
            {
                cmd.Parameters.AddWithValue("@rebate",1);
            }
            SqlDataReader read = cmd.ExecuteReader();
            this.rebate.Items.Clear();
            if (this.style.Enabled == false)
            {
                this.rebate.Items.Add(((DataRowView)source.Current).Row.ItemArray[1].ToString().Trim());
            }
            while (read.Read())
            {
                this.rebate.Items.Add(read["rebate"].ToString().Trim());
            }
            read.Close();
            connect.Close();
        }

        /// <summary>
        /// 设置优惠政策到初始状态
        /// </summary>
        private void InitRebate()
        {
            this.rebate.Items.AddRange(new object[] { "0.95", "0.90", "0.85", "0.80", "0.75", "0.70", "0.65", "0.60", "0.55", "0.50", "0.45", "0.40", "0.35", "0.30", "0.25", "0.20", "0.15", "0.10" });
        }

        /// <summary>
        /// 设置会员级别到初始状态
        /// </summary>
        private void InitLevel()
        {
            this.level.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        }

        private void level_DropDown(object sender, EventArgs e)//显示可以设置的会员级别
        {
            this.SetLevel();
        }

        private void rebate_DropDown(object sender, EventArgs e)//显示可以设置的优惠政策
        {
            this.SetRebate();
        }
    }
}
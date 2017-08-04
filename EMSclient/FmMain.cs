using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.IO;

namespace EMSclient
{
    public partial class FmMain : Form
    {
        public FmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置用户的权限
        /// </summary>
        private void SetUserPower()
        {
            this.button1.Enabled = false;
            this.menublock1.Enabled = false;
            this.button2.Enabled = false;
            this.menublock2.Enabled = false;
            this.button3.Enabled = false;
            this.menublock3.Enabled = false;
            this.button4.Enabled = false;
            this.menublock4.Enabled = false;
            this.button5.Enabled = false;
            this.menublock5.Enabled = false;
            this.button6.Enabled = false;
            this.menublock6.Enabled = false;
            /////////////////////////////////////////////////////////////////////////////////////////
            SqlConnection connect = InitConnect.GetConnection();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from power where power_style=@style", connect);
            cmd.Parameters.AddWithValue("@style", UserInfo.UserPower);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                if (read["power_name"].ToString().Trim() == "系统设置")
                {
                    this.button1.Enabled = true;
                    this.menublock1.Enabled = true;
                }
                else if (read["power_name"].ToString().Trim() == "基本资料维护")
                {
                    this.button2.Enabled = true;
                    this.menublock2.Enabled = true;
                }
                else if (read["power_name"].ToString().Trim() == "采购管理")
                {
                    this.button3.Enabled = true;
                    this.menublock3.Enabled = true;
                }
                else if (read["power_name"].ToString().Trim() == "销售管理")
                {
                    this.button4.Enabled = true;
                    this.menublock4.Enabled = true;
                }
                else if (read["power_name"].ToString().Trim() == "库存管理")
                {
                    this.button5.Enabled = true;
                    this.menublock5.Enabled = true;
                }
                else if (read["power_name"].ToString().Trim() == "系统数据管理")
                {
                    this.button6.Enabled = true;
                    this.menublock6.Enabled = true;
                }
            }
            read.Close();
            connect.Close();
        }
        /// <summary>
        /// 打开窗体,不重复
        /// </summary>
        /// <param name="form">要打开的窗体</param>
        private void ReForm(string title, object form)
        {
            bool exists = false;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Text.Trim() == title.Trim())
                {
                    exists = true;
                    if (this.MdiChildren[i].WindowState == FormWindowState.Minimized)
                    {
                        this.MdiChildren[i].WindowState = FormWindowState.Normal;
                    }
                    this.MdiChildren[i].Activate();
                    break;
                }
            }
            if (exists == false)
            {
                Form temp = (Form)Activator.CreateInstance(form.GetType());
                temp.MdiParent = this;
                temp.Show();

            }
        }


        private void splitContainer1_Panel1_Resize_1(object sender, EventArgs e)//当窗体大小改变时要改变导航的大小
        {
            for (int i = 0; i < this.splitContainer1.Panel1.Controls.Count; i++)
            {
                if (this.splitContainer1.Panel1.Controls[i] is Panel)
                {
                    if ((this.splitContainer1.Panel1.Controls[i] as Panel).Visible)
                    {
                        (this.splitContainer1.Panel1.Controls[i] as Panel).Height = this.Height - this.button7.Height * (this.splitContainer1.Panel1.Controls.Count / 2) - 144;
                    }
                }
            }
        }

        private void 系统初始化IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmInit init = new FmInit();
            this.ReForm(init.Text, init);
        }

        /// <summary>
        /// 检查是否有越界商品,如果有弹出警告窗口
        /// </summary>
        private void CheckWareUpDown()
        {
            if (InitConnect.GetWareDown(true) != "0" || InitConnect.GetWareDown(false) != "0" || InitConnect.GetWareUp(true) != "0" || InitConnect.GetWareUp(false) != "0")
            {
                FmWarning warning = new FmWarning();
                warning.Show();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.SetUserPower();
            //////////////////////////////////////////////////////////////////
            this.CheckWareUpDown();
            ///////////////////////////////////////////////////////////////////////
            this.timer1.Enabled = true;
            this.toolStripStatusLabel2.Text = "     用户类型：" + UserInfo.UserPower + "     ";
            this.toolStripStatusLabel3.Text = "     用户名称：" + UserInfo.UserID + "     ";
            this.toolStripStatusLabel4.Text = "     当前时间：" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "     ";
            ////////////////////////////////////////////////初始显示退出登录模块
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.panel3.Visible = false;
            this.panel4.Visible = false;
            this.panel5.Visible = false;
            this.panel6.Visible = false;
            this.panel7.Visible = true;
            this.panel7.Height = this.Height - this.button2.Height * (this.splitContainer1.Panel1.Controls.Count / 2) - 84;
        }

        private void timer1_Tick(object sender, EventArgs e)//显示时间
        {
            this.toolStripStatusLabel4.Text = "     当前时间：" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "     ";
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)//当窗体关闭的时候关闭定时器
        {
            if (MessageBox.Show("你确定要退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.timer1.Enabled = false;
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void 商品类型设置SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookStyle bookstyle = new FmBookStyle();
            this.ReForm(bookstyle.Text, bookstyle);
        }

        private void 商品上下限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmUpdown updown = new FmUpdown();
            this.ReForm(updown.Text, updown);
        }
        private void 出版社信息管理lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmPublish publish = new FmPublish();
            this.ReForm(publish.Text, publish);
        }

        private void 会员信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmVip vip = new FmVip();
            this.ReForm(vip.Text, vip);
        }

        private void 垂直排列显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 并排显示TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void button1_Click(object sender, EventArgs e)//显示你选择的模块
        {
            for (int i = 0; i < this.splitContainer1.Panel1.Controls.Count; i++)
            {
                if (this.splitContainer1.Panel1.Controls[i] is Panel)
                {
                    if ((this.splitContainer1.Panel1.Controls[i] as Panel).Tag.ToString().Trim() == ((Button)sender).Tag.ToString().Trim())
                    {
                        (this.splitContainer1.Panel1.Controls[i] as Panel).Visible = true;
                        (this.splitContainer1.Panel1.Controls[i] as Panel).Height = this.Height - this.button7.Height * (this.splitContainer1.Panel1.Controls.Count / 2) - 180;
                    }
                    else
                    {
                        if ((this.splitContainer1.Panel1.Controls[i] as Panel).Visible)
                        {
                            (this.splitContainer1.Panel1.Controls[i] as Panel).Visible = false;
                        }
                    }
                }
            }
        }

    

        private void 用户类型设置UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmUserStyle userstyle = new FmUserStyle();
            this.ReForm(userstyle.Text, userstyle);
        }

        private void 用户ToolStripMenuItem_Click(object sender, EventArgs e)//权限
        {
            FmUserPower userpower = new FmUserPower();
            this.ReForm(userpower.Text, userpower);
        }

        private void 会员类型设置VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmVipStyle vipstyle = new FmVipStyle();
            this.ReForm(vipstyle.Text, vipstyle);
        }

        private void 退货期限设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmReturnDate returndate = new FmReturnDate();
            this.ReForm(returndate.Text, returndate);
        }

        private void 供应商信息管理PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmProvider provider = new FmProvider();
            this.ReForm(provider.Text, provider);
        }

        private void 书架信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookcase bookcase = new FmBookcase();
            this.ReForm(bookcase.Text, bookcase);
        }

        private void 用户信息管理UToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmUser user = new FmUser();
            this.ReForm(user.Text, user);
        }

        private void 商品入库IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookIn bookin = new FmBookIn();
            this.ReForm(bookin.Text, bookin);
        }

        private void 退货管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookBack bookback = new FmBookBack();
            this.ReForm(bookback.Text, bookback);
        }

        private void 商品查询SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmQueryBook querybook = new FmQueryBook();
            this.ReForm(querybook.Text, querybook);
        }

        private void 商品销售SToolStripMenuItem_Click(object sender, EventArgs e)//商品销售
        {
            FmSale sale = new FmSale();
            this.ReForm(sale.Text, sale);
        }

        private void 退货管理RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookReturn bookreturn = new FmBookReturn();
            this.ReForm(bookreturn.Text, bookreturn);
        }

        private void 销售情况查询QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmSaleQuery salequery = new FmSaleQuery();
            this.ReForm(salequery.Text, salequery);
        }

        private void 销售排行IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmSaleIndex saleindex = new FmSaleIndex();
            this.ReForm(saleindex.Text, saleindex);
        }

        private void 商品损坏MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmWareBad warebad = new FmWareBad();
            this.ReForm(warebad.Text, warebad);
        }

        private void 图书库存管理BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBookStock bookstock = new FmBookStock();
            this.ReForm(bookstock.Text, bookstock);
        }

        private void 光盘库存管理CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmCdStock cdstock = new FmCdStock();
            this.ReForm(cdstock.Text, cdstock);
        }

        private void 数据导入IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmDataIn datain = new FmDataIn();
            this.ReForm(datain.Text, datain);
        }

        private void 数据导出OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmDataOut dataout = new FmDataOut();
            this.ReForm(dataout.Text, dataout);
        }

        private void 备份数据库BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmBackUp backup = new FmBackUp();
            this.ReForm(backup.Text, backup);
        }

        private void 还原数据库RToolStripMenuItem_Click(object sender, EventArgs e)//还原数据库
        {
            FmRestore restore = new FmRestore();
            this.ReForm(restore.Text, restore);
        }

        private void 重叠排列显示CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void 水平排列显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 隐藏导航栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Visible = false;
        }

        private void 显示导航栏SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Visible = true;
        }

        private void 关闭当前窗口CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void 关闭所有窗口OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.MdiChildren.Length - 1; i >= 0; i--)
            {
                this.MdiChildren[i].Close();
            }
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmModifyPwd modifypwd = new FmModifyPwd();
            this.ReForm(modifypwd.Text, modifypwd);
        }

        private void 注销账户LToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要注销账户吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                FmLogin login = new FmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.FrmMain_Load(sender, e);
                }
            }
        }

        private void 退出系统OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 帮助主题FToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, Path.GetDirectoryName(Application.ExecutablePath) + "\\Help\\help.pdf");
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmAbout about = new FmAbout();
            about.ShowDialog();
        }

        private void menuprintwaresale_Click(object sender, EventArgs e)//打印商品销售
        {
            FmPrintSale printsale = new FmPrintSale();
            this.ReForm(printsale.Text, printsale);
        }

        private void 打印商品信息WToolStripMenuItem_Click(object sender, EventArgs e)//打印商品信息
        {
            FmPrintWare printware = new FmPrintWare();
            this.ReForm(printware.Text, printware);
        }

        private void menuprintbookback_Click(object sender, EventArgs e)//打印图书退还供应商
        {
            if (this.HaveBookBackData())
            {
                PrintBackReturnBad bookback = new PrintBackReturnBad(1);
                bookback.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuprintcdback_Click(object sender, EventArgs e)//打印光盘退还供应商
        {
            if (this.HaveCdBackData())
            {
                PrintBackReturnBad cdback = new PrintBackReturnBad(2);
                cdback.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuprintbookreturn_Click(object sender, EventArgs e)//打印顾客退还图书
        {
            if (this.HaveBookReturnData())
            {
                PrintBackReturnBad bookreturn = new PrintBackReturnBad(3);
                bookreturn.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuprintcdreturn_Click(object sender, EventArgs e)//打印顾客退还光盘
        {
            if (this.HaveCdReturnData())
            {
                PrintBackReturnBad cdreturn = new PrintBackReturnBad(4);
                cdreturn.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuprintbookbad_Click(object sender, EventArgs e)//打印图书损坏
        {
            if (this.HaveBookBadData())
            {
                PrintBackReturnBad bookbad = new PrintBackReturnBad(5);
                bookbad.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void menuprintcdbad_Click(object sender, EventArgs e)//打印光盘损坏
        {
            if (this.HaveCdBadData())
            {
                PrintBackReturnBad cdbad = new PrintBackReturnBad(6);
                cdbad.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有可打印的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// 判断是否可打印退还供应商图书信息
        /// </summary>
        private bool HaveBookBackData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from bookbackprovider", connect);
            data.Clear();
            adapter.Fill(data.book_back);
            if (data.book_back.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否可打印退还供应商光盘信息
        /// </summary>
        private bool HaveCdBackData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from cdbackprovider", connect);
            data.Clear();
            adapter.Fill(data.cd_back);
            if (data.cd_back.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否可打印顾客退还图书信息
        /// </summary>
        private bool HaveBookReturnData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from bookreturnme", connect);
            data.Clear();
            adapter.Fill(data.book_return);
            if (data.book_return.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否可打印顾客退还光盘信息
        /// </summary>
        private bool HaveCdReturnData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from cdreturnme", connect);
            data.Clear();
            adapter.Fill(data.cd_return);
            if (data.cd_return.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否可打印图书损坏
        /// </summary>
        private bool HaveBookBadData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from bookbadme", connect);
            data.Clear();
            adapter.Fill(data.book_bad);
            if (data.book_bad.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否可打印光盘损坏
        /// </summary>
        private bool HaveCdBadData()
        {
            SqlConnection connect = InitConnect.GetConnection();
            MyDataSet data = new MyDataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from cdbadme", connect);
            data.Clear();
            adapter.Fill(data.cd_bad);
            if (data.cd_bad.DefaultView.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

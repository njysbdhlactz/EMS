using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMSclient
{
    public partial class FmWarning : Form
    {
        public FmWarning()
        {
            InitializeComponent();
        }

        private void FrmWarning_Paint(object sender, PaintEventArgs e)//绘制窗体
        {
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(79,151,211)));
            e.Graphics.DrawRectangle(pen,0,0,this.Width-1,this.Height-1);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(194,213,252)),1,1,this.Width-2,this.Height-2);
            e.Graphics.DrawRectangle(pen,0,0,this.Width,20);
            pen.Dispose();
        }

        bool show=false;

        private void FrmWarning_Load(object sender, EventArgs e)//初始化
        {
            int StartX = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            int StartY = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(StartX,StartY);
            //////////////////////////////////////////////////////////////////////////
            this.bookupcount.Text = InitConnect.GetWareUp(true) + " 本";
            this.cdupcount.Text = InitConnect.GetWareUp(false) + " 张";
            this.bookdowncount.Text = InitConnect.GetWareDown(true) + " 本";
            this.cddowncount.Text = InitConnect.GetWareDown(false) + " 张";
        }

        private void Timer_Tick(object sender, EventArgs e)//定时器事件
        {
            if (show == false)//窗体出来
            {
                int Up = Screen.PrimaryScreen.Bounds.Height - this.Height - (Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height);
                int Current = this.Location.Y;
                if (Current <= Up)
                {
                    show = true;
                    this.Timer.Enabled = false;
                }
                Current = Current - 1;
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width-this.Width, Current);
            }
            else//窗体消失
            {
                int Current = this.Location.Y;
                if (Current >= Screen.PrimaryScreen.Bounds.Height)
                {
                    show = false;
                    this.Timer.Enabled = false;
                    this.Close();
                }
                Current = Current + 1;
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Current);
            }
        }

        private void FrmWarning_FormClosing(object sender, FormClosingEventArgs e)//关闭时的效果
        {
            if (this.Location.Y == Screen.PrimaryScreen.Bounds.Height)
            {
                e.Cancel = false;
            }
            else
            {
                this.Timer.Enabled = true;
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)//关闭
        {
            this.Close();
        }

        new bool Enter=false;

        private void button1_Paint(object sender, PaintEventArgs e)//绘制按钮
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawImage(this.button1.BackgroundImage,0,0,this.button1.Width,this.button1.Height);
            if (Enter)
            {
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(79, 151, 211))), 0, 0, this.button1.Width - 1, this.button1.Height - 1);
            }
            else
            {
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(194,213,252))),0,0,this.Width-1,this.Height-1);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Enter = true;
            this.button1.Update();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Enter = false;
            this.button1.Update();
        }

        int frmclose = 0;

        private void CloseFrm_Tick(object sender, EventArgs e)//15秒后自动关闭
        {
            if (frmclose == 15)
            {
                this.CloseFrm.Enabled = false;
                this.Close();
            }
            frmclose=frmclose+1;
        }

        private void bookup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//图书超过上限
        {
            if (InitConnect.GetWareUp(true).Trim() == "0")
            {
                MessageBox.Show("没有图书超过系统上限！","显示",MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            else
            {
                PrintUpDown bookup = new PrintUpDown(1,"图书");
                bookup.Show();
            }
        }

        private void cdup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//光盘超过上限
        {
            if (InitConnect.GetWareUp(false).Trim() == "0")
            {
                MessageBox.Show("没有光盘超过系统上限！", "显示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                PrintUpDown cdup = new PrintUpDown(2,"光盘");
                cdup.Show();
            }
        }

        private void bookdown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//图书低于下限
        {
            if (InitConnect.GetWareDown(true).Trim() == "0")
            {
                MessageBox.Show("没有图书低于系统下限！", "显示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                PrintUpDown bookdown = new PrintUpDown(3,"图书");
                bookdown.Show();
            }
        }

        private void cddown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)//光盘低于下限
        {
            if (InitConnect.GetWareDown(false).Trim() == "0")
            {
                MessageBox.Show("没有光盘低于系统下限！", "显示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                PrintUpDown cddown = new PrintUpDown(4,"光盘");
                cddown.Show();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EMSclient
{
    partial class MyButton:Button
    {
        private MyButtonState State=MyButtonState.Normal;//表示鼠标的状态
        /////////////////////////////////////////////////////
        enum MyButtonState//表示按钮状态
        {
            Normal,//正常状态
            Enter,//鼠标移上
            Leave,//鼠标离开
            Down,//鼠标按下
            Up//鼠标弹起
        }
        //////////////////////////////////////////
        public MyButton()
        { 
        }

        protected override void OnPaint(PaintEventArgs pevent)//重新绘制按钮
        {
            pevent.Graphics.Clear(this.Parent.BackColor);
            ///////////////////////////////////////////////////////////////////
            switch(State)
            {
                case MyButtonState.Normal:
                    this.DrawLeave(pevent.Graphics);
                    break;
                case MyButtonState.Enter:
                    this.DrawEnter(pevent.Graphics);
                    break;
                case MyButtonState.Leave:
                    this.DrawLeave(pevent.Graphics);
                    break;
                case MyButtonState.Down:
                    this.DrawDown(pevent.Graphics);
                    break;
                case MyButtonState.Up:
                    this.DrawUp(pevent.Graphics);
                    break;
            }
            ////////////////////////////////////////////////////////////////////
            this.DrawText(pevent.Graphics);
        }

        /// <summary>
        /// 绘制文本
        /// </summary>
        private void DrawText(Graphics g)
        {
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;
            if (this.Image != null)
            {
                g.DrawImage(this.Image, new Rectangle((this.Width-this.Image.Width)/2, (this.Image.Height-38)/2, this.Image.Width, this.Image.Height));
                g.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new Rectangle(0, this.Image.Height, this.Width, this.Height-this.Image.Height), format);
            }
            else
            {
                g.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new Rectangle(0, 0, this.Width, this.Height), format);
            }
        }

        /// <summary>
        /// 鼠标移到按钮上时按钮的状态
        /// </summary>
        private void DrawEnter(Graphics g)
        {
            SolidBrush borderbrush = new SolidBrush(Color.FromArgb(49, 106, 197));
            SolidBrush fillbrush = new SolidBrush(Color.FromArgb(193, 210, 238));
            Pen pen = new Pen(borderbrush);
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            g.FillRectangle(fillbrush, 1, 1, this.Width - 2, this.Height - 2);
            borderbrush.Dispose();
            fillbrush.Dispose();
            pen.Dispose();
            borderbrush = null;
            fillbrush = null;
            pen = null;
        }

        /// <summary>
        /// 鼠标离开按钮时按钮的状态
        /// </summary>
        private void DrawLeave(Graphics g)
        {
            SolidBrush brush = new SolidBrush(this.Parent.BackColor);
            g.FillRectangle(brush,0,0,this.Width,this.Height);
            brush.Dispose();
            brush = null;
        }

        /// <summary>
        /// 鼠标按下时按钮的状态
        /// </summary>
        private void DrawDown(Graphics g)
        {
            SolidBrush borderbrush = new SolidBrush(Color.FromArgb(49, 106, 197));
            SolidBrush fillbrush = new SolidBrush(Color.FromArgb(152, 181, 226));
            Pen pen = new Pen(borderbrush);
            g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            g.FillRectangle(fillbrush, 1, 1, this.Width - 2, this.Height - 2);
            borderbrush.Dispose();
            fillbrush.Dispose();
            pen.Dispose();
            borderbrush = null;
            fillbrush = null;
            pen = null;
        }

        /// <summary>
        /// 鼠标弹起时按钮的状态
        /// </summary>
        private void DrawUp(Graphics g)
        {
            this.DrawEnter(g);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            //////////////////////////////////////
            State = MyButtonState.Enter;
            //////////////////////////////////////
            this.Invalidate(false);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            //////////////////////////////////////
            State = MyButtonState.Leave;
            //////////////////////////////////////
            this.Invalidate(false);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            //////////////////////////////////////
            State = MyButtonState.Down;
            //////////////////////////////////////
            this.Invalidate(false);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            //////////////////////////////////////
            State = MyButtonState.Up;
            //////////////////////////////////////
            this.Invalidate(false);
        }
    }
}

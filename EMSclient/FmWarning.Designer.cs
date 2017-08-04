namespace EMSclient
{
    partial class FmWarning
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmWarning));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CloseFrm = new System.Windows.Forms.Timer(this.components);
            this.bookinfo = new System.Windows.Forms.Label();
            this.cdinfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bookup = new System.Windows.Forms.LinkLabel();
            this.cdup = new System.Windows.Forms.LinkLabel();
            this.bookdown = new System.Windows.Forms.LinkLabel();
            this.cddown = new System.Windows.Forms.LinkLabel();
            this.bookupcount = new System.Windows.Forms.Label();
            this.cdupcount = new System.Windows.Forms.Label();
            this.bookdowncount = new System.Windows.Forms.Label();
            this.cddowncount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品上下限越界提示：";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(375, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 21);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.button1_Paint);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // CloseFrm
            // 
            this.CloseFrm.Enabled = true;
            this.CloseFrm.Interval = 1000;
            this.CloseFrm.Tick += new System.EventHandler(this.CloseFrm_Tick);
            // 
            // bookinfo
            // 
            this.bookinfo.BackColor = System.Drawing.Color.Transparent;
            this.bookinfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookinfo.ForeColor = System.Drawing.Color.Gray;
            this.bookinfo.Location = new System.Drawing.Point(8, 58);
            this.bookinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookinfo.Name = "bookinfo";
            this.bookinfo.Size = new System.Drawing.Size(189, 20);
            this.bookinfo.TabIndex = 3;
            this.bookinfo.Text = "图书超过上限数量：";
            this.bookinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cdinfo
            // 
            this.cdinfo.BackColor = System.Drawing.Color.Transparent;
            this.cdinfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cdinfo.ForeColor = System.Drawing.Color.Gray;
            this.cdinfo.Location = new System.Drawing.Point(8, 96);
            this.cdinfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cdinfo.Name = "cdinfo";
            this.cdinfo.Size = new System.Drawing.Size(189, 20);
            this.cdinfo.TabIndex = 3;
            this.cdinfo.Text = "光盘超过上限数量：";
            this.cdinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(8, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "图书低于下限数量：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(8, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "光盘低于下限数量：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bookup
            // 
            this.bookup.AutoSize = true;
            this.bookup.BackColor = System.Drawing.Color.Transparent;
            this.bookup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookup.LinkColor = System.Drawing.Color.Green;
            this.bookup.Location = new System.Drawing.Point(347, 58);
            this.bookup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookup.Name = "bookup";
            this.bookup.Size = new System.Drawing.Size(44, 18);
            this.bookup.TabIndex = 4;
            this.bookup.TabStop = true;
            this.bookup.Text = "查看";
            this.bookup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bookup_LinkClicked);
            // 
            // cdup
            // 
            this.cdup.AutoSize = true;
            this.cdup.BackColor = System.Drawing.Color.Transparent;
            this.cdup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cdup.LinkColor = System.Drawing.Color.Green;
            this.cdup.Location = new System.Drawing.Point(347, 96);
            this.cdup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cdup.Name = "cdup";
            this.cdup.Size = new System.Drawing.Size(44, 18);
            this.cdup.TabIndex = 4;
            this.cdup.TabStop = true;
            this.cdup.Text = "查看";
            this.cdup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cdup_LinkClicked);
            // 
            // bookdown
            // 
            this.bookdown.AutoSize = true;
            this.bookdown.BackColor = System.Drawing.Color.Transparent;
            this.bookdown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookdown.LinkColor = System.Drawing.Color.Green;
            this.bookdown.Location = new System.Drawing.Point(347, 135);
            this.bookdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookdown.Name = "bookdown";
            this.bookdown.Size = new System.Drawing.Size(44, 18);
            this.bookdown.TabIndex = 4;
            this.bookdown.TabStop = true;
            this.bookdown.Text = "查看";
            this.bookdown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.bookdown_LinkClicked);
            // 
            // cddown
            // 
            this.cddown.AutoSize = true;
            this.cddown.BackColor = System.Drawing.Color.Transparent;
            this.cddown.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cddown.LinkColor = System.Drawing.Color.Green;
            this.cddown.Location = new System.Drawing.Point(347, 174);
            this.cddown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cddown.Name = "cddown";
            this.cddown.Size = new System.Drawing.Size(44, 18);
            this.cddown.TabIndex = 4;
            this.cddown.TabStop = true;
            this.cddown.Text = "查看";
            this.cddown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cddown_LinkClicked);
            // 
            // bookupcount
            // 
            this.bookupcount.AutoSize = true;
            this.bookupcount.BackColor = System.Drawing.Color.Transparent;
            this.bookupcount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookupcount.ForeColor = System.Drawing.Color.Green;
            this.bookupcount.Location = new System.Drawing.Point(211, 60);
            this.bookupcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookupcount.Name = "bookupcount";
            this.bookupcount.Size = new System.Drawing.Size(0, 18);
            this.bookupcount.TabIndex = 5;
            // 
            // cdupcount
            // 
            this.cdupcount.AutoSize = true;
            this.cdupcount.BackColor = System.Drawing.Color.Transparent;
            this.cdupcount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cdupcount.ForeColor = System.Drawing.Color.Green;
            this.cdupcount.Location = new System.Drawing.Point(211, 98);
            this.cdupcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cdupcount.Name = "cdupcount";
            this.cdupcount.Size = new System.Drawing.Size(0, 18);
            this.cdupcount.TabIndex = 5;
            // 
            // bookdowncount
            // 
            this.bookdowncount.AutoSize = true;
            this.bookdowncount.BackColor = System.Drawing.Color.Transparent;
            this.bookdowncount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookdowncount.ForeColor = System.Drawing.Color.Green;
            this.bookdowncount.Location = new System.Drawing.Point(211, 138);
            this.bookdowncount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bookdowncount.Name = "bookdowncount";
            this.bookdowncount.Size = new System.Drawing.Size(0, 18);
            this.bookdowncount.TabIndex = 5;
            // 
            // cddowncount
            // 
            this.cddowncount.AutoSize = true;
            this.cddowncount.BackColor = System.Drawing.Color.Transparent;
            this.cddowncount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cddowncount.ForeColor = System.Drawing.Color.Green;
            this.cddowncount.Location = new System.Drawing.Point(211, 176);
            this.cddowncount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cddowncount.Name = "cddowncount";
            this.cddowncount.Size = new System.Drawing.Size(0, 18);
            this.cddowncount.TabIndex = 5;
            // 
            // FmWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 225);
            this.Controls.Add(this.cddowncount);
            this.Controls.Add(this.bookdowncount);
            this.Controls.Add(this.cdupcount);
            this.Controls.Add(this.bookupcount);
            this.Controls.Add(this.cddown);
            this.Controls.Add(this.bookdown);
            this.Controls.Add(this.cdup);
            this.Controls.Add(this.bookup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cdinfo);
            this.Controls.Add(this.bookinfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmWarning";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWarning_FormClosing);
            this.Load += new System.EventHandler(this.FrmWarning_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmWarning_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer CloseFrm;
        private System.Windows.Forms.Label bookinfo;
        private System.Windows.Forms.Label cdinfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel bookup;
        private System.Windows.Forms.LinkLabel cdup;
        private System.Windows.Forms.LinkLabel bookdown;
        private System.Windows.Forms.LinkLabel cddown;
        private System.Windows.Forms.Label bookupcount;
        private System.Windows.Forms.Label cdupcount;
        private System.Windows.Forms.Label bookdowncount;
        private System.Windows.Forms.Label cddowncount;
    }
}
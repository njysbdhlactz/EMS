namespace EMSclient
{
    partial class FmPrintSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmPrintSale));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cd = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cd);
            this.groupBox1.Controls.Add(this.book);
            this.groupBox1.Location = new System.Drawing.Point(19, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(267, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品类型";
            // 
            // cd
            // 
            this.cd.AutoSize = true;
            this.cd.Location = new System.Drawing.Point(159, 22);
            this.cd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(58, 19);
            this.cd.TabIndex = 1;
            this.cd.Text = "光盘";
            this.cd.UseVisualStyleBackColor = true;
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Checked = true;
            this.book.Location = new System.Drawing.Point(45, 24);
            this.book.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(58, 19);
            this.book.TabIndex = 0;
            this.book.TabStop = true;
            this.book.Text = "图书";
            this.book.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "时间段：";
            // 
            // date1
            // 
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date1.Location = new System.Drawing.Point(100, 98);
            this.date1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(131, 25);
            this.date1.TabIndex = 2;
            // 
            // date2
            // 
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date2.Location = new System.Drawing.Point(304, 98);
            this.date2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(136, 25);
            this.date2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "<-->";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(60, 145);
            this.ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(131, 40);
            this.ok.TabIndex = 5;
            this.ok.Text = "确定";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(276, 145);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(131, 40);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // FmPrintSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 202);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FmPrintSale";
            this.Text = "打印商品销售信息";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.RadioButton cd;
        private System.Windows.Forms.RadioButton book;
    }
}
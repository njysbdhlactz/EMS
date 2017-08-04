namespace EMSclient
{
    partial class FmPrintWare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmPrintWare));
            this.panel1 = new System.Windows.Forms.Panel();
            this.author = new System.Windows.Forms.TextBox();
            this.bookcase = new System.Windows.Forms.ComboBox();
            this.publish = new System.Windows.Forms.ComboBox();
            this.style = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cd = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.print = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.author);
            this.panel1.Controls.Add(this.bookcase);
            this.panel1.Controls.Add(this.publish);
            this.panel1.Controls.Add(this.style);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 165);
            this.panel1.TabIndex = 13;
            // 
            // author
            // 
            this.author.Location = new System.Drawing.Point(115, 111);
            this.author.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(228, 25);
            this.author.TabIndex = 19;
            // 
            // bookcase
            // 
            this.bookcase.FormattingEnabled = true;
            this.bookcase.Location = new System.Drawing.Point(849, 111);
            this.bookcase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bookcase.Name = "bookcase";
            this.bookcase.Size = new System.Drawing.Size(228, 23);
            this.bookcase.TabIndex = 16;
            this.bookcase.DropDown += new System.EventHandler(this.bookcase_DropDown);
            // 
            // publish
            // 
            this.publish.FormattingEnabled = true;
            this.publish.Location = new System.Drawing.Point(495, 111);
            this.publish.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.publish.Name = "publish";
            this.publish.Size = new System.Drawing.Size(228, 23);
            this.publish.TabIndex = 17;
            this.publish.DropDown += new System.EventHandler(this.publish_DropDown);
            // 
            // style
            // 
            this.style.FormattingEnabled = true;
            this.style.Location = new System.Drawing.Point(849, 42);
            this.style.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(228, 23);
            this.style.TabIndex = 18;
            this.style.DropDown += new System.EventHandler(this.style_DropDown);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(495, 42);
            this.name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(228, 25);
            this.name.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(751, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "书架：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "出版社：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 118);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "作者：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(751, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "商品类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "商品名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cd);
            this.groupBox1.Controls.Add(this.book);
            this.groupBox1.Location = new System.Drawing.Point(57, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(305, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品类型";
            // 
            // cd
            // 
            this.cd.AutoSize = true;
            this.cd.Location = new System.Drawing.Point(191, 29);
            this.cd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(58, 19);
            this.cd.TabIndex = 0;
            this.cd.Text = "光盘";
            this.cd.UseVisualStyleBackColor = true;
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Checked = true;
            this.book.Location = new System.Drawing.Point(52, 29);
            this.book.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(58, 19);
            this.book.TabIndex = 0;
            this.book.TabStop = true;
            this.book.Text = "图书";
            this.book.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.print);
            this.panel2.Controls.Add(this.cancel);
            this.panel2.Controls.Add(this.ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 165);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 79);
            this.panel2.TabIndex = 14;
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(485, 19);
            this.print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(161, 41);
            this.print.TabIndex = 15;
            this.print.Text = "打印";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(804, 19);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(161, 41);
            this.cancel.TabIndex = 14;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(167, 19);
            this.ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(161, 41);
            this.ok.TabIndex = 13;
            this.ok.Text = "查询";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 244);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 466);
            this.dataGridView1.TabIndex = 15;
            // 
            // FmPrintWare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 710);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmPrintWare";
            this.Text = "打印商品信息";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox author;
        private System.Windows.Forms.ComboBox bookcase;
        private System.Windows.Forms.ComboBox publish;
        private System.Windows.Forms.ComboBox style;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cd;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}
namespace EMSclient
{
    partial class FmQueryBook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmQueryBook));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.code = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cd = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.isbn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bookcase = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.publish = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.style = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.code);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.isbn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.bookcase);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.publish);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.author);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.style);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1132, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(873, 46);
            this.code.Margin = new System.Windows.Forms.Padding(4);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(220, 25);
            this.code.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(777, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "条形码：";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(555, 46);
            this.id.Margin = new System.Windows.Forms.Padding(4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(196, 25);
            this.id.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "图书编号：";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cd);
            this.panel1.Controls.Add(this.book);
            this.panel1.Location = new System.Drawing.Point(39, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 54);
            this.panel1.TabIndex = 26;
            // 
            // cd
            // 
            this.cd.AutoSize = true;
            this.cd.Location = new System.Drawing.Point(236, 16);
            this.cd.Margin = new System.Windows.Forms.Padding(4);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(118, 19);
            this.cd.TabIndex = 1;
            this.cd.Text = "光盘信息查询";
            this.cd.UseVisualStyleBackColor = true;
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Checked = true;
            this.book.Location = new System.Drawing.Point(43, 16);
            this.book.Margin = new System.Windows.Forms.Padding(4);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(118, 19);
            this.book.TabIndex = 0;
            this.book.TabStop = true;
            this.book.Text = "图书信息查询";
            this.book.UseVisualStyleBackColor = true;
            // 
            // isbn
            // 
            this.isbn.Location = new System.Drawing.Point(873, 104);
            this.isbn.Margin = new System.Windows.Forms.Padding(4);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(220, 25);
            this.isbn.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(775, 110);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "I S B N：";
            // 
            // bookcase
            // 
            this.bookcase.FormattingEnabled = true;
            this.bookcase.Location = new System.Drawing.Point(481, 159);
            this.bookcase.Margin = new System.Windows.Forms.Padding(4);
            this.bookcase.Name = "bookcase";
            this.bookcase.Size = new System.Drawing.Size(269, 23);
            this.bookcase.TabIndex = 20;
            this.bookcase.DropDown += new System.EventHandler(this.bookcase_DropDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(385, 165);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "书架位置：";
            // 
            // publish
            // 
            this.publish.FormattingEnabled = true;
            this.publish.Location = new System.Drawing.Point(481, 104);
            this.publish.Margin = new System.Windows.Forms.Padding(4);
            this.publish.Name = "publish";
            this.publish.Size = new System.Drawing.Size(269, 23);
            this.publish.TabIndex = 18;
            this.publish.DropDown += new System.EventHandler(this.publish_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "出 版 社：";
            // 
            // author
            // 
            this.author.Location = new System.Drawing.Point(873, 159);
            this.author.Margin = new System.Windows.Forms.Padding(4);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(220, 25);
            this.author.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(775, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "作    者：";
            // 
            // style
            // 
            this.style.FormattingEnabled = true;
            this.style.Location = new System.Drawing.Point(131, 159);
            this.style.Margin = new System.Windows.Forms.Padding(4);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(228, 23);
            this.style.TabIndex = 14;
            this.style.DropDown += new System.EventHandler(this.style_DropDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "商品类型：";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(131, 104);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(228, 25);
            this.name.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "商品名称：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(469, 22);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 41);
            this.button3.TabIndex = 27;
            this.button3.Text = "显示全部";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(816, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(157, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 209);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1132, 78);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 287);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 0);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FmQueryBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 285);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FmQueryBook";
            this.Text = "商品信息查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox isbn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox bookcase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox publish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox author;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox style;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton cd;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label6;


    }
}
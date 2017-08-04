namespace EMSclient
{
    partial class FmBookBack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmBookBack));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.count = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.part = new System.Windows.Forms.RadioButton();
            this.all = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isbn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cd = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bookcase = new System.Windows.Forms.ComboBox();
            this.publish = new System.Windows.Forms.ComboBox();
            this.style = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1132, 308);
            this.panel1.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1132, 107);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "退还类型";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.count);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.part);
            this.panel2.Controls.Add(this.all);
            this.panel2.Location = new System.Drawing.Point(44, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 61);
            this.panel2.TabIndex = 6;
            // 
            // count
            // 
            this.count.Enabled = false;
            this.count.Location = new System.Drawing.Point(512, 16);
            this.count.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(132, 25);
            this.count.TabIndex = 2;
            this.count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.count_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "请输入要退还的数量：";
            // 
            // part
            // 
            this.part.AutoSize = true;
            this.part.Location = new System.Drawing.Point(141, 20);
            this.part.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.part.Name = "part";
            this.part.Size = new System.Drawing.Size(103, 19);
            this.part.TabIndex = 1;
            this.part.Text = "退还一部分";
            this.part.UseVisualStyleBackColor = true;
            this.part.CheckedChanged += new System.EventHandler(this.part_CheckedChanged);
            // 
            // all
            // 
            this.all.AutoSize = true;
            this.all.Checked = true;
            this.all.Location = new System.Drawing.Point(39, 20);
            this.all.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(88, 19);
            this.all.TabIndex = 0;
            this.all.TabStop = true;
            this.all.Text = "退还全部";
            this.all.UseVisualStyleBackColor = true;
            this.all.CheckedChanged += new System.EventHandler(this.all_CheckedChanged);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(957, 39);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(804, 39);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "确定退还";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isbn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.bookcase);
            this.groupBox1.Controls.Add(this.publish);
            this.groupBox1.Controls.Add(this.style);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1132, 201);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商品信息查询";
            // 
            // isbn
            // 
            this.isbn.Location = new System.Drawing.Point(617, 89);
            this.isbn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.isbn.Name = "isbn";
            this.isbn.Size = new System.Drawing.Size(195, 25);
            this.isbn.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "ISBN：";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(577, 36);
            this.id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(216, 25);
            this.id.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(496, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "商品编号：";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cd);
            this.panel3.Controls.Add(this.book);
            this.panel3.Location = new System.Drawing.Point(20, 30);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 44);
            this.panel3.TabIndex = 9;
            // 
            // cd
            // 
            this.cd.AutoSize = true;
            this.cd.Location = new System.Drawing.Point(295, 11);
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
            this.book.Location = new System.Drawing.Point(57, 11);
            this.book.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(58, 19);
            this.book.TabIndex = 0;
            this.book.TabStop = true;
            this.book.Text = "图书";
            this.book.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(677, 141);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(195, 41);
            this.button4.TabIndex = 4;
            this.button4.Text = "显示全部";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(259, 141);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "查    询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bookcase
            // 
            this.bookcase.FormattingEnabled = true;
            this.bookcase.Location = new System.Drawing.Point(904, 89);
            this.bookcase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bookcase.Name = "bookcase";
            this.bookcase.Size = new System.Drawing.Size(207, 23);
            this.bookcase.TabIndex = 3;
            this.bookcase.DropDown += new System.EventHandler(this.bookcase_DropDown);
            // 
            // publish
            // 
            this.publish.FormattingEnabled = true;
            this.publish.Location = new System.Drawing.Point(347, 89);
            this.publish.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.publish.Name = "publish";
            this.publish.Size = new System.Drawing.Size(200, 23);
            this.publish.TabIndex = 2;
            this.publish.DropDown += new System.EventHandler(this.publish_DropDown);
            // 
            // style
            // 
            this.style.FormattingEnabled = true;
            this.style.Location = new System.Drawing.Point(103, 89);
            this.style.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(168, 23);
            this.style.TabIndex = 1;
            this.style.DropDown += new System.EventHandler(this.style_DropDown);
            // 
            // name
            // 
            this.name.ImeMode = System.Windows.Forms.ImeMode.On;
            this.name.Location = new System.Drawing.Point(904, 36);
            this.name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(207, 25);
            this.name.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(821, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "所在书架：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "出版社：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品类型：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名称：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 308);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1132, 402);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // FmBookBack
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 710);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmBookBack";
            this.Text = "商品退还管理";
            this.Load += new System.EventHandler(this.FrmBookBack_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton cd;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox bookcase;
        private System.Windows.Forms.ComboBox publish;
        private System.Windows.Forms.ComboBox style;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox count;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton part;
        private System.Windows.Forms.RadioButton all;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox isbn;
        private System.Windows.Forms.Label label7;



    }
}
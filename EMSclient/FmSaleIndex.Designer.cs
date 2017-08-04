namespace EMSclient
{
    partial class FmSaleIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmSaleIndex));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cd = new System.Windows.Forms.RadioButton();
            this.book = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.style = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.index = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cd);
            this.panel1.Controls.Add(this.book);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.style);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 78);
            this.panel1.TabIndex = 0;
            // 
            // cd
            // 
            this.cd.AutoSize = true;
            this.cd.Location = new System.Drawing.Point(248, 30);
            this.cd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cd.Name = "cd";
            this.cd.Size = new System.Drawing.Size(58, 19);
            this.cd.TabIndex = 4;
            this.cd.Text = "光盘";
            this.cd.UseVisualStyleBackColor = true;
            // 
            // book
            // 
            this.book.AutoSize = true;
            this.book.Checked = true;
            this.book.Location = new System.Drawing.Point(152, 30);
            this.book.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(58, 19);
            this.book.TabIndex = 3;
            this.book.TabStop = true;
            this.book.Text = "图书";
            this.book.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "何种商品：";
            // 
            // style
            // 
            this.style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.style.FormattingEnabled = true;
            this.style.Items.AddRange(new object[] {
            "",
            "按商品名称排行",
            "按商品类型排行",
            "按商品作者排行",
            "按出版社排行"});
            this.style.Location = new System.Drawing.Point(753, 26);
            this.style.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.style.Name = "style";
            this.style.Size = new System.Drawing.Size(319, 23);
            this.style.TabIndex = 1;
            this.style.SelectedIndexChanged += new System.EventHandler(this.style_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(627, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择排行方式：";
            // 
            // result
            // 
            this.result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.result.Location = new System.Drawing.Point(0, 683);
            this.result.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(1129, 25);
            this.result.TabIndex = 1;
            this.result.Text = "在此显示统计结果";
            this.result.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // index
            // 
            this.index.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.index.FullRowSelect = true;
            this.index.GridLines = true;
            this.index.Location = new System.Drawing.Point(0, 78);
            this.index.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.index.MultiSelect = false;
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(1129, 605);
            this.index.TabIndex = 2;
            this.index.UseCompatibleStateImageBehavior = false;
            this.index.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "排行方式";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "销售数量";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "销售额";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "利润额";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "排名";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // FmSaleIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 708);
            this.Controls.Add(this.index);
            this.Controls.Add(this.result);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FmSaleIndex";
            this.Text = "销售排行";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox style;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton cd;
        private System.Windows.Forms.RadioButton book;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.ListView index;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
namespace EMSclient
{
    partial class FmSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmSet));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.server = new System.Windows.Forms.ComboBox();
            this.user = new System.Windows.Forms.TextBox();
            this.pwd = new System.Windows.Forms.TextBox();
            this.database = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "服务器名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "数据库名称：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 275);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 275);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // server
            // 
            this.server.FormattingEnabled = true;
            this.server.Location = new System.Drawing.Point(169, 39);
            this.server.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(257, 23);
            this.server.TabIndex = 0;
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(169, 88);
            this.user.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(257, 25);
            this.user.TabIndex = 1;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(169, 136);
            this.pwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(257, 25);
            this.pwd.TabIndex = 2;
            // 
            // database
            // 
            this.database.FormattingEnabled = true;
            this.database.Location = new System.Drawing.Point(169, 185);
            this.database.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(257, 23);
            this.database.TabIndex = 3;
            this.database.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(36, 229);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(181, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "测试连接...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 332);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.database);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.user);
            this.Controls.Add(this.server);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FmSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置数据库参数";
            this.Load += new System.EventHandler(this.FrmSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox server;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.ComboBox database;
        private System.Windows.Forms.Button button3;
    }
}
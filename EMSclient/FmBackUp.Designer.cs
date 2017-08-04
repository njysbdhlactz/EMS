namespace EMSclient
{
    partial class FmBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmBackUp));
            this.label1 = new System.Windows.Forms.Label();
            this.filename = new System.Windows.Forms.TextBox();
            this.look = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件名：";
            // 
            // filename
            // 
            this.filename.Location = new System.Drawing.Point(108, 36);
            this.filename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(425, 25);
            this.filename.TabIndex = 0;
            // 
            // look
            // 
            this.look.Location = new System.Drawing.Point(543, 35);
            this.look.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.look.Name = "look";
            this.look.Size = new System.Drawing.Size(100, 29);
            this.look.TabIndex = 1;
            this.look.Text = "浏览...";
            this.look.UseVisualStyleBackColor = true;
            this.look.Click += new System.EventHandler(this.look_Click);
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(149, 94);
            this.ok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(144, 39);
            this.ok.TabIndex = 2;
            this.ok.Text = "备份";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(392, 94);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(144, 39);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bak";
            this.saveFileDialog1.Filter = "备份文件|*.bak|所有文件|*.*";
            // 
            // FmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 160);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.look);
            this.Controls.Add(this.filename);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FmBackUp";
            this.Text = "备份数据库";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.Button look;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
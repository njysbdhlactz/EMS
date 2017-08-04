using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMSclient
{
    public partial class FmAbout : Form
    {
        public FmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.user.Text = Environment.MachineName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Whistler;

namespace WhistlerTest
{
    public partial class Main : WhistlerForm
    {
        public Main()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.testicon;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Width + "x" + this.Height);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stretchy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WM_CANCELMODE");
        }
    }
}

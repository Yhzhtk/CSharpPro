using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageGroup
{
    public partial class AddHighForm : Form
    {
        public string index;
        public string highKey;

        public AddHighForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            index = indexComb.Text;
            highKey = keyTxt.Text;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            index = "-1";
            this.Close();
        }
    }
}

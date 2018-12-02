using AnugerahWinform.StokBarang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void JenisBrgMenu_Click(object sender, EventArgs e)
        {
            var form = new JenisBrgListForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}

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
            var form = new JenisBrgListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }

        private void TipeBrgMenu_Click(object sender, EventArgs e)
        {
            var form = new TipeBrgListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }

        private void BarangMenu_Click(object sender, EventArgs e)
        {
            var form = new BarangListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }

        private void sT08SubJenisBrgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SubJenisBrgListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.Black;
        }

        private void StudentMenuButton_Click(object sender, EventArgs e)
        {
            var form = new BarangListForm
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent
            };
            form.Show();
        }
    }
}

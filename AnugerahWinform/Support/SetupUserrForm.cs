using AnugerahBackend.Support.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Support
{
    public partial class SetupUserrForm : Form
    {
        private IUserrBL _userrBL;

        public SetupUserrForm()
        {
            InitializeComponent();
            _userrBL = new UserrBL();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var userrName = textBox1.Text;
            var pass1 = PasswordTextBox.Text;
            var pass2 = maskedTextBox1.Text;
            var jenis = "F";
            if (radioButton2.Checked)
                jenis = "B";

            try
            {
                _userrBL.Save(userrName, pass1, pass2, jenis);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = "";
            PasswordTextBox.Text = "";
            maskedTextBox1.Text = "";
        }
    }
}

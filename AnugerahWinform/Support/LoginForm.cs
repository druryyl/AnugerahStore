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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var _userrBL = new UserrBL();
            var userr = _userrBL.GetData(textBox1.Text);
            if (userr == null)
            {
                return;
            }
        }
    }
}

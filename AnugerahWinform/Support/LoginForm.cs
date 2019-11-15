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
        public bool IsSuccess { get; set; }
        private int _counter = 0;

        public LoginForm()
        {
            InitializeComponent();
            IsSuccess = false;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var _userrBL = new UserrBL();
            var userr = _userrBL.GetData(textBox1.Text);
            if (userr == null)
            {
                _counter++;
                if (_counter > 3)
                    this.Close();
                MessageBox.Show("Invalid login");
                return;
            }

            var pass = PasswordTextBox.Text;
            if(_userrBL.IsValidPassword(userr,pass))
            {
                _counter++;
                if (_counter > 3)
                    this.Close();
                MessageBox.Show("Invalid login");
                return;
            }

            IsSuccess = true;
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            switch (e.CloseReason)
            {
                case CloseReason.UserClosing:
                case CloseReason.ApplicationExitCall:
                    if (IsSuccess == true)
                        DialogResult = DialogResult.OK;
                    else
                        DialogResult = DialogResult.Cancel;
                    break;
                default:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }
    }
}

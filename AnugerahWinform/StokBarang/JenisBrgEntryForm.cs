using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.StokBarang
{
    public partial class JenisBrgEntryForm : Form
    {
        IJenisBrgBL _jenisBrgBL;
        
        public JenisBrgEntryForm(string id)
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();

            ShowData(id);
        }

        public JenisBrgEntryForm()
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            ResetData();
        }

        private void ShowData(string id)
        {
            ResetData();
            var jenisBrg = _jenisBrgBL.GetData(id);
            if(jenisBrg != null)
            {
                JenisBrgIDTextBox.ReadOnly = true;
                JenisBrgIDTextBox.Text = jenisBrg.JenisBrgID;
                JenisBrgNameTextBox.Text = jenisBrg.JenisBrgName;
            }
        }

        private void ResetData()
        {
            JenisBrgIDTextBox.Text = "";
            JenisBrgNameTextBox.Text = "";
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var jenisBrg = new JenisBrgModel
            {
                JenisBrgID = JenisBrgIDTextBox.Text,
                JenisBrgName = JenisBrgNameTextBox.Text
            };

            var result = _jenisBrgBL.Save(jenisBrg);

            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void JenisBrgEntryForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}

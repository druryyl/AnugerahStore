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
    public partial class SubJenisBrgEntryForm : Form
    {
        IJenisBrgBL _jenisBrgBL;
        ISubJenisBrgBL _subJenisBrgBL;

        private void OKButton_Click(object sender, EventArgs e)
        {
            var model = new SubJenisBrgModel
            {
                SubJenisBrgID = SubJenisBrgIDTextBox.Text,
                SubJenisBrgName = SubJenisBrgNameTextBox.Text,
                JenisBrgID = JenisBrgIDTextBox.Text
            };
            var resultSave = _subJenisBrgBL.Save(model);
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public SubJenisBrgEntryForm(string jenisBrgID, string subJenisBrgID)
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            _subJenisBrgBL = new SubJenisBrgBL();

            ShowJenisBrg(jenisBrgID);
            ShowSubJenisBrg(subJenisBrgID);
            SubJenisBrgIDTextBox.Enabled = false;
        }

        public SubJenisBrgEntryForm(string jenisBrgID)
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            _subJenisBrgBL = new SubJenisBrgBL();

            ShowJenisBrg(jenisBrgID);
        }

        private void ShowSubJenisBrg(string id)
        {
            SubJenisBrgIDTextBox.Text = id;
            var subJenisBrg = _subJenisBrgBL.GetData(id);
            if (subJenisBrg != null)
            {
                SubJenisBrgNameTextBox.Text = subJenisBrg.SubJenisBrgName;
            }
            else
            {
                SubJenisBrgNameTextBox.Text = "";
            }
        }

        private void ShowJenisBrg(string id)
        {
            JenisBrgIDTextBox.Text = id;
            var jenisBrg = _jenisBrgBL.GetData(id);
            if (jenisBrg != null)
            {
                JenisBrgNameTextBox.Text = jenisBrg.JenisBrgName;
            }
            else
            {
                JenisBrgNameTextBox.Text = "";
            }
        }
    }
}

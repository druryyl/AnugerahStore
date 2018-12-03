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
    public partial class TipeBrgEntryForm : Form
    {
        IJenisBrgBL _jenisBrgBL;
        ITipeBrgBL _tipeBrgBL;

        private void OKButton_Click(object sender, EventArgs e)
        {
            var model = new TipeBrgModel
            {
                TipeBrgID = TipeBrgIDTextBox.Text,
                TipeBrgName = TipeBrgNameTextBox.Text,
                JenisBrgID = JenisBrgIDTextBox.Text
            };
            var resultSave = _tipeBrgBL.Save(model);
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipeBrgEntryForm(string jenisBrgID, string tipeBrgID)
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            _tipeBrgBL = new TipeBrgBL();

            ShowJenisBrg(jenisBrgID);
            ShowTipeBrg(tipeBrgID);
            TipeBrgIDTextBox.Enabled = false;
        }

        public TipeBrgEntryForm(string jenisBrgID)
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            _tipeBrgBL = new TipeBrgBL();

            ShowJenisBrg(jenisBrgID);
        }

        private void ShowTipeBrg(string id)
        {
            TipeBrgIDTextBox.Text = id;
            var tipeBrg = _tipeBrgBL.GetData(id);
            if (tipeBrg != null)
            {
                TipeBrgNameTextBox.Text = tipeBrg.TipeBrgName;
            }
            else
            {
                TipeBrgNameTextBox.Text = "";
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

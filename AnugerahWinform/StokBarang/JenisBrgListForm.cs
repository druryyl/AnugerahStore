using AnugerahBackend.StokBarang.BL;
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
    public partial class JenisBrgListForm : Form
    {
        IJenisBrgBL _jenisBrgBL;

        public JenisBrgListForm()
        {
            InitializeComponent();
            _jenisBrgBL = new JenisBrgBL();
            ListData();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            using (var formEntry = new JenisBrgEntryForm(""))
            {
                var result = formEntry.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        ListData();
                        break;
                    default:
                        break;
                }
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (JenisBrgGrid.SelectedRows.Count == 0) return;

            var jenisBrgID = JenisBrgGrid.SelectedRows[0].Cells["JenisBrgID"].Value.ToString();
            var result = MessageBox.Show("Delete?","Anugerah", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _jenisBrgBL.Delete(jenisBrgID);
            }
            ListData();
        }
        private void JenisBrgGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = JenisBrgGrid.Rows[e.RowIndex].Cells["JenisBrgID"].Value.ToString();
            using (var formEntry = new JenisBrgEntryForm(id))
            {
                var result = formEntry.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        ListData();
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetLayoutJenisBrgGrid()
        {
            JenisBrgGrid.DefaultCellStyle.Font = new Font("Courier New", 8, FontStyle.Regular);
            JenisBrgGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            JenisBrgGrid.Columns.Clear();
            JenisBrgGrid.Rows.Clear();

            JenisBrgGrid.Columns.Add("JenisBrgID", "ID");
            JenisBrgGrid.Columns["JenisBrgID"].Width = 30;

            JenisBrgGrid.Columns.Add("JenisBrgName", "JenisBrg Name");
            JenisBrgGrid.Columns["JenisBrgName"].Width = 300;

        }
        private void ListData()
        {
            var listJenisBrg = _jenisBrgBL.ListData();
            if (listJenisBrg == null)
                return;

            SetLayoutJenisBrgGrid();
            foreach(var item in listJenisBrg)
            {
                object[] rowData = { item.JenisBrgID, item.JenisBrgName };
                JenisBrgGrid.Rows.Add(rowData);
            }
        }

    }
}

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
    public partial class SubJenisBrgListForm : Form
    {
        IJenisBrgBL _jenisBrgBL;
        ISubJenisBrgBL _subJenisBrgBL;

        public SubJenisBrgListForm()
        {
            InitializeComponent();

            _jenisBrgBL = new JenisBrgBL();
            _subJenisBrgBL = new SubJenisBrgBL();

            ListDataJenisBrg();
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var searchKeyword = SearchTextBox.Text.ToLower();

            //  jika keyword kosong, tampilkan semua
            if (searchKeyword.Trim() == "")
            {
                ListDataJenisBrg();
                return;
            }

            //  clear grid
            JenisBrgGrid.Rows.Clear();
            SubJenisBrgGrid.Rows.Clear();

            var listSubJenisBrg = _subJenisBrgBL.ListData();
            if (listSubJenisBrg == null)
                return;

            var searchResult =
                (
                    from c in listSubJenisBrg
                    where c.SubJenisBrgName.ToLower().Contains(searchKeyword.ToLower())
                    select c
                ).ToList();

            if (!searchResult.Any())
                return;

            //  distinct jenisbrg
            var resultJenisBrg =
                (
                    from c in searchResult
                    group c by new
                    {
                        c.JenisBrgID,
                        c.JenisBrgName
                    }
                    into d
                    select d.FirstOrDefault()
                ).ToList();

            //  isi grid jenisbrg
            if (resultJenisBrg.Any())
            {
                foreach (var item in resultJenisBrg)
                {
                    object[] rowdata =
                    {
                        item.JenisBrgID,
                        item.JenisBrgName
                    };
                    JenisBrgGrid.Rows.Add(rowdata);
                }

                ListDataSubJenisBrg(resultJenisBrg.FirstOrDefault().JenisBrgID, searchKeyword);

            }

        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            var currentRow = JenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;

            var jenisBrgID = currentRow.Cells["JenisBrgID"].Value.ToString();

            using (var formEntry = new SubJenisBrgEntryForm(jenisBrgID))
            {
                var result = formEntry.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        ListDataJenisBrg();
                        //  kembalikan aktif row
                        foreach (DataGridViewRow row in JenisBrgGrid.Rows)
                        {
                            if (row.Cells["JenisBrgID"].Value.ToString() == jenisBrgID)
                            {
                                row.Selected = true;
                            }
                        }
                        ListDataSubJenisBrg(jenisBrgID, "");
                        break;
                    default:
                        break;
                }
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            //  ambil ID jenisbrg
            var currentRow = JenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;
            var jenisBrgID = currentRow.Cells["JenisBrgID"].Value.ToString();

            //  ambil id tipebrg
            currentRow = SubJenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;
            var tipeBrgID = currentRow.Cells["SubJenisBrgID"].Value.ToString();

            using (var formEntry = new SubJenisBrgEntryForm(jenisBrgID, tipeBrgID))
            {
                var result = formEntry.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        ListDataJenisBrg();
                        //  kembalikan aktif row
                        foreach (DataGridViewRow row in JenisBrgGrid.Rows)
                        {
                            if (row.Cells["JenisBrgID"].Value.ToString() == jenisBrgID)
                            {
                                row.Selected = true;
                            }
                        }
                        ListDataSubJenisBrg(jenisBrgID, "");
                        break;
                    default:
                        break;
                }
            }
        }
        private void JenisBrgGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (JenisBrgGrid.CurrentRow == null)
                return;

            var jenisBrgID = JenisBrgGrid.Rows[e.RowIndex].Cells["JenisBrgID"].Value.ToString();
            var searchKeyword = SearchTextBox.Text;
            ListDataSubJenisBrg(jenisBrgID, searchKeyword);
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
        private void SetLayoutSubJenisBrgGrid()
        {
            SubJenisBrgGrid.DefaultCellStyle.Font = new Font("Courier New", 8, FontStyle.Regular);
            SubJenisBrgGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            SubJenisBrgGrid.Columns.Clear();

            SubJenisBrgGrid.Columns.Add("SubJenisBrgID", "ID");
            SubJenisBrgGrid.Columns["SubJenisBrgID"].Width = 50;

            SubJenisBrgGrid.Columns.Add("SubJenisBrgName", "SubJenisBrg Name");
            SubJenisBrgGrid.Columns["SubJenisBrgName"].Width = 300;
        }
        private void ListDataJenisBrg()
        {
            var listJenisBrg = _jenisBrgBL.ListData();
            if (listJenisBrg == null)
                return;

            SetLayoutJenisBrgGrid();
            foreach (var item in listJenisBrg)
            {
                object[] rowData = { item.JenisBrgID, item.JenisBrgName };
                JenisBrgGrid.Rows.Add(rowData);
            }

            if (JenisBrgGrid.CurrentRow == null)
                return;

            var jenisBrgID = JenisBrgGrid.CurrentRow.Cells["JenisBrgID"].Value.ToString();
            var searchKeyword = SearchTextBox.Text;
            ListDataSubJenisBrg(jenisBrgID, searchKeyword);
        }
        private void ListDataSubJenisBrg(string jenisBrgID, string searchKeyword)
        {
            var listSubJenisBrg = _subJenisBrgBL.ListData(jenisBrgID);
            if (listSubJenisBrg == null)
            {
                SubJenisBrgGrid.Rows.Clear();
                return;
            }

            SetLayoutSubJenisBrgGrid();
            foreach (var item in listSubJenisBrg)
            {
                if (searchKeyword.Trim() != "")
                {
                    if (item.SubJenisBrgName.ToLower().Contains(searchKeyword.ToLower()))
                    {
                        object[] rowData = { item.SubJenisBrgID, item.SubJenisBrgName };
                        SubJenisBrgGrid.Rows.Add(rowData);
                    }
                }
                else
                {
                    object[] rowData = { item.SubJenisBrgID, item.SubJenisBrgName };
                    SubJenisBrgGrid.Rows.Add(rowData);
                }
            }
        }

        private void SubJenisBrgListForm_Load(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //  ambil ID jenisbrg
            var currentRow = JenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;
            var jenisBrgID = currentRow.Cells["JenisBrgID"].Value.ToString();

            //  ambil id tipebrg
            currentRow = SubJenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;
            var tipeBrgID = currentRow.Cells["SubJenisBrgID"].Value.ToString();

            using (var formEntry = new SubJenisBrgEntryForm(jenisBrgID, tipeBrgID))
            {
                DialogResult result =  MessageBox.Show("Delete data?", "Delete", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.OK:
                        _subJenisBrgBL.Delete(tipeBrgID);
                        ListDataSubJenisBrg(jenisBrgID, "");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

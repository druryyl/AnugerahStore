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
    public partial class TipeBrgListForm : Form
    {
        IJenisBrgBL _jenisBrgBL;
        ITipeBrgBL _tipeBrgBL;

        public TipeBrgListForm()
        {
            InitializeComponent();

            _jenisBrgBL = new JenisBrgBL();
            _tipeBrgBL = new TipeBrgBL();

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
            TipeBrgGrid.Rows.Clear();

            var listTipeBrg = _tipeBrgBL.ListData();
            if (listTipeBrg == null)
                return;

            var searchResult =
                (
                    from c in listTipeBrg
                    where c.TipeBrgName.ToLower().Contains(searchKeyword.ToLower())
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

                ListDataTipeBrg(resultJenisBrg.FirstOrDefault().JenisBrgID, searchKeyword);

            }

        }
        private void NewButton_Click(object sender, EventArgs e)
        {
            var currentRow = JenisBrgGrid.CurrentRow;
            if (currentRow == null)
                return;

            var jenisBrgID = currentRow.Cells["JenisBrgID"].Value.ToString();

            using(var formEntry = new TipeBrgEntryForm(jenisBrgID))
            {
                var result = formEntry.ShowDialog();
                switch (result)
                {
                    case DialogResult.OK:
                        ListDataJenisBrg();
                        //  kembalikan aktif row
                        foreach(DataGridViewRow row in JenisBrgGrid.Rows)
                        {
                            if(row.Cells["JenisBrgID"].Value.ToString() == jenisBrgID)
                            {
                                row.Selected = true;
                            }
                        }
                        ListDataTipeBrg(jenisBrgID, "");
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
            currentRow = TipeBrgGrid.CurrentRow;
            if (currentRow == null)
                return;
            var tipeBrgID = currentRow.Cells["TipeBrgID"].Value.ToString();

            using (var formEntry = new TipeBrgEntryForm(jenisBrgID, tipeBrgID))
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
                        ListDataTipeBrg(jenisBrgID, "");
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
            ListDataTipeBrg(jenisBrgID, searchKeyword);
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
        private void SetLayoutTipeBrgGrid()
        {
            TipeBrgGrid.DefaultCellStyle.Font = new Font("Courier New", 8, FontStyle.Regular);
            TipeBrgGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);

            TipeBrgGrid.Columns.Clear();

            TipeBrgGrid.Columns.Add("TipeBrgID", "ID");
            TipeBrgGrid.Columns["TipeBrgID"].Width = 50;

            TipeBrgGrid.Columns.Add("TipeBrgName", "TipeBrg Name");
            TipeBrgGrid.Columns["TipeBrgName"].Width = 300;
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
            ListDataTipeBrg(jenisBrgID, searchKeyword);
        }
        private void ListDataTipeBrg(string jenisBrgID, string searchKeyword)
        {
            var listTipeBrg = _tipeBrgBL.ListData(jenisBrgID);
            if (listTipeBrg == null)
            {
                TipeBrgGrid.Rows.Clear();
                return;
            }

            SetLayoutTipeBrgGrid();
            foreach(var item in listTipeBrg)
            {
                if (searchKeyword.Trim() != "")
                {
                    if (item.TipeBrgName.ToLower().Contains(searchKeyword.ToLower()))
                    {
                        object[] rowData = { item.TipeBrgID, item.TipeBrgName };
                        TipeBrgGrid.Rows.Add(rowData);
                    }
                }
                else
                {
                    object[] rowData = { item.TipeBrgID, item.TipeBrgName };
                    TipeBrgGrid.Rows.Add(rowData);
                }
            }
        }


    }
}

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
            TipeBrgGrid.Rows.Clear();

            TipeBrgGrid.Columns.Add("TipeBrgID", "ID");
            TipeBrgGrid.Columns["TipeBrgID"].Width = 30;

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
            ListDataTipeBrg(jenisBrgID);
        }

        private void ListDataTipeBrg(string jenisBrgID)
        {
            var listTipeBrg = _tipeBrgBL.ListData(jenisBrgID);
            if (listTipeBrg == null)
                return;

            SetLayoutTipeBrgGrid();
            foreach(var item in listTipeBrg)
            {
                object[] rowData = { item.TipeBrgID, item.TipeBrgName };
                TipeBrgGrid.Rows.Add(rowData);
            }
        }


    }
}

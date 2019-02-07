using AnugerahBackend.Support;
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
    public partial class SearchingForm<T> : Form
    {
        private ISearch<T> _searchBL;

        public string SelectedDataKey;

        public SearchingForm(ISearch<T> _injSearchBL)
        {
            InitializeComponent();
            _searchBL = _injSearchBL;
        }

        private void InnerContructor()
        {

            if(!_searchBL.SearchFilter.IsDate )
            {
                Tgl1DatePicker.Visible = false;
                Tgl2DatePicker.Visible = false;
                splitContainer1.FixedPanel = FixedPanel.None;
                splitContainer1.SplitterDistance -= Tgl1DatePicker.Height + 5;
                splitContainer1.FixedPanel = FixedPanel.Panel1;
            }

            IEnumerable<T> listData = _searchBL.Search();

            if (listData == null) return;

            ListDataGrid.DataSource = listData;
            int allColWidth = 0;
            foreach (DataGridViewColumn col in ListDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                allColWidth += col.Width;
            }
            var maxWidth = 900;
            var minWidth = 300;
            var margin = 65;
            if (allColWidth <= maxWidth)
                this.Width = allColWidth + margin;

            if (allColWidth <= minWidth)
                this.Width = minWidth + margin;

        }

        private void KeywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void Search()
        {
            //  set date
            if(_searchBL.SearchFilter.IsDate)
            {
                _searchBL.SearchFilter.Date1= Tgl1DatePicker.Value;
                _searchBL.SearchFilter.Date2 = Tgl2DatePicker.Value;
            }
            //  set keyword
            if(KeywordTextBox.Text.Trim() == "")
                _searchBL.SearchFilter.UserKeyword = null;
            else
                _searchBL.SearchFilter.UserKeyword = KeywordTextBox.Text.Trim();

            //  searh
            IEnumerable<T> listData = _searchBL.Search();

            //  set result to grid
            ListDataGrid.DataSource = listData;

            //  format grid
            if (listData!=null)
                foreach (DataGridViewColumn col in ListDataGrid.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
        }

        private void ListDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = (DataGridView)sender;
            SelectedDataKey = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            if(e.RowIndex != -1)
                DialogResult = DialogResult.OK;
        }

        private void SearchingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                DialogResult = DialogResult.Cancel;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void SearchingForm_KeyDown(object sender, KeyEventArgs e)
        {

            if((e.KeyCode == Keys.Up)||(e.KeyCode==Keys.Down))
            {
                ListDataGrid.Focus();
            }
        }

        private void ListDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ListDataGrid.CurrentRow == null) return;

                SelectedDataKey = ListDataGrid.CurrentRow.Cells[0].Value.ToString();
                DialogResult = DialogResult.OK;
            }
        }
    }
}

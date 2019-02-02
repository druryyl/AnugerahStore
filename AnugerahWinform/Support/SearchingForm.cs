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
        ISearchData<T> _searchBL;
        public string SelectedDataKey;
        private bool _isFilterTgl;

        public SearchingForm(ISearchData<T> _injSearchBL, bool isShowTgl)
        {
            InitializeComponent();
            _searchBL = _injSearchBL;
            _isFilterTgl = isShowTgl;
            
            if (!isShowTgl)
            {
                Tgl1DatePicker.Visible = false;
                Tgl2DatePicker.Visible = false;
                splitContainer1.FixedPanel = FixedPanel.None;
                splitContainer1.SplitterDistance -= Tgl1DatePicker.Height + 5;
                splitContainer1.FixedPanel = FixedPanel.Panel1;
            }

            IEnumerable<T> listData;
            listData = _searchBL.Search();
            if (listData == null) return;

            ListDataGrid.DataSource = listData;
            foreach (DataGridViewColumn col in ListDataGrid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
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
            IEnumerable<T> listData;
            if (!_isFilterTgl)
            {
                if (KeywordTextBox.Text != "")
                    listData = _searchBL.Search(KeywordTextBox.Text);
                else
                    listData = _searchBL.Search();
            }
            else
                listData = _searchBL.Search(KeywordTextBox.Text,
                    Tgl1DatePicker.Value.ToString("dd-MM-yyyy"),
                    Tgl2DatePicker.Value.ToString("dd-MM-yyyy"));

            ListDataGrid.DataSource = listData;
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

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

        public SearchingForm(ISearchData<T> _injSearchBL)
        {
            InitializeComponent();
            _searchBL = _injSearchBL;
        }

        private void KeywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var listData = _searchBL.Search(KeywordTextBox.Text);
                ListDataGrid.DataSource = listData;
                foreach(DataGridViewColumn col in ListDataGrid.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

        private void KeywordTextBox_TextChanged(object sender, EventArgs e)
        {

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
    }
}

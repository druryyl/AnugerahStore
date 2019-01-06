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
        public SearchingForm(ISearchData<T> _injSearchBL)
        {
            InitializeComponent();
            _searchBL = _injSearchBL;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var listData = _searchBL.Search(textBox1.Text);
                ListDataGrid.DataSource = listData;
            }
        }
    }
}

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
        public IEnumerable<T> ListData;

        public SearchingForm(IEnumerable<T> listData)
        {
            InitializeComponent();
            ListData = listData;

            ListDataGrid.DataSource = ListData;
        }
    }
}

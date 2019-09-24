using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.StokBarang.Presenter;
using AnugerahWinform.StokBarang.View;
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
    public partial class BPStokInfoForm : Form, IBPStokInfoView
    {
        private BindingSource _listResultBindingSource = new BindingSource();
        private List<BPStokInfoRowModel> _listResultDataSource = new List<BPStokInfoRowModel>();

        private readonly BPStokInfoPresenter _presenter;

        public BPStokInfoForm()
        {
            InitializeComponent();
            _presenter = new BPStokInfoPresenter(this);

            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.DataSource = _listResultBindingSource;
            ResultGridView.Columns["QtyIn"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["QtyOut"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["Saldo"].DefaultCellStyle = NumericStyle();
        }

        private DataGridViewCellStyle NumericStyle()
        {
            var result = new DataGridViewCellStyle
            {
                Format = "###.#0;(###.#0);-",
                Alignment = DataGridViewContentAlignment.MiddleRight,
            };
            return result;
        }

        private DataGridViewCellStyle StringStyle => new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft };

        public DateTime PeriodeAwal
        {
            get => PeriodeMonthCalender.SelectionStart;
            set => PeriodeMonthCalender.SelectionStart = value;
        }
        public DateTime PeriodeAkhir
        {
            get => PeriodeMonthCalender.SelectionEnd;
            set => PeriodeMonthCalender.SelectionEnd = value;
        }
        public string SearchKeyword
        {
            get => SearchTextBox.Text;
            set => SearchTextBox.Text = value;
        }
        public bool IsDetail
        {
            get => IsDetailCheckBox.Checked;
            set => IsDetailCheckBox.Checked = value;
        }
        public List<BPStokInfoRowModel> ListResult
        {
            get => _listResultDataSource;
            set
            {
                _listResultDataSource = value;
                _listResultBindingSource.DataSource = _listResultDataSource;
            }
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            _presenter.Proses();
            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            foreach (DataGridViewRow item in ResultGridView.Rows)
            {
                if (item.Cells["BrgID"].Value.ToString().Trim() != "")
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    item.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}

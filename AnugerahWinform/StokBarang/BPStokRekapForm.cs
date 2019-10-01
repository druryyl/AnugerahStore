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
    public partial class BPStokRekapForm : Form, IBPStokRekapView
    {
        private BindingSource _listResultBindingSource = new BindingSource();
        private List<BPStokRekapRowModel> _listResultDataSource = new List<BPStokRekapRowModel>();
        private List<BPStokRekapRowForecastingModel> _listResultForecastingDataSource = new List<BPStokRekapRowForecastingModel>();

        private readonly BPStokRekapPresenter _presenter;

        public BPStokRekapForm()
        {
            InitializeComponent();
            _presenter = new BPStokRekapPresenter(this);

            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.DataSource = _listResultBindingSource;
            ResultGridView.Columns["Qty"].DefaultCellStyle = NumericStyle();
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

        public string SearchKeyword
        {
            get => SearchTextBox.Text;
            set => SearchTextBox.Text = value;
        }
        public bool IsForecasting
        {
            get => IsForecastCheckBox.Checked;
            set
            {
                IsForecastCheckBox.Checked = value;
                ForecastingPanel.Visible = value;
            }
        }
        public int ProgressCounter
        {
            get => ProsesProgressBar.Value;
            set => ProsesProgressBar.Value = value;
        }
        public int ProgressMax
        {
            get => ProsesProgressBar.Maximum;
            set => ProsesProgressBar.Maximum = value;
        }

        public decimal PeriodeAnalisa
        {
            get => PeriodeAnalisaNumText.Value;
            set => PeriodeAnalisaNumText.Value = value;
        }
        public decimal LeadTime
        {
            get => MaxLevelNumText.Value;
            set => MaxLevelNumText.Value = value;
        }

        public List<BPStokRekapRowModel> ListResult
        {
            get => _listResultDataSource;
            set
            {
                _listResultDataSource = value;
                _listResultBindingSource.DataSource = _listResultDataSource;
            }
        }

        public List<BPStokRekapRowForecastingModel> ListResultForecasting
        {
            get => _listResultForecastingDataSource;
            set
            {
                _listResultForecastingDataSource = value;
                _listResultBindingSource.DataSource = _listResultForecastingDataSource;
            }
        }


        private void ProsesButton_Click(object sender, EventArgs e)
        {
            ProsesProgressBar.Visible = true;

            _presenter.Proses();
            if (!IsForecasting)
                _listResultBindingSource.DataSource = _listResultDataSource;
            else
            {
                _listResultBindingSource.DataSource = _listResultForecastingDataSource;
                ResultGridView.Columns["MovingAvg"].DefaultCellStyle = NumericStyle();
                ResultGridView.Columns["MaxStock"].DefaultCellStyle = NumericStyle();
                ResultGridView.Columns["MinStock"].DefaultCellStyle = NumericStyle();
                ResultGridView.Columns["ReOrder"].DefaultCellStyle = NumericStyle();
            }

            ResultGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            ProsesProgressBar.Value = 0;
            ProsesProgressBar.Visible = false;
        }

        private void IsForecastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ForecastingPanel.Visible = IsForecastCheckBox.Checked;
        }
    }
}

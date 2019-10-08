using AnugerahWinform.Penjualan.Presenter;
using AnugerahWinform.Penjualan.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Penjualan
{
    public partial class LapPenjualanForm : Form, ILapPenjualanView
    {
        private BindingSource _listResultBindingSource = new BindingSource();
        private List<PenjualanViewModel> _listResultDataSource = new List<PenjualanViewModel>();

        private readonly LapPenjualanPresenter _presenter;

        public LapPenjualanForm()
        {
            InitializeComponent();
            _presenter = new LapPenjualanPresenter(this);

            _listResultBindingSource = new BindingSource();
            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.DataSource = _listResultBindingSource;

            FormatGrid();
            PeriodeLabel.Text = PeriodeMonthCalender.SelectionStart.Date.ToString("dd MMM yyyy");
        }

        private void FormatGrid()
        {
            ResultGridView.Columns["Penjualan"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["Kas"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["BcaEdc"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["BcaTrf"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["BriEdc"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["BriTrf"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["Deposit"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["Piutang"].DefaultCellStyle = NumericStyle();

            ResultGridView.Columns["CustomerName"].HeaderText = "Customer";
            ResultGridView.Columns["BcaEdc"].HeaderText = "EDC BCA";
            ResultGridView.Columns["BcaTrf"].HeaderText = "Trf BCA";
            ResultGridView.Columns["BriEdc"].HeaderText = "EDC BRI";
            ResultGridView.Columns["BriTrf"].HeaderText = "Trf BRI";

            ResultGridView.Columns["Tgl"].Width = 80;
            ResultGridView.Columns["NoNota"].Width = 80;
            ResultGridView.Columns["CustomerName"].Width = 180;
            ResultGridView.Columns["Penjualan"].Width = 100;
            ResultGridView.Columns["Kas"].Width = 100;
            ResultGridView.Columns["BcaEdc"].Width = 100;
            ResultGridView.Columns["BcaTrf"].Width = 100;
            ResultGridView.Columns["BriEdc"].Width = 100;
            ResultGridView.Columns["BriTrf"].Width = 100;
            ResultGridView.Columns["Deposit"].Width = 100;
            ResultGridView.Columns["Piutang"].Width = 100;
            ResultGridView.Columns["Keterangan"].Width = 150;
        }

        private DataGridViewCellStyle NumericStyle()
        {
            var result = new DataGridViewCellStyle
            {
                Format = "####,###,###;(####,###,###);-",
                Alignment = DataGridViewContentAlignment.MiddleRight,
            };
            return result;
        }

        private DataGridViewCellStyle StringStyle
            => new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft };


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
        public List<PenjualanViewModel> ListResult
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
            ProsesProgressBar.Visible = true;

            _presenter.Proses();
            _listResultBindingSource.DataSource = _listResultDataSource;

            //  baris balance diberi warna biru tua
            ProsesProgressBar.Value = 0;
            ProsesProgressBar.Maximum = ResultGridView.Rows.Count;
            foreach (DataGridViewRow row in ResultGridView.Rows)
            {
                ProsesProgressBar.Value++;
                if (row.Cells["Tgl"].Value.ToString().Trim() != "")
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    row.DefaultCellStyle.BackColor = Color.White;

                if (row.Cells["CustomerName"].Value.ToString().Trim() == "TOTAL")
                {
                    row.Cells["CustomerName"].Style.BackColor = Color.LightCoral;
                    row.Cells["Penjualan"].Style.BackColor = Color.LightCoral;
                    row.Cells["Kas"].Style.BackColor = Color.LightCoral;
                    row.Cells["BcaEdc"].Style.BackColor = Color.LightCoral;
                    row.Cells["BcaTrf"].Style.BackColor = Color.LightCoral;
                    row.Cells["BriEdc"].Style.BackColor = Color.LightCoral;
                    row.Cells["BriTrf"].Style.BackColor = Color.LightCoral;
                    row.Cells["Piutang"].Style.BackColor = Color.LightCoral;
                    row.Cells["Deposit"].Style.BackColor = Color.LightCoral;
                    row.Cells["Keterangan"].Style.BackColor = Color.LightCoral;
                }
            }
            ProsesProgressBar.Value = 0;
            ProsesProgressBar.Visible = false;
        }

        private void PeriodeMonthCalender_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (PeriodeMonthCalender.SelectionStart.Date != PeriodeMonthCalender.SelectionEnd.Date)
                PeriodeLabel.Text = string.Format("{0} - {1}",
                    PeriodeMonthCalender.SelectionStart.ToString("dd MMM yyyy"),
                    PeriodeMonthCalender.SelectionEnd.ToString("dd MMM yyyy"));
            else
                PeriodeLabel.Text = string.Format("{0}",
                    PeriodeMonthCalender.SelectionStart.ToString("dd MMM yyyy"));
        }
    }
}

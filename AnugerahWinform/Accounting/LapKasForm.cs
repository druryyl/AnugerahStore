using AnugerahWinform.Accounting.Presenter;
using AnugerahWinform.Accounting.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Accounting
{
    public partial class LapKasForm : Form, ILapKasView
    {
        private BindingSource _listResultBindingSource = new BindingSource();
        private List<LapKasViewModel> _listResultDataSource = new List<LapKasViewModel>();

        private readonly LapKasPresenter _presenter;

        public LapKasForm()
        {
            InitializeComponent();
            _presenter = new LapKasPresenter(this);

            _listResultBindingSource = new BindingSource();
            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.DataSource = _listResultBindingSource;

            FormatGrid();
            PeriodeLabel.Text = PeriodeMonthCalender.SelectionStart.Date.ToString("dd MMM yyyy");
        }

        private void FormatGrid()
        {
            ResultGridView.Columns["KasKecil"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["KasBankBca"].DefaultCellStyle = NumericStyle();
            ResultGridView.Columns["KasBankBri"].DefaultCellStyle = NumericStyle();

            ResultGridView.Columns["KasKecil"].HeaderText = "Kas Kecil";
            ResultGridView.Columns["KasBankBca"].HeaderText = "Kas Bank BCA";
            ResultGridView.Columns["KasBankBri"].HeaderText = "Kas Bank BRI";

            ResultGridView.Columns["Tgl"].Width = 80;
            ResultGridView.Columns["NoTransaksi"].Width = 80;
            ResultGridView.Columns["Keterangan"].Width = 180;
            ResultGridView.Columns["KasKecil"].Width = 100;
            ResultGridView.Columns["KasBankBca"].Width = 100;
            ResultGridView.Columns["KasBankBri"].Width = 100;
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
        public List<LapKasViewModel> ListResult
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

                if (row.Cells["NoTransaksi"].Value.ToString().Trim() == "TOTAL")
                {
                    row.Cells["NoTransaksi"].Style.BackColor = Color.LightCoral;
                    row.Cells["KasKecil"].Style.BackColor = Color.LightCoral;
                    row.Cells["KasBankBca"].Style.BackColor = Color.LightCoral;
                    row.Cells["kasBankBri"].Style.BackColor = Color.LightCoral;
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

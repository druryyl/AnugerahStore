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

            PeriodeLabel.Text = PeriodeMonthCalender.SelectionStart.Date.ToString("dd MMM yyyy");
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
        public List<BPStokInfoRowModel> ListResult
        {
            get => _listResultDataSource;
            set
            {
                _listResultDataSource = value;
                _listResultBindingSource.DataSource = _listResultDataSource;
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


        private void ProsesButton_Click(object sender, EventArgs e)
        {
            ProsesProgressBar.Visible = true;

            _presenter.Proses();
            _listResultBindingSource.DataSource = _listResultDataSource;
            ResultGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            ProsesProgressBar.Value = 0;
            ProsesProgressBar.Maximum = ResultGridView.Rows.Count;
            //  baris stok awal diberi warna biru muda
            foreach (DataGridViewRow item in ResultGridView.Rows)
            {
                ProsesProgressBar.Value++;

                if (item.Cells["BrgID"].Value.ToString().Trim() != "")
                    item.DefaultCellStyle.BackColor = Color.LightBlue;
                else
                    item.DefaultCellStyle.BackColor = Color.White;
            }

            //  baris balance diberi warna biru tua
            ProsesProgressBar.Value = 0;
            ProsesProgressBar.Maximum = ResultGridView.Rows.Count;
            foreach (DataGridViewRow row in ResultGridView.Rows)
            {
                ProsesProgressBar.Value++;
                if (row.Cells["Keterangan"].Value.ToString().Trim() == "BALANCE")
                {
                    row.Cells["Keterangan"].Style.BackColor = Color.LightCoral;
                    row.Cells["QtyIn"].Style.BackColor = Color.LightCoral;
                    row.Cells["QtyOut"].Style.BackColor = Color.LightCoral;
                    row.Cells["Saldo"].Style.BackColor = Color.LightCoral;
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

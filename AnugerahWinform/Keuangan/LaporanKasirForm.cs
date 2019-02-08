using AnugerahBackend.Keuangan.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Keuangan
{
    public partial class LaporanKasirForm : Form
    {
        private IBukuKasDal _bukuKasDal;

        public LaporanKasirForm()
        {
            InitializeComponent();
            _bukuKasDal = new BukuKasDal();
        }

        private void ProsesButton_Click(object sender, EventArgs e)
        {
            Proses();
        }

        private void Proses()
        {
            var tgl1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            var tgl2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");
            var listData = _bukuKasDal.ListData(tgl1, tgl2);
            if (listData == null) return;

            var dataSource = listData.ToList();

            LaporanKasirTable.Rows.Clear();
            foreach (var item in dataSource)
            {
                LaporanKasirTable.Rows.Add(
                    item.TglBuku, 
                    item.JamBuku, 
                    item.BukuKasID, 
                    item.JenisTrsKasirName + " - " + item.Keterangan, 
                    item.PihakKetigaName, 
                    item.NilaiKas.ToString("N0").PadLeft(15,' '));
            }
                

        }
    }
}

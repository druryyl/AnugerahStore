using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
using AnugerahWinform.Support;
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
    public partial class PenjualanBayarForm : Form
    {
        public IEnumerable<PenjualanBayarModel> ListBayar;
        private IJenisBayarDal _jenisBayarDal;

        public PenjualanBayarForm(IEnumerable<PenjualanBayarModel> listBayar)
        {
            InitializeComponent();

            _jenisBayarDal = new JenisBayarDal();
            ListBayar = listBayar;

            ShowListBayar();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SetFormResult();
            DialogResult = DialogResult.OK;
        }

        private void BayarGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SearchJenisBayar(e.RowIndex);
                ShowJenisBayar(e.RowIndex);
            }
        }

        private void ShowListBayar()
        {
            //  clear grid
            DetilBayarTable.Rows.Clear();

            //  tampilkan data bayar
            if(ListBayar!=null)
                foreach (var item in ListBayar)
                {
                    DetilBayarTable.Rows.Add(
                        item.JenisBayarID,
                        item.JenisBayarName,
                        item.NilaiBayar,
                        item.Catatan);
                }
            //  tambahkan baris kosong (new data)
            DetilBayarTable.Rows.Add("", "", 0, "");
        }

        private void SetFormResult()
        {
            var result = new List<PenjualanBayarModel>();

            var i = 0;
            foreach (DataRow dr in DetilBayarTable.Rows)
            {
                result.Add(new PenjualanBayarModel
                {
                    NoUrut = i,
                    JenisBayarID = dr["JenisBayarIDCol"].ToString(),
                    NilaiBayar = Convert.ToDecimal(dr["NilaiBayarCol"]),
                    Catatan = dr["CatatanCol"].ToString()
                });
                i++;
            }
            ListBayar = result;
        }

        private void SearchJenisBayar(int rowIndex)
        {
            var searchForm = new SearchingForm<JenisBayarModel>(_jenisBayarDal, false);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var result = searchForm.SelectedDataKey;
                DetilBayarTable.Rows[rowIndex]["JenisBayarIDCol"] = result;
            }
        }

        private void ShowJenisBayar(int rowIndex)
        {
            var id = DetilBayarTable.Rows[rowIndex]["JenisBayarIDCol"].ToString();
            var jenisBayar = _jenisBayarDal.GetData(id);
            if (jenisBayar == null) return;
            DetilBayarTable.Rows[rowIndex]["JenisBayarNameCol"] = jenisBayar.JenisBayarName;

            var jenisBayarName = DetilBayarTable.Rows[rowIndex]["JenisBayarNameCol"].ToString();
            if ((jenisBayarName.Trim() != "") && (rowIndex == DetilBayarTable.Rows.Count - 1))
                DetilBayarTable.Rows.Add("", "", 0, "");
        }
    }
}

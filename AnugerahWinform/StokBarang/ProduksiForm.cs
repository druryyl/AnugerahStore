using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.StokBarang.Presenter;
using AnugerahWinform.StokBarang.View;
using Ics.Helper.StringDateTime;
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
    public partial class ProduksiForm : Form, IProduksiView
    {
        private ProduksiPresenter presenter;
        public ProduksiForm()
        {
            InitializeComponent();
        }

        public string ProduksiID
        {
            get => ProduksiIDTextBox.Text;
            set => ProduksiIDTextBox.Text = value;
        }
        public string Tgl
        {
            get => TanggalDateTime.Value.ToString("dd-MM-yyyy");
            set => TanggalDateTime.Value = value.ToDate();
        }
        public string Jam
        {
            get => JamTextBox.Text;
            set => JamTextBox.Text = value;
        }
        public string Keterangan
        {
            get => KeteranganTextBox.Text;
            set => KeteranganTextBox.Text = value;
        }
        public List<ProduksiMaterialModel> ListMaterial
        {
            get => GetListMaterial();
            set => SetListMaterial(value);
        }
        public List<ProduksiHasilModel> ListHasil
        {
            get => GetListHasil();
            set => SetListHasil(value);
        }

        private List<ProduksiMaterialModel> GetListMaterial()
        {
            List<ProduksiMaterialModel> result = null;
            for (int i = 0; i <= MaterialTable.Rows.Count - 1; i++)
            {
                if (result == null) result = new List<ProduksiMaterialModel>();
                var item = DataRowToModelMaterial(i);
                result.Add(item);
            }
            return result;
        }
        private ProduksiMaterialModel DataRowToModelMaterial(int rowIndex)
        {
            DataRow dr = MaterialTable.Rows[rowIndex];
            var result = new ProduksiMaterialModel
            {
                NoUrut = rowIndex,
                BrgID = dr["BrgID"].ToString(),
                BrgName = dr["BrgName"].ToString(),
                Qty = Convert.ToInt64(dr["Qty"]),
                Hpp= Convert.ToDecimal(dr["Hpp"]),
            };
            return result;
        }
        private void ModelToDataRowMaterial(int rowIndex, ProduksiMaterialModel produksimaterial)
        {
            if (produksimaterial == null) return;
            DataRow dr = MaterialTable.Rows[rowIndex];
            dr["BrgID"] = produksimaterial.BrgID;
            dr["BrgName"] = produksimaterial.BrgName;
            dr["Qty"] = produksimaterial.Qty;
            dr["Hpp"] = produksimaterial.Hpp;
        }
        private void SetListMaterial(IEnumerable<ProduksiMaterialModel> listBrg)
        {
            if (listBrg == null) return;

            MaterialTable.Rows.Clear();
            foreach (var item in listBrg)
            {
                MaterialTable.Rows.Add("", "", 0, 0, 0, 0, 0);
                ModelToDataRowMaterial(MaterialTable.Rows.Count - 1, item);
            }
        }


        private List<ProduksiHasilModel> GetListHasil()
        {
            List<ProduksiHasilModel> result = null;
            for (int i = 0; i <= HasilTable.Rows.Count - 1; i++)
            {
                if (result == null) result = new List<ProduksiHasilModel>();
                var item = DataRowToModelHasil(i);
                result.Add(item);
            }
            return result;
        }
        private ProduksiHasilModel DataRowToModelHasil(int rowIndex)
        {
            DataRow dr = HasilTable.Rows[rowIndex];
            var result = new ProduksiHasilModel
            {
                NoUrut = rowIndex,
                BrgID = dr["BrgID"].ToString(),
                BrgName = dr["BrgName"].ToString(),
                Qty = Convert.ToInt64(dr["Qty"]),
                Hpp = Convert.ToDecimal(dr["Hpp"]),
            };
            return result;
        }
        private void ModelToDataRowHasil(int rowIndex, ProduksiHasilModel produksiHasil)
        {
            if (produksiHasil == null) return;
            DataRow dr = MaterialTable.Rows[rowIndex];
            dr["BrgID"] = produksiHasil.BrgID;
            dr["BrgName"] = produksiHasil.BrgName;
            dr["Qty"] = produksiHasil.Qty;
            dr["Hpp"] = produksiHasil.Hpp;
        }
        private void SetListHasil(IEnumerable<ProduksiHasilModel> listBrg)
        {
            if (listBrg == null) return;

            HasilTable.Rows.Clear();
            foreach (var item in listBrg)
            {
                HasilTable.Rows.Add("", "", 0, 0, 0, 0, 0);
                ModelToDataRowHasil(HasilTable.Rows.Count - 1, item);
            }
        }

        private void MaterialGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var purchaseDetil = DataRowToModelMaterial(e.RowIndex);
                //purchaseDetil = presenter.PilihBrg(purchaseDetil);
                ModelToDataRowMaterial(e.RowIndex, purchaseDetil);
            }
        }
    }
}

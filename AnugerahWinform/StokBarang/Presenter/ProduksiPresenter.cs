using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.StokBarang.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.StokBarang.Presenter
{
    public class ProduksiPresenter
    {
        private IProduksiView _view;

        public ProduksiPresenter(IProduksiView view)
        {
            _view = view;
        }

        //public ProduksiMaterialModel PilihBrgMaterial(ProduksiDetilModel pd)
        //{
        //    var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
        //    var resultDialog = searchForm.ShowDialog();
        //    if (resultDialog == DialogResult.OK)
        //    {
        //        var brgID = searchForm.SelectedDataKey;
        //        var brg = _brgBL.GetData(brgID);
        //        if (brg == null) return pd;

        //        if (pd == null) pd = new PurchaseDetilModel();

        //        pd.BrgID = brgID;
        //        pd.BrgName = brg.BrgName;
        //    }
        //    return pd;
        //}
    }
}

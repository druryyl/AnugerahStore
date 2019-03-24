using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.StokBarang.View;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.StokBarang.Presenter
{
    public class RepackPresenter
    {
        private IRepackView _view;
        private IRepackBL _repackBL;
        private IBrgBL _brgBL;
        private IBPStokBL _bpStokBL;

        public RepackPresenter(IRepackView view)
        {
            _view = view;
            _repackBL = new RepackBL();
            _brgBL = new BrgBL();
            _bpStokBL = new BPStokBL();
        }

        public void Save()
        {
            var repack = new RepackModel
            {
                RepackID = _view.RepackID,
                Tgl = _view.Tgl,
                Jam = _view.Jam,
                BPStokID = _view.BPStokID,

                BrgIDMaterial = _view.BrgIDMaterial,
                BrgNameMaterial = _view.BrgNameMaterial,
                QtyMaterial = _view.QtyMaterial,
                HppMaterial = _view.HppMaterial,

                BrgIDHasil = _view.BrgIDHasil,
                BrgNameHasil = _view.BrgIDHasil,
                QtyHasil = _view.QtyHasil,
                HppHasil = _view.HppHasil,
                SlotControl = _view.SlotControl
            };

            using (var trans = TransHelper.NewScope())
            {
                _repackBL.Save(repack);
                trans.Complete();
            }
        }

        public void New()
        {
            _view.RepackID = "";
            _view.Tgl = DateTime.Now.ToString("dd-MM-yyyy");
            _view.Jam = DateTime.Now.ToString("HH:mm:ss");

            _view.BrgIDMaterial = "";
            _view.BrgNameMaterial = "";
            _view.QtyMaterial = 0;
            _view.HppMaterial = 0;

            _view.BrgIDHasil = "";
            _view.BrgNameHasil = "";
            _view.QtyHasil = 0;
            _view.HppHasil = 0;
            _view.SlotControl = "";
        }

        public void PilihRepackID()
        {
            var searchForm = new SearchingForm<RepackSearchModel>(_repackBL);
            var resultDialog = searchForm.ShowDialog();
            if(resultDialog == DialogResult.OK)
            {
                var repackID = searchForm.SelectedDataKey;
                var repack = _repackBL.GetData(repackID);
                if (repack == null) return;

                _view.RepackID = repack.RepackID;
                _view.Tgl = repack.Tgl;
                _view.Jam = repack.Jam;
                _view.BPStokID = repack.BPStokID;

                _view.BrgIDMaterial = repack.BrgIDMaterial;
                _view.BrgNameMaterial = repack.BrgNameMaterial;
                _view.QtyMaterial = repack.QtyMaterial;
                _view.HppMaterial = repack.HppMaterial;

                _view.BrgIDHasil = repack.BrgIDHasil;
                _view.BrgNameHasil = repack.BrgNameMaterial;
                _view.QtyHasil = repack.QtyHasil;
                _view.HppHasil = repack.HppHasil;
                _view.SlotControl = repack.SlotControl;
            }
        }

        public void PilihBPStokIDMaterial()
        {
            var searchForm = new SearchingForm<BPStokSearchModel>(_bpStokBL);
            var resultDialog = searchForm.ShowDialog();
            if(resultDialog == DialogResult.OK)
            {
                var bpStok = _bpStokBL.GetData(searchForm.SelectedDataKey);
                _view.BPStokID = bpStok.BPStokID;
                _view.BrgIDMaterial= bpStok.BrgID;
                _view.BrgNameMaterial= bpStok.BrgName;
                _view.HppMaterial = bpStok.NilaiHpp;
            }
        }

        public void PilihBrgIDHasil()
        {
            var searchForm = new SearchingForm<BrgSearchResultModel>(_brgBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                var brg = _brgBL.GetData(searchForm.SelectedDataKey);
                _view.BrgIDHasil = brg.BrgID;
                _view.BrgNameHasil = brg.BrgName;
            }
        }
    }
}

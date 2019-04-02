using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahWinform.Accounting.View;
using AnugerahWinform.Support;
using Ics.Helper.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnugerahWinform.Accounting.Presenter
{
    public class MutasiKasPresenterDependency
    {
        public IMutasiKasBL MutasiKasBL { get; set; }
        public IPegawaiBL PegawaiBL { get; set; }
        public IJenisKasBL JenisKasBL { get; set; }
        public IBPKasBL BPKasBL { get; set; }
    }

    public class MutasiKasPresenter
    {
        private IMutasiKasView _view;
        private MutasiKasPresenterDependency _dep;

        public MutasiKasPresenter(IMutasiKasView view)
        {
            _view = view;
            _dep = new MutasiKasPresenterDependency
            {
                MutasiKasBL = new MutasiKasBL(),
                PegawaiBL = new PegawaiBL(),
                JenisKasBL = new JenisKasBL(),
                BPKasBL = new BPKasBL()
            };
        }

        public MutasiKasPresenter(IMutasiKasView view, MutasiKasPresenterDependency dep)
        {
            _view = view;
            _dep = dep;
        }

        public void Save()
        {
            var mutasiKas = new MutasiKasModel
            {
                MutasiKasID = _view.MutasiKasID,
                Tgl = _view.Tgl,
                Jam = _view.Jam,
                Keterangan = _view.Keterangan,
                PegawaiID = _view.PegawaiID,
                PegawaiName = _view.PegawaiName,
                JenisKasIDAsal = _view.JenisKasIDAsal,
                JenisKasNameAsal = _view.JenisKasNameAsal,
                JenisKasIDTujan = _view.JenisKasIDTujuan,
                NilaiKas = _view.NilaiKas
            };
            using (var trans = TransHelper.NewScope())
            {
                _dep.MutasiKasBL.Save(mutasiKas);
                _dep.BPKasBL.Generate(mutasiKas);
                New();
                trans.Complete();
            }
        }

        public void Delete()
        {
            _dep.MutasiKasBL.Delete(_view.MutasiKasID);
        }

        public void New()
        {
            _view.MutasiKasID = "";
            _view.Tgl = DateTime.Now.ToString("dd-MM-yyyy");
            _view.Jam = DateTime.Now.ToString("HH:mm:ss");
            _view.Keterangan = "";
            _view.PegawaiID = "";
            _view.PegawaiName = "";
            _view.JenisKasIDAsal = "";
            _view.JenisKasNameAsal = "";
            _view.JenisKasIDTujuan = "";
            _view.NilaiKas = 0;
        }

        public void PilihKasir()
        {
            var searchForm = new SearchingForm<PegawaiSearchModel>(_dep.PegawaiBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog != DialogResult.OK) return;

            var pegawaiID = searchForm.SelectedDataKey;
            var pegawai = _dep.PegawaiBL.GetData(pegawaiID);

            if (pegawai != null)
            {
                _view.PegawaiID = pegawaiID;
                _view.PegawaiName = pegawai.PegawaiName;
            }
        }

        public void PilihJenisKasAsal()
        {
            var searchForm = new SearchingForm<JenisKasModel>(_dep.JenisKasBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog != DialogResult.OK) return;

            var jenisKasID = searchForm.SelectedDataKey;
            var jenisKas = _dep.JenisKasBL.GetData(jenisKasID);

            if(jenisKas != null)
            {
                _view.JenisKasIDAsal = jenisKasID;
                _view.JenisKasNameAsal = jenisKas.JenisKasName;
            }
        }

        public void PilihJenisKasTujuan()
        {
            var searchForm = new SearchingForm<JenisKasModel>(_dep.JenisKasBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog != DialogResult.OK) return;

            var jenisKasID = searchForm.SelectedDataKey;
            var jenisKas = _dep.JenisKasBL.GetData(jenisKasID);

            if (jenisKas != null)
            {
                _view.JenisKasIDTujuan = jenisKasID;
                _view.JenisKasNameTujuan = jenisKas.JenisKasName;
            }
        }

        public void PilihMutasiKas()
        {
            var searchForm = new SearchingForm<MutasiKasSearchModel>(_dep.MutasiKasBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog != DialogResult.OK) return;

            var mutasiKasID = searchForm.SelectedDataKey;
            var mutasiKas = _dep.MutasiKasBL.GetData(mutasiKasID);

            if (mutasiKas != null)
            {
                _view.MutasiKasID = mutasiKasID;
                _view.Tgl = mutasiKas.Tgl;
                _view.Jam = mutasiKas.Jam;
                _view.Keterangan = mutasiKas.Keterangan;
                _view.PegawaiID = mutasiKas.PegawaiID;
                _view.PegawaiName = mutasiKas.PegawaiName;
                _view.JenisKasIDAsal = mutasiKas.JenisKasIDAsal;
                _view.JenisKasNameAsal = mutasiKas.JenisKasNameAsal;
                _view.JenisKasIDTujuan = mutasiKas.JenisKasIDTujan;
                _view.JenisKasNameTujuan = mutasiKas.JenisKasNameTujuan;
                _view.NilaiKas = mutasiKas.NilaiKas;
            }
        }
    }
}

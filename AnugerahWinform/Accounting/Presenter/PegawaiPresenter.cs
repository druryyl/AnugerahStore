using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnugerahBackend.Accounting.BL;
using AnugerahBackend.Accounting.Model;
using AnugerahBackend.Pembelian.BL;
using AnugerahBackend.Pembelian.Model;
using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
using AnugerahWinform.Accounting.View;
using AnugerahWinform.Pembelian.View;
using AnugerahWinform.Support;
using Ics.Helper.Database;

namespace AnugerahWinform.Accounting.Presenter
{
    public class PegawaiPresenter
    {
        private IPegawaiView _view;
        private IPegawaiBL _pegawaiBL;

        public PegawaiPresenter(IPegawaiView view)
        {
            _view = view;
            _pegawaiBL = new PegawaiBL();
        }

        public PegawaiPresenter(IPegawaiView view, IPegawaiBL pegawaiBL)
        {
            _view = view;
            _pegawaiBL = pegawaiBL;
        }

        public void Save()
        {
            var pegawai = new PegawaiModel
            {
                PegawaiID = _view.PegawaiID,
                PegawaiName = _view.PegawaiName,
                Alamat = _view.Alamat,
                NoTelp = _view.NoTelp
            };

            var result = _pegawaiBL.Save(pegawai);
        }

        public void New()
        {
            _view.PegawaiID = "";
            _view.PegawaiName = "";
            _view.Alamat = "";
            _view.NoTelp = "";
        }

        public string PilihPegawai()
        {
            var result = "";
            var searchForm = new SearchingForm<PegawaiSearchModel>(_pegawaiBL);
            var resultDialog = searchForm.ShowDialog();
            if (resultDialog == DialogResult.OK)
            {
                result = searchForm.SelectedDataKey;
            }
            var pegawai = _pegawaiBL.GetData(result);

            if (pegawai != null)
            {
                _view.PegawaiID = result;
                _view.PegawaiName = pegawai.PegawaiName;
                _view.Alamat = pegawai.Alamat;
                _view.NoTelp = pegawai.NoTelp;
            }

            return result;
        }
    }
}
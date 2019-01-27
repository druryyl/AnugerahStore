using AnugerahBackend.Penjualan.Dal;
using AnugerahBackend.Penjualan.Model;
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
            ListBayar = listBayar;
            _jenisBayarDal = new JenisBayarDal();
        }

        private void PenjualanBayarForm_Load(object sender, EventArgs e)
        {
            //  clear grid
            DetilBayarTable.Rows.Clear();

            //  tampilkan data bayar
            foreach(var item in ListBayar)
            {
                DetilBayarTable.Rows.Add(
                    item.JenisBayarID, 
                    item.JenisBayarName, 
                    item.NilaiBayar, 
                    item.Catatan);
            }
            DetilBayarTable.Rows.Add("", "", 0, "");
        }

        private void OKButton_Click(object sender, EventArgs e)
        {

        }
    }
}

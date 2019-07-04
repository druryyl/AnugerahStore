using AnugerahBackend.Penjualan.Model;
using Ics.Helper.StringDateTime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnugerahWinform.PrintDoc
{
    public class NotaJualPrintDoc
    {
        PenjualanModel _penjualan;

        private Font _font;
        private StreamReader reader;
        private string _fileName;
        private string _printerName;

        public NotaJualPrintDoc(PenjualanModel penjualan)
        {
            _penjualan = penjualan;
            _fileName = ConfigurationManager.AppSettings["TemporerPrintFile"];
            _printerName = ConfigurationManager.AppSettings["PrinterNotaJual"];

        }
        public void Print()
        {
            CreateTextFileTMU();

            //  print textfile
            reader = new StreamReader(_fileName);
            _font = new Font("Courier New", 10);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintTextFileHandler);
            Margins margins = new Margins(10, 0, 10, 0);
            pd.DefaultPageSettings.Margins = margins;
            pd.DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.Low;
            pd.PrinterSettings.PrinterName = _printerName;
            pd.Print();
            reader.Close();
        }

        private void CreateTextFile()
        {
            var sw = new StreamWriter(_fileName);
            //  print area : 90 char x 29 baris Courier New 8
            //           "123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 12345678 0"
            var kiri0 = "ANUGERAH SPS";                         var kanan0 = "Yogyakarta, " + _penjualan.TglPenjualan.ToDate().ToLongDateString();
            var kiri1 = "Jl.Kol.Sugiyono 65";                   var kanan1 = " ";
            var kiri2 = "Yogyakarta 55153";                     var kanan2 = "Kepada Yth,";
            var kiri3 = "No.Telp : (0274) 123-456";             var kanan3 = "Bp/Ibu. " + _penjualan.BuyerName;
            var kiri4 = "";                                     var kanan4 = _penjualan.Alamat;
            var kiri5 = "No.Nota : " + _penjualan.PenjualanID;  var kanan5 = _penjualan.NoTelp;

            sw.WriteLine(kiri0.PadRight(51, ' ') + ' ' + kanan0);
            sw.WriteLine(kiri1.PadRight(51, ' ') + ' ' + kanan1);
            sw.WriteLine(kiri2.PadRight(51, ' ') + ' ' + kanan2);
            sw.WriteLine(kiri3.PadRight(51, ' ') + ' ' + kanan3);
            sw.WriteLine(kiri4.PadRight(51, ' ') + ' ' + kanan4);
            sw.WriteLine(kiri5.PadRight(51, ' ') + ' ' + kanan5);

            //  header
            //           "123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 12345678 0"
            sw.WriteLine("------------------------------------------------------------------------------------------");
            sw.WriteLine("No| Nama Barang                               | Qty | Harga     | Diskon    | Sub Total   ");
            sw.WriteLine("------------------------------------------------------------------------------------------");

            //  content
            var lineCounter = 0;
            foreach(var item in _penjualan.ListBrg.OrderBy(x => x.NoUrut))
            {
                var no = (item.NoUrut + 1).ToString().PadLeft(2,' ');
                var namaBrg = item.BrgName.PadRight(43, ' ');
                //if (namaBrg.ToLower().Contains("jasa"))
                //    namaBrg = GetNamaBrgJasa(item.NoUrut);
                var qty = item.Qty.ToString().PadLeft(5, ' ');
                var harga = item.Harga.ToString("N0").PadLeft(11);
                var diskon = item.Diskon.ToString("N0").PadLeft(11);
                var subTotal = item.SubTotal.ToString("N0").PadLeft(11);
                sw.WriteLine(no + '|'+ namaBrg + '|' + qty + '|' + harga + '|' + diskon + '|' + subTotal);
                lineCounter++;
            }

            if(lineCounter < 8)
                for(int i = lineCounter; i<=10; i++)
                    sw.WriteLine("  |                                           |     |           |           |             ");
            sw.WriteLine("------------------------------------------------------------------------------------------");
            //               "123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 12345678 0"
            var nilaiTotal = "Total      : " + _penjualan.NilaiTotal.ToString("N0").PadLeft(11,' ');
            var nilaiDiskn = "Diskon Lain: " + _penjualan.NilaiDiskonLain.ToString("N0").PadLeft(11,' ');
            var nilaiBiaya = "Biaya Lain : " + _penjualan.NilaiBiayaLain.ToString("N0").PadLeft(11,' ');
            var nilaiGrand = "Grand Total: " + _penjualan.NilaiGrandTotal.ToString("N0").PadLeft(11,' ');
            //sw.WriteLine("                                                                --------------------------");
            sw.WriteLine(nilaiTotal.PadLeft(88));
            sw.WriteLine(nilaiDiskn.PadLeft(88));
            sw.WriteLine(nilaiBiaya.PadLeft(88));
            sw.WriteLine(nilaiGrand.PadLeft(88));
            sw.WriteLine(" ");
            sw.WriteLine("                                                                Hormat Kami,");
            sw.WriteLine("Terimakasih seudah berbelanja di tempat kami.");
            sw.WriteLine("Brg yg sudah dibeli, tidak dapat dikembalikan.                  Kasir: DIAS ");

            sw.Close();
        }
        private void CreateTextFileTMU()
        {
            var sw = new StreamWriter(_fileName);
            //  header
            //           "123456789 123456789 1234567"
            sw.WriteLine("       ANUGERAH SPS        ");
            sw.WriteLine("Jl.Kol.Sugiyono 65 - Jogja");
            sw.WriteLine("Telp/WA 0811-268-1605");
            sw.WriteLine(" ");
            if (_penjualan.CustomerName.Trim() != "")
            {
                sw.WriteLine("Yth." + _penjualan.CustomerName);
                if (_penjualan.BuyerName.Trim() != "")
                    sw.WriteLine("(a/n " + _penjualan.BuyerName);
            }
            else
            {
                if (_penjualan.BuyerName.Trim() != "")
                    sw.WriteLine("(Yth. " + _penjualan.BuyerName);
            }
            sw.WriteLine(" ");
            sw.WriteLine(_penjualan.PenjualanID + " / " + _penjualan.TglPenjualan);
            sw.WriteLine("Item Pembelian");
            sw.WriteLine("---------------------------");
            foreach (var item in _penjualan.ListBrg.OrderBy(x => x.NoUrut))
            {
                var no = (item.NoUrut + 1).ToString().PadLeft(2, ' ');
                var namaBrg = item.BrgName.PadRight(27, ' ');
                //  tentukan format qty; bulat atau pecaha
                decimal xsisa = item.Qty % 1;
                string qty;
                if(xsisa !=0)
                    qty = item.Qty.ToString().PadLeft(3, ' ');
                else
                    qty = item.Qty.ToString("N0").PadLeft(3, ' ');

                var harga = item.Harga.ToString("N0").PadLeft(8);
                var diskon = item.Diskon.ToString("N0").PadLeft(9);
                var hrgDiskon = (item.Harga - item.Diskon).ToString("N0").PadLeft(8);
                var subTotal = item.SubTotal.ToString("N0").PadLeft(9);
                sw.WriteLine(namaBrg);
                var lineStr = string.Format("  {0}x {1} = {2}",
                    qty, hrgDiskon, subTotal);
                sw.WriteLine(lineStr);
            }
            sw.WriteLine("---------------------------");
            var nilaiTotal = "Total   : " + _penjualan.NilaiTotal.ToString("N0").PadLeft(11, ' ');
            var nilaiDiskn = "Diskon  : " + _penjualan.NilaiDiskonLain.ToString("N0").PadLeft(11, ' ');
            var nilaiBiaya = "Biaya   : " + _penjualan.NilaiBiayaLain.ToString("N0").PadLeft(11, ' ');
            var nilaiGrand = "GrandTot: " + _penjualan.NilaiGrandTotal.ToString("N0").PadLeft(11, ' ');

            sw.WriteLine(nilaiTotal.PadLeft(27));
            sw.WriteLine(nilaiDiskn.PadLeft(27));
            sw.WriteLine(nilaiBiaya.PadLeft(27));
            sw.WriteLine(nilaiGrand.PadLeft(27));
            sw.WriteLine(" ");
            sw.WriteLine("Hormat Kami,");
            sw.WriteLine(" ");
            sw.WriteLine("Kasir: DIAS ");
            sw.WriteLine(" ");
            sw.WriteLine("Trimakasih sudah belanja");
            sw.WriteLine("di tempat kami.");







            sw.Close();
        }

        private void PrintTextFileHandler(object sender, PrintPageEventArgs ppeArgs)
        {
            //Get the Graphics object  
            Graphics g = ppeArgs.Graphics;
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;

            //Read margins from PrintPageEventArgs  
            float leftMargin = ppeArgs.MarginBounds.Left;
            float topMargin = ppeArgs.MarginBounds.Top;
            string line = null;

            //Calculate the lines per page on the basis of the height of the page and the height of the font  
            linesPerPage = ppeArgs.MarginBounds.Height / _font.GetHeight(g);

            //Now read lines one by one, using StreamReader  
            while (count < linesPerPage && ((line = reader.ReadLine()) != null))
            {
                //Calculate the starting position  
                yPos = topMargin + (count * _font.GetHeight(g));

                //Draw text  
                g.DrawString(line, _font, Brushes.Black, leftMargin, yPos, new StringFormat());

                //Move to next line  
                count++;
            }

            //If PrintPageEventArgs has more pages to print  
            if (line != null)
            {
                ppeArgs.HasMorePages = true;
            }
            else
            {
                ppeArgs.HasMorePages = false;
            }
        }
    }
}

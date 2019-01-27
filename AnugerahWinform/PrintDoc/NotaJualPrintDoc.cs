﻿using AnugerahBackend.Penjualan.Model;
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

        private Font _courierNew10Font;
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
            CreateTextFile();

            //  print textfile
            reader = new StreamReader(_fileName);
            _courierNew10Font = new Font("Courier New", 8);
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintTextFileHandler);
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
                var qty = item.Qty.ToString().PadLeft(5, ' ');
                var harga = item.Harga.ToString("N0").PadLeft(11);
                var diskon = item.Diskon.ToString("N0").PadLeft(11);
                var subTotal = item.SubTotal.ToString("N0").PadLeft(11);
                sw.WriteLine(no + '|'+ namaBrg + '|' + qty + '|' + harga + '|' + diskon + '|' + subTotal);
                lineCounter++;
            }

            if(lineCounter<12)
                for(int i = lineCounter; i<=12; i++)
                    sw.WriteLine("  |                                           |     |           |           |             ");
            sw.WriteLine("------------------------------------------------------------------------------------------");
            //               "123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 12345678 0"
            var nilaiTotal = "Total      : " + _penjualan.NilaiTotal.ToString("N0").PadLeft(11,' ');
            var nilaiDiskn = "Diskon Lain: " + _penjualan.NilaiDiskonLain.ToString("N0").PadLeft(11,' ');
            var nilaiBiaya = "Biaya Lain : " + _penjualan.NilaiBiayaLain.ToString("N0").PadLeft(11,' ');
            var nilaiGrand = "Grand Total: " + _penjualan.NilaiGrandTotal.ToString("N0").PadLeft(11,' ');
            sw.WriteLine(nilaiTotal.PadLeft(88));
            sw.WriteLine(nilaiDiskn.PadLeft(88));
            sw.WriteLine(nilaiBiaya.PadLeft(88));
            sw.WriteLine(nilaiGrand.PadLeft(88));
            sw.WriteLine(" ");
            sw.WriteLine("                                                                Hormat Kami,");
            sw.WriteLine(" ");
            sw.WriteLine(" ");
            sw.WriteLine("Terimakasih seudah berbelanja di tempat kami.");
            sw.WriteLine("Brg yg sudah dibeli, tidak dapat dikembalikan.                  Kasir: ");

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
            linesPerPage = ppeArgs.MarginBounds.Height / _courierNew10Font.GetHeight(g);

            //Now read lines one by one, using StreamReader  
            while (count < linesPerPage && ((line = reader.ReadLine()) != null))
            {
                //Calculate the starting position  
                yPos = topMargin + (count * _courierNew10Font.GetHeight(g));

                //Draw text  
                g.DrawString(line, _courierNew10Font, Brushes.Black, leftMargin, yPos, new StringFormat());

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
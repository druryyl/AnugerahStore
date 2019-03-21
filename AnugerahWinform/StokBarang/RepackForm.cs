﻿using AnugerahWinform.StokBarang.View;
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
    public partial class RepackForm : Form, IRepackView
    {
        public RepackForm()
        {
            InitializeComponent();
        }

        public string RepackID
        {
            get => RepackIDTextBox.Text;
            set => RepackIDTextBox.Text = value;
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
        public string BrgIDMaterial
        {
            get => BrgIDMaterialTextBox.Text;
            set => BrgIDMaterialTextBox.Text = value;
        }
        public string BrgNameMaterial
        {
            get => BrgNameMaterialTextBox.Text;
            set => BrgNameMaterialTextBox.Text = value;
        }
        public long QtyMaterial
        {
            get => Convert.ToInt64(QtyMaterialTextBox.Value);
            set => QtyMaterialTextBox.Value = value;
        }
        public decimal HppMaterial
        {
            get => HppMaterialTextBox.Value;
            set => HppMaterialTextBox.Value = value;
        }
        public string BrgIDHasil
        {
            get => BrgIDHasilTextBox.Text;
            set => BrgIDHasilTextBox.Text = value;
        }
        public string BrgNameHasil
        {
            get => BrgNameHasilTextBox.Text;
            set => BrgNameHasilTextBox.Text = value;
        }
        public long QtyHasil
        {
            get => Convert.ToInt64(QtyHasilTextBox.Value);
            set => QtyHasilTextBox.Value = value;
        }
        public decimal HppHasil
        {
            get => HppHasilTextBox.Value;
            set => HppHasilTextBox.Value = value;
        }
    }
} 

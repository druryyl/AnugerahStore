using AnugerahBackend.StokBarang.BL;
using AnugerahBackend.StokBarang.Model;
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
    public partial class ColorForm : Form
    {
        private IColorBL _colorBL;

        public ColorForm()
        {
            InitializeComponent();

            _colorBL = new ColorBL();

            RedSlider.Maximum = 255;
            GreenSlider.Maximum = 255;
            BlueSlider.Maximum = 255;

            ColorPanel.BackColor = Color.FromArgb(RedSlider.Value,
                GreenSlider.Value, BlueSlider.Value);
            LoadColorComboBox();
        }

        private void LoadColorComboBox()
        {
            ColorIDComboBox.DataSource = null;
            ColorIDComboBox.Items.Clear();

            //  ambil data
            var listColor = _colorBL.ListData();

            //  exit jika kosong
            if (listColor == null)
                return;

            var listColorOrdered = listColor
                .OrderBy(x => x.ColorID)
                .Select(x => x.ColorID)
                .ToList();
            ColorIDComboBox.DataSource = listColorOrdered;
        }

        private void LoadDataColor()
        {
            var color = _colorBL.GetData(ColorIDComboBox.Text);
            if(color == null)
            {
                RedTextBox.Value = 0;
                GreenTextBox.Value = 0;
                BlueTextBox.Value = 0;
                return;
            }
            RedTextBox.Value = color.RedValue;
            GreenTextBox.Value = color.GreenValue;
            BlueTextBox.Value = color.BlueValue;
            WhiteForeColorCheckBox.Checked = color.IsWhiteForeColor;
        }

        private void RedSlider_Scroll(object sender, EventArgs e)
        {
            RedSlider.BackColor = Color.FromArgb(RedSlider.Value, 0, 0);
            RedTextBox.Text = RedSlider.Value.ToString();
            ChangeColorPanel();
        }

        private void ChangeColorPanel()
        {
            ColorPanel.BackColor = Color.FromArgb(
                RedSlider.Value,
                GreenSlider.Value,
                BlueSlider.Value);
        }

        private void GreenSlider_Scroll(object sender, EventArgs e)
        {
            GreenSlider.BackColor = Color.FromArgb(0, GreenSlider.Value,  0);
            GreenTextBox.Text = GreenSlider.Value.ToString();
            ChangeColorPanel();
        }

        private void BlueSlider_Scroll(object sender, EventArgs e)
        {
            BlueSlider.BackColor = Color.FromArgb(0, 0, BlueSlider.Value);
            BlueTextBox.Text = BlueSlider.Value.ToString();
            ChangeColorPanel();
        }

        private void RedTextBox_ValueChanged(object sender, EventArgs e)
        {
            RedSlider.Value = (int)RedTextBox.Value;
        }

        private void GreenTextBox_ValueChanged(object sender, EventArgs e)
        {
            GreenSlider.Value = (int)GreenTextBox.Value;
        }

        private void BlueTextBox_ValueChanged(object sender, EventArgs e)
        {
            BlueSlider.Value = (int)BlueTextBox.Value;
        }

        private void ColorIDComboBox_Validating(object sender, CancelEventArgs e)
        {
            LoadDataColor();
        }

        private void ColorIDComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataColor();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var color = new ColorModel
            {
                ColorID = ColorIDComboBox.Text,
                RedValue = (int)RedTextBox.Value,
                GreenValue = (int)GreenTextBox.Value,
                BlueValue = (int)BlueTextBox.Value,
                IsWhiteForeColor = WhiteForeColorCheckBox.Checked
            };
            _colorBL.Save(color);
            LoadColorComboBox();
            ColorIDComboBox.Text = "";
            LoadDataColor();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete", "Color", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            _colorBL.Delete(ColorIDComboBox.Text);
            LoadColorComboBox();
            ColorIDComboBox.Text = "";
            LoadDataColor();
        }
    }
}

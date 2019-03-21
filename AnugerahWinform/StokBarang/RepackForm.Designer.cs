namespace AnugerahWinform.StokBarang
{
    partial class RepackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RepackIDTextBox = new System.Windows.Forms.TextBox();
            this.TanggalDateTime = new System.Windows.Forms.DateTimePicker();
            this.JamTextBox = new System.Windows.Forms.MaskedTextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.SearchRepackIDButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BrgIDMaterialTextBox = new System.Windows.Forms.TextBox();
            this.BrgMaterialSearchButton = new System.Windows.Forms.Button();
            this.BrgNameMaterialTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.QtyMaterialTextBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.HppMaterialTextBox = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HppHasilTextBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.QtyHasilTextBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.BrgNameHasilTextBox = new System.Windows.Forms.TextBox();
            this.BrgIDHasilSearchButton = new System.Windows.Forms.Button();
            this.BrgIDHasilTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtyMaterialTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HppMaterialTextBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HppHasilTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyHasilTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.HppMaterialTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.QtyMaterialTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BrgNameMaterialTextBox);
            this.panel1.Controls.Add(this.BrgMaterialSearchButton);
            this.panel1.Controls.Add(this.BrgIDMaterialTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TanggalDateTime);
            this.panel1.Controls.Add(this.JamTextBox);
            this.panel1.Controls.Add(this.NewButton);
            this.panel1.Controls.Add(this.SearchRepackIDButton);
            this.panel1.Controls.Add(this.RepackIDTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 254);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repack ID";
            // 
            // RepackIDTextBox
            // 
            this.RepackIDTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RepackIDTextBox.Location = new System.Drawing.Point(11, 24);
            this.RepackIDTextBox.Name = "RepackIDTextBox";
            this.RepackIDTextBox.ReadOnly = true;
            this.RepackIDTextBox.Size = new System.Drawing.Size(188, 21);
            this.RepackIDTextBox.TabIndex = 1;
            // 
            // TanggalDateTime
            // 
            this.TanggalDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TanggalDateTime.CustomFormat = "dd-MMM-yyyy";
            this.TanggalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TanggalDateTime.Location = new System.Drawing.Point(11, 64);
            this.TanggalDateTime.Name = "TanggalDateTime";
            this.TanggalDateTime.Size = new System.Drawing.Size(203, 21);
            this.TanggalDateTime.TabIndex = 18;
            // 
            // JamTextBox
            // 
            this.JamTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.JamTextBox.Location = new System.Drawing.Point(220, 64);
            this.JamTextBox.Mask = "99:99:99";
            this.JamTextBox.Name = "JamTextBox";
            this.JamTextBox.Size = new System.Drawing.Size(72, 21);
            this.JamTextBox.TabIndex = 19;
            // 
            // NewButton
            // 
            this.NewButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NewButton.Location = new System.Drawing.Point(229, 23);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(63, 23);
            this.NewButton.TabIndex = 17;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            // 
            // SearchRepackIDButton
            // 
            this.SearchRepackIDButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SearchRepackIDButton.Location = new System.Drawing.Point(201, 23);
            this.SearchRepackIDButton.Name = "SearchRepackIDButton";
            this.SearchRepackIDButton.Size = new System.Drawing.Size(27, 23);
            this.SearchRepackIDButton.TabIndex = 16;
            this.SearchRepackIDButton.Text = "...";
            this.SearchRepackIDButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tgl - Jam";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Brg Material";
            // 
            // BrgIDMaterialTextBox
            // 
            this.BrgIDMaterialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgIDMaterialTextBox.Location = new System.Drawing.Point(11, 104);
            this.BrgIDMaterialTextBox.Name = "BrgIDMaterialTextBox";
            this.BrgIDMaterialTextBox.ReadOnly = true;
            this.BrgIDMaterialTextBox.Size = new System.Drawing.Size(248, 21);
            this.BrgIDMaterialTextBox.TabIndex = 22;
            // 
            // BrgMaterialSearchButton
            // 
            this.BrgMaterialSearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BrgMaterialSearchButton.Location = new System.Drawing.Point(261, 103);
            this.BrgMaterialSearchButton.Name = "BrgMaterialSearchButton";
            this.BrgMaterialSearchButton.Size = new System.Drawing.Size(31, 23);
            this.BrgMaterialSearchButton.TabIndex = 23;
            this.BrgMaterialSearchButton.Text = "...";
            this.BrgMaterialSearchButton.UseVisualStyleBackColor = true;
            // 
            // BrgNameMaterialTextBox
            // 
            this.BrgNameMaterialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgNameMaterialTextBox.Location = new System.Drawing.Point(11, 131);
            this.BrgNameMaterialTextBox.Name = "BrgNameMaterialTextBox";
            this.BrgNameMaterialTextBox.Size = new System.Drawing.Size(281, 21);
            this.BrgNameMaterialTextBox.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Qty";
            // 
            // QtyMaterialTextBox
            // 
            this.QtyMaterialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.QtyMaterialTextBox.Location = new System.Drawing.Point(11, 171);
            this.QtyMaterialTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.QtyMaterialTextBox.Name = "QtyMaterialTextBox";
            this.QtyMaterialTextBox.Size = new System.Drawing.Size(281, 21);
            this.QtyMaterialTextBox.TabIndex = 26;
            this.QtyMaterialTextBox.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "HPP";
            // 
            // HppMaterialTextBox
            // 
            this.HppMaterialTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HppMaterialTextBox.Location = new System.Drawing.Point(11, 211);
            this.HppMaterialTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.HppMaterialTextBox.Name = "HppMaterialTextBox";
            this.HppMaterialTextBox.Size = new System.Drawing.Size(281, 21);
            this.HppMaterialTextBox.TabIndex = 28;
            this.HppMaterialTextBox.ThousandsSeparator = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.HppHasilTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.QtyHasilTextBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.BrgNameHasilTextBox);
            this.panel2.Controls.Add(this.BrgIDHasilSearchButton);
            this.panel2.Controls.Add(this.BrgIDHasilTextBox);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(11, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 178);
            this.panel2.TabIndex = 1;
            // 
            // HppHasilTextBox
            // 
            this.HppHasilTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HppHasilTextBox.Location = new System.Drawing.Point(11, 131);
            this.HppHasilTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.HppHasilTextBox.Name = "HppHasilTextBox";
            this.HppHasilTextBox.Size = new System.Drawing.Size(281, 21);
            this.HppHasilTextBox.TabIndex = 36;
            this.HppHasilTextBox.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "HPP";
            // 
            // QtyHasilTextBox
            // 
            this.QtyHasilTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.QtyHasilTextBox.Location = new System.Drawing.Point(11, 91);
            this.QtyHasilTextBox.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.QtyHasilTextBox.Name = "QtyHasilTextBox";
            this.QtyHasilTextBox.Size = new System.Drawing.Size(281, 21);
            this.QtyHasilTextBox.TabIndex = 34;
            this.QtyHasilTextBox.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Qty";
            // 
            // BrgNameHasilTextBox
            // 
            this.BrgNameHasilTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgNameHasilTextBox.Location = new System.Drawing.Point(11, 51);
            this.BrgNameHasilTextBox.Name = "BrgNameHasilTextBox";
            this.BrgNameHasilTextBox.Size = new System.Drawing.Size(281, 21);
            this.BrgNameHasilTextBox.TabIndex = 32;
            // 
            // BrgIDHasilSearchButton
            // 
            this.BrgIDHasilSearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BrgIDHasilSearchButton.Location = new System.Drawing.Point(261, 23);
            this.BrgIDHasilSearchButton.Name = "BrgIDHasilSearchButton";
            this.BrgIDHasilSearchButton.Size = new System.Drawing.Size(31, 23);
            this.BrgIDHasilSearchButton.TabIndex = 31;
            this.BrgIDHasilSearchButton.Text = "...";
            this.BrgIDHasilSearchButton.UseVisualStyleBackColor = true;
            // 
            // BrgIDHasilTextBox
            // 
            this.BrgIDHasilTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BrgIDHasilTextBox.Location = new System.Drawing.Point(11, 24);
            this.BrgIDHasilTextBox.Name = "BrgIDHasilTextBox";
            this.BrgIDHasilTextBox.ReadOnly = true;
            this.BrgIDHasilTextBox.Size = new System.Drawing.Size(248, 21);
            this.BrgIDHasilTextBox.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Brg Hasil";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.Location = new System.Drawing.Point(11, 456);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(151, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.Location = new System.Drawing.Point(168, 456);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Deletee";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(248, 456);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // RepackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(335, 491);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RepackForm";
            this.Text = "Repack Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QtyMaterialTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HppMaterialTextBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HppHasilTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QtyHasilTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RepackIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker TanggalDateTime;
        private System.Windows.Forms.MaskedTextBox JamTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button SearchRepackIDButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BrgNameMaterialTextBox;
        private System.Windows.Forms.Button BrgMaterialSearchButton;
        private System.Windows.Forms.TextBox BrgIDMaterialTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown HppMaterialTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown QtyMaterialTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown HppHasilTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown QtyHasilTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BrgNameHasilTextBox;
        private System.Windows.Forms.Button BrgIDHasilSearchButton;
        private System.Windows.Forms.TextBox BrgIDHasilTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ExitButton;
    }
}
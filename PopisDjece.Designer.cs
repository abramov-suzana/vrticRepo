namespace vrtic
{
    partial class PopisDjece
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
            this.dgvPopisDjece = new System.Windows.Forms.DataGridView();
            this.OIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumRodenja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImeOca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisDjece)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopisDjece
            // 
            this.dgvPopisDjece.AllowUserToAddRows = false;
            this.dgvPopisDjece.AllowUserToDeleteRows = false;
            this.dgvPopisDjece.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPopisDjece.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopisDjece.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OIB,
            this.Ime,
            this.Prezime,
            this.DatumRodenja,
            this.ImeOca,
            this.Adresa});
            this.dgvPopisDjece.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPopisDjece.Location = new System.Drawing.Point(0, 0);
            this.dgvPopisDjece.Name = "dgvPopisDjece";
            this.dgvPopisDjece.ReadOnly = true;
            this.dgvPopisDjece.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPopisDjece.Size = new System.Drawing.Size(444, 261);
            this.dgvPopisDjece.TabIndex = 0;
            this.dgvPopisDjece.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopisDjece_CellDoubleClick);
            // 
            // OIB
            // 
            this.OIB.HeaderText = "OIB";
            this.OIB.Name = "OIB";
            this.OIB.ReadOnly = true;
            // 
            // Ime
            // 
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // DatumRodenja
            // 
            this.DatumRodenja.HeaderText = "Datum rođenja";
            this.DatumRodenja.Name = "DatumRodenja";
            this.DatumRodenja.ReadOnly = true;
            // 
            // ImeOca
            // 
            this.ImeOca.HeaderText = "Ime oca";
            this.ImeOca.Name = "ImeOca";
            this.ImeOca.ReadOnly = true;
            // 
            // Adresa
            // 
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // PopisDjece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 261);
            this.Controls.Add(this.dgvPopisDjece);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopisDjece";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisDjece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn OIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumRodenja;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImeOca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        public System.Windows.Forms.DataGridView dgvPopisDjece;
    }
}
namespace vrtic
{
    partial class Evidencija
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
            this.dgvEvidencija = new System.Windows.Forms.DataGridView();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prisutan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RedovnoVrijeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProduzeniBoravak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Izvjestaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPohrani = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEvidencija
            // 
            this.dgvEvidencija.AllowUserToAddRows = false;
            this.dgvEvidencija.AllowUserToDeleteRows = false;
            this.dgvEvidencija.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvidencija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvidencija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvidencija.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Datum,
            this.OIB,
            this.Ime,
            this.Prezime,
            this.Prisutan,
            this.RedovnoVrijeme,
            this.ProduzeniBoravak,
            this.Izvjestaj});
            this.dgvEvidencija.Location = new System.Drawing.Point(-1, -1);
            this.dgvEvidencija.Name = "dgvEvidencija";
            this.dgvEvidencija.Size = new System.Drawing.Size(924, 279);
            this.dgvEvidencija.TabIndex = 0;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
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
            // Prisutan
            // 
            this.Prisutan.HeaderText = "Prisutan?";
            this.Prisutan.Name = "Prisutan";
            // 
            // RedovnoVrijeme
            // 
            this.RedovnoVrijeme.HeaderText = "Redovno vrijeme";
            this.RedovnoVrijeme.Name = "RedovnoVrijeme";
            // 
            // ProduzeniBoravak
            // 
            this.ProduzeniBoravak.HeaderText = "Produzeni Boravak";
            this.ProduzeniBoravak.Name = "ProduzeniBoravak";
            // 
            // Izvjestaj
            // 
            this.Izvjestaj.HeaderText = "Izvjestaj";
            this.Izvjestaj.Name = "Izvjestaj";
            // 
            // btnPohrani
            // 
            this.btnPohrani.Location = new System.Drawing.Point(824, 371);
            this.btnPohrani.Name = "btnPohrani";
            this.btnPohrani.Size = new System.Drawing.Size(75, 23);
            this.btnPohrani.TabIndex = 1;
            this.btnPohrani.Text = "Pohrani promjene";
            this.btnPohrani.UseVisualStyleBackColor = true;
            this.btnPohrani.Click += new System.EventHandler(this.btnPohrani_Click);
            // 
            // Evidencija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 406);
            this.Controls.Add(this.btnPohrani);
            this.Controls.Add(this.dgvEvidencija);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Evidencija";
            this.Text = "Evidencija";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvidencija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEvidencija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn OIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Prisutan;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedovnoVrijeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProduzeniBoravak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Izvjestaj;
        private System.Windows.Forms.Button btnPohrani;
    }
}
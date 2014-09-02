namespace vrtic
{
    partial class PopisOsoblja
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
            this.dgvPopisOsoblja = new System.Windows.Forms.DataGridView();
            this.OIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisOsoblja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopisOsoblja
            // 
            this.dgvPopisOsoblja.AllowUserToAddRows = false;
            this.dgvPopisOsoblja.AllowUserToDeleteRows = false;
            this.dgvPopisOsoblja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPopisOsoblja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopisOsoblja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OIB,
            this.Ime,
            this.Prezime,
            this.Adresa});
            this.dgvPopisOsoblja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPopisOsoblja.Location = new System.Drawing.Point(0, 0);
            this.dgvPopisOsoblja.Name = "dgvPopisOsoblja";
            this.dgvPopisOsoblja.ReadOnly = true;
            this.dgvPopisOsoblja.Size = new System.Drawing.Size(948, 566);
            this.dgvPopisOsoblja.TabIndex = 0;
            this.dgvPopisOsoblja.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopisOsoblja_CellDoubleClick);
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
            // Adresa
            // 
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            this.Adresa.ReadOnly = true;
            // 
            // PopisOsoblja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 566);
            this.Controls.Add(this.dgvPopisOsoblja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopisOsoblja";
            this.Text = "PopisOsoblja";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopisOsoblja)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPopisOsoblja;
        private System.Windows.Forms.DataGridViewTextBoxColumn OIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
    }
}
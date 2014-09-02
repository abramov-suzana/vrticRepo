namespace vrtic
{
    partial class Izdajracun
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
            this.dgvPopis = new System.Windows.Forms.DataGridView();
            this.OIB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PREZIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Izradi = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopis)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPopis
            // 
            this.dgvPopis.AllowUserToAddRows = false;
            this.dgvPopis.AllowUserToDeleteRows = false;
            this.dgvPopis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPopis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPopis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OIB,
            this.IME,
            this.PREZIME,
            this.Izradi});
            this.dgvPopis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPopis.Location = new System.Drawing.Point(0, 0);
            this.dgvPopis.Name = "dgvPopis";
            this.dgvPopis.Size = new System.Drawing.Size(284, 261);
            this.dgvPopis.TabIndex = 0;
            this.dgvPopis.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPopis_CellClick);
            // 
            // OIB
            // 
            this.OIB.HeaderText = "OIB";
            this.OIB.Name = "OIB";
            // 
            // IME
            // 
            this.IME.HeaderText = "IME";
            this.IME.Name = "IME";
            // 
            // PREZIME
            // 
            this.PREZIME.HeaderText = "PREZIME";
            this.PREZIME.Name = "PREZIME";
            // 
            // Izradi
            // 
            this.Izradi.HeaderText = "Izradi";
            this.Izradi.Name = "Izradi";
            // 
            // Izdajracun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.dgvPopis);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Izdajracun";
            this.Text = "Izdaj račun";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPopis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvPopis;
        private System.Windows.Forms.DataGridViewTextBoxColumn OIB;
        private System.Windows.Forms.DataGridViewTextBoxColumn IME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PREZIME;
        private System.Windows.Forms.DataGridViewButtonColumn Izradi;

    }
}
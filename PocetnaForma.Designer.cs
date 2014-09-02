namespace vrtic
{
    partial class PocetnaForma
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
            this.glavniMeni = new System.Windows.Forms.MenuStrip();
            this.početnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.djecaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidencijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popisDjeceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osobljeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.popisOsobljaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajZaposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajDijeteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.računiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izdavanjeRačunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledIzvjestajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promjenaTarifeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslRod = new System.Windows.Forms.ToolStripStatusLabel();
            this.glavniMeni.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glavniMeni
            // 
            this.glavniMeni.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.početnaToolStripMenuItem,
            this.djecaToolStripMenuItem,
            this.osobljeToolStripMenuItem,
            this.računiToolStripMenuItem});
            this.glavniMeni.Location = new System.Drawing.Point(0, 0);
            this.glavniMeni.Name = "glavniMeni";
            this.glavniMeni.Size = new System.Drawing.Size(1008, 24);
            this.glavniMeni.TabIndex = 0;
            this.glavniMeni.Text = "menuStrip1";
            // 
            // početnaToolStripMenuItem
            // 
            this.početnaToolStripMenuItem.Name = "početnaToolStripMenuItem";
            this.početnaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.početnaToolStripMenuItem.Text = "Početna";
            // 
            // djecaToolStripMenuItem
            // 
            this.djecaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evidencijaToolStripMenuItem,
            this.popisDjeceToolStripMenuItem,
            this.pregledIzvjestajaToolStripMenuItem});
            this.djecaToolStripMenuItem.Name = "djecaToolStripMenuItem";
            this.djecaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.djecaToolStripMenuItem.Text = "Odgajatelj";
            // 
            // evidencijaToolStripMenuItem
            // 
            this.evidencijaToolStripMenuItem.Name = "evidencijaToolStripMenuItem";
            this.evidencijaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.evidencijaToolStripMenuItem.Text = "Evidencija";
            this.evidencijaToolStripMenuItem.Click += new System.EventHandler(this.evidencijaToolStripMenuItem_Click);
            // 
            // popisDjeceToolStripMenuItem
            // 
            this.popisDjeceToolStripMenuItem.Name = "popisDjeceToolStripMenuItem";
            this.popisDjeceToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.popisDjeceToolStripMenuItem.Text = "Popis djece";
            this.popisDjeceToolStripMenuItem.Click += new System.EventHandler(this.popisDjeceToolStripMenuItem_Click);
            // 
            // osobljeToolStripMenuItem
            // 
            this.osobljeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.popisOsobljaToolStripMenuItem,
            this.dodajZaposlenikaToolStripMenuItem,
            this.dodajDijeteToolStripMenuItem});
            this.osobljeToolStripMenuItem.Name = "osobljeToolStripMenuItem";
            this.osobljeToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.osobljeToolStripMenuItem.Text = "Administrator";
            // 
            // popisOsobljaToolStripMenuItem
            // 
            this.popisOsobljaToolStripMenuItem.Name = "popisOsobljaToolStripMenuItem";
            this.popisOsobljaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.popisOsobljaToolStripMenuItem.Text = "Popis osoblja";
            this.popisOsobljaToolStripMenuItem.Click += new System.EventHandler(this.popisOsobljaToolStripMenuItem_Click);
            // 
            // dodajZaposlenikaToolStripMenuItem
            // 
            this.dodajZaposlenikaToolStripMenuItem.Name = "dodajZaposlenikaToolStripMenuItem";
            this.dodajZaposlenikaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dodajZaposlenikaToolStripMenuItem.Text = "Dodaj zaposlenika";
            this.dodajZaposlenikaToolStripMenuItem.Click += new System.EventHandler(this.dodajZaposlenikaToolStripMenuItem_Click);
            // 
            // dodajDijeteToolStripMenuItem
            // 
            this.dodajDijeteToolStripMenuItem.Name = "dodajDijeteToolStripMenuItem";
            this.dodajDijeteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dodajDijeteToolStripMenuItem.Text = "Dodaj dijete";
            this.dodajDijeteToolStripMenuItem.Click += new System.EventHandler(this.dodajDijeteToolStripMenuItem_Click);
            // 
            // računiToolStripMenuItem
            // 
            this.računiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izdavanjeRačunaToolStripMenuItem,
            this.promjenaTarifeToolStripMenuItem});
            this.računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            this.računiToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.računiToolStripMenuItem.Text = "Računovođa";
            // 
            // izdavanjeRačunaToolStripMenuItem
            // 
            this.izdavanjeRačunaToolStripMenuItem.Name = "izdavanjeRačunaToolStripMenuItem";
            this.izdavanjeRačunaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.izdavanjeRačunaToolStripMenuItem.Text = "Izdavanje računa";
            this.izdavanjeRačunaToolStripMenuItem.Click += new System.EventHandler(this.izdavanjeRačunaToolStripMenuItem_Click);
            // 
            // pregledIzvjestajaToolStripMenuItem
            // 
            this.pregledIzvjestajaToolStripMenuItem.Name = "pregledIzvjestajaToolStripMenuItem";
            this.pregledIzvjestajaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pregledIzvjestajaToolStripMenuItem.Text = "Pregled izvjestaja";
            this.pregledIzvjestajaToolStripMenuItem.Click += new System.EventHandler(this.pregledIzvjestajaToolStripMenuItem_Click);
            // 
            // promjenaTarifeToolStripMenuItem
            // 
            this.promjenaTarifeToolStripMenuItem.Name = "promjenaTarifeToolStripMenuItem";
            this.promjenaTarifeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.promjenaTarifeToolStripMenuItem.Text = "Promjena tarife";
            this.promjenaTarifeToolStripMenuItem.Click += new System.EventHandler(this.promjenaTarifeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRod});
            this.statusStrip1.Location = new System.Drawing.Point(0, 707);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslRod
            // 
            this.tslRod.Name = "tslRod";
            this.tslRod.Size = new System.Drawing.Size(67, 17);
            this.tslRod.Text = "Rođendani:";
            // 
            // PocetnaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.glavniMeni);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.glavniMeni;
            this.Name = "PocetnaForma";
            this.Text = "Vrtić";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.glavniMeni.ResumeLayout(false);
            this.glavniMeni.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip glavniMeni;
        private System.Windows.Forms.ToolStripMenuItem početnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem djecaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidencijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobljeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popisOsobljaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izdavanjeRačunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem popisDjeceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajZaposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajDijeteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledIzvjestajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promjenaTarifeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslRod;
    }
}


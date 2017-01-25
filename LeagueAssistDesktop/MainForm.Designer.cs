namespace LeagueAssistDesktop
{
    partial class MainForm
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.natjecanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledNatjecanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kreirajNatjecanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stvoriNovoNatjecanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kluboviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKlubovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKlubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.koloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorKolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.podaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stadioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prikažiSudceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.natjecanjaToolStripMenuItem,
            this.kluboviToolStripMenuItem,
            this.licenceToolStripMenuItem,
            this.koloToolStripMenuItem,
            this.podaciToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(937, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // natjecanjaToolStripMenuItem
            // 
            this.natjecanjaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledNatjecanjaToolStripMenuItem,
            this.kreirajNatjecanjeToolStripMenuItem,
            this.stvoriNovoNatjecanjeToolStripMenuItem});
            this.natjecanjaToolStripMenuItem.Name = "natjecanjaToolStripMenuItem";
            this.natjecanjaToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.natjecanjaToolStripMenuItem.Text = "Natjecanja";
            this.natjecanjaToolStripMenuItem.Click += new System.EventHandler(this.natjecanjaToolStripMenuItem_Click);
            // 
            // pregledNatjecanjaToolStripMenuItem
            // 
            this.pregledNatjecanjaToolStripMenuItem.Name = "pregledNatjecanjaToolStripMenuItem";
            this.pregledNatjecanjaToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pregledNatjecanjaToolStripMenuItem.Text = "Pregled natjecanja";
            this.pregledNatjecanjaToolStripMenuItem.Click += new System.EventHandler(this.pregledNatjecanjaToolStripMenuItem_Click);
            // 
            // kreirajNatjecanjeToolStripMenuItem
            // 
            this.kreirajNatjecanjeToolStripMenuItem.Name = "kreirajNatjecanjeToolStripMenuItem";
            this.kreirajNatjecanjeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.kreirajNatjecanjeToolStripMenuItem.Text = "Kreiraj natjecanje";
            // 
            // stvoriNovoNatjecanjeToolStripMenuItem
            // 
            this.stvoriNovoNatjecanjeToolStripMenuItem.Name = "stvoriNovoNatjecanjeToolStripMenuItem";
            this.stvoriNovoNatjecanjeToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.stvoriNovoNatjecanjeToolStripMenuItem.Text = "Stvori novo natjecanje";
            // 
            // kluboviToolStripMenuItem
            // 
            this.kluboviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKlubovaToolStripMenuItem,
            this.dodajKlubToolStripMenuItem});
            this.kluboviToolStripMenuItem.Name = "kluboviToolStripMenuItem";
            this.kluboviToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.kluboviToolStripMenuItem.Text = "Klubovi";
            // 
            // pregledKlubovaToolStripMenuItem
            // 
            this.pregledKlubovaToolStripMenuItem.Name = "pregledKlubovaToolStripMenuItem";
            this.pregledKlubovaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.pregledKlubovaToolStripMenuItem.Text = "Pregled klubova";
            // 
            // dodajKlubToolStripMenuItem
            // 
            this.dodajKlubToolStripMenuItem.Name = "dodajKlubToolStripMenuItem";
            this.dodajKlubToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.dodajKlubToolStripMenuItem.Text = "Dodaj klub";
            // 
            // licenceToolStripMenuItem
            // 
            this.licenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prikažiSudceToolStripMenuItem});
            this.licenceToolStripMenuItem.Name = "licenceToolStripMenuItem";
            this.licenceToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.licenceToolStripMenuItem.Text = "Licence";
            // 
            // koloToolStripMenuItem
            // 
            this.koloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatorKolaToolStripMenuItem,
            this.pregledKolaToolStripMenuItem});
            this.koloToolStripMenuItem.Name = "koloToolStripMenuItem";
            this.koloToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.koloToolStripMenuItem.Text = "Kolo";
            // 
            // generatorKolaToolStripMenuItem
            // 
            this.generatorKolaToolStripMenuItem.Name = "generatorKolaToolStripMenuItem";
            this.generatorKolaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.generatorKolaToolStripMenuItem.Text = "Generator kola";
            this.generatorKolaToolStripMenuItem.Click += new System.EventHandler(this.generatorKolaToolStripMenuItem_Click);
            // 
            // pregledKolaToolStripMenuItem
            // 
            this.pregledKolaToolStripMenuItem.Name = "pregledKolaToolStripMenuItem";
            this.pregledKolaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.pregledKolaToolStripMenuItem.Text = "Pregled kola";
            this.pregledKolaToolStripMenuItem.Click += new System.EventHandler(this.pregledKolaToolStripMenuItem_Click);
            // 
            // podaciToolStripMenuItem
            // 
            this.podaciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stadioniToolStripMenuItem});
            this.podaciToolStripMenuItem.Name = "podaciToolStripMenuItem";
            this.podaciToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.podaciToolStripMenuItem.Text = "Podaci";
            // 
            // stadioniToolStripMenuItem
            // 
            this.stadioniToolStripMenuItem.Name = "stadioniToolStripMenuItem";
            this.stadioniToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.stadioniToolStripMenuItem.Text = "Stadioni";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // prikažiSudceToolStripMenuItem
            // 
            this.prikažiSudceToolStripMenuItem.Name = "prikažiSudceToolStripMenuItem";
            this.prikažiSudceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.prikažiSudceToolStripMenuItem.Text = "Prikaži sudce";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(937, 375);
            this.Controls.Add(this.menuStrip2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem natjecanjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kluboviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem koloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledNatjecanjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kreirajNatjecanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKlubovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKlubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorKolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKolaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stadioniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stvoriNovoNatjecanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prikažiSudceToolStripMenuItem;
    }
}
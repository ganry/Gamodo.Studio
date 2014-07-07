namespace ActiveWare
{
    partial class HelpBrowser
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpBrowser));
            this.simpleExample1 = new ActiveWare.HTMLHelp.CHMBrowserControl();
            this.SuspendLayout();
            // 
            // simpleExample1
            // 
            this.simpleExample1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleExample1.Location = new System.Drawing.Point(0, 0);
            this.simpleExample1.Name = "simpleExample1";
            this.simpleExample1.Size = new System.Drawing.Size(319, 342);
            this.simpleExample1.TabIndex = 0;
            // 
            // HelpBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 342);
            this.Controls.Add(this.simpleExample1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpBrowser";
            this.Text = "HelpBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private CHMBrowserControl simpleExample1;
    }
}
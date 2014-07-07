using ActiveWare;

namespace Gamodo.UserInterface
{
    partial class HelpBrowserDock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpBrowserDock));
            this.helpBrowser = new ActiveWare.HelpBrowser();
            this.SuspendLayout();
            // 
            // helpBrowser
            // 
            resources.ApplyResources(this.helpBrowser, "helpBrowser");
            this.helpBrowser.Name = "helpBrowser";
            this.helpBrowser.TocSelected += new HtmlHelp.UIComponents.TocSelectedEventHandler(this.helpBrowser_TocSelected);
            // 
            // HelpBrowserDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpBrowser);
            this.Name = "HelpBrowserDock";
            this.ResumeLayout(false);

        }

        #endregion

        private HelpBrowser helpBrowser;


    }
}
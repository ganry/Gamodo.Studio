namespace Gamodo.UserInterface
{
    partial class CodeBrowserDock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeBrowserDock));
            this.codeBrowserControl = new ActiveWare.CodeBrowser.CodeBrowserControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbxLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.tbAutoDetectLanguage = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeBrowserControl
            // 
            resources.ApplyResources(this.codeBrowserControl, "codeBrowserControl");
            this.codeBrowserControl.Name = "codeBrowserControl";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbxLanguage,
            this.tbAutoDetectLanguage});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLanguage.Items.AddRange(new object[] {
            resources.GetString("cbxLanguage.Items"),
            resources.GetString("cbxLanguage.Items1"),
            resources.GetString("cbxLanguage.Items2"),
            resources.GetString("cbxLanguage.Items3")});
            this.cbxLanguage.Name = "cbxLanguage";
            resources.ApplyResources(this.cbxLanguage, "cbxLanguage");
            // 
            // tbAutoDetectLanguage
            // 
            this.tbAutoDetectLanguage.Checked = true;
            this.tbAutoDetectLanguage.CheckOnClick = true;
            this.tbAutoDetectLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbAutoDetectLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbAutoDetectLanguage, "tbAutoDetectLanguage");
            this.tbAutoDetectLanguage.Name = "tbAutoDetectLanguage";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.codeBrowserControl);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // CodeBrowserDock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CodeBrowserDock";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal ActiveWare.CodeBrowser.CodeBrowserControl codeBrowserControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbxLanguage;
        private System.Windows.Forms.ToolStripButton tbAutoDetectLanguage;
        private System.Windows.Forms.Panel panel1;

    }
}
using ActiveWare;

namespace Gamodo.Dialogs
{
    partial class DesktopColor
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
            this.magnifyingGlass = new ActiveWare.MagnifyingGlass();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // magnifyingGlass
            // 
            this.magnifyingGlass.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.magnifyingGlass.Location = new System.Drawing.Point(216, 187);
            this.magnifyingGlass.Name = "magnifyingGlass";
            this.magnifyingGlass.PixelRange = 1;
            this.magnifyingGlass.PixelSize = 5;
            this.magnifyingGlass.PosAlign = System.Drawing.ContentAlignment.TopLeft;
            this.magnifyingGlass.PosFormat = "#x ; #y";
            this.magnifyingGlass.ShowPixel = true;
            this.magnifyingGlass.ShowPosition = true;
            this.magnifyingGlass.Size = new System.Drawing.Size(15, 15);
            this.magnifyingGlass.TabIndex = 0;
            this.magnifyingGlass.UseMovingGlass = false;
            this.magnifyingGlass.DisplayUpdated += new ActiveWare.MagnifyingGlass.DisplayUpdatedDelegate(this.magnifyingGlass_DisplayUpdated);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 50);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // DesktopColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(88, 73);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.magnifyingGlass);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DesktopColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DesktopColor";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Deactivate += new System.EventHandler(this.DesktopColor_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DesktopColor_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MagnifyingGlass magnifyingGlass;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
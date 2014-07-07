using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveWare;
using Gamodo.Tabs.EditorTab;
using Gamodo.Tabs.EditorTab.Tools;

namespace Gamodo.Dialogs
{
    public partial class DesktopColor : Form
    {
        public DesktopColor()
        {
            InitializeComponent();
            magnifyingGlass.KeyDown += new KeyEventHandler(magnifyingGlass_KeyDown);
            magnifyingGlass.UpdateTimer.Start();
        }

        void magnifyingGlass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SelectColor()
        {
            label1.Text = HTMLColorConverter.convertColorToHtmlHexColor(panel1.BackColor);
        }

        private void magnifyingGlass_DisplayUpdated(MagnifyingGlass sender)
        {
            panel1.BackColor = magnifyingGlass.PixelColor;
            this.Location = MainForm.MousePosition;
            SelectColor();
        }

        private void DesktopColor_Deactivate(object sender, EventArgs e)
        {
            
            if (this.Owner is MainForm)
            {
                if ((Owner as MainForm).ActiveDocumentTab is EditorTab)
                    TemplateLoader.InsertString(label1.Text.ToString(), ((Owner as MainForm).ActiveDocumentTab as EditorTab).editor);
            }
            this.Close();
        }

        private void DesktopColor_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.mainForm.TopMost = false;
            MainForm.mainForm.BringToFront();
            MainForm.mainForm.Focus();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gamodo.Tabs.Interface;

namespace Gamodo.Tabs
{
    public partial class HelpBrowserTab : DocumentBase, ICloseAble
    {
        public string URI = "";

        public HelpBrowserTab()
        {
            InitializeComponent();
            this.Text = MainForm.rm.GetString("Help");
        }

        protected override string GetPersistString()
        {
            // Add extra information into the persist string for this document
            // so that it is available when deserialized.
            return GetType().ToString() + "," + URI;
        }

        #region ICloseAble
        public bool CanCloseTab()
        {
            return true;
        }
        #endregion

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            URI = webBrowser.Url.ToString();
        }
    }
}

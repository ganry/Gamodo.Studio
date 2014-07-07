using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using HtmlHelp.UIComponents;
using Gamodo.Tabs;
using HtmlHelp;

namespace Gamodo.UserInterface
{
    public partial class HelpBrowserDock : DockBase
    {
        public HelpBrowserDock()
        {
            InitializeComponent();

        }

        internal void AddHelp(string title, string fileName)
        {
            helpBrowser.AddHelp(title, fileName);
        }

        internal void AddHelp(string title, HtmlHelpSystem helpFile)
        {
            helpBrowser.AddHelp(title, helpFile);
        }

        internal static HelpBrowserTab FindHelpTab()
        {
            foreach (IDockContent item in MainForm.mainForm.dockPanel.Documents)
            {
                if (item is HelpBrowserTab)
                    return (item as HelpBrowserTab);
            }
            return null;
        }

        public HelpBrowserTab ShowHelp(string URI)
        {
            HelpBrowserTab helpBrowserTab = FindHelpTab();
            if (helpBrowserTab == null)
                helpBrowserTab = new HelpBrowserTab();

            helpBrowserTab.URI = URI;
            helpBrowserTab.Show(MainForm.mainForm.dockPanel);
            helpBrowserTab.webBrowser.Navigate(URI);

            return helpBrowserTab;
        }


        private void helpBrowser_TocSelected(object sender, TocEventArgs e)
        {
            if (e.Item != null)
            {
                ShowHelp(e.Item.Url);
            }
        }
    }
}

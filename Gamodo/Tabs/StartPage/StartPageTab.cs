using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Gamodo.Config;

namespace Gamodo.Tabs.StartPage
{
    public partial class StartPageTab : DocumentBase
    {
        private TreeNode phpRoot;
        private TreeNode cssRoot;
        private TreeNode htmlRoot;
        private TreeNode jsRoot;
        private TreeNode othersRoot;

        public StartPageTab()
        {
            InitializeComponent();

            this.Text = MainForm.rm.GetString("StartPage");
            lblInstalledVersion.Text = global.appVer;
        }

        private void StartPageTab_Load(object sender, EventArgs e)
        {
            phpRoot = new TreeNode("PHP");
            phpRoot.ImageIndex = 0;
            phpRoot.SelectedImageIndex = 0;

            htmlRoot = new TreeNode("HTML");
            htmlRoot.ImageIndex = 1;
            htmlRoot.SelectedImageIndex = 1;

            cssRoot = new TreeNode("CSS");
            cssRoot.ImageIndex = 2;
            cssRoot.SelectedImageIndex = 2;

            jsRoot = new TreeNode("JavaScript");
            jsRoot.ImageIndex = 3;
            jsRoot.SelectedImageIndex = 3;

            othersRoot= new TreeNode("Sonstige");
            othersRoot.ImageIndex = 4;
            othersRoot.SelectedImageIndex = 4;

            historyFiles.Nodes.Add(phpRoot);
            historyFiles.Nodes.Add(htmlRoot);
            historyFiles.Nodes.Add(cssRoot);
            historyFiles.Nodes.Add(jsRoot);
            historyFiles.Nodes.Add(othersRoot);

            foreach (var item in ConfigClass.Config.HistoryFileList)
            {
                TreeNode node = new TreeNode();
                node.Tag = item;
                node.Text = Path.GetFileName(item);

                if (item.EndsWith("php"))
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    phpRoot.Nodes.Add(node);
                }
                else if (item.EndsWith("html"))
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    htmlRoot.Nodes.Add(node);
                }
                else if (item.EndsWith("css"))
                {
                    node.ImageIndex = 2;
                    node.SelectedImageIndex = 2;

                    cssRoot.Nodes.Add(node);
                }
                else if (item.EndsWith("js"))
                {
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;

                    jsRoot.Nodes.Add(node);
                }
                else
                {
                    node.ImageIndex = 4;
                    node.SelectedImageIndex = 4;

                    othersRoot.Nodes.Add(node);
                }
            }

            historyFiles.ExpandAll();
            rssNews.Navigate("http://www.gamodo.de");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            MainForm.mainForm.tbOpen_Click(sender, e);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MainForm.mainForm.neuesDokumentToolStripMenuItem_Click(sender, e);
        }

        private void historyFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node != null) & (e.Node.Tag != null))
                MainForm.mainForm.OpenFile(e.Node.Tag.ToString());
        }
    }
}

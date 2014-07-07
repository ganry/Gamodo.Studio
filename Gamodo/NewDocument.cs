using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Gamodo.Tabs.EditorTab;

namespace Gamodo
{
    public partial class NewDocument : Form
    {
        public string SelectedTemplate = null;

        public NewDocument()
        {
            InitializeComponent();
        }

        private int GetImageIndex(string ext)
        {
            switch (ext)
            {
                case ".php":
                    return 0;
                case ".html":
                    return 1;
                case ".css":
                    return 2;
                case ".js":
                    return 3;
                default:
                    return -1;
            }
        }

        private void LoadFiles(string cat)
        {
            fileListView.Items.Clear();
            string[] folders = Directory.GetFiles(@"templates\wizard\" + cat);
            foreach (string file in folders)
            {
                string bufferFile = file;
                string ext = Path.GetExtension(file);
                //bufferFile = bufferFile.Replace(@"\bin\..", "");
                this.fileListView.Items.Add(Path.GetFileName(bufferFile),
                    GetImageIndex(ext));
            }

        }

        private void NewDocument_Load(object sender, EventArgs e)
        {
            string[] folders = Directory.GetDirectories(@"templates\wizard");
            foreach (string folder in folders)
                this.folderTreeView.Nodes.Add(Path.GetFileName(folder));
        }

        private void folderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (folderTreeView.SelectedNode != null)
            {
                LoadFiles(folderTreeView.SelectedNode.Text);
                filePathTextBox.Text = @"templates\wizard\" + folderTreeView.SelectedNode.Text;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedItems.Count == 1)
            {
                SelectedTemplate = filePathTextBox.Text + @"\" + fileListView.SelectedItems[0].Text;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

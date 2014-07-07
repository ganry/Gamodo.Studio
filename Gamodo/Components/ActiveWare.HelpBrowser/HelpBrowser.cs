using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;
using HtmlHelp;
using HtmlHelp.UIComponents;
using System.Collections;
using System.Collections.ObjectModel;
using System.Drawing;

namespace ActiveWare
{
	public partial class HelpBrowser : UserControl
	{
		private TreeModel _model;
        private HtmlHelpSystem currentHelpSystem = null;
        private PleaseWait pleaseWait = null;
        private ArrayList helpSystems;
        public event TocSelectedEventHandler TocSelected;

        private Collection<Node> chmNode;

		public HelpBrowser()
		{
			InitializeComponent();
			_model = new TreeModel();
			_tree.Model = _model;
            helpSystems = new ArrayList();
		}

        public void AddHelp(string title, HtmlHelpSystem helpFile)
        {
            helpSystems.Add(helpFile);

            Node node = new Node(title);
            node.Image = hhImages.Images[3];
            node.Object = helpFile;
            _model.Nodes.Add(node);
        }

        public void AddHelp(string title, string fileName)
        {
            HtmlHelpSystem helpFile = new HtmlHelpSystem();
            helpFile.OpenFile(fileName);
            helpSystems.Add(helpFile);
            /*
            phpHelpFile = 
            mysqlHelpFile = new HtmlHelpSystem();
            phpHelpFile.OpenFile();
            mysqlHelpFile.OpenFile("help/mysql_5.0_en.chm");
            */
            Node node = new Node(title);
            node.Image = hhImages.Images[3];
            node.Object = helpFile;
            _model.Nodes.Add(node);
        }

        /// <summary>
        /// Fireing the on selected event
        /// </summary>
        /// <param name="e">event parameters</param>
        protected virtual void OnTocSelected(TocEventArgs e)
        {
            if (TocSelected != null)
            {
                TocSelected(this, e);
            }
        }

        /// <summary>
        /// Recursively builds the toc tree and fills the treeview
        /// </summary>
        /// <param name="tocItems">list of toc-items</param>
        /// <param name="col">treenode collection of the current level</param>
        /// <param name="filter">information type/category filter</param>
        private void BuildTOC(ArrayList tocItems, Collection<Node> nodes)
        {
            for (int i = 0; i < tocItems.Count; i++)
            {
                
                TOCItem curItem = (TOCItem)tocItems[i];
                Node newNode = new Node(curItem.Name);
                newNode.Object = curItem;
                if (curItem.Children.Count > 0)
                    newNode.Image = hhImages.Images[0];
                else
                    newNode.Image = hhImages.Images[2];
                
                //newNode.Image = hhImages.Images[curItem.ImageIndex];
                nodes.Add(newNode);

                if (curItem.Children.Count > 0)
                {
                    BuildTOC(curItem.Children, newNode.Nodes);
                }

                // check if we have a book/folder which doesn't have any children
                // after applied filter.
                if ((curItem.Children.Count > 0) && (newNode.Nodes.Count <= 0))
                {
                    // check if the item has a local value
                    // if not, this don't display this item in the tree
                    if (curItem.Local.Length > 0)
                    {
                        nodes.Add(newNode);
                    }
                }
                else
                {
                    nodes.Add(newNode);
                }
            }
        }

        private void _tree_Expanding(object sender, TreeViewAdvEventArgs e)
        {
            if (e.Node != null)
            {
                if ((e.Node.Children.Count > 0) && (e.Node.Parent != null) && (e.Node.Parent.Parent != null))
                {
                    if (e.Node.Tag is Node)
                        (e.Node.Tag as Node).Image = hhImages.Images[1];
                }
                if (e.Node.Tag != null)
                {
                    if ((e.Node.Tag as Node).Object != null)
                    {
                        if ((e.Node.Tag as Node).Nodes.Count == 0)
                        {
                            bool createCache = false;

                            foreach (var item in helpSystems)
                            {
                                HtmlHelpSystem help = (item as HtmlHelpSystem);
                                if ((e.Node.Tag as Node).Object == help)
                                    createCache = true;
                            }

                            if (createCache)
                            {
                                _tree.LoadOnDemand = false;
                                
                                currentHelpSystem = ((e.Node.Tag as Node).Object as HtmlHelpSystem);
                                chmNode = (e.Node.Tag as Node).Nodes;
                                backgroundWorker.RunWorkerAsync();

                                pleaseWait = new PleaseWait();
                                pleaseWait.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _tree.BeginUpdate();
            BuildTOC(currentHelpSystem.TableOfContents.TOC, chmNode);
            _tree.EndUpdate();
            
            backgroundWorker.CancelAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pleaseWait.Close();
        }

        private void _tree_Collapsing(object sender, TreeViewAdvEventArgs e)
        {
            if (e.Node != null)
            {
                if ((e.Node.Children.Count > 0) && (e.Node.Parent != null) && (e.Node.Parent.Parent != null))
                {
                    if (e.Node.Tag is Node)
                        (e.Node.Tag as Node).Image = hhImages.Images[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IndexItem item = phpHelpFile.Index.SearchIndex("echo?", IndexType.KeywordLinks);
            //Console.WriteLine(item.IndentKeyWord);
        }

        private void _tree_SelectionChanged(object sender, EventArgs e)
        {
            if (_tree.SelectedNode != null)
                if (_tree.SelectedNode.Tag != null)
                    if ((_tree.SelectedNode.Tag is Node))
                        if ((_tree.SelectedNode.Tag as Node).Object is TOCItem)
                            OnTocSelected(new TocEventArgs((TOCItem)((_tree.SelectedNode.Tag as Node).Object)));
        }

        private void _tree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Red), new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
    }
}

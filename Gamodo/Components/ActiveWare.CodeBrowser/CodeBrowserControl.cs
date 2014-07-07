using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Aga.Controls.Tree;
using HtmlAgilityPack;

namespace ActiveWare.CodeBrowser
{
	public partial class CodeBrowserControl : UserControl
	{
		public TreeModel _model;
        public event HtmlNodeSelectedEventHandler HtmlSelected;
        public event EventHandler<TreeNodeAdvMouseEventArgs> NodeClick;
        

		public CodeBrowserControl()
		{
			InitializeComponent();
			_model = new TreeModel();
			_tree.Model = _model;
		}

        /// <summary>
        /// Fireing the on selected event
        /// </summary>
        /// <param name="e">event parameters</param>
        protected virtual void OnHtmlNodeSelected(HtmlEventArgs e)
        {
            if (HtmlSelected != null)
            {
                HtmlSelected(this, e);
            }
        }

        /// <summary>
        /// Fireing the on Click event
        /// </summary>
        /// <param name="e">event parameters</param>
        protected virtual void OnNodeClick(TreeNodeAdvMouseEventArgs e)
        {
            if (NodeClick != null)
            {
                NodeClick(this, e);
            }
        }

        public void Clear()
        {
            _model.Nodes.Clear();
        }

        private void _tree_NodeMouseDoubleClick(object sender, TreeNodeAdvMouseEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag != null)
                    if ((e.Node.Tag is Node))
                    {
                        if ((e.Node.Tag as Node).Object is HtmlNode)
                            OnHtmlNodeSelected(new HtmlEventArgs((HtmlNode)((e.Node.Tag as Node).Object)));
                        else
                            OnNodeClick(e);
                    }
            }
        }

	}
}

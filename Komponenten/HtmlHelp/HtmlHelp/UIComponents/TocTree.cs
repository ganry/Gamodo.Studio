using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>TocTree</c> implements a user control which displays the HtmlHelp table of contents pane to the user.
	/// </summary>
	public class TocTree : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Event if the user changes the selection in the toc tree
		/// </summary>
		public event TocSelectedEventHandler TocSelected;
		private System.Windows.Forms.TreeView tocTreeView;
		private System.Windows.Forms.ImageList hhImages;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public TocTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			ReloadImageList();
		}


		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.tocTreeView = new System.Windows.Forms.TreeView();
            this.hhImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // tocTreeView
            // 
            this.tocTreeView.HideSelection = false;
            this.tocTreeView.ImageIndex = 0;
            this.tocTreeView.ImageList = this.hhImages;
            this.tocTreeView.Location = new System.Drawing.Point(5, 5);
            this.tocTreeView.Name = "tocTreeView";
            this.tocTreeView.SelectedImageIndex = 0;
            this.tocTreeView.Size = new System.Drawing.Size(263, 329);
            this.tocTreeView.TabIndex = 0;
            this.tocTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tocTreeView_AfterCollapse);
            this.tocTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tocTreeView_AfterExpand);
            this.tocTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tocTreeView_AfterSelect);
            // 
            // hhImages
            // 
            this.hhImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.hhImages.ImageSize = new System.Drawing.Size(16, 16);
            this.hhImages.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            // 
            // TocTree
            // 
            this.Controls.Add(this.tocTreeView);
            this.Name = "TocTree";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(456, 394);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Fireing the on selected event
		/// </summary>
		/// <param name="e">event parameters</param>
		protected virtual void OnTocSelected(TocEventArgs e)
		{
			if(TocSelected != null)
			{
				TocSelected(this,e);
			}
		}

		/// <summary>
		/// Reloads the imagelist using the HtmlHelpSystem.UseHH2TreePics preference
		/// </summary>
		public void ReloadImageList()
		{
			ResourceHelper resHelper = new ResourceHelper( this.GetType().Assembly );
			resHelper.DefaultBitmapNamespace = "Resources";

			if(hhImages.Images.Count > 0)
			{
				hhImages.Images.Clear();
			}

			hhImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;

			if(HtmlHelpSystem.UseHH2TreePics)
			{
				hhImages.TransparentColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(64)), ((System.Byte)(0)));
				hhImages.Images.AddStrip(resHelper.LoadBitmap("ContentTree.bmp"));
			}
			else
			{
				hhImages.TransparentColor = Color.Fuchsia;
				hhImages.Images.AddStrip(resHelper.LoadBitmap("HH11.bmp"));
			}
		}

		/// <summary>
		/// Clears the items displayed in the toc pane
		/// </summary>
		public void ClearContents()
		{
			tocTreeView.Nodes.Clear();
		}

		/// <summary>
		/// Call this method to build the table of contents (TOC) tree.
		/// </summary>
		/// <param name="tocItems">TOC instance (tree) extracted from the chm file</param>
		public void BuildTOC(TableOfContents tocItems)
		{	
			BuildTOC(tocItems, null);
		}

		/// <summary>
		/// Call this method to build the table of contents (TOC) tree.
		/// </summary>
		/// <param name="tocItems">TOC instance (tree) extracted from the chm file</param>
		/// <param name="filter">information type/category filter</param>
		public void BuildTOC(TableOfContents tocItems, InfoTypeCategoryFilter filter)
		{	
			tocTreeView.Nodes.Clear();
			BuildTOC(tocItems.TOC, tocTreeView.Nodes, filter);
			tocTreeView.Update();
		}

		/// <summary>
		/// Snychronizes the table of content tree with the currently displayed browser url.
		/// </summary>
		/// <param name="URL">url to search</param>
		public void Synchronize(string URL)
		{
			string local = URL;
			string sFile = "";

			if( URL.StartsWith(HtmlHelpSystem.UrlPrefix) )
			{
				local = local.Substring(HtmlHelpSystem.UrlPrefix.Length);
			}

			if( local.IndexOf("::")>-1)
			{
				sFile = local.Substring(0, local.IndexOf("::"));
				local = local.Substring( local.IndexOf("::")+2 );
			}
			SelectTOCItem(tocTreeView.Nodes, sFile, local);
		}


		/// <summary>
		/// Called if the user has expanded a tree item
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tocTreeView_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TOCItem curItem = (TOCItem)(e.Node.Tag);

			if(curItem != null)
			{
				if(HtmlHelpSystem.UseHH2TreePics)
				{
					if(curItem.ImageIndex <= 15)
					{
						e.Node.ImageIndex = curItem.ImageIndex+2;
						e.Node.SelectedImageIndex = curItem.ImageIndex+2;
					}
				} 
				else 
				{
					if(curItem.ImageIndex < 8)
					{
						e.Node.ImageIndex = curItem.ImageIndex+1;
						e.Node.SelectedImageIndex = curItem.ImageIndex+1;
					}
				}
			}
		}

		/// <summary>
		/// Called if the user has collapsed a tree item
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tocTreeView_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TOCItem curItem = (TOCItem)(e.Node.Tag);

			if(curItem != null)
			{
				if(HtmlHelpSystem.UseHH2TreePics)
				{
					if(curItem.ImageIndex <= 15)
					{
						e.Node.ImageIndex = curItem.ImageIndex;
						e.Node.SelectedImageIndex = curItem.ImageIndex;
					}
				} 
				else 
				{
					if(curItem.ImageIndex < 8)
					{
						e.Node.ImageIndex = curItem.ImageIndex;
						e.Node.SelectedImageIndex = curItem.ImageIndex;
					}
				}
			}
		}

		/// <summary>
		/// Called if the user selects a tree item. 
		/// This method will fire the <c>TocSelected</c> event notifying the parent window, that the user whants 
		/// to view a new help topic.
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tocTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			OnTocSelected( new TocEventArgs((TOCItem)(e.Node.Tag)) );
		}

		/// <summary>
		/// Selects a node identified by its chm file and local
		/// </summary>
		/// <param name="col">treenode collection to search</param>
		/// <param name="chmFile">chm filename</param>
		/// <param name="local">local of the toc item</param>
		private void SelectTOCItem(TreeNodeCollection col, string chmFile, string local)
		{
			foreach(TreeNode curNode in col)
			{
				TOCItem curItem = curNode.Tag as TOCItem;

				if(curItem!=null)
				{
					if((curItem.Local == local)||(("/"+curItem.Local) == local))
					{
						if(chmFile.Length>0)
						{
							if(curItem.AssociatedFile.ChmFilePath == chmFile)
							{
								tocTreeView.SelectedNode = curNode;
								return;
							}
						} 
						else 
						{
							tocTreeView.SelectedNode = curNode;
							return;
						}
					}
				}

				SelectTOCItem(curNode.Nodes, chmFile, local);
			}
		}

		/// <summary>
		/// Recursively builds the toc tree and fills the treeview
		/// </summary>
		/// <param name="tocItems">list of toc-items</param>
		/// <param name="col">treenode collection of the current level</param>
		/// <param name="filter">information type/category filter</param>
		private void BuildTOC(ArrayList tocItems, TreeNodeCollection col, InfoTypeCategoryFilter filter)
		{
			foreach( TOCItem curItem in tocItems )
			{
				bool bAdd = true;

				if(filter!=null)
				{
					bAdd=false;

					if(curItem.InfoTypeStrings.Count <= 0)
					{
						bAdd=true;
					} 
					else 
					{
						for(int i=0;i<curItem.InfoTypeStrings.Count;i++)
						{
							bAdd |= filter.Match( curItem.InfoTypeStrings[i].ToString() );
						}
					}
				}

				if(bAdd)
				{
					TreeNode newNode = new TreeNode( curItem.Name, curItem.ImageIndex, curItem.ImageIndex );
					newNode.Tag = curItem;

					if(curItem.Children.Count > 0)
					{
						BuildTOC(curItem.Children, newNode.Nodes, filter);
					}

					// check if we have a book/folder which doesn't have any children
					// after applied filter.
					if( (curItem.Children.Count > 0) && (newNode.Nodes.Count <= 0) )
					{
						// check if the item has a local value
						// if not, this don't display this item in the tree
						if( curItem.Local.Length > 0)
						{
							col.Add(newNode);
						}
					} 
					else 
					{
						col.Add(newNode);
					}
				}
			}
		}
	}
}

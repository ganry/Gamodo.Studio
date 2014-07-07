namespace ActiveWare
{
	partial class HelpBrowser
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpBrowser));
            this.hhImages = new System.Windows.Forms.ImageList(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._tree = new Aga.Controls.Tree.TreeViewAdv();
            this._nodeStateIcon = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this.nodeIcon1 = new Aga.Controls.Tree.NodeControls.NodeIcon();
            this._nodeTextBox = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this.SuspendLayout();
            // 
            // hhImages
            // 
            this.hhImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hhImages.ImageStream")));
            this.hhImages.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hhImages.Images.SetKeyName(0, "book.png");
            this.hhImages.Images.SetKeyName(1, "book_open.png");
            this.hhImages.Images.SetKeyName(2, "page_white_text.png");
            this.hhImages.Images.SetKeyName(3, "help.png");
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // _tree
            // 
            this._tree.BackColor = System.Drawing.SystemColors.Window;
            this._tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tree.Cursor = System.Windows.Forms.Cursors.Default;
            this._tree.DefaultToolTipProvider = null;
            this._tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tree.DragDropMarkColor = System.Drawing.Color.Black;
            this._tree.FullRowSelect = true;
            this._tree.LineColor = System.Drawing.SystemColors.ControlDark;
            this._tree.LoadOnDemand = true;
            this._tree.Location = new System.Drawing.Point(0, 0);
            this._tree.Model = null;
            this._tree.Name = "_tree";
            this._tree.NodeControls.Add(this._nodeStateIcon);
            this._tree.NodeControls.Add(this.nodeIcon1);
            this._tree.NodeControls.Add(this._nodeTextBox);
            this._tree.SelectedNode = null;
            this._tree.ShowNodeToolTips = true;
            this._tree.Size = new System.Drawing.Size(283, 268);
            this._tree.TabIndex = 0;
            this._tree.Text = "treeViewAdv1";
            this._tree.SelectionChanged += new System.EventHandler(this._tree_SelectionChanged);
            this._tree.Collapsing += new System.EventHandler<Aga.Controls.Tree.TreeViewAdvEventArgs>(this._tree_Collapsing);
            this._tree.Expanding += new System.EventHandler<Aga.Controls.Tree.TreeViewAdvEventArgs>(this._tree_Expanding);
            this._tree.Paint += new System.Windows.Forms.PaintEventHandler(this._tree_Paint);
            // 
            // _nodeStateIcon
            // 
            this._nodeStateIcon.LeftMargin = 1;
            this._nodeStateIcon.ParentColumn = null;
            this._nodeStateIcon.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // nodeIcon1
            // 
            this.nodeIcon1.LeftMargin = 1;
            this.nodeIcon1.ParentColumn = null;
            this.nodeIcon1.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // _nodeTextBox
            // 
            this._nodeTextBox.DataPropertyName = "Text";
            this._nodeTextBox.IncrementalSearchEnabled = true;
            this._nodeTextBox.LeftMargin = 3;
            this._nodeTextBox.ParentColumn = null;
            // 
            // HelpBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tree);
            this.Name = "HelpBrowser";
            this.Size = new System.Drawing.Size(283, 268);
            this.ResumeLayout(false);

		}

		#endregion

        private Aga.Controls.Tree.TreeViewAdv _tree;
        private Aga.Controls.Tree.NodeControls.NodeStateIcon _nodeStateIcon;
        private Aga.Controls.Tree.NodeControls.NodeTextBox _nodeTextBox;
        private System.Windows.Forms.ImageList hhImages;
        private Aga.Controls.Tree.NodeControls.NodeIcon nodeIcon1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
	}
}

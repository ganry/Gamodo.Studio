namespace ActiveWare.CodeBrowser
{
	partial class CodeBrowserControl
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
            this._nodeStateIcon = new Aga.Controls.Tree.NodeControls.NodeStateIcon();
            this._nodeTextBox = new Aga.Controls.Tree.NodeControls.NodeTextBox();
            this._tree = new Aga.Controls.Tree.TreeViewAdv();
            this.SuspendLayout();
            // 
            // _nodeStateIcon
            // 
            this._nodeStateIcon.LeftMargin = 1;
            this._nodeStateIcon.ParentColumn = null;
            this._nodeStateIcon.ScaleMode = Aga.Controls.Tree.ImageScaleMode.Clip;
            // 
            // _nodeTextBox
            // 
            this._nodeTextBox.DataPropertyName = "Text";
            this._nodeTextBox.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._nodeTextBox.IncrementalSearchEnabled = true;
            this._nodeTextBox.LeftMargin = 3;
            this._nodeTextBox.ParentColumn = null;
            // 
            // _tree
            // 
            this._tree.AllowDrop = true;
            this._tree.BackColor = System.Drawing.SystemColors.Window;
            this._tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._tree.Cursor = System.Windows.Forms.Cursors.Default;
            this._tree.DefaultToolTipProvider = null;
            this._tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tree.DragDropMarkColor = System.Drawing.Color.Black;
            this._tree.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tree.Indent = 14;
            this._tree.LineColor = System.Drawing.SystemColors.ControlDark;
            this._tree.Location = new System.Drawing.Point(0, 0);
            this._tree.Model = null;
            this._tree.Name = "_tree";
            this._tree.NodeControls.Add(this._nodeStateIcon);
            this._tree.NodeControls.Add(this._nodeTextBox);
            this._tree.SelectedNode = null;
            this._tree.ShowNodeToolTips = true;
            this._tree.Size = new System.Drawing.Size(321, 324);
            this._tree.TabIndex = 1;
            this._tree.Text = "treeViewAdv1";
            this._tree.NodeMouseDoubleClick += new System.EventHandler<Aga.Controls.Tree.TreeNodeAdvMouseEventArgs>(this._tree_NodeMouseDoubleClick);
            // 
            // CodeBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tree);
            this.Name = "CodeBrowserControl";
            this.Size = new System.Drawing.Size(321, 324);
            this.ResumeLayout(false);

		}

		#endregion

        private Aga.Controls.Tree.NodeControls.NodeStateIcon _nodeStateIcon;
        public Aga.Controls.Tree.NodeControls.NodeTextBox _nodeTextBox;
        public Aga.Controls.Tree.TreeViewAdv _tree;
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>TopcisFound</c> implements a form which displays a list of found topics.
	/// </summary>
	public class TopicsFound : System.Windows.Forms.Form
	{
		private ArrayList _items = null;
		private string _url = "";
		private string _title = "";

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvTopics;
		private System.Windows.Forms.Button btnDisplay;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ColumnHeader chTitle;
		private System.Windows.Forms.ColumnHeader chLocation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public TopicsFound()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.lvTopics = new System.Windows.Forms.ListView();
			this.btnDisplay = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chTitle = new System.Windows.Forms.ColumnHeader();
			this.chLocation = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Click a topic, then click Display";
			// 
			// lvTopics
			// 
			this.lvTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvTopics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.chTitle,
																					   this.chLocation});
			this.lvTopics.FullRowSelect = true;
			this.lvTopics.Location = new System.Drawing.Point(8, 32);
			this.lvTopics.MultiSelect = false;
			this.lvTopics.Name = "lvTopics";
			this.lvTopics.Size = new System.Drawing.Size(472, 160);
			this.lvTopics.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvTopics.TabIndex = 1;
			this.lvTopics.View = System.Windows.Forms.View.Details;
			this.lvTopics.DoubleClick += new System.EventHandler(this.lvTopics_DoubleClick);
			// 
			// btnDisplay
			// 
			this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDisplay.Location = new System.Drawing.Point(304, 200);
			this.btnDisplay.Name = "btnDisplay";
			this.btnDisplay.TabIndex = 2;
			this.btnDisplay.Text = "&Display";
			this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(400, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "&Cancel";
			// 
			// chTitle
			// 
			this.chTitle.Text = "Title";
			this.chTitle.Width = 250;
			// 
			// chLocation
			// 
			this.chLocation.Text = "Location";
			this.chLocation.Width = 210;
			// 
			// TopicsFound
			// 
			this.AcceptButton = this.btnDisplay;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(490, 231);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnDisplay);
			this.Controls.Add(this.lvTopics);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TopicsFound";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Topics found";
			this.Load += new System.EventHandler(this.TopicsFound_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called if the form is loaded
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void TopicsFound_Load(object sender, System.EventArgs e)
		{
			if(_items != null)
			{
				foreach(IndexTopic curEntry in _items)
				{
					ListViewItem lvItem = new ListViewItem( curEntry.Title );
					lvItem.Tag = curEntry;
					lvItem.SubItems.Add( curEntry.CompileFile );
					
					lvTopics.Items.Add( lvItem );
				}
			} 
			else 
			{
				DialogResult = DialogResult.Cancel;
				this.Close();
			}
		}

		/// <summary>
		/// Called if the user double clicks on a topic item in the listview
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void lvTopics_DoubleClick(object sender, System.EventArgs e)
		{
			if( lvTopics.SelectedItems.Count > 0)
			{
				_url = ((IndexTopic)(lvTopics.SelectedItems[0].Tag)).URL;
				_title = ((IndexTopic)(lvTopics.SelectedItems[0].Tag)).Title;
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		/// <summary>
		/// Called if the user clicks the <c>Display</c> button
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void btnDisplay_Click(object sender, System.EventArgs e)
		{
			if( lvTopics.SelectedItems.Count > 0)
			{
				_url = ((IndexTopic)(lvTopics.SelectedItems[0].Tag)).URL;
				_title = ((IndexTopic)(lvTopics.SelectedItems[0].Tag)).Title;
				DialogResult = DialogResult.OK;
				this.Close();
			}
			else 
			{
				MessageBox.Show("Select a topic first !","Index",MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Gets/Sets the items for displaying the topics
		/// </summary>
		public ArrayList Items
		{
			get { return _items; }
			set { _items = value; }
		}

		/// <summary>
		/// Gets the selected URL
		/// </summary>
		public string SelectedUrl
		{
			get { return _url; }
		}

		/// <summary>
		/// Gets the selected URL
		/// </summary>
		public string SelectedTitle
		{
			get { return _title; }
		}
	}
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using HtmlHelp;
using HtmlHelp.UIComponents;

namespace HtmlHelpViewer
{
	/// <summary>
	/// Summary description for CustomizeContent.
	/// </summary>
	public class CustomizeContent : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.CheckBox chkAll;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView lvTypes;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chType;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.ComponentModel.IContainer components = null;

		private InfoTypeCategoryFilter _filter = null;
		private ListViewItem _liExclusive=null;
		private HtmlHelp.UIComponents.HelpProviderEx helpProviderEx1;
		private bool _exclusiveUpdate = false;

		public CustomizeContent()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			helpProviderEx1.Viewer = Viewer.Current; // set the active viewer
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CustomizeContent));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.chkAll = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lvTypes = new System.Windows.Forms.ListView();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.chType = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.helpProviderEx1 = new HtmlHelp.UIComponents.HelpProviderEx();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(120, 226);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(0, 226);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(446, 2);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// chkAll
			// 
			this.helpProviderEx1.SetHelpString(this.chkAll, "Check this if you want to view ALL help contents");
			this.chkAll.Location = new System.Drawing.Point(128, 3);
			this.chkAll.Name = "chkAll";
			this.chkAll.Size = new System.Drawing.Size(231, 24);
			this.chkAll.TabIndex = 2;
			this.chkAll.Text = "Display &all help contents";
			this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblDescription);
			this.groupBox1.Controls.Add(this.lvTypes);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(127, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(306, 193);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information types and categories";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(8, 158);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(288, 32);
			this.lblDescription.TabIndex = 2;
			// 
			// lvTypes
			// 
			this.lvTypes.CheckBoxes = true;
			this.lvTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.chName,
																					  this.chType});
			this.lvTypes.FullRowSelect = true;
			this.lvTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.helpProviderEx1.SetHelpString(this.lvTypes, "Select one or more categories/information types which should be included in your " +
				"content filter. NOTE: Exclusive information types can not be combined with other" +
				" information types or categories !");
			this.lvTypes.HideSelection = false;
			this.lvTypes.LabelWrap = false;
			this.lvTypes.Location = new System.Drawing.Point(6, 35);
			this.lvTypes.MultiSelect = false;
			this.lvTypes.Name = "lvTypes";
			this.lvTypes.Size = new System.Drawing.Size(293, 119);
			this.lvTypes.TabIndex = 1;
			this.lvTypes.View = System.Windows.Forms.View.Details;
			this.lvTypes.SelectedIndexChanged += new System.EventHandler(this.lvTypes_SelectedIndexChanged);
			this.lvTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvTypes_ItemCheck);
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 188;
			// 
			// chType
			// 
			this.chType.Text = "Type";
			this.chType.Width = 100;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(291, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Check all info types and categories you want to view";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(357, 234);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(272, 234);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// helpProviderEx1
			// 
			this.helpProviderEx1.Viewer = null;
			// 
			// CustomizeContent
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(440, 267);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkAll);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomizeContent";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Customize content";
			this.Load += new System.EventHandler(this.CustomizeContent_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Gets/Sets the filter
		/// </summary>
		public InfoTypeCategoryFilter Filter
		{
			get { return _filter; }
			set { _filter = value; }
		}

		/// <summary>
		/// Checks an exclusive info type item (unchecks all others)
		/// </summary>
		/// <param name="li">listview item which is of infotype mode exclusive</param>
		private void CheckExclusive(ListViewItem li)
		{
			foreach(ListViewItem curItem in lvTypes.Items)
			{
				curItem.Checked = ( curItem == li);
			}

			_liExclusive = li;
		}

		/// <summary>
		/// Called if the form loads
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void CustomizeContent_Load(object sender, System.EventArgs e)
		{
			if(_filter == null)
			{
				DialogResult = DialogResult.Cancel;
				this.Close();
			}

			chkAll.Checked = !_filter.FilterEnabled;
			groupBox1.Enabled = _filter.FilterEnabled;

			ArrayList arrInfotypes = HtmlHelpSystem.Current.InformationTypes;
			ArrayList arrCategories = HtmlHelpSystem.Current.Categories;
			int i=0;

			for(i=0; i<arrInfotypes.Count;i++)
			{
				InformationType curType = arrInfotypes[i] as InformationType;

				// hidden types are only for API called
				if(curType.Mode != InformationTypeMode.Hidden)
				{
					if( !curType.IsInCategory )
					{
						ListViewItem liIT = new ListViewItem(curType.Name);
						liIT.SubItems.Add(curType.Mode.ToString());
						liIT.Tag = curType;

						bool bCheck = _filter.ContainsInformationType(curType);

						if((bCheck)&&(curType.Mode == InformationTypeMode.Exclusive))
						{
							_liExclusive = liIT;
						}

						liIT.Checked = bCheck;
						
						lvTypes.Items.Add(liIT);
					}
				}
			}

			for(i=0;i<arrCategories.Count;i++)
			{
				Category curCat = arrCategories[i] as Category;

				ListViewItem liC = new ListViewItem(curCat.Name);
				liC.SubItems.Add("Category");
				liC.Tag = curCat;

				bool bCheck = _filter.ContainsCategory(curCat);

				liC.Checked = bCheck;
						
				lvTypes.Items.Add(liC);
			}
	
			if(_liExclusive != null)
				CheckExclusive(_liExclusive);
		}

		/// <summary>
		/// Called if the user clicks the "Display all" checkbox
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void chkAll_CheckedChanged(object sender, System.EventArgs e)
		{
			groupBox1.Enabled = !chkAll.Checked;
		}

		/// <summary>
		/// Called if the user changes the selection of the list view
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void lvTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( lvTypes.SelectedItems.Count > 0)
			{
				ListViewItem selItem = lvTypes.SelectedItems[0];

				InformationType iT = selItem.Tag as InformationType;
				Category cat = selItem.Tag as Category;

				if(iT!=null)
				{
					lblDescription.Text = iT.Description;
				}

				if(cat != null)
				{
					lblDescription.Text = cat.Description;
				}
			} 
			else 
			{
				lblDescription.Text = "";
			}
		}

		/// <summary>
		/// Called if the user changes the check state of an item
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void lvTypes_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(!_exclusiveUpdate)
			{
				ListViewItem lvCheck = lvTypes.Items[ e.Index ];

				InformationType iT = lvCheck.Tag as InformationType;

				if(iT!=null)
				{
					if((iT.Mode == InformationTypeMode.Exclusive)&&(e.NewValue == CheckState.Checked))
					{
						_exclusiveUpdate = true;
						CheckExclusive(lvCheck);
						_exclusiveUpdate=false;
						return;
					} 
					else if((iT.Mode == InformationTypeMode.Exclusive)&&(e.NewValue == CheckState.Unchecked))
					{
						_liExclusive = null;
						return;
					}
				}

				if(_liExclusive != null)
				{
					_exclusiveUpdate = true;
					CheckExclusive(null);
					_exclusiveUpdate=false;
				}
			}
		}

		/// <summary>
		/// Called if the user clicks the OK button
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_filter.ResetFilter();

			foreach(ListViewItem curItem in lvTypes.Items)
			{
				InformationType iT = curItem.Tag as InformationType;
				Category cat = curItem.Tag as Category;

				if(iT!=null)
					if(curItem.Checked)
						_filter.AddInformationType(iT);

				if(cat != null)
					if(curItem.Checked)
						_filter.AddCategory(cat);
			}

			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}

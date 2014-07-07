using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HtmlHelpViewer
{
	/// <summary>
	/// Summary description for Preferences.
	/// </summary>
	public class Preferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tbHHS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtURLPrefix;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbImageList;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		string _prefURLPrefix = "mk:@MSITStore:";
		private HtmlHelp.UIComponents.HelpProviderEx helpProviderEx1;
		bool _prefUseHH2TreePics = false;

		public Preferences()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Preferences));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbHHS = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.cbImageList = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtURLPrefix = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.helpProviderEx1 = new HtmlHelp.UIComponents.HelpProviderEx();
			this.tabControl1.SuspendLayout();
			this.tbHHS.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(344, 200);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "&Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(248, 200);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 184);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(432, 2);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tbHHS);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(416, 168);
			this.tabControl1.TabIndex = 9;
			// 
			// tbHHS
			// 
			this.tbHHS.Controls.Add(this.label3);
			this.tbHHS.Controls.Add(this.cbImageList);
			this.tbHHS.Controls.Add(this.label2);
			this.tbHHS.Controls.Add(this.txtURLPrefix);
			this.tbHHS.Controls.Add(this.label1);
			this.tbHHS.Location = new System.Drawing.Point(4, 22);
			this.tbHHS.Name = "tbHHS";
			this.tbHHS.Size = new System.Drawing.Size(408, 142);
			this.tbHHS.TabIndex = 0;
			this.tbHHS.Text = "HtmlHelpSystem settings";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(384, 32);
			this.label3.TabIndex = 4;
			this.label3.Text = "NOTE: Changing the standard imagelist requires to close all current CHM files !";
			// 
			// cbImageList
			// 
			this.cbImageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.helpProviderEx1.SetHelpString(this.cbImageList, "Sets the imagelist used for the Table of Contents tree view.");
			this.cbImageList.Items.AddRange(new object[] {
															 "HtmlHelp 1.1 image list",
															 "HtmlHelp 2.0 image list"});
			this.cbImageList.Location = new System.Drawing.Point(184, 61);
			this.cbImageList.Name = "cbImageList";
			this.cbImageList.Size = new System.Drawing.Size(216, 21);
			this.cbImageList.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(176, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Standard imagelist for TOC-Tree:";
			// 
			// txtURLPrefix
			// 
			this.helpProviderEx1.SetHelpString(this.txtURLPrefix, "The prefix string for identifying ITS-Urls ( should be \"mt-its:\" or \"mk:@MSITStor" +
				"e:\" )");
			this.txtURLPrefix.Location = new System.Drawing.Point(184, 21);
			this.txtURLPrefix.Name = "txtURLPrefix";
			this.txtURLPrefix.Size = new System.Drawing.Size(216, 20);
			this.txtURLPrefix.TabIndex = 1;
			this.txtURLPrefix.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Url prefix for identifying ITS-Urls:";
			// 
			// helpProviderEx1
			// 
			this.helpProviderEx1.Viewer = null;
			// 
			// Preferences
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 231);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Preferences";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Preferences ...";
			this.Load += new System.EventHandler(this.Preferences_Load);
			this.tabControl1.ResumeLayout(false);
			this.tbHHS.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Gets/Sets the ITS url prefix
		/// </summary>
		public string UrlPrefixPreference
		{
			get { return _prefURLPrefix; }
			set { _prefURLPrefix = value; }
		}

		/// <summary>
		/// Gets/Sets the preferenced tree image list
		/// </summary>
		public bool UseHH2TreePicsPreference
		{
			get { return _prefUseHH2TreePics; }
			set { _prefUseHH2TreePics = value; }
		}

		/// <summary>
		/// Called if the form is loaded
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void Preferences_Load(object sender, System.EventArgs e)
		{
			txtURLPrefix.Text = _prefURLPrefix;
			cbImageList.SelectedIndex = (_prefUseHH2TreePics) ? 1 : 0;
		}

		/// <summary>
		/// Called if the user clicks OK
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			_prefURLPrefix = txtURLPrefix.Text;
			_prefUseHH2TreePics = (cbImageList.SelectedIndex == 1);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}

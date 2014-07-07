using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using HtmlHelp;
using HtmlHelp.ChmDecoding;

namespace HtmlHelpViewer
{
	/// <summary>
	/// Summary description for FileInfo.
	/// </summary>
	public class FileInfo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbFiles;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Property grid instance
		/// </summary>
		private PropertyGrid _propGrid;
		private HtmlHelpSystem _system;
		private CHMFile[] _files;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public FileInfo() : this(null)
		{

		}

		/// <summary>
		/// Constructor of the class
		/// </summary>
		/// <param name="system">set the instance of the help system which holds a file list</param>
		public FileInfo(HtmlHelpSystem system)
		{
			_system = system;
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this._propGrid = new PropertyGrid();
			this._propGrid.SuspendLayout();

			//
			// _propGrid
			//
			_propGrid.CommandsVisibleIfAvailable = true;
			_propGrid.LargeButtons = false;
			_propGrid.LineColor = SystemColors.Control;
			_propGrid.Location = new System.Drawing.Point(7, 50);
			_propGrid.Size = new System.Drawing.Size(454, 240);
			_propGrid.TabIndex = 2;
			_propGrid.PropertySort = PropertySort.Alphabetical;
			_propGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));

			this.Controls.Add(this._propGrid);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileInfo));
			this.label1 = new System.Windows.Forms.Label();
			this.cbFiles = new System.Windows.Forms.ComboBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(319, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select a file from the list:";
			// 
			// cbFiles
			// 
			this.cbFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFiles.Location = new System.Drawing.Point(7, 25);
			this.cbFiles.Name = "cbFiles";
			this.cbFiles.Size = new System.Drawing.Size(454, 21);
			this.cbFiles.TabIndex = 1;
			this.cbFiles.SelectedIndexChanged += new System.EventHandler(this.cbFiles_SelectedIndexChanged);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(4, 291);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(458, 2);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(196, 301);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "&OK";
			// 
			// FileInfo
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 333);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.cbFiles);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Loaded file info";
			this.Load += new System.EventHandler(this.FileInfo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called if the form loads
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void FileInfo_Load(object sender, System.EventArgs e)
		{
			if(_system!=null)
			{
				if( _files == null)
					_files = _system.FileList;

				cbFiles.Items.Clear();

				for(int i=0; i<_files.Length;i++)
				{
					cbFiles.Items.Add( _files[i].FileInfo.FileInfo.Name );
				}

				if(_files.Length > 0)
				{
					cbFiles.SelectedIndex = 0;
					SetPropertyObject(0);
				}
			}
		}

		/// <summary>
		/// Called if the user changes the file selection
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void cbFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetPropertyObject( cbFiles.SelectedIndex );
		}

		/// <summary>
		/// Sets the object for the property grid
		/// </summary>
		/// <param name="nIdx">index of the file to display</param>
		private void SetPropertyObject(int nIdx)
		{
			if(_files!=null)
			{
				_propGrid.SelectedObject = _files[nIdx].FileInfo;
			}
		}
	}
}

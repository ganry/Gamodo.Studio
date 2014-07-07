using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

using HtmlHelp;

namespace HtmlHelpViewer
{
	/// <summary>
	/// This class implements the help-about dialog
	/// </summary>
	public class AboutDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblLibVersion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblviewerVersion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button btnOk;
		
		HtmlHelpSystem _hlpSystem = null;
		private System.Windows.Forms.Button btnLoadedFiles;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public AboutDlg()
		{
			InitializeComponent();
			btnLoadedFiles.Enabled = false;
		}

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public AboutDlg(HtmlHelpSystem system)
		{
			_hlpSystem = system;
			InitializeComponent();

			if(_hlpSystem != null)
			{
				if(_hlpSystem.FileList.Length > 0)
					btnLoadedFiles.Enabled = true;
				else
					btnLoadedFiles.Enabled = false;
			} 
			else 
			{
				btnLoadedFiles.Enabled = false;
			}
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutDlg));
			this.label1 = new System.Windows.Forms.Label();
			this.lblLibVersion = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblviewerVersion = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnLoadedFiles = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "HtmlHelp library version:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblLibVersion
			// 
			this.lblLibVersion.Location = new System.Drawing.Point(144, 16);
			this.lblLibVersion.Name = "lblLibVersion";
			this.lblLibVersion.Size = new System.Drawing.Size(256, 16);
			this.lblLibVersion.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Viewer version:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblviewerVersion
			// 
			this.lblviewerVersion.Location = new System.Drawing.Point(144, 40);
			this.lblviewerVersion.Name = "lblviewerVersion";
			this.lblviewerVersion.Size = new System.Drawing.Size(256, 16);
			this.lblviewerVersion.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(376, 32);
			this.label3.TabIndex = 4;
			this.label3.Text = "You can freely reuse the library or parts of its code in non commercial applicati" +
				"ons. ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 64);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(392, 2);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(8, 168);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(392, 2);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 6;
			this.pictureBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(376, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Copyright (c) 2004 by Klaus Weisser";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(77, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 8;
			this.label5.Text = "Special thanks to:";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(173, 136);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(160, 23);
			this.linkLabel1.TabIndex = 9;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Pabs\' CHM specification page";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(272, 184);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(128, 23);
			this.btnOk.TabIndex = 10;
			this.btnOk.Text = "&OK";
			// 
			// btnLoadedFiles
			// 
			this.btnLoadedFiles.Location = new System.Drawing.Point(8, 184);
			this.btnLoadedFiles.Name = "btnLoadedFiles";
			this.btnLoadedFiles.Size = new System.Drawing.Size(152, 23);
			this.btnLoadedFiles.TabIndex = 11;
			this.btnLoadedFiles.Text = "File info of loaded files...";
			this.btnLoadedFiles.Click += new System.EventHandler(this.btnLoadedFiles_Click);
			// 
			// AboutDlg
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(410, 213);
			this.Controls.Add(this.btnLoadedFiles);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblviewerVersion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblLibVersion);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About ...";
			this.Load += new System.EventHandler(this.AboutDlg_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called if the form is loaded
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void AboutDlg_Load(object sender, System.EventArgs e)
		{
			AssemblyName libName = typeof(HtmlHelpSystem).Assembly.GetName();

			lblLibVersion.Text = libName.Version.Major + "." + libName.Version.Minor + "." + libName.Version.Build + " (Rev: " + libName.Version.Revision + ") - Technology Preview";

			libName = this.GetType().Assembly.GetName();

			lblviewerVersion.Text = libName.Version.Major + "." + libName.Version.Minor + "." + libName.Version.Build + " (Rev: " + libName.Version.Revision + ") - Technology Preview";
			
		}

		/// <summary>
		/// Called if the user clicks the link label
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			BrowseUrlWithShellWebBrowser( "http://bonedaddy.net/pabs3/chmspec/0.1.2" );
		}

		/// <summary>
		/// Browse an url with the default shell browser
		/// </summary>
		/// <param name="url">url to browse</param>
		/// <returns>true if succeeded</returns>
		private bool BrowseUrlWithShellWebBrowser(string url)
		{
			if (url == null || url.Length == 0)
			{
				return false;
			}
			Process process = new Process();
			process.StartInfo.FileName = url;
			process.StartInfo.Verb = "open";
			process.StartInfo.UseShellExecute = true;
			bool bRet = false;
			try
			{
				bRet = process.Start();
			}
			catch (Exception e)
			{
				Debug.WriteLine("AboutDlg.BrowseUrlWithShellWebBrowser() - Failed with error: " + e.Message);
			}
			return bRet;
		}

		/// <summary>
		/// Called if the user clicks on the loaded files button
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void btnLoadedFiles_Click(object sender, System.EventArgs e)
		{
			FileInfo fiDlg = new FileInfo(_hlpSystem);
			fiDlg.ShowDialog();
		}
	}
}

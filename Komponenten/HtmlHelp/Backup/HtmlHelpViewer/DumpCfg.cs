using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using HtmlHelp;
using HtmlHelp.ChmDecoding;

namespace HtmlHelpViewer
{
	/// <summary>
	/// Summary description for DumpCfg.
	/// </summary>
	public class DumpCfg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkDEnableDump;
		private System.Windows.Forms.GroupBox grpDumping;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFolderName;
		private System.Windows.Forms.ComboBox cbSpecialFolder;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbCompression;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkTextTOC;
		private System.Windows.Forms.CheckBox chkBinTOC;
		private System.Windows.Forms.CheckBox chkTextIdx;
		private System.Windows.Forms.CheckBox chkBinIdx;
		private System.Windows.Forms.CheckBox chkStrings;
		private System.Windows.Forms.CheckBox chkUrlstr;
		private System.Windows.Forms.CheckBox chkUrltbl;
		private System.Windows.Forms.CheckBox chkTopics;
		private System.Windows.Forms.CheckBox chkFulltext;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.RadioButton rbSF;
		private System.Windows.Forms.RadioButton rbF;

		DumpingInfo _dmpInfo = null;

		string _prefDumpOutput="";

		DumpCompression _prefDumpCompression = DumpCompression.Medium;
		private HtmlHelp.UIComponents.HelpProviderEx helpProviderEx1;

		DumpingFlags _prefDumpFlags = DumpingFlags.DumpBinaryTOC | DumpingFlags.DumpTextTOC | 
			DumpingFlags.DumpTextIndex | DumpingFlags.DumpBinaryIndex | 
			DumpingFlags.DumpUrlStr | DumpingFlags.DumpStrings;

		public DumpCfg()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DumpCfg));
			this.label1 = new System.Windows.Forms.Label();
			this.chkDEnableDump = new System.Windows.Forms.CheckBox();
			this.grpDumping = new System.Windows.Forms.GroupBox();
			this.chkFulltext = new System.Windows.Forms.CheckBox();
			this.chkTopics = new System.Windows.Forms.CheckBox();
			this.chkUrltbl = new System.Windows.Forms.CheckBox();
			this.chkUrlstr = new System.Windows.Forms.CheckBox();
			this.chkStrings = new System.Windows.Forms.CheckBox();
			this.chkBinIdx = new System.Windows.Forms.CheckBox();
			this.chkTextIdx = new System.Windows.Forms.CheckBox();
			this.chkBinTOC = new System.Windows.Forms.CheckBox();
			this.chkTextTOC = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbCompression = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbSpecialFolder = new System.Windows.Forms.ComboBox();
			this.txtFolderName = new System.Windows.Forms.TextBox();
			this.rbF = new System.Windows.Forms.RadioButton();
			this.rbSF = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.helpProviderEx1 = new HtmlHelp.UIComponents.HelpProviderEx();
			this.grpDumping.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Use this dialog to configure the HtmlHelpSystem data dumping";
			// 
			// chkDEnableDump
			// 
			this.helpProviderEx1.SetHelpString(this.chkDEnableDump, "Check this flag to enable data dumping for the Viewer.");
			this.chkDEnableDump.Location = new System.Drawing.Point(8, 32);
			this.chkDEnableDump.Name = "chkDEnableDump";
			this.chkDEnableDump.Size = new System.Drawing.Size(176, 24);
			this.chkDEnableDump.TabIndex = 1;
			this.chkDEnableDump.Text = "&Enable data dumping";
			this.chkDEnableDump.CheckedChanged += new System.EventHandler(this.chkDEnableDump_CheckedChanged);
			// 
			// grpDumping
			// 
			this.grpDumping.Controls.Add(this.chkFulltext);
			this.grpDumping.Controls.Add(this.chkTopics);
			this.grpDumping.Controls.Add(this.chkUrltbl);
			this.grpDumping.Controls.Add(this.chkUrlstr);
			this.grpDumping.Controls.Add(this.chkStrings);
			this.grpDumping.Controls.Add(this.chkBinIdx);
			this.grpDumping.Controls.Add(this.chkTextIdx);
			this.grpDumping.Controls.Add(this.chkBinTOC);
			this.grpDumping.Controls.Add(this.chkTextTOC);
			this.grpDumping.Controls.Add(this.label4);
			this.grpDumping.Controls.Add(this.cbCompression);
			this.grpDumping.Controls.Add(this.label3);
			this.grpDumping.Controls.Add(this.cbSpecialFolder);
			this.grpDumping.Controls.Add(this.txtFolderName);
			this.grpDumping.Controls.Add(this.rbF);
			this.grpDumping.Controls.Add(this.rbSF);
			this.grpDumping.Controls.Add(this.label2);
			this.grpDumping.Location = new System.Drawing.Point(8, 64);
			this.grpDumping.Name = "grpDumping";
			this.grpDumping.Size = new System.Drawing.Size(344, 288);
			this.grpDumping.TabIndex = 2;
			this.grpDumping.TabStop = false;
			this.grpDumping.Text = "Dump settings";
			// 
			// chkFulltext
			// 
			this.helpProviderEx1.SetHelpString(this.chkFulltext, "Check this if the system should dump the CHM\'s internal full-text index file.");
			this.chkFulltext.Location = new System.Drawing.Point(176, 232);
			this.chkFulltext.Name = "chkFulltext";
			this.chkFulltext.Size = new System.Drawing.Size(136, 24);
			this.chkFulltext.TabIndex = 16;
			this.chkFulltext.Text = "Dump Full-text index";
			// 
			// chkTopics
			// 
			this.helpProviderEx1.SetHelpString(this.chkTopics, "Check this if the system should dump the CHM\'s internal #TOPICS file.");
			this.chkTopics.Location = new System.Drawing.Point(176, 208);
			this.chkTopics.Name = "chkTopics";
			this.chkTopics.Size = new System.Drawing.Size(136, 24);
			this.chkTopics.TabIndex = 15;
			this.chkTopics.Text = "Dump #TOPICS file";
			// 
			// chkUrltbl
			// 
			this.helpProviderEx1.SetHelpString(this.chkUrltbl, "Check this if the system should dump the CHM\'s internal #URLTBL file.");
			this.chkUrltbl.Location = new System.Drawing.Point(176, 184);
			this.chkUrltbl.Name = "chkUrltbl";
			this.chkUrltbl.Size = new System.Drawing.Size(136, 24);
			this.chkUrltbl.TabIndex = 14;
			this.chkUrltbl.Text = "Dump #URLTBL file";
			// 
			// chkUrlstr
			// 
			this.helpProviderEx1.SetHelpString(this.chkUrlstr, "Check this if the system should dump the CHM\'s internal #URLSTR file.");
			this.chkUrlstr.Location = new System.Drawing.Point(176, 160);
			this.chkUrlstr.Name = "chkUrlstr";
			this.chkUrlstr.Size = new System.Drawing.Size(136, 24);
			this.chkUrlstr.TabIndex = 13;
			this.chkUrlstr.Text = "Dump #URLSTR file";
			// 
			// chkStrings
			// 
			this.helpProviderEx1.SetHelpString(this.chkStrings, "Check this if the system should dump the CHM\'s internal #STRINGS file.");
			this.chkStrings.Location = new System.Drawing.Point(40, 256);
			this.chkStrings.Name = "chkStrings";
			this.chkStrings.Size = new System.Drawing.Size(136, 24);
			this.chkStrings.TabIndex = 12;
			this.chkStrings.Text = "Dump #STRINGS file";
			// 
			// chkBinIdx
			// 
			this.helpProviderEx1.SetHelpString(this.chkBinIdx, "Check this if you want to dump binary index data");
			this.chkBinIdx.Location = new System.Drawing.Point(40, 232);
			this.chkBinIdx.Name = "chkBinIdx";
			this.chkBinIdx.Size = new System.Drawing.Size(120, 24);
			this.chkBinIdx.TabIndex = 11;
			this.chkBinIdx.Text = "Dump binary index";
			// 
			// chkTextIdx
			// 
			this.helpProviderEx1.SetHelpString(this.chkTextIdx, "Check this if you want to dump text-based index data");
			this.chkTextIdx.Location = new System.Drawing.Point(40, 208);
			this.chkTextIdx.Name = "chkTextIdx";
			this.chkTextIdx.Size = new System.Drawing.Size(120, 24);
			this.chkTextIdx.TabIndex = 10;
			this.chkTextIdx.Text = "Dump text index";
			// 
			// chkBinTOC
			// 
			this.helpProviderEx1.SetHelpString(this.chkBinTOC, "Check this if you want to dump a binary table of contents ");
			this.chkBinTOC.Location = new System.Drawing.Point(40, 184);
			this.chkBinTOC.Name = "chkBinTOC";
			this.chkBinTOC.Size = new System.Drawing.Size(120, 24);
			this.chkBinTOC.TabIndex = 9;
			this.chkBinTOC.Text = "Dump binary TOC";
			// 
			// chkTextTOC
			// 
			this.helpProviderEx1.SetHelpString(this.chkTextTOC, "Check this if you want to dump text-based table of contents");
			this.chkTextTOC.Location = new System.Drawing.Point(40, 160);
			this.chkTextTOC.Name = "chkTextTOC";
			this.chkTextTOC.Size = new System.Drawing.Size(120, 24);
			this.chkTextTOC.TabIndex = 8;
			this.chkTextTOC.Text = "Dump text TOC";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Dumping flags:";
			// 
			// cbCompression
			// 
			this.cbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.helpProviderEx1.SetHelpString(this.cbCompression, "Select the compression level you would prefer (NOTE: No compression needs maximum" +
				" space and works fastest, Maximum copmression needs minimum space and works slow" +
				"est)");
			this.cbCompression.Items.AddRange(new object[] {
															   "None",
															   "Minimum",
															   "Medium",
															   "Maximum"});
			this.cbCompression.Location = new System.Drawing.Point(144, 101);
			this.cbCompression.Name = "cbCompression";
			this.cbCompression.Size = new System.Drawing.Size(192, 21);
			this.cbCompression.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Dump compression level:";
			// 
			// cbSpecialFolder
			// 
			this.cbSpecialFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.helpProviderEx1.SetHelpString(this.cbSpecialFolder, "Select one of the special folders from the list.");
			this.cbSpecialFolder.Location = new System.Drawing.Point(8, 72);
			this.cbSpecialFolder.Name = "cbSpecialFolder";
			this.cbSpecialFolder.Size = new System.Drawing.Size(328, 21);
			this.cbSpecialFolder.TabIndex = 4;
			// 
			// txtFolderName
			// 
			this.helpProviderEx1.SetHelpString(this.txtFolderName, "Type in the full path of the output folder where dumping files should be stored.");
			this.txtFolderName.Location = new System.Drawing.Point(8, 72);
			this.txtFolderName.Name = "txtFolderName";
			this.txtFolderName.Size = new System.Drawing.Size(328, 20);
			this.txtFolderName.TabIndex = 3;
			this.txtFolderName.Text = "";
			// 
			// rbF
			// 
			this.helpProviderEx1.SetHelpString(this.rbF, "Set this flag, if you want to specify a custom output path.");
			this.rbF.Location = new System.Drawing.Point(112, 48);
			this.rbF.Name = "rbF";
			this.rbF.TabIndex = 2;
			this.rbF.Text = "Specify &folder";
			this.rbF.CheckedChanged += new System.EventHandler(this.rbF_CheckedChanged);
			// 
			// rbSF
			// 
			this.rbSF.Checked = true;
			this.helpProviderEx1.SetHelpString(this.rbSF, "Select this if you want to set the dump-data output to a special folder on your c" +
				"omputer.");
			this.rbSF.Location = new System.Drawing.Point(8, 48);
			this.rbSF.Name = "rbSF";
			this.rbSF.TabIndex = 1;
			this.rbSF.TabStop = true;
			this.rbSF.Text = "&Special folder";
			this.rbSF.CheckedChanged += new System.EventHandler(this.rbSF_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.TabIndex = 0;
			this.label2.Text = "Output directory:";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 360);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(360, 2);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(176, 376);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "&OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(272, 376);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			// 
			// helpProviderEx1
			// 
			this.helpProviderEx1.Viewer = null;
			// 
			// DumpCfg
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 407);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.grpDumping);
			this.Controls.Add(this.chkDEnableDump);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DumpCfg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dumping configuration";
			this.Load += new System.EventHandler(this.DumpCfg_Load);
			this.grpDumping.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Gets/Sets the associated dumping info 
		/// </summary>
		public DumpingInfo DumpingInfo
		{
			get { return _dmpInfo; }
			set { _dmpInfo = value; }
		}

		/// <summary>
		/// Gets/Sets the output path set in the application preferences
		/// </summary>
		public string PreferencesOutput
		{
			get { return _prefDumpOutput; }
			set { _prefDumpOutput = value; }
		}

		/// <summary>
		/// Gets/Sets the compression set in the application preferences
		/// </summary>
		public DumpCompression PrefencesCompression
		{
			get { return _prefDumpCompression; }
			set { _prefDumpCompression = value; }
		}

		/// <summary>
		/// Gets/Sets the dumping flags set in the application preferences
		/// </summary>
		public DumpingFlags PreferencesFlags
		{
			get { return _prefDumpFlags; }
			set { _prefDumpFlags = value; }
		}

		/// <summary>
		/// Fills the special folder combobox
		/// </summary>
		/// <param name="currentFolder">current folder to select</param>
		/// <returns>Returns true if the current folder is a special folder</returns>
		private bool FillSpecialFolders(string currentFolder)
		{
			bool bRet = false;
			int nSelIdx = 0;

			// use temporary folder for data dumping
			string sTemp = System.Environment.GetEnvironmentVariable("TEMP");
			if(sTemp.Length <= 0)
				sTemp = System.Environment.GetEnvironmentVariable("TMP");

			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=0;
			}
			cbSpecialFolder.Items.Add("Temporary files");
			
			sTemp = Environment.GetFolderPath( System.Environment.SpecialFolder.ApplicationData );
			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=1;
			}
			cbSpecialFolder.Items.Add(System.Environment.SpecialFolder.ApplicationData.ToString());

			sTemp = Environment.GetFolderPath( System.Environment.SpecialFolder.InternetCache );
			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=2;
			}
			cbSpecialFolder.Items.Add("Temporary internet files");

			sTemp = Environment.GetFolderPath( System.Environment.SpecialFolder.MyMusic );
			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=3;
			}
			cbSpecialFolder.Items.Add("My music");

			sTemp = Environment.GetFolderPath( System.Environment.SpecialFolder.MyPictures );
			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=4;
			}
			cbSpecialFolder.Items.Add("My pictures");

			sTemp = Environment.GetFolderPath( System.Environment.SpecialFolder.Personal );
			if(sTemp.ToLower() == currentFolder.ToLower())
			{
				bRet = true;
				nSelIdx=5;
			}
			cbSpecialFolder.Items.Add("My documents");

			cbSpecialFolder.SelectedIndex = nSelIdx;
			return bRet;
		}

		/// <summary>
		/// Gets the full folder path of the currently selected special folder.
		/// </summary>
		/// <returns>Returns a full folder path.</returns>
		private string GetSpecialFolderPath()
		{
			string sRet = "";

			switch(cbSpecialFolder.SelectedIndex)
			{
				case 0:
				{
					sRet = System.Environment.GetEnvironmentVariable("TEMP");
					if(sRet.Length <= 0)
						sRet = System.Environment.GetEnvironmentVariable("TMP");
				};break;
				case 1:
				{
					sRet = Environment.GetFolderPath( System.Environment.SpecialFolder.ApplicationData );
				};break;
				case 2:
				{
					sRet = Environment.GetFolderPath( System.Environment.SpecialFolder.InternetCache );
				};break;
				case 3:
				{
					sRet = Environment.GetFolderPath( System.Environment.SpecialFolder.MyMusic );
				};break;
				case 4:
				{
					sRet = Environment.GetFolderPath( System.Environment.SpecialFolder.MyPictures );
				};break;
				case 5:
				{
					sRet = Environment.GetFolderPath( System.Environment.SpecialFolder.Personal );
				};break;
			}
			return sRet;
		}

		/// <summary>
		/// Called if the form is loaded
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void DumpCfg_Load(object sender, System.EventArgs e)
		{
			if( _dmpInfo == null)
			{
				chkDEnableDump.Checked = false;
				grpDumping.Enabled = false;
				txtFolderName.Visible = false;
				txtFolderName.Text = _prefDumpOutput;

				cbCompression.SelectedIndex = (int)_prefDumpCompression;
				FillSpecialFolders(_prefDumpOutput);

				chkTextTOC.Checked = ((_prefDumpFlags & DumpingFlags.DumpTextTOC)!=0);
				chkBinTOC.Checked = ((_prefDumpFlags & DumpingFlags.DumpBinaryTOC)!=0);
				chkTextIdx.Checked = ((_prefDumpFlags & DumpingFlags.DumpTextIndex)!=0);
				chkBinIdx.Checked = ((_prefDumpFlags & DumpingFlags.DumpBinaryIndex)!=0);
				chkStrings.Checked = ((_prefDumpFlags & DumpingFlags.DumpStrings)!=0);
				chkUrlstr.Checked = ((_prefDumpFlags & DumpingFlags.DumpUrlStr)!=0);
				chkUrltbl.Checked = ((_prefDumpFlags & DumpingFlags.DumpUrlTbl)!=0);
				chkTopics.Checked = ((_prefDumpFlags & DumpingFlags.DumpTopics)!=0);
				chkFulltext.Checked = ((_prefDumpFlags & DumpingFlags.DumpFullText)!=0);
			} 
			else 
			{
				chkDEnableDump.Checked = true;

				cbCompression.SelectedIndex = (int)_dmpInfo.CompressionLevel;

				chkTextTOC.Checked = _dmpInfo.DumpTextTOC;
				chkBinTOC.Checked = _dmpInfo.DumpBinaryTOC;
				chkTextIdx.Checked = _dmpInfo.DumpTextIndex;
				chkBinIdx.Checked = _dmpInfo.DumpBinaryIndex;
				chkStrings.Checked = _dmpInfo.DumpStrings;
				chkUrlstr.Checked = _dmpInfo.DumpUrlStr;
				chkUrltbl.Checked = _dmpInfo.DumpUrlTbl;
				chkTopics.Checked = _dmpInfo.DumpTopics;
				chkFulltext.Checked = _dmpInfo.DumpFullText;

				txtFolderName.Text = _dmpInfo.OutputDir;

				if(FillSpecialFolders(_dmpInfo.OutputDir))
				{
					rbSF.Checked = true;
					rbF.Checked = false;

					cbSpecialFolder.Visible = true;
					txtFolderName.Visible = false;
				} 
				else 
				{
					rbSF.Checked = false;
					rbF.Checked = true;

					cbSpecialFolder.Visible = false;
					txtFolderName.Visible = true;
				}
			}
		}

		/// <summary>
		/// Called if the user changes the checked-state
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void rbSF_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbSF.Checked)
			{
				cbSpecialFolder.Visible = true;
				txtFolderName.Visible = false;
			} 
			else 
			{
				cbSpecialFolder.Visible = false;
				txtFolderName.Visible = true;
			}
		}

		/// <summary>
		/// Called if the user changes the checked-state
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void rbF_CheckedChanged(object sender, System.EventArgs e)
		{
			if(rbSF.Checked)
			{
				cbSpecialFolder.Visible = true;
				txtFolderName.Visible = false;
			} 
			else 
			{
				cbSpecialFolder.Visible = false;
				txtFolderName.Visible = true;
			}
		}

		/// <summary>
		/// Called if the user clicks enable dump checkbox
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void chkDEnableDump_CheckedChanged(object sender, System.EventArgs e)
		{
			grpDumping.Enabled = chkDEnableDump.Checked;
		}

		/// <summary>
		/// Called if the user clicks OK
		/// </summary>
		/// <param name="sender">sender of the event</param>
		/// <param name="e">event parameter</param>
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if( chkDEnableDump.Checked)
			{
				DumpingFlags flags = 0;

				if( chkTextTOC.Checked )
					flags |= DumpingFlags.DumpTextTOC;

				if( chkBinTOC.Checked )
					flags |= DumpingFlags.DumpBinaryTOC;

				if( chkTextIdx.Checked )
					flags |= DumpingFlags.DumpTextIndex;

				if( chkBinIdx.Checked )
					flags |= DumpingFlags.DumpBinaryIndex;

				if( chkStrings.Checked )
					flags |= DumpingFlags.DumpStrings;

				if( chkUrlstr.Checked )
					flags |= DumpingFlags.DumpUrlStr;

				if( chkUrltbl.Checked )
					flags |= DumpingFlags.DumpUrlTbl;

				if( chkTopics.Checked )
					flags |= DumpingFlags.DumpTopics;

				if( chkFulltext.Checked )
					flags |= DumpingFlags.DumpFullText;

				DumpCompression compression = (DumpCompression)cbCompression.SelectedIndex;

				string sPath="";

				if(rbSF.Checked)
					sPath = GetSpecialFolderPath();
				else
					sPath = txtFolderName.Text;

				if(!Directory.Exists(sPath))
				{
					MessageBox.Show("The path \n  " + sPath +  "\ndould not be found on your PC !", "Path error", 
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				_prefDumpOutput = sPath;
				_prefDumpCompression = compression;
				_prefDumpFlags = flags;

				_dmpInfo = new DumpingInfo(flags, sPath, compression);
			} 
			else 
			{
				_dmpInfo = null;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}

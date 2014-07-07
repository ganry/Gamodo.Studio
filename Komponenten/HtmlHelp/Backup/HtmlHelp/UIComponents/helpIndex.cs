using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>helpIndex</c> implements a user control which displays the HtmlHelp index pane 
	/// known by the default HtmlHelp viewer
	/// </summary>
	public class helpIndex : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Event if the user changes the selection in the toc tree
		/// </summary>
		public event IndexSelectedEventHandler IndexSelected;
		/// <summary>
		/// Event if the user selects a keyword which is bound to more than one topic.
		/// </summary>
		/// <remarks>If you don't add an event handler for this event, the user control will show its own dialog 
		/// with the found topics.</remarks>
		public event TopicsFoundEventHandler TopicsFound;
		/// <summary>
		/// Internal member storing the arraylist of indezes
		/// </summary>
		public ArrayList _arrIndex = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbLookfor;
		private System.Windows.Forms.ListBox lbIndex;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDisplay;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public helpIndex()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Fireing the on selected event
		/// </summary>
		/// <param name="e">event parameters</param>
		protected virtual void OnIndexSelected(IndexEventArgs e)
		{
			if(IndexSelected != null)
			{
				IndexSelected(this,e);
			}
		}

		/// <summary>
		/// Fireing the topics found event
		/// </summary>
		/// <param name="e">event parameters</param>
		protected virtual void OnTopicsFound(TopicsFoundEventArgs e)
		{
			if(TopicsFound != null)
			{
				TopicsFound(this,e);
			} 
			else 
			{
				// if the user doesn't handle this event,
				// show an internal dialog listing the found topics

				TopicsFound frmTopics = new TopicsFound();

				frmTopics.Items= e.Topics;

				if( frmTopics.ShowDialog() == DialogResult.OK )
				{
					OnIndexSelected( new IndexEventArgs( frmTopics.SelectedTitle, frmTopics.SelectedUrl, false, new string[0]) );
				}
			}
		}

		/// <summary>
		/// Clears the items displayed in the index pane
		/// </summary>
		public void ClearContents()
		{
			lbIndex.Items.Clear();
		}

		/// <summary>
		/// Call this method to build the help-index and fill the internal list box
		/// </summary>
		/// <param name="index">Index instance extracted from the chm file(s)</param>
		/// <param name="typeOfIndex">type of index to display</param>
		public void BuildIndex(Index index, IndexType typeOfIndex)
		{
			BuildIndex(index, typeOfIndex, null);
		}

		/// <summary>
		/// Call this method to build the help-index and fill the internal list box
		/// </summary>
		/// <param name="index">Index instance extracted from the chm file(s)</param>
		/// <param name="typeOfIndex">type of index to display</param>
		/// <param name="filter">information type/category filter</param>
		public void BuildIndex(Index index, IndexType typeOfIndex, InfoTypeCategoryFilter filter)
		{
			switch(typeOfIndex)
			{
				case IndexType.AssiciativeLinks: _arrIndex = index.ALinks; break;
				case IndexType.KeywordLinks: _arrIndex = index.KLinks; break;
			}

			lbIndex.Items.Clear();

			foreach(IndexItem curItem in _arrIndex)
			{
				bool bAdd = true;

				if(filter != null)
				{
					bAdd = false;

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
					lbIndex.Items.Add( curItem.IndentKeyWord );
				}
			}
		}

		/// <summary>
		/// Sets the selected index text
		/// </summary>
		/// <param name="indexText">text to select</param>
		public void SelectText(string indexText)
		{
			tbLookfor.Text = indexText.Trim();
			int idx = lbIndex.FindString(indexText, 0);
			lbIndex.SelectedIndex = idx;
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbLookfor = new System.Windows.Forms.TextBox();
			this.lbIndex = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnDisplay = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Look for:";
			// 
			// tbLookfor
			// 
			this.tbLookfor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbLookfor.Location = new System.Drawing.Point(0, 16);
			this.tbLookfor.Name = "tbLookfor";
			this.tbLookfor.Size = new System.Drawing.Size(272, 20);
			this.tbLookfor.TabIndex = 1;
			this.tbLookfor.Text = "";
			this.tbLookfor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLookfor_KeyPress);
			this.tbLookfor.TextChanged += new System.EventHandler(this.tbLookfor_TextChanged);
			// 
			// lbIndex
			// 
			this.lbIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbIndex.Location = new System.Drawing.Point(0, 0);
			this.lbIndex.Name = "lbIndex";
			this.lbIndex.Size = new System.Drawing.Size(272, 277);
			this.lbIndex.TabIndex = 2;
			this.lbIndex.DoubleClick += new System.EventHandler(this.lbIndex_DoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tbLookfor);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(272, 40);
			this.panel1.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnDisplay);
			this.panel2.Controls.Add(this.lbIndex);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(272, 307);
			this.panel2.TabIndex = 4;
			// 
			// btnDisplay
			// 
			this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDisplay.Location = new System.Drawing.Point(192, 281);
			this.btnDisplay.Name = "btnDisplay";
			this.btnDisplay.TabIndex = 3;
			this.btnDisplay.Text = "&Display";
			this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
			// 
			// helpIndex
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "helpIndex";
			this.Size = new System.Drawing.Size(272, 347);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Called if the user double-clicks on the listbox
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void lbIndex_DoubleClick(object sender, System.EventArgs e)
		{
			DisplayTopic(false);
		}

		/// <summary>
		/// Called if the user clicks on the <c>Display</c> button
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void btnDisplay_Click(object sender, System.EventArgs e)
		{
			DisplayTopic(true);
		}

		/// <summary>
		/// Checks the selection of the listbox. If the keyword contains more than one topic, 
		/// a "Topics found" dialog will be displayed to the user and let him select de desired topic.
		/// Fires the <c>IndexSelected</c> event let the parent window know, that the user wants to view
		/// a new help topic.
		/// </summary>
		/// <param name="errorOnNothingSelected">set this true, if you want to display an error message if no item is selected</param>
		private void DisplayTopic(bool errorOnNothingSelected)
		{
			if(lbIndex.SelectedIndex >= 0)
			{
				IndexItem item = (IndexItem) _arrIndex[lbIndex.SelectedIndex];

				if( item.Topics.Count > 1)
				{

					OnTopicsFound( new TopicsFoundEventArgs(item.Topics));
				} 
				else 
				{
					if(item.IsSeeAlso)
					{
						if( item.SeeAlso.Length>0)
						{
							SelectText( item.SeeAlso[0] );
							string url = "";
							string title = item.KeyWord;

							if (item.Topics.Count == 1)
							{
								url = ((IndexTopic)item.Topics[0]).URL;
								title = ((IndexTopic)item.Topics[0]).Title;
							}

							OnIndexSelected( new IndexEventArgs( title, url, item.IsSeeAlso, item.SeeAlso) );
							return;
						}
					} 

					if (item.Topics.Count == 1)
					{
						OnIndexSelected( new IndexEventArgs( ((IndexTopic)item.Topics[0]).Title, ((IndexTopic)item.Topics[0]).URL, item.IsSeeAlso, item.SeeAlso) );
					}
				}
			} 
			else 
			{
				if(errorOnNothingSelected)
				{
					MessageBox.Show("Select a keyword first !","Index",MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Called if the user changes the text of the "Loof for" textbox
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tbLookfor_TextChanged(object sender, System.EventArgs e)
		{
			int idx = lbIndex.FindString(tbLookfor.Text, 0);
			lbIndex.SelectedIndex = idx;
		}

		/// <summary>
		/// Called if the user presses a key in the "Look for" textbox
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tbLookfor_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if( e.KeyChar == (char)Keys.Enter )
			{
				if( lbIndex.SelectedIndex >= 0)
				{
					DisplayTopic(true);
					e.Handled = true;
				}
			}
		}
	}
}

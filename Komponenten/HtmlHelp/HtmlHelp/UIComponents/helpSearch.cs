using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>helpSearch</c> implements a user control which displays the HtmlHelp full-text search pane to 
	/// the user.
	/// </summary>
	public class helpSearch : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Event if the user presses the "search" button in the control
		/// </summary>
		public event FTSearchEventHandler FTSearch;
		/// <summary>
		/// Event if the user changes the selection in the hit results
		/// </summary>
		public event HitSelectedEventHandler HitSelected;

		private DataTable _hits = null;
		private bool ascSort = false;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbLookfor;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView lvSearch;
		private System.Windows.Forms.CheckBox chkPartialMatch;
		private System.Windows.Forms.CheckBox chkTitlesOnly;
		private System.Windows.Forms.Button btnDoSearch;
		private System.Windows.Forms.ColumnHeader chTitle;
		private System.Windows.Forms.ColumnHeader chLocation;
		private System.Windows.Forms.ColumnHeader chRate;
		private System.Windows.Forms.Label lblResults;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		public helpSearch()
		{
			// This call is required by the Windows.Forms Form Designer.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDoSearch = new System.Windows.Forms.Button();
			this.chkTitlesOnly = new System.Windows.Forms.CheckBox();
			this.chkPartialMatch = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbLookfor = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblResults = new System.Windows.Forms.Label();
			this.lvSearch = new System.Windows.Forms.ListView();
			this.chTitle = new System.Windows.Forms.ColumnHeader();
			this.chLocation = new System.Windows.Forms.ColumnHeader();
			this.chRate = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnDoSearch);
			this.panel1.Controls.Add(this.chkTitlesOnly);
			this.panel1.Controls.Add(this.chkPartialMatch);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.tbLookfor);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 120);
			this.panel1.TabIndex = 4;
			// 
			// btnDoSearch
			// 
			this.btnDoSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.btnDoSearch.Location = new System.Drawing.Point(8, 96);
			this.btnDoSearch.Name = "btnDoSearch";
			this.btnDoSearch.Size = new System.Drawing.Size(224, 23);
			this.btnDoSearch.TabIndex = 4;
			this.btnDoSearch.Text = "&Search";
			this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
			// 
			// chkTitlesOnly
			// 
			this.chkTitlesOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.chkTitlesOnly.Location = new System.Drawing.Point(8, 64);
			this.chkTitlesOnly.Name = "chkTitlesOnly";
			this.chkTitlesOnly.Size = new System.Drawing.Size(224, 24);
			this.chkTitlesOnly.TabIndex = 3;
			this.chkTitlesOnly.Text = "Search titles only";
			// 
			// chkPartialMatch
			// 
			this.chkPartialMatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.chkPartialMatch.Checked = true;
			this.chkPartialMatch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPartialMatch.Location = new System.Drawing.Point(8, 40);
			this.chkPartialMatch.Name = "chkPartialMatch";
			this.chkPartialMatch.Size = new System.Drawing.Size(224, 24);
			this.chkPartialMatch.TabIndex = 2;
			this.chkPartialMatch.Text = "Get partial matches";
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
			this.tbLookfor.Size = new System.Drawing.Size(240, 20);
			this.tbLookfor.TabIndex = 1;
			this.tbLookfor.Text = "";
			this.tbLookfor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLookfor_KeyPress);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lblResults);
			this.panel2.Controls.Add(this.lvSearch);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 120);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(240, 264);
			this.panel2.TabIndex = 5;
			// 
			// lblResults
			// 
			this.lblResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblResults.Location = new System.Drawing.Point(8, 8);
			this.lblResults.Name = "lblResults";
			this.lblResults.Size = new System.Drawing.Size(224, 16);
			this.lblResults.TabIndex = 1;
			// 
			// lvSearch
			// 
			this.lvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.chTitle,
																					   this.chLocation,
																					   this.chRate});
			this.lvSearch.FullRowSelect = true;
			this.lvSearch.HideSelection = false;
			this.lvSearch.Location = new System.Drawing.Point(0, 24);
			this.lvSearch.MultiSelect = false;
			this.lvSearch.Name = "lvSearch";
			this.lvSearch.Size = new System.Drawing.Size(240, 240);
			this.lvSearch.TabIndex = 0;
			this.lvSearch.View = System.Windows.Forms.View.Details;
			this.lvSearch.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSearch_ColumnClick);
			this.lvSearch.SelectedIndexChanged += new System.EventHandler(this.lvSearch_SelectedIndexChanged);
			// 
			// chTitle
			// 
			this.chTitle.Text = "Title";
			this.chTitle.Width = 200;
			// 
			// chLocation
			// 
			this.chLocation.Text = "Location";
			this.chLocation.Width = 100;
			// 
			// chRate
			// 
			this.chRate.Text = "Rating";
			// 
			// helpSearch
			// 
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "helpSearch";
			this.Size = new System.Drawing.Size(240, 384);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Clears the items displayed in the search pane
		/// </summary>
		public void ClearContents()
		{
			lvSearch.Items.Clear();
		}

		/// <summary>
		/// Updates the search results with the records of the given datatable
		/// </summary>
		/// <param name="hits">hits table</param>
		public void SetResults(DataTable hits)
		{
			lvSearch.Items.Clear();

			_hits = hits;

			if(_hits != null)
			{
				for(int i=0; i<_hits.DefaultView.Count; i++)
				{
					ListViewItem lvItem = new ListViewItem( _hits.DefaultView[i].Row["Title"].ToString() );
					lvItem.SubItems.Add( _hits.DefaultView[i].Row["Location"].ToString() );
					lvItem.SubItems.Add( _hits.DefaultView[i].Row["Rating"].ToString() );
					lvItem.Tag = new HitEventArgs( _hits.DefaultView[i].Row["Title"].ToString(), 
						_hits.DefaultView[i].Row["URL"].ToString(), 
						_hits.DefaultView[i].Row["Location"].ToString(), (double)_hits.DefaultView[i].Row["Rating"]);

					lvSearch.Items.Add( lvItem );
				}

				lblResults.Text = _hits.DefaultView.Count.ToString() + " Result(s)";
			} 
			else 
			{
				lblResults.Text = "0 Result(s)";
			}
		}

		/// <summary>
		/// Sets the text which appears in the look-for textbox
		/// </summary>
		/// <param name="searchText"></param>
		public void SetSearchText(string searchText)
		{
			tbLookfor.Text = searchText.Trim();
		}

		/// <summary>
		/// Fireing the do search event
		/// </summary>
		/// <param name="e">event parameters</param>
		protected virtual void OnFTSearch(SearchEventArgs e)
		{
			if(FTSearch != null)
			{
				FTSearch(this,e);
			}
		}

		/// <summary>
		/// Fireing the do search event
		/// </summary>
		/// <param name="e">event parameters</param>
		protected virtual void OnHitSelected(HitEventArgs e)
		{
			if(HitSelected != null)
			{
				HitSelected(this,e);
			}
		}

		/// <summary>
		/// Called if the user clicks on the <c>Search</c> button.
		/// If the "Look for" text is not empty, this method fires the <c>FTSearch</c> event notifying the
		/// parent window, that the user wants to perform a fulltext search.
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void btnDoSearch_Click(object sender, System.EventArgs e)
		{
			if(tbLookfor.Text.Length > 0)
				OnFTSearch( new SearchEventArgs(tbLookfor.Text, chkPartialMatch.Checked, chkTitlesOnly.Checked) );
		}

		/// <summary>
		/// Called if the user selects an item of the search results. 
		/// This method fires the <c>HitSelected</c> event notifying the parent window, that the user wants to 
		/// view a new help topic.
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void lvSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if( lvSearch.SelectedItems.Count > 0)
			{
				OnHitSelected( ((HitEventArgs)(lvSearch.SelectedItems[0].Tag)) );
			}
		}

		/// <summary>
		/// Called if the user presses a key in the "Look for" textbox.
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void tbLookfor_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if( e.KeyChar == (char)Keys.Enter )
			{
				btnDoSearch_Click(this, EventArgs.Empty );
				e.Handled = true;
			}
		}

		/// <summary>
		/// Called if the user clicks on a column header of the search results
		/// </summary>
		/// <param name="sender">event sender</param>
		/// <param name="e">event parameter</param>
		private void lvSearch_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			string sSort = "Title " + (ascSort ? "ASC" : "DESC");

			if(e.Column == 1)
			{
				sSort = "Location " + (ascSort ? "ASC" : "DESC");
			}
			if(e.Column == 2)
			{
				sSort = "Rating " + (ascSort ? "ASC" : "DESC");
			}

			ascSort = !ascSort;

			if(_hits != null)
			{
				_hits.DefaultView.Sort = sSort;
				SetResults(_hits);
			}
		}
	}
}

using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The class <c>HelpProviderEx</c> implements an extended HelpProvider for interacting with
	/// the class library.
	/// </summary>
	[ProvideProperty("HelpNamespace", typeof(Control))]
	[ProvideProperty("HelpKeyword", typeof(Control))]
	[ProvideProperty("HelpNavigator", typeof(Control))]
	[ProvideProperty("HelpString", typeof(Control))]
	[ProvideProperty("ShowHelp", typeof(Control))]
	public class HelpProviderEx : Component, IExtenderProvider
	{
		private Hashtable helpNamespaces;
		private Hashtable helpKeywords;
		private Hashtable helpNavigators;
		private Hashtable helpStrings;
		private Hashtable helpShowHelpFlags;
		private Hashtable helpEvtHooks;
		
		private string _helpNamespace = "";
		private IHelpViewer _viewer = null;

		/// <summary>
		/// Standard constructor
		/// </summary>
		public HelpProviderEx()
		{
			helpNamespaces = new Hashtable();
			helpKeywords = new Hashtable();
			helpNavigators = new Hashtable();
			helpStrings = new Hashtable();
			helpShowHelpFlags = new Hashtable();
			helpEvtHooks = new Hashtable();
		}

		/// <summary>
		/// Gets/Sets the help viewer which will receive display requests
		/// </summary>
		[Browsable(false)]
		public IHelpViewer Viewer
		{
			get { return _viewer; }
			set
			{
				_viewer = value;
			}
		}

		/// <summary>
		/// Gets/Sets the HelpNamespace name
		/// </summary>
		/// <remarks>This property is only for compatibility with the default HelpProvider.</remarks>
		[Browsable(true)]
		[DefaultValue("")]
		[Description("The default helpnamespace (not required if you work within a HtmlHelpSystem environment!)")]
		public string HelpNamespace
		{
			get { return _helpNamespace; }
			set 
			{
				if(value == null)
					value = string.Empty;

				_helpNamespace = value;
			}
		}

		#region Get/Set methods for extender properties
		/// <summary>
		/// Gets the property HelpNamespace for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpNamespace should be retreived</param>
		/// <returns>Returns the HelpNamespace for this control</returns>
		[DefaultValue("")]
		public string GetHelpNamespace(Control control)
		{
			string hlpNamespace = (string)helpNamespaces[control];
			if(hlpNamespace == null)
				hlpNamespace = string.Empty;

			return hlpNamespace;
		}

		/// <summary>
		/// Sets the property HelpNamespace for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpNamespace should be set</param>
		/// <param name="value">value to set</param>
		public void SetHelpNamespace(Control control, string value)
		{
			if(helpEvtHooks[control]==null)
			{
				control.HelpRequested += new HelpEventHandler(this.HandleHelpRequested);
				helpEvtHooks[control]=true;
			}

			if(value == null)
				value = string.Empty;

			if(value.Length == 0)
				helpNamespaces.Remove(control);
			else
				helpNamespaces[control] = value;
		}

		/// <summary>
		/// Gets the property HelpKeyword for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpNamespace should be retreived</param>
		/// <returns>Returns the HelpNamespace for this control</returns>
		[DefaultValue("")]
		public string GetHelpKeyword(Control control)
		{
			string hlpKeyword = (string)helpKeywords[control];
			if(hlpKeyword == null)
				hlpKeyword = string.Empty;

			return hlpKeyword;
		}

		/// <summary>
		/// Sets the property HelpKeyword for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpKeyword should be set</param>
		/// <param name="value">value to set</param>
		public void SetHelpKeyword(Control control, string value)
		{
			if(helpEvtHooks[control]==null)
			{
				control.HelpRequested += new HelpEventHandler(this.HandleHelpRequested);
				helpEvtHooks[control]=true;
			}

			if(value == null)
				value = string.Empty;

			if(value.Length == 0)
				helpKeywords.Remove(control);
			else
				helpKeywords[control] = value;
		}

		/// <summary>
		/// Gets the property HelpNavigator for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpNavigator should be retreived</param>
		/// <returns>Returns the HelpNavigator for this control</returns>
		[DefaultValue(HelpNavigator.AssociateIndex)]
		public HelpNavigator GetHelpNavigator(Control control)
		{
			HelpNavigator hlpNavigator;

			if(helpNavigators[control]==null)
				hlpNavigator = HelpNavigator.AssociateIndex;
			else
				hlpNavigator = (HelpNavigator)helpNavigators[control];

			return hlpNavigator;
		}

		/// <summary>
		/// Sets the property HelpNavigator for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpNavigator should be set</param>
		/// <param name="value">value to set</param>
		public void SetHelpNavigator(Control control, HelpNavigator value)
		{	
			if(helpEvtHooks[control]==null)
			{
				control.HelpRequested += new HelpEventHandler(this.HandleHelpRequested);
				helpEvtHooks[control]=true;
			}

			helpNavigators[control] = value;
		}

		/// <summary>
		/// Gets the property HelpString for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpString should be retreived</param>
		/// <returns>Returns the HelpString for this control</returns>
		[DefaultValue("")]
		public string GetHelpString(Control control)
		{
			string hlpString = (string)helpStrings[control];
			if(hlpString == null)
				hlpString = string.Empty;

			return hlpString;
		}

		/// <summary>
		/// Sets the property HelpString for a specific control
		/// </summary>
		/// <param name="control">control for which the HelpString should be set</param>
		/// <param name="value">value to set</param>
		public void SetHelpString(Control control, string value)
		{
			if(helpEvtHooks[control]==null)
			{
				control.HelpRequested += new HelpEventHandler(this.HandleHelpRequested);
				helpEvtHooks[control]=true;
			}

			if(value == null)
				value = string.Empty;

			if(value.Length == 0)
				helpStrings.Remove(control);
			else
				helpStrings[control] = value;
		}

		/// <summary>
		/// Gets the property ShowHelp for a specific control
		/// </summary>
		/// <param name="control">control for which the ShowHelp should be retreived</param>
		/// <returns>Returns the ShowHelp for this control</returns>
		[DefaultValue(false)]
		public bool GetShowHelp(Control control)
		{
			bool hlpShowHelp;

			if(helpShowHelpFlags[control] == null)
				hlpShowHelp = false;
			else
				hlpShowHelp = (bool)helpShowHelpFlags[control];

			return hlpShowHelp;
		}

		/// <summary>
		/// Sets the property ShowHelp for a specific control
		/// </summary>
		/// <param name="control">control for which the ShowHelp should be set</param>
		/// <param name="value">value to set</param>
		public void SetShowHelp(Control control, bool value)
		{
			if(helpEvtHooks[control]==null)
			{
				control.HelpRequested += new HelpEventHandler(this.HandleHelpRequested);
				helpEvtHooks[control]=true;
			}

			if(value)
			{
				control.KeyPress += new KeyPressEventHandler(this.HandleKeyPressed);
			} 
			else 
			{
				control.KeyPress -= new KeyPressEventHandler(this.HandleKeyPressed);
			}

			helpShowHelpFlags[control] = value;
		}

		#endregion

		#region IExtenderProvider interface implementation
		
		/// <summary>
		/// Implements the interface method CanExtend()
		/// </summary>
		/// <param name="extendee">object/control which is checked if it is extendable by this provider</param>
		/// <returns>Returns true if the object can be extended</returns>
		bool IExtenderProvider.CanExtend(object extendee)
		{
			// allow extender on all controls
			if(extendee is Control)
				return true;

			return false;
		}

		#endregion

		#region Control event handlers
		/// <summary>
		/// Called if the user request help on one of the extended controls
		/// </summary>
		/// <param name="sender">sender of the event (the control)</param>
		/// <param name="e">event arguments</param>
		private void HandleHelpRequested(object sender, HelpEventArgs e)
		{
			if(! (sender is Control))
			{
				e.Handled = false;
				return;
			}

			if((HtmlHelpSystem.Current != null) && (_viewer != null))
			{
				HelpNavigator curNav = GetHelpNavigator(sender as Control);
				string keyword = GetHelpKeyword(sender as Control);
				string hlpString = GetHelpString(sender as Control);
				string hlpNamespace = GetHelpNamespace(sender as Control);

				if( hlpString.Length > 0)
				{
					e.Handled = true;
					// show popup help
					_viewer.ShowPopup(sender as Control, hlpString, e.MousePos);
					return;
				}

				e.Handled=true;
				_viewer.ShowHelp(hlpNamespace, curNav, keyword);
			} 
			else 
			{
				if(_helpNamespace.Length<=0)
				{
					throw new InvalidOperationException("You have to set the HelpNamespace in order to work with the HelpProvider!");
				}
				else
				{
					HelpNavigator curNav = GetHelpNavigator(sender as Control);
					string keyword = GetHelpKeyword(sender as Control);
					string hlpString = GetHelpString(sender as Control);

					if( hlpString.Length > 0)
					{
						e.Handled = true;
						// show popup help
						Help.ShowPopup(sender as Control, hlpString, e.MousePos);
						return;
					}

					if(curNav == HelpNavigator.Index)
					{
						e.Handled = true;
						Help.ShowHelpIndex(sender as Control, keyword);
						return;
					}

					e.Handled=true;

					if( keyword.Length<=0 )
					{
						Help.ShowHelp(sender as Control, _helpNamespace, curNav);
					} 
					else 
					{
						Help.ShowHelp(sender as Control, _helpNamespace, curNav, keyword);
					}
				}
			}
		}

		/// <summary>
		/// Called if the user presses a key in one of the extended controls
		/// </summary>
		/// <param name="sender">sender of the event (the control)</param>
		/// <param name="e">event arguments</param>
		private void HandleKeyPressed(object sender, KeyPressEventArgs e)
		{
			if(! (sender is Control))
			{
				e.Handled = false;
				return;
			}

			if( e.KeyChar == (char)Keys.F1)
			{
				Point ptLoc = new Point( ((Control)sender).Location.X, ((Control)sender).Location.Y + ((Control)sender).Size.Height);
				HandleHelpRequested(sender, new HelpEventArgs(ptLoc) );
			}
		}
		#endregion
	}
}
 
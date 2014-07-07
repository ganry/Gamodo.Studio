using System;
using System.Windows.Forms;
using System.Drawing;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// The interface <c>IHelpViewer</c> defines methods/properties for a help-viewing window.
	/// </summary>
	public interface IHelpViewer
	{
		/// <summary>
		/// Navigates the helpviewer to a specific help url
		/// </summary>
		/// <param name="url">url</param>
		void NavigateTo(string url);
		/// <summary>
		/// Shows help for a specific url
		/// </summary>
		/// <param name="namespaceFilter">namespace filter (used for merged files)</param>
		/// <param name="hlpNavigator">navigator value</param>
		/// <param name="keyword">keyword</param>
		void ShowHelp(string namespaceFilter, HelpNavigator hlpNavigator, string keyword);
		/// <summary>
		/// Shows help for a specific keyword
		/// </summary>
		/// <param name="namespaceFilter">namespace filter (used for merged files)</param>
		/// <param name="hlpNavigator">navigator value</param>
		/// <param name="keyword">keyword</param>
		/// <param name="url">url</param>
		void ShowHelp(string namespaceFilter, HelpNavigator hlpNavigator, string keyword, string url);
		/// <summary>
		/// Shows the help index
		/// </summary>
		/// <param name="url">url</param>
		void ShowHelpIndex(string url);
		/// <summary>
		/// Shows a help popup window
		/// </summary>
		/// <param name="parent">the parent control for the popup window</param>
		/// <param name="text">help text</param>
		/// <param name="location">display location</param>
		void ShowPopup(Control parent, string text, Point location);
	}
}

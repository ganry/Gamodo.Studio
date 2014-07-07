using System;
using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// Eventhandler for handling toc-tree events
	/// </summary>
	public delegate void TocSelectedEventHandler(object sender, TocEventArgs e);

	/// <summary>
	/// The class <c>TocEventArgs</c> implements event arguments for toc selected event
	/// </summary>
	public class TocEventArgs : EventArgs
	{
		private TOCItem _tocItem = null;

		/// <summary>
		/// Standard constructor
		/// </summary>
		/// <param name="item">toc item associated with the event</param>
		public TocEventArgs(TOCItem item)
		{
			_tocItem = item;
		}

		/// <summary>
		/// Gets the associated item
		/// </summary>
		public TOCItem Item
		{
			get { return _tocItem; }
		}
	}
}

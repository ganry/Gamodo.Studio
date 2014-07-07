using System;
using System.Collections;
using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// Eventhandler for handling the topics found event.
	/// </summary>
	public delegate void TopicsFoundEventHandler(object sender, TopicsFoundEventArgs e);

	/// <summary>
	/// The class <c>TopicsFoundEventArgs</c> implements event arguments for the TopicsFound event of the index 
	/// user controll. 
	/// </summary>
	/// <remarks>If you don't add an event handler for this event, the user control will show its own dialog 
	/// with the found topics.</remarks>
	public class TopicsFoundEventArgs
	{
		private ArrayList _topics = new ArrayList();

		/// <summary>
		/// Constructor of the class
		/// </summary>
		/// <param name="topics">topics found</param>
		public TopicsFoundEventArgs(ArrayList topics)
		{
			_topics = topics;
		}

		/// <summary>
		/// Gets an arraylist containing all found topics.
		/// </summary>
		/// <remarks>Each item is of type IndexTopic.</remarks>
		public ArrayList Topics
		{
			get { return _topics; }
		}
	}
}

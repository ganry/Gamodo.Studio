using System;
using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// Eventhandler for handling helpIndex events
	/// </summary>
	public delegate void IndexSelectedEventHandler(object sender, IndexEventArgs e);

	/// <summary>
	/// The class <c>IndexEventArgs</c> implements event arguments for index selected event
	/// </summary>
	public class IndexEventArgs : EventArgs
	{
		private string _title = "";
		private string _url = "";
		private bool _isSeeAlso = false;
		private string[] _seeAlso = new string[0];

		/// <summary>
		/// Constructor of the event args
		/// </summary>
		/// <param name="title">the title of the topic</param>
		/// <param name="url">url selected by the user</param>
		/// <param name="isSeeAlso">true if the indexitem is a see also link</param>
		/// <param name="seeAlso">array of see also key words</param>
		public IndexEventArgs(string title, string url, bool isSeeAlso, string[] seeAlso)
		{
			_title = title;
			_url = url;
			_isSeeAlso = isSeeAlso;
			_seeAlso = seeAlso;
		}

		/// <summary>
		/// Gets the title of the selected topic
		/// </summary>
		public string Title
		{
			get { return _title; }
		}

		/// <summary>
		/// Gets the topic-url selected by the user
		/// </summary>
		public string URL
		{
			get { return _url; }
		}

		/// <summary>
		/// Gets the flag if the index item is a see also link
		/// </summary>
		public bool IsSeeAlso
		{
			get { return _isSeeAlso; }
		}

		/// <summary>
		/// Gets the see also key words
		/// </summary>
		public string[] SeeAlso
		{
			get { return _seeAlso; }
		}
	}
}

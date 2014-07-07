using System;
using System.Data;
using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// Eventhandler for handling full-text search events
	/// </summary>
	public delegate void FTSearchEventHandler(object sender, SearchEventArgs e);

	/// <summary>
	/// The class <c>SearchEventArgs</c> implements the event arguments for the FTSearch event.
	/// </summary>
	public class SearchEventArgs
	{
		private string _words = "";
		private bool _partial = false;
		private bool _titlesOnly = true;

		/// <summary>
		/// Constructor of the class
		/// </summary>
		/// <param name="words">words to search</param>
		/// <param name="partial">search partial words</param>
		/// <param name="titlesOnly">search titles only</param>
		public SearchEventArgs(string words, bool partial, bool titlesOnly)
		{
			_words = words;
			_partial = partial;
			_titlesOnly = titlesOnly;
		}

		/// <summary>
		/// Gets the words to search
		/// </summary>
		public string Words
		{
			get { return _words; }
		}

		/// <summary>
		/// Gets the flag if partial words should also be searched
		/// </summary>
		public bool PartialWords
		{
			get { return _partial; }
		}

		/// <summary>
		/// Gets the flag if only search in titles
		/// </summary>
		public bool TitlesOnly
		{
			get { return _titlesOnly; }
		}
	}
}

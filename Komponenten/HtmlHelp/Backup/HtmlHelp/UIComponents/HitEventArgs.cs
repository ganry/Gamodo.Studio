using System;
using HtmlHelp;

namespace HtmlHelp.UIComponents
{
	/// <summary>
	/// Eventhandler for handling full-text search-hit events
	/// </summary>
	public delegate void HitSelectedEventHandler(object sender, HitEventArgs e);

	/// <summary>
	/// The class <c>HitEventArgs</c> implements the event parameters which occures if the user selects a search hit.
	/// </summary>
	public class HitEventArgs
	{
		private string _title = "";
		private string _url = "";
		private string _location = "";
		private double _rating = 0.0;

		/// <summary>
		/// Constructor of the event args
		/// </summary>
		/// <param name="title">the title of the topic</param>
		/// <param name="url">url selected by the user</param>
		/// <param name="location">location of the hit</param>
		/// <param name="rating">rating of the hit</param>
		public HitEventArgs(string title, string url, string location, double rating)
		{
			_title = title;
			_url = url;
			_location = location;
			_rating = rating;
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
		/// Gets the location of the selected topic
		/// </summary>
		public string Location
		{
			get { return _location; }
		}

		/// <summary>
		/// Gets the rating of the selected hit
		/// </summary>
		public double Rating
		{
			get { return _rating; }
		}
	}
}

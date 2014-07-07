using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace ActiveWare.CodeBrowser
{
    /// <summary>
    /// Eventhandler for handling html-tree events
    /// </summary>
    public delegate void HtmlNodeSelectedEventHandler(object sender, HtmlEventArgs e);

    /// <summary>
    /// The class <c>HtmlEventArgs</c> implements event arguments for html selected event
    /// </summary>
    public class HtmlEventArgs : EventArgs
    {
        private HtmlNode _htmlItem = null;

        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="item">toc item associated with the event</param>
        public HtmlEventArgs(HtmlNode item)
        {
            _htmlItem = item;
        }

        /// <summary>
        /// Gets the associated item
        /// </summary>
        public HtmlNode Item
        {
            get { return _htmlItem; }
        }
    }
}

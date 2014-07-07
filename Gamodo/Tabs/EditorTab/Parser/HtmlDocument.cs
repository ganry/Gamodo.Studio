using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gamodo.Tabs.EditorTab.Parser
{
    public class HtmlDocument: AbstractDocument
    {
        private HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
        private List<AbstractDocument> childList;
        private List<AbstractDocument> styleChilds;

        public HtmlAgilityPack.HtmlDocument ParsedFile
        {
            get { return htmlDoc; }
            set { htmlDoc = value; }
        }

        public HtmlDocument(string fileName, string text)
        {
            this.fileName = fileName;
            htmlDoc.LoadHtml(text);
        }

        public void ParseDocument(string text)
        {
            htmlDoc.LoadHtml(text);
        }

        #region childs

        public void AddStyleChild(AbstractDocument doc)
        {
            if (styleChilds == null)
                styleChilds = new List<AbstractDocument>();
            styleChilds.Add(doc);
        }

        public void AddChild(AbstractDocument doc)
        {
            if (childList == null)
                childList = new List<AbstractDocument>();
            childList.Add(doc);
        }

        public void ClearStyleChilds()
        {
            if (styleChilds != null)
                styleChilds.Clear();
        }

        #endregion
    }
}

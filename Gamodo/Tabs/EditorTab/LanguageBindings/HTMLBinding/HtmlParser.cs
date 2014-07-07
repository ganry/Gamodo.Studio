using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Aga.Controls.Tree;
using ActiveWare.CodeBrowser;
using System.Windows.Forms;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public enum HtmlDocType
    {
        HTML4,
        XHTML1,
        XHTML11,
        HTML5
    }

    public class HtmlParserClass
    {
        private HtmlAgilityPack.HtmlDocument htmlDoc =  new HtmlAgilityPack.HtmlDocument();
        private CodeBrowserControl codeBrowser;
        private ImageList imageList = MainForm.mainForm.imgHtmlCompletion;
        public List<Node> StyleNodes;


        public HtmlAgilityPack.HtmlDocument HtmlDoc
        {
            get { return htmlDoc; }
        }

        public HtmlParserClass(CodeBrowserControl codeBrowser)
        {
            this.codeBrowser = codeBrowser;
        }

        #region getImageIndex
        private int getImageIndex(string tag)
        {
            switch (tag)
            {
                case "h1":
                    return 1;

                case "h2":
                    return 2;

                case "h3":
                    return 3;

                case "h4":
                    return 4;

                case "h5":
                    return 5;

                case "h6":
                    return 6;

                case "b":
                    return 7;

                case "i":
                    return 8;

                case "u":
                    return 9;

                case "ul":
                    return 10;

                case "ol":
                    return 11;

                case "li":
                    return 12;

                case "table":
                    return 13;

                case "img":
                    return 14;

                case "a":
                    return 15;

                case "div":
                    return 16;

                case "span":
                    return 17;

                case "form":
                    return 18;

                case "hr":
                    return 19;

                case "input":
                    return 20;

                case "center":
                    return 21;

                case "font":
                    return 22;

                case "html":
                    return 23;

                case "frameset":
                    return 24;

                case "script":
                    return 25;

                case "style":
                    return 26;

                case "sub":
                    return 27;

                case "sup":
                    return 28;

                case "strike":
                    return 29;

                case "iframe":
                    return 30;

                case "frame":
                    return 30;

                case "php":
                    return 33;

                default:
                    return 0;
            }
        }
        #endregion

        private void BuildTree()
        {
            HtmlNode rootHtmlNode = htmlDoc.DocumentNode;
            Node rootNode = new Node(MainForm.rm.GetString("defaultFileName"));
            rootNode.Image = imageList.Images[34];
            rootNode.Object = rootHtmlNode;
            codeBrowser._model.Nodes.Add(rootNode);

            if (StyleNodes != null)
            {
                StyleNodes.Clear();
                StyleNodes = null;
            }

            if (rootHtmlNode.HasChildNodes) //&& codeBrowser.CanParse())
            {
                BuildChilds(rootHtmlNode, rootNode);
            }
        }

        private void BuildChilds(HtmlNode htmlNode, Node rootNode)
        {
            
            foreach (var item in htmlNode.ChildNodes)
            {
                string itemText = "";
                if (item.Name == "?" || item.Name == "?php")
                    itemText = "php";
                else
                    itemText = item.Name;

                if (!(item.Name == "#text") && !(item.Name == "#comment"))
                {
                    int imageIndex = getImageIndex(itemText);

                    if (item.HasAttributes)
                    {
                        foreach (var attr in item.Attributes)
                        {
                            if (attr.Name == "id")
                            {
                                itemText += " : " + attr.Value;
                            }
                        }

                    }
                    
                    Node childNode = new Node(itemText);
                    childNode.Image = imageList.Images[imageIndex];
                    childNode.Object = item;
                    rootNode.Nodes.Add(childNode);

                    if (item.Name == "style")
                    {
                        if (StyleNodes == null)
                            StyleNodes = new List<Node>();
                        StyleNodes.Add(childNode);
                    }

                    if (item.HasChildNodes)
                    {
                        BuildChilds(item, childNode);
                    }
                }
            }
        }

        public void ClearAll()
        {
            foreach (TreeNodeAdv node in codeBrowser._tree.AllNodes)
            {
                TreeNodeAdv Node = node;
                if (node.Tag is Node)
                {
                    (node.Tag as Node).Image = null;
                    (node.Tag as Node).Object = null;
                    Node = null;
                }
            }
            codeBrowser._model.Nodes.Clear();

            htmlDoc.DocumentNode.RemoveAll();
            //htmlDoc = null;
        }

        public void Parse(string text)
        {
            ClearAll();
            htmlDoc.LoadHtml(text);

            codeBrowser._tree.BeginUpdate();
            
            BuildTree();
            codeBrowser._tree.ExpandAll();
            codeBrowser._tree.EndUpdate();
           
        }
    }
}

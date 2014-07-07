using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveWare.CodeBrowser;
using System.Windows.Forms;
using Aga.Controls.Tree;
using HtmlAgilityPack;
using System.IO;

namespace Gamodo.Tabs.EditorTab.Parser
{
    public class HtmlParser
    {
        private CodeBrowserControl codeBrowser;
        private ImageList imageList = MainForm.mainForm.imgHtmlCompletion;

        public void Parse(string fileName, string textToParse, bool reparse, CodeBrowserControl codeBrowser)
        {
            this.codeBrowser = codeBrowser;

            HtmlDocument htmlDocument = (HtmlDocument)DocumentList.GetDocument(fileName);
            if (htmlDocument == null)
            {
                htmlDocument = new HtmlDocument(fileName, textToParse);
                DocumentList.AddDocument(htmlDocument);
            }
            else
            {
                if (reparse)
                {
                    codeBrowser.Clear();
                    htmlDocument.ClearStyleChilds();
                    htmlDocument.ParseDocument(textToParse);
                }
            }

            codeBrowser._tree.BeginUpdate();

            BuildTree(htmlDocument);
            codeBrowser._tree.ExpandAll();
            codeBrowser._tree.EndUpdate();
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

        private void BuildTree(HtmlDocument htmlDoc)
        {
            HtmlNode rootHtmlNode = htmlDoc.ParsedFile.DocumentNode;
            Node rootNode = new Node(MainForm.rm.GetString("defaultFileName"));
            rootNode.Image = imageList.Images[34];
            rootNode.Object = rootHtmlNode;
            codeBrowser._model.Nodes.Add(rootNode);

            /*
            if (StyleNodes != null)
            {
                StyleNodes.Clear();
                StyleNodes = null;
            }*/

            if (rootHtmlNode.HasChildNodes) //&& codeBrowser.CanParse())
            {
                BuildChilds(rootHtmlNode, rootNode, htmlDoc);
            }
        }

        private void BuildChilds(HtmlNode htmlNode, Node rootNode, HtmlDocument htmlDoc)
        {

            foreach (var item in htmlNode.ChildNodes)
            {
                string itemText = "";
                if (item.Name == "?" || item.Name == "?php")
                    itemText = "php";
                else if (item.Name == "link" && item.HasAttributes && item.Attributes["href"] != null)
                    itemText = "link : " + item.Attributes["href"].Value;
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
                                itemText += " : #" + attr.Value;
                            else if (attr.Name == "class")
                                itemText += " : " + attr.Value;
                        }

                    }

                    Node childNode = new Node(itemText);
                    childNode.Image = imageList.Images[imageIndex];
                    childNode.Object = item;
                    rootNode.Nodes.Add(childNode);

                   if (item.Name == "link")
                    {
                       //fehler müssen abgefangen werde
                        if (item.Attributes["href"].Value.EndsWith(".css"))
                        {
                            item.FileName = Path.GetDirectoryName(htmlDoc.FileName) + "\\" + item.Attributes["href"].Value;
                            ParserClass.CssParser.Parse(item.FileName, CssParser.ReadFile(item.FileName), false);
                        }
                    }
                    
                    if (item.Name == "style")
                    {
                        CssDocument css = ParserClass.CssParser.Parse(item.InnerText);
                        htmlDoc.AddStyleChild(css);
                        ParserClass.CssParser.GenerateTree(MainForm.mainForm.codeBrowser.codeBrowserControl, css, childNode, false);
                        
                        /*
                        if (StyleNodes == null)
                            StyleNodes = new List<Node>();
                        StyleNodes.Add(childNode);
                         * */
                    }
                    

                    if (item.HasChildNodes)
                    {
                        if (item.Name == "?")
                            BuildChilds(item, rootNode, htmlDoc);
                        else
                            BuildChilds(item, childNode, htmlDoc);
                    }
                }
            }
        }

        /*
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
        }*/
    }
}

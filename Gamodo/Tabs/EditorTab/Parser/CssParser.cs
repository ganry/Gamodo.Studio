using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveWare.CodeBrowser;
using System.Windows.Forms;
using Aga.Controls.Tree;
using ActiveWare.CSS;
using System.IO;

namespace Gamodo.Tabs.EditorTab.Parser
{
    public class CssParser
    {
        private CodeBrowserControl codeBrowser;
        private ImageList imageList = MainForm.mainForm.imgCSS;

        private Node classNode;
        private Node elementsNode;
        private Node idNode;

        ///<summary>
        /// Liefert den Inhalt der Datei zurück.
        ///</summary>
        ///<param name="sFilename">Dateipfad</param>
        public static string ReadFile(String sFilename)
        {
            string sContent = "";

            if (File.Exists(sFilename))
            {
                StreamReader myFile = new StreamReader(sFilename, System.Text.Encoding.Default);
                sContent = myFile.ReadToEnd();
                myFile.Close();
            }
            return sContent;
        }

        public CssDocument Parse(string textToParse)
        {
            CssDocument cssDoc;
            cssDoc = new CssDocument("child");
            cssDoc.ParseDocument(textToParse);
            return cssDoc;
        }


        public CssDocument Parse(string fileName, string textToParse, bool reparse)
        {
            CssDocument cssDocument;

            if (fileName == "")
            {
                cssDocument = new CssDocument(fileName);
                cssDocument.ParseDocument(textToParse);
            }
            else
            {
                cssDocument = (CssDocument)DocumentList.GetDocument(fileName);
                if (cssDocument == null)
                {
                    cssDocument = new CssDocument(fileName);
                    cssDocument.ParseDocument(textToParse);
                    DocumentList.AddDocument(cssDocument);
                }
                else
                {
                    if (reparse)
                    {
                        codeBrowser.Clear();
                        cssDocument.ParseDocument(textToParse);
                    }
                }
            }

            return cssDocument;
        }

        public void GenerateTree(CodeBrowserControl codeBrowser, CssDocument css, Node parent = null, bool clear = true)
        {
            this.codeBrowser = codeBrowser;
            if (clear)
            codeBrowser.Clear();
            codeBrowser._tree.BeginUpdate();

            BuildTree(css, parent);
            codeBrowser._tree.ExpandAll();
            codeBrowser._tree.EndUpdate();
        }

        private void BuildTree(CssDocument css, Node parentNode)
        {
            classNode = new Node(MainForm.rm.GetString("css_class"));
            classNode.Image = imageList.Images[0];

            idNode = new Node(MainForm.rm.GetString("css_ids"));
            idNode.Image = imageList.Images[2];

            elementsNode = new Node(MainForm.rm.GetString("css_element"));
            elementsNode.Image = imageList.Images[1];

            Node parent;

            if (parentNode != null)
                parent = parentNode;
            else
            {
                parent = new Node(MainForm.rm.GetString("defaultFileName"));
                parent.Image = imageList.Images[0];
                parent.Object = css;
                codeBrowser._model.Nodes.Add(parent);
            }

            parent.Nodes.Add(classNode);
            parent.Nodes.Add(idNode);
            parent.Nodes.Add(elementsNode);

            FillRuleSet(css.ParsedFile, parent);
        }

        private void FillRuleSet(IRuleSetContainer irc, Node parent)
        {

            // Media, Doc
            foreach (RuleSet rs in irc.RuleSets)
            {
                Node head = parent == null ? new Node("NULL") : parent;


                if (rs.Selectors.Count > 0)
                {
                    Selector first = rs.Selectors[0];
                    Node stn = new Node(first.ToString());


                    //stn.Image = codeBrowser.imgCSS.Images[getImageIndex(first.ToString())];
                    head = stn;
                    /*
                    if (rs.Selectors.Count > 1)
                    {
                        bool start = true;
                        Node temp = stn;
                        foreach (Selector s in rs.Selectors)
                        {
                            if (start) { start = false; continue; }
                            Node child = new Node(s.ToString());
                            head.Nodes.Add(child);
                            temp = child;
                        }
                    }*/
                }
                head.Object = rs;


                //FillDeclarations(rs, head.Text.Equals("NULL") ? null : head);
                if (parent == null)
                {
                    throw new Exception("CSS parent can't be null");
                }
                else
                {
                    switch (head.Text[0])
                    {
                        case '.':
                            head.Image = imageList.Images[3];
                            classNode.Nodes.Add(head);
                            break;
                        case '#':
                            head.Image = imageList.Images[5];
                            idNode.Nodes.Add(head);
                            break;
                        default:
                            head.Image = imageList.Images[4];
                            elementsNode.Nodes.Add(head);
                            break;
                    }
                }
            }
        }
    }
}

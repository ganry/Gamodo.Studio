using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActiveWare.CodeBrowser;
using Aga.Controls.Tree;
using ActiveWare.CSS;
using Gamodo.Editor;
using ICSharpCode.TextEditor;
using Aga.Controls.Tree.NodeControls;
using System.Drawing;
using System.Windows.Forms;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class CssParser
    {
        private CSSDocument cssDoc = new CSSDocument();
        private CodeBrowserControl codeBrowser;
        private Font _childFont;
        private ImageList imageList = MainForm.mainForm.imgCSS;

        private Node classNode;
        private Node elementsNode;
        private Node idNode;

        public CSSDocument CssDoc
        {
            get { return cssDoc; }
        }

        public CssParser(CodeBrowserControl codeBrowser)
        {
            this.codeBrowser = codeBrowser;
            _childFont = new Font(codeBrowser._tree.Font.FontFamily, 8);
            codeBrowser._nodeTextBox.DrawText += new EventHandler<DrawEventArgs>(_nodeTextBox_DrawText);
        }

        #region getImageIndex
        private int getImageIndex(string tag)
        {

            switch (tag[0])
            {
                case '.':
                    return 1;
                case '#':
                    return 2;

                default:
                    return 0;
            }
        }
        #endregion

        void _nodeTextBox_DrawText(object sender, DrawEventArgs e)
        {
            if (((e.Node.Tag as Node).Parent.Parent != null) && (e.Node.Tag as Node).Parent.Parent.Text == "style")
            {
                e.TextColor = Color.Gray;
                e.Font = _childFont;
            }
        }

        private void FillTree(CSSDocument css, Node parentNode)
        {
            /*
            foreach (Directive dir in css.Directives)
            {
                string name = dir.Name;
                int ico = dir.Type == DirectiveType.Charset || dir.Type == DirectiveType.Import ? 3 : 2;
                if (dir.Expression != null)
                {
                    name += " " + dir.Expression.ToString();
                }
                else if (dir.Mediums.Count > 0)
                {
                    bool first = true;
                    name += " ";
                    foreach (Medium m in dir.Mediums)
                    {
                        if (first) { first = false; } else { name += ", "; }
                        name += m.ToString();
                    }
                }
            }*/

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

            FillRuleSet(css, parent);
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

        /*
        private void FillDeclarations(RuleSet idc, Node parent)
        {
            // FontFace, Page, RuleSet
            foreach (Declaration dec in idc.Declarations)
            {
                string name = dec.Name;
                string seperator = null;
                int counter = 0;
                if (dec.Important) { name += " !important"; }
                name += ": ";
                Node dtn = new Node(name);
                dtn.Image = codeBrowser.imgCSS.Images[5];

                if (dec.Expression != null)
                {
                    foreach (Term t in dec.Expression.Terms)
                    {
                        counter++;
                        string trmname = t.ToString();
                        seperator = t.Seperator.ToString();
                        if (trmname.StartsWith(", "))
                        {
                            trmname = trmname.Substring(2);
                        }
                        int ico = 5;
                        
                        switch (t.Type)
                        {
                            case TermType.Number: ico = 5; break;
                            case TermType.String: ico = 6; break;
                            case TermType.Unicode: ico = 7; break;
                            case TermType.Url: ico = 8; break;
                            case TermType.Hex: ico = 9; break;
                            case TermType.Function: ico = 10; break;
                        }
                         
                        Node trm = new Node(trmname);

                        if (counter != dec.Expression.Terms.Count)
                        {
                            if (dec.Name == "font-family")
                                seperator = ", ";
                            else if (t.Seperator == ',')
                                seperator = ", ";
                            else
                                seperator = " ";
                        }
                        else
                            seperator = "";

                        dtn.Text += trmname + seperator;
                        //dtn.Nodes.Add(trm);
                    }
                    //dtn.Text = dtn.Text.TrimEnd(' ');
                    dtn.Text += ";";
                }

                if (parent == null)
                {
                    codeBrowser._model.Nodes.Add(dtn);
                }
                else
                {
                    parent.Nodes.Add(dtn);
                }
            }
        }*/

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

            cssDoc.RuleSets.Clear();
        }
        

        public void Parse(string text, Node parentNode = null)
        {
            codeBrowser._tree.BeginUpdate();
            if (parentNode == null)
                ClearAll();
            ActiveWare.CSS.CSSParser parser = new ActiveWare.CSS.CSSParser();
            parser.ParseText(text);
            cssDoc = parser.CSSDocument;
            if (cssDoc != null)
                FillTree(cssDoc, parentNode);
            //codeBrowser._tree.ExpandAll();
            codeBrowser._tree.EndUpdate();
        }
    }
}

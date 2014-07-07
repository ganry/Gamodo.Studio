using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using HtmlAgilityPack;
using Aga.Controls.Tree;
using Gamodo.Tabs;
using Gamodo.Tabs.EditorTab;
using ActiveWare.CSS;
using ICSharpCode.TextEditor;
using ActiveWare.CodeBrowser;
using System.IO;

namespace Gamodo.UserInterface
{
    public partial class CodeBrowserDock : DockBase
    {
        public CodeBrowserDock()
        {
            InitializeComponent();
            codeBrowserControl.HtmlSelected += new HtmlNodeSelectedEventHandler(HtmlSelected);
            codeBrowserControl.NodeClick += new EventHandler<TreeNodeAdvMouseEventArgs>(CssSelected);
        }

        public HtmlNode GetParentStyleNode(Node child)
        {
            if (child.Parent.Parent.Object is HtmlNode)
            {
                return child.Parent.Parent.Object as HtmlNode;
            }
            return null;
        }

        public void CssSelected(object sender, TreeNodeAdvMouseEventArgs e)
        {
            EditorTab editorTab = MainForm.mainForm.ActiveDocumentTab as EditorTab;
            if (editorTab != null)
                if (e.Node.Tag != null)
                {
                    Node node = (e.Node.Tag as Node);
                    if (node != null)
                    {

                        RuleSet ruleSet = (node.Object as RuleSet);
                        if (ruleSet != null)
                        {
                            TextLocation tl = new TextLocation(ruleSet.Col - 1, ruleSet.Line - 1);
                            HtmlNode styleNode = GetParentStyleNode(node);
                            if (styleNode != null)
                            {
                                if (styleNode.Name == "link")
                                {
                                    if (File.Exists(styleNode.FileName))
                                        MainForm.mainForm.OpenFile(styleNode.FileName);
                                }
                                else
                                {
                                    TextLocation tl2 = editorTab.editor.Document.OffsetToPosition(styleNode.StreamPosition);
                                    tl.Line += tl2.Line;
                                }

                            }
                            (MainForm.mainForm.ActiveDocumentTab as EditorTab).editor.Caret.Position = tl;
                            (MainForm.mainForm.ActiveDocumentTab as EditorTab).editor.Focus();
                        }
                    }
                }
        }

        public void HtmlSelected(object sender, HtmlEventArgs e)
        {
            EditorTab editorTab = MainForm.mainForm.ActiveDocumentTab as EditorTab;
            if (editorTab != null)
            {
                TextLocation tl = editorTab.editor.Document.OffsetToPosition(e.Item.StreamPosition);
                editorTab.editor.Caret.Position = tl;
                editorTab.editor.Focus();
            }
        }
        
    }
}

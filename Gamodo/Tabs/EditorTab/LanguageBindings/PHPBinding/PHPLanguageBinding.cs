using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Tabs.Interface;
using ICSharpCode.TextEditor.Document;
using Gamodo.Editor;
using Gamodo.Tabs.EditorTab.Tools;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using System.Drawing;
using ICSharpCode.TextEditor;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class PHPLanguageBinding
    {
        IFormattingStrategy phpFormatting = null;
        IFoldingStrategy phpFolding = null;
        
        EditorControl editor;
        TextMarker txtMarker;

        public PHPLanguageBinding(EditorControl edit)
        {
            editor = edit;
            editor.ActiveTextAreaControl.TextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(TextArea_KeyDown);

            phpFolding = new PHPFoldingStrategy();
            phpFormatting = new PHPFormattingStrategy();
        }

        void TextArea_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            Point p1 = e.Location;
            TextLocation tl = editor.ActiveTextAreaControl.TextArea.TextView.GetLogicalPosition(p1);
            int offset = editor.Document.PositionToOffset(tl);

            
            int colorBegin = TextUtilities.FindWordStart(editor.Document, offset);
            int colorEnd = TextUtilities.FindWordEnd(editor.Document, offset);
            string color = TextUtilities.GetWordAt(editor.Document, offset);
            
            Color c = HTMLColorConverter.convertHtmlHexColorToColor("#"+color);
            Console.WriteLine(color);
            if (c != Color.Empty)
            {
                if (colorMarker != null)
                {

                    //editor.Document.MarkerStrategy.RemoveMarker(colorMarker);
                    //colorMarker = null;
                }
                /*
                colorMarker = new TextMarker(colorBegin, colorEnd - colorBegin, TextMarkerType.SolidBlock);
                colorMarker.ToolTip = "<body bgcolor=\"#" + color + "\">" + color;
                editor.Document.MarkerStrategy.AddMarker(colorMarker);
                 * */
            /*
                DeclarationViewWindow toolTip;
                toolTip = new DeclarationViewWindow(editor.ActiveTextAreaControl.TextArea.FindForm());
                Point p = e.Location;
                Point cp = editor.ActiveTextAreaControl.TextArea.PointToClient(p);
                toolTip.Owner = editor.ActiveTextAreaControl.TextArea.FindForm();
                toolTip.Location = cp;
                toolTip.Description = "adsfsdfsdfdsfsdfasdfsad";
                toolTip.HideOnClick = true;
                toolTip.Show();
            }
             * */
        }

        void TextArea_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             DeclarationViewWindow toolTip;
             toolTip = new DeclarationViewWindow(editor.ActiveTextAreaControl.TextArea.FindForm());
                 Point p = Control.MousePosition;
                 Point cp = editor.ActiveTextAreaControl.TextArea.PointToClient(p);
                 p.Y = (p.Y - cp.Y) + (1 * editor.ActiveTextAreaControl.Font.Height) - editor.ActiveTextAreaControl.TextArea.VirtualTop.Y;
                 toolTip.Owner = editor.ActiveTextAreaControl.TextArea.FindForm();
                 toolTip.Location = p;
                 toolTip.Description = "adsfsdfsdfdsfsdfasdfsad";
                 toolTip.HideOnClick = true;
                 toolTip.Show();
             
             if (e.KeyCode == Keys.F3)
             {
                 txtMarker = new TextMarker(editor.Caret.Offset, 1, TextMarkerType.QuickMark);
                 txtMarker.ToolTip = "function <b>test</b>()<br>-- Die Funktion Test";
                 editor.Document.MarkerStrategy.AddMarker(txtMarker);
                 editor.Refresh();
             }
             else if (e.KeyCode == Keys.F4)
             {

                 LineSegment line = editor.Document.GetLineSegment(editor.Caret.Line);

                 /*
                 string color = TextUtilities.GetWordAt(editor.Document, editor.Caret.Offset);
                 int colorBegin = TextUtilities.FindWordStart(editor.Document, editor.Caret.Offset);
                 int colorEnd = TextUtilities.FindWordEnd(editor.Document, editor.Caret.Offset);
                 TextMarker colorMarker = new TextMarker(colorBegin, colorEnd - colorBegin, TextMarkerType.SolidBlock);
                 colorMarker.ToolTip = "sdsadasdasds";
                 editor.Document.MarkerStrategy.AddMarker(colorMarker);
                  * 
                
             }*/
        }


        public void SetBinding()
        {
            if (!(editor.Document.FoldingManager.FoldingStrategy is PHPFoldingStrategy))
                editor.Document.FoldingManager.FoldingStrategy = phpFolding;

            if (!(editor.Document.FormattingStrategy is PHPFormattingStrategy))
                editor.Document.FormattingStrategy = phpFormatting;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using Gamodo.Tabs.EditorTab.LanguageBindings;
using ICSharpCode.TextEditor.Actions;
using System.Diagnostics;
using System.Collections;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    class HTMLFormattingStrategy: DefaultFormattingStrategy
    {
        #region private functions
        bool IsInsideString(TextArea textArea, LineSegment curLine, int cursorOffset)
        {
            // scan cur line if it is inside a string
            bool insideString = false;
            char stringstart = ' ';
            char c = ' ';
            char lastchar;

            for (int i = curLine.Offset; i < cursorOffset; ++i)
            {
                lastchar = c;
                c = textArea.Document.GetCharAt(i);
                if (insideString)
                {
                    if (c == stringstart)
                    {
                        insideString = false;
                    }
                    else if (c == '\\')
                    {
                        ++i; // skip escaped character
                    }
                }
                else if (c == '"')
                {
                    stringstart = c;
                    insideString = true;
                }
            }

            return insideString;
        }

        #endregion

        #region FormatLine

        public override void FormatLine(TextArea textArea, int lineNr, int cursorOffset, char ch) // used for comment tag formater/inserter
        {
            textArea.Document.UndoStack.StartUndoGroup();
            FormatLineInternal(textArea, lineNr, cursorOffset, ch);
            textArea.Document.UndoStack.EndUndoGroup();
        }

        void FormatLineInternal(TextArea textArea, int lineNr, int cursorOffset, char ch)
        {
            LineSegment curLine = textArea.Document.GetLineSegment(lineNr);
            LineSegment lineAbove = lineNr > 0 ? textArea.Document.GetLineSegment(lineNr - 1) : null;
            string terminator = textArea.TextEditorProperties.LineTerminator;
            
            //// local string for curLine segment
            string curLineText = "";
            switch (ch)
            {
                case '>':
                    if (!IsInsideString(textArea, curLine, cursorOffset))
                    {
                        curLineText = textArea.Document.GetText(curLine);
                        int column = textArea.Caret.Offset - curLine.Offset;
                        int index = Math.Min(column - 1, curLineText.Length - 1);

                        while (index >= 0 && curLineText[index] != '<')
                        {
                            
                            --index;
                            if (curLineText[index] == '/')
                                return; // the tag was an end tag or already
                        }

                        if (index >= 0)
                        {
                            StringBuilder commentBuilder = new StringBuilder("");
                            for (int i = index; i < curLineText.Length && i < column && !Char.IsWhiteSpace(curLineText[i]); ++i)
                            {
                                commentBuilder.Append(curLineText[i]);
                            }
                            string tag = commentBuilder.ToString().Trim();
                            if (!tag.EndsWith(">"))
                            {
                                tag += ">";
                            }
                            if ((!tag.StartsWith("/")) && !(tag.StartsWith("<!")))
                            {
                                textArea.Document.Insert(textArea.Caret.Offset, "</" + tag.Substring(1));
                            }
                        }
                    }
                    break;
                case '\n':
                    return;
            }
        }
        #endregion
    }
}

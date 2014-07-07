using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using System.Resources;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class PHPFoldingStrategy : IFoldingStrategy
    {
        
        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>	
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            List<FoldMarker> list = new List<FoldMarker>();
            Stack<WordPos> startLines = new Stack<WordPos>();
            Stack<int> startBlocks = new Stack<int>();
            Stack<int> startTags = new Stack<int>();
            Stack<WordPos> startCom = new Stack<WordPos>();
            Stack<WordPos> startPHP = new Stack<WordPos>();
            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i <= document.TotalNumberOfLines - 1; i++)
            {
                LineSegment seg = document.GetLineSegment(i);
                TextWord lastWord = null;
                TextWord nextWord = default(TextWord);
                for (int p = 0; p <= seg.Words.Count - 1; p++)
                {
                    TextWord text = seg.Words[p];
                    if (p < seg.Words.Count - 1)
                    {
                        if (((TextWord)seg.Words[p + 1]).IsWhiteSpace)
                        {
                            if (p < seg.Words.Count - 2)
                            {
                                nextWord = seg.Words[p + 2];
                            }
                            else
                            {
                                nextWord = text;
                            }
                        }
                        else
                        {
                            nextWord = seg.Words[p + 1];
                        }
                    }
                    else
                    {
                        nextWord = text;
                    }
                    // REGION HANDLER
                    if (lastWord != null)
                    {
                        if (lastWord.Word == "#")
                        {
                            if (string.Compare(text.Word, "end", true) == 0 & string.Compare(nextWord.Word, "region", true) == 0)
                            {
                                p = p + 1;
                                if (startLines.Count > 0)
                                {
                                    WordPos pos = startLines.Pop();
                                    if (pos.Line < i)
                                    {
                                        list.Add(new FoldMarker(document, pos.Line, pos.Col - 1, i, text.Offset + text.Length + 7, FoldType.Region, "Region : " + pos.Caption));
                                    }
                                }
                            }
                            else if (string.Compare(text.Word, "endregion", true) == 0)
                            {
                                if (startLines.Count > 0)
                                {
                                    WordPos pos = startLines.Pop();
                                    if (pos.Line < i)
                                    {
                                        list.Add(new FoldMarker(document, pos.Line, pos.Col - 1, i, text.Offset + text.Length, FoldType.Region, "Region : " + pos.Caption));
                                    }
                                }
                            }
                            else if (string.Compare(text.Word, "region", true) == 0)
                            {
                                string caption = "";
                                for (int c = p + 1; c <= seg.Words.Count - 1; c++)
                                {
                                    if (seg.Words[c].IsWhiteSpace)
                                    {
                                        caption += " ";
                                    }
                                    else
                                    {
                                        caption += seg.Words[c].Word;
                                    }
                                }
                                caption = caption.Replace("\"", "").Trim();
                                startLines.Push(new WordPos(i, ref text, caption));
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                    // PHPDoc handler
                    if (text.Word == "/**")
                    {
                        startCom.Push(new WordPos(i, ref text));
                    }

                    // COMMENTS HANDLER
                    if (text.Word == "/*")
                    {
                        startCom.Push(new WordPos(i, ref text));
                    }
                    if (text.Word == "*/")
                    {
                        if (startCom.Count > 0)
                        {
                            WordPos pos = startCom.Pop();
                            if (pos.Line < i)
                            {
                                list.Add(new FoldMarker(
                                    document, 
                                    pos.Line, 
                                    pos.Col, 
                                    i, 
                                    text.Offset + 2,
                                    FoldType.Region, 
                                    String.Format("/* {0} */", MainForm.rm.GetString("FoldTextComment"))
                                    ));
                            }
                        }
                    }
                    if (!text.HasDefaultColor)
                    {
                        if ((text.Word == "<?php") || (text.Word == "<?"))
                        {
                            startPHP.Push(new WordPos(i, ref text));
                            //startTags.Push(i);
                        }
                        if (text.Word == "?>")
                        {
                            if (startPHP.Count > 0)
                            {
                                WordPos pos = startPHP.Pop();
                                //int start = startTags.Pop();
                                if (pos.Line < i)
                                {
                                    list.Add(new FoldMarker(document, pos.Line, pos.Col, i, text.Offset + 2, FoldType.Region, "<? PHP Script ?>"));
                                }
                            }
                        }
                    }
                    if (!text.HasDefaultColor)
                    {
                        if (text.Word == "{")
                        {
                            startBlocks.Push(i);
                        }
                        if (text.Word == "}")
                        {
                            if (startBlocks.Count > 0)
                            {
                                int start = startBlocks.Pop();
                                if (start < i - 1)
                                {
                                    list.Add(new FoldMarker(
                                        document,
                                        start, 
                                        document.GetLineSegment(start).Length - 1, 
                                        i, 
                                        text.Offset + text.Length
                                        ));
                                }
                            }
                        }
                    }
                    lastWord = text;
                }
            }
            if (startLines.Count > 0)
            {
                WordPos start = startLines.Pop();
                if (start.Line < document.TotalNumberOfLines - 1)
                {
                    list.Add(new FoldMarker(
                        document, 
                        start.Line, 
                        start.Col - 1, 
                        document.TotalNumberOfLines - 1, 
                        0, 
                        FoldType.Region, 
                        String.Format("{0} : ",MainForm.rm.GetString("FoldTextUnfinishedRegion")) + start.Caption
                        ));
                }
            }
            //If startBlocks.Count > 0 Then
            //	Dim start As Integer = startBlocks.Pop()			
            //	if start < document.TotalNumberOfLines - 1 then
            //		list.Add(New FoldMarker(document, start, document.GetLineSegment(start).Length, document.TotalNumberOfLines - 1, 0))		
            //	end if
            //End If
            return list;
        }
        private static T InlineAssignHelper<T>(ref T target, T value)
        {
            target = value;
            return value;
        }

        public class WordPos
        {
            public int Line;
            public int Col;
            public int Length;
            public string Caption;
            public WordPos(int Line, ref TextWord Word, string Caption = "")
            {
                this.Line = Line;
                this.Col = Word.Offset;
                this.Length = Word.Length;
                this.Caption = Caption;
            }
        }

    }
}

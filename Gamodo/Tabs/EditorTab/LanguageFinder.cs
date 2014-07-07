using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using Gamodo.Editor;

namespace Gamodo.Tabs.EditorTab
{
    public enum DocumentLanguage
	{
        NULL = -1,
        PHP = 0,
        HTML = 1,
        CSS = 2,
        JavaScript = 3,
	};

    public class LanguageFinder
    {
        public static DocumentLanguage GetLanguageFromSegment(LineSegment ls, EditorControl edit)
        {
            if (edit.Document.HighlightingStrategy.Name.Contains("HTML") || edit.Document.HighlightingStrategy.Name.Contains("PHP"))
            {
                if ((ls.HighlightSpanStack != null) && (ls.HighlightSpanStack.First() != null) && (ls.HighlightSpanStack.First().Rule != null))
                {
                    if (ls.HighlightSpanStack.First().Rule.Contains("PHP"))
                        return DocumentLanguage.PHP;
                    else if (ls.HighlightSpanStack.First().Rule.Contains("HTML"))
                        return DocumentLanguage.HTML;
                    else if (ls.HighlightSpanStack.First().Rule.Contains("CSS"))
                        return DocumentLanguage.CSS;
                    else if (ls.HighlightSpanStack.First().Rule.Contains("JavaScript"))
                        return DocumentLanguage.JavaScript;
                }
            }
            else if (edit.Document.HighlightingStrategy.Name.Contains("JavaScript"))
                return DocumentLanguage.JavaScript;
            else if (edit.Document.HighlightingStrategy.Name.Contains("Cascading Style Sheet"))
                return DocumentLanguage.CSS;
            return DocumentLanguage.HTML;
        }
    }
}

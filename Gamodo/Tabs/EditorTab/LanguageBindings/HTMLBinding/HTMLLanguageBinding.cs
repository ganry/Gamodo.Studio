using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Tabs.Interface;
using ICSharpCode.TextEditor.Document;
using Gamodo.Tabs.EditorTab.LanguageBindings;
using Gamodo.Editor;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class HTMLLanguageBinding: IDisposable
    {
        IFormattingStrategy htmlFormatting = null;
        IFoldingStrategy htmlFolding = null;
        EditorControl editor;
       
        public HTMLLanguageBinding(EditorControl edit)
        {
            editor = edit;
            htmlFolding = new PHPFoldingStrategy();
            htmlFormatting = new HTMLFormattingStrategy();
            
        }

        public void SetBinding()
        {
            if (!(editor.Document.FoldingManager.FoldingStrategy is PHPFoldingStrategy))
                editor.Document.FoldingManager.FoldingStrategy = htmlFolding;

            if (!(editor.Document.FormattingStrategy is HTMLFormattingStrategy))
                editor.Document.FormattingStrategy = htmlFormatting;
        }

        public void Dispose()
        {
            htmlFolding = null;
            htmlFormatting = null;
        }
    }
}

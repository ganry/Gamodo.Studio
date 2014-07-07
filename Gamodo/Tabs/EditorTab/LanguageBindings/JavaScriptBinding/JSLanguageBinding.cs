using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Editor;

using ICSharpCode.TextEditor.Document;
using Gamodo.Tabs.EditorTab.LanguageBindings;

namespace Gamodo.Tabs.EditorTab.LanguageBindings
{
    public class JSLanguageBinding : IDisposable
    {
        IFormattingStrategy jsFormatting = new DefaultFormattingStrategy(); 
        IFoldingStrategy jsFolding = null;
        EditorControl editor;

        public JSLanguageBinding(EditorControl edit)
        {
            editor = edit;
            jsFolding = new PHPFoldingStrategy();
        }

        public void SetBinding()
        {
            if (!(editor.Document.FoldingManager.FoldingStrategy is PHPFoldingStrategy))
                editor.Document.FoldingManager.FoldingStrategy = jsFolding;

            if (!(editor.Document.FormattingStrategy is DefaultFormattingStrategy))
                editor.Document.FormattingStrategy = jsFormatting;
        }

        public void Dispose()
        {
            jsFolding = null;
            jsFormatting = null;
        }
    }
}

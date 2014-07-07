using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using System.Drawing;
using Gamodo.Editor;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    public class CopyMarker: ExpressionMarker
    {
        public ExpressionMarker Parent;

        public CopyMarker(int beginOffset, int length, ExpressionMarker parent)
        {
            markerColor = Color.Black;
            base.MarkerType = TextMarkerType.CopyMarker;
            Expression = new QuickletMarker(beginOffset, length, MarkerType, markerColor);
            Begin = new QuickletMarker(beginOffset - 1, 1, TextMarkerType.Invisible, System.Drawing.Color.Aqua);
            End = new QuickletMarker(beginOffset + length, 1, TextMarkerType.Invisible, System.Drawing.Color.Aqua);
            VariableName = "";
            Parent = parent;
        }

    }
}

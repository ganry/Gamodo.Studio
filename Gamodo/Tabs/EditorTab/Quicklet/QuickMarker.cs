using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using System.Drawing;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    public class QuickletMarker: TextMarker
    {
        public QuickletMarker(int offset, int length, TextMarkerType textMarkerType, Color color, string toolTip = "") :
            base(offset, length, textMarkerType, color)
        {
            if (toolTip != "")
                this.ToolTip = toolTip;
        }
    }
}

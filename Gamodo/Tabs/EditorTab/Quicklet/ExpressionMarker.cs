using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Document;
using Gamodo.Editor;
using System.Drawing;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    public class ExpressionMarker
    {
        #region private fields
        QuickletMarker begin = null;
        QuickletMarker end = null;
        QuickletMarker expression = null;
        protected TextMarkerType MarkerType = TextMarkerType.SolidBlock;
        #endregion

        #region public fields & properties
        public string VariableName = null;
        public bool HasChilds = false;

        public Color markerColor = Color.FromArgb(255, 255, 231, 160);

        public QuickletMarker Begin
        {
            get { return begin; }
            set { begin = value; }
        }

        public QuickletMarker End
        {
            get { return end; }
            set { end = value; }
        }

        public QuickletMarker Expression
        {
            get { return expression; }
            set { expression = value; }
        }
        #endregion

        #region ctor
        public ExpressionMarker()
        {
        }

        public ExpressionMarker(int beginOffset, int length, string varName)
        {
            expression = new QuickletMarker(beginOffset, length, MarkerType, markerColor, MainForm.rm.GetString("expressionTooltip"));
            begin = new QuickletMarker(beginOffset - 1, 1, TextMarkerType.Invisible, System.Drawing.Color.Blue, "");
            end = new QuickletMarker(beginOffset + length, 1, TextMarkerType.Invisible, System.Drawing.Color.Blue, "");

            VariableName = varName;
        }
        #endregion

        #region Expression handling: Add, Remove, Replace etc.
        public void AddExpressionToEditor(EditorControl editor)
        {
            editor.Document.MarkerStrategy.AddMarker(begin);
            editor.Document.MarkerStrategy.AddMarker(expression);
            editor.Document.MarkerStrategy.AddMarker(end);
        }

        public virtual void ReplaceExpressionMarker(EditorControl editor)
        {
            QuickletMarker newExpression = new QuickletMarker(Begin.Offset + 1, End.Offset - (Begin.Offset + 1), MarkerType, markerColor, MainForm.rm.GetString("expressionTooltip"));
            RemoveExpressionFromEditor(editor);
            Expression = newExpression;
            AddExpressionToEditor(editor);
        }

        public void RemoveExpressionFromEditor(EditorControl editor)
        {
            editor.Document.MarkerStrategy.RemoveMarker(begin);
            editor.Document.MarkerStrategy.RemoveMarker(expression);
            editor.Document.MarkerStrategy.RemoveMarker(end);
        }

        public bool IsBetweenExpression(int offset)
        {
            if (this is CopyMarker)
                return false;
            if (offset < Expression.Offset)
            {
                return false;
            }
            else if ((offset > end.Offset))
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}

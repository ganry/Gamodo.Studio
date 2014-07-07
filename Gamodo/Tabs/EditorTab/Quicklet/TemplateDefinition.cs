using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gamodo.Editor;
using Gamodo.Tabs.EditorTab.Tools;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Drawing;

namespace Gamodo.Tabs.EditorTab.Quicklet
{
    #region struct Variable
    public struct Variable
    {
        public string Name;
        public string Value;
        public string Tooltip;

        public Variable(string name, string value, string toolTip)
        {
            Name = name;
            Value = value;
            Tooltip = toolTip;
        }
    }
    #endregion

    public class TemplateDefinition
    {
        #region Variables/Properties
        private List<ExpressionMarker> list = new List<ExpressionMarker>();
        List<Variable> variableList = null;
        private string shortcut = null;
        private string template = null;
        private string cleanTemplate = null;
        private int variablesInTemplate = -1;

        public QuickletMarker EndMarker;
        public DocumentLanguage DocLang;

        public string Shortcut
        {
            get { return shortcut; }
        }

        public List<ExpressionMarker> List
        {
            get { return list; }
        }
        #endregion

        public TemplateDefinition(string shortCut, string templateText, int variablesInText, DocumentLanguage docLang)
        {
            shortcut = shortCut;
            template = templateText;
            DocLang = docLang;

            variablesInTemplate = variablesInText;
            variableList = new List<Variable>();
        }

        #region Delegate to Remove QuickMarkers
        private static bool FindQuickMarkers(TextMarker textMarker)
        {
            if (textMarker is QuickletMarker)
                return true;
            else
                return false;
        }
        #endregion

        #region private methods
        private Variable getVariableByName(string name)
        {
            foreach (var item in variableList)
            {
                if (item.Name == name)
                    return item;
            }
            return new Variable();
        }

        private string formatTemplate(string template, string indent)
        {
            return template.Replace("\n", "\n" + indent);
        }

        private ExpressionMarker getParentMarker(string varName)
        {
            foreach (var item in list)
            {
                if (item.VariableName == varName)
                {
                    item.HasChilds = true;
                    return item;
                }
            }
            return null;
        }


        private void GenerateExpressions(string formattedTemplate, int shortcutBeginOffset)
        {
            cleanTemplate = formattedTemplate;
            list.Clear();
            int pos = 0;
            for (int i = 0; i < variablesInTemplate + 1; i++)
            {
                int begin = cleanTemplate.IndexOf("$", pos);
                int end = cleanTemplate.IndexOf("$", begin + 1);
                end += 1;

                string varName = cleanTemplate.Substring(begin, end - begin);
                if (varName == "$end$")
                {
                    EndMarker = new QuickletMarker(begin + shortcutBeginOffset, 1, TextMarkerType.QuickMark, Color.Red);
                    cleanTemplate = cleanTemplate.Remove(begin, "$end$".Length);
                }

                else
                {
                    Variable var = getVariableByName(varName);
                    if (var.Name != "")
                    {
                        cleanTemplate = cleanTemplate.Remove(begin, var.Name.Length);
                        cleanTemplate = cleanTemplate.Insert(begin, var.Value);

                        pos = begin + var.Value.Length;

                        ExpressionMarker parent = getParentMarker(var.Name);
                        if (parent == null)
                            list.Add(new ExpressionMarker(begin + shortcutBeginOffset, var.Value.Length, var.Name));
                        else
                            list.Add(new CopyMarker(begin + shortcutBeginOffset, var.Value.Length, parent));
                    }
                }
            }
        }
        #endregion

        #region expression selection/go to quickmark
        public void SelectExpression(int number, EditorControl editor)
        {

            if (list.Count > 0)
            {
                TextLocation beginSelection = editor.Document.OffsetToPosition(list[number].Expression.Offset);
                TextLocation endSelection = editor.Document.OffsetToPosition(list[number].End.Offset);
                editor.ActiveTextAreaControl.SelectionManager.SetSelection(beginSelection, endSelection);

                editor.Caret.Position = endSelection;
            }

        }

        public void GoToEndMarker(EditorControl editor)
        {
            editor.ActiveTextAreaControl.SelectionManager.ClearSelection();
            if (EndMarker != null)
                editor.Caret.Position = editor.Document.OffsetToPosition(EndMarker.Offset);
            ClearMarkers(editor);
        }

        public bool SwitchBetweenExpressions(EditorControl editor)
        {
            ExpressionMarker expression = GetExpressionMarkerAtPos(editor.Caret.Offset, editor);
            if (expression != null)
            {
                if (!(list.Count() == 1))
                {
                    int index = list.IndexOf(expression);
                    if (index < list.Count())
                    {
                        if (list[index] == list.Last())
                        {
                            SelectExpression(0, editor);
                            return true;
                        }
                        else
                        {
                            if (list[index + 1] is CopyMarker)
                            {
                                for (int i = index + 1; i < list.Count; i++)
                                {
                                    if (list[i] == list.Last())
                                    {
                                        if (list[i] is CopyMarker)
                                        {
                                            SelectExpression(0, editor);
                                            return true;
                                        }
                                    }
                                    if (!(list[i] is CopyMarker))
                                    {
                                        SelectExpression(i, editor);
                                        return true;
                                    }
                                }
                            }
                            SelectExpression(index + 1, editor);
                            return true;
                        }
                    }
                }
            }
            return false;

        }
        #endregion

        public void AddVariable(string name, string value, string toolTip = "")
        {
            variableList.Add(new Variable(name, value, toolTip));
        }

        public ExpressionMarker GetExpressionMarkerAtPos(int offset, EditorControl editor)
        {
            if (list.Count > 0)
            {
                bool isInExpression = false;
                foreach (var item in list)
                {
                    isInExpression = item.IsBetweenExpression(editor.Caret.Offset);
                    if (isInExpression)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public List<CopyMarker> GetChildsOfParent(string varName)
        {
            ExpressionMarker parent = null;
            List <CopyMarker> copyMarkerList = new List<CopyMarker>();

            foreach (var item in list)
            {
                if (item.VariableName == varName)
                {
                    parent = item;
                    continue;
                }
                if (parent != null)
                {
                    if (item is CopyMarker)
                    {
                        if (parent == (item as CopyMarker).Parent)
                            copyMarkerList.Add((item as CopyMarker));
                    }
                }
            }
            return copyMarkerList;
        }

        public bool InsertTemplate(int shortcutBeginOffset, EditorControl editor)
        {
            bool result = true;
            string indentionLevel = editor.Document.FormattingStrategy.GetIndentationLevel(editor.ActiveTextAreaControl.TextArea, editor.Caret.Line);
            string formattedTemplate = formatTemplate(template, indentionLevel);

            GenerateExpressions(formattedTemplate, shortcutBeginOffset);
            editor.Document.Insert(editor.Caret.Offset, cleanTemplate);
            //TemplateLoader.InsertString(cleanTemplate, editor);
            
            if (EndMarker != null)
                editor.Document.MarkerStrategy.AddMarker(EndMarker);
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    item.AddExpressionToEditor(editor);
                }
                SelectExpression(0, editor);
            }
            else
            {
                GoToEndMarker(editor);
                result = false;
            }
                
            editor.Refresh();
            return result;
        }

        public void ClearMarkers(EditorControl editor)
        {
            editor.Document.MarkerStrategy.RemoveAll(FindQuickMarkers);
            list.Clear();
            editor.Refresh();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor.Gui.CompletionWindow;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using System.Drawing;

namespace CodeCompletition
{
    public class HtmlCompletionDataProvider : ICompletionDataProvider
    {
        public ImageList imageList;
        string preSelection = "";
        int defaultIndex = 0;
        List<HtmlTag> htmlTagList = null;

        public ImageList ImageList
        {
            get { return imageList; }
        }

        public string PreSelection
        {
            get { return preSelection; }
        }
        /// <summary>
        /// Gets the index of the element in the list that is chosen by default.
        /// </summary>
        public int DefaultIndex
        {
            get { return defaultIndex; }
        }

        public HtmlCompletionDataProvider()
        {
        }

        private HtmlTag GetHtmlTag(string tagName)
        {
            foreach (var item in htmlTagList)
            {
                if (item.Name == tagName)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Processes a keypress. Returns the action to be run with the key.
        /// </summary>
        public CompletionDataProviderKeyResult ProcessKey(char key)
        {
            Console.WriteLine("dsfsdds "+key);
            if (key == '<')
                return CompletionDataProviderKeyResult.BeforeStartKey;
            return CompletionDataProviderKeyResult.NormalKey;
        }


        /// <summary>
        /// Executes the insertion. The provider should set the caret position and then
        /// call data.InsertAction.
        /// </summary>
        public bool InsertAction(ICompletionData data, TextArea textArea, int insertionOffset, char key)
        {
            textArea.Caret.Position = textArea.Document.OffsetToPosition(insertionOffset);
            data.InsertAction(textArea, key);
            return true;
        }

        /// <summary>
        /// Generates the completion data. This method is called by the text editor control.
        /// </summary>
        public ICompletionData[] GenerateCompletionData(string fileName, TextArea textArea, char charTyped, string optional)
        {
            if (charTyped == '<')
            {
                if (htmlTagList == null)
                    htmlTagList = HtmlDefinitionReader.ReadDefinition(fileName);
                HtmlTagCompletionData[] data = new HtmlTagCompletionData[htmlTagList.Count];
                for (int i = 0; i < htmlTagList.Count; i++)
                {
                    data[i] = new HtmlTagCompletionData(htmlTagList[i]);
                }
                return data;
            }
            //else if (charTyped == '\0')
            else if (Char.IsLetter(charTyped) || Char.IsWhiteSpace(charTyped))
            {
                if ((optional != String.Empty) || (optional != ""))
                {
                    HtmlTag htmlTag = GetHtmlTag(optional);
                    if (htmlTag != null)
                    {
                        if (htmlTag.AttributeList != null)
                        {
                            if (htmlTag.AttributeList.Count > -1)
                            {
                                HtmlAttributeCompletionData[] data = new HtmlAttributeCompletionData[htmlTag.AttributeList.Count];
                                for (int i = 0; i < htmlTag.AttributeList.Count; i++)
                                {
                                    data[i] = new HtmlAttributeCompletionData(htmlTag.AttributeList[i], htmlTag.Name);
                                }
                                return data;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                        return null;
                }
            }
            return null;
        }
    }
}

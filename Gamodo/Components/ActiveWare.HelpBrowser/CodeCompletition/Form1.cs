using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ICSharpCode.TextEditor.Gui.CompletionWindow;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using System.Text.RegularExpressions;

namespace CodeCompletition
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            htmlDataProvider = new HtmlCompletionDataProvider();
            htmlDataProvider.imageList = imageList1;

            textEditorControl1.ActiveTextAreaControl.TextArea.KeyPress += new KeyPressEventHandler(TextArea_KeyPress);
        }






        private void button1_Click(object sender, EventArgs e)
        {
            textEditorControl1.SetHighlighting("HTML");
            Console.WriteLine(GetHTMLTag(textEditorControl1.ActiveTextAreaControl.TextArea));
            //HtmlDefinitionReader reader = new HtmlDefinitionReader();
            //reader.ReadDefinition("html4.01_def.xml");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Gamodo.Editor;
using Gamodo.Tabs;
using Gamodo.Tabs.EditorTab;
using Gamodo.Tabs.EditorTab.Tools;
using WeifenLuo.WinFormsUI.Docking;
using Gamodo.Tabs.Interface;
using System.Globalization;
using System.Threading;
using System.Resources;
using Gamodo.UserInterface.Office2007Renderer;
using Gamodo.UserInterface;
using HtmlHelp;
using System.IO;
using ActiveWare.CodeBrowser;
using ICSharpCode.TextEditor;
using Aga.Controls.Tree;
using ActiveWare.CSS;
using HtmlAgilityPack;
using Gamodo.Tabs.EditorTab.LanguageBindings;

using Gamodo.Tabs.StartPage;
using Gamodo.Config;

namespace Gamodo
{
    public partial class MainForm : Form
    {
        static internal ResourceManager rm = new ResourceManager("Gamodo.TextResource",
          typeof(MainForm).Assembly);
        internal static MainForm mainForm = null;
        internal HtmlHelpSystem phpHelp = null;

        internal HelpBrowserDock helpBrowserDock = new HelpBrowserDock();
        internal CodeBrowserDock codeBrowser = new CodeBrowserDock();

        private DeserializeDockContent m_deserializeDockContent;
        private ToolStripDropDown tsHistoryDropDown;

        #region Eigenschaften
        public int EditorTabCount
        {
            get
            {
                int count = 0;
                foreach (IDockContent item in dockPanel.Documents)
                {
                    if (item is EditorTab)
                    {
                        if ((item as EditorTab).TabText.IndexOf(rm.GetString("defaultFileName")) > -1)
                            count++;
                    }
                }
                return count;
            }
        }

        public IDockContent ActiveDock
        {
            get
            {
                if (dockPanel.ActiveContent != null)
                    return dockPanel.ActiveContent;
                return null;
            }
        }

        public DocumentBase ActiveDocumentTab
        {
            get
            {
                if (dockPanel.ActiveDocument != null)
                    if (dockPanel.ActiveDocument is DocumentBase)
                        return (dockPanel.ActiveDocument as DocumentBase);
                return null;
            }
        }

        #endregion

        public MainForm()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(ConfigClass.Config.GetSettingValue("language"));
            InitializeComponent();

            this.WindowState = (FormWindowState)int.Parse(ConfigClass.Config.GetSettingValue("WindowState"));

            mainForm = this;
            Application.Idle += new EventHandler(Application_Idle);
            this.Text = global.appNameVer;
            
            miNew.DropDown = tbNewWithDropDown.DropDown;
            CreateDialogFilter();

            #region skin choose
            if (ConfigClass.Config.GetSettingValue("skin") == "blue")
            {
                dockPanel.Skin.BlueSkin = true;
                ToolStripManager.Renderer = new Office2007Renderer(new Office2007BlueColorTable());
            }
            else
            {
                dockPanel.Skin.BlueSkin = false;
                ToolStripManager.Renderer = new Office2007Renderer(new Office2007SilverColorTable());
            }
            #endregion
            
            LoadHelp();
        }

        private void generateHistoryMenu()
        {
            if (tsHistoryDropDown == null)
                tsHistoryDropDown = new ToolStripDropDown();
            else
                tsHistoryDropDown.Items.Clear();

            int counter = 0;
            foreach (var item in ConfigClass.Config.HistoryFileList)
            {
                counter++;
                tsHistoryDropDown.Items.Add(counter+". "+item);
            }
            miOpen.DropDown = tsHistoryDropDown;
            tbOpen.DropDown = tsHistoryDropDown;
            
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(CodeBrowserDock).ToString())
                return codeBrowser;
            else if (persistString == typeof(HelpBrowserDock).ToString())
                return helpBrowserDock;
            else
            {
                // DummyDoc overrides GetPersistString to add extra information into persistString.
                // Any DockContent may override this value to add any needed information for deserialization.

                string[] parsedStrings = persistString.Split(new char[] { ',' });
                if (parsedStrings.Length != 2)
                    return null;

                if (parsedStrings[0] == typeof(EditorTab).ToString())
                {


                    EditorTab editorTab = null;
                    if (parsedStrings[1] != string.Empty)
                        editorTab = OpenFile(parsedStrings[1]);

                    return editorTab;
                }
                else if (parsedStrings[0] == typeof(HelpBrowserTab).ToString())
                {
                    HelpBrowserTab helpTab = null;
                    if (parsedStrings[1] != string.Empty)
                        helpTab = helpBrowserDock.ShowHelp(parsedStrings[1]);

                    return helpTab;
                }
                else
                    return null;
            }
        }

        private void LoadPHPHelp()
        {
            if (phpHelp == null)
            {
                string phpHelpFile = "help/" + Thread.CurrentThread.CurrentUICulture.Name + "/php_manual.chm";
                if (File.Exists(phpHelpFile))
                {
                    phpHelp = new HtmlHelpSystem();
                    phpHelp.OpenFile(phpHelpFile);
                }
            }
        }

        private void LoadHelp()
        {
            string selfHTML = "help/" + Thread.CurrentThread.CurrentUICulture.Name + "/selfhtml-8.1.2.chm";
            string mysqlHelpFile = "help/mysql_5.0_en.chm";

            LoadPHPHelp();
            if (phpHelp != null)
                helpBrowserDock.AddHelp("PHP 5.3", phpHelp);

            if (File.Exists(selfHTML))
                helpBrowserDock.AddHelp("SelfHTML", selfHTML);

            if (File.Exists(mysqlHelpFile))
                helpBrowserDock.AddHelp("Mysql 5.0", mysqlHelpFile);
        }

        private void CreateDialogFilter()
        {
            openFileDialog.Filter = rm.GetString("filterWeb") + "|" +
                rm.GetString("filterPHP") + "|" + rm.GetString("filterHTML") + "|" +
                rm.GetString("filterCSS") + "|" + rm.GetString("filterJS") + "|" +
                rm.GetString("filterAll");
            saveFileDialog.Filter = openFileDialog.Filter;
        }

        private bool CloseAll()
        {
            bool CanClose = true;
            for (int index = dockPanel.Contents.Count - 1; index >= 0; index--)
            {
                if (dockPanel.Contents[index] is DocumentBase)
                {
                    if (dockPanel.Contents[index] is ICloseAble)
                    {
                        DocumentBase content = (DocumentBase)dockPanel.Contents[index];
                        if ((content as ICloseAble).CanCloseTab())
                        {
                            content.Close();
                        }
                        else
                            CanClose = false;
                    }
                }
            }
            return CanClose;
        }

        #region MenuItems and ToolbarItems State
        void Application_Idle(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {

                //File
                tbSave.Enabled = (ActiveDocumentTab is ISaveAble) && (ActiveDocumentTab as ISaveAble).CanSave();
                tbSaveAll.Enabled = (ActiveDocumentTab != null);

                //Edit
                tbCut.Enabled = (ActiveDocumentTab is IEditCommands) && (ActiveDocumentTab as IEditCommands).CanCut();
                tbCopy.Enabled = (ActiveDocumentTab is IEditCommands) && (ActiveDocumentTab as IEditCommands).CanCopy();
                tbPaste.Enabled = (ActiveDocumentTab is IEditCommands) && (ActiveDocumentTab as IEditCommands).CanPaste();

                tbRedo.Enabled = (ActiveDocumentTab is IEditCommands) && (ActiveDocumentTab as IEditCommands).CanRedo();
                tbUndo.Enabled = (ActiveDocumentTab is IEditCommands) && (ActiveDocumentTab as IEditCommands).CanUndo();

                //Window
                tbCloseAll.Enabled = (ActiveDocumentTab != null);
                tbClose.Enabled = (ActiveDocumentTab is ICloseAble);
            }
        }

        //File State
        private void miFile_DropDownOpening(object sender, EventArgs e)
        {
            miSave.Enabled = tbSave.Enabled;
            miSaveAll.Enabled = tbSaveAll.Enabled;
            miSaveAs.Enabled = (ActiveDocumentTab != null) && (ActiveDocumentTab is ISaveAble);
        }

        //Edit State
        private void miEdit_DropDownOpening(object sender, EventArgs e)
        {
            miCut.Enabled = tbCut.Enabled;
            miCopy.Enabled = tbCopy.Enabled;
            miPaste.Enabled = tbPaste.Enabled;

            miRedo.Enabled = tbRedo.Enabled;
            miUndo.Enabled = tbUndo.Enabled;
        }

        //View
        private void miView_DropDownOpening(object sender, EventArgs e)
        {
            miCodeBrowser.Checked = codeBrowser == null || codeBrowser.IsDisposed ? false : true;
            miHelpBrowser.Checked = helpBrowserDock == null || helpBrowserDock.IsDisposed || !helpBrowserDock.Visible ? false : true;
        }

        //Window State
        private void miWindow_DropDownOpening(object sender, EventArgs e)
        {
            miCloseAll.Enabled = tbCloseAll.Enabled;
            miClose.Enabled = tbClose.Enabled;
        }
        #endregion

        #region Erstellen eines neuen Dokuments

        public EditorTab CreateNewDocumentWithTemplate(string TemplateFile)
        {
            int count = EditorTabCount + 1;
            EditorTab db = new EditorTab(this);
            db.CreateNewDocumentWithTemplate(rm.GetString("defaultFileName") + count, TemplateFile);
            return db;
        }

        private void tbNew_Click(object sender, EventArgs e)
        {
            int count = EditorTabCount + 1;
            EditorTab db = new EditorTab(this);
            db.CreateEmptyDocument(rm.GetString("defaultFileName") + count, DocumentLanguage.PHP);
            db.Show(dockPanel);
        }

        private void tbNewPHP_Click(object sender, EventArgs e)
        {
            EditorTab db = CreateNewDocumentWithTemplate(@"templates\templatePHP.php");
            db.Show(dockPanel);
        }

        private void tbNewHTML_Click(object sender, EventArgs e)
        {
            EditorTab db = CreateNewDocumentWithTemplate(@"templates\wizard\HTML\HTML401Trans.html");
            db.Show(dockPanel);
        }

        private void tbNewXHTML_Click(object sender, EventArgs e)
        {
            EditorTab db = CreateNewDocumentWithTemplate(@"templates\wizard\HTML\XHTML10Trans.html");
            db.Show(dockPanel);
        }

        private void tbNewJavaScript_Click(object sender, EventArgs e)
        {
            EditorTab db = CreateNewDocumentWithTemplate(@"templates\wizard\JavaScript\template.js");
            db.Show(dockPanel);
        }

        private void tbNewCSS_Click(object sender, EventArgs e)
        {
            EditorTab db = CreateNewDocumentWithTemplate(@"templates\wizard\CSS\CSS.css");
            db.Show(dockPanel);
        }

        //Wizard
        public void neuesDokumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string SelectedTemplate = null;
            using (NewDocument newDoc = new NewDocument())
            {
                newDoc.Owner = this;
                newDoc.ShowDialog();
                SelectedTemplate = newDoc.SelectedTemplate;
            }

            if (SelectedTemplate != null)
            {
                EditorTab db = CreateNewDocumentWithTemplate(SelectedTemplate);
                db.Show(dockPanel);
                db.Focus();
            }
        }

        #endregion

        #region File Menu

        public EditorTab OpenFile(string fileName)
        {
            bool result = false;
            EditorTab editorTab = null;
            foreach (var item in dockPanel.Documents)
            {
                EditorTab edit = item as EditorTab;
                if (edit != null)
                    if (edit.Title == Path.GetFileName(fileName))
                    {
                        editorTab = edit;
                        result = true;
                    }
            }

            if (File.Exists(fileName))
            {
                if (!result)
                {


                    editorTab = new EditorTab(this);
                    editorTab.OpenFile(fileName);
                    ConfigClass.Config.AddHistoryItem(fileName);
                }
                editorTab.Show(dockPanel);
                return editorTab;
            }
            else
            {
                MessageBox.Show(String.Format(MainForm.rm.GetString("fileDontExist"), Path.GetFileName(fileName)));
            }
            return null;
        }

        public void tbOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFile(openFileDialog.FileName);
            }
        }

        private void tbOpen_DropDownOpening(object sender, EventArgs e)
        {
            generateHistoryMenu();
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            ISaveAble activeTab = (ActiveDocumentTab as ISaveAble);
            if (activeTab != null)
                activeTab.Save();
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            ISaveAble activeTab = (ActiveDocumentTab as ISaveAble);
            if (activeTab != null)
                activeTab.SaveAs();
        }

        private void tbSaveAll_Click(object sender, EventArgs e)
        {
            foreach (IDockContent item in dockPanel.Documents)
            {
                if (item is ISaveAble)
                {
                    (item as ISaveAble).Save();
                }
            }
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Edit Menu
        private void tbCut_Click(object sender, EventArgs e)
        {
            (ActiveDocumentTab as IEditCommands).Cut();
        }

        private void tbCopy_Click(object sender, EventArgs e)
        {
            (ActiveDocumentTab as IEditCommands).Copy();
        }

        private void tbPaste_Click(object sender, EventArgs e)
        {
            (ActiveDocumentTab as IEditCommands).Paste();
        }

        private void tbUndo_Click(object sender, EventArgs e)
        {
            (ActiveDocumentTab as IEditCommands).Undo();
        }

        private void tbRedo_Click(object sender, EventArgs e)
        {
            (ActiveDocumentTab as IEditCommands).Redo();
        }
        #endregion

        #region View
        private void miHelpBrowser_Click(object sender, EventArgs e)
        {
            if (helpBrowserDock == null || helpBrowserDock.IsDisposed)
            {
                helpBrowserDock = new HelpBrowserDock();
                LoadHelp();
                helpBrowserDock.Show(dockPanel, DockState.DockBottom);
            }
            else if (!helpBrowserDock.Visible)
            {
                helpBrowserDock.Show(dockPanel, DockState.DockRight);
            }
            else
            {
                helpBrowserDock.Close();
            }
            
        }

        private void miCodeBrowser_Click(object sender, EventArgs e)
        {
            if (codeBrowser == null || codeBrowser.IsDisposed)
            {
                codeBrowser = new CodeBrowserDock();
                codeBrowser.Show(dockPanel, DockState.DockRight);
            }
            else if (!codeBrowser.Visible)
            {
                codeBrowser.Show(dockPanel, DockState.DockRight);
            }
            else
            {
                codeBrowser.Close();
            }
        }
        #endregion

        #region Window
        private void tbClose_Click(object sender, EventArgs e)
        {
            ICloseAble activeTab = (ActiveDocumentTab as ICloseAble);
            if (activeTab != null)
            {
                if (activeTab.CanCloseTab())
                    ActiveDocumentTab.Close();
            }
        }

        private void tbCloseAll_Click(object sender, EventArgs e)
        {
            CloseAll();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            dockPanel.SaveAsXml(configFile);
            ConfigClass.Config.SetSettingValue("WindowState", ((int)WindowState).ToString());

            ConfigClass.Config.SaveSettings();

            e.Cancel = !CloseAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);

            StartPageTab sp = new StartPageTab();
            sp.Show(dockPanel);
        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            EditorTab editTab = (ActiveDocumentTab as EditorTab);
            if (editTab != null)
            {
                if (editTab.languageBinding != null)
                    editTab.languageBinding.Parse();

                editTab.editor.BringToFront();
                editTab.editor.Focus();
            }
            else
                LanguageBinding.ClearAll();
        }

    }
}

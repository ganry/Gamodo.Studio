using ActiveWare;

namespace Gamodo.Tabs.EditorTab
{
    partial class EditorTab
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorTab));
            this.panel1 = new System.Windows.Forms.Panel();
            this.languageHelp = new DevExpress.XtraTab.XtraTabControl();
            this.tabHtml = new DevExpress.XtraTab.XtraTabPage();
            this.tbHtml = new System.Windows.Forms.ToolStrip();
            this.tbHtmlTable = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlForm = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlDiv = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlSpan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbHtmlP = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlH1 = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlH2 = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlH3 = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlB = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlI = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlU = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbHtmlLink = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlImage = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlBullet = new System.Windows.Forms.ToolStripButton();
            this.tbHtmlOl = new System.Windows.Forms.ToolStripButton();
            this.tabPHP = new DevExpress.XtraTab.XtraTabPage();
            this.tbPHP = new System.Windows.Forms.ToolStrip();
            this.tbPHPComment = new System.Windows.Forms.ToolStripButton();
            this.tbPHPFunction = new System.Windows.Forms.ToolStripButton();
            this.tbPHPClass = new System.Windows.Forms.ToolStripButton();
            this.tbPHPFor = new System.Windows.Forms.ToolStripButton();
            this.tbPHPIf = new System.Windows.Forms.ToolStripButton();
            this.tbPHPTry = new System.Windows.Forms.ToolStripButton();
            this.tbPHPSwitch = new System.Windows.Forms.ToolStripButton();
            this.tabCSS = new DevExpress.XtraTab.XtraTabPage();
            this.tbCSS = new System.Windows.Forms.ToolStrip();
            this.tbCSSColorPicker = new System.Windows.Forms.ToolStripButton();
            this.tbCSSColorChooser = new System.Windows.Forms.ToolStripButton();
            this.tabJS = new DevExpress.XtraTab.XtraTabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbJSId = new System.Windows.Forms.ToolStripButton();
            this.tbJSComment = new System.Windows.Forms.ToolStripButton();
            this.tbJSFunction = new System.Windows.Forms.ToolStripButton();
            this.tbJSFor = new System.Windows.Forms.ToolStripButton();
            this.tbJSIf = new System.Windows.Forms.ToolStripButton();
            this.tbJSTry = new System.Windows.Forms.ToolStripButton();
            this.tbJSSwitch = new System.Windows.Forms.ToolStripButton();
            this.colorDialogEx1 = new DrawingEx.ColorManagement.ColorDialogEx();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.languageHelp)).BeginInit();
            this.languageHelp.SuspendLayout();
            this.tabHtml.SuspendLayout();
            this.tbHtml.SuspendLayout();
            this.tabPHP.SuspendLayout();
            this.tbPHP.SuspendLayout();
            this.tabCSS.SuspendLayout();
            this.tbCSS.SuspendLayout();
            this.tabJS.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.languageHelp);
            this.panel1.Name = "panel1";
            // 
            // languageHelp
            // 
            resources.ApplyResources(this.languageHelp, "languageHelp");
            this.languageHelp.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("languageHelp.Appearance.BackColor")));
            this.languageHelp.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("languageHelp.Appearance.GradientMode")));
            this.languageHelp.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("languageHelp.Appearance.Image")));
            this.languageHelp.Appearance.Options.UseBackColor = true;
            this.languageHelp.LookAndFeel.SkinName = "Lilian";
            this.languageHelp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.languageHelp.Name = "languageHelp";
            this.languageHelp.SelectedTabPage = this.tabHtml;
            this.languageHelp.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabHtml,
            this.tabPHP,
            this.tabCSS,
            this.tabJS});
            // 
            // tabHtml
            // 
            resources.ApplyResources(this.tabHtml, "tabHtml");
            this.tabHtml.Controls.Add(this.tbHtml);
            this.tabHtml.Name = "tabHtml";
            // 
            // tbHtml
            // 
            resources.ApplyResources(this.tbHtml, "tbHtml");
            this.tbHtml.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbHtmlTable,
            this.tbHtmlForm,
            this.tbHtmlDiv,
            this.tbHtmlSpan,
            this.toolStripSeparator3,
            this.tbHtmlP,
            this.tbHtmlH1,
            this.tbHtmlH2,
            this.tbHtmlH3,
            this.tbHtmlB,
            this.tbHtmlI,
            this.tbHtmlU,
            this.toolStripSeparator4,
            this.tbHtmlLink,
            this.tbHtmlImage,
            this.tbHtmlBullet,
            this.tbHtmlOl});
            this.tbHtml.Name = "tbHtml";
            // 
            // tbHtmlTable
            // 
            resources.ApplyResources(this.tbHtmlTable, "tbHtmlTable");
            this.tbHtmlTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlTable.Image = global::Gamodo.Properties.Resources.table;
            this.tbHtmlTable.Name = "tbHtmlTable";
            this.tbHtmlTable.Click += new System.EventHandler(this.tbHTMLTable_Click);
            // 
            // tbHtmlForm
            // 
            resources.ApplyResources(this.tbHtmlForm, "tbHtmlForm");
            this.tbHtmlForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlForm.Image = global::Gamodo.Properties.Resources.form;
            this.tbHtmlForm.Name = "tbHtmlForm";
            this.tbHtmlForm.Click += new System.EventHandler(this.tbHTMLForm_Click);
            // 
            // tbHtmlDiv
            // 
            resources.ApplyResources(this.tbHtmlDiv, "tbHtmlDiv");
            this.tbHtmlDiv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlDiv.Image = global::Gamodo.Properties.Resources.div;
            this.tbHtmlDiv.Name = "tbHtmlDiv";
            this.tbHtmlDiv.Click += new System.EventHandler(this.tbHTMLDiv_Click);
            // 
            // tbHtmlSpan
            // 
            resources.ApplyResources(this.tbHtmlSpan, "tbHtmlSpan");
            this.tbHtmlSpan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlSpan.Image = global::Gamodo.Properties.Resources.span;
            this.tbHtmlSpan.Name = "tbHtmlSpan";
            this.tbHtmlSpan.Click += new System.EventHandler(this.tbHTMLSpan_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // tbHtmlP
            // 
            resources.ApplyResources(this.tbHtmlP, "tbHtmlP");
            this.tbHtmlP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlP.Image = global::Gamodo.Properties.Resources.edit_pilcrow;
            this.tbHtmlP.Name = "tbHtmlP";
            this.tbHtmlP.Click += new System.EventHandler(this.tbHTMLP_Click);
            // 
            // tbHtmlH1
            // 
            resources.ApplyResources(this.tbHtmlH1, "tbHtmlH1");
            this.tbHtmlH1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlH1.Image = global::Gamodo.Properties.Resources.text_heading_1;
            this.tbHtmlH1.Name = "tbHtmlH1";
            this.tbHtmlH1.Click += new System.EventHandler(this.tbHTMLH1_Click);
            // 
            // tbHtmlH2
            // 
            resources.ApplyResources(this.tbHtmlH2, "tbHtmlH2");
            this.tbHtmlH2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlH2.Image = global::Gamodo.Properties.Resources.text_heading_2;
            this.tbHtmlH2.Name = "tbHtmlH2";
            this.tbHtmlH2.Click += new System.EventHandler(this.tbHTMLH2_Click);
            // 
            // tbHtmlH3
            // 
            resources.ApplyResources(this.tbHtmlH3, "tbHtmlH3");
            this.tbHtmlH3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlH3.Image = global::Gamodo.Properties.Resources.text_heading_3;
            this.tbHtmlH3.Name = "tbHtmlH3";
            this.tbHtmlH3.Click += new System.EventHandler(this.tbHTMLH3_Click);
            // 
            // tbHtmlB
            // 
            resources.ApplyResources(this.tbHtmlB, "tbHtmlB");
            this.tbHtmlB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlB.Image = global::Gamodo.Properties.Resources.text_bold;
            this.tbHtmlB.Name = "tbHtmlB";
            this.tbHtmlB.Click += new System.EventHandler(this.tbHTMLB_Click);
            // 
            // tbHtmlI
            // 
            resources.ApplyResources(this.tbHtmlI, "tbHtmlI");
            this.tbHtmlI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlI.Image = global::Gamodo.Properties.Resources.text_italic;
            this.tbHtmlI.Name = "tbHtmlI";
            this.tbHtmlI.Click += new System.EventHandler(this.tbHTMLI_Click);
            // 
            // tbHtmlU
            // 
            resources.ApplyResources(this.tbHtmlU, "tbHtmlU");
            this.tbHtmlU.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlU.Image = global::Gamodo.Properties.Resources.text_underline;
            this.tbHtmlU.Name = "tbHtmlU";
            this.tbHtmlU.Click += new System.EventHandler(this.tbHTMLU_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // tbHtmlLink
            // 
            resources.ApplyResources(this.tbHtmlLink, "tbHtmlLink");
            this.tbHtmlLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlLink.Image = global::Gamodo.Properties.Resources.anchor;
            this.tbHtmlLink.Name = "tbHtmlLink";
            this.tbHtmlLink.Click += new System.EventHandler(this.tbHTMLLink_Click);
            // 
            // tbHtmlImage
            // 
            resources.ApplyResources(this.tbHtmlImage, "tbHtmlImage");
            this.tbHtmlImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlImage.Image = global::Gamodo.Properties.Resources.picture_add;
            this.tbHtmlImage.Name = "tbHtmlImage";
            this.tbHtmlImage.Click += new System.EventHandler(this.tbHTMLImage_Click);
            // 
            // tbHtmlBullet
            // 
            resources.ApplyResources(this.tbHtmlBullet, "tbHtmlBullet");
            this.tbHtmlBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlBullet.Image = global::Gamodo.Properties.Resources.text_list_bullets;
            this.tbHtmlBullet.Name = "tbHtmlBullet";
            this.tbHtmlBullet.Click += new System.EventHandler(this.tbHTMLBullet_Click);
            // 
            // tbHtmlOl
            // 
            resources.ApplyResources(this.tbHtmlOl, "tbHtmlOl");
            this.tbHtmlOl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHtmlOl.Image = global::Gamodo.Properties.Resources.text_list_numbers;
            this.tbHtmlOl.Name = "tbHtmlOl";
            this.tbHtmlOl.Click += new System.EventHandler(this.tbHTMLOL_Click);
            // 
            // tabPHP
            // 
            resources.ApplyResources(this.tabPHP, "tabPHP");
            this.tabPHP.Controls.Add(this.tbPHP);
            this.tabPHP.Name = "tabPHP";
            // 
            // tbPHP
            // 
            resources.ApplyResources(this.tbPHP, "tbPHP");
            this.tbPHP.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPHPComment,
            this.tbPHPFunction,
            this.tbPHPClass,
            this.tbPHPFor,
            this.tbPHPIf,
            this.tbPHPTry,
            this.tbPHPSwitch});
            this.tbPHP.Name = "tbPHP";
            // 
            // tbPHPComment
            // 
            resources.ApplyResources(this.tbPHPComment, "tbPHPComment");
            this.tbPHPComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPComment.Image = global::Gamodo.Properties.Resources.comment;
            this.tbPHPComment.Name = "tbPHPComment";
            this.tbPHPComment.Click += new System.EventHandler(this.tbPHPComment_Click);
            // 
            // tbPHPFunction
            // 
            resources.ApplyResources(this.tbPHPFunction, "tbPHPFunction");
            this.tbPHPFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPFunction.Image = global::Gamodo.Properties.Resources.function;
            this.tbPHPFunction.Name = "tbPHPFunction";
            this.tbPHPFunction.Click += new System.EventHandler(this.tbPHPFunction_Click);
            // 
            // tbPHPClass
            // 
            resources.ApplyResources(this.tbPHPClass, "tbPHPClass");
            this.tbPHPClass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPClass.Name = "tbPHPClass";
            this.tbPHPClass.Click += new System.EventHandler(this.tbPHPClass_Click);
            // 
            // tbPHPFor
            // 
            resources.ApplyResources(this.tbPHPFor, "tbPHPFor");
            this.tbPHPFor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPFor.Image = global::Gamodo.Properties.Resources.FOR;
            this.tbPHPFor.Name = "tbPHPFor";
            this.tbPHPFor.Click += new System.EventHandler(this.tbPHPFor_Click);
            // 
            // tbPHPIf
            // 
            resources.ApplyResources(this.tbPHPIf, "tbPHPIf");
            this.tbPHPIf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPIf.Image = global::Gamodo.Properties.Resources._if;
            this.tbPHPIf.Name = "tbPHPIf";
            this.tbPHPIf.Click += new System.EventHandler(this.tbPHPIf_Click);
            // 
            // tbPHPTry
            // 
            resources.ApplyResources(this.tbPHPTry, "tbPHPTry");
            this.tbPHPTry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPTry.Image = global::Gamodo.Properties.Resources._try;
            this.tbPHPTry.Name = "tbPHPTry";
            this.tbPHPTry.Click += new System.EventHandler(this.tbPHPTry_Click);
            // 
            // tbPHPSwitch
            // 
            resources.ApplyResources(this.tbPHPSwitch, "tbPHPSwitch");
            this.tbPHPSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPHPSwitch.Image = global::Gamodo.Properties.Resources._switch;
            this.tbPHPSwitch.Name = "tbPHPSwitch";
            this.tbPHPSwitch.Click += new System.EventHandler(this.tbPHPSwitch_Click);
            // 
            // tabCSS
            // 
            resources.ApplyResources(this.tabCSS, "tabCSS");
            this.tabCSS.Controls.Add(this.tbCSS);
            this.tabCSS.Name = "tabCSS";
            // 
            // tbCSS
            // 
            resources.ApplyResources(this.tbCSS, "tbCSS");
            this.tbCSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbCSSColorPicker,
            this.tbCSSColorChooser});
            this.tbCSS.Name = "tbCSS";
            // 
            // tbCSSColorPicker
            // 
            resources.ApplyResources(this.tbCSSColorPicker, "tbCSSColorPicker");
            this.tbCSSColorPicker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCSSColorPicker.Image = global::Gamodo.Properties.Resources.color_picker;
            this.tbCSSColorPicker.Name = "tbCSSColorPicker";
            this.tbCSSColorPicker.Click += new System.EventHandler(this.tbColorPicker_Click);
            // 
            // tbCSSColorChooser
            // 
            resources.ApplyResources(this.tbCSSColorChooser, "tbCSSColorChooser");
            this.tbCSSColorChooser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbCSSColorChooser.Name = "tbCSSColorChooser";
            this.tbCSSColorChooser.Click += new System.EventHandler(this.tbColorChooser_Click);
            // 
            // tabJS
            // 
            resources.ApplyResources(this.tabJS, "tabJS");
            this.tabJS.Controls.Add(this.toolStrip1);
            this.tabJS.Name = "tabJS";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbJSId,
            this.tbJSComment,
            this.tbJSFunction,
            this.tbJSFor,
            this.tbJSIf,
            this.tbJSTry,
            this.tbJSSwitch});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tbJSId
            // 
            resources.ApplyResources(this.tbJSId, "tbJSId");
            this.tbJSId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSId.Image = global::Gamodo.Properties.Resources.id;
            this.tbJSId.Name = "tbJSId";
            this.tbJSId.Click += new System.EventHandler(this.tbJSID_Click);
            // 
            // tbJSComment
            // 
            resources.ApplyResources(this.tbJSComment, "tbJSComment");
            this.tbJSComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSComment.Image = global::Gamodo.Properties.Resources.comment;
            this.tbJSComment.Name = "tbJSComment";
            this.tbJSComment.Click += new System.EventHandler(this.tbJSComment_Click);
            // 
            // tbJSFunction
            // 
            resources.ApplyResources(this.tbJSFunction, "tbJSFunction");
            this.tbJSFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSFunction.Image = global::Gamodo.Properties.Resources.function;
            this.tbJSFunction.Name = "tbJSFunction";
            this.tbJSFunction.Click += new System.EventHandler(this.tbJSFunction_Click);
            // 
            // tbJSFor
            // 
            resources.ApplyResources(this.tbJSFor, "tbJSFor");
            this.tbJSFor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSFor.Image = global::Gamodo.Properties.Resources.FOR;
            this.tbJSFor.Name = "tbJSFor";
            this.tbJSFor.Click += new System.EventHandler(this.tbJSFor_Click);
            // 
            // tbJSIf
            // 
            resources.ApplyResources(this.tbJSIf, "tbJSIf");
            this.tbJSIf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSIf.Image = global::Gamodo.Properties.Resources._if;
            this.tbJSIf.Name = "tbJSIf";
            this.tbJSIf.Click += new System.EventHandler(this.tbJSIF_Click);
            // 
            // tbJSTry
            // 
            resources.ApplyResources(this.tbJSTry, "tbJSTry");
            this.tbJSTry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSTry.Image = global::Gamodo.Properties.Resources._try;
            this.tbJSTry.Name = "tbJSTry";
            this.tbJSTry.Click += new System.EventHandler(this.tbJSTry_Click);
            // 
            // tbJSSwitch
            // 
            resources.ApplyResources(this.tbJSSwitch, "tbJSSwitch");
            this.tbJSSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbJSSwitch.Image = global::Gamodo.Properties.Resources._switch;
            this.tbJSSwitch.Name = "tbJSSwitch";
            this.tbJSSwitch.Click += new System.EventHandler(this.tbJSSwitch_Click);
            // 
            // EditorTab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EditorTab";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorTab_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditorTab_FormClosed);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.languageHelp)).EndInit();
            this.languageHelp.ResumeLayout(false);
            this.tabHtml.ResumeLayout(false);
            this.tabHtml.PerformLayout();
            this.tbHtml.ResumeLayout(false);
            this.tbHtml.PerformLayout();
            this.tabPHP.ResumeLayout(false);
            this.tabPHP.PerformLayout();
            this.tbPHP.ResumeLayout(false);
            this.tbPHP.PerformLayout();
            this.tabCSS.ResumeLayout(false);
            this.tabCSS.PerformLayout();
            this.tbCSS.ResumeLayout(false);
            this.tbCSS.PerformLayout();
            this.tabJS.ResumeLayout(false);
            this.tabJS.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DrawingEx.ColorManagement.ColorDialogEx colorDialogEx1;
        private DevExpress.XtraTab.XtraTabPage tabHtml;
        private DevExpress.XtraTab.XtraTabPage tabPHP;
        private System.Windows.Forms.ToolStrip tbHtml;
        private System.Windows.Forms.ToolStripButton tbHtmlTable;
        private System.Windows.Forms.ToolStripButton tbHtmlForm;
        private System.Windows.Forms.ToolStripButton tbHtmlDiv;
        private System.Windows.Forms.ToolStripButton tbHtmlSpan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tbHtmlP;
        private System.Windows.Forms.ToolStripButton tbHtmlH1;
        private System.Windows.Forms.ToolStripButton tbHtmlH2;
        private System.Windows.Forms.ToolStripButton tbHtmlH3;
        private System.Windows.Forms.ToolStripButton tbHtmlB;
        private System.Windows.Forms.ToolStripButton tbHtmlI;
        private System.Windows.Forms.ToolStripButton tbHtmlU;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbHtmlLink;
        private System.Windows.Forms.ToolStripButton tbHtmlImage;
        private System.Windows.Forms.ToolStripButton tbHtmlBullet;
        private System.Windows.Forms.ToolStripButton tbHtmlOl;
        private System.Windows.Forms.ToolStrip tbPHP;
        private DevExpress.XtraTab.XtraTabPage tabCSS;
        private DevExpress.XtraTab.XtraTabPage tabJS;
        private System.Windows.Forms.ToolStripButton tbPHPComment;
        private System.Windows.Forms.ToolStripButton tbPHPFunction;
        private System.Windows.Forms.ToolStripButton tbPHPClass;
        private System.Windows.Forms.ToolStripButton tbPHPFor;
        private System.Windows.Forms.ToolStripButton tbPHPIf;
        private System.Windows.Forms.ToolStripButton tbPHPTry;
        private System.Windows.Forms.ToolStripButton tbPHPSwitch;
        private System.Windows.Forms.ToolStrip tbCSS;
        private System.Windows.Forms.ToolStripButton tbCSSColorPicker;
        private System.Windows.Forms.ToolStripButton tbCSSColorChooser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbJSId;
        private System.Windows.Forms.ToolStripButton tbJSComment;
        private System.Windows.Forms.ToolStripButton tbJSFunction;
        private System.Windows.Forms.ToolStripButton tbJSFor;
        private System.Windows.Forms.ToolStripButton tbJSIf;
        private System.Windows.Forms.ToolStripButton tbJSTry;
        private System.Windows.Forms.ToolStripButton tbJSSwitch;
        internal DevExpress.XtraTab.XtraTabControl languageHelp;

    }
}
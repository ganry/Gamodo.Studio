using System.Windows.Forms;
namespace Gamodo.Tabs.StartPage
{
    partial class StartPageTab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartPageTab));
            this.rightLogo = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.openedFiles = new DevExpress.XtraEditors.GroupControl();
            this.historyFiles = new System.Windows.Forms.TreeView();
            this.fileImageList = new System.Windows.Forms.ImageList(this.components);
            this.rssNewsGroup = new DevExpress.XtraEditors.GroupControl();
            this.rssNews = new System.Windows.Forms.WebBrowser();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstalledVersion = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rightLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openedFiles)).BeginInit();
            this.openedFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rssNewsGroup)).BeginInit();
            this.rssNewsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rightLogo
            // 
            resources.ApplyResources(this.rightLogo, "rightLogo");
            this.rightLogo.Name = "rightLogo";
            this.rightLogo.TabStop = false;
            // 
            // logo
            // 
            resources.ApplyResources(this.logo, "logo");
            this.logo.BackColor = System.Drawing.Color.Transparent;
            this.logo.Name = "logo";
            this.logo.TabStop = false;
            // 
            // openedFiles
            // 
            resources.ApplyResources(this.openedFiles, "openedFiles");
            this.openedFiles.Controls.Add(this.historyFiles);
            this.openedFiles.LookAndFeel.SkinName = "Blue";
            this.openedFiles.LookAndFeel.UseDefaultLookAndFeel = false;
            this.openedFiles.Name = "openedFiles";
            // 
            // historyFiles
            // 
            resources.ApplyResources(this.historyFiles, "historyFiles");
            this.historyFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyFiles.FullRowSelect = true;
            this.historyFiles.ImageList = this.fileImageList;
            this.historyFiles.Name = "historyFiles";
            this.historyFiles.ShowLines = false;
            this.historyFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.historyFiles_NodeMouseDoubleClick);
            // 
            // fileImageList
            // 
            this.fileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileImageList.ImageStream")));
            this.fileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileImageList.Images.SetKeyName(0, "php_16.png");
            this.fileImageList.Images.SetKeyName(1, "html_16.png");
            this.fileImageList.Images.SetKeyName(2, "CSS_16.png");
            this.fileImageList.Images.SetKeyName(3, "js_16.png");
            this.fileImageList.Images.SetKeyName(4, "others_16.png");
            // 
            // rssNewsGroup
            // 
            resources.ApplyResources(this.rssNewsGroup, "rssNewsGroup");
            this.rssNewsGroup.Controls.Add(this.rssNews);
            this.rssNewsGroup.LookAndFeel.SkinName = "Blue";
            this.rssNewsGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rssNewsGroup.Name = "rssNewsGroup";
            // 
            // rssNews
            // 
            resources.ApplyResources(this.rssNews, "rssNews");
            this.rssNews.AllowWebBrowserDrop = false;
            this.rssNews.IsWebBrowserContextMenuEnabled = false;
            this.rssNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.rssNews.Name = "rssNews";
            this.rssNews.ScriptErrorsSuppressed = true;
            // 
            // groupControl1
            // 
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblInstalledVersion);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.LookAndFeel.SkinName = "Blue";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblInstalledVersion
            // 
            resources.ApplyResources(this.lblInstalledVersion, "lblInstalledVersion");
            this.lblInstalledVersion.Name = "lblInstalledVersion";
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.DisabledImage")));
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl2.Appearance.GradientMode")));
            this.labelControl2.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.HoverImage")));
            this.labelControl2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.Image")));
            this.labelControl2.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("labelControl2.Appearance.PressedImage")));
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.AllowHtmlString = true;
            this.labelControl1.Name = "labelControl1";
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(205)))), ((int)(((byte)(242)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnOpen.Image = global::Gamodo.Properties.Resources.open2;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(205)))), ((int)(((byte)(242)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.btnNew.Image = global::Gamodo.Properties.Resources.newDocument;
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // StartPageTab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.rssNewsGroup);
            this.Controls.Add(this.openedFiles);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.rightLogo);
            this.Name = "StartPageTab";
            this.Load += new System.EventHandler(this.StartPageTab_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rightLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openedFiles)).EndInit();
            this.openedFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rssNewsGroup)).EndInit();
            this.rssNewsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox rightLogo;
        private System.Windows.Forms.PictureBox logo;
        private DevExpress.XtraEditors.GroupControl openedFiles;
        private DevExpress.XtraEditors.GroupControl rssNewsGroup;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private WebBrowser rssNews;
        private Button btnOpen;
        private Button btnNew;
        private TreeView historyFiles;
        private ImageList fileImageList;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Label lblInstalledVersion;
        private Label label1;

    }
}
namespace Gamodo
{
    partial class NewDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDocument));
            this.lblCategory = new System.Windows.Forms.Label();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.fileListView = new System.Windows.Forms.ListView();
            this.fileImageList = new System.Windows.Forms.ImageList(this.components);
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.lblTemplates = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            resources.ApplyResources(this.lblCategory, "lblCategory");
            this.lblCategory.Name = "lblCategory";
            // 
            // folderTreeView
            // 
            resources.ApplyResources(this.folderTreeView, "folderTreeView");
            this.folderTreeView.ImageList = this.imageList;
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderTreeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "close.bmp");
            this.imageList.Images.SetKeyName(1, "open.bmp");
            // 
            // fileListView
            // 
            resources.ApplyResources(this.fileListView, "fileListView");
            this.fileListView.LargeImageList = this.fileImageList;
            this.fileListView.Name = "fileListView";
            this.fileListView.UseCompatibleStateImageBehavior = false;
            // 
            // fileImageList
            // 
            this.fileImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileImageList.ImageStream")));
            this.fileImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileImageList.Images.SetKeyName(0, "php_32.png");
            this.fileImageList.Images.SetKeyName(1, "html_32.png");
            this.fileImageList.Images.SetKeyName(2, "CSS_32.png");
            this.fileImageList.Images.SetKeyName(3, "js_32.png");
            // 
            // filePathTextBox
            // 
            resources.ApplyResources(this.filePathTextBox, "filePathTextBox");
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            // 
            // lblTemplates
            // 
            resources.ApplyResources(this.lblTemplates, "lblTemplates");
            this.lblTemplates.Name = "lblTemplates";
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewDocument
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblTemplates);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.folderTreeView);
            this.Controls.Add(this.lblCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewDocument";
            this.Load += new System.EventHandler(this.NewDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.ImageList fileImageList;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label lblTemplates;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
    }
}
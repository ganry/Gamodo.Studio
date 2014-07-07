// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;
using System.Drawing;

using System.Windows.Forms;

using ICSharpCode.TextEditor.Util;

namespace ICSharpCode.TextEditor.Gui.CompletionWindow
{
    public interface IDeclarationViewWindow
    {
        string Description
        {
            get;
            set;
        }
        void ShowDeclarationViewWindow();
        void CloseDeclarationViewWindow();
    }

    public class DeclarationViewWindow : Form, IDeclarationViewWindow
    {
        string description = String.Empty;
        private DevExpress.XtraEditors.LabelControl htmlLabel;
        bool fixedWidth;

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                if (value == null && Visible)
                {
                    Visible = false;
                }
                else if (value != null)
                {
                    if (!Visible) ShowDeclarationViewWindow();
                    htmlLabel.Text = description;
                    htmlLabel.Width -= 149;
                    Refresh();
                    
                }
            }
        }

        public bool FixedWidth
        {
            get
            {
                return fixedWidth;
            }
            set
            {
                fixedWidth = value;
            }
        }

        public int GetRequiredLeftHandSideWidth(Point p)
        {
            if (description != null && description.Length > 0)
            {
                using (Graphics g = CreateGraphics())
                {
                    Size s = TipPainterTools.GetLeftHandSideDrawingSizeHelpTipFromCombinedDescription(this, g, Font, null, description, p);
                    return s.Width;
                }
            }
            return 0;
        }

        public bool HideOnClick;

        public DeclarationViewWindow(Form parent)
        {
            SetStyle(ControlStyles.Selectable, false);
            StartPosition = FormStartPosition.Manual;
            FormBorderStyle = FormBorderStyle.None;
            Owner = parent;
            ShowInTaskbar = false;
            //Size = new Size(200, 200);
            this.DoubleBuffered = true;
            this.BackColor = SystemColors.Info;
            //ResizeRedraw = true;
            CreateHtmlLabel();
            //this.Controls.Add(this.htmlLabel);
            base.CreateHandle();
        }


        private void CreateHtmlLabel()
        {
            
            this.htmlLabel = new DevExpress.XtraEditors.LabelControl();
            //this.htmlPanel.AutoScroll = false;
            //htmlPanel.VerticalScroll.Visible = false;
            this.HorizontalScroll.Visible = false;
            this.VerticalScroll.Visible = false;
            this.htmlLabel.Appearance.Image = ((System.Drawing.Image)(Resource1.chmHelp_kategorie));
            this.htmlLabel.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.htmlLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            //this.htmlLabel.AutoScrollMinSize = new System.Drawing.Size(40, 23);

            this.htmlLabel.AutoSize = true;
            this.htmlLabel.BackColor = System.Drawing.SystemColors.Info;
            this.htmlLabel.Location = new System.Drawing.Point(4, 3);
            htmlLabel.AllowHtmlString = true;
            this.htmlLabel.Name = "htmlPanel";
            this.htmlLabel.Size = new System.Drawing.Size(1, 1);
            this.htmlLabel.TabIndex = 0;

            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
             
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams p = base.CreateParams;
                AbstractCompletionWindow.AddShadowToWindow(p);
                return p;
            }
        }

        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (HideOnClick) Hide();
        }

        public void ShowDeclarationViewWindow()
        {
            Show();
        }

        public void CloseDeclarationViewWindow()
        {
            Close();
            Dispose();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {

           

            htmlLabel.Text = description;
            
            SizeF sizeF = pe.Graphics.MeasureString(description, new Font("Microsoft Sans Serif", 10,FontStyle.Regular, GraphicsUnit.Pixel));


                //HtmlRenderer.Render(pe.Graphics, description, (RectangleF)pe.ClipRectangle, false);
            sizeF.Width -= 50;
            this.Size = Size.Ceiling(sizeF);
            //Console.WriteLine(sizeF.Width);



            
            if (description != null && description.Length > 0) {
                if (fixedWidth) {
                    TipPainterTools.DrawFixedWidthHelpTipFromCombinedDescription(this, pe.Graphics, Font, null, description);
                } else {
                    TipPainterTools.DrawHelpTipFromCombinedDescription(this, pe.Graphics, Font, null, description);
                }
            }
            



        }

        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            //htmlPanel.Width -= 149;
            pe.Graphics.Clear(SystemColors.Info);
            pe.Graphics.DrawRectangle(BrushRegistry.GetPen(Color.FromArgb(103, 103, 103)), pe.ClipRectangle.X, pe.ClipRectangle.Y, pe.ClipRectangle.Width - 1, pe.ClipRectangle.Height-1);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DeclarationViewWindow
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeclarationViewWindow";
            
            this.ResumeLayout(false);

        }
    }
}

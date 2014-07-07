using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal abstract class InertButtonBase : Control
    {
        protected InertButtonBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public abstract Bitmap Image
        {
            get;
        }

        private bool m_isMouseOver = false;
        protected bool IsMouseOver
        {
            get { return m_isMouseOver; }
            private set
            {
                if (m_isMouseOver == value)
                    return;

                m_isMouseOver = value;
                Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get { return Resources.DockPane_Close.Size; }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool over = ClientRectangle.Contains(e.X, e.Y);
            if (IsMouseOver != over)
                IsMouseOver = over;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsMouseOver)
                IsMouseOver = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (IsMouseOver)
                IsMouseOver = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsMouseOver && Enabled)
            {
                using (Pen pen = new Pen(ForeColor))
                {
                    #region activeware
                    //TopBorder
                    Color startColorBorder = Color.FromArgb(255, 216, 202, 149);
                    Color endColorBorder = Color.FromArgb(255, 216, 194, 120);

                    Rectangle borderRect = ClientRectangle;
                    borderRect.Height = (borderRect.Height / 2) - 1;
                    using (LinearGradientBrush brush = new LinearGradientBrush(borderRect, startColorBorder, endColorBorder, LinearGradientMode.Vertical))
                    {

                        e.Graphics.FillRectangle(brush, borderRect);
                    }

                    //Bottom Border
                    Color startColorBottomBorder = Color.FromArgb(255, 216, 194, 120);
                    Color endColorBottomBorder = Color.FromArgb(255, 216, 202, 149);
                    Rectangle bottomBorderRect = borderRect;
                    bottomBorderRect.Y = borderRect.Height;
                    bottomBorderRect.Height += 2;
                    using (LinearGradientBrush brush = new LinearGradientBrush(bottomBorderRect, startColorBottomBorder, endColorBottomBorder, LinearGradientMode.Vertical))
                    {

                        e.Graphics.FillRectangle(brush, bottomBorderRect);
                    }

                    //TopBorderSecond
                    Color startColorBorderSecond = Color.FromArgb(255, 255, 255, 249);
                    Color endColorBorderSecond = Color.FromArgb(255, 255, 250, 231);
                    Rectangle borderRectSecond = borderRect;
                    borderRectSecond.Height = borderRect.Height;
                    borderRectSecond.Width -= 2;
                    borderRectSecond.Y += 1;
                    borderRectSecond.X += 1;
                    using (LinearGradientBrush brush = new LinearGradientBrush(borderRectSecond, startColorBorderSecond, endColorBorderSecond, LinearGradientMode.Vertical))
                    {
                        e.Graphics.FillRectangle(brush, borderRectSecond);
                    }


                    //Bottom Border Second
                    Color startColorBottomBorderSecond = Color.FromArgb(255, 255, 242, 200);
                    Color endColorBottomBorderSecond = Color.FromArgb(255, 255, 247, 185);
                    Rectangle bottomBorderRectSecond = borderRect;
                    bottomBorderRectSecond.Y = borderRect.Height + 1;
                    bottomBorderRectSecond.X += 1;
                    bottomBorderRectSecond.Width -= 2;

                    using (LinearGradientBrush brush = new LinearGradientBrush(bottomBorderRectSecond, startColorBottomBorderSecond, endColorBottomBorderSecond, LinearGradientMode.Vertical))
                    {

                        e.Graphics.FillRectangle(brush, bottomBorderRectSecond);
                    }



                    Color startColorFirst = Color.FromArgb(255, 255, 249, 218);
                    Color endColorFirst = Color.FromArgb(255, 255, 238, 177);
                    Rectangle rect = ClientRectangle;
                    rect.Height = (rect.Height / 2) - 1;
                    rect.Width -= 3;
                    rect.X += 2;
                    rect.Y += 2;
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColorFirst, endColorFirst, LinearGradientMode.Vertical))
                    {

                        e.Graphics.FillRectangle(brush, rect);
                    }


                    Color startColorSecond = Color.FromArgb(255, 255, 214, 107);
                    Color endColorSecond = Color.FromArgb(255, 255, 224, 135);
                    Rectangle rectSecond = rect;
                    rectSecond.Y = rect.Height + 1;
                    rectSecond.Height = rect.Height - 1;
                    using (LinearGradientBrush brush = new LinearGradientBrush(rectSecond, startColorSecond, endColorSecond, LinearGradientMode.Vertical))
                    {

                        e.Graphics.FillRectangle(brush, rectSecond);
                    }
                    #endregion

                    //e.Graphics.DrawRectangle(pen, Rectangle.Inflate(ClientRectangle, -1, -1));
                }
            }

            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                ColorMap[] colorMap = new ColorMap[2];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.FromArgb(0, 0, 0);
                colorMap[0].NewColor = ForeColor;
                colorMap[1] = new ColorMap();
                colorMap[1].OldColor = Image.GetPixel(0, 0);
                colorMap[1].NewColor = Color.Transparent;

                imageAttributes.SetRemapTable(colorMap);
                
                e.Graphics.DrawImage(
                   Image,
                   new Rectangle(0, 1, Image.Width, Image.Height),
                   0, 0,
                   Image.Width,
                   Image.Height,
                   GraphicsUnit.Pixel,
                   imageAttributes);
            }

            base.OnPaint(e);
        }

        public void RefreshChanges()
        {
            if (IsDisposed)
                return;

            bool mouseOver = ClientRectangle.Contains(PointToClient(Control.MousePosition));
            if (mouseOver != IsMouseOver)
                IsMouseOver = mouseOver;

            OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }
    }
}

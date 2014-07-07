using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ActiveWare
{
    /// <summary>
    /// A fixed magnifying glass for placing on a control
    /// </summary>
    public partial class MagnifyingGlass : UserControl
    {
        private System.Windows.Forms.Timer _UpdateTimer = new System.Windows.Forms.Timer();
        private int _PixelSize = 5;
        private int _PixelRange = 10;
        private bool _ShowPixel = true;
        private bool _ShowPosition = true;
        private string _PosFormat = "#x ; #y";
        private bool _FollowCursor = false;
        internal Bitmap _ScreenShot = null;
        internal MovingMagnifyingGlass _DisplayForm = null;
        private Point _LastPosition = Point.Empty;
        private MovingMagnifyingGlass _MovingGlass = null;
        private ContentAlignment _PosAlign = ContentAlignment.TopLeft;
        private bool _UseMovingGlass = false;

        /// <summary>
        /// Instance of the magnifying glass with moving glass, if the user clicks on this one
        /// </summary>
        public MagnifyingGlass()
            : this(true)
        {
        }

        /// <summary>
        /// Instance of the magnifying glass
        /// </summary>
        /// <param name="movingGlass">Create a moving glass if the user clicks on this one?</param>
        public MagnifyingGlass(bool movingGlass)
        {
            if (movingGlass)
            {
                // Moving glass is enabled
                _MovingGlass = new MovingMagnifyingGlass();
                MovingGlass.MagnifyingGlass.ShowPosition = false;
                MovingGlass.MagnifyingGlass.DisplayUpdated += new DisplayUpdatedDelegate(MagnifyingGlass_DisplayUpdated);
                MovingGlass.MagnifyingGlass.Click += new EventHandler(_MovingGlass_Click);
                MouseWheel += new MouseEventHandler(MagnifyingGlass_MouseWheel);
                Cursor = Cursors.SizeAll;
                UseMovingGlass = true;
            }
            _UpdateTimer.Tick += new System.EventHandler(_UpdateTimer_Tick);
            Click += new System.EventHandler(MagnifyingGlass_Click);
            CalculateSize();
        }

        #region Properties
        [Description("Magnifying ratio (calculate PixelRange*PixelSize*2+PixelSize for the final control size, min. 3)")]
        public int PixelSize
        {
            get
            {
                return _PixelSize;
            }
            set
            {
                int temp = value;
                if (temp < 3)
                {
                    // Minimum size
                    temp = 3;
                }
                if ((double)temp / 2 == (double)Math.Floor((double)temp / 2))
                {
                    // Use only integers that can't be divided by 2
                    temp++;
                }
                _PixelSize = temp;
                CalculateSize();
            }
        }

        
        [Description("Get/set if the moving glass feature should be used")]
        public bool UseMovingGlass
        {
            get
            {
                return _UseMovingGlass;
            }
            set
            {
                if (MovingGlass != null)
                {
                    _UseMovingGlass = value;
                }
            }
        }

        [Description("Get/set the align of the position (choose everything, but not the middle")]
        public ContentAlignment PosAlign
        {
            get
            {
                return _PosAlign;
            }
            set
            {
                _PosAlign = (!value.ToString().ToLower().StartsWith("middle")) ? value : ContentAlignment.TopLeft;
            }
        }

        [Description("Get/set the position display string format (you have to use #x and #y for the corrdinates values)")]
        public string PosFormat
        {
            get
            {
                return _PosFormat;
            }
            set
            {
                // Settings without the #x and #y variables will be ignored
                _PosFormat = (value != null && value != "" && value.Contains("#x") && value.Contains("#y")) ? value : "#x ; #y";
                Invalidate();
            }
        }

        [Description("The moving glass, if the user clicks on this")]
        public MovingMagnifyingGlass MovingGlass
        {
            get
            {
                return _MovingGlass;
            }
        }

        /// <summary>
        /// Returns true, if enabled, visible and not in designer mode
        /// </summary>
        [Browsable(false)]
        public bool IsEnabled
        {
            get
            {
                return Visible && Enabled && !DesignMode;
            }
        }

        [Browsable(false)]
        internal bool FollowCursor
        {
            get
            {
                return _FollowCursor;
            }
            set
            {
                if (!(_FollowCursor = value))
                {
                    // Exit the following mode
                    if (_ScreenShot != null)
                    {
                        _ScreenShot.Dispose();
                        _ScreenShot = null;
                    }
                }
            }
        }

        [Description("Get/set the pixel range (calculate PixelRange*PixelSize*2+PixelSize for the final control size, min. 1)")]
        public int PixelRange
        {
            get
            {
                return _PixelRange;
            }
            set
            {
                int temp = value;
                if (temp < 1)
                {
                    // Minimum range is one pixel
                    temp = 1;
                }
                _PixelRange = temp;
                CalculateSize();
            }
        }

        [Description("Get/set if the active pixel should be shown")]
        public bool ShowPixel
        {
            get
            {
                return _ShowPixel;
            }
            set
            {
                _ShowPixel = value;
                Invalidate();
            }
        }

        [Description("Get/set if the current cursor position should be shown")]
        public bool ShowPosition
        {
            get
            {
                return _ShowPosition;
            }
            set
            {
                _ShowPosition = value;
                Invalidate();
            }
        }

        [Description("Get the control size (settings will be ignored)")]
        new public Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                // Settings will be ignored 'cause size will be calculated internal
            }
        }

        [Description("Get the timer that updates the display in an interval")]
        public Timer UpdateTimer
        {
            get
            {
                return _UpdateTimer;
            }
        }

        [Description("Get the color of the current pixel")]
        public Color PixelColor
        {
            get
            {
                Bitmap bmp = null;
                try
                {
                    // Make a screenshot of the pixel from the current cursor position
                    bmp = new Bitmap(1, 1);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        bool makeScreenshot = !FollowCursor;// Make a real screenshot?
                        if (makeScreenshot)
                        {
                            if (MovingGlass != null)
                            {
                                //Only make a real screenshot if the moving glass is inactive
                                makeScreenshot &= !MovingGlass.Visible;
                            }
                        }
                        if (!FollowCursor)
                        {
                            // Make a real screenshot
                            g.CopyFromScreen(Cursor.Position, new Point(0, 0), bmp.Size);
                        }
                        else
                        {
                            // Use the screen image for the screenshot
                            bool createScreenshot = false;// Did we create a screenshot for this?
                            if (FollowCursor)
                            {
                                // Create the screenshot only if it wasn't done yet
                                createScreenshot = _ScreenShot == null;
                            }
                            else
                            {
                                // Create the screenshot only of the moving glass has not done it yet
                                createScreenshot = MovingGlass.MagnifyingGlass._ScreenShot == null;
                            }
                            if (createScreenshot)
                            {
                                // Create a new screen image
                                MakeScreenshot();
                            }
                            if (FollowCursor)
                            {
                                // We're the moving glass
                                g.DrawImage(_ScreenShot, new Rectangle(new Point(0, 0), new Size(1, 1)), new Rectangle(Cursor.Position, new Size(1, 1)), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                // Use the moving glasses screenshot
                                g.DrawImage(MovingGlass.MagnifyingGlass._ScreenShot, new Rectangle(new Point(0, 0), new Size(1, 1)), new Rectangle(Cursor.Position, new Size(1, 1)), GraphicsUnit.Pixel);
                            }
                            if (createScreenshot)
                            {
                                // Destroy the screenshot if we only needed to create one for this
                                _ScreenShot.Dispose();
                            }
                        }
                    }
                    // Return the pixel color
                    return bmp.GetPixel(0, 0);
                }
                finally
                {
                    bmp.Dispose();
                }
            }
        }
        #endregion

        #region Painting
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Only paint the background, if we're disabled or in DesignMode
            if (!IsEnabled)
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!IsEnabled)
            {
                // Draw only if visible, enabled and not in DesignMode
                return;
            }
            // Set the InterpolationMode to NearestNeighbor to see the pixels clearly
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            // Prepare some shortcut variables for a better overview
            Point pos = Cursor.Position;
            Rectangle scr = Screen.PrimaryScreen.Bounds;// The screen size
            Point zeroPoint = new Point(0, 0);
            #region Set the new display window location if we follow the cursor
            if (FollowCursor)
            {
                Point loc = new Point(Cursor.Position.X - PixelRange * PixelSize, Cursor.Position.Y - PixelRange * PixelSize);
                if (loc.X < 0)
                {
                    loc = new Point(0, loc.Y);
                }
                if (loc.X + Width > Screen.PrimaryScreen.Bounds.Width)
                {
                    loc = new Point(Screen.PrimaryScreen.Bounds.Width - Width, loc.Y);
                }
                if (loc.Y < 0)
                {
                    loc = new Point(loc.X, 0);
                }
                if (loc.Y + Height > Screen.PrimaryScreen.Bounds.Height)
                {
                    loc = new Point(loc.X, Screen.PrimaryScreen.Bounds.Height - Height);
                }
                _DisplayForm.Location = loc;
            }
            #endregion
            #region Make the screenshot
            Rectangle shot = new Rectangle(zeroPoint, new Size(Size.Width / PixelSize, Size.Height / PixelSize));// The final screenshot size and position
            Point defaultLocation = new Point(pos.X - PixelRange, pos.Y - PixelRange);// The screenshot default location
            shot.Location = defaultLocation;
            if (shot.Location.X < 0)
            {
                // The area is going over the left screen border
                shot.Size = new Size(shot.Size.Width + shot.Location.X, shot.Size.Height);
                shot.Location = new Point(0, shot.Location.Y);
            }
            else if (shot.Location.X > scr.Width)
            {
                // The area is going over the right screen border
                shot.Size = new Size(shot.Location.X - scr.Width, shot.Size.Height);
            }
            if (shot.Location.Y < 0)
            {
                // The area is going over the upper screen border
                shot.Size = new Size(shot.Size.Width, shot.Size.Height + shot.Location.Y);
                shot.Location = new Point(shot.Location.X, 0);
            }
            else if (shot.Location.Y > scr.Height)
            {
                // The area is going over the bottom screen border
                shot.Size = new Size(shot.Size.Width, shot.Location.Y - scr.Height);
            }
            Bitmap screenShot=new Bitmap(shot.Width, shot.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);// The screenshot imag;
            using (Graphics g = Graphics.FromImage(screenShot))
            {
                bool makeScreenshot = !FollowCursor;// Make areal screenshot?
                if (makeScreenshot)
                {
                    if (MovingGlass != null)
                    {
                        // Only make a real screenshot if the moving glass is inactive
                        makeScreenshot &= !MovingGlass.Visible;
                    }
                }
                if (makeScreenshot)
                {
                    // Make screenshot
                    g.CopyFromScreen(shot.Location, zeroPoint, shot.Size);
                }
                else
                {
                    // Copy from work screenshot
                    if (FollowCursor)
                    {
                        // We're the moving glass
                        g.DrawImage(_ScreenShot, new Rectangle(zeroPoint, screenShot.Size), shot, GraphicsUnit.Pixel);
                    }
                    else
                    {
                        // We're not the moving glass, but we should use the work screenshot 
                        // of the moving glass, 'cause if it's fully visible we'd copy the 
                        // moving glass display area...
                        g.DrawImage(MovingGlass.MagnifyingGlass._ScreenShot, new Rectangle(zeroPoint, screenShot.Size), shot, GraphicsUnit.Pixel);
                    }
                }
            }
            #endregion
            #region Paint the screenshot scaled to the display
            Rectangle display = new Rectangle(zeroPoint, Size);// The rectangle within the display to show the screenshot
            Size displaySize = new Size(shot.Width * PixelSize, shot.Height * PixelSize);// The default magnified screenshot size
            if (defaultLocation.X < 0 || defaultLocation.X > scr.Width)
            {
                if (defaultLocation.X < 0)
                {
                    // Display the screenshot with right align
                    display.Location = new Point(display.Width - displaySize.Width, display.Location.Y);
                }
                // Change the display area width to the width of the magnified screenshot
                display.Size = new Size(displaySize.Width, display.Size.Height);
            }
            if (defaultLocation.Y < 0 || defaultLocation.Y > scr.Height)
            {
                if (defaultLocation.Y < 0)
                {
                    // Display the screenshot with bottom align
                    display.Location = new Point(display.Location.X, display.Height - displaySize.Height);
                }
                // Change the display area height to the height of the magnified screenshot
                display.Size = new Size(display.Size.Width, displaySize.Height);
            }
            if (displaySize != Size)
            {
                // Paint the background 'cause the magnified screenshot size is different from the display size and we have a out-of-screen area
                e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(zeroPoint, Size));
            }
            // Scale and paint the screenshot
            e.Graphics.DrawImage(screenShot, display);
            screenShot.Dispose();
            #endregion
            #region Paint everything else to the display
            // Show the current pixel in a black/white bordered rectangle in the middle of the display
            if (ShowPixel)
            {
                int xy = PixelSize * PixelRange;
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), new Rectangle(new Point(xy, xy), new Size(PixelSize, PixelSize)));
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.White)), new Rectangle(new Point(xy + 1, xy + 1), new Size(PixelSize - 2, PixelSize - 2)));
            }
            // Show the cursor position coordinates on a fixed colored background rectangle in the display
            if (ShowPosition)
            {
                // Parse the format string
                string posText = PosFormat;
                posText = posText.Replace("#x", pos.X.ToString());
                posText = posText.Replace("#y", pos.Y.ToString());
                // Calculate where to paint
                Size textSize = e.Graphics.MeasureString(posText, Font).ToSize();
                if (textSize.Width + 6 <= Width && textSize.Height + 6 <= Height)// Continue only if the display is bigger or equal to the needed size
                {
                    string posString = PosAlign.ToString().ToLower();// The align as text (for less code)
                    Point posZero = Point.Empty;// The zero coordinates for the position display
                    if (posString.StartsWith("top"))
                    {
                        posZero = new Point(0, 0);
                    }
                    else
                    {
                        posZero = new Point(0, Height - textSize.Height);
                    }
                    if (posString.Contains("center"))
                    {
                        posZero = new Point((int)Math.Ceiling((double)(Width - textSize.Width) / 2), posZero.Y);
                    }
                    else if (posString.Contains("right"))
                    {
                        posZero = new Point(Width - textSize.Width - 6, posZero.Y);
                    }
                    // Paint the text background rectangle and the text on it
                    e.Graphics.FillRectangle(new SolidBrush(BackColor), new Rectangle(posZero, new Size(textSize.Width + 6, textSize.Height + 6)));
                    e.Graphics.DrawString(posText, Font, new SolidBrush(ForeColor), new PointF(posZero.X + 3, posZero.Y + 3));
                }
            }
            #endregion
        }
        #endregion

        /// <summary>
        /// Set a new size
        /// </summary>
        /// <param name="pixelSize">Pixel size value</param>
        /// <param name="pixelRange">Pixel range value</param>
        public void SetNewSize(int pixelSize, int pixelRange)
        {
            SuspendLayout();
            PixelSize = pixelSize;
            PixelRange = pixelRange;
            ResumeLayout(true);
        }

        private void CalculateSize()
        {
            // Calculate the new control size depending on the magnifying ratio and the pixel range to display
            int wh = PixelSize * (PixelRange * 2 + 1);
            base.Size = new Size(wh, wh);
        }

        private void _UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Redraw and continue the timer if we're visible, enabled and not in DesignMode
                // The timer is also disabled here because the Timer component seems to have an error (it will crashafter a while!?). Restarting the timer is a workaround.
                UpdateTimer.Stop();
                if (IsEnabled)
                {
                    if (_LastPosition == Cursor.Position)
                    {
                        // Refresh only if the position has changed
                        return;
                    }
                    // Remember the current cursor position
                    _LastPosition = Cursor.Position;
                    // Repaint everything
                    Invalidate();
                    // Release the event after the display has been updated
                    OnDisplayUpdated();
                }
            }
            finally
            {
                // Restart the timer
                UpdateTimer.Start();
            }
        }

        /// <summary>
        /// Delegate for the DisplayUpdated event
        /// </summary>
        /// <param name="sender">The sending MagnifyingGlass control</param>
        public delegate void DisplayUpdatedDelegate(MagnifyingGlass sender);
        /// <summary>
        /// Fired after the display has been refreshed by the UpdateTimer or the moving glass
        /// </summary>
        public event DisplayUpdatedDelegate DisplayUpdated;
        private void OnDisplayUpdated()
        {
            if (DisplayUpdated != null)
            {
                DisplayUpdated(this);
            }
        }

        #region Moving glass related methods
        private void MagnifyingGlass_Click(object sender, EventArgs e)
        {
            // Show the moving glass
            if (MovingGlass != null && IsEnabled && UseMovingGlass)
            {
                MovingGlass.Show();
            }
        }

        private void MagnifyingGlass_MouseWheel(object sender, MouseEventArgs e)
        {
            // Resize on mouse wheel actions
            if (_DisplayForm != null && e.Delta != 0)
            {
                if (e.Delta > 0)
                {
                    if ((PixelRange + 1) * PixelRange * 2 <= Screen.PrimaryScreen.Bounds.Width && (PixelRange + 1) * PixelRange * 2 <= Screen.PrimaryScreen.Bounds.Height)
                    {
                        PixelRange++;
                        PixelSize += 2;
                    }
                }
                else
                {
                    if (PixelRange - 1 >= 5)
                    {
                        PixelRange--;
                    }
                    if (PixelSize > 3)
                    {
                        PixelSize -= 2;
                    }
                }
            }
        }

        private void _MovingGlass_Click(object sender, EventArgs e)
        {
            // Hide the moving glass on mouse click
            MovingGlass.Hide();
        }

        private void MagnifyingGlass_DisplayUpdated(MagnifyingGlass sender)
        {
            // Refresh if the moving one has refreshed
            Invalidate();
            OnDisplayUpdated();
        }

        internal void MakeScreenshot()
        {
            // Copy the current screen without this control for the following glass
            OnBeforeMakingScreenshot();
            _ScreenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(_ScreenShot))
            {
                bool visible = _DisplayForm.Visible;
                if (visible)
                {
                    _DisplayForm.Visible = false;
                }
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), _ScreenShot.Size);
                g.Flush();
                if (visible)
                {
                    _DisplayForm.Visible = true;
                }
            }
            OnAfterMakingScreenshot();
        }

        /// <summary>
        /// Delegate for the BeforeMakingScreenshot and the AfterMakingScreenshot events
        /// </summary>
        /// <param name="sender">The sending MagnifyingGlass object</param>
        public delegate void MakingScreenshotDelegate(object sender);
        /// <summary>
        /// Fired before making a screenshot
        /// </summary>
        public event MakingScreenshotDelegate BeforeMakingScreenshot;
        /// <summary>
        /// Fired after making a screenshot
        /// </summary>
        public event MakingScreenshotDelegate AfterMakingScreenshot;
        private void OnBeforeMakingScreenshot()
        {
            if (BeforeMakingScreenshot != null)
            {
                BeforeMakingScreenshot(this);
            }
        }
        private void OnAfterMakingScreenshot()
        {
            if (AfterMakingScreenshot != null)
            {
                AfterMakingScreenshot(this);
            }
        }
        #endregion
    }

    /// <summary>
    /// A free magnifying glass that follows the cursor
    /// </summary>
    public class MovingMagnifyingGlass : Form
    {
        private MagnifyingGlass _MagnifyingGlass = new MagnifyingGlass(false);

        public MovingMagnifyingGlass()
        {
            Opacity = .75;// Added because it makes things easier
            ShowInTaskbar = false;
            ShowIcon = false;
            FormBorderStyle = FormBorderStyle.None;
            MagnifyingGlass.PixelSize = 10;
            MagnifyingGlass.PixelRange = 5;
            MagnifyingGlass.BackColor = Color.Black;
            MagnifyingGlass.ForeColor = Color.White;
            MagnifyingGlass.UpdateTimer.Interval = 50;
            MagnifyingGlass._DisplayForm = this;
            MagnifyingGlass.FollowCursor = true;
            MagnifyingGlass.BorderStyle = BorderStyle.FixedSingle;
            MagnifyingGlass.Resize += new EventHandler(MagnifyingGlass_Resize);
            MagnifyingGlass.Location = new Point(0, 0);
            Controls.Add(MagnifyingGlass);
            Size = MagnifyingGlass.Size;
            Text = "Moving magnifying glass";
        }

        /// <summary>
        /// Show the window and enable the timer
        /// </summary>
        new public void Show()
        {
            MagnifyingGlass.MakeScreenshot();
            Cursor.Position = new Point(0, 0);
            base.Show();
            MagnifyingGlass.UpdateTimer.Start();
            Cursor.Hide();
        }

        /// <summary>
        /// Hide the window and disable the timer
        /// </summary>
        new public void Hide()
        {
            base.Hide();
            MagnifyingGlass.UpdateTimer.Stop();
            Cursor.Show();
            MagnifyingGlass._ScreenShot.Dispose();
            MagnifyingGlass._ScreenShot = null;
        }

        private void MagnifyingGlass_Resize(object sender, EventArgs e)
        {
            // Always stay as big as the glass
            Size = MagnifyingGlass.Size;
        }

        /// <summary>
        /// The magnifying glass object
        /// </summary>
        [Description("The magnifying glass object")]
        public MagnifyingGlass MagnifyingGlass
        {
            get
            {
                return _MagnifyingGlass;
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingExDemo
{
	/// <summary>
	/// Zusammenfassung für icnpicturebox.
	/// </summary>
	public class icnpicturebox:Control
	{
		private DrawingEx.IconEncoder.Icon _icn;
		public icnpicturebox()
		{
			this.SetStyle(ControlStyles.AllPaintingInWmPaint  |
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint  |
				ControlStyles.ResizeRedraw, true);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);
			if(_icn!=null)
			{
				int x=8;
				foreach(DrawingEx.IconEncoder.IconImage img in _icn.Images)
				{
					e.Graphics.DrawImageUnscaled(img.Bitmap,x,8);
					x+=img.Bitmap.Width+8;
				}
			}
		}

		[DefaultValue(null)]
		public DrawingEx.IconEncoder.Icon Icon
		{
			get{return _icn;}
			set
			{
				_icn=value; Refresh();
			}
		}
	}
}

using System;

using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DrawingEx.IconEncoder;

namespace DrawingExDemo
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DrawingExDemo.icnpicturebox icnpicturebox1;
		private DrawingEx.ColorManagement.ColorDialogEx colorDialogEx1;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.icnpicturebox1 = new DrawingExDemo.icnpicturebox();
			this.colorDialogEx1 = new DrawingEx.ColorManagement.ColorDialogEx();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// icnpicturebox1
			// 
			this.icnpicturebox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.icnpicturebox1.Icon = ((DrawingEx.IconEncoder.Icon)(resources.GetObject("icnpicturebox1.Icon")));
			this.icnpicturebox1.Location = new System.Drawing.Point(57, 87);
			this.icnpicturebox1.Name = "icnpicturebox1";
			this.icnpicturebox1.Size = new System.Drawing.Size(184, 72);
			this.icnpicturebox1.TabIndex = 1;
			this.icnpicturebox1.Click += new System.EventHandler(this.icnpicturebox1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(57, 158);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "click here ^^ to choose a color";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(298, 268);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.icnpicturebox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(304, 300);
			this.MinimumSize = new System.Drawing.Size(304, 300);
			this.Name = "Form1";
			this.Text = "DrawingEx Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.CurrentCulture = new System.Globalization.CultureInfo("en-US");
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private void icnpicturebox1_Click(object sender, System.EventArgs e)
		{
			colorDialogEx1.Color=icnpicturebox1.BackColor;
			if(colorDialogEx1.ShowDialog()==DialogResult.OK)
				icnpicturebox1.BackColor=colorDialogEx1.Color;
		}



	}
}

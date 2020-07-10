using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Palindromizer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox txtLeft;
		private System.Windows.Forms.RichTextBox txtRight;
		private System.Windows.Forms.RichTextBox txtFull;
		private System.Windows.Forms.CheckBox checkCenter;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtLeft = new System.Windows.Forms.RichTextBox();
            this.txtRight = new System.Windows.Forms.RichTextBox();
            this.txtFull = new System.Windows.Forms.RichTextBox();
            this.checkCenter = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtLeft
            // 
            this.txtLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeft.Location = new System.Drawing.Point(16, 40);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(280, 56);
            this.txtLeft.TabIndex = 0;
            this.txtLeft.Text = "";
            this.txtLeft.TextChanged += new System.EventHandler(this.txtLeft_TextChanged);
            // 
            // txtRight
            // 
            this.txtRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRight.Location = new System.Drawing.Point(304, 40);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(280, 56);
            this.txtRight.TabIndex = 1;
            this.txtRight.Text = "";
            this.txtRight.TextChanged += new System.EventHandler(this.txtRight_TextChanged);
            // 
            // txtFull
            // 
            this.txtFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFull.Location = new System.Drawing.Point(16, 104);
            this.txtFull.Name = "txtFull";
            this.txtFull.ReadOnly = true;
            this.txtFull.Size = new System.Drawing.Size(568, 56);
            this.txtFull.TabIndex = 2;
            this.txtFull.Text = "";
            // 
            // checkCenter
            // 
            this.checkCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCenter.Location = new System.Drawing.Point(360, 8);
            this.checkCenter.Name = "checkCenter";
            this.checkCenter.Size = new System.Drawing.Size(192, 24);
            this.checkCenter.TabIndex = 3;
            this.checkCenter.Text = "Repeat middle letter";
            this.checkCenter.CheckedChanged += new System.EventHandler(this.checkCenter_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(602, 176);
            this.Controls.Add(this.checkCenter);
            this.Controls.Add(this.txtFull);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.txtLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Palindromizer (с) 2005";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		bool leftChange = false;
		bool rightChange = false;

		private void txtLeft_TextChanged(object sender, System.EventArgs e)
		{
			if (rightChange)
				return;

			leftChange = true;

			char[] chars = txtLeft.Text.ToCharArray();
			string text = string.Empty;

			int higher = (checkCenter.Checked)? chars.Length-1 : chars.Length-2;
			for (int i = higher; i >= 0; i--)
			{
				text += chars[i];
			}
			txtRight.Text = text;
			UpdateFullText();

			leftChange = false;
		}		

		private void checkCenter_CheckedChanged(object sender, System.EventArgs e)
		{
			txtLeft_TextChanged(null, null);
		}

		private void txtRight_TextChanged(object sender, System.EventArgs e)
		{
			if (leftChange)
				return;

			rightChange = true;

			char[] chars = txtRight.Text.ToCharArray();
			string text = string.Empty;

			int lower = (checkCenter.Checked)? 0 : 1;
			for (int i = chars.Length - 1; i >= lower; i--)
			{
				text += chars[i];
			}
			txtLeft.Text = text;
			UpdateFullText();

			rightChange = false;
		}

		private void UpdateFullText()
		{
			txtFull.Text = txtLeft.Text + txtRight.Text;
		}
	}
}

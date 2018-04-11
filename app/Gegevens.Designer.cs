namespace app
{
	partial class Gegevens
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Gebruiker = new System.Windows.Forms.Label();
			this.Lengte = new System.Windows.Forms.Label();
			this.Aantal_woorden = new System.Windows.Forms.Label();
			this.Aantal_stopwoorden = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.Aantal = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Aantal);
			this.groupBox1.Controls.Add(this.listBox1);
			this.groupBox1.Controls.Add(this.Aantal_stopwoorden);
			this.groupBox1.Controls.Add(this.Aantal_woorden);
			this.groupBox1.Controls.Add(this.Gebruiker);
			this.groupBox1.Controls.Add(this.Lengte);
			this.groupBox1.Location = new System.Drawing.Point(52, 69);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(438, 420);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// Gebruiker
			// 
			this.Gebruiker.AutoSize = true;
			this.Gebruiker.Location = new System.Drawing.Point(33, 44);
			this.Gebruiker.Name = "Gebruiker";
			this.Gebruiker.Size = new System.Drawing.Size(19, 17);
			this.Gebruiker.TabIndex = 1;
			this.Gebruiker.Text = "G";
			// 
			// Lengte
			// 
			this.Lengte.AutoSize = true;
			this.Lengte.Location = new System.Drawing.Point(33, 78);
			this.Lengte.Name = "Lengte";
			this.Lengte.Size = new System.Drawing.Size(46, 17);
			this.Lengte.TabIndex = 0;
			this.Lengte.Text = "label2";
			// 
			// Aantal_woorden
			// 
			this.Aantal_woorden.AutoSize = true;
			this.Aantal_woorden.Location = new System.Drawing.Point(33, 111);
			this.Aantal_woorden.Name = "Aantal_woorden";
			this.Aantal_woorden.Size = new System.Drawing.Size(46, 17);
			this.Aantal_woorden.TabIndex = 2;
			this.Aantal_woorden.Text = "label1";
			// 
			// Aantal_stopwoorden
			// 
			this.Aantal_stopwoorden.AutoSize = true;
			this.Aantal_stopwoorden.Location = new System.Drawing.Point(33, 141);
			this.Aantal_stopwoorden.Name = "Aantal_stopwoorden";
			this.Aantal_stopwoorden.Size = new System.Drawing.Size(46, 17);
			this.Aantal_stopwoorden.TabIndex = 3;
			this.Aantal_stopwoorden.Text = "label1";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 16;
			this.listBox1.Location = new System.Drawing.Point(238, 55);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(132, 100);
			this.listBox1.TabIndex = 4;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// Aantal
			// 
			this.Aantal.AutoSize = true;
			this.Aantal.Location = new System.Drawing.Point(260, 201);
			this.Aantal.Name = "Aantal";
			this.Aantal.Size = new System.Drawing.Size(46, 17);
			this.Aantal.TabIndex = 5;
			this.Aantal.Text = "label1";
			// 
			// Gegevens
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 512);
			this.Controls.Add(this.groupBox1);
			this.Name = "Gegevens";
			this.Text = "Gegevens";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label Aantal_stopwoorden;
		private System.Windows.Forms.Label Aantal_woorden;
		private System.Windows.Forms.Label Gebruiker;
		private System.Windows.Forms.Label Lengte;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label Aantal;
	}
}
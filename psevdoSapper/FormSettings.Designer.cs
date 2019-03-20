namespace psevdoSapper {
	partial class FormSettings {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBoxLevel = new System.Windows.Forms.GroupBox();
			this.textBoxHeight = new System.Windows.Forms.TextBox();
			this.textBoxWidth = new System.Windows.Forms.TextBox();
			this.textBoxMines = new System.Windows.Forms.TextBox();
			this.labelMines = new System.Windows.Forms.Label();
			this.labelWidth = new System.Windows.Forms.Label();
			this.labelHeight = new System.Windows.Forms.Label();
			this.radioButtonSpecial = new System.Windows.Forms.RadioButton();
			this.radioButtonHard = new System.Windows.Forms.RadioButton();
			this.radioButtonMedium = new System.Windows.Forms.RadioButton();
			this.radioButtonEasy = new System.Windows.Forms.RadioButton();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.groupBoxLevel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxLevel
			// 
			this.groupBoxLevel.Controls.Add(this.textBoxHeight);
			this.groupBoxLevel.Controls.Add(this.textBoxWidth);
			this.groupBoxLevel.Controls.Add(this.textBoxMines);
			this.groupBoxLevel.Controls.Add(this.labelMines);
			this.groupBoxLevel.Controls.Add(this.labelWidth);
			this.groupBoxLevel.Controls.Add(this.labelHeight);
			this.groupBoxLevel.Controls.Add(this.radioButtonSpecial);
			this.groupBoxLevel.Controls.Add(this.radioButtonHard);
			this.groupBoxLevel.Controls.Add(this.radioButtonMedium);
			this.groupBoxLevel.Controls.Add(this.radioButtonEasy);
			this.groupBoxLevel.Location = new System.Drawing.Point(12, 12);
			this.groupBoxLevel.Name = "groupBoxLevel";
			this.groupBoxLevel.Size = new System.Drawing.Size(330, 181);
			this.groupBoxLevel.TabIndex = 0;
			this.groupBoxLevel.TabStop = false;
			this.groupBoxLevel.Text = "Level";
			// 
			// textBoxHeight
			// 
			this.textBoxHeight.Enabled = false;
			this.textBoxHeight.Location = new System.Drawing.Point(273, 41);
			this.textBoxHeight.Name = "textBoxHeight";
			this.textBoxHeight.Size = new System.Drawing.Size(51, 20);
			this.textBoxHeight.TabIndex = 9;
			this.textBoxHeight.Text = "10";
			// 
			// textBoxWidth
			// 
			this.textBoxWidth.Enabled = false;
			this.textBoxWidth.Location = new System.Drawing.Point(273, 64);
			this.textBoxWidth.Name = "textBoxWidth";
			this.textBoxWidth.Size = new System.Drawing.Size(51, 20);
			this.textBoxWidth.TabIndex = 8;
			this.textBoxWidth.Text = "20";
			// 
			// textBoxMines
			// 
			this.textBoxMines.Enabled = false;
			this.textBoxMines.Location = new System.Drawing.Point(273, 89);
			this.textBoxMines.Name = "textBoxMines";
			this.textBoxMines.Size = new System.Drawing.Size(51, 20);
			this.textBoxMines.TabIndex = 7;
			this.textBoxMines.Text = "10";
			// 
			// labelMines
			// 
			this.labelMines.AutoSize = true;
			this.labelMines.Enabled = false;
			this.labelMines.Location = new System.Drawing.Point(147, 89);
			this.labelMines.Name = "labelMines";
			this.labelMines.Size = new System.Drawing.Size(119, 13);
			this.labelMines.TabIndex = 6;
			this.labelMines.Text = "Number of mines (5 - ?):";
			// 
			// labelWidth
			// 
			this.labelWidth.AutoSize = true;
			this.labelWidth.Enabled = false;
			this.labelWidth.Location = new System.Drawing.Point(144, 72);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(74, 13);
			this.labelWidth.TabIndex = 5;
			this.labelWidth.Text = "Width (5 - 50):";
			// 
			// labelHeight
			// 
			this.labelHeight.AutoSize = true;
			this.labelHeight.Enabled = false;
			this.labelHeight.Location = new System.Drawing.Point(144, 49);
			this.labelHeight.Name = "labelHeight";
			this.labelHeight.Size = new System.Drawing.Size(77, 13);
			this.labelHeight.TabIndex = 4;
			this.labelHeight.Text = "Height (5 - 50):";
			// 
			// radioButtonSpecial
			// 
			this.radioButtonSpecial.AutoSize = true;
			this.radioButtonSpecial.Location = new System.Drawing.Point(120, 29);
			this.radioButtonSpecial.Name = "radioButtonSpecial";
			this.radioButtonSpecial.Size = new System.Drawing.Size(60, 17);
			this.radioButtonSpecial.TabIndex = 3;
			this.radioButtonSpecial.Text = "Special";
			this.radioButtonSpecial.UseVisualStyleBackColor = true;
			this.radioButtonSpecial.CheckedChanged += new System.EventHandler(this.radioButtonSpecial_CheckedChanged);
			// 
			// radioButtonHard
			// 
			this.radioButtonHard.AutoSize = true;
			this.radioButtonHard.Location = new System.Drawing.Point(6, 127);
			this.radioButtonHard.Name = "radioButtonHard";
			this.radioButtonHard.Size = new System.Drawing.Size(106, 43);
			this.radioButtonHard.TabIndex = 2;
			this.radioButtonHard.Text = "Hard\r\n99 mines\r\nfield 30 x 16 cells";
			this.radioButtonHard.UseVisualStyleBackColor = true;
			// 
			// radioButtonMedium
			// 
			this.radioButtonMedium.AutoSize = true;
			this.radioButtonMedium.Checked = true;
			this.radioButtonMedium.Location = new System.Drawing.Point(6, 78);
			this.radioButtonMedium.Name = "radioButtonMedium";
			this.radioButtonMedium.Size = new System.Drawing.Size(106, 43);
			this.radioButtonMedium.TabIndex = 1;
			this.radioButtonMedium.TabStop = true;
			this.radioButtonMedium.Text = "Medium\r\n40 mines\r\nfield 16 x 16 cells";
			this.radioButtonMedium.UseVisualStyleBackColor = true;
			// 
			// radioButtonEasy
			// 
			this.radioButtonEasy.AutoSize = true;
			this.radioButtonEasy.Location = new System.Drawing.Point(6, 29);
			this.radioButtonEasy.Name = "radioButtonEasy";
			this.radioButtonEasy.Size = new System.Drawing.Size(94, 43);
			this.radioButtonEasy.TabIndex = 0;
			this.radioButtonEasy.Text = "Easy\r\n10 mines\r\nfield 9 x 9 cells";
			this.radioButtonEasy.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(267, 199);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(186, 199);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 23);
			this.buttonOk.TabIndex = 1;
			this.buttonOk.Text = "Ok";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 233);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.groupBoxLevel);
			this.Name = "FormSettings";
			this.Text = "FormSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
			this.groupBoxLevel.ResumeLayout(false);
			this.groupBoxLevel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxLevel;
		private System.Windows.Forms.TextBox textBoxHeight;
		private System.Windows.Forms.TextBox textBoxWidth;
		private System.Windows.Forms.TextBox textBoxMines;
		private System.Windows.Forms.Label labelMines;
		private System.Windows.Forms.Label labelWidth;
		private System.Windows.Forms.Label labelHeight;
		private System.Windows.Forms.RadioButton radioButtonSpecial;
		private System.Windows.Forms.RadioButton radioButtonHard;
		private System.Windows.Forms.RadioButton radioButtonMedium;
		private System.Windows.Forms.RadioButton radioButtonEasy;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
	}
}
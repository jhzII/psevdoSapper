namespace psevdoSapper {
	partial class FormClose {
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
			this.labelText = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonNotSave = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelText.Location = new System.Drawing.Point(82, 9);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(160, 40);
			this.labelText.TabIndex = 0;
			this.labelText.Text = "The game is not over!\r\nWhat to do?\r\n";
			// 
			// buttonSave
			// 
			this.buttonSave.Location = new System.Drawing.Point(41, 74);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 1;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonNotSave
			// 
			this.buttonNotSave.Location = new System.Drawing.Point(122, 74);
			this.buttonNotSave.Name = "buttonNotSave";
			this.buttonNotSave.Size = new System.Drawing.Size(75, 23);
			this.buttonNotSave.TabIndex = 2;
			this.buttonNotSave.Text = "Not save";
			this.buttonNotSave.UseVisualStyleBackColor = true;
			this.buttonNotSave.Click += new System.EventHandler(this.buttonNotSave_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(203, 74);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// FormClose
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(328, 109);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonNotSave);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.labelText);
			this.Name = "FormClose";
			this.Text = "FormClose";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClose_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonNotSave;
		private System.Windows.Forms.Button buttonCancel;
	}
}
namespace psevdoSapper {
	partial class FormVictory {
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
			this.labelVictory = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonNewGame = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelVictory
			// 
			this.labelVictory.AutoSize = true;
			this.labelVictory.Location = new System.Drawing.Point(117, 9);
			this.labelVictory.Name = "labelVictory";
			this.labelVictory.Size = new System.Drawing.Size(39, 13);
			this.labelVictory.TabIndex = 0;
			this.labelVictory.Text = "Victory";
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(41, 85);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonNewGame
			// 
			this.buttonNewGame.Location = new System.Drawing.Point(159, 85);
			this.buttonNewGame.Name = "buttonNewGame";
			this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
			this.buttonNewGame.TabIndex = 2;
			this.buttonNewGame.Text = "New Game";
			this.buttonNewGame.UseVisualStyleBackColor = true;
			this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
			// 
			// FormVictory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 120);
			this.Controls.Add(this.buttonNewGame);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.labelVictory);
			this.Name = "FormVictory";
			this.Text = "FormVictory";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelVictory;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonNewGame;
	}
}
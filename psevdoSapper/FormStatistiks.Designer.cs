namespace psevdoSapper {
	partial class FormStatistiks {
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
			this.comboBoxMode = new System.Windows.Forms.ComboBox();
			this.labelMode = new System.Windows.Forms.Label();
			this.labelGameAT = new System.Windows.Forms.Label();
			this.labelVictoryAT = new System.Windows.Forms.Label();
			this.labelWinPercTA = new System.Windows.Forms.Label();
			this.gBoxAllTime = new System.Windows.Forms.GroupBox();
			this.labelBestTimeTA = new System.Windows.Forms.Label();
			this.gBoxCurSess = new System.Windows.Forms.GroupBox();
			this.labelBestTimeCS = new System.Windows.Forms.Label();
			this.labelGameCS = new System.Windows.Forms.Label();
			this.labelWinPercCS = new System.Windows.Forms.Label();
			this.labelVictoryCS = new System.Windows.Forms.Label();
			this.buttonReset = new System.Windows.Forms.Button();
			this.gBoxAllTime.SuspendLayout();
			this.gBoxCurSess.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxMode
			// 
			this.comboBoxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.comboBoxMode.FormattingEnabled = true;
			this.comboBoxMode.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
			this.comboBoxMode.Location = new System.Drawing.Point(13, 46);
			this.comboBoxMode.Name = "comboBoxMode";
			this.comboBoxMode.Size = new System.Drawing.Size(94, 23);
			this.comboBoxMode.TabIndex = 0;
			this.comboBoxMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxMode_SelectedIndexChanged);
			// 
			// labelMode
			// 
			this.labelMode.AutoSize = true;
			this.labelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.labelMode.Location = new System.Drawing.Point(12, 25);
			this.labelMode.Name = "labelMode";
			this.labelMode.Size = new System.Drawing.Size(50, 18);
			this.labelMode.TabIndex = 1;
			this.labelMode.Text = "Mode:";
			// 
			// labelGameAT
			// 
			this.labelGameAT.AutoSize = true;
			this.labelGameAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelGameAT.Location = new System.Drawing.Point(5, 19);
			this.labelGameAT.Name = "labelGameAT";
			this.labelGameAT.Size = new System.Drawing.Size(94, 17);
			this.labelGameAT.TabIndex = 2;
			this.labelGameAT.Text = "labelGameAT";
			// 
			// labelVictoryAT
			// 
			this.labelVictoryAT.AutoSize = true;
			this.labelVictoryAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelVictoryAT.Location = new System.Drawing.Point(5, 38);
			this.labelVictoryAT.Name = "labelVictoryAT";
			this.labelVictoryAT.Size = new System.Drawing.Size(99, 17);
			this.labelVictoryAT.TabIndex = 3;
			this.labelVictoryAT.Text = "labelVictoryAT";
			// 
			// labelWinPercTA
			// 
			this.labelWinPercTA.AutoSize = true;
			this.labelWinPercTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelWinPercTA.Location = new System.Drawing.Point(5, 58);
			this.labelWinPercTA.Name = "labelWinPercTA";
			this.labelWinPercTA.Size = new System.Drawing.Size(109, 17);
			this.labelWinPercTA.TabIndex = 4;
			this.labelWinPercTA.Text = "labelWinPercTA";
			// 
			// gBoxAllTime
			// 
			this.gBoxAllTime.Controls.Add(this.labelBestTimeTA);
			this.gBoxAllTime.Controls.Add(this.labelGameAT);
			this.gBoxAllTime.Controls.Add(this.labelWinPercTA);
			this.gBoxAllTime.Controls.Add(this.labelVictoryAT);
			this.gBoxAllTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gBoxAllTime.Location = new System.Drawing.Point(132, 12);
			this.gBoxAllTime.Name = "gBoxAllTime";
			this.gBoxAllTime.Size = new System.Drawing.Size(212, 100);
			this.gBoxAllTime.TabIndex = 5;
			this.gBoxAllTime.TabStop = false;
			this.gBoxAllTime.Text = "For the all time";
			// 
			// labelBestTimeTA
			// 
			this.labelBestTimeTA.AutoSize = true;
			this.labelBestTimeTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelBestTimeTA.Location = new System.Drawing.Point(5, 76);
			this.labelBestTimeTA.Name = "labelBestTimeTA";
			this.labelBestTimeTA.Size = new System.Drawing.Size(115, 17);
			this.labelBestTimeTA.TabIndex = 5;
			this.labelBestTimeTA.Text = "labelBestTimeTA";
			// 
			// gBoxCurSess
			// 
			this.gBoxCurSess.Controls.Add(this.labelBestTimeCS);
			this.gBoxCurSess.Controls.Add(this.labelGameCS);
			this.gBoxCurSess.Controls.Add(this.labelWinPercCS);
			this.gBoxCurSess.Controls.Add(this.labelVictoryCS);
			this.gBoxCurSess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.gBoxCurSess.Location = new System.Drawing.Point(132, 118);
			this.gBoxCurSess.Name = "gBoxCurSess";
			this.gBoxCurSess.Size = new System.Drawing.Size(212, 100);
			this.gBoxCurSess.TabIndex = 6;
			this.gBoxCurSess.TabStop = false;
			this.gBoxCurSess.Text = "For the current session";
			// 
			// labelBestTimeCS
			// 
			this.labelBestTimeCS.AutoSize = true;
			this.labelBestTimeCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelBestTimeCS.Location = new System.Drawing.Point(5, 76);
			this.labelBestTimeCS.Name = "labelBestTimeCS";
			this.labelBestTimeCS.Size = new System.Drawing.Size(115, 17);
			this.labelBestTimeCS.TabIndex = 5;
			this.labelBestTimeCS.Text = "labelBestTimeCS";
			// 
			// labelGameCS
			// 
			this.labelGameCS.AutoSize = true;
			this.labelGameCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelGameCS.Location = new System.Drawing.Point(5, 19);
			this.labelGameCS.Name = "labelGameCS";
			this.labelGameCS.Size = new System.Drawing.Size(94, 17);
			this.labelGameCS.TabIndex = 2;
			this.labelGameCS.Text = "labelGameCS";
			// 
			// labelWinPercCS
			// 
			this.labelWinPercCS.AutoSize = true;
			this.labelWinPercCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelWinPercCS.Location = new System.Drawing.Point(5, 58);
			this.labelWinPercCS.Name = "labelWinPercCS";
			this.labelWinPercCS.Size = new System.Drawing.Size(109, 17);
			this.labelWinPercCS.TabIndex = 4;
			this.labelWinPercCS.Text = "labelWinPercCS";
			// 
			// labelVictoryCS
			// 
			this.labelVictoryCS.AutoSize = true;
			this.labelVictoryCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.labelVictoryCS.Location = new System.Drawing.Point(5, 38);
			this.labelVictoryCS.Name = "labelVictoryCS";
			this.labelVictoryCS.Size = new System.Drawing.Size(99, 17);
			this.labelVictoryCS.TabIndex = 3;
			this.labelVictoryCS.Text = "labelVictoryCS";
			// 
			// buttonReset
			// 
			this.buttonReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
			this.buttonReset.Location = new System.Drawing.Point(13, 194);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(78, 24);
			this.buttonReset.TabIndex = 7;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// FormStatistiks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(356, 230);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.gBoxCurSess);
			this.Controls.Add(this.gBoxAllTime);
			this.Controls.Add(this.labelMode);
			this.Controls.Add(this.comboBoxMode);
			this.Name = "FormStatistiks";
			this.Text = "Statistiks";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStatistiks_FormClosing);
			this.gBoxAllTime.ResumeLayout(false);
			this.gBoxAllTime.PerformLayout();
			this.gBoxCurSess.ResumeLayout(false);
			this.gBoxCurSess.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxMode;
		private System.Windows.Forms.Label labelMode;
		private System.Windows.Forms.Label labelGameAT;
		private System.Windows.Forms.Label labelVictoryAT;
		private System.Windows.Forms.Label labelWinPercTA;
		private System.Windows.Forms.GroupBox gBoxAllTime;
		private System.Windows.Forms.Label labelBestTimeTA;
		private System.Windows.Forms.GroupBox gBoxCurSess;
		private System.Windows.Forms.Label labelBestTimeCS;
		private System.Windows.Forms.Label labelGameCS;
		private System.Windows.Forms.Label labelWinPercCS;
		private System.Windows.Forms.Label labelVictoryCS;
		private System.Windows.Forms.Button buttonReset;
	}
}
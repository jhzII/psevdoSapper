﻿using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormVictory : Form {
		public static bool open = false;
		Form1 main_form;
		bool new_game = true;
		public FormVictory() {
			InitializeComponent();
			open = true;
		}

		public FormVictory(Form1 form, int sec) {
			InitializeComponent();
			main_form = form;
			main_form.Enabled = false;
			open = true;
			labelWithTime.Text = "You won in " + sec + " seconds.";
		}

		private void buttonClose_Click(object sender, EventArgs e) {
			new_game = false;
			FormClose.open = true;
			this.Close();
		}

		private void buttonNewGame_Click(object sender, EventArgs e) {			
			this.Close();
		}

		private void FormVictory_FormClosing(object sender, FormClosingEventArgs e) {
			main_form.Enabled = true;
			open = false;
			if(new_game)
				main_form.Restart(main_form.supMatrix.n, main_form.supMatrix.m,
								  main_form.supMatrix.kol_min);
			else
				main_form.Close();
		}
	}
}

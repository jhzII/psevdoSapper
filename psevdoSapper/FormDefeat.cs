using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormDefeat : Form {
		public static bool open = false;
		Form1 main_form;
		bool new_game = true;

		public FormDefeat() {
			InitializeComponent();
			open = true;
		}		

		public FormDefeat(Form1 form) {
			InitializeComponent();
			main_form = form;
			main_form.Enabled = false;
			open = true;
		}

		private void buttonExit_Click(object sender, EventArgs e) {
			new_game = false;
			this.Close();
		}

		private void buttonNewGame_Click(object sender, EventArgs e) {			
			this.Close();
		}

		private void FormDefeat_FormClosing(object sender, FormClosingEventArgs e) {
			if(new_game)
				main_form.Restart(main_form.supMatrix.n, main_form.supMatrix.m,
								  main_form.supMatrix.kol_min);
			main_form.Enabled = true;
			open = false;
		}
	}
}
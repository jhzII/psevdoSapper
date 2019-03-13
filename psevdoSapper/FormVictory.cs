using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormVictory : Form {
		public static bool open = false;
		Form1 main_form;
		public FormVictory() {
			InitializeComponent();
			open = true;
		}

		public FormVictory(Form1 form) {
			InitializeComponent();
			main_form = form;
			open = true;
		}

		private void buttonClose_Click(object sender, EventArgs e) {
			open = false;
			main_form.Close();
		}

		private void buttonNewGame_Click(object sender, EventArgs e) {
			Form1.Restart(Form1.main_matrix.n, Form1.main_matrix.m, Form1.main_matrix.kol_min);
			open = false;
			this.Close();
		}
	}
}

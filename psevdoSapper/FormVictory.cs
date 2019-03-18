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
			main_form.Restart(main_form.supMatrix.n, main_form.supMatrix.m,
							  main_form.supMatrix.kol_min);
			open = false;
			this.Close();
		}
	}
}

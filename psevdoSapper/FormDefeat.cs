using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormDefeat : Form {
		Form1 main_form;
		public FormDefeat() {
			InitializeComponent();
		}		
		public FormDefeat(Form1 form) {
			InitializeComponent();
			main_form = form;
		}

		private void buttonExit_Click(object sender, EventArgs e) {
			main_form.Close();
			this.Close();
		}

		private void buttonNewGame_Click(object sender, EventArgs e) {
			Form1.Restart(Form1.main_matrix.n, Form1.main_matrix.m, Form1.main_matrix.kol_min);
			this.Close();
		}
	}
}
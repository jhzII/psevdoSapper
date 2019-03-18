using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormDefeat : Form {
		public static bool open = false;
		Form1 main_form;
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
			main_form.Close();
		}

		private void buttonNewGame_Click(object sender, EventArgs e) {
			main_form.Restart(main_form.supMatrix.n, main_form.supMatrix.m,
							  main_form.supMatrix.kol_min);
			main_form.Enabled = true;
			open = false;
			this.Close();
		}
	}
}
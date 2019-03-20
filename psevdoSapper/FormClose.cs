using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormClose : Form {
		public static bool open = false;
		Form1 main_form;
		public FormClose() {
			InitializeComponent();
			open = true;
		}

		public FormClose(Form1 form) {
			InitializeComponent();
			main_form = form;
			main_form.Enabled = false;
			open = true;
		}

		// сохранить
		private void buttonSave_Click(object sender, EventArgs e) {
			main_form.Enabled = true;
			main_form.save = true;
			main_form.Close();
		}

		// не сохранять
		private void buttonNotSave_Click(object sender, EventArgs e) {
			main_form.Enabled = true;
			main_form.save = false;
			main_form.Close();
		}

		// отмена
		private void buttonCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void FormClose_FormClosing(object sender, FormClosingEventArgs e) {
			main_form.Enabled = true;
			open = false;
		}
	}
}

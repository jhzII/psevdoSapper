using System;
using System.Windows.Forms;

/* future:
 * Help
 * */
 
namespace psevdoSapper {
	public partial class Form1 : Form {
		public MatrixSapperButton supMatrix;
		public radioButtonOption selectedBatton;
		public Form1() {
			InitializeComponent();

			supMatrix = new MatrixSapperButton(this, 16, 16, 40); // соответствует Medium
			selectedBatton = radioButtonOption.Medium;
			supMatrix.AddMatrixSapperButtonOnForm();
		}

		public void Restart(byte kol_n, byte kol_m, int k_min) {
			supMatrix.RemoveMatrixSapperButtonOnForm();
			supMatrix = new MatrixSapperButton(this, kol_n, kol_m, k_min);
			supMatrix.AddMatrixSapperButtonOnForm();
		}

		public void Defeat() {
			if(!FormDefeat.open) {
				FormDefeat defForm = new FormDefeat(this);
				defForm.Show();
			}
		}

		public void Victory() {
			if (!FormVictory.open) {
				FormVictory vicForm = new FormVictory(this);
				vicForm.Show();
			}
		}

		// New game
		private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
			Restart(supMatrix.n, supMatrix.m, supMatrix.kol_min);
		}

		// Settings - вызвать окно настройки размера
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
			FormSettings SetForm = new FormSettings(this, selectedBatton);
			SetForm.Show();
		}

		// Exit
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		// Help
		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("Oops, not ready yet");
		}
	}	
}
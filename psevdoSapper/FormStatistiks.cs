using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class FormStatistiks : Form {
		Form1 main_form;
		StatisticsData Statics;
		public FormStatistiks() {
			InitializeComponent();
		}

		public FormStatistiks(Form1 form, StatisticsData statics, radioButtonOption mode) {
			InitializeComponent();

			main_form = form;
			main_form.Enabled = false;
			Statics = statics;
			
			comboBoxMode.SelectedIndex = (mode == radioButtonOption.Special) ? 1 : (int)mode;
			ShowByMode(comboBoxMode.SelectedIndex);
		}

		private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e) {
			ShowByMode(comboBoxMode.SelectedIndex);
		}

		private void ShowByMode(int mode) {
			labelGameAT.Text = "Played: " + Statics.massAllTimeData[mode, 0];
			labelVictoryAT.Text = "Won: " + Statics.massAllTimeData[mode, 1];
			labelWinPercTA.Text = "Win percentage: " + Statics.getAvergeValueByMode(mode, true) + "%";
			labelBestTimeTA.Text = "Best time: " + Statics.massAllTimeData[mode, 2];

			labelGameCS.Text = "Played: " + Statics.massCurrentTimeData[mode, 0];
			labelVictoryCS.Text = "Won: " + Statics.massCurrentTimeData[mode, 1];
			labelWinPercCS.Text = "Win percentage: " + Statics.getAvergeValueByMode(mode, false) + "%";
			labelBestTimeCS.Text = "Best time: " + Statics.massCurrentTimeData[mode, 2];
		}

		private void FormStatistiks_FormClosing(object sender, FormClosingEventArgs e) {
			main_form.Enabled = true;
		}

		private void buttonReset_Click(object sender, EventArgs e) {
			DialogResult dialogResult = MessageBox.Show("Reset all statistics?", "Confirmation",
				MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes) {
				Statics.massAllTimeData = new int[3, 3];
				Statics.massCurrentTimeData = new int[3, 3];
				ShowByMode(comboBoxMode.SelectedIndex);
			}
		}
	}
}

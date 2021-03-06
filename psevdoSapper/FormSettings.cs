﻿using System;
using System.Windows.Forms;

namespace psevdoSapper {
	public enum radioButtonOption { Easy, Medium, Hard, Special };

	public partial class FormSettings : Form {
		Form1 main_form;
		radioButtonOption selectedButton;

		public FormSettings() {
			InitializeComponent();
		}

		public FormSettings(Form1 form, radioButtonOption selectedButton) {
			InitializeComponent();
			main_form = form;
			main_form.Enabled = false;
			this.selectedButton = selectedButton;
			// установка режима
			switch(selectedButton) {
			case radioButtonOption.Easy:
				radioButtonEasy.Checked = true;
				break;
			case radioButtonOption.Medium:
				radioButtonMedium.Checked = true;
				break;
			case radioButtonOption.Hard:
				radioButtonHard.Checked = true;
				break;
			case radioButtonOption.Special:
				radioButtonSpecial.Checked = true;
				textBoxWidth.Text = "" + main_form.supMatrix.n;
				textBoxHeight.Text = "" + main_form.supMatrix.m;
				textBoxMines.Text = "" + main_form.supMatrix.kol_min;
				TextBoxEnabled(true);
				break;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void buttonOk_Click(object sender, EventArgs e) {
			if (radioButtonEasy.Checked) { // Easy
				if (selectedButton != radioButtonOption.Easy) {
					main_form.selectedBatton = radioButtonOption.Easy;
					main_form.Restart(9, 9, 10);
				}
				this.Close();
			}
			else if(radioButtonMedium.Checked) { // Medium
				if(selectedButton != radioButtonOption.Medium) {
					main_form.selectedBatton = radioButtonOption.Medium;
					main_form.Restart(16, 16, 40);
				}
				this.Close();
			}
			else if(radioButtonHard.Checked) { // Hard
				if(selectedButton != radioButtonOption.Hard) {
					main_form.selectedBatton = radioButtonOption.Hard;
					main_form.Restart(30, 16, 99);
				}
				this.Close();
			}
			else if(radioButtonSpecial.Checked) { // Special
				if (ValidationFields()) {
					// cчитаем новые значения, если данные корректны
					byte new_n = Convert.ToByte(textBoxWidth.Text);
					byte new_m = Convert.ToByte(textBoxHeight.Text);
					int new_kol_min = Convert.ToInt32(textBoxMines.Text);
					if (selectedButton != radioButtonOption.Special ||
						main_form.supMatrix.n != new_n ||
						main_form.supMatrix.m != new_m ||
						main_form.supMatrix.kol_min != new_kol_min) {
						main_form.selectedBatton = radioButtonOption.Special;
						main_form.Restart(new_n, new_m, new_kol_min);
					}
					this.Close();
				}
				else {
					MessageBox.Show("Был некорректный ввод значений\n" + 
						"Проверьте правильность и повторите попытку.");
				}
			}			
		}

		// блокирование выделение полей, если не режим Special
		private void radioButtonSpecial_CheckedChanged(object sender, EventArgs e) {
			if (radioButtonSpecial.Checked) 
				TextBoxEnabled(true);
			else
				TextBoxEnabled(false);
		}
		
		// проверяет корректность данных в веденных полях, если всё норм true
		// иначе правит и false + вывод сообщения о том что исправила
		private bool ValidationFields() {
			bool correctness = true;
			int number;
			// Height
			if (int.TryParse(textBoxHeight.Text, out number)) { // проверка на число
				if (number < 5) { // проверка соблюдения границ
					correctness = false;
					textBoxHeight.Text = "5";
				}
				else if (number > 50) {
					correctness = false;
					textBoxHeight.Text = "50";
				}
			}
			else {
				correctness = false;
				textBoxHeight.Text = "10";
			}
			// Width
			if (int.TryParse(textBoxWidth.Text, out number)) { // проверка на число
				if (number < 5) { // проверка соблюдения границ
					correctness = false;
					textBoxWidth.Text = "5";
				}
				else if (number > 50) {
					correctness = false;
					textBoxWidth.Text = "50";
				}
			}
			else {
				correctness = false;
				textBoxWidth.Text = "20";
			}
			// Mines
			if(int.TryParse(textBoxMines.Text, out number)) { // проверка на число
				if(number < 5) { // проверка соблюдения границ
					correctness = false;
					textBoxMines.Text = "5";
				}
				else if(number > Math.Min((Convert.ToInt32(textBoxHeight.Text) * 
								 		  Convert.ToInt32(textBoxWidth.Text) * 0.9), 
										  (Convert.ToInt32(textBoxHeight.Text) *
										   Convert.ToInt32(textBoxWidth.Text) - 9))) {
					correctness = false;
					textBoxMines.Text = "" + (int)Math.Min((Convert.ToInt32(textBoxHeight.Text) *
															Convert.ToInt32(textBoxWidth.Text) * 0.9),
														   (Convert.ToInt32(textBoxHeight.Text) *
															Convert.ToInt32(textBoxWidth.Text) - 9));
				}
			}
			else {
				correctness = false;
				textBoxMines.Text = "10";
			}
			
			return correctness;
		}

		private void TextBoxEnabled(bool value) {
			labelHeight.Enabled = value;
			labelWidth.Enabled = value;
			labelMines.Enabled = value;
			textBoxHeight.Enabled = value;
			textBoxWidth.Enabled = value;
			textBoxMines.Enabled = value;
		}

		private void FormSettings_FormClosing(object sender, FormClosingEventArgs e) {
			main_form.Enabled = true;
		}
	}
}

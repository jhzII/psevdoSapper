﻿using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/* future:
 * Help
 * */

namespace psevdoSapper {
	public partial class Form1 : Form {
		public bool save = false; // определяет, надо ли сохранять
		public StatisticsData statistiks;
		public MatrixSapperButton supMatrix;
		public radioButtonOption selectedBatton;
		public bool startGame = false;

		public Form1() {
			InitializeComponent();
			try {
				Stream file = File.OpenRead("settimgs.txt");
				BinaryFormatter fileRead = new BinaryFormatter();
				
				SaveSetAndRez saveS_R = (SaveSetAndRez)fileRead.Deserialize(file);
				file.Close();
				
				statistiks = new StatisticsData();
				statistiks.massAllTimeData = saveS_R.Statistics;
				selectedBatton = saveS_R.selectedBatton;
				supMatrix = saveS_R.createMatrixSapperButton(this);
			}
			catch {
				supMatrix = new MatrixSapperButton(this, 16, 16, 40); // соответствует Medium
				selectedBatton = radioButtonOption.Medium;
				statistiks = new StatisticsData();
			}
						
			supMatrix.AddMatrixSapperButtonOnForm();
		}

		public void Restart(byte kol_n, byte kol_m, int k_min) {
			supMatrix.RemoveMatrixSapperButtonOnForm();
			supMatrix = new MatrixSapperButton(this, kol_n, kol_m, k_min);
			supMatrix.AddMatrixSapperButtonOnForm();
			startGame = false;
		}

		public void Defeat() {
			if(!FormDefeat.open) {
				if(selectedBatton != radioButtonOption.Special) {
					statistiks.massAllTimeData[(int)selectedBatton, 0]++;
					statistiks.massCurrentTimeData[(int)selectedBatton, 0]++;
				}
				FormDefeat defForm = new FormDefeat(this);
				defForm.Show();
			}
		}

		public void Victory() {
			if (!FormVictory.open) {
				if(selectedBatton != radioButtonOption.Special) {
					statistiks.massAllTimeData[(int)selectedBatton, 0]++;
					statistiks.massCurrentTimeData[(int)selectedBatton, 0]++;

					statistiks.massAllTimeData[(int)selectedBatton, 1]++;
					if(statistiks.massAllTimeData[(int)selectedBatton, 1] == 1)
						statistiks.massAllTimeData[(int)selectedBatton, 2] = supMatrix.seconds;
					else if(supMatrix.seconds < statistiks.massAllTimeData[(int)selectedBatton, 2])
						statistiks.massAllTimeData[(int)selectedBatton, 2] = supMatrix.seconds;

					if(statistiks.massCurrentTimeData[(int)selectedBatton, 1] == 1)
						statistiks.massCurrentTimeData[(int)selectedBatton, 2] = supMatrix.seconds;
					statistiks.massCurrentTimeData[(int)selectedBatton, 1]++;
					if(supMatrix.seconds < statistiks.massCurrentTimeData[(int)selectedBatton, 2])
						statistiks.massCurrentTimeData[(int)selectedBatton, 2] = supMatrix.seconds;
				}

				FormVictory vicForm = new FormVictory(this, supMatrix.seconds);
				vicForm.Show();
			}
		}
		
		// New game
		private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
			Restart(supMatrix.n, supMatrix.m, supMatrix.kol_min);
		}
		
		private void staticsToolStripMenuItem_Click(object sender, EventArgs e) {
			FormStatistiks StatForm = new FormStatistiks(this, statistiks, selectedBatton);
			StatForm.Show();
		}

		// Settings - вызвать окно настройки размера
		private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
			FormSettings SetForm = new FormSettings(this, selectedBatton);
			SetForm.Show();
		}

		// Help
		private void helpToolStripMenuItem_Click(object sender, EventArgs e) {
			MessageBox.Show("Oops, not ready yet");
		}

		// Exit
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		// save == true, если нужно сохранить матрицу кнопок
		private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			// если форма не открыта -- вызвать её
			if (FormClose.open) {
				BinaryFormatter formatter = new BinaryFormatter();

				using(FileStream fs = new FileStream("settimgs.txt", FileMode.OpenOrCreate)) {
					if(save) {
						SaveSetAndRez saveS_R = new SaveSetAndRez(statistiks, supMatrix, true);
						formatter.Serialize(fs, saveS_R);
					}
					else {
						if(selectedBatton != radioButtonOption.Special) {
							statistiks.massAllTimeData[(int)selectedBatton, 0]++;
							statistiks.massCurrentTimeData[(int)selectedBatton, 0]++;
						}
						SaveSetAndRez saveS_R = new SaveSetAndRez(statistiks, supMatrix);
						formatter.Serialize(fs, saveS_R);
					}
				}
			}
			else {
				e.Cancel = true;				
				if(startGame) {
					FormClose closeForm = new FormClose(this);
					closeForm.Show();
				}
				else {
					FormClose.open = true;
					Close();
				}
			}
		}
	}
}
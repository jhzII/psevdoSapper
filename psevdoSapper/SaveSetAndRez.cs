using System;

namespace psevdoSapper {

	[Serializable]
	public class SaveSetAndRez {
		public int[,] Statistics;
		public radioButtonOption selectedBatton;
		bool save; // true, если надо сохранять
		SapperButton[,] matrix;

		byte n; // количество столбцов
		byte m; // количество строк 
		int kol_min; // количество мин 		
		int kol_ost_min;  // количество мин, которые выделены
		int time;

		public SaveSetAndRez(StatisticsData statistics, MatrixSapperButton mainMatrix, bool needSave = false) {
			Statistics = statistics.massAllTimeData;
			selectedBatton = mainMatrix.form.selectedBatton;

			save = needSave;
			if (save) { // надо ли сохранять прогресс
				matrix = mainMatrix.matrix;
				n = mainMatrix.n;
				m = mainMatrix.m;
				kol_min = mainMatrix.kol_min;
				kol_ost_min = mainMatrix.kol_ost_min;
				time = mainMatrix.seconds;
			}
		}
		
		public MatrixSapperButton createMatrixSapperButton(Form1 form) {
			MatrixSapperButton matrixSB = new MatrixSapperButton(null, 0, 0, 0); // мне не нравится эта строка  

			if(save) {
				form.startGame = true;
				matrixSB = new MatrixSapperButton(form, matrix, n, m, kol_min, kol_ost_min, time);
				for(int i = 0; i < n; i++)
					for(int j = 0; j < m; j++)
						if(!matrixSB.matrix[i, j].open)
							matrixSB.matrix[i, j].MouseUp += matrixSB.OpenMove;
						else if(matrixSB.matrix[i, j].open_value != 0)
							matrixSB.matrix[i, j].MouseDoubleClick += matrixSB.HelpOpenCellsMove;
				matrixSB.TimerStart();
			}
			else {
				switch(selectedBatton) {
				case radioButtonOption.Easy:
					matrixSB = new MatrixSapperButton(form, 9, 9, 10);
					break;
				case radioButtonOption.Medium:
					matrixSB = new MatrixSapperButton(form, 16, 16, 40);
					break;
				case radioButtonOption.Hard:
					matrixSB = new MatrixSapperButton(form, 30, 16, 99);
					break;
				case radioButtonOption.Special:
					matrixSB = new MatrixSapperButton(form, n, m, kol_min);
					break;
				}
			}

			return matrixSB;
		}
	}
}

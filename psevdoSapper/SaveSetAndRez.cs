using System;

namespace psevdoSapper {

	[Serializable]
	public class SaveSetAndRez {
		public radioButtonOption selectedBatton;
		public bool save; // true, если надо сохранять
		public SapperButton[,] matrix;

		public byte n; // количество столбцов
		public byte m; // количество строк 
		public int kol_min; // количество мин 		
		public int kol_ost_min;  // количество мин, которые выделены
		
		// не надо сохранять прогресс 
		public SaveSetAndRez(radioButtonOption option, byte n, byte m, int kol_min) {
			selectedBatton = option;
			this.n = n;
			this.n = n;
			this.m = m;
			this.kol_min = kol_min;
			save = false;
		}

		// надо сохранять прогресс 
		public SaveSetAndRez(radioButtonOption option, SapperButton[,] matrix,
			byte n, byte m, int kol_min, int kol_ost_min) {
			selectedBatton = option;
			this.matrix = matrix;
			this.n = n;
			this.m = m;
			this.kol_min = kol_min;
			this.kol_ost_min = kol_ost_min;
			save = true;
		}

		public MatrixSapperButton createMatrixSapperButton(Form1 form) {
			MatrixSapperButton matrixSB = new MatrixSapperButton(null, 0, 0, 0); // мне не нравится эта строка  

			if(save) {
				form.startGame = true;
				matrixSB = new MatrixSapperButton(form, matrix, n, m, kol_min, kol_ost_min);
				for(int i = 0; i < n; i++)
					for(int j = 0; j < m; j++)
						if(!matrixSB.matrix[i, j].open)
							matrixSB.matrix[i, j].MouseUp += matrixSB.OpenMove;
						else if(matrixSB.matrix[i, j].open_value != 0)
							matrixSB.matrix[i, j].MouseDoubleClick += matrixSB.HelpOpenCellsMove;
				// то что выше оставляем, тк игра которая не начиналась, будет сохранятся с save = false
				//int kol_close = 0;
				//for(int i = 0; i < n; i++)
				//	for(int j = 0; j < m; j++)
				//		if(!matrixSB.matrix[i, j].open) kol_close++;

				//if (kol_close == n * m) { //игра не начиналась
				//	for(int i = 0; i < n; i++)
				//		for(int j = 0; j < m; j++)
				//			matrixSB.matrix[i, j].MouseUp += matrixSB.FirstMove;
				//}
				//else { //игра начиналась
				//	for(int i = 0; i < n; i++)
				//		for(int j = 0; j < m; j++)
				//			if(!matrixSB.matrix[i, j].open)
				//				matrixSB.matrix[i, j].MouseUp += matrixSB.OpenMove;
				//			else if(matrixSB.matrix[i, j].open_value != 0) 
				//				matrixSB.matrix[i, j].MouseDoubleClick += matrixSB.HelpOpenCellsMove;
				//}
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

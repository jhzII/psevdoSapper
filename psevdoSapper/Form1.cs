using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psevdoSapper {
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
			
			SapperButton[,] main_mass = SapperButton.CreateMatrixSapperButton(7, 5);
			SapperButton.AddMatrixSapperButtonOnForm(main_mass, this);
		}
	}

	// так 
	// завтра надо решить, делать ли класс управления классами или оставить со статик методами и значениями
	
	//class MatrixSapperButton {
	//	int n; // количество столбцов
	//	int m; // количество строк 
	//	bool firstMove; // флаг совершения первого хода (для формирования поля)


	//}


	public class SapperButton : Button {
		bool open; // true, если не открыта
		byte open_value; // 0 - пустая
						 // 1-8 - сколько вокруг
						 // 9 - мина
		byte close_value;   // 0 - просто
							// 1 - флаг
							// 2 - знак вопросаparameter 

		public byte Index_x { get; set; } // свойство 
		public byte Index_y { get; set; }

		static byte n; // количество столбцов
		static byte m; // количество строк 
		static byte kol_min; // количество мин 
		//	bool firstMove; // флаг совершения первого хода (для формирования поля)

		public SapperButton(byte indX, byte indY) : base() {
			Index_x = indX;
			Index_y = indY;

			// настроить размер и расположение
			// ...
			Size = new Size(25, 25);
			//Width = 10; // оч мб
			//Height = 10; // оч мб

			Location = new Point(indX * 25 + 50, indY * 25 + 50);
			//Top = indX * 10 + 15; // оч мб
			//Left = indY * 10 + 15; // оч мб

			Text = "";
		}

		// static свойства для расставления и тп
		public static SapperButton[,] CreateMatrixSapperButton(byte kol_n, byte kol_m) {
			// n - столбцов m - строк
			n = kol_n;
			m = kol_m;
			SapperButton[,] mass = new SapperButton[n, m];
			for(int i = 0; i < n; i++) {
				for(int j = 0; j < m; j++) {
					mass[i, j] = new SapperButton((byte)i, (byte)j);
				}
			}
			return mass;
		}

		public static void AddMatrixSapperButtonOnForm(SapperButton[,] matrix, Form form) {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Add(matrix[i, j]);
		}
	}


}

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

			MatrixSapperButton main_matrix = new MatrixSapperButton(9, 7, 10);
			main_matrix.AddMatrixSapperButtonOnForm(this);

			//SapperButton[,] main_mass = SapperButton.CreateMatrixSapperButton(7, 5);
			//SapperButton.AddMatrixSapperButtonOnForm(main_mass, this);
		}
	}

	// так 
	// завтра надо решить, делать ли класс управления классами или оставить со статик методами и значениями

	public class MatrixSapperButton {
		SapperButton[,] matrix; 

		byte n; // количество столбцов
		byte m; // количество строк 
		int kol_min; // количество мин 
		bool firstMove; // флаг совершения первого хода (для формирования поля)

		

		public MatrixSapperButton(byte kol_n, byte kol_m, int k_min) {
			// n - столбцов m - строк
			n = kol_n;
			m = kol_m;
			kol_min = k_min;
			matrix = new SapperButton[n, m];
			for(int i = 0; i < n; i++) {
				for(int j = 0; j < m; j++) {
					matrix[i, j] = new SapperButton((byte)i, (byte)j, this);
				}
			}
		}

		public void AddMatrixSapperButtonOnForm(Form form) {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Add(matrix[i, j]);
		}

		public void test() {
			MessageBox.Show("test");
		}

		public void InitializationField(byte ind_x, byte ind_y) {
			int kol_null_kl = 0; // сколько нужно выделить пустых клеток

			// в зависимости от расположения первой открываемой, выделяется:
			if (ind_x != 0) kol_null_kl += 2;
			if (ind_y != 0) kol_null_kl += 2;
			if (ind_x != n - 1) kol_null_kl += 2;
			if (ind_y != m - 1) kol_null_kl += 2;
			if (kol_null_kl == 8) kol_null_kl++;

			int occupied_cells = kol_min + kol_null_kl;

			// массив, где будут хранится занятые клетки
			int[] mass_oc_cells = new int[occupied_cells];

			// установка значений 'занятых клеток' // последовательность важна 
			int ind_kl = 0;

			// верхняя линия
			if(ind_y > 0 && ind_x > 0)
				mass_oc_cells[ind_kl++] = (ind_y - 1) * n + ind_x - 1;
			if(ind_y > 0)
				mass_oc_cells[ind_kl++] = (ind_y - 1) * n + ind_x;
			if(ind_y > 0 && ind_x < n - 1)
				mass_oc_cells[ind_kl++] = (ind_y - 1) * n + ind_x + 1;
			// средняя линия
			if(ind_x > 0)
				mass_oc_cells[ind_kl++] = ind_y * n + ind_x - 1;
			mass_oc_cells[ind_kl++] = ind_y * n + ind_x;
			if(ind_x < n - 1)
				mass_oc_cells[ind_kl++] = ind_y * n + ind_x + 1;
			// нижняя линия
			if(ind_y < m - 1 && ind_x > 0)
				mass_oc_cells[ind_kl++] = (ind_y + 1) * n + ind_x - 1;
			if(ind_y < m - 1)
				mass_oc_cells[ind_kl++] = (ind_y + 1) * n + ind_x;
			if(ind_y < m - 1 && ind_x < n - 1)
				mass_oc_cells[ind_kl++] = (ind_y + 1) * n + ind_x + 1;

			for(int i = kol_null_kl; i < occupied_cells; i++) {
				mass_oc_cells[i] = -1;
			}

			Random rnd = new Random();
			int rand_val;
			// цикл для расстановки мин
			for(int i = kol_null_kl; i < occupied_cells; i++) {
				rand_val = rnd.Next(n * m - i); // выбиваем значение из оставшегося кол-ва пустых клеток
				int j;
				for(j = 0; j < i; j++) { // считаем реальное место
					if(rand_val < mass_oc_cells[j]) { // поставить на место, если -1 то сдвиг не надо
						for(int k = i; k > j; k--) { // сдвиг значений мин
							mass_oc_cells[k] = mass_oc_cells[k - 1];
						}
						mass_oc_cells[j] = rand_val;
						break;
					}
					else { // увеличить значения, если есть значения меньше
						rand_val++;
					}
				}
				if(mass_oc_cells[j] == -1) { // если самое большое значение, то просто присвоить
					mass_oc_cells[j] = rand_val;
				}

				//MessageBox.Show("# " + rand_val + " - " +rand_val % n + " - " + rand_val / n);

				matrix[rand_val % n, rand_val / n].open_value = 9;  // устанавливаем значение мины
												// x = rand_val % n		// y = rand_val / n

				// temporary
				//matrix[rand_val % n, rand_val / n].Text = "9";
				// temporary
			}

			// попытка расстановки сколько мин вокруг 

			// 1 вариант
			// проверка сверху
			for(int i = 1; i < n; i++)
				for(int j = 0; j < m; j++)
					if(matrix[i, j].open_value != 9 && matrix[i - 1, j].open_value == 9)
						matrix[i, j].open_value++;
			// проверка сверху cправа
			for(int i = 1; i < n; i++)
				for(int j = 0; j < m - 1; j++)
					if(matrix[i, j].open_value != 9 && matrix[i - 1, j + 1].open_value == 9)
						matrix[i, j].open_value++;
			// проверка cправа
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m - 1; j++)
					if(matrix[i, j].open_value != 9 && matrix[i, j + 1].open_value == 9)
						matrix[i, j].open_value++;
			// проверка снизу cправа
			for(int i = 0; i < n - 1; i++)
				for(int j = 0; j < m - 1; j++)
					if(matrix[i, j].open_value != 9 && matrix[i + 1, j + 1].open_value == 9)
						matrix[i, j].open_value++;
			// проверка снизу
			for(int i = 0; i < n - 1; i++)
				for(int j = 0; j < m; j++)
					if(matrix[i, j].open_value != 9 && matrix[i + 1, j].open_value == 9)
						matrix[i, j].open_value++;
			// проверка снизу слева
			for(int i = 0; i < n - 1; i++)
				for(int j = 1; j < m; j++)
					if(matrix[i, j].open_value != 9 && matrix[i + 1, j - 1].open_value == 9)
						matrix[i, j].open_value++;
			// проверка слева
			for(int i = 0; i < n; i++)
				for(int j = 1; j < m; j++)
					if(matrix[i, j].open_value != 9 && matrix[i, j - 1].open_value == 9)
						matrix[i, j].open_value++;
			// проверка сверху слева
			for(int i = 1; i < n; i++)
				for(int j = 1; j < m; j++)
					if(matrix[i, j].open_value != 9 && matrix[i - 1, j - 1].open_value == 9)
						matrix[i, j].open_value++;

			// temporary
			//for(int i =0; i < n; i++)
			//	for(int j = 0; j < m; j++)
			//		matrix[i, j].Text = "" + matrix[i, j].open_value; // ***********************
			// temporary
			// открытть нажатую клетку
			Open_cell(ind_x, ind_y);

			// убрать обработчик первого хода
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++) {
					matrix[i, j].Click -= matrix[i, j].FirstMove;
					matrix[i, j].Click += matrix[i, j].OpenMove;
				}
		}

		public void Open_cell(byte ind_x, byte ind_y) {
			if (matrix[ind_x, ind_y].open_value == 9) {
				MessageBox.Show("defeat");
			}
			else if(matrix[ind_x, ind_y].open_value == 0) {
				matrix[ind_x, ind_y].open = true;
				matrix[ind_x, ind_y].Text = "0";
				// пытаемся открыть соседние, если они есть
				// верхняя линия
				if(ind_y > 0 && ind_x > 0 && !matrix[ind_x - 1, ind_y - 1].open)
					Open_cell((byte)(ind_x - 1), (byte)(ind_y - 1));
				if(ind_y > 0 && !matrix[ind_x, ind_y - 1].open)
					Open_cell(ind_x, (byte)(ind_y - 1));
				if(ind_y > 0 && ind_x < n - 1 && !matrix[ind_x + 1, ind_y - 1].open)
					Open_cell((byte)(ind_x + 1), (byte)(ind_y - 1));
				// средняя линия
				if(ind_x > 0 && !matrix[ind_x - 1, ind_y].open)
					Open_cell((byte)(ind_x - 1), ind_y);
				if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y].open)
					Open_cell((byte)(ind_x + 1), ind_y);
				// нижняя линия
				if(ind_y < m - 1 && ind_x > 0 && !matrix[ind_x - 1, ind_y + 1].open)
					Open_cell((byte)(ind_x - 1), (byte)(ind_y + 1));
				if(ind_y < m - 1 && !matrix[ind_x, ind_y + 1].open)
					Open_cell(ind_x, (byte)(ind_y + 1));
				if(ind_y < m - 1 && ind_x < n - 1 && !matrix[ind_x + 1, ind_y + 1].open)
					Open_cell((byte)(ind_x + 1), (byte)(ind_y + 1));
			}
			else {
				matrix[ind_x, ind_y].open = true;
				matrix[ind_x, ind_y].Text = "" + matrix[ind_x, ind_y].open_value;
			}

		}
	}


	public class SapperButton : Button {
		public bool open; // true, если не открыта
		public byte open_value; // 0 - пустая
						 // 1-8 - сколько вокруг
						 // 9 - мина
		byte close_value;   // 0 - просто
							// 1 - флаг
							// 2 - знак вопросаparameter 

		public byte Index_x { get; set; } // свойство 
		public byte Index_y { get; set; }

		MatrixSapperButton belongs_matrix; // какой матрице принадлежит 

		//static byte n; // количество столбцов
		//static byte m; // количество строк 
		//static byte kol_min; // количество мин 
		//	bool firstMove; // флаг совершения первого хода (для формирования поля)

		public SapperButton(byte indX, byte indY, MatrixSapperButton matrix) : base() {
			belongs_matrix = matrix;
			Index_x = indX;
			Index_y = indY;

			// настроить размер и расположение
			// ...
			Size = new Size(25, 25);
			Location = new Point(indX * 25 + 50, indY * 25 + 50);
			Text = "";

			Click += FirstMove;

			// знач по умолчанию
			open = false;
			open_value = 0;
			close_value = 0;
		}

		public void FirstMove(object sender, EventArgs eventArgs) {
			SapperButton button = sender as SapperButton;
			if (button != null) {
				//MessageBox.Show("FirstMove " + button.Index_x + " - " + button.Index_y);

				// устанавливаем мины // удалить первый ход
				// добавить открытие  // вызвать открытие от этой кнопки
				button.belongs_matrix.InitializationField(button.Index_x, button.Index_y);
				

			}
		}

		public void OpenMove(object sender, EventArgs eventArgs) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				if(!button.open)
					button.belongs_matrix.Open_cell(button.Index_x, button.Index_y);
			}
		}		
	}
}
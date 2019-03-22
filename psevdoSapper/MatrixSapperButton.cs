using System;
using System.Drawing;
using System.Windows.Forms;

namespace psevdoSapper {
	public class MatrixSapperButton {
		public Form1 form;
		public SapperButton[,] matrix { get; private set; }

		public byte n { get; private set; } // byte n; // количество столбцов
		public byte m { get; private set; } // byte m; // количество строк 
		public int kol_min { get; private set; } // int kol_min; // количество мин 		
		public int kol_ost_min;  // количество мин, которые выделены

		Timer timer;
		public int seconds; // время прохождения игры 

		public MatrixSapperButton(Form1 form, byte kol_n, byte kol_m, int k_min) {
			InitializeTimer();
			this.form = form;
			// n - столбцов m - строк
			n = kol_n;
			m = kol_m;
			kol_min = kol_ost_min = k_min;
			matrix = new SapperButton[n, m];
			for(int i = 0; i < n; i++) {
				for(int j = 0; j < m; j++) {
					matrix[i, j] = new SapperButton((byte)i, (byte)j);
					matrix[i, j].MouseUp += FirstMove;
				}
			}
		}

		public MatrixSapperButton(Form1 form, SapperButton[,] matrix, byte kol_n, 
								  byte kol_m, int k_min, int kol_ost_min) {
			InitializeTimer();
			this.form = form;
			// n - столбцов m - строк
			n = kol_n;
			m = kol_m;
			kol_min = k_min;
			this.kol_ost_min = kol_ost_min;
			this.matrix = matrix;
		}

		public void AddMatrixSapperButtonOnForm() {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Add(matrix[i, j]);
			form.MinimumSize = new Size(100 + 24 * (n + 1) + 1, 120 + 24 * (m + 1) + 1);
			form.MaximumSize = form.MinimumSize;
			form.Size = form.MinimumSize;
			// позиционирование счетчика
			form.label_kol_min.Location = new Point(form.Width - 120, form.Height - 60);
			form.label_kol_min.Text = kol_ost_min + " mines left";
			form.labelTime.Location = new Point(40, form.Height - 60);
			form.labelTime.Text = "Time: " + seconds;
		}

		public void RemoveMatrixSapperButtonOnForm() {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Remove(matrix[i, j]);
		}


		public void FirstMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				form.ActiveControl = form.label_kol_min; // убрать фокус
				InitializationField(button.Index_x, button.Index_y);
				timer.Start();
			}
		}

		public void OpenMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				form.ActiveControl = form.label_kol_min; // убрать фокус
				switch(e.Button) {
				case MouseButtons.Left:
					if(!button.open && button.close_value != Close.Flag)
						Open_cell(button.Index_x, button.Index_y);
					break;
				case MouseButtons.Right:
					if(!button.open)
						kol_ost_min = button.ChengeCloseValue(kol_ost_min);
					form.label_kol_min.Text = kol_ost_min + " mines left";
					break;
				}
			}
		}

		// помощь открытия очевдных клеток без мин -- мб поражение
		public void HelpOpenCellsMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				form.ActiveControl = form.label_kol_min; // убрать фокус
				HelpOpenCells(button.Index_x, button.Index_y);
			}
		}

		// устанавливаем мины // удалить первый ход
		// добавить открытие  // вызвать открытие от этой кнопки
		void InitializationField(byte ind_x, byte ind_y) {
			form.startGame = true;
			int kol_null_kl = 0; // сколько нужно выделить пустых клеток

			// в зависимости от расположения первой открываемой, выделяется:
			if(ind_x != 0)
				kol_null_kl += 2;
			if(ind_y != 0)
				kol_null_kl += 2;
			if(ind_x != n - 1)
				kol_null_kl += 2;
			if(ind_y != m - 1)
				kol_null_kl += 2;
			if(kol_null_kl == 8)
				kol_null_kl++;

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
			}

			// попытка подсчета сколько мин вокруг 
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

			// открытть нажатую клетку
			Open_cell(ind_x, ind_y);

			// убрать обработчик первого хода
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++) {
					matrix[i, j].MouseUp -= FirstMove;
					matrix[i, j].MouseUp += OpenMove;
				}
		}

		private void Open_cell(byte ind_x, byte ind_y) {
			if(matrix[ind_x, ind_y].open_value == 9) { // открыли мину
				timer.Stop();
				showMines();
				form.Defeat();
				return;
			}
			else if(matrix[ind_x, ind_y].open_value == 0) { // открыли пустую клетку
				matrix[ind_x, ind_y].open = true;
				matrix[ind_x, ind_y].BackColor = Color.FromArgb(0xF6, 0xF6, 0xF6);
				matrix[ind_x, ind_y].Text = ""; // = "0";
				matrix[ind_x, ind_y].FlatStyle = FlatStyle.Flat;

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
			else { // открыли клетку с цифрой
				matrix[ind_x, ind_y].open = true;
				matrix[ind_x, ind_y].BackColor = Color.FromArgb(0xF6, 0xF6, 0xF6);
				matrix[ind_x, ind_y].Text = "" + matrix[ind_x, ind_y].open_value;
				matrix[ind_x, ind_y].FlatStyle = FlatStyle.Flat;
				matrix[ind_x, ind_y].MouseUp -= OpenMove;
				matrix[ind_x, ind_y].MouseDoubleClick += HelpOpenCellsMove;
				switch(matrix[ind_x, ind_y].open_value) {
				case 1:
					matrix[ind_x, ind_y].ForeColor = Color.FromArgb(0x40, 0x50, 0xBE);
					break;
				case 2:
					matrix[ind_x, ind_y].ForeColor = Color.FromArgb(0x1D, 0x69, 0x05);
					break;
				case 3:
					matrix[ind_x, ind_y].ForeColor = Color.FromArgb(0xAD, 0x02, 0x08);
					break;
				case 4:
					matrix[ind_x, ind_y].ForeColor = Color.FromArgb(0x04, 0x08, 0x8A);
					break;
				default:
					matrix[ind_x, ind_y].ForeColor = Color.FromArgb(0x75, 0x06, 0x00);
					break;
				}
			}
			if(CheckVictory()) { // проверка на победу
				timer.Stop();
				form.label_kol_min.Text = "0 mines left";
				form.Victory();
				return;
			}
		}

		// помощь открытия очевдных клеток без мин -- мб поражение 
		void HelpOpenCells(byte ind_x, byte ind_y) {
			sbyte dif_min = 0;  // if мина -- увеличиваем значение
								// if отметка -- уменьшаем значение
								// if kol_min == 0 -- количество совпало

			// проверка по верхней линии
			if(ind_y > 0) {
				if(ind_x > 0 && !matrix[ind_x - 1, ind_y - 1].open) {
					if(matrix[ind_x - 1, ind_y - 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x - 1, ind_y - 1].close_value == Close.Flag)
						dif_min--;
				}
				if(!matrix[ind_x, ind_y - 1].open) {
					if(matrix[ind_x, ind_y - 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x, ind_y - 1].close_value == Close.Flag)
						dif_min--;
				}
				if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y - 1].open) {
					if(matrix[ind_x + 1, ind_y - 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x + 1, ind_y - 1].close_value == Close.Flag)
						dif_min--;
				}
			}
			// проверка по средней линии
			if(ind_x > 0 && !matrix[ind_x - 1, ind_y].open) {
				if(matrix[ind_x - 1, ind_y].open_value == 9)
					dif_min++;
				if(matrix[ind_x - 1, ind_y].close_value == Close.Flag)
					dif_min--;
			}
			if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y].open) {
				if(matrix[ind_x + 1, ind_y].open_value == 9)
					dif_min++;
				if(matrix[ind_x + 1, ind_y].close_value == Close.Flag)
					dif_min--;
			}
			// проверка по нижней линии
			if(ind_y < m - 1) {
				if(ind_x > 0 && !matrix[ind_x - 1, ind_y + 1].open) {
					if(matrix[ind_x - 1, ind_y + 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x - 1, ind_y + 1].close_value == Close.Flag)
						dif_min--;
				}
				if(!matrix[ind_x, ind_y + 1].open) {
					if(matrix[ind_x, ind_y + 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x, ind_y + 1].close_value == Close.Flag)
						dif_min--;
				}
				if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y + 1].open) {
					if(matrix[ind_x + 1, ind_y + 1].open_value == 9)
						dif_min++;
					if(matrix[ind_x + 1, ind_y + 1].close_value == Close.Flag)
						dif_min--;
				}
			}

			// Если dif_min == 0 => отмечено нужное количество мин => открываем
			if(dif_min == 0) {
				// открытие по верхней линии
				if(ind_y > 0) {
					if(ind_x > 0 && !matrix[ind_x - 1, ind_y - 1].open &&
						matrix[ind_x - 1, ind_y - 1].close_value != Close.Flag)
						Open_cell((byte)(ind_x - 1), (byte)(ind_y - 1));
					if(!matrix[ind_x, ind_y - 1].open &&
						matrix[ind_x, ind_y - 1].close_value != Close.Flag)
						Open_cell(ind_x, (byte)(ind_y - 1));
					if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y - 1].open &&
						matrix[ind_x + 1, ind_y - 1].close_value != Close.Flag)
						Open_cell((byte)(ind_x + 1), (byte)(ind_y - 1));
				}
				// открытие по средней линии
				if(ind_x > 0 && !matrix[ind_x - 1, ind_y].open &&
					matrix[ind_x - 1, ind_y].close_value != Close.Flag)
					Open_cell((byte)(ind_x - 1), ind_y);
				if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y].open &&
					matrix[ind_x + 1, ind_y].close_value != Close.Flag)
					Open_cell((byte)(ind_x + 1), ind_y);
				// открытие по нижней линии
				if(ind_y < m - 1) {
					if(ind_x > 0 && !matrix[ind_x - 1, ind_y + 1].open &&
						matrix[ind_x - 1, ind_y + 1].close_value != Close.Flag)
						Open_cell((byte)(ind_x - 1), (byte)(ind_y + 1));
					if(!matrix[ind_x, ind_y + 1].open &&
						matrix[ind_x, ind_y + 1].close_value != Close.Flag)
						Open_cell(ind_x, (byte)(ind_y + 1));
					if(ind_x < n - 1 && !matrix[ind_x + 1, ind_y + 1].open &&
						matrix[ind_x + 1, ind_y + 1].close_value != Close.Flag)
						Open_cell((byte)(ind_x + 1), (byte)(ind_y + 1));
				}
			}

		}

		private void showMines() {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < n; j++)
					if(matrix[i, j].open_value == 9)
						matrix[i, j].BackgroundImage = Image.FromFile("../../images/mine.png");
		}

		private bool CheckVictory() {
			int kol_close = 0;
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					if(!matrix[i, j].open)
						kol_close++;
			return (kol_close == kol_min);
		}

		private void InitializeTimer() {
			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += TickTimer;
		}

		private void TickTimer(object sender, EventArgs e) {
			seconds++;
			form.labelTime.Text = "Time: " + seconds;
		}
	}
}

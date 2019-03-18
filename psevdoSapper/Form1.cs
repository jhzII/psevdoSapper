using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* future:
 * нельзя открывать доп формы, если откырта другая 
 * открытие очевидно доступных, при двойном клике
 * Вывод количества оставшегося количества мин
 * приемлимый внешний вид
 * Help
 * */

namespace psevdoSapper {
	public partial class Form1 : Form {
		public MatrixSapperButton supMatrix;
		public radioButtonOption selectedBatton;
		//public Form1 form;
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
			FormDefeat defForm = new FormDefeat(this); //////////////////////////
			defForm.Show();
		}

		public void Victory() {
			if (!FormVictory.open) {
				FormVictory vicForm = new FormVictory(this); //////////////////////////
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

	// размер клетки 20х20

	public class MatrixSapperButton {
		Form1 form;
		SapperButton[,] matrix;

		public byte n { get; private set; } // byte n; // количество столбцов
		public byte m { get; private set; } // byte m; // количество строк 
		public int kol_min { get; private set; } // int kol_min; // количество мин 		
		int kol_vid_min = 0; // количество мин, которые выделены

		public MatrixSapperButton(Form1 form, byte kol_n, byte kol_m, int k_min) {
			this.form = form;
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

		public void AddMatrixSapperButtonOnForm() {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Add(matrix[i, j]);
			form.MinimumSize = new Size(100 + 20 * (n + 1), 120 + 20 * (m + 1));
			form.MaximumSize = form.MinimumSize;
			form.Size = form.MinimumSize;
		}

		public void RemoveMatrixSapperButtonOnForm() {
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++)
					form.Controls.Remove(matrix[i, j]);
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
					matrix[i, j].MouseUp -= matrix[i, j].FirstMove;
					matrix[i, j].MouseUp += matrix[i, j].OpenMove;
				}
		}

		public void Open_cell(byte ind_x, byte ind_y) {
			if (matrix[ind_x, ind_y].open_value == 9) { // открыли мину
				form.Defeat();
				return;
			}
			else if(matrix[ind_x, ind_y].open_value == 0) { // открыли пустую клетку
				matrix[ind_x, ind_y].open = true;
				matrix[ind_x, ind_y].BackColor = Color.FromArgb(0xF6, 0xF6, 0xF6);
				matrix[ind_x, ind_y].Text = ""; // = "0";
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
				matrix[ind_x, ind_y].MouseUp -= matrix[ind_x, ind_y].OpenMove;
				matrix[ind_x, ind_y].MouseDoubleClick += matrix[ind_x, ind_y].HelpOpenCellsMove;
			}
			if(CheckVictory()) { // проверка на победу
				form.Victory();
				return;
			} 
		}

		// помощь открытия очевдных клеток без мин -- мб поражение 
		public void HelpOpenCells(byte ind_x, byte ind_y) {
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
			if(ind_x > n - 1 && !matrix[ind_x + 1, ind_y].open) {
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
			if (dif_min == 0) {
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

		public bool CheckVictory() {
			int kol_close = 0;
			for(int i = 0; i < n; i++)
				for(int j = 0; j < m; j++) 
					if(!matrix[i, j].open) kol_close++;
			return (kol_close == kol_min);
		}
	}

	public enum Close { Close, Flag, Question };

	public class SapperButton : Button {
		public bool open; // true, если открыта
		public byte open_value; // 0 - пустая
								// 1-8 - сколько вокруг
								// 9 - мина
		
		public Close close_value;   // 0 - просто	// 1 - флаг // 2 - знак вопроса

		public byte Index_x { get; private set; } // свойство 
		public byte Index_y { get; private set; }

		MatrixSapperButton belongs_matrix; // какой матрице принадлежит 
		
		public SapperButton(byte indX, byte indY, MatrixSapperButton matrix) : base() {
			//Включаем опцию даблклика на кнопках
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);

			belongs_matrix = matrix;
			Index_x = indX;
			Index_y = indY;

			// настроить размер и расположение
			Size = new Size(20, 20);
			Location = new Point(indX * 20 + 50, indY * 20 + 50);
			BackColor = Color.FromArgb(0xE0, 0xE0, 0xE0);
			Text = "";
			
			MouseUp += FirstMove;

			// знач по умолчанию
			open = false;
			open_value = 0;
			close_value = Close.Close;
		}

		public void FirstMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if (button != null) {
				// устанавливаем мины // удалить первый ход
				// добавить открытие  // вызвать открытие от этой кнопки
				button.belongs_matrix.InitializationField(button.Index_x, button.Index_y);
			}
		}

		public void OpenMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				switch(e.Button) {
				case MouseButtons.Left:
					if(!button.open && button.close_value != Close.Flag)
						button.belongs_matrix.Open_cell(button.Index_x, button.Index_y);
					break;
				case MouseButtons.Right:
					if(!button.open)
						ChengeCloseValue();
					break;
				}
			}
		}
		
		// помощь открытия очевдных клеток без мин -- мб поражение 
		// CЮДА вызов, а реализацию в том классе 
		public void HelpOpenCellsMove(object sender, MouseEventArgs e) {
			SapperButton button = sender as SapperButton;
			if(button != null) {
				button.belongs_matrix.HelpOpenCells(button.Index_x, button.Index_y);
			}
		}

		private void ChengeCloseValue() {
			close_value = (close_value == Close.Question) ? 0 : close_value + 1;
			switch(close_value) {
			case Close.Close:
				Text = "";
				break;
			case Close.Flag:
				Text = "!";
				break;
			case Close.Question:
				Text = "?";
				break;
			}
		}
	}
}
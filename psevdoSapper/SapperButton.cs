using System;
using System.Drawing;
using System.Windows.Forms;

namespace psevdoSapper {
	public enum Close { Close, Flag, Question };

	public class SapperButton : Button {
		public bool open; // true, если открыта
		public byte open_value; // 0 - пустая
								// 1-8 - сколько вокруг
								// 9 - мина
		public Close close_value;   // 0 - просто	// 1 - флаг // 2 - знак вопроса

		public byte Index_x { get; private set; } // свойство
		public byte Index_y { get; private set; }

		public SapperButton(byte indX, byte indY) : base() {
			//Включаем опцию даблклика на кнопках
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);

			Index_x = indX;
			Index_y = indY;

			// настроить размер и расположение
			Size = new Size(25, 25);
			Location = new Point(indX * 24 + 50, indY * 24 + 50);
			Text = "";
			Font = new Font("GenericSansSerif", 9, FontStyle.Bold);
			FlatStyle = FlatStyle.Flat;
			BackColor = Color.FromArgb(0xE0, 0xE0, 0xE0);
			FlatAppearance.BorderColor = Color.FromArgb(0x68, 0x68, 0x68);

			// знач по умолчанию
			open = false;
			open_value = 0;
			close_value = Close.Close;
		}

		public int ChengeCloseValue(int kMin) {
			close_value = (close_value == Close.Question) ? 0 : close_value + 1;
			switch(close_value) {
			case Close.Close:
				Text = "";
				break;
			case Close.Flag:
				Text = "F";
				ForeColor = Color.FromArgb(0xFF, 0x00, 0x00);
				kMin--;
				break;
			case Close.Question:
				Text = "?";
				ForeColor = Color.FromArgb(0x35, 0x35, 0x35);
				kMin++;
				break;
			}
			return kMin;
		}
	}
}

using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace psevdoSapper {
	public enum Close { Close, Flag, Question };

	[Serializable]
	public class SapperButton : Button, ISerializable {
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
			BackColor = Color.FromArgb(0xDE, 0xDE, 0xDE);
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
				BackgroundImage = Image.FromFile("../../images/flag.bmp");
				kMin--;
				break;
			case Close.Question:
				BackgroundImage = null;
				Text = "?";
				ForeColor = Color.FromArgb(0x35, 0x35, 0x35);
				kMin++;
				break;
			}
			return kMin;
		}

		protected SapperButton(SerializationInfo info, StreamingContext context):base()
        {
			this.open = (bool)info.GetValue("open", typeof(bool));
			this.open_value = (byte)info.GetValue("open_value", typeof(byte));
			this.close_value = (Close)info.GetValue("close_value", typeof(Close));
			this.Index_x = (byte)info.GetValue("Index_x", typeof(byte));
			this.Index_y = (byte)info.GetValue("Index_y", typeof(byte));

			this.ForeColor = (Color)info.GetValue("ForeColor", typeof(Color));
			this.Text = info.GetString("Text");
			this.FlatStyle = (FlatStyle)info.GetValue("FlatStyle", typeof(FlatStyle));
			this.BackColor = (Color)info.GetValue("BackColor", typeof(Color));
			
			this.Enabled = (bool)info.GetValue("Enable", typeof(bool));

			//Включаем опцию даблклика на кнопках
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
			Size = new Size(25, 25);
			Location = new Point(Index_x * 24 + 50, Index_y * 24 + 50);
			Font = new Font("GenericSansSerif", 9, FontStyle.Bold);
			//FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderColor = Color.FromArgb(0x68, 0x68, 0x68);
			if(close_value == Close.Flag)
				BackgroundImage = Image.FromFile("../../images/flag.bmp");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("open", this.open);
			info.AddValue("open_value", this.open_value);
			info.AddValue("close_value", this.close_value);
			info.AddValue("Index_x", this.Index_x);
			info.AddValue("Index_y", this.Index_y);

			info.AddValue("ForeColor", this.ForeColor);
			info.AddValue("Text", this.Text);
			info.AddValue("FlatStyle", this.FlatStyle);
			info.AddValue("BackColor", this.BackColor);
			
			info.AddValue("Enable", this.Enabled);
			//throw new NotImplementedException();
		}
	}
}

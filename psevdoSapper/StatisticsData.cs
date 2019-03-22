using System;

namespace psevdoSapper {
	[Serializable]
	public class StatisticsData {
		// статистика за всё время
		public int[,] massAllTimeData = new int[3, 3];
		// статистика за текущий сеанс
		public int[,] massCurrentTimeData = new int[3, 3];
			// [i, 0] == всего игр
			// [i, 1] == побед
			// [i, 0] == лучшее время
		
		public int getAvergeValueByMode(radioButtonOption mode, bool AllTimes) {
			return (AllTimes) ? (massAllTimeData[(int)mode, 1] / massAllTimeData[(int)mode, 0] * 100) :
				(massCurrentTimeData[(int)mode, 1] / massCurrentTimeData[(int)mode, 0] * 100);
		}
	}
}

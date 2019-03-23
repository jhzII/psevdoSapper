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
		
		public int getAvergeValueByMode(int mode, bool AllTimes) {
			return (AllTimes) ?
				((massAllTimeData[mode, 0] == 0) ?
					0 : (100 * massAllTimeData[mode, 1] / massAllTimeData[mode, 0])) :
				((massCurrentTimeData[mode, 0] == 0) ?
					0 : (100 * massCurrentTimeData[mode, 1] / massCurrentTimeData[mode, 0]));
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入命名空間
	public class WaveDataStructure                                              //	WaveDataStructure類別
	{                                                                           //	進入WaveDataStructure類別
		public int[] WaveRawData;
		public WaveDataStructure(int InitialSize)                               //	WaveDataStructure建構子
		{                                                                       //	進入WaveDataStructure建構子
			Array.Resize<int>(ref WaveRawData, InitialSize);
		}                                                                       //	結束WaveDataStructure建構子
	}                                                                           //	結束WaveDataStructure類別
}																				//	結束命名空間

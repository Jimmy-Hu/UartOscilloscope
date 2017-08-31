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
		public WaveDataStructure()
		{
			Array.Resize<int>(ref WaveRawData, OscilloscopeFunctionVariable.Get_ADC_Raw_Data_Max());
		}
	}                                                                           //	結束WaveDataStructure類別
}																				//	結束命名空間

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入命名空間
	public class WaveDataStructure                                              //	WaveDataStructure類別
	{                                                                           //	進入WaveDataStructure類別
		/// <summary>
		/// WaveRawData陣列用於儲存感測通道資料，資料以環型方式寫入更新
		/// </summary>
		public int[] WaveRawData;                                               //	宣告WaveRawData資料儲存陣列
		private int NewDataIndex;												//	宣告NewDataIndex，記錄下一筆資料儲存位址
		/// <summary>
		/// WaveDataStructure建構子，初始化資料陣列
		/// </summary>
		/// <param name="InitialSize">變數用於給定資料陣列初始大小</param>
		public WaveDataStructure(int InitialSize)                               //	WaveDataStructure建構子
		{                                                                       //	進入WaveDataStructure建構子
			ResizeArray(InitialSize);
		}                                                                       //	結束WaveDataStructure建構子
		public void ResizeArray(int NewSize)                                    //	ResizeArray方法
		{                                                                       //	進入ResizeArray方法
			Array.Resize<int>(ref WaveRawData, NewSize);                        //	調整陣列大小
		}                                                                       //	結束ResizeArray方法
	}                                                                           //	結束WaveDataStructure類別
}																				//	結束命名空間

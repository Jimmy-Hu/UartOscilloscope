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
		private int[] WaveRawData;                                              //	宣告WaveRawData資料儲存陣列
		private int NewDataIndex;												//	宣告NewDataIndex，記錄下一筆資料儲存位址
		/// <summary>
		/// WaveDataStructure建構子，初始化資料陣列
		/// </summary>
		/// <param name="InitialSize">變數用於給定資料陣列初始大小</param>
		public WaveDataStructure(int InitialSize)                               //	WaveDataStructure建構子
		{                                                                       //	進入WaveDataStructure建構子
			ResizeArray(InitialSize);                                           //	呼叫ResizeArray方法
			this.NewDataIndex = -1;                                             //	給定NewDataIndex初始值
		}                                                                       //	結束WaveDataStructure建構子
		/// <summary>
		/// ResizeArray方法用於調整資料陣列大小
		/// </summary>
		/// <param name="NewSize"></param>
		public void ResizeArray(int NewSize)                                    //	ResizeArray方法
		{                                                                       //	進入ResizeArray方法
			Array.Resize<int>(ref WaveRawData, NewSize);                        //	調整陣列大小
			for(int Loopnum = 0; Loopnum < WaveRawData.Length; Loopnum++)		//	以for迴圈初始化資料內容
			{                                                                   //	進入for迴圈
				WaveRawData[Loopnum] = 0;										//	初始化資料為0
			}                                                                   //	結束for迴圈
			NewDataIndex = -1;                                                  //	重新定位下一筆資料儲存位址
		}                                                                       //	結束ResizeArray方法
		/// <summary>
		/// AddData方法用於新增資料至陣列空間
		/// </summary>
		/// <param name="InputData"></param>
		public void AddData(int InputData)                                      //	AddData方法
		{                                                                       //	進入AddData方法
			WaveRawData[NextIndex()] = InputData;								//	將資料填入陣列空間
		}                                                                       //	結束AddData方法
		/// <summary>
		/// NextIndex方法用於取得填入下一筆陣列資料之位置
		/// </summary>
		/// <returns>回傳值為填入下一筆陣列資料之位置</returns>
		private int NextIndex()                                                 //	NextIndex方法
		{                                                                       //	進入NextIndex方法
			int OutputIndex;                                                    //	宣告OutputIndex區域變數
			OutputIndex = (NewDataIndex + 1) % WaveRawData.Length;				//	取出填入下一筆陣列資料之位置
			return OutputIndex;                                                 //	回傳OutputIndex區域變數
		}                                                                       //	結束NextIndex方法
		public override string ToString()                                       //	覆寫ToString方法
		{                                                                       //	進入覆寫ToString方法
			string OutputString = "";                                           //	宣告OutputString(輸出字串結果)
			foreach (int item in WaveRawData)                                   //	以foreach依序列出Name內容
			{                                                                   //	進入foreach敘述
				OutputString = OutputString + item.ToString() + '\n';           //	填入內容至輸出字串
			}                                                                   //	結束foreach敘述
			return OutputString;                                                //	回傳OutputString
		}                                                                       //	結束覆寫ToString方法
	}                                                                           //	結束WaveDataStructure類別
}																				//	結束命名空間

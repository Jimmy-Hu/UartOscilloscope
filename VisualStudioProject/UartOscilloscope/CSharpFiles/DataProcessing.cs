using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                                                     //	使用System.Windows.Forms函式庫

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入命名空間
	public class DataProcessing                                                 //	DataProcessing類別
	{                                                                           //	進入DataProcessing類別
		public char[] String2CharArray(string InputData)                        //	String2CharArray方法
		{                                                                       //	進入String2CharArray方法
			char[] OutputData = InputData.ToCharArray();                        //	宣告OutputData
			return OutputData;													//	回傳轉換結果
		}                                                                       //	結束String2CharArray方法
	}                                                                           //	結束DataProcessing類別
}                                                                               //	結束命名空間

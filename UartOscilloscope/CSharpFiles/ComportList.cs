using System;
using System.Collections.Generic;
/*	串列埠(Comport)物件宣告於System.IO.Ports函式庫中
 */
using System.IO.Ports;                                                          //	使用System.IO.Ports函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	public class ComportList													//	ComportList類別
	{                                                                           //	進入ComportList類別
		private string[] Name;                                                  //	宣告Name字串陣列
		public ComportList(string[] Name)                                       //	ComportList建構子
		{                                                                       //	進入ComportList建構子
			this.Name = Name;													//	初始化內部物件
		}                                                                       //	結束ComportList建構子
		public string[] GetComportList()                                        //	GetComportList方法
		{                                                                       //	進入GetComportList方法
			return Name;                                                        //	回傳Name
		}                                                                       //	結束GetComportList方法
		public void UpdateComportList(string[] ComportList)                     //	UpdateComportList方法
		{                                                                       //	進入UpdateComportList方法
			Name = ComportList;													//	填入資料
		}                                                                       //	結束UpdateComportList方法
		/// <summary>
		/// 複寫ToString方法，以foreach依序列出comport
		/// </summary>
		/// <returns></returns>
		public override string ToString()                                       //	覆寫ToString方法
		{                                                                       //	進入覆寫ToString方法
			string OutputString = "";                                           //	宣告OutputString(輸出字串結果)
			foreach (string item in Name)                                       //	以foreach依序列出Name內容
			{                                                                   //	進入foreach敘述
				OutputString = OutputString + item + '\n';						//	填入內容至輸出字串
			}                                                                   //	結束foreach敘述
			return OutputString;                                                //	回傳OutputString
		}                                                                       //	結束覆寫ToString方法
	}                                                                           //	結束ComportList類別
}                                                                               //	結束UartOscilloscope命名空間

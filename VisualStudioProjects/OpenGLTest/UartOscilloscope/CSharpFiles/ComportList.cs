using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	/// <summary>
	/// ComportList類別單純為一字串陣列容器，可透過UpdateComportList方法新增Comport名稱
	/// </summary>
	public class ComportList													//	ComportList類別
	{                                                                           //	進入ComportList類別
		private string[] Name;                                                  //	宣告Name字串陣列
		/// <summary>
		/// ComportList建構子
		/// </summary>
		/// <param name="Name"></param>
		public ComportList(string[] Name)                                       //	ComportList建構子
		{                                                                       //	進入ComportList建構子
			this.Name = Name;													//	初始化內部物件
		}                                                                       //	結束ComportList建構子
		/// <summary>
		/// GetComportList方法用於取得Comport列表
		/// </summary>
		/// <returns></returns>
		public string[] GetComportList()                                        //	GetComportList方法
		{                                                                       //	進入GetComportList方法
			return Name;                                                        //	回傳Name
		}                                                                       //	結束GetComportList方法
		/// <summary>
		/// UpdateComportList用於更新ComportList內部物件資料
		/// </summary>
		/// <param name="ComportList"></param>
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

		/// <summary>
		/// IsComportListNull方法用於檢測ComportList是否為空
		/// </summary>
		/// <returns>若未偵測到Comport回傳true，否則回傳false</returns>
		public bool IsComportListNull()                                         //	IsComportListNull方法
		{                                                                       //	進入IsComportListNull方法
			if(Name.Length == 0)                                                //	若未偵測到Comport
			{																	//	進入if敘述
				return true;													//	回傳true
			}                                                                   //	結束if敘述
			else                                                                //	若偵測到Comport
			{																	//	進入else敘述
				return false;													//	回傳false
			}																	//	結束else敘述
		}                                                                       //	結束IsComportListNull方法
	}                                                                           //	結束ComportList類別
}                                                                               //	結束UartOscilloscope命名空間

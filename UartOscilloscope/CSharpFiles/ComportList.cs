using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class ComportList                                                           //	ComportList類別
	{                                                                           //	進入ComportList類別
		private string[] Name;                                                  //	宣告Name字串陣列
		public string[] GetComportList()                                        //	GetComportList方法
		{                                                                       //	進入GetComportList方法
			return Name;                                                        //	回傳Name
		}                                                                       //	結束GetComportList方法
		public void SetComportList(string[] ComportList)                        //	SetComportList方法
		{                                                                       //	進入SetComportList方法
			Name = ComportList;													//	填入資料
		}                                                                       //	結束SetComportList方法
	}                                                                           //	結束ComportList類別
}                                                                               //	結束UartOscilloscope命名空間

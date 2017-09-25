using System;                                                                   //	使用System函式庫
using System.Collections.Generic;                                               //	使用System.Collections.Generic函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class CommandDatabase                                                       //	CommandDatabase類別
	{                                                                           //	進入CommandDatabase類別
		List<CommandClass> CommandSet = new List<CommandClass>();               //	宣告CommandSet
		public CommandDatabase()                                                //	CommandDatabase建構子
		{                                                                       //	進入CommandDatabase建構子
			CommandSet.Add(new CommandClass(                                    //	新增指令
				1,                                                              //	指令編號
				"help",															//	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容
					
					
				})));                                                           //	結束指令工作內容
			CommandSet.Add(new CommandClass(                                    //	新增指令
				1,                                                              //	指令編號
				"lscom",                                                        //	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容
					UARTConnection UARTConnection1;                             //	宣告UARTConnection1物件
					UARTConnection1 = new UARTConnection(0, false);
					Console.WriteLine(UARTConnection1.GetComportList().ToString());
				})));                                                           //	結束指令工作內容
		}                                                                       //	結束CommandDatabase建構子
		public override string ToString()
		{
			return base.ToString();
		}
	}                                                                           //	結束CommandDatabase類別
}                                                                               //	結束UartOscilloscope命名空間

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	/// <summary>
	/// CommandParser類別用於建立指令語法分析器
	/// </summary>
	class CommandParser															//	CommandParser類別
	{                                                                           //	進入CommandParser類別
		List<CommandClass> CommandSet = new List<CommandClass>();               //	宣告CommandSet
		/// <summary>
		/// CommandParser建構子
		/// </summary>
		public CommandParser()                                                  //	CommandParser建構子
		{                                                                       //	進入CommandParser建構子
			CommandSet.Add(new CommandClass(									//	新增指令
				1,																//	指令編號
				"lscom",														//	指令名稱
				new System.Threading.Tasks.Task(() =>							//	建立指令工作
				{																//	進入指令工作內容
					UARTConnection UARTConnection1;                             //	宣告UARTConnection1物件
					UARTConnection1 = new UARTConnection(0,false);
					Console.WriteLine(UARTConnection1.GetComportList().ToString());
				})));															//	結束指令工作內容
		}                                                                       //	結束CommandParser建構子
	}                                                                           //	結束CommandParser類別
}                                                                               //	結束UartOscilloscope命名空間
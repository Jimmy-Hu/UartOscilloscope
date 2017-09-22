using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class CommandClass                                                          //	CommandClass指令類別
	{                                                                           //	進入CommandClass指令類別
		private int CommandID;														//	宣告CommandID為指令編號
		private string Command;                                                     //	宣告Command為指令內容
		/// <summary>
		/// CommandClass建構子
		/// </summary>
		/// <param name="CommandID"></param>
		/// <param name="Command"></param>
		public CommandClass(int CommandID, string Command)
		{
			this.CommandID = CommandID;

		}
	}                                                                           //	結束CommandClass指令類別
}                                                                               //	結束UartOscilloscope命名空間
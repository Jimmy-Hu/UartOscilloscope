using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class CommandClass                                                          //	CommandClass指令類別
	{                                                                           //	進入CommandClass指令類別
		private int CommandID;													//	宣告CommandID為指令編號
		private string Command;                                                 //	宣告Command為指令內容
		private Task task;														//	宣告指令工作
		/// <summary>
		/// CommandClass建構子
		/// </summary>
		/// <param name="CommandID">為指令編號</param>
		/// <param name="Command">為指令內容</param>
		/// <param name="task">為指令工作</param>
		public CommandClass(int CommandID, string Command, Task task)           //	CommandClass建構子
		{                                                                       //	進入CommandClass建構子
			this.CommandID = CommandID;                                         //	初始化指令編號
			this.Command = Command;                                             //	初始化指令內容
			this.task = task;													//	初始化指令工作
		}                                                                       //	結束CommandClass建構子
	}                                                                           //	結束CommandClass指令類別
}                                                                               //	結束UartOscilloscope命名空間
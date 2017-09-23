using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class CommandClass                                                          //	CommandClass指令類別
	{                                                                           //	進入CommandClass指令類別
		private int CommandID;													//	宣告指令編號
		private string CommandName;                                             //	宣告指令名稱
		private Task task;														//	宣告指令工作
		/// <summary>
		/// CommandClass建構子
		/// </summary>
		/// <param name="CommandID">為指令編號</param>
		/// <param name="CommandName">為指令名稱</param>
		/// <param name="task">為指令工作</param>
		public CommandClass(int CommandID, string CommandName, Task task)       //	CommandClass建構子
		{                                                                       //	進入CommandClass建構子
			this.CommandID = CommandID;                                         //	初始化指令編號
			this.CommandName = CommandName;                                     //	初始化指令名稱
			this.task = task;													//	初始化指令工作
		}                                                                       //	結束CommandClass建構子
	}                                                                           //	結束CommandClass指令類別
}                                                                               //	結束UartOscilloscope命名空間
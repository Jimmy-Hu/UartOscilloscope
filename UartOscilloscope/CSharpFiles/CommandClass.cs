/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * CommandClass.cs													*
 * 本檔案建立程式指令模式下指令單元物件								*
 ********************************************************************
 */

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
		private string ChineseDescription;                                      //	宣告指令中文描述
		private string EnglishDescription;										//	宣告指令英文描述
		private Task task;														//	宣告指令工作
		public CommandClass(int CommandID, string CommandName, string ChineseDescription, string EnglishDescription, Task task)
		//	CommandClass建構子
		{                                                                       //	進入CommandClass建構子

		}                                                                       //	結束CommandClass建構子

		/// <summary>
		/// CommandClass建構子
		/// </summary>
		/// <param name="CommandID">為指令編號</param>
		/// <param name="CommandName">為指令名稱</param>
		/// <param name="ChineseDescription">為指令中文敘述</param>
		/// <param name="task">為指令工作</param>
		public CommandClass(int CommandID, string CommandName, string ChineseDescription, Task task)
		//	CommandClass建構子
		{                                                                       //	進入CommandClass建構子
			this.CommandID = CommandID;                                         //	初始化指令編號
			this.CommandName = CommandName;                                     //	初始化指令名稱
			this.ChineseDescription = ChineseDescription;						//	初始化指令中文描述
			this.task = task;													//	初始化指令工作
		}                                                                       //	結束CommandClass建構子

		/// <summary>
		/// 覆寫ToString方法可回傳指令名稱
		/// </summary>
		/// <returns>回傳值為指令名稱</returns>
		public override string ToString()                                       //	覆寫ToString方法
		{                                                                       //	進入覆寫ToString方法
			return CommandName;													//	回傳指令名稱
		}                                                                       //	結束覆寫ToString方法
	}                                                                           //	結束CommandClass指令類別
}                                                                               //	結束UartOscilloscope命名空間
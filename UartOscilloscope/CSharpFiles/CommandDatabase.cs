using System;                                                                   //	使用System函式庫
using System.Collections.Generic;                                               //	使用System.Collections.Generic函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	UartOscilloscope命名空間
{                                                                               //	進入UartOscilloscope命名空間
	class CommandDatabase                                                       //	CommandDatabase類別
	{                                                                           //	進入CommandDatabase類別
		public readonly static CommandDatabase Instance = new CommandDatabase();//	設計CommandDatabase存取介面
		private List<CommandClass> CommandSet = new List<CommandClass>();       //	宣告CommandSet
		/// <summary>
		/// CommandDatabase類別
		/// </summary>
		public CommandDatabase()                                                //	CommandDatabase建構子
		{                                                                       //	進入CommandDatabase建構子
			CreateCommandSet();                                                 //	呼叫CreateCommandSet方法
		}                                                                       //	結束CommandDatabase建構子

		/// <summary>
		/// CreateCommandSet方法用於建立命令集合
		/// </summary>
		public void CreateCommandSet()
		{
			CommandSet.Add(new CommandClass(                                    //	新增指令
				1,                                                              //	指令編號
				"connect",                                                      //	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容

				})));                                                           //	結束指令工作內容
			CommandSet.Add(new CommandClass(                                    //	新增指令
				2,                                                              //	指令編號
				"help",                                                         //	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容


				})));                                                           //	結束指令工作內容
			CommandSet.Add(new CommandClass(                                    //	新增指令
				3,                                                              //	指令編號
				"lscom",                                                        //	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容
					UARTConnection UARTConnection1;                             //	宣告UARTConnection1物件
					UARTConnection1 = new UARTConnection(0, false);
					Console.WriteLine(UARTConnection1.GetComportList().ToString());
				})));                                                           //	結束指令工作內容
			CommandSet.Add(new CommandClass(                                    //	新增指令
				3,                                                              //	指令編號
				"version",                                                      //	指令名稱
				new System.Threading.Tasks.Task(() =>                           //	建立指令工作
				{                                                               //	進入指令工作內容
					UARTConnection UARTConnection1;                             //	宣告UARTConnection1物件
					UARTConnection1 = new UARTConnection(0, false);
					Console.WriteLine(UARTConnection1.GetComportList().ToString());
				})));                                                           //	結束指令工作內容
		}
		/// <summary>
		/// 顯示CommandSet指令列表
		/// </summary>
		/// <returns></returns>
		public override string ToString()                                       //	覆寫ToString方法
		{                                                                       //	進入覆寫ToString方法
			string OutputStr = "";												//	宣告輸出字串
			foreach (CommandClass Item in this.CommandSet)						//	以foreach迴圈依序取出指令物件
			{                                                                   //	進入foreach敘述
				OutputStr = OutputStr + Item.ToString() + '\t';					//	生成輸出字串
			}                                                                   //	結束foreach敘述
			return OutputStr;													//	回傳輸出字串
		}                                                                       //	結束覆寫ToString方法
		/// <summary>
		/// GetCommandSet方法用於取得命令集合中指令列表
		/// </summary>
		/// <returns></returns>
		public string[] GetCommandSet()                                         //	GetCommandSet方法
		{                                                                       //	進入GetCommandSet方法
			string[] OutputStrArray;                                            //	宣告輸出字串陣列
			OutputStrArray = new string[] { };                                  //	初始化字串陣列
			int OutputStrArraySize = CommandSet.Count;                          //	宣告OutputStrArraySize，用於記錄輸出陣列大小
			Array.Resize<string>(ref OutputStrArray, OutputStrArraySize);       //	調整字串陣列大小
			int Index = 0;														//	宣告索引值用於存取陣列元素
			foreach(CommandClass Item in this.CommandSet)						//	取出命令集合中指令
			{																	//	進入foreach敘述
				OutputStrArray[Index] = Item.ToString();						//	填入資料至輸出陣列
				Index = Index + 1;												//	遞增索引值
			}																	//	結束foreach敘述
			return OutputStrArray;												//	回傳字串陣列
		}                                                                       //	結束GetCommandSet方法
		/// <summary>
		/// GetCommandSetCount方法用於取得命令集合指令數量
		/// </summary>
		/// <returns></returns>
		private int GetCommandSetCount()                                        //	GetCommandSetCount方法
		{                                                                       //	進入GetCommandSetCount方法
			return this.CommandSet.Count;                                       //	回傳命令集合指令數量
		}                                                                       //	結束GetCommandSetCount方法
	}                                                                           //	結束CommandDatabase類別
}                                                                               //	結束UartOscilloscope命名空間

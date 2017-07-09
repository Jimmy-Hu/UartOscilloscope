/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * WorkingMode.cs													*
 * 本檔案撰寫WorkingMode類別以紀錄程式執行模式						*
 ********************************************************************
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為本程式
{                                                                               //	進入UartOscilloscope命名空間
	public class WorkingMode                                                    //	WorkingMode類別
	{                                                                           //	進入WorkingMode類別
		public enum Program_Work_Mode_Options : byte                            //	Program_Work_Mode_Options列舉
		{                                                                       //	進入Program_Work_Mode_Options列舉
			Normal_Mode = 0,
			Debug_Mode = 1,
		};                                                                      //	結束Program_Work_Mode_Options列舉
		private static Program_Work_Mode_Options Program_Work_Mode = 
			Program_Work_Mode_Options.Normal_Mode;				                //	宣告Program_Work_Mode靜態變數，控制程式執行模式
		public static void Set_Program_Work_Mode(Program_Work_Mode_Options InputMode)  //	Set_Program_Work_Mode方法
		{																		//	進入Set_Program_Work_Mode方法
			Program_Work_Mode = (Program_Work_Mode_Options)InputMode;                                      //	設定Program_Work_Mode模式
		}                                                                       //	結束Set_Program_Work_Mode方法
	}                                                                           //	結束WorkingMode類別
}                                                                               //	結束UartOscilloscope命名空間

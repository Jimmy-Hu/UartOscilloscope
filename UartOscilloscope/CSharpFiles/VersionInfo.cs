/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * VersionInfo.cs													*
 * 本檔案撰寫VersionInfo類別以紀錄程式版本資訊						*
 ********************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為本程式
{                                                                               //	進入UartOscilloscope命名空間
	class VersionInfo                                                           //	VersionInfo類別
	{                                                                           //	進入VersionInfo類別
		private const float Program_Version = 39;								//	宣告Program_Version靜態全域變數，記錄程式版本
		public float GetProgramVersion()										//	GetProgramVersion方法
		{                                                                       //	進入GetProgramVersion方法
			return Program_Version;                                             //	回傳Program_Version變數值
		}                                                                       //	結束GetProgramVersion方法
	}                                                                           //	結束VersionInfo類別
}                                                                               //	結束UartOscilloscope命名空間

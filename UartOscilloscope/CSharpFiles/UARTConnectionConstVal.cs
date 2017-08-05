using System;
using System.Collections.Generic;
/*	串列埠(Comport)物件宣告於System.IO.Ports函式庫中
 */
using System.IO.Ports;                                                          //	使用System.IO.Ports函式庫
using System.Linq;
using System.Text;

namespace UartOscilloscope
{
	public class UARTConnectionConstVal                                         //	UARTConnectionConstVal類別
	{                                                                           //	進入UARTConnectionConstVal類別
		/// <summary>
		/// 宣告靜態常數
		/// </summary>
		private const int DefaultBaudRate = 9600;                               //	宣告DefaultBaudRate(預設鮑率)常數
		/*	同位位元設定說明：0為不檢查(None),1為奇同位檢察,2為偶同位檢察,3為同位位元恆為1,4為同位位元恆為0 */
		private const Parity DefaultParitySetting = 0;                          //	宣告DefaultParitySetting(預設同位位元設定)常數
		private const int DefaultDataBitsSetting = 8;                           //	宣告DefaultDataBitsSetting(預設UART傳輸每組資料位元數)
		public static int GetDefaultBaudRate()                                  //	GetDefaultBaudRate方法
		{                                                                       //	進入GetDefaultBaudRate方法
			return DefaultBaudRate;                                             //	回傳DefaultBaudRate變數
		}                                                                       //	結束GetDefaultBaudRate方法
		public static Parity GetDefaultParitySetting()                          //	GetDefaultParitySetting方法
		{                                                                       //	進入GetDefaultParitySetting方法
			return DefaultParitySetting;                                        //	回傳DefaultParitySetting變數
		}                                                                       //	結束GetDefaultParitySetting方法
	}                                                                           //	結束UARTConnectionConstVal類別
}
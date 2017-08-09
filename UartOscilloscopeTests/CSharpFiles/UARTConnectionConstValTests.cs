﻿using Microsoft.VisualStudio.TestTools.UnitTesting;                             //	使用Microsoft.VisualStudio.TestTools.UnitTesting函式庫
using UartOscilloscope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope.Tests                                                //	UartOscilloscope.Tests命名空間
{                                                                               //	進入命名空間
	[TestClass()]
	public class UARTConnectionConstValTests                                    //	UARTConnectionConstValTests類別
	{                                                                           //	進入UARTConnectionConstValTests類別
		[TestMethod()]
		public void GetDefaultBaudRateTest()                                    //	GetDefaultBaudRateTest方法
		{                                                                       //	進入GetDefaultBaudRateTest方法
			int expected = 9600;                                                //	宣告expected(期望輸出)
			int actual;                                                         //	宣告actual(實際輸出)
			actual = UARTConnectionConstVal.GetDefaultBaudRate();               //	執行GetDefaultBaudRate方法
			Assert.AreEqual(expected, actual);                                  //	比對期望輸出與實際輸出
		}                                                                       //	結束GetDefaultBaudRateTest方法

		[TestMethod()]
		public void GetDefaultParitySettingTest()                               //	GetDefaultParitySettingTest方法
		{                                                                       //	進入GetDefaultParitySettingTest方法
			Assert.Fail();
		}                                                                       //	結束GetDefaultParitySettingTest方法
	}                                                                           //	結束UARTConnectionConstValTests類別
}                                                                               //	結束命名空間
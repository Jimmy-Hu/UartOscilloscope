using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope.Tests                                                //	UartOscilloscope.Tests命名空間
{																				//	進入命名空間
	/// <summary>
	/// TestingType類別物件用於記錄測試結果
	/// 若測試成功，
	/// </summary>
	public class TestingType                                                    //	TestingType類別
	{                                                                           //	進入TestingType類別
		/// <summary>
		/// 當測試成功，Result為True，否則為False
		/// </summary>
		private bool Result;                                                    //	宣告Result記錄測試結果
		public TestingType()                                                    //	TestingType建構子
		{                                                                       //	進入TestingType建構子
			Result = false;                                                     //	初始化Result為false
		}                                                                       //	結束TestingType建構子
		public void TestSuccess()                                               //	TestSuccess方法
		{                                                                       //	進入TestSuccess方法

		}                                                                       //	結束TestSuccess方法

	}                                                                           //	結束TestingType類別
}																				//	結束命名空間

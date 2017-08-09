using Microsoft.VisualStudio.TestTools.UnitTesting;
using UartOscilloscope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope.Tests                                                //	UartOscilloscope.Tests命名空間
{                                                                               //	進入命名空間
	[TestClass()]
	public class DataProcessingTests                                            //	DataProcessingTests類別
	{                                                                           //	進入DataProcessingTests類別

		[TestMethod()]
		public void String2CharArrayTest()                                      //	String2CharArrayTest方法
		{                                                                       //	進入String2CharArrayTest方法
			DataProcessing DataProcessing1 = new DataProcessing();              //	建立DataProcessing1物件
			string TestData1 = "12345";                                         //	宣告測試資料TestData1
			char[] expected = new char[5]; ;                                    //	宣告預期輸出資料expected
			expected[0] = '1';													//	設定預期輸出
			expected[1] = '2';                                                  //	設定預期輸出
			expected[2] = '3';                                                  //	設定預期輸出
			expected[3] = '4';                                                  //	設定預期輸出
			expected[4] = '5';                                                  //	設定預期輸出
			char[] actual;                                                      //	宣告actual(實際輸出)
			actual = DataProcessing1.String2CharArray(TestData1);               //	執行String2CharArray方法
			Assert.AreEqual(expected, actual);                                  //	比對期望輸出與實際輸出
		}                                                                       //	結束String2CharArrayTest方法
	}                                                                           //	結束DataProcessingTests類別
}                                                                               //	結束命名空間
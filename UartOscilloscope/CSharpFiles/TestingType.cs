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
		/// <summary>
		/// TestingType建構子
		/// </summary>
		public TestingType()                                                    //	TestingType建構子
		{                                                                       //	進入TestingType建構子
			Result = false;                                                     //	初始化Result為false
		}                                                                       //	結束TestingType建構子
		/// <summary>
		/// TestSuccess方法用於記錄測試成功結果
		/// </summary>
		public void TestSuccess()                                               //	TestSuccess方法
		{                                                                       //	進入TestSuccess方法
			Result = true;                                                      //	設定結果為true
		}                                                                       //	結束TestSuccess方法
		/// <summary>
		/// TestFail用於記錄測試失敗結果
		/// </summary>
		public void TestFail()                                                  //	TestFail方法
		{                                                                       //	進入TestFail方法
			Result = false;                                                     //	設定結果為false
		}                                                                       //	結束TestFail方法
		/// <summary>
		/// GetTestingResult用於取得測試結果
		/// </summary>
		public bool GetTestingResult()                                          //	GetTestingResult方法
		{                                                                       //	進入GetTestingResult方法
			return Result;														//	回傳測試結果
		}                                                                       //	結束GetTestingResult方法
		/// <summary>
		/// IsTestSuccessed方法用於核對測試結果是否成功，若測試成功傳回true，若測試失敗則傳回false
		/// </summary>
		/// <param name="TestResult"></param>
		/// <returns>回傳測試結果是否成功核對結果</returns>
		public bool IsTestSuccessed(TestingType TestResult)                     //	IsTestSuccessed方法
		{                                                                       //	進入IsTestSuccessed方法
			return TestResult.GetTestingResult();                               //	回傳比對結果
		}                                                                       //	結束IsTestSuccessed方法
		/// <summary>
		/// IsTestFailed方法用於核對測試結果是否失敗，若測試失敗傳回true，若測試成功則傳回false
		/// </summary>
		/// <param name="TestResult"></param>
		/// <returns>回傳測試結果是否失敗核對結果</returns>
		public bool IsTestFailed(TestingType TestResult)                        //	IsTestFailed方法
		{                                                                       //	進入IsTestFailed方法
			return !TestResult.GetTestingResult();                              //	回傳比對結果
		}                                                                       //	結束IsTestFailed方法
	}                                                                           //	結束TestingType類別
}																				//	結束命名空間

using Microsoft.VisualStudio.TestTools.UnitTesting;                             //	使用Microsoft.VisualStudio.TestTools.UnitTesting函式庫
using UartOscilloscope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope.Tests                                                //	UartOscilloscope.Tests命名空間
{                                                                               //	進入命名空間
	[TestClass()]
	public class WaveDataStructureTests                                         //	WaveDataStructureTests類別
	{                                                                           //	進入WaveDataStructureTests類別
		[TestMethod()]
		public void AddDataTest()                                               //	AddDataTest方法
		{                                                                       //	進入AddDataTest方法
			WaveDataStructure WaveDataStructureTest1;                           //	宣告WaveDataStructureTest1物件
			int ArrayMax = 3;                                                   //	宣告ArrayMax變數，用於給定WaveDataStructureTest物件空間
			WaveDataStructureTest1 = new WaveDataStructure(ArrayMax);           //	初始化測試物件
			if(TestingType.IsTestFailed(WaveDataStructureInitialTest(WaveDataStructureTest1)))
			{																	//	進入if敘述
				Assert.Fail();													//	測試失敗
			}                                                                   //	結束if敘述
			int[] TestData1 = new int[] { 3, 2, 1 };                            //	建立測試資料
			WaveDataStructureTest1.AddData(TestData1[0]);						//	填入測試資料
			WaveDataStructureTest1.AddData(TestData1[1]);						//	填入測試資料
			WaveDataStructureTest1.AddData(TestData1[2]);                        //	填入測試資料
			if (TestingType.IsTestFailed(WaveDataStructureMatch(WaveDataStructureTest1, TestData1)))
			{                                                                   //	進入if敘述
				Assert.Fail();                                                  //	測試失敗
			}                                                                   //	結束if敘述
			int[] TestData2 = TestData1;                                        //	宣告TestData2
			TestData2[0] = 4;
			WaveDataStructureTest1.AddData(TestData2[0]);                       //	填入測試資料
			if (TestingType.IsTestFailed(WaveDataStructureMatch(WaveDataStructureTest1, TestData2)))
			{                                                                   //	進入if敘述
				Assert.Fail();                                                  //	測試失敗
			}                                                                   //	結束if敘述
		}                                                                       //	結束AddDataTest方法
		/// <summary>
		/// WaveDataStructureInitialTest方法用於測試WaveDataStructure初始化功能
		/// 初始化完成後，若內部陣列空間資料皆為0，代表初始化順利完成
		/// 若初始化順利，則TestSuccess，否則TestFail
		/// </summary>
		/// <returns>回傳測試結果</returns>
		private TestingType WaveDataStructureInitialTest(WaveDataStructure InputData)
		//	WaveDataStructureInitialTest方法
		{                                                                       //	進入WaveDataStructureInitialTest方法
			TestingType Test1 = new TestingType();                              //	建立Test1物件
			foreach(int Data in InputData.ReturnData())							//	依序比對資料內容
			{																	//	進入foreach敘述
				if(Data == 0)													//	若Data為0
				{																//	進入if敘述
					Test1.TestSuccess();										//	測試Success
				}																//	結束if敘述
				else															//	若Data不為0
				{																//	進入else敘述
					Test1.TestFail();                                           //	測試Fail
					return Test1;												//	回傳測試結果
				}																//	結束else敘述
			}																	//	結束foreach敘述
			return Test1;														//	回傳測試結果
		}                                                                       //	結束WaveDataStructureInitialTest方法
		/// <summary>
		/// WaveDataStructureMatch方法用於比對WaveDataStructure內容
		/// </summary>
		/// <param name="InputData1">為WaveDataStructure型態資料</param>
		/// <param name="InputData2">為欲確認之答案</param>
		/// <returns></returns>
		private TestingType WaveDataStructureMatch(WaveDataStructure InputData1, int[] InputData2)
		//	WaveDataStructureMatch方法
		{                                                                       //	進入WaveDataStructureMatch方法
			TestingType Test1 = new TestingType();                              //	建立Test1物件
			int CountNum = 0;                                                   //	宣告CountNum計數變數
			foreach (int Data in InputData1.ReturnData())						//	以foreach依序取出Data
			{                                                                   //	進入foreach敘述
				if(Data == InputData2[CountNum])								//	若資料相同
				{																//	進入if敘述
					Test1.TestSuccess();                                        //	測試Success
				}                                                               //	結束if敘述
				else															//	若資料不同
				{                                                               //	進入else敘述
					Test1.TestFail();                                           //	測試Fail
					return Test1;                                               //	回傳測試結果
				}																//	結束else敘述
				CountNum = (CountNum + 1) % InputData2.Length;					//	取得下一筆測試資料序號
			}																	//	結束foreach敘述
			return Test1;                                                       //	回傳測試結果
		}                                                                       //	結束WaveDataStructureMatch方法
		private int[] GenerateRandomNumber(int NumberOfRandomNumber)            //	GenerateRandomNumber方法
		{                                                                       //	進入GenerateRandomNumber方法
			Random rnd = new Random();                                          //	宣告Random物件
			int[] Result = new int[0];                                          //	宣告回傳結果
			Array.Resize<int>(ref Result, NumberOfRandomNumber);				//	配置記憶體位置
			for(int LoopNum = 0; LoopNum < NumberOfRandomNumber; LoopNum++)		//	以for迴圈依序填入亂數
			{                                                                   //	進入for迴圈
				Result[LoopNum] = rnd.Next(-1000, 1000);						//	生成亂數
			}																	//	結束for迴圈
			return Result;														//	回傳結果
		}                                                                       //	結束GenerateRandomNumber方法
		[TestMethod()]
		public void ResizeArrayTest()                                           //	ResizeArrayTest方法
		{                                                                       //	進入ResizeArrayTest方法
			WaveDataStructure WaveDataStructureTest1;                           //	宣告WaveDataStructureTest1物件
			int ArrayMax = 3;                                                   //	宣告ArrayMax變數，用於給定WaveDataStructureTest物件空間
			WaveDataStructureTest1 = new WaveDataStructure(ArrayMax);           //	初始化測試物件
			ArrayMax = 10;                                                      //	調整ArrayMax變數
			WaveDataStructureTest1.ResizeArray(ArrayMax);                       //	測試ResizeArray方法
			int[] TestData1 = GenerateRandomNumber(ArrayMax);					//	生成亂數測試資料
			for(int LoopNum = 0; LoopNum < TestData1.Length; LoopNum++)			//	以for迴圈填入資料
			{                                                                   //	進入for迴圈
				WaveDataStructureTest1.AddData(TestData1[LoopNum]);				//	新增資料
			}                                                                   //	結束for迴圈
			if (TestingType.IsTestFailed(WaveDataStructureMatch(WaveDataStructureTest1, TestData1)))
			{                                                                   //	進入if敘述
				Assert.Fail();                                                  //	測試失敗
			}                                                                   //	結束if敘述
		}                                                                       //	結束ResizeArrayTest方法
	}                                                                           //	結束WaveDataStructureTests類別
}                                                                               //	結束命名空間
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
			int[] TestData = new int[] { 3, 2, 1 };                             //	建立測試資料
			
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
	}                                                                           //	結束WaveDataStructureTests類別
}                                                                               //	結束命名空間
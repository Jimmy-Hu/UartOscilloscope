/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * DataQueue.cs														*
 * 本檔案建立繪圖資料佇列單元物件									*
 ********************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDataGraphic.CSharpFiles
{                                                                               //	namespace start, 進入命名空間
	class DataQueue                                                             //	DataQueue class, DataQueue類別
	{				                                                            //	DataQueue class start, 進入DataQueue類別
		/// <summary>
		/// GraphicData is the queue for storing the graphic data.
		/// GraphicData佇列用於儲存繪圖資料
		/// </summary>
		private Queue<object> GraphicData;                                      //	GraphicData object, GraphicData佇列物件

		/// <summary>
		/// DataQueueName is the name of DataQueue.
		/// DataQueue名稱
		/// </summary>
		private string DataQueueName;                                           //	DataQueueName string, DataQueueName字串

		/// <summary>
		/// GraphicDataQueueMax is the max number of count of GraphData elements.
		/// GraphicDataQueueMax為GraphData物件數量上限
		/// </summary>
		private int GraphicDataQueueMax;                                        //	GraphicDataQueueMax variable, GraphicDataQueueMax變數

		/// <summary>
		/// DataQueue constructor, DataQueue建構子
		/// </summary>
		/// <param name="NewDataQueueName">為DataQueue名稱</param>
		public DataQueue(string NewDataQueueName)                               //	DataQueue constructor, DataQueue建構子
		{                                                                       //	DataQueue constructor start, 進入DataQueue建構子
			this.GraphicData = new Queue<object>();                             //	initialize GraphicData, 初始化GraphicData物件
			this.DataQueueName = NewDataQueueName;                              //	initialize DataQueueName, 初始化DataQueueName字串
			this.GraphicDataQueueMax = 100;                                     //	initialize GraphicDataQueueMax, 初始化GraphicDataQueueMax變數
		}                                                                       //	DataQueue constructor end, 結束DataQueue建構子

		/// <summary>
		/// DataQueue constructor with NewGraphicDataQueueMax, 具NewGraphicDataQueueMax輸入之DataQueue建構子
		/// </summary>
		/// <param name="NewDataQueueName">為DataQueue名稱</param>
		/// <param name="NewGraphicDataQueueMax">為GraphicDataQueue資料儲存數量上限值</param>
		public DataQueue(string NewDataQueueName, int NewGraphicDataQueueMax)                            //	DataQueue constructor, DataQueue建構子
		{                                                                       //	DataQueue constructor start, 進入DataQueue建構子
			this.GraphicData = new Queue<object>();                             //	initialize GraphicData, 初始化GraphicData物件
			this.DataQueueName = NewDataQueueName;                              //	initialize DataQueueName, 初始化DataQueueName字串
			this.GraphicDataQueueMax = NewGraphicDataQueueMax;                  //	initialize GraphicDataQueueMax, 初始化GraphicDataQueueMax變數
		}                                                                       //	DataQueue constructor end, 結束DataQueue建構子


		/// <summary>
		/// SetGraphicDataQueueMax method would update GraphicDataQueueMax variable.
		/// SetGraphicDataQueueMax方法用於更新GraphicDataQueueMax變數
		/// </summary>
		/// <param name="NewGraphicDataQueueMax">為GraphicDataQueueMax更新值</param>
		public void SetGraphicDataQueueMax(int NewGraphicDataQueueMax)          //	SetGraphicDataQueueMax method, SetGraphicDataQueueMax方法
		{                                                                       //	SetGraphicDataQueueMax method start, 進入SetGraphicDataQueueMax方法
			this.GraphicDataQueueMax = NewGraphicDataQueueMax;                  //	Update GraphicDataQueueMax variable, 更新GraphicDataQueueMax變數
			if (Debug.DebugMode == true)                                        //	if DebugMode is true, 若DebugMode為true
			{                                                                   //	if statement start, 進入if敘述
				Console.WriteLine("GraphicDataQueueMax is updated, it's value is " + this.GraphicDataQueueMax);
				// Write out debug info, 輸出偵錯訊息
			}																	//	if statement end, 結束if敘述
		}                                                                       //	SetGraphicDataQueueMax method end, 結束SetGraphicDataQueueMax方法

		/// <summary>
		/// GetGraphicDataQueueMax return GraphicDataQueueMax.
		/// GetGraphicDataQueueMax方法回傳GraphicDataQueueMax變數
		/// </summary>
		/// <returns>GraphicDataQueueMax</returns>
		public int GetGraphicDataQueueMax()                                     //	GetGraphicDataQueueMax method, GetGraphicDataQueueMax方法
		{                                                                       //	GetGraphicDataQueueMax method start, 進入GetGraphicDataQueueMax方法
			return this.GraphicDataQueueMax;                                    //	return GraphicDataQueueMax, 回傳GraphicDataQueueMax
		}                                                                       //	GetGraphicDataQueueMax method end, 結束GetGraphicDataQueueMax方法

		/// <summary>
		/// RemovingOverload method would remove the data when GraphicData.count > GraphicDataQueueMax
		/// RemovingOverload用於清除多於物件數量上限之資料
		/// </summary>
		private void RemovingOverload()                                         //	RemovingOverload method, RemovingOverload方法
		{                                                                       //	RemovingOverload method start, 進入RemovingOverload方法
			while(GraphicData.Count > GraphicDataQueueMax)                      //	when GraphicData.Count more than GraphicDataQueueMax, 當有過多資料
			{                                                                   //	while loop start, 進入while迴圈
				GraphicData.Dequeue();                                          //	clear GraphicData data, 清除GraphicData資料
			}                                                                   //	while loop end, 結束while迴圈
			GC.Collect();                                                       //	forces an immediate garbage collection of all generations, 強制立即執行所有層代的記憶體回收
			return;																//	return, 結束方法
		}                                                                       //	RemovingOverload method end, 結束RemovingOverload方法

		/// <summary>
		/// AddData method would add new data into queue.
		/// AddData方法用於存入新資料至Queue
		/// </summary>
		/// <param name="InputData">欲紀錄至Queue之資料</param>
		public void AddData(object InputData)                                   //	AddData method, AddData方法
		{                                                                       //	AddData method start, 進入AddData方法
			GraphicData.Enqueue(InputData);                                     //	add data into GraphicData, 新增資料至GraphicData佇列
			RemovingOverload();                                                 //	call RemovingOverload method, 呼叫RemovingOverload方法
		}                                                                       //	AddData method end, 結束AddData方法

		/// <summary>
		/// GetGraphicData method would return the GraphicData object.
		/// GetGraphicData方法用於回傳GraphicData物件
		/// </summary>
		/// <returns>GraphicData object, GraphicData物件</returns>
		public Queue<object> GetGraphicData()                                   //	GetGraphicData method, GetGraphicData方法
		{                                                                       //	GetGraphicData method start, 進入GetGraphicData方法
			return GraphicData;                                                 //	return GraphicData object, 回傳GraphicData物件
		}                                                                       //	GetGraphicData method end, 結束GetGraphicData方法

		/// <summary>
		/// GetDataQueueName method would return DataQueueName.
		/// GetDataQueueName方法用於回傳DataQueueName
		/// </summary>
		/// <returns>DataQueueName</returns>
		public string GetDataQueueName()                                        //	GetDataQueueName method, GetDataQueueName方法
		{                                                                       //	GetDataQueueName method start, 進入GetDataQueueName方法
			return this.DataQueueName;                                          //	return DataQueueName, 回傳DataQueueName
		}                                                                       //	GetDataQueueName method end, 結束GetDataQueueName方法

	}                                                                           //	DataQueue class end, 結束DataQueue類別
}                                                                               //	namespace end, 結束命名空間

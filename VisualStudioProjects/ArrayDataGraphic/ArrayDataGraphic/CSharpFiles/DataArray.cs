﻿/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * DataArray.cs														*
 * 本檔案建立繪圖資料佇列單元物件									*
 ********************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDataGraphic.CSharpFiles
{                                                                               //	namespace start, 進入命名空間
	class DataArray                                                             //	DataArray class, DataArray類別
	{                                                                           //	DataArray class start, 開始DataArray類別
		/// <summary>
		/// GraphicData is the queue for storing the graphic data.
		/// GraphicData佇列用於儲存繪圖資料
		/// </summary>
		private Queue<object> GraphicData;                                      //	GraphicData object, GraphicData佇列物件

		/// <summary>
		/// DataArrayName is the name of DataArray.
		/// DataArray名稱
		/// </summary>
		private string DataArrayName;                                           //	DataArrayName string, DataArrayName字串

		/// <summary>
		/// GraphicDataArrayMax is the max number of count of GraphData elements.
		/// GraphicDataArrayMax為GraphData物件數量上限
		/// </summary>
		private int GraphicDataArrayMax;                                        //	GraphicDataArrayMax variable, GraphicDataArrayMax變數

		/// <summary>
		/// DataArray constructor, DataArray建構子
		/// </summary>
		/// <param name="NewDataArrayName">為DataArray名稱</param>
		public DataArray(string NewDataArrayName)                               //	DataArray constructor, DataArray建構子
		{                                                                       //	DataArray constructor start, 進入DataArray建構子
			this.GraphicData = new Queue<object>();                             //	initialize GraphicData, 初始化GraphicData物件
			this.DataArrayName = NewDataArrayName;                              //	initialize DataArrayName, 初始化DataArrayName字串
			this.GraphicDataArrayMax = 100;                                     //	initialize GraphicDataArrayMax, 初始化GraphicDataArrayMax變數
		}                                                                       //	DataArray constructor end, 結束DataArray建構子

		/// <summary>
		/// DataArray constructor with NewGraphicDataArrayMax, 具NewGraphicDataArrayMax輸入之DataArray建構子
		/// </summary>
		/// <param name="NewDataArrayName">為DataArray名稱</param>
		/// <param name="NewGraphicDataArrayMax">為GraphicDataArray資料儲存數量上限值</param>
		public DataArray(string NewDataArrayName, int NewGraphicDataArrayMax)                            //	DataArray constructor, DataArray建構子
		{                                                                       //	DataArray constructor start, 進入DataArray建構子
			this.GraphicData = new Queue<object>();                             //	initialize GraphicData, 初始化GraphicData物件
			this.DataArrayName = NewDataArrayName;                              //	initialize DataArrayName, 初始化DataArrayName字串
			this.GraphicDataArrayMax = NewGraphicDataArrayMax;                  //	initialize GraphicDataArrayMax, 初始化GraphicDataArrayMax變數
		}                                                                       //	DataArray constructor end, 結束DataArray建構子


		/// <summary>
		/// SetGraphicDataArrayMax method would update GraphicDataArrayMax variable.
		/// SetGraphicDataArrayMax方法用於更新GraphicDataArrayMax變數
		/// </summary>
		/// <param name="NewGraphicDataArrayMax">為GraphicDataArrayMax更新值</param>
		public void SetGraphicDataArrayMax(int NewGraphicDataArrayMax)          //	SetGraphicDataArrayMax method, SetGraphicDataArrayMax方法
		{                                                                       //	SetGraphicDataArrayMax method start, 進入SetGraphicDataArrayMax方法
			this.GraphicDataArrayMax = NewGraphicDataArrayMax;                  //	Update GraphicDataArrayMax variable, 更新GraphicDataArrayMax變數
			if (Debug.DebugMode == true)                                        //	if DebugMode is true, 若DebugMode為true
			{                                                                   //	if statement start, 進入if敘述
				Console.WriteLine("GraphicDataArrayMax is updated, it's value is " + this.GraphicDataArrayMax);
				// Write out debug info, 輸出偵錯訊息
			}																	//	if statement end, 結束if敘述
		}                                                                       //	SetGraphicDataArrayMax method end, 結束SetGraphicDataArrayMax方法

		/// <summary>
		/// GetGraphicDataArrayMax return GraphicDataArrayMax.
		/// GetGraphicDataArrayMax方法回傳GraphicDataArrayMax變數
		/// </summary>
		/// <returns>GraphicDataArrayMax</returns>
		public int GetGraphicDataArrayMax()                                     //	GetGraphicDataArrayMax method, GetGraphicDataArrayMax方法
		{                                                                       //	GetGraphicDataArrayMax method start, 進入GetGraphicDataArrayMax方法
			return this.GraphicDataArrayMax;                                    //	return GraphicDataArrayMax, 回傳GraphicDataArrayMax
		}                                                                       //	GetGraphicDataArrayMax method end, 結束GetGraphicDataArrayMax方法

		/// <summary>
		/// RemovingOverload method would remove the data when GraphicData.count > GraphicDataArrayMax
		/// RemovingOverload用於清除多於物件數量上限之資料
		/// </summary>
		private void RemovingOverload()                                         //	RemovingOverload method, RemovingOverload方法
		{                                                                       //	RemovingOverload method start, 進入RemovingOverload方法
			while(GraphicData.Count > GraphicDataArrayMax)                      //	when GraphicData.Count more than GraphicDataArrayMax, 當有過多資料
			{                                                                   //	while loop start, 進入while迴圈
				GraphicData.Dequeue();                                          //	clear GraphicData data, 清除GraphicData資料
			}                                                                   //	while loop end, 結束while迴圈
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
		/// GetDataArrayName method would return DataArrayName.
		/// GetDataArrayName方法用於回傳DataArrayName
		/// </summary>
		/// <returns>DataArrayName</returns>
		public string GetDataArrayName()                                        //	GetDataArrayName method, GetDataArrayName方法
		{                                                                       //	GetDataArrayName method start, 進入GetDataArrayName方法
			return this.DataArrayName;                                          //	return DataArrayName, 回傳DataArrayName
		}                                                                       //	GetDataArrayName method end, 結束GetDataArrayName方法

	}                                                                           //	DataArray class end, 結束DataArray類別
}                                                                               //	namespace end, 結束命名空間
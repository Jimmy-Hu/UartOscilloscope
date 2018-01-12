/********************************************************************
 * Develop by Jimmy Hu												*
 * This program is licensed under the Apache License 2.0.			*
 * QueueDataGraphic.cs												*
 * 本檔案用於佇列資料繪圖功能										*
 ********************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDataGraphic.CSharpFiles
{                                                                               //	namespace start, 進入命名空間
	class QueueDataGraphic                                                      //	QueueDataGraphic class, QueueDataGraphic類別
	{                                                                           //	QueueDataGraphic class start, 進入QueueDataGraphic類別
		List<DataQueue> DataQueueList;                                          //	DataQueueList object, DataQueueList物件

		/// <summary>
		/// QueueDataGraphic constructor, QueueDataGraphic建構子
		/// </summary>
		/// <param name="DataQueueNames">DataQueue通道名稱集合</param>
		public QueueDataGraphic(List<string> DataQueueNames)                    //	QueueDataGraphic constructor, QueueDataGraphic建構子
		{                                                                       //	QueueDataGraphic constructor start, 進入QueueDataGraphic建構子
			DataQueueList = new List<DataQueue>();                              //	initialize DataQueueList, 初始化DataQueueList物件
			foreach (string item in DataQueueNames)                             //	get each name of DataQueueNames
			{                                                                   //	foreach statement start, 進入foreach敘述
				DataQueueList.Add(new DataQueue(item));                         //	add DataQueue, 新增DataQueue
			}                                                                   //	foreach statement end, 結束foreach敘述
		}                                                                       //	QueueDataGraphic constructor end, 結束QueueDataGraphic建構子

		public void AddData(string DataQueueName, object InputData)             //	AddData method, AddData方法
		{                                                                       //	AddData method start, 進入AddData方法
			foreach (DataQueue item in DataQueueList)
			{

			}
		}                                                                       //	AddData method end, 結束AddData方法
	}                                                                           //	QueueDataGraphic class end, 結束QueueDataGraphic類別
}                                                                               //	namespace end, 結束命名空間

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
		/// <param name="ChannelCount">the number of graphic channels, 繪圖通道數量</param>
		public QueueDataGraphic(int ChannelCount)                               //	QueueDataGraphic constructor, QueueDataGraphic建構子
		{                                                                       //	QueueDataGraphic constructor start, 進入QueueDataGraphic建構子
			DataQueueList = new List<DataQueue>();                              //	initialize DataQueueList, 初始化DataQueueList物件
			for (int Loopnum = 0; Loopnum < ChannelCount; Loopnum++)			//	add graphic channels, 加入繪圖通道
			{																	//	for loop start, 進入for迴圈
				DataQueueList.Add(new DataQueue());                             //	add graphic channels, 加入繪圖通道
			}																	//	for loop end, 結束for迴圈
		}                                                                       //	QueueDataGraphic constructor end, 結束QueueDataGraphic建構子

	}                                                                           //	QueueDataGraphic class end, 結束QueueDataGraphic類別
}                                                                               //	namespace end, 結束命名空間

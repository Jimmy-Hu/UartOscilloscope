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
using System.Drawing;

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

		/// <summary>
		/// AddData method would add data to queue.
		/// AddData方法用於新增資料至Queue
		/// </summary>
		/// <param name="DataQueueName">欲新增資料之Queue名稱</param>
		/// <param name="InputData">欲新增至Queue之資料</param>
		public void AddData(string DataQueueName, object InputData)             //	AddData method, AddData方法
		{                                                                       //	AddData method start, 進入AddData方法
			foreach (DataQueue item in DataQueueList)                           //	search DataQueue in DataQueueList
			{                                                                   //	foreach statement start, 進入foreach敘述
				if (item.GetDataQueueName() == DataQueueName)                   //	if item name is as same as DataQueueName, 若搜尋得相同名稱
				{                                                               //	if statement start, 進入if敘述
					item.AddData(InputData);									//	add data to queue, 新增資料至對應佇列
				}                                                               //	if statement end, 結束if敘述
			}                                                                   //	foreach statement end, 結束foreach敘述
		}                                                                       //	AddData method end, 結束AddData方法

		/// <summary>
		/// DrawGraphOnPanel method would draw graph on InputPanel.
		/// DrawGraphOnPanel方法用於將queue資料繪製於InputPanel上
		/// </summary>
		/// <param name="InputPanel"></param>
		public void DrawGraphOnPanel(ref System.Windows.Forms.Panel InputPanel) //	DrawGraphOnPanel method, DrawGraphOnPanel方法
		{                                                                       //	DrawGraphOnPanel method start, 進入DrawGraphOnPanel方法
			Graphics Graph1 = InputPanel.CreateGraphics();                      //	create Graphics
			foreach (DataQueue DataQueueItem in DataQueueList)                  //	get each DataQueue, 依序取出各DataQueue
			{                                                                   //	foreach statement start, 進入foreach敘述
				Point GraphPointTemp = new Point(0,0);
				int Loopnum = 0;                                                //	initialize Loopnum variable, 初始化Loopnum變數
				foreach (int Data in DataQueueItem.GetGraphicData())            //	get each data in DataQueue, 從DataQueue取出資料
				{                                                               //	foreach statement start, 進入foreach敘述
					if (Loopnum == 0)
					{                                                           //	if statement start, 進入if敘述
						GraphPointTemp = new Point((
							Loopnum * InputPanel.Size.Width / DataQueueItem.GetGraphicDataQueueMax()),
							InputPanel.Size.Height - (Data * InputPanel.Size.Height / 4096));
					}                                                           //	if statement end, 結束if敘述
					else
					{                                                           //	else statement start, 進入else敘述
						Graph1.DrawLine(new Pen(Color.Black), GraphPointTemp,
							new Point((
							Loopnum * InputPanel.Size.Width / DataQueueItem.GetGraphicDataQueueMax()),
							InputPanel.Size.Height - (Data * InputPanel.Size.Height / 4096)));
					}                                                           //	else statement end, 結束else敘述
					Loopnum = Loopnum + 1;                                      //	increase Loopnum variable, 遞增Loopnum變數
				}                                                               //	foreach statement end, 結束foreach敘述
			}                                                                   //	foreach statement end, 結束foreach敘述
		}                                                                       //	DrawGraphOnPanel method end, 結束DrawGraphOnPanel方法

	}                                                                           //	QueueDataGraphic class end, 結束QueueDataGraphic類別
}                                                                               //	namespace end, 結束命名空間

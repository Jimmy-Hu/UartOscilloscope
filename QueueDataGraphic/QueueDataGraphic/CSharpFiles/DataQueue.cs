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
{                                                                               //	namespace start
	class DataQueue
	{
		/// <summary>
		/// GraphicData is the queue for storing the graphic data.
		/// GraphicData佇列用於儲存繪圖資料
		/// </summary>
		private Queue<object> GraphicData;

		/// <summary>
		/// GraphicDataQueueMax is the max number of count of GraphData elements.
		/// GraphicDataQueueMax為GraphData物件數量上限
		/// </summary>
		private int GraphicDataQueueMax;

		/// <summary>
		/// SetGraphicDataQueueMax method would update GraphicDataQueueMax variable.
		/// SetGraphicDataQueueMax方法用於更新GraphicDataQueueMax變數
		/// </summary>
		/// <param name="NewGraphicDataQueueMax">為GraphicDataQueueMax更新值</param>
		public void SetGraphicDataQueueMax(int NewGraphicDataQueueMax)          //	SetGraphicDataQueueMax method, SetGraphicDataQueueMax方法
		{

		}

		/// <summary>
		/// RemovingOverload method would remove the data when GraphicData.count > GraphicDataQueueMax
		/// RemovingOverload用於清除多於物件數量上限之資料
		/// </summary>
		private void RemovingOverload()                                         //	RemovingOverload method, RemovingOverload方法
		{                                                                       //	RemovingOverload method start, 進入RemovingOverload方法
			while(GraphicData.Count > GraphicDataQueueMax)                      //	when GraphicData.Count more than GraphicDataQueueMax, 當有過多資料
			{                                                                   //	while loop start, 進入while迴圈
				GraphicData.Dequeue();                                          //	clear GraphicData data, 清除GraphicData資料
			}																	//	while loop end, 結束while迴圈
		}                                                                       //	RemovingOverload method end, 結束RemovingOverload方法


	}
}                                                                               //	namespace end

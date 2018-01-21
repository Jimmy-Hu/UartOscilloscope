using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayDataGraphic.CSharpFiles
{
	class ArrayDataGraphic
	{
		private List<DataArray> DataArrayList;                                  //	DataArrayList object, DataArrayList物件

		/// <summary>
		/// Width is the width of graph.
		/// </summary>
		private int Width;                                                      //	Width variable, Width變數

		/// <summary>
		/// Height is the height of graph.
		/// </summary>
		private int Height;                                                     //	Height variable, Height變數

		/// <summary>
		/// ArrayDataGraphic constructor, ArrayDataGraphic建構子
		/// </summary>
		/// <param name="DataArrayNames">DataArray通道名稱集合</param>
		public ArrayDataGraphic(List<string> DataArrayNames)                    //	ArrayDataGraphic constructor, ArrayDataGraphic建構子
		{                                                                       //	ArrayDataGraphic constructor start, 進入ArrayDataGraphic建構子
			DataArrayList = new List<DataArray>();                              //	initialize DataArrayList, 初始化DataArrayList物件
			foreach (string item in DataArrayNames)                             //	get each name of DataArrayNames
			{                                                                   //	foreach statement start, 進入foreach敘述
				DataArrayList.Add(new DataArray(item));                         //	add DataArray, 新增DataArray
			}                                                                   //	foreach statement end, 結束foreach敘述
		}                                                                       //	ArrayDataGraphic constructor end, 結束ArrayDataGraphic建構子

		/// <summary>
		/// SetWidth method would update Width variable.
		/// SetWidth方法用於更新Width變數
		/// </summary>
		/// <param name="NewWidth">Width更新值</param>
		public void SetWidth(int NewWidth)                                      //	SetWidth method, SetWidth方法
		{                                                                       //	SetWidth method start, 進入SetWidth方法
			if (NewWidth > 0)
			{
				this.Width = NewWidth;                                          //	Update Width, 更新Width資料
			}
		}                                                                       //	SetWidth method end, 結束SetWidth方法

		/// <summary>
		/// SetHeight method would update Height variable.
		/// SetHeight方法用於更新Height變數
		/// </summary>
		/// <param name="NewHeight">Height更新值</param>
		public void SetHeight(int NewHeight)                                    //	SetHeight method, SetHeight方法
		{                                                                       //	SetHeight method start, 進入SetHeight方法
			if (NewHeight > 0)
			{
				this.Height = NewHeight;                                        //	Update Height, 更新Height資料
			}
		}                                                                       //	SetHeight method end, 結束SetHeight方法

		/// <summary>
		/// AddData method would add data to queue.
		/// AddData方法用於新增資料至Queue
		/// </summary>
		/// <param name="DataArrayName">欲新增資料之Queue名稱</param>
		/// <param name="InputData">欲新增至Queue之資料</param>
		public void AddData(string DataArrayName, object InputData)             //	AddData method, AddData方法
		{                                                                       //	AddData method start, 進入AddData方法
			foreach (DataArray item in DataArrayList)                           //	search DataArray in DataArrayList
			{                                                                   //	foreach statement start, 進入foreach敘述
				if (item.GetDataArrayName() == DataArrayName)                   //	if item name is as same as DataArrayName, 若搜尋得相同名稱
				{                                                               //	if statement start, 進入if敘述
					item.AddData(InputData);                                    //	add data to queue, 新增資料至對應佇列
				}                                                               //	if statement end, 結束if敘述
			}                                                                   //	foreach statement end, 結束foreach敘述
		}                                                                       //	AddData method end, 結束AddData方法

		/// <summary>
		/// DrawGraph method would draw the graph of queue data.
		/// DrawGraph方法用於繪製queue資料圖形
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void DrawGraph(object sender, PaintEventArgs e)                  //	DrawGraph method, DrawGraph方法
		{                                                                       //	DrawGraph method start, 進入DrawGraph方法
			Graphics Graph1 = e.Graphics;
			foreach (DataArray DataArrayItem in DataArrayList)                  //	get each DataArray, 依序取出各DataArray
			{                                                                   //	foreach statement start, 進入foreach敘述
				Point GraphPointTemp = new Point(0, 0);
				int Loopnum = 0;                                                //	initialize Loopnum variable, 初始化Loopnum變數
				foreach (int Data in DataArrayItem.GetGraphicData())            //	get each data in DataArray, 從DataArray取出資料
				{                                                               //	foreach statement start, 進入foreach敘述
					if (Loopnum == 0)                                           //	if run first loop, 若Loopnum變數為0
					{                                                           //	if statement start, 進入if敘述
						GraphPointTemp = new Point((
							(int)(Loopnum * this.Width / DataArrayItem.GetGraphicDataArrayMax())),
							(int)(this.Height - (Data * this.Height / 4096)));
					}                                                           //	if statement end, 結束if敘述
					else
					{                                                           //	else statement start, 進入else敘述
						Graph1.DrawLine(new Pen(Color.Black), GraphPointTemp,
							new Point((
							(int)(Loopnum * this.Width / DataArrayItem.GetGraphicDataArrayMax())),
							(int)(this.Height - (Data * this.Height / 4096))));
						GraphPointTemp = new Point((
							(int)(Loopnum * this.Width / DataArrayItem.GetGraphicDataArrayMax())),
							(int)(this.Height - (Data * this.Height / 4096)));  //	update GraphPointTemp data. 更新GraphPointTemp資料
					}                                                           //	else statement end, 結束else敘述
					Loopnum = Loopnum + 1;                                      //	increase Loopnum variable, 遞增Loopnum變數
				}                                                               //	foreach statement end, 結束foreach敘述
			}                                                                   //	foreach statement end, 結束foreach敘述
			Graph1.Flush();
		}                                                                       //	DrawGraph method end, 結束DrawGraph方法

	}
}

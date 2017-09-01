/********************************************************************
 * Develop by Jimmy Hu,												*
 * s103360021@gmail.com												*
 * This program is licensed under the Apache License 2.0.			*
 * OscilloscopeFunctionVariable.cs									*
 * 本檔案撰寫OscilloscopeFunctionVariable類別以宣告Oscilloscope		*
 * 功能實作變數														*
 ********************************************************************
 */
using System;
using System.Collections.Generic;                                               //	使用System.Collections.Generic函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope														//	命名空間為本程式
{																				//	進入命名空間
	/**	OscilloscopeFunctionVariable類別宣告示波器功能實作變數 **
	 */
	public class OscilloscopeFunctionVariable									//	OscilloscopeFunctionVariable類別
	{																			//	進入OscilloscopeFunctionVariable類別
		public WaveDataStructure XChannel;										//	宣告XChannel全域陣列變數，記錄X通道ADC原始資料
		public WaveDataStructure YChannel;										//	宣告YChannel全域陣列變數，記錄Y通道ADC原始資料
		public WaveDataStructure ZChannel;										//	宣告ZChannel全域陣列變數，記錄Z通道ADC原始資料
		private static int ADC_Raw_Data_Max = 100;								//	宣告ADC_Raw_Data_Max全域整數變數，記錄ADC_Raw_Data陣列大小
		public static Queue<int> Data_Graphic_Queue_X;							//	宣告X通道資料繪圖用整數型態佇列Data_Graphic_Queue_X
		public static Queue<int> Data_Graphic_Queue_Y;							//	宣告Y通道資料繪圖用整數型態佇列Data_Graphic_Queue_Y
		public static Queue<int> Data_Graphic_Queue_Z;                          //	宣告Z通道資料繪圖用整數型態佇列Data_Graphic_Queue_Z

		public OscilloscopeFunctionVariable()
		{
			this.XChannel = new WaveDataStructure(ADC_Raw_Data_Max);
			this.YChannel = new WaveDataStructure(ADC_Raw_Data_Max);
			this.ZChannel = new WaveDataStructure(ADC_Raw_Data_Max);
		}
		public static int Get_ADC_Raw_Data_Max()								//	宣告Get_ADC_Raw_Data_Max方法
		{																		//	進入Get_ADC_Raw_Data_Max方法
			return OscilloscopeFunctionVariable.ADC_Raw_Data_Max;				//	回傳ADC_Raw_Data_Max數值
		}																		//	結束Get_ADC_Raw_Data_Max方法
		public static void Set_ADC_Raw_Data_Max(int InputData)                  //	宣告Set_ADC_Raw_Data_Max方法
		{                                                                       //	進入Set_ADC_Raw_Data_Max方法
			OscilloscopeFunctionVariable.ADC_Raw_Data_Max = InputData;          //	設定ADC_Raw_Data_Max數值
			return;                                                             //	結束Set_ADC_Raw_Data_Max方法
		}                                                                       //	結束Set_ADC_Raw_Data_Max方法
	}																			//	結束OscilloscopeFunctionVariable類別
}																				//	結束命名空間

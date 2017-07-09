using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{                                                                               //	進入命名空間
	class DebugVariables                                                        //  DebugVariables類別
	{                                                                           //  進入DebugVariables類別
		private static uint button1_Click_Runtimes = 0;                         //	宣告button1_Click_Runtimes全域靜態變數，記錄button1_Click副程式執行次數，並初始化為0

		public static uint button2_Click_Runtimes = 0;                          //	宣告button2_Click_Runtimes全域靜態變數，記錄button2_Click副程式執行次數，並初始化為0
		public static uint button3_Click_Runtimes = 0;                          //	宣告button3_Click_Runtimes全域靜態變數，記錄button3_Click副程式執行次數，並初始化為0
		public static uint Transmission_Setting_Click_Runtimes = 0;
		//	宣告Transmission_Setting_Click_Runtimes全域靜態變數，記錄設定_傳輸設定ToolStripMenuItem_Click副程式執行次數，並初始化為0
		public static uint User_Interface_Setting_Click_Runtimes = 0;
		//	宣告User_Interface_Setting_Click_Runtimes全域靜態變數，記錄設定_介面設定ToolStripMenuItem_Click副程式執行次數，並初始化為0
		public static uint list_SerialPort_Runtimes = 0;                        //	宣告list_SerialPort_Runtimes全域靜態變數，記錄list_SerialPort副程式執行次數
		public static uint Uart_comport_handle_Runtimes = 0;                    //	宣告Uart_comport_handle_Runtimes全域靜態變數，記錄Uart_comport_handle副程式執行次數
		public static uint comport_DataReceived_Runtimes = 0;                   //	宣告comport_DataReceived_Runtimes全域靜態變數，記錄comport_DataReceived副程式執行次數
		public static uint DisplayText_Runtimes = 0;                            //	宣告DisplayText_Runtimes全域靜態變數，記錄DisplayText副程式執行次數
	}                                                                           //  結束DebugVariables類別

}																				//	結束命名空間
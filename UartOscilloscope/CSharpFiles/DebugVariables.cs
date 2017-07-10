using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{                                                                               //	進入命名空間
	/**	DebugVariables類別宣告用於記錄事件發生次數或方法執行次數的變數及方法
	 * 各項變數皆具有重置(Reset)、設定(Set，遞增1)與取得值(Get)方法，
	 * 方法名稱命名為：
	 *		重置(Reset)－Reset_[變數名稱]
	 *		設定(Set，遞增1)－Set_[變數名稱]
	 *		取得值(Get)－Get_[變數名稱]
	 * 變數條列如下：
	 *		button1_Click_Runtimes
	 * 		button2_Click_Runtimes
	 * 		
	 **/
	public class DebugVariables                                                 //  DebugVariables類別
	{                                                                           //  進入DebugVariables類別
		
		private static uint button1_Click_Runtimes;                             //	宣告button1_Click_Runtimes私有靜態變數，記錄button1_Click副程式執行次數
		private static void Reset_button1_Click_Runtimes()                      //	Reset_button1_Click_Runtimes方法，用於重置button1_Click_Runtimes計數變數為0
		{                                                                       //	進入Reset_button1_Click_Runtimes方法
			button1_Click_Runtimes = 0;                                         //	將button1_Click_Runtimes變數重置為0
		}                                                                       //	結束Reset_button1_Click_Runtimes方法
		public static void Set_button1_Click_Runtimes()                         //	Set_button1_Click_Runtimes方法
		{                                                                       //	進入Set_button1_Click_Runtimes方法
			button1_Click_Runtimes = button1_Click_Runtimes + 1;                //	遞增button1_Click_Runtimes變數
		}                                                                       //	結束Set_button1_Click_Runtimes方法
		public static uint Get_button1_Click_Runtimes()                         //	Get_button1_Click_Runtimes方法
		{                                                                       //	進入Get_button1_Click_Runtimes方法
			return button1_Click_Runtimes;                                      //	取得button1_Click_Runtimes變數數值
		}                                                                       //	結束Get_button1_Click_Runtimes方法

		private static uint button2_Click_Runtimes;                             //	宣告button2_Click_Runtimes私有靜態變數，記錄button2_Click副程式執行次數

		public static void Set_button2_Click_Runtimes()                         //	Set_button2_Click_Runtimes方法
		{                                                                       //	進入Set_button2_Click_Runtimes方法
			button2_Click_Runtimes = button2_Click_Runtimes + 1;                //	遞增button2_Click_Runtimes變數
		}                                                                       //	結束Set_button2_Click_Runtimes方法
		public static uint Get_button2_Click_Runtimes()                         //	Get_button2_Click_Runtimes方法
		{                                                                       //	進入Get_button2_Click_Runtimes方法
			return button2_Click_Runtimes;                                      //	取得button2_Click_Runtimes變數數值
		}                                                                       //	結束Get_button2_Click_Runtimes方法

		private static uint button3_Click_Runtimes;                             //	宣告button3_Click_Runtimes私有靜態變數，記錄button3_Click副程式執行次數
		public static void Set_button3_Click_Runtimes()                         //	Set_button3_Click_Runtimes方法
		{                                                                       //	進入Set_button3_Click_Runtimes方法
			button3_Click_Runtimes = button3_Click_Runtimes + 1;                //	遞增button3_Click_Runtimes變數
		}                                                                       //	結束Set_button3_Click_Runtimes方法
		public static uint Get_button3_Click_Runtimes()                         //	Get_button3_Click_Runtimes方法
		{                                                                       //	進入Get_button3_Click_Runtimes方法
			return button3_Click_Runtimes;                                      //	取得button3_Click_Runtimes變數數值
		}                                                                       //	結束Get_button3_Click_Runtimes方法

		private static uint Transmission_Setting_Click_Runtimes;
		//	宣告Transmission_Setting_Click_Runtimes私有靜態變數，記錄設定_傳輸設定ToolStripMenuItem_Click副程式執行次數
		public static void Set_Transmission_Setting_Click_Runtimes()            //	Set_Transmission_Setting_Click_Runtimes方法
		{                                                                       //	進入Set_Transmission_Setting_Click_Runtimes方法
			Transmission_Setting_Click_Runtimes = Transmission_Setting_Click_Runtimes + 1;
			//	遞增Transmission_Setting_Click_Runtimes變數
		}                                                                       //	結束Set_Transmission_Setting_Click_Runtimes方法
		public static uint Get_Transmission_Setting_Click_Runtimes()            //	Get_Transmission_Setting_Click_Runtimes方法
		{                                                                       //	進入Get_Transmission_Setting_Click_Runtimes方法
			return Transmission_Setting_Click_Runtimes;                         //	取得Transmission_Setting_Click_Runtimes變數數值
		}                                                                       //	結束Get_Transmission_Setting_Click_Runtimes方法

		private static uint User_Interface_Setting_Click_Runtimes;
		//	宣告User_Interface_Setting_Click_Runtimes私有靜態變數，記錄設定_介面設定ToolStripMenuItem_Click副程式執行次數
		public static void Set_User_Interface_Setting_Click_Runtimes()          //	Set_User_Interface_Setting_Click_Runtimes方法
		{                                                                       //	進入Set_User_Interface_Setting_Click_Runtimes方法
			User_Interface_Setting_Click_Runtimes = User_Interface_Setting_Click_Runtimes + 1;
			//	遞增User_Interface_Setting_Click_Runtimes變數
		}                                                                       //	結束Set_User_Interface_Setting_Click_Runtimes方法
		public static uint Get_User_Interface_Setting_Click_Runtimes()          //	Get_User_Interface_Setting_Click_Runtimes方法
		{                                                                       //	進入Get_User_Interface_Setting_Click_Runtimes方法
			return User_Interface_Setting_Click_Runtimes;                       //	取得User_Interface_Setting_Click_Runtimes變數數值
		}                                                                       //	結束Get_User_Interface_Setting_Click_Runtimes方法

		private static uint list_SerialPort_Runtimes;							//	宣告list_SerialPort_Runtimes私有靜態變數，記錄list_SerialPort副程式執行次數
		public static void Set_list_SerialPort_Runtimes()                       //	Set_list_SerialPort_Runtimes方法
		{                                                                       //	進入Set_list_SerialPort_Runtimes方法
			list_SerialPort_Runtimes = list_SerialPort_Runtimes + 1;            //	遞增list_SerialPort_Runtimes變數
		}                                                                       //	結束Set_list_SerialPort_Runtimes方法
		public static uint Get_list_SerialPort_Runtimes()                       //	Get_list_SerialPort_Runtimes方法
		{                                                                       //	進入Get_list_SerialPort_Runtimes方法
			return list_SerialPort_Runtimes;                                    //	取得list_SerialPort_Runtimes變數數值
		}                                                                       //	結束Get_list_SerialPort_Runtimes方法

		private static uint Uart_comport_handle_Runtimes;						//	宣告Uart_comport_handle_Runtimes私有靜態變數，記錄Uart_comport_handle副程式執行次數
		public static void Set_Uart_comport_handle_Runtimes()                   //	Set_Uart_comport_handle_Runtimes方法
		{                                                                       //	進入Set_Uart_comport_handle_Runtimes方法
			Uart_comport_handle_Runtimes = Uart_comport_handle_Runtimes + 1;    //	遞增Uart_comport_handle_Runtimes變數
		}                                                                       //	結束Set_Uart_comport_handle_Runtimes方法
		public static uint Get_Uart_comport_handle_Runtimes()                   //	Get_Uart_comport_handle_Runtimes方法
		{                                                                       //	進入Get_Uart_comport_handle_Runtimes方法
			return Uart_comport_handle_Runtimes;                                //	取得Uart_comport_handle_Runtimes變數數值
		}                                                                       //	結束Get_Uart_comport_handle_Runtimes方法

		private static uint comport_DataReceived_Runtimes;						//	宣告comport_DataReceived_Runtimes私有靜態變數，記錄comport_DataReceived副程式執行次數
		public static void Set_comport_DataReceived_Runtimes()                  //	Set_comport_DataReceived_Runtimes方法
		{                                                                       //	進入Set_comport_DataReceived_Runtimes方法
			comport_DataReceived_Runtimes = comport_DataReceived_Runtimes + 1;  //	遞增comport_DataReceived_Runtimes變數
		}                                                                       //	結束Set_comport_DataReceived_Runtimes方法
		public static uint Get_comport_DataReceived_Runtimes()                  //	Get_comport_DataReceived_Runtimes方法
		{                                                                       //	進入Get_comport_DataReceived_Runtimes方法
			return comport_DataReceived_Runtimes;                               //	取得comport_DataReceived_Runtimes變數數值
		}                                                                       //	結束Get_comport_DataReceived_Runtimes方法

		private static uint DisplayText_Runtimes;								//	宣告DisplayText_Runtimes私有靜態變數，記錄DisplayText副程式執行次數
		public static void Set_DisplayText_Runtimes()                           //	Set_DisplayText_Runtimes方法
		{                                                                       //	進入Set_DisplayText_Runtimes方法
			DisplayText_Runtimes = DisplayText_Runtimes + 1;                    //	遞增DisplayText_Runtimes變數
		}                                                                       //	結束Set_DisplayText_Runtimes方法
		public static uint Get_DisplayText_Runtimes()                           //	Get_DisplayText_Runtimes方法
		{                                                                       //	進入Get_DisplayText_Runtimes方法
			return DisplayText_Runtimes;                                        //	取得DisplayText_Runtimes變數數值
		}                                                                       //	結束Get_DisplayText_Runtimes方法

		public void ResetDebugVariables()                                       //	ResetDebugVariables方法
		{
			Reset_button1_Click_Runtimes();                                     //	重置button1_Click_Runtimes變數
			button2_Click_Runtimes = 0;
			User_Interface_Setting_Click_Runtimes = 0;
			list_SerialPort_Runtimes = 0;                                       //	重置list_SerialPort_Runtimes變數為0
			Uart_comport_handle_Runtimes = 0;                                   //	重置Uart_comport_handle_Runtimes變數為0
			comport_DataReceived_Runtimes = 0;                                  //	重置comport_DataReceived_Runtimes變數為0
			DisplayText_Runtimes = 0;                                           //	重置DisplayText_Runtimes變數為0
		}

	}                                                                           //  結束DebugVariables類別

}																				//	結束命名空間
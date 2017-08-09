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
	 * 		button3_Click_Runtimes
	 * 		Transmission_Setting_Click_Runtimes
	 * 		User_Interface_Setting_Click_Runtimes
	 * 		list_SerialPort_Runtimes
	 * 		UartComport_handle_Runtimes
	 * 		comport_DataReceived_Runtimes
	 * 		DisplayText_Runtimes
	 **/
	public class DebugVariables                                                 //  DebugVariables類別
	{                                                                           //  進入DebugVariables類別
		public struct Debug_Login_Account_struct                                //	宣告Debug_Login_Account_struct全域結構
		{                                                                       //	進入Debug_Login_Account_struct結構設定
			public string Debug_Login_Account, Debug_Login_Password;            //	在Debug_Login_Account_struct結構中有兩項字串(Account與Password)
			public Debug_Login_Account_struct(string p1, string p2)             //	設定結構成員
			{                                                                   //	設定結構成員
				Debug_Login_Account = p1;                                       //	設定結構成員
				Debug_Login_Password = p2;                                      //	設定結構成員
			}                                                                   //	設定結構成員完成
		}                                                                       //	結束Debug_Login_Account_struct結構設定
		public static Debug_Login_Account_struct Debug_Account1 =               //	宣告Debug_Account1靜態全域除錯帳戶1
			new Debug_Login_Account_struct("Debug", "debug");                   //	設定Debug_Account1除錯帳戶1帳號密碼

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
		private static void Reset_button2_Click_Runtimes()                      //	Reset_button2_Click_Runtimes方法，用於重置button2_Click_Runtimes計數變數為0
		{                                                                       //	進入Reset_button2_Click_Runtimes方法
			button2_Click_Runtimes = 0;                                         //	將button2_Click_Runtimes變數重置為0
		}                                                                       //	結束Reset_button2_Click_Runtimes方法
		public static void Set_button2_Click_Runtimes()                         //	Set_button2_Click_Runtimes方法
		{                                                                       //	進入Set_button2_Click_Runtimes方法
			button2_Click_Runtimes = button2_Click_Runtimes + 1;                //	遞增button2_Click_Runtimes變數
		}                                                                       //	結束Set_button2_Click_Runtimes方法
		public static uint Get_button2_Click_Runtimes()                         //	Get_button2_Click_Runtimes方法
		{                                                                       //	進入Get_button2_Click_Runtimes方法
			return button2_Click_Runtimes;                                      //	取得button2_Click_Runtimes變數數值
		}                                                                       //	結束Get_button2_Click_Runtimes方法

		private static uint button3_Click_Runtimes;                             //	宣告button3_Click_Runtimes私有靜態變數，記錄button3_Click副程式執行次數
		private static void Reset_button3_Click_Runtimes()                      //	Reset_button3_Click_Runtimes方法，用於重置button3_Click_Runtimes計數變數為0
		{                                                                       //	進入Reset_button3_Click_Runtimes方法
			button3_Click_Runtimes = 0;                                         //	將button3_Click_Runtimes變數重置為0
		}                                                                       //	結束Reset_button3_Click_Runtimes方法
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
		private static void Reset_Transmission_Setting_Click_Runtimes()         //	Reset_Transmission_Setting_Click_Runtimes方法，用於重置Transmission_Setting_Click_Runtimes計數變數為0
		{                                                                       //	進入Reset_Transmission_Setting_Click_Runtimes方法
			Transmission_Setting_Click_Runtimes = 0;                            //	將Transmission_Setting_Click_Runtimes變數重置為0
		}                                                                       //	結束Reset_Transmission_Setting_Click_Runtimes方法
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
		private static void Reset_User_Interface_Setting_Click_Runtimes()       //	Reset_User_Interface_Setting_Click_Runtimes方法，用於重置User_Interface_Setting_Click_Runtimes計數變數為0
		{                                                                       //	進入Reset_User_Interface_Setting_Click_Runtimes方法
			User_Interface_Setting_Click_Runtimes = 0;                          //	將User_Interface_Setting_Click_Runtimes變數重置為0
		}                                                                       //	結束Reset_User_Interface_Setting_Click_Runtimes方法
		public static void Set_User_Interface_Setting_Click_Runtimes()          //	Set_User_Interface_Setting_Click_Runtimes方法
		{                                                                       //	進入Set_User_Interface_Setting_Click_Runtimes方法
			User_Interface_Setting_Click_Runtimes = User_Interface_Setting_Click_Runtimes + 1;
			//	遞增User_Interface_Setting_Click_Runtimes變數
		}                                                                       //	結束Set_User_Interface_Setting_Click_Runtimes方法
		public static uint Get_User_Interface_Setting_Click_Runtimes()          //	Get_User_Interface_Setting_Click_Runtimes方法
		{                                                                       //	進入Get_User_Interface_Setting_Click_Runtimes方法
			return User_Interface_Setting_Click_Runtimes;                       //	取得User_Interface_Setting_Click_Runtimes變數數值
		}                                                                       //	結束Get_User_Interface_Setting_Click_Runtimes方法

		private static uint list_SerialPort_Runtimes;                           //	宣告list_SerialPort_Runtimes私有靜態變數，記錄list_SerialPort副程式執行次數
		private static void Reset_list_SerialPort_Runtimes()                    //	Reset_list_SerialPort_Runtimes方法，用於重置list_SerialPort_Runtimes計數變數為0
		{                                                                       //	進入Reset_list_SerialPort_Runtimes方法
			list_SerialPort_Runtimes = 0;                                       //	將list_SerialPort_Runtimes變數重置為0
		}                                                                       //	結束Reset_list_SerialPort_Runtimes方法
		public static void Set_list_SerialPort_Runtimes()                       //	Set_list_SerialPort_Runtimes方法
		{                                                                       //	進入Set_list_SerialPort_Runtimes方法
			list_SerialPort_Runtimes = list_SerialPort_Runtimes + 1;            //	遞增list_SerialPort_Runtimes變數
		}                                                                       //	結束Set_list_SerialPort_Runtimes方法
		public static uint Get_list_SerialPort_Runtimes()                       //	Get_list_SerialPort_Runtimes方法
		{                                                                       //	進入Get_list_SerialPort_Runtimes方法
			return list_SerialPort_Runtimes;                                    //	取得list_SerialPort_Runtimes變數數值
		}                                                                       //	結束Get_list_SerialPort_Runtimes方法

		private static uint UartComport_handle_Runtimes;                       //	宣告UartComport_handle_Runtimes私有靜態變數，記錄UartComport_handle副程式執行次數
		private static void Reset_UartComport_handle_Runtimes()                //	Reset_UartComport_handle_Runtimes方法，用於重置UartComport_handle_Runtimes計數變數為0
		{                                                                       //	進入Reset_UartComport_handle_Runtimes方法
			UartComport_handle_Runtimes = 0;                                   //	將UartComport_handle_Runtimes變數重置為0
		}                                                                       //	結束Reset_UartComport_handle_Runtimes方法
		public static void Set_UartComport_handle_Runtimes()                   //	Set_UartComport_handle_Runtimes方法
		{                                                                       //	進入Set_UartComport_handle_Runtimes方法
			UartComport_handle_Runtimes = UartComport_handle_Runtimes + 1;    //	遞增UartComport_handle_Runtimes變數
		}                                                                       //	結束Set_UartComport_handle_Runtimes方法
		public static uint Get_UartComport_handle_Runtimes()                   //	Get_UartComport_handle_Runtimes方法
		{                                                                       //	進入Get_UartComport_handle_Runtimes方法
			return UartComport_handle_Runtimes;                                //	取得UartComport_handle_Runtimes變數數值
		}                                                                       //	結束Get_UartComport_handle_Runtimes方法

		private static uint comport_DataReceived_Runtimes;                      //	宣告comport_DataReceived_Runtimes私有靜態變數，記錄comport_DataReceived副程式執行次數
		private static void Reset_comport_DataReceived_Runtimes()               //	Reset_comport_DataReceived_Runtimes方法，用於重置comport_DataReceived_Runtimes計數變數為0
		{                                                                       //	進入Reset_comport_DataReceived_Runtimes方法
			comport_DataReceived_Runtimes = 0;                                  //	將comport_DataReceived_Runtimes變數重置為0
		}                                                                       //	結束Reset_comport_DataReceived_Runtimes方法
		public static void Set_comport_DataReceived_Runtimes()                  //	Set_comport_DataReceived_Runtimes方法
		{                                                                       //	進入Set_comport_DataReceived_Runtimes方法
			comport_DataReceived_Runtimes = comport_DataReceived_Runtimes + 1;  //	遞增comport_DataReceived_Runtimes變數
		}                                                                       //	結束Set_comport_DataReceived_Runtimes方法
		public static uint Get_comport_DataReceived_Runtimes()                  //	Get_comport_DataReceived_Runtimes方法
		{                                                                       //	進入Get_comport_DataReceived_Runtimes方法
			return comport_DataReceived_Runtimes;                               //	取得comport_DataReceived_Runtimes變數數值
		}                                                                       //	結束Get_comport_DataReceived_Runtimes方法

		private static uint DisplayText_Runtimes;                               //	宣告DisplayText_Runtimes私有靜態變數，記錄DisplayText副程式執行次數
		private static void Reset_DisplayText_Runtimes()                        //	Reset_DisplayText_Runtimes方法，用於重置DisplayText_Runtimes計數變數為0
		{                                                                       //	進入Reset_DisplayText_Runtimes方法
			DisplayText_Runtimes = 0;                                           //	將DisplayText_Runtimes變數重置為0
		}                                                                       //	結束Reset_DisplayText_Runtimes方法
		public static void Set_DisplayText_Runtimes()                           //	Set_DisplayText_Runtimes方法
		{                                                                       //	進入Set_DisplayText_Runtimes方法
			DisplayText_Runtimes = DisplayText_Runtimes + 1;                    //	遞增DisplayText_Runtimes變數
		}                                                                       //	結束Set_DisplayText_Runtimes方法
		public static uint Get_DisplayText_Runtimes()                           //	Get_DisplayText_Runtimes方法
		{                                                                       //	進入Get_DisplayText_Runtimes方法
			return DisplayText_Runtimes;                                        //	取得DisplayText_Runtimes變數數值
		}                                                                       //	結束Get_DisplayText_Runtimes方法

		public static void ResetDebugVariables()                                //	ResetDebugVariables方法
		{                                                                       //	進入ResetDebugVariables方法
			Reset_button1_Click_Runtimes();                                     //	重置button1_Click_Runtimes變數
			Reset_button2_Click_Runtimes();                                     //	重置button2_Click_Runtimes變數
			Reset_button3_Click_Runtimes();                                     //	重置button3_Click_Runtimes變數
			Reset_Transmission_Setting_Click_Runtimes();                        //	重置Transmission_Setting_Click_Runtimes變數
			Reset_User_Interface_Setting_Click_Runtimes();                      //	重置User_Interface_Setting_Click_Runtimes變數
			Reset_list_SerialPort_Runtimes();                                   //	重置list_SerialPort_Runtimes變數
			Reset_UartComport_handle_Runtimes();                               //	重置UartComport_handle_Runtimes變數
			Reset_comport_DataReceived_Runtimes();                              //	重置comport_DataReceived_Runtimes變數
			Reset_DisplayText_Runtimes();                                       //	重置DisplayText_Runtimes變數
		}                                                                       //	結束ResetDebugVariables方法
	}                                                                           //  結束DebugVariables類別

}																				//	結束命名空間
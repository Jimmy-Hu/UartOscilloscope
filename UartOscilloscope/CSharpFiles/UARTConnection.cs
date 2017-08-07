using System;
using System.Collections.Generic;
/*	串列埠(Comport)物件宣告於System.IO.Ports函式庫中
 */
using System.IO.Ports;															//	使用System.IO.Ports函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                                                     //	使用System.Windows.Forms函式庫

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{                                                                               //	進入命名空間
	public class UARTConnection													//	UARTConnection類別
	{                                                                           //	進入UARTConnection類別
		public SerialPort UartComport;											//	宣告SerialPort通訊埠，名稱為UartComport
		private static Parity ParitySetting;                                    //	宣告ParitySetting靜態私有變數，控制SerialPort串列埠之Parity同位位元設定
		private static int DataBitsSetting;                                     //	宣告DataBitsSetting靜態私有變數，控制SerialPort串列埠之DataBits數值
		private static int ConnectedCOMPortNum;                                 //	宣告ConnectedCOMPortNum私有靜態變數，記錄已連接的SerialPort數量
		private static bool UartComport_connected;								//	宣告UartComport_connected布林變數，表示UartComport連線狀態
		public UARTConnection()                                                 //	UARTConnection建構子
		{                                                                       //	進入UARTConnection建構子
			UartComport = new SerialPort();                                     //	初始化UartComport串列埠物件
		}                                                                       //	結束UARTConnection建構子
		public void InitializeUARTConnectionSetting()							//	InitializeUARTConnectionSetting方法，初始化UART連線參數
		{                                                                       //	進入InitializeUARTConnectionSetting方法
			UartComport.BaudRate = UARTConnectionConstVal.GetDefaultBaudRate(); //	預設BaudRate數值為DefaultBaudRate
			ParitySetting = UARTConnectionConstVal.GetDefaultParitySetting();   //	預設ParitySetting數值為0(無同位位元檢查)
			DataBitsSetting = UARTConnectionConstVal.GetDefaultDataBitsSetting();
			//	預設DataBitsSetting數值為8
			ConnectedCOMPortNum = 0;                                            //	預設ConnectedCOMPortNum為0
			UartComport_connected = false;										//	預設UartComport_connected值為False
		}                                                                       //	結束InitializeUARTConnectionSetting方法
		public int GetBaudRate()												//	GetBaudRate方法
		{                                                                       //	進入GetBaudRate方法
			return UartComport.BaudRate;                                        //	回傳BaudRate數值
		}                                                                       //	結束GetBaudRate方法
		public void SetBaudRate(int NewBaudRate)								//	SetBaudRate方法
		{                                                                       //	進入SetBaudRate方法
			UartComport.BaudRate = NewBaudRate;                                 //	設定BaudRate
		}                                                                       //	進入SetBaudRate方法
		public static Parity GetParitySetting()                                 //	GetParitySetting方法
		{                                                                       //	進入GetParitySetting方法
			return ParitySetting;                                               //	回傳ParitySetting數值
		}                                                                       //	結束GetParitySetting方法
		public static void Set_ParitySetting(Parity NewParitySetting)           //	Set_ParitySetting方法
		{                                                                       //	進入Set_ParitySetting方法
			ParitySetting = NewParitySetting;                                   //	設定ParitySetting
		}                                                                       //	結束Set_ParitySetting方法
		/// <summary>
		/// Set_ParitySetting方法用於調整同位位元設定
		/// 同位位元設定說明：0為不檢查(None),1為奇同位檢察,2為偶同位檢察,3為同位位元恆為1,4為同位位元恆為0
		/// </summary>
		/// <param name="NewParitySetting"></param>
		public static void Set_ParitySetting(int NewParitySetting)				//	Set_ParitySetting方法
		{                                                                       //	進入Set_ParitySetting方法
			switch (NewParitySetting)
			{
				case 0 :
					{
						ParitySetting = Parity.None;
						break;
					}
				case 1:
					{
						ParitySetting = Parity.Odd;
						break;
					}
				case 2:
					{
						ParitySetting = Parity.Even;
						break;
					}
				case 3:
					{
						ParitySetting = Parity.Mark;
						break;
					}
				case 4:
					{
						ParitySetting = Parity.Space;
						break;
					}
				default:
					break;
			}
		}                                                                       //	結束Set_ParitySetting方法
		public static int Get_DataBitsSetting()                                 //	Get_DataBitsSetting方法
		{                                                                       //	進入Get_DataBitsSetting方法
			return DataBitsSetting;                                             //	回傳DataBitsSetting數值
		}                                                                       //	結束Get_DataBitsSetting方法
		public static void Set_DataBitsSetting(int NewDataBitsSetting)          //	Set_DataBitsSetting方法
		{                                                                       //	進入Set_DataBitsSetting方法
			DataBitsSetting = NewDataBitsSetting;                               //	設定DataBitsSetting數值
		}                                                                       //	結束Set_DataBitsSetting方法
		public static int Get_ConnectedCOMPortNum()                             //	Get_ConnectedCOMPortNum方法
		{                                                                       //	進入Get_ConnectedCOMPortNum方法
			return ConnectedCOMPortNum;                                         //	回傳ConnectedCOMPortNum數值
		}                                                                       //	結束Get_ConnectedCOMPortNum方法
		public static void Set_ConnectedCOMPortNum(int NewConnectedCOMPortNum)  //	Set_ConnectedCOMPortNum方法
		{                                                                       //	進入Set_ConnectedCOMPortNum方法
			ConnectedCOMPortNum = NewConnectedCOMPortNum;                       //	設定ConnectedCOMPortNum數值
		}                                                                       //	結束Set_ConnectedCOMPortNum方法
		public static void Set_UartComport_connected(bool NewUartComport_connected)
		//	Set_UartComport_connected方法
		{                                                                       //	進入Set_UartComport_connected方法
			UartComport_connected = NewUartComport_connected;                 //	設定UartComport_connected
		}                                                                       //	結束Set_UartComport_connected方法
		public static bool Get_UartComport_connected()                         //	Get_UartComport_connected方法，用以取得UartComport_connected狀態
		{                                                                       //	進入Get_UartComport_connected方法
			return UartComport_connected;                                      //	回傳UartComport_connected狀態
		}                                                                       //	結束Get_UartComport_connected方法
		  
	}                                                                           //	結束UARTConnection類別
}																				//	結束命名空間

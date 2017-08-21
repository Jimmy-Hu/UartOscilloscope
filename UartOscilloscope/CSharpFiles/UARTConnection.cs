///   <summary>
///   C#實作Uart接收程式，By Jimmy Hu
///   This program is licensed under the Apache License 2.0.
///   </summary>
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
		private int ConnectedCOMPortCount;										//	宣告ConnectedCOMPortCount私有變數，記錄已連接的SerialPort數量
		private bool UartComportConnected;                                      //	宣告UartComportConnected布林變數，表示UartComport連線狀態
		private ComportList ComportList1;
		private ComboBox ComportListComboBox1;                                  //	宣告ComportListComboBox1物件
		public UARTConnection(                                                  //	UARTConnection建構子
			int ConnectedCOMPortCount = 0,                                      //	初始化參數
			bool UartComportConnected = false									//	初始化參數
			)																	//	UARTConnection建構子
		{                                                                       //	進入UARTConnection建構子
			this.UartComport = new SerialPort();                                //	初始化UartComport串列埠物件
			this.ConnectedCOMPortCount = ConnectedCOMPortCount;                 //	初始化ConnectedCOMPortCount物件
			this.UartComportConnected = UartComportConnected;                   //	初始化UartComportConnected物件
			this.ComportList1 = new ComportList(new string[] { ""});            //	初始化ComportList1物件
			this.ComportListComboBox1 = new System.Windows.Forms.ComboBox();    //	初始化ComportListComboBox1物件
		}                                                                       //	結束UARTConnection建構子
		public void InitializeUARTConnectionSetting()							//	InitializeUARTConnectionSetting方法，初始化UART連線參數
		{                                                                       //	進入InitializeUARTConnectionSetting方法
			UartComport.BaudRate = UARTConnectionConstVal.GetDefaultBaudRate(); //	預設BaudRate數值為DefaultBaudRate
			UartComport.Parity = UARTConnectionConstVal.GetDefaultParitySetting();
			//	預設Parity數值為0(無同位位元檢查)
			UartComport.DataBits = UARTConnectionConstVal.GetDefaultDataBitsSetting();
			//	預設DataBitsSetting數值為8
			ConnectedCOMPortCount = 0;                                          //	預設ConnectedCOMPortCount為0
			UartComportConnected = false;										//	預設UartComportConnected值為False
		}                                                                       //	結束InitializeUARTConnectionSetting方法
		public int GetBaudRate()												//	GetBaudRate方法
		{                                                                       //	進入GetBaudRate方法
			return UartComport.BaudRate;                                        //	回傳BaudRate數值
		}                                                                       //	結束GetBaudRate方法
		public void SetBaudRate(int NewBaudRate)								//	SetBaudRate方法
		{                                                                       //	進入SetBaudRate方法
			UartComport.BaudRate = NewBaudRate;                                 //	設定BaudRate
		}                                                                       //	進入SetBaudRate方法
		public Parity GetParitySetting()										//	GetParitySetting方法
		{                                                                       //	進入GetParitySetting方法
			return UartComport.Parity;                                          //	回傳Parity數值
		}                                                                       //	結束GetParitySetting方法
		public void SetParitySetting(Parity NewParitySetting)					//	SetParitySetting方法
		{                                                                       //	進入SetParitySetting方法
			UartComport.Parity = NewParitySetting;                              //	設定ParitySetting
		}                                                                       //	結束SetParitySetting方法
		/// <summary>
		/// SetParitySetting方法用於調整同位位元設定
		/// 同位位元設定說明：0為不檢查(None),1為奇同位檢察,2為偶同位檢察,3為同位位元恆為1,4為同位位元恆為0
		/// </summary>
		/// <param name="NewParitySetting"></param>
		public void SetParitySetting(int NewParitySetting)						//	SetParitySetting方法
		{                                                                       //	進入SetParitySetting方法
			switch (NewParitySetting)                                           //	依據NewParitySetting輸入選擇Parity設定
			{                                                                   //	進入switch敘述
				case 0 :
					{
						UartComport.Parity = Parity.None;
						break;
					}
				case 1:
					{
						UartComport.Parity = Parity.Odd;
						break;
					}
				case 2:
					{
						UartComport.Parity = Parity.Even;
						break;
					}
				case 3:
					{
						UartComport.Parity = Parity.Mark;
						break;
					}
				case 4:
					{
						UartComport.Parity = Parity.Space;
						break;
					}
				default:
					break;
			}                                                                   //	結束switch敘述
		}                                                                       //	結束SetParitySetting方法
		public int GetDataBitsSetting()											//	GetDataBitsSetting方法
		{                                                                       //	進入GetDataBitsSetting方法
			return UartComport.DataBits;										//	回傳DataBitsSetting數值
		}                                                                       //	結束GetDataBitsSetting方法
		public void SetDataBitsSetting(int NewDataBitsSetting)					//	SetDataBitsSetting方法
		{                                                                       //	進入SetDataBitsSetting方法
			UartComport.DataBits = NewDataBitsSetting;							//	設定DataBitsSetting數值
		}                                                                       //	結束SetDataBitsSetting方法
		public int GetConnectedCOMPortCount()									//	GetConnectedCOMPortCount方法
		{                                                                       //	進入GetConnectedCOMPortCount方法
			return ConnectedCOMPortCount;										//	回傳ConnectedCOMPortCount數值
		}                                                                       //	結束GetConnectedCOMPortCount方法
		public void SetConnectedCOMPortCount(int NewConnectedCOMPortCount)		//	SetConnectedCOMPortCount方法
		{                                                                       //	進入SetConnectedCOMPortCount方法
			ConnectedCOMPortCount = NewConnectedCOMPortCount;					//	設定ConnectedCOMPortCount數值
		}                                                                       //	結束SetConnectedCOMPortCount方法
		public void SetUartComportConnected(bool NewUartComportConnected)		//	SetUartComportConnected方法
		{                                                                       //	進入SetUartComportConnected方法
			UartComportConnected = NewUartComportConnected;						//	設定UartComportConnected
		}                                                                       //	結束SetUartComportConnected方法
		public bool GetUartComportConnected()									//	GetUartComportConnected方法，用以取得UartComportConnected狀態
		{                                                                       //	進入GetUartComportConnected方法
			return UartComportConnected;										//	回傳UartComportConnected狀態
		}                                                                       //	結束GetUartComportConnected方法
		public ComportList GetComportList()                                     //	GetComportList方法
		{                                                                       //	進入GetComportList方法
			ListSerialPort();                                                   //	呼叫ListSerialPort方法
			return ComportList1;                                                //	回傳ComportList1物件
		}                                                                       //	結束GetComportList方法
		private void ListSerialPort()											//	ListSerialPort方法
		{                                                                       //	進入ListSerialPort方法
			ComportList1.UpdateComportList(SerialPort.GetPortNames());			//	偵測已連線的SerialPort並儲存結果
		}                                                                       //	結束ListSerialPort方法

	}                                                                           //	結束UARTConnection類別
}																				//	結束命名空間

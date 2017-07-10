using System;
using System.Collections.Generic;
/*	
 */
using System.IO.Ports;															//	使用System.IO.Ports函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{                                                                               //	進入命名空間
	public class UARTConnection                                                 //	UARTConnection類別
	{                                                                           //	進入UARTConnection類別
		private static SerialPort Uart_comport;                                 //	宣告新的SerialPort通訊埠，名稱為Uart_comport
		private static int BaudRate;                                            //	宣告BaudRate靜態私有變數，控制SerialPort連線鮑率
		private static int ParitySetting;                                       //	宣告ParitySetting靜態私有變數，控制SerialPort串列埠之Parity同位位元設定
		private static int DataBitsSetting;                                     //	宣告DataBitsSetting靜態私有變數，控制SerialPort串列埠之DataBits數值
		private static int ConnectedCOMPortNum;                                 //	宣告ConnectedCOMPortNum私有靜態變數，記錄已連接的SerialPort數量
		private static bool Uart_comport_connected;                             //	宣告Uart_comport_connected布林變數，表示Uart_comport連線狀態
		public static void InitializeUARTConnectionSetting()                    //	InitializeUARTConnectionSetting方法，初始化UART連線參數
		{                                                                       //	進入InitializeUARTConnectionSetting方法
			BaudRate = 9600;                                                    //	預設BaudRate數值為9600
			ParitySetting = 0;                                                  //	預設ParitySetting數值為0(無同位位元檢查)
			DataBitsSetting = 8;                                                //	預設DataBitsSetting數值為8
			ConnectedCOMPortNum = 0;                                            //	預設ConnectedCOMPortNum為0
			Uart_comport_connected = false;                                     //	預設Uart_comport_connected值為False
		}                                                                       //	結束InitializeUARTConnectionSetting方法
		public static void list_SerialPort()                                    //	偵測並列出已連線SerialPort副程式
		{                                                                       //	進入list_SerialPort副程式
			DebugVariables.Set_list_SerialPort_Runtimes();                      //	呼叫Set_list_SerialPort_Runtimes方法遞增list_SerialPort_Runtimes變數
			string[] ports = SerialPort.GetPortNames();                         //	偵測已連線的SerialPort並儲存結果至陣列ports
			Form1.comboBox1.Items.Clear();                                      //	清空下拉式選單所有項目
			if (ports.Length == 0)                                              //	若偵測不到任何已連接的SerialPort(ports.Length為0)
			{                                                                   //	進入if敘述
				ErrorCodeMessage.Error_Message_Show((int)ErrorCodeMessage.ErrorCodeEncoding.NoSerialPortConnected);
				//	顯示錯誤訊息
				button2.Enabled = false;                                        //	關閉"連線/中斷連線"按鈕功能
				textBox1.Enabled = false;                                       //	關閉textBox1(接收字串資料文字方塊)功能
				return;                                                         //	提早結束list_SerialPort副程式
			}                                                                   //	結束if敘述
			else                                                                //	若偵測到已連線的SerialPort
			{                                                                   //	進入else敘述
				ConnectedCOMPortNum = ports.Length;                                    //	記錄已連線的SerialPort數量
				foreach (string port in ports)                                  //	依序處理每個已連線的SerialPort
				{                                                               //	進入foreach敘述
					comboBox1.Items.Add(port);                                  //	以條列式選單(comboBox1)列出已連線的SerialPort
				}                                                               //	結束foreach敘述
				button2.Enabled = false;                                        //	暫時關閉"連線"按鈕功能，待使用者選定愈連線之Serialport(未選定連線Serialport，可避免發生Error_010002)
				textBox1.Enabled = true;                                        //	開啟textBox1(接收字串資料文字方塊)功能
				return;                                                         //	結束list_SerialPort副程式
			}                                                                   //	結束else敘述
		}                                                                       //	結束list_SerialPort副程式
		public static void Uart_comport_handle                                  //	串列埠連線處理Uart_comport_handle副程式
		(string comport_name)
		//  處理Uart_comport連線設定
		//  呼叫格式為Uart_comport_handle(comport名稱,連線鮑率,同位位元設定,)
		//  同位位元設定說明：0為不檢查(None),1為奇同位檢察,2為偶同位檢察,3為同位位元恆為1,4為同位位元恆為0
		{                                                                       //	進入Uart_comport_handle副程式
			DebugVariables.Set_Uart_comport_handle_Runtimes();                  //	呼叫Set_Uart_comport_handle_Runtimes方法遞增Uart_comport_handle_Runtimes變數
			if (Uart_comport_connected == true)
			//  若Uart_comport_connected為True，代表Uart_comport連線中，將執行中斷連線
			{                                                                   //	進入if敘述
				label6.Text = (comport_name + "正在中斷連線");
				//  顯示連線狀態為(comport_name + "正在中斷連線")，如"COM1正在中斷連線"
				Uart_comport_connected = false;                                 //	更新Uart_comport_connected
				Uart_comport.Close();                                           //	關閉Uart_comport連線
				button2.Text = "連線";                                          //	更改button2文字為"連線"
				button2.Enabled = true;                                         //	重新開啟"連線/中斷連線"按鈕功能
				label6.Text = "未連線";                                         //	顯示連線狀態為"未連線"
				return;                                                         //	結束Uart_comport_handle副程式
			}                                                                   //	結束if敘述
			else                                                                //	若Uart_comport_connected為False，執行連線
			{                                                                   //	進入else敘述
				label6.Text = "偵測連接埠設定";                                 //	顯示連線狀態為"偵測連接埠設定"
				if (comport_name == "")                                         //	若comport_name為空白(Combobox1未選定)
				{                                                               //	進入if敘述
					ErrorCode = 010002;                                         //	記錄ErrorCode
					ErrorCodeMessage.Error_Message_Show(ErrorCode);             //	顯示錯誤訊息
					button2.Enabled = true;                                     //	重新開啟"連線/中斷連線"按鈕功能
					return;                                                     //	結束Uart_comport_handle副程式
				}                                                               //	結束if敘述
				else                                                            //	已選定連接埠
				{                                                               //	進入else敘述
					label6.Text = (comport_name + "正在嘗試連線");              //	顯示連線狀態為(comport_name + "正在嘗試連線")，如"COM1正在嘗試連線"
					try                                                         //	嘗試以comport_name建立串列通訊連線
					{                                                           //	進入try敘述
						Uart_comport = new SerialPort(comport_name);            //	Uart_comport串列埠建立comport_name連線
					}                                                           //	結束try敘述
					catch (System.IO.IOException)                               //	當IO發生錯誤時的例外狀況
					{                                                           //	進入catch敘述
						ErrorCode = 010003;                                     //	記錄ErrorCode
						ErrorCodeMessage.Error_Message_Show(ErrorCode);         //	顯示錯誤訊息
						button2.Enabled = true;                                 //	重新開啟"連線/中斷連線"按鈕功能
						return;                                                 //	結束Uart_comport_handle副程式
					}                                                           //	結束catch敘述
					Uart_comport.BaudRate = UARTConnection.BaudRate;            //	設定Uart_comport連線之BaudRate
					Uart_comport.DataBits = DataBitsSetting;                    //	設定Uart_comport連線之DataBits
					switch (UARTConnection.ParitySetting)                       //	根據UARTConnection.ParitySetting變數進行同位位元設定
					{                                                           //	進入switch-case敘述
						case 0:                                                 //	若為case0(UARTConnection.ParitySetting為0)
							Uart_comport.Parity = Parity.None;                  //	無同位元檢查
							break;                                              //	結束case0敘述、跳出switch-case
						case 1:                                                 //	若為case1(UARTConnection.ParitySetting為1)
							Uart_comport.Parity = Parity.Odd;                   //	奇同位位元檢查
							break;                                              //	結束case1敘述、跳出switch-case
						case 2:                                                 //	若為case2(UARTConnection.ParitySetting為2)
							Uart_comport.Parity = Parity.Even;                  //	偶同位位元檢查
							break;                                              //	結束case2敘述、跳出switch-case
						case 3:                                                 //	若為case3(UARTConnection.ParitySetting為3)
							Uart_comport.Parity = Parity.Mark;                  //	將同位位元恆設為1
							break;                                              //	結束case3敘述、跳出switch-case
						case 4:                                                 //	若為case4(UARTConnection.ParitySetting為4)
							Uart_comport.Parity = Parity.Space;                 //	將同位位元恆設為0
							break;                                              //	結束case4敘述、跳出switch-case
					}                                                           //	結束switch-case敘述
					try                                                         //	以try方式執行資料接收
					{                                                           //	進入try敘述
						if (!Uart_comport.IsOpen)                               //	若Uart_comport未開啟
						{                                                       //	進入if敘述
							Uart_comport.Open();                                //	開啟Uart_comport
							label6.Text = (comport_name + "已連線");            //	顯示連線狀態為(comport_name + "已連線")，如"COM1已連線"
							Uart_comport_connected = true;                      //	更新Uart_comport_connected狀態
							button2.Text = "中斷連線";                          //	更改button2文字為"中斷連線"
							button2.Enabled = true;                             //	重新開啟"連線/中斷連線"按鈕功能
						}                                                       //	結束if敘述
						Uart_comport.DataReceived += new SerialDataReceivedEventHandler(Form1.comport_DataReceived);
						//  處理資料接收
					}                                                           //  結束try敘述
					catch (Exception ex)                                        //  若發生錯誤狀況
					{                                                           //  進入catch敘述
						var result = MessageBox.Show                            //  顯示錯誤訊息
							(                                                   //  進入錯誤訊息MessageBox設定
								ex.ToString(), "DataReceived Error",            //  顯示錯誤訊息ex.ToString()，標題為"DataReceived Error"
								MessageBoxButtons.OK,                           //  MessageBox選項為OK
								MessageBoxIcon.Error                            //  顯示錯誤標誌
							);                                                  //  結束錯誤訊息MessageBox設定
						Uart_comport.Close();                                   //  關閉Uart_comport連線
						button2.Text = "連線";                                  //  更改button2文字為"連線"
						button2.Enabled = true;                                 //  重新開啟"連線/中斷連線"按鈕功能
						return;                                                 //  結束Uart_comport_handle副程式
					}                                                           //  結束catch敘述
				}                                                               //  結束else敘述
			}                                                                   //  結束else敘述
		}                                                                       //  結束Uart_comport_handle副程式        
	}                                                                           //	結束UARTConnection類別
}																				//	結束命名空間

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{																				//	進入命名空間
	class UARTConnection                                                        //	UARTConnection類別
	{                                                                           //	進入UARTConnection類別
		public void Uart_comport_handle                                         //	串列埠連線處理Uart_comport_handle副程式
		(string comport_name, int Baud_Rate, int Parity_set)
		//  處理Uart_comport連線設定
		//  呼叫格式為Uart_comport_handle(comport名稱,連線鮑率,同位位元設定,)
		//  同位位元設定說明：0為不檢查(None),1為奇同位檢察,2為偶同位檢察,3為同位位元恆為1,4為同位位元恆為0
		{                                                                       //	進入Uart_comport_handle副程式
			Uart_comport_handle_Runtimes = Uart_comport_handle_Runtimes + 1;    //	遞增Uart_comport_handle_Runtimes變數
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
					Uart_comport.BaudRate = Baud_Rate;                          //	設定Uart_comport連線之BaudRate
					Uart_comport.DataBits = DataBits_num;                       //	設定Uart_comport連線之DataBits
					switch (Parity_set)                                         //	根據Parity_set變數進行同位位元設定
					{                                                           //	進入switch-case敘述
						case 0:                                                 //	若為case0(Parity_set為0)
							Uart_comport.Parity = Parity.None;                  //	無同位元檢查
							break;                                              //	結束case0敘述、跳出switch-case
						case 1:                                                 //	若為case1(Parity_set為1)
							Uart_comport.Parity = Parity.Odd;                   //	奇同位位元檢查
							break;                                              //	結束case1敘述、跳出switch-case
						case 2:                                                 //	若為case2(Parity_set為2)
							Uart_comport.Parity = Parity.Even;                  //	偶同位位元檢查
							break;                                              //	結束case2敘述、跳出switch-case
						case 3:                                                 //	若為case3(Parity_set為3)
							Uart_comport.Parity = Parity.Mark;                  //	將同位位元恆設為1
							break;                                              //	結束case3敘述、跳出switch-case
						case 4:                                                 //	若為case4(Parity_set為4)
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
						Uart_comport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);
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

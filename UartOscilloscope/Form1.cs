///   <summary>
///   C#實作Uart接收程式，By Jimmy Hu
///   This program is licensed under the Apache License 2.0.
///   </summary>
using System;																	//	使用System函式庫
using System.IO.Ports;                                                          //	使用System.IO.Ports函式庫
using System.Windows.Forms;														//	使用System.Windows.Forms函式庫
using System.Collections;														//	使用System.Collections函式庫
//	System.Collections函式庫定義Queue資料型態
using System.Collections.Generic;												//	使用System.Collections.Generic函式庫
//	System.Collections.Generic函式庫定義非泛型Queue資料型態
using System.Drawing;															//	使用System.Drawing函式庫
using SharpGL;                                                                  //	使用SharpGL函式庫(使用OpenGL函數)

namespace UartOscilloscope														//	命名空間為本程式
{																				//	進入命名空間
	public partial class Form1 : Form											//	Form1類別，繼承自System.Windows.Forms.Form類別
	{                                                                           //	進入Form1類別
		//-----全域物件宣告-----
		public static UARTConnection UARTConnection1;							//	宣告UARTConnection1為UARTConnection物件
		//-----全域變數宣告-----
		public static uint Analysis_Graphic_Mode = 3;							//	宣告Analysis_Graphic_Mode靜態全域變數，控制程式分析與繪圖方法
		public static Font textBox1_Font;										//	宣告textBox1_Font靜態字型變數，控制接收字串資料文字方塊字型
		public static char[] Transmission_Buffer_CharArray;						//	宣告Transmission_Buffer_CharArray(Uart通訊傳輸Buffer資料)字元陣列，用於字串資料解析
		public static char[] Transmission_Analysis_CharArray;					//	宣告Transmission_Analysis_CharArray字元陣列，用於字串資料解析
		public static int Transmission_Analysis_CharArray_Datanum = 0;
		//	宣告Transmission_Analysis_CharArray_Datanum全域靜態變數，記錄Transmission_Analysis_CharArray字元陣列中已填入資料長度，並初始化為0
		public static Queue Transmission_Analysis_Queue;						//	宣告Transmission_Analysis_Queue(Uart通訊傳輸資料分析字元佇列)為全域靜態佇列
		public static int Total_Transmission_Length = 0;						//	宣告UART通訊傳輸字串累計長度統計全域靜態變數，並初始化為0
		public static int Analysed_Length = -1;
		//	宣告Analysed_Length全域靜態變數，記錄Transmission_Analysis_CharArray字元陣列中已分析字串長度(陣列值)，並初始化為-1(因陣列從0開始)
		public static int Uart_Buffer_Size = 0;									//	宣告Uart_Buffer_Size全域靜態變數，記錄Uart接收資料Buffer(資料緩衝區)大小
		public static string Uart_Buffer_ASCII_Data = "";                       //	宣告Uart_Buffer_ASCII_Data全域靜態字串，記錄Uart傳輸之Buffer資料(ASCII編碼值)
		public static int ADCintervals = 1024;                                  //	宣告ADCintervals(MCU輸出狀態數)
		public struct OpenGL_Graph_point										//	宣告OpenGL_Graph_point結構，用於OpenGL繪圖座標宣告
		{																		//	進入OpenGL_Graph_point結構
			public double point_X, point_Y;										//	在OpenGL_Graph_point結構中有兩項雙精度浮點數
			public OpenGL_Graph_point(double X, double Y)						//	設定結構成員
			{																	//	設定結構成員
				point_X = X;													//	宣告OpenGL_Graph_point結構內部元素(X座標)
				point_Y = Y;													//	宣告OpenGL_Graph_point結構內部元素(Y座標)
			}																	//	設定結構成員完成
		}																		//	結束OpenGL_Graph_point結構
		public static int loop_num;												//	宣告loop_num全域靜態變數，供迴圈使用
		delegate void Display(byte[] buffer);									//	定義Display型態
		//delegate 是可用來封裝具名方法或匿名方法的參考型別。
		/// <summary>
		/// Form1方法
		/// </summary>
		public Form1()															//	宣告Form1方法
		{                                                                       //	進入Form1(由Program.cs的Main呼叫執行)
			UARTConnection1 = new UARTConnection();                             //	初始化UARTConnection1物件
			InitializeComponent();                                              //	呼叫InitializeComponent方法(於Form1.Designer.cs中)初始化表單
			UARTConnection1.InitializeUARTConnectionSetting();                  //	呼叫InitializeUARTConnectionSetting初始化UART連線
		}																		//	結束Form1方法
		public void Form1_Load(object sender, EventArgs e)						//	Form1_Load程式，Form1表單載入時執行
		{																		//	進入Form1_Load方法
			textBox1_Font = new Font("新細明體", 9, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 136);
			//	設定接收字串資料文字方塊預設字型
			
			Transmission_Analysis_Queue = new Queue();							//	初始化Transmission_Analysis_Queue(Uart通訊傳輸資料分析字元佇列)
			OscilloscopeFunctionVariable.Data_Graphic_Queue_X = new Queue<int>();
			//	初始化Data_Graphic_Queue_X(X通道資料繪圖用整數型態佇列)
			OscilloscopeFunctionVariable.Data_Graphic_Queue_Y = new Queue<int>();
			//	初始化Data_Graphic_Queue_Y(Y通道資料繪圖用整數型態佇列)
			OscilloscopeFunctionVariable.Data_Graphic_Queue_Z = new Queue<int>();
			//	初始化Data_Graphic_Queue_Z(Z通道資料繪圖用整數型態佇列)
			label6.Text = "未連線";                                             //	顯示連線狀態為"未連線"
			list_SerialPort();                                   //	呼叫list_SerialPort(偵測並列出已連線SerialPort)方法
		}																		//	結束Form1_Load方法
		private void button1_Click(object sender, EventArgs e)					//	當按下"重新偵測SerialPort"按鈕
		{																		//	進入button1_Click方法
			DebugVariables.Set_button1_Click_Runtimes();                        //	呼叫Set_button1_Click_Runtimes方法記錄button1_Click執行次數
			//UARTConnection.list_SerialPort();                                   //	呼叫list_SerialPort(偵測並列出已連線SerialPort)方法
			list_SerialPort();													//	呼叫list_SerialPort(偵測並列出已連線SerialPort)方法
		}																		//	結束button1_Click方法
		private void button1_Enable()                                           //	button1_Enable方法
		{                                                                       //	進入button1_Enable方法
			button1.Enabled = true;                                             //	設定button1致能
		}                                                                       //	結束button1_Enable方法
		private void button1_Disable()                                          //	button1_Disable方法
		{                                                                       //	進入button1_Disable方法
			button1.Enabled = false;                                            //	設定button1 Disable
		}                                                                       //	結束button1_Disable方法
		private void button2_Click(object sender, EventArgs e)					//	當按下"連線/中斷連線"按鈕
		{                                                                       //	進入button2_Click方法
			DebugVariables.Set_button2_Click_Runtimes();						//	呼叫Set_button2_Click_Runtimes方法記錄button2_Click執行次數
			button2.Enabled = false;                                            //	暫時關閉"連線/中斷連線"按鈕功能
			//UARTConnection.UARTConnectHandle(comboBox1.Text);                 //	呼叫UARTConnectHandle方法
			UARTConnectHandle(comboBox1.Text);								//	呼叫UARTConnectHandle方法
		}                                                                       //	結束button2_Click方法
		private void button2_Enable()                                           //	button2_Enable方法
		{                                                                       //	進入button2_Enable方法
			button2.Enabled = true;                                             //	設定button2致能
		}                                                                       //	結束button2_Enable方法
		private void button2_Disable()                                          //	button2_Disable方法
		{                                                                       //	進入button2_Disable方法
			button2.Enabled = false;                                            //	設定button2 Disable
		}                                                                       //	結束button2_Disable方法
		private void button3_Click(object sender, EventArgs e)					//	當按下"清除"(button3)按鈕
		{                                                                       //	進入button3_Click方法
			DebugVariables.Set_button3_Click_Runtimes();                        //	呼叫Set_button3_Click_Runtimes方法記錄button3_Click執行次數
			textBox1.Clear();													//	清除textBox1(接收字串資料文字方塊)資料
		}                                                                       //	結束button3_Click方法
		private void button3_Enable()                                           //	button3_Enable方法
		{                                                                       //	進入button3_Enable方法
			button3.Enabled = true;                                             //	設定button3致能
		}                                                                       //	結束button3_Enable方法
		private void button3_Disable()                                          //	button3_Disable方法
		{                                                                       //	進入button3_Disable方法
			button3.Enabled = false;                                            //	設定button3 Disable
		}                                                                       //	結束button3_Disable方法
																				//	ToolStripMenuItem選單相關方法
		private void 設定_傳輸設定ToolStripMenuItem_Click(object sender, EventArgs e)
		//	宣告設定_傳輸設定ToolStripMenuItem_Click方法
		{                                                                       //	進入設定_傳輸設定ToolStripMenuItem_Click方法
			DebugVariables.Set_Transmission_Setting_Click_Runtimes();           //	呼叫Set_Transmission_Setting_Click_Runtimes方法記錄Transmission_Setting_Click執行次數
			Form2 Transmission_Setting_form = new Form2();						//	宣告transmission_setting_form代表Form2
			Transmission_Setting_form.Show();									//	顯示transmission_setting_form
		}																		//	結束設定_傳輸設定ToolStripMenuItem_Click方法

		private void 設定_介面設定ToolStripMenuItem_Click(object sender, EventArgs e)
		//	宣告設定_介面設定ToolStripMenuItem_Click方法
		{                                                                       //	進入設定_介面設定ToolStripMenuItem_Click方法
			DebugVariables.Set_User_Interface_Setting_Click_Runtimes();         //	呼叫Set_User_Interface_Setting_Click_Runtimes方法記錄User_Interface_Setting_Click執行次數
			Form3 User_Interface_Setting_form = new Form3();					//	宣告User_Interface_Setting_form代表Form3
			User_Interface_Setting_form.Show();									//	顯示User_Interface_Setting_form
		}																		//	結束設定_介面設定ToolStripMenuItem_Click方法
		public void comboBox1ItemClear()                                        //	comboBox1ItemClear方法
		{                                                                       //	進入comboBox1ItemClear方法
			comboBox1.Items.Clear();                                            //	清空下拉式選單所有項目
		}                                                                       //	結束comboBox1ItemClear方法
		public void comboBox1ItemAdd(string AddItem)							//	comboBox1ItemAdd方法
		{                                                                       //	進入comboBox1ItemAdd方法
			comboBox1.Items.Add(AddItem);										//	以條列式選單(comboBox1)列出已連線的SerialPort
		}                                                                       //	結束comboBox1ItemAdd方法
		public void comboBox1_text_change(object sender, EventArgs e)			//	comboBox1_text_change方法，於comboBox1文字內容改變時執行
		{																		//	進入comboBox1_text_change方法
			if(string.IsNullOrEmpty(comboBox1.Text))							//	若comboBox1內容為空白
			{																	//	進入if敘述
				button2.Enabled = false;										//	關閉"連線"按鈕功能(未選定連線Serialport，可避免發生Error_010002)
			}																	//	結束if敘述
			else																//	若comboBox1內容不為""(空白)
			{																	//	進入else敘述
				button2.Enabled = true;											//	開啟"連線"按鈕功能
			}																	//	結束else敘述
		}                                                                       //	結束comboBox1_text_change方法
		public void list_SerialPort()                                           //	偵測並列出已連線SerialPort方法
		{                                                                       //	進入list_SerialPort方法
			DebugVariables.Set_list_SerialPort_Runtimes();                      //	呼叫Set_list_SerialPort_Runtimes方法遞增list_SerialPort_Runtimes變數
			comboBox1ItemClear();												//	清除下拉式選單
			ComportListToComboBox(UARTConnection1.GetComportList(), comboBox1); //	將Comport偵測結果更新至下拉式選單
			/*if (ports.Length == 0)                                              //	若偵測不到任何已連接的SerialPort(ports.Length為0)
			{                                                                   //	進入if敘述
				ErrorCodeMessage.Error_Message_Show((int)ErrorCodeMessage.ErrorCodeEncoding.NoSerialPortConnected);
				//	顯示錯誤訊息
				button2.Enabled = false;                                        //	關閉"連線/中斷連線"按鈕功能
				textBox1.Enabled = false;                                       //	關閉textBox1(接收字串資料文字方塊)功能
				return;                                                         //	提早結束list_SerialPort方法
			}                                                                   //	結束if敘述
			else                                                                //	若偵測到已連線的SerialPort
			{                                                                   //	進入else敘述
				UARTConnection1.SetConnectedCOMPortCount(ports.Length);          //	記錄已連線的SerialPort數量
				foreach (string port in ports)                                  //	依序處理每個已連線的SerialPort
				{                                                               //	進入foreach敘述
					comboBox1.Items.Add(port);                                  //	以條列式選單(comboBox1)列出已連線的SerialPort
				}                                                               //	結束foreach敘述
				button2.Enabled = false;                                        //	暫時關閉"連線"按鈕功能，待使用者選定愈連線之Serialport(未選定連線Serialport，可避免發生Error_010002)
				textBox1.Enabled = true;                                        //	開啟textBox1(接收字串資料文字方塊)功能
				return;                                                         //	結束list_SerialPort方法
			}                                                                   //	結束else敘述*/
		}                                                                       //	結束list_SerialPort方法
		/// <summary>
		/// ComportListToComboBox方法用於將ComportList型態資料新增至下拉式選單
		/// </summary>
		/// <param name="InputComportList">該參數為欲新增至下拉式選單之ComportList型態資料</param>
		/// <param name="InputComboBox">該參數為下拉式選單物件</param>
		private void ComportListToComboBox(ComportList InputComportList, ComboBox InputComboBox)
		//	ComportListToComboBox方法
		{                                                                       //	進入ComportListToComboBox方法
			foreach (string Item in InputComportList.GetComportList())			//	取出各Comport名稱
			{																	//	進入foreach敘述
				InputComboBox.Items.Add(Item);									//	新增項目至下拉式選單
			}																	//	結束foreach敘述
		}																		//	結束ComportListToComboBox方法
		/// <summary>
		/// UARTConnectHandle方法
		/// UARTConnectHandle方法用於處理UartComport連線設定
		/// 呼叫格式為UARTConnectHandle(comport名稱)
		///  
		/// </summary>
		/// <param name="comport_name"></param>
		public void UARTConnectHandle(string comport_name)                    //	串列埠連線處理UARTConnectHandle方法
		{                                                                       //	進入UARTConnectHandle方法
			DebugVariables.Set_UARTConnectHandle_Runtimes();                  //	呼叫Set_UARTConnectHandle_Runtimes方法遞增UARTConnectHandle_Runtimes變數
			if (UARTConnection1.GetUartComportConnected() == true)            //  若UartComportConnected為True，代表UartComport連線中，將執行中斷連線
			{                                                                   //	進入if敘述
				label6.Text = (comport_name + "正在中斷連線");
				//  顯示連線狀態為(comport_name + "正在中斷連線")，如"COM1正在中斷連線"
				UARTConnection1.SetUartComportConnected(false);               //	更新UartComportConnected
				UARTConnection1.UartComport.Close();                            //	關閉UartComport連線
				button2.Text = "連線";                                          //	更改button2文字為"連線"
				button2.Enabled = true;                                         //	重新開啟"連線/中斷連線"按鈕功能
				label6.Text = "未連線";                                         //	顯示連線狀態為"未連線"
				return;                                                         //	結束UARTConnectHandle方法
			}                                                                   //	結束if敘述
			else                                                                //	若UartComportConnected為False，執行連線
			{                                                                   //	進入else敘述
				label6.Text = "偵測連接埠設定";                                 //	顯示連線狀態為"偵測連接埠設定"
				if (comport_name == "")                                         //	若comport_name為空白(Combobox1未選定)
				{                                                               //	進入if敘述
					ErrorCodeMessage.Error_Message_Show((int)ErrorCodeMessage.ErrorCodeEncoding.NoSerialPortSelected);
					//	顯示錯誤訊息
					button2.Enabled = true;                                     //	重新開啟"連線/中斷連線"按鈕功能
					return;                                                     //	結束UARTConnectHandle方法
				}                                                               //	結束if敘述
				else                                                            //	已選定連接埠
				{                                                               //	進入else敘述
					label6.Text = (comport_name + "正在嘗試連線");              //	顯示連線狀態為(comport_name + "正在嘗試連線")，如"COM1正在嘗試連線"
					try                                                         //	嘗試以comport_name建立串列通訊連線
					{                                                           //	進入try敘述
						UARTConnection1.UartComport = new SerialPort(comport_name);
						//	UartComport串列埠建立comport_name連線
					}                                                           //	結束try敘述
					catch (System.IO.IOException)                               //	當IO發生錯誤時的例外狀況
					{                                                           //	進入catch敘述
						ErrorCodeMessage.Error_Message_Show((int)ErrorCodeMessage.ErrorCodeEncoding.SerialPortConnectError);
						//	顯示錯誤訊息
						button2.Enabled = true;                                 //	重新開啟"連線/中斷連線"按鈕功能
						return;                                                 //	結束UARTConnectHandle方法
					}                                                           //	結束catch敘述
					try                                                         //	以try方式執行資料接收
					{                                                           //	進入try敘述
						if (!UARTConnection1.UartComport.IsOpen)                //	若UartComport未開啟
						{                                                       //	進入if敘述
							UARTConnection1.UartComport.Open();                 //	開啟UartComport
							label6.Text = (comport_name + "已連線");            //	顯示連線狀態為(comport_name + "已連線")，如"COM1已連線"
							UARTConnection1.SetUartComportConnected(true);     //	更新UartComportConnected狀態
							button2.Text = "中斷連線";                          //	更改button2文字為"中斷連線"
							button2.Enabled = true;                             //	重新開啟"連線/中斷連線"按鈕功能
						}                                                       //	結束if敘述
						UARTConnection1.UartComport.DataReceived += new SerialDataReceivedEventHandler(comport_DataReceived);
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
						UARTConnection1.UartComport.Close();                    //  關閉UartComport連線
						button2.Text = "連線";                                  //  更改button2文字為"連線"
						button2.Enabled = true;                                 //  重新開啟"連線/中斷連線"按鈕功能
						return;                                                 //  結束UARTConnectHandle方法
					}                                                           //  結束catch敘述
				}                                                               //  結束else敘述
			}                                                                   //  結束else敘述
		}                                                                       //  結束UARTConnectHandle方法
		private void comport_DataReceived(object sender, SerialDataReceivedEventArgs e)
		//  comport資料接收處理方法
		{                                                                       //  進入comport資料接收處理方法
			DebugVariables.Set_comport_DataReceived_Runtimes();                 //	呼叫Set_comport_DataReceived_Runtimes方法記錄comport_DataReceived執行次數
			if (UARTConnection1.GetUartComportConnected() == false)           //  若UartComport未連線(UartComportConnected值為False)
			{                                                                   //  進入if敘述
				return;                                                         //  結束comport資料接收處理方法
			}                                                                   //  結束if敘述
			byte[] buffer = new byte[1024];                                     //  宣告buffer暫存讀取資料，型態為Byte
			int length = 0;                                                     //  宣告length變數用於記錄串列資料緩衝區長度
			try                                                                 //  以try語法嘗試讀取Uart串列資料緩衝區
			{                                                                   //  進入try敘述
				length = (sender as System.IO.Ports.SerialPort).Read(buffer, 0, buffer.Length); 
				//  讀取Uart串列資料緩衝區
			}                                                                   //  結束try敘述
			catch (ArgumentNullException)                                       //  當發生NULL例外狀況
			{                                                                   //  進入catch敘述
				return;                                                         //	結束comport_DataReceived方法
			}                                                                   //  結束catch敘述
			Uart_Buffer_Size = length;                                          //  更新Uart_Buffer_Size數值
			try                                                                 //  嘗試調整buffer陣列大小
			{                                                                   //  進入try敘述
				Array.Resize(ref buffer, length);                               //  調整buffer陣列大小
			}                                                                   //  結束try敘述
			catch (ArgumentOutOfRangeException outOfRange)                      //  若調整buffer陣列空間時範圍錯誤
			{                                                                   //  進入catch敘述
				var result = MessageBox.Show                                    //  顯示錯誤訊息
					(                                                           //  進入錯誤訊息MessageBox設定
						outOfRange.Message,"",
						MessageBoxButtons.OK,                                   //  MessageBox選項為OK
						MessageBoxIcon.Error                                    //  顯示錯誤標誌
					);                                                          //  結束錯誤訊息MessageBox設定
			}                                                                   //  結束catch敘述
			Display d = new Display(DisplayText);
			try                                                                 //  以try執行invoke
			{                                                                   //  進入try敘述
				Invoke(d, new object[] { buffer });
			}                                                                   //  結束try敘述
			catch (Exception)                                                   //  若發生例外狀況
			{                                                                   //  進入catch敘述
				MessageBox.Show(e.ToString());                                  //  顯示錯誤訊息
				return;                                                         //  跳出方法
			}                                                                   //  結束catch敘述            
			string message = BitConverter.ToString(buffer,0);                   //  取得Uart傳輸之Buffer資料(ASCII編碼值)
			Uart_Buffer_ASCII_Data = message;                                   //  將Uart傳輸之Buffer資料(ASCII編碼值)填入Uart_Buffer_ASCII_Data
		}                                                                       //  結束comport資料接收處理方法
		private void DisplayText(byte[] buffer)                                 //  DisplayText顯示文字方法
		{                                                                       //  進入DisplayText顯示文字方法
			DebugVariables.Set_DisplayText_Runtimes();                          //	呼叫Set_DisplayText_Runtimes方法記錄DisplayText方法執行次數
			textBox1.Font = textBox1_Font;                                      //  設定文字方塊顯示字型
			//textBox1.Text += String.Format("{0}{1}", BitConverter.ToString(buffer), Environment.NewLine);
			//  將buffer中之接收文字(ascii原始碼)顯示於textBox1上
			//textBox1.Text += System.Text.Encoding.ASCII.GetString(buffer);    //  已修正使用AppendText方法顯示
			textBox1.AppendText(System.Text.Encoding.ASCII.GetString(buffer));
			//  將buffer中之接收資料(ascii原始碼)轉換為字串(符號字元)，並顯示於textBox1上
			FileIO FileIO1 = new FileIO();                                      //	建立FileIO1(檔案讀寫功能控制)物件
			FileIO1.FileWrite("Data.txt",System.Text.Encoding.ASCII.GetString(buffer));
			//  將buffer中之接收資料(ascii原始碼)轉換為字串(符號字元)，並以FileMode.Append模式寫入"Data.txt"檔案
			FileIO1.FileWrite("Date_Data.txt", DateTime.Now.ToString() + "\t" + System.Text.Encoding.ASCII.GetString(buffer) + "\r\n");
			//  以FileMode.Append模式建立包含傳輸時間資訊的資料記錄檔"Date_Data.txt"
			Transmission_Buffer_CharArray = System.Text.Encoding.ASCII.GetString(buffer).ToCharArray();
			//  將buffer中之接收資料(ascii原始碼)轉換為字串(符號字元)後，再轉換為字元陣列(CharArray)，存入Transmission_Buffer_CharArray
			textBox1.ScrollBars = ScrollBars.Vertical;                          //  控制textBox1顯示垂直捲軸
			textBox1.SelectionStart = textBox1.Text.Length;                     //  控制textBox1游標位置為textBox1內容結束處
			textBox1.ScrollToCaret();                                           //  捲動textBox1捲軸至游標位置(自動捲動至最新資料)
			Total_Transmission_Length = Total_Transmission_Length + buffer.Length;
			//  累計接收字串長度
			Label2.Text = Total_Transmission_Length.ToString();                 //  顯示累計字串長度
			//Uart_Data_Analysis方法與Uart_Data_Analysis_Queue方法擇一使用，由Analysis_Graphic_Mode靜態全域變數控制
			/*if( (Analysis_Graphic_Mode / 4) % 2 == 0)                           //  若Analysis_Graphic_Mode二進位數值為0XX
			{                                                                   //  進入if敘述
				Uart_Data_Analysis();                                           //  呼叫Uart_Data_Analysis方法
			}                                                                   //  結束if敘述
			else                                                                //  Analysis_Graphic_Mode二進位數值不為0XX
			{                                                                   //  進入else敘述
				Uart_Data_Analysis_Queue();                                     //  呼叫Uart_Data_Analysis_Queue方法
			}                                                                   //  結束else敘述*/
		}                                                                       //  結束DisplayText顯示文字方法
	}                                                                           //  結束Form1類別
}

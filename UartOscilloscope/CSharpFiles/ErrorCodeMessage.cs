using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                                                     //	使用System.Windows.Forms函式庫

namespace UartOscilloscope                                                      //	命名空間為UartOscilloscope
{                                                                               //	進入命名空間
	public class ErrorCodeMessage                                               //	宣告ErrorCodeMessage類別
	{                                                                           //	進入ErrorCodeMessage類別
		private enum ErrorCodeEncoding                                          //	ErrorCode錯誤編碼列舉型態
		{                                                                       //	進入ErrorCode錯誤編碼列舉型態
			NoError = 000000,                                                   //	NoError編碼
			NoSerialPortConnected = 010001,                                     //	NoSerialPortConnected編碼
			NoSerialPortSelected = 010002,                                      //	NoSerialPortSelected編碼
			SerialPortConnectError = 010003,                                    //	SerialPortConnectError編碼
			LoginAccountNull = 040001,                                          //	LoginAccountNull編碼
			LoginPasswordNull = 040002,                                         //	LoginPasswordNull編碼
			LoginAccountError = 040003,                                         //	LoginAccountError編碼
			LoginPasswordError = 040004                                         //	LoginPasswordError編碼
		}                                                                       //	結束ErrorCode錯誤編碼列舉型態
		private struct Error_message_struct                                     //  宣告Error_message_struct結構
		{
			public string Error_Message;                                        //  宣告Error_Message(錯誤訊息)字串
			public string Error_Title;                                          //  宣告Error_Title(錯誤訊息標題)字串
			public MessageBoxButtons Error_MessageBoxButton;                    //  宣告Error_MessageBoxButton(錯誤訊息方塊按鈕)物件
			public MessageBoxIcon Error_MessageBoxIcon;                         //  宣告Error_MessageBoxIcon(錯誤訊息方塊圖示)物件
			/** Error_message_struct建構子 **/
			public Error_message_struct(string Error_Message_set,               //  宣告Error_message_struct建構子，設定建構子參數
										string Error_Title_set,
										MessageBoxButtons Error_MessageBoxButton_set,
										MessageBoxIcon Error_MessageBoxIcon_set)
			{                                                                   //  進入Error_message_struct建構子
				Error_Message = Error_Message_set;                              //  設定Error_message_struct建構子
				Error_Title = Error_Title_set;                                  //  設定Error_message_struct建構子
				Error_MessageBoxButton = Error_MessageBoxButton_set;            //  設定Error_message_struct建構子
				Error_MessageBoxIcon = Error_MessageBoxIcon_set;                //  設定Error_message_struct建構子
			}                                                                   //  結束Error_message_struct建構子

		}                                                                       //  結束Error_message_struct結構
		/**  定義Error_010001錯誤訊息  **/
		private const string Error_010001_Message = "未偵測到任何已連接的SerialPort，ErrorCode=010001";
		private const string Error_010001_Title = "None of SerialPort";
		private const MessageBoxButtons Error_010001_MessageBoxButton = MessageBoxButtons.OK;
		private const MessageBoxIcon Error_010001_MessageBoxIcon = MessageBoxIcon.Warning;
		private static Error_message_struct Error_010001 =
			new Error_message_struct(Error_010001_Message, Error_010001_Title, Error_010001_MessageBoxButton, Error_010001_MessageBoxIcon);
		/**  定義Error_010002錯誤訊息  **/
		private const string Error_010002_Message = "未選定連接埠，ErrorCode=010002";
		private const string Error_010002_Title = "Connect Error";
		private const MessageBoxButtons Error_010002_MessageBoxButton = MessageBoxButtons.OK;
		private const MessageBoxIcon Error_010002_MessageBoxIcon = MessageBoxIcon.Error;
		private static Error_message_struct Error_010002 =
			new Error_message_struct(Error_010002_Message, Error_010002_Title, Error_010002_MessageBoxButton, Error_010002_MessageBoxIcon);
		/**  定義Error_010003錯誤訊息  **/
		private const string Error_010003_Message = "裝置不存在或無法建立連線，ErrorCode=010003";
		private const string Error_010003_Title = "Connect Error";
		private const MessageBoxButtons Error_010003_MessageBoxButton = MessageBoxButtons.OK;
		private const MessageBoxIcon Error_010003_MessageBoxIcon = MessageBoxIcon.Warning;
		private static Error_message_struct Error_010003 =
			new Error_message_struct(Error_010003_Message, Error_010003_Title, Error_010003_MessageBoxButton, Error_010003_MessageBoxIcon);
		public static void Error_Message_Show(int ErrorCode_input)
		{                                                                       //  進入Error_Message_Show副程式
			switch (ErrorCode_input)
			{                                                                   //  進入switch敘述
				case 010001:
					var warning_010001 = MessageBox.Show(Error_010001.Error_Message,
														Error_010001.Error_Title,
														Error_010001.Error_MessageBoxButton,
														Error_010001.Error_MessageBoxIcon);
					break;
				case 010002:
					var warning_010002 = MessageBox.Show(Error_010002.Error_Message,
														Error_010002.Error_Title,
														Error_010002.Error_MessageBoxButton,
														Error_010002.Error_MessageBoxIcon);
					break;
				case 010003:
					var warning = MessageBox.Show(Error_010003.Error_Message,
														Error_010003.Error_Title,
														Error_010003.Error_MessageBoxButton,
														Error_010003.Error_MessageBoxIcon);
					break;
				default:
					break;
			}                                                                   //  結束switch敘述
		}                                                                       //  結束Error_Message_Show副程式
	}                                                                           //	結束ErrorCodeMessage類別
}

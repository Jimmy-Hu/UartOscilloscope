using System;                                                                   //  使用System函式庫
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                                                     //  使用System.Windows.Forms函式庫
using System.Globalization;                                                     //  使用System.Windows.Forms函式庫

namespace UartOscilloscope                                                      //  命名空間為本程式
{                                                                               //  進入命名空間
    public partial class Form5 : Form                                           //  Form5類別
    {                                                                           //  進入Form5類別
        public Form5()                                                          //  宣告Form5
        {                                                                       //  進入Form5
            InitializeComponent();                                              //  初始化表單
        }                                                                       //  結束Form5
        private void Form5_Load(object sender, EventArgs e)                     //  宣告Form5_Load方法，Form5表單載入時執行
        {                                                                       //  進入Form5_Load方法
            label2.Text = Form4.Debug_Login_Account_Input.Debug_Login_Account;  //  顯示登入之除錯帳號
            Debug_Information_Refresh();                                        //  呼叫Debug_Information_Reflash方法
            timer1.Interval = 100;                                              //  設定timer1執行頻率
            timer1.Enabled = true;                                              //  啟動timer1，即時更新除錯資訊
        }                                                                       //  結束Form5_Load方法
        private void timer1_Tick(object sender, EventArgs e)                    //  宣告timer1_Tick方法
        {                                                                       //  進入timer1_Tick方法
            Debug_Information_Refresh();                                        //  呼叫Debug_Information_Reflash方法
        }                                                                       //  結束timer1_Tick方法
        private void button1_Click(object sender, EventArgs e)                  //  宣告button1_Click方法，當按下button1時執行
        {                                                                       //  進入button1_Click方法
            Debug_Information_Reset();                                          //  呼叫Debug_Information_Reset除錯資料重置方法
        }                                                                       //  結束button1_Click方法
        public void Debug_Information_Refresh()                                 //  宣告Debug_Information_Refresh除錯資料更新方法
        {                                                                       //  進入除錯資料更新方法
            label4.Text = Form4.Login_Date.ToString();                          //  顯示除錯模式登入時間
            label6.Text = (DateTime.Now.ToString());							//  顯示現在時間
            label8.Text = Form1.UARTConnection1.GetConnectedCOMPortCount().ToString();
			//  顯示已連線之Serialport數量
            label10.Text = DebugVariables.Get_list_SerialPort_Runtimes().ToString();
			//  顯示list_SerialPort方法執行次數
            label12.Text = DebugVariables.Get_comport_DataReceived_Runtimes().ToString();
			//  顯示comport_DataReceived方法執行次數
            label14.Text = DebugVariables.Get_UartComport_handle_Runtimes().ToString();
			//  顯示UartComport_handle方法執行次數
            label16.Text = DebugVariables.Get_DisplayText_Runtimes().ToString(); //  顯示DisplayText方法執行次數
            label18.Text = DebugVariables.Get_button1_Click_Runtimes().ToString();
			//  顯示button1_Click方法執行次數
            label20.Text = DebugVariables.Get_button2_Click_Runtimes().ToString();
			//  顯示button2_Click方法執行次數
            label22.Text = DebugVariables.Get_button3_Click_Runtimes().ToString();
			//  顯示button3_Click方法執行次數
            label24.Text = DebugVariables.Get_Transmission_Setting_Click_Runtimes().ToString();
            //  顯示設定_傳輸設定ToolStripMenuItem_Click方法
            label26.Text = DebugVariables.Get_User_Interface_Setting_Click_Runtimes().ToString();
            //  顯示設定_介面設定ToolStripMenuItem_Click方法執行次數
            label101.Text = Form1.Uart_Buffer_Size.ToString();                  //  顯示Uart接收資料Buffer大小
            textBox1.Text = Form1.Uart_Buffer_ASCII_Data;                       //  顯示Uart傳輸之Buffer資料(ASCII編碼值)
        }                                                                       //  結束除錯資料更新方法
        public void Debug_Information_Reset()                                   //  宣告Debug_Information_Reset除錯資料重置方法
        {                                                                       //  進入除錯資料重置方法
			DebugVariables.ResetDebugVariables();                               //	呼叫ResetDebugVariables方法重置變數
		}                                                                       //  結束除錯資料重置方法
    }                                                                           //  結束Form5類別
}                                                                               //  結束命名空間

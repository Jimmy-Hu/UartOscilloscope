using System;                                                                   //  使用System函式庫
using System.Collections.Generic;                                               //  使用System.Collections.Generic函式庫
using System.ComponentModel;                                                    //  使用System.ComponentModel函式庫
using System.Data;                                                              //  使用System.Data函式庫
using System.Drawing;                                                           //  使用System.Drawing函式庫
using System.Linq;                                                              //  使用System.Linq函式庫
using System.Text;                                                              //  使用System.Text函式庫
using System.Threading.Tasks;                                                   //  使用System.Threading.Tasks函式庫
using System.Windows.Forms;                                                     //  使用System.Windows.Forms函式庫

namespace UartOscilloscope                                                      //  命名空間為本程式
{                                                                               //  進入命名空間
    public partial class Form2 : Form                                           //  Form2類別
    {                                                                           //  進入Form2類別
        public Form2()                                                          //  宣告Form2
        {                                                                       //  進入Form2
            InitializeComponent();                                              //  初始化表單
        }                                                                       //  結束Form2
        private void Form2_Load(object sender, EventArgs e)                     //  Form2表單載入時執行
        {                                                                       //  進入Form2_Load副程式
            textBox1.Text = UARTConnection.Get_BaudRate().ToString();           //  載入當前鮑率(BaudRate)設定
            comboBox1.SelectedIndex = UARTConnection.Get_ParitySetting();       //  載入當前同位位元設定
        }                                                                       //  結束Form2_Load副程式
        private void button1_Click(object sender, EventArgs e)                  //  當按下"儲存"按鈕
        {                                                                       //  進入button1_Click副程式
            UARTConnection.Set_BaudRate(int.Parse(textBox1.Text));              //  更新BaudRate鮑率設定
            UARTConnection.Set_ParitySetting(comboBox1.SelectedIndex);          //  更新Parity_num同位位元設定
            var Information = MessageBox.Show                                   //  顯示通知訊息
                    (                                                           //  進入通知訊息MessageBox設定
                        "連線設定將於下次連線生效",                             //  顯示文字"連線設定將於下次連線生效"
                        "Information",                                          //  設定MessageBox標題為"Information"
                        MessageBoxButtons.OK,                                   //  MessageBox選項為OK
                        MessageBoxIcon.Information                              //  顯示通知標誌
                    );                                                          //  結束通知訊息MessageBox設定
            Close();                                                            //  關閉表單
        }                                                                       //  結束button1_Click副程式
    }                                                                           //  結束Form2類別
}                                                                               //  結束命名空間

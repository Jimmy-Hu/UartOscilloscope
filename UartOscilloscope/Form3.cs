using System.Windows.Forms;                                                     //  使用System.Windows.Forms函式庫
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace UartOscilloscope                                              //  命名空間為本程式
{                                                                               //  進入命名空間
    public partial class Form3 : Form                                           //  Form3類別
    {                                                                           //  進入Form3類別
        public Form3()                                                          //  宣告Form3
        {                                                                       //  進入Form3
            InitializeComponent();                                              //  初始化表單
        }                                                                       //  結束Form3

        private void button1_Click(object sender, System.EventArgs e)           //  宣告button1_Click方法，按下"儲存"按鈕時執行
        {                                                                       //  進入button1_Click方法

            Close();                                                            //  關閉表單
        }                                                                       //  結束button1_Click方法

        private void button2_Click(object sender, System.EventArgs e)           //  宣告button2_Click方法，按下"字型"按鈕時執行
        {                                                                       //  進入button2_Click方法
            if (fontDialog1.ShowDialog() == DialogResult.OK)                    //  若字型設定正確
            {                                                                   //  進入if敘述
                Form1.textBox1_Font = fontDialog1.Font;                         //  更新字型設定(textBox1_Font)
            }                                                                   //  結束if敘述
        }                                                                       //  結束button2_Click方法

        private void button3_Click(object sender, System.EventArgs e)           //  宣告button3_Click方法，按下"登入除錯介面"按鈕時執行
        {                                                                       //  進入button3_Click方法
            Form4 Debug_Login_form = new Form4();                               //  宣告Debug_Login_form代表Form4
            Debug_Login_form.Show();                                            //  顯示Debug_Login_form
        }                                                                       //  結束button3_Click方法
    }                                                                           //  結束Form3類別
}                                                                               //  結束命名空間

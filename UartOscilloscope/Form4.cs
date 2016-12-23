using System;                                                                   //  使用System函式庫
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;                                                     //  使用System.Windows.Forms函式庫

namespace WindowsFormsApplication6                                              //  命名空間為本程式
{                                                                               //  進入命名空間
    public partial class Form4 : Form                                           //  Form4類別
    {                                                                           //  進入Form4類別
        public static Form1.Debug_Login_Account_struct                          //  宣告Debug_Login_Account_Input全域變數，儲存輸入帳號密碼資訊
            Debug_Login_Account_Input = new Form1.Debug_Login_Account_struct(); //  宣告Debug_Login_Account_Input全域變數，儲存輸入帳號密碼資訊
        public static DateTime Login_Date;                                      //  宣告Login_Date時間變數，記錄除錯模式登入時間
        public Form4()                                                          //  宣告Form4
        {                                                                       //  進入Form4
            InitializeComponent();                                              //  初始化表單
        }                                                                       //  結束Form4
        private void Form4_Load(object sender, EventArgs e)                     //  宣告Form4_Load副程式，Form4表單載入時執行
        {                                                                       //  進入Form4_Load副程式
            textBox2.UseSystemPasswordChar = true;                              //  設定textBox2(密碼輸入欄位)顯示字元隱藏
        }                                                                       //  結束Form4_Load副程式
        private void button1_Click(object sender, EventArgs e)                  //  宣告button1_Click副程式，按下"登入除錯模式"按鈕時執行
        {                                                                       //  進入button1_Click副程式
            //  輸入資訊檢查
            if (textBox1.Text == "")                                            //  若帳號資訊(textBox1欄位)為空白
            {                                                                   //  進入if敘述
                Form1.Error_Code = 040001;                                      //  記錄Error_Code
                var Error = MessageBox.Show                                     //  顯示錯誤訊息
                    (                                                           //  進入錯誤訊息MessageBox設定
                        "請輸入帳號，Error_Code=" + Form1.Error_Code,           //  顯示錯誤訊息"請輸入帳號"，同時顯示Error_Code
                        "請輸入帳號",                                           //  顯示錯誤訊息標題為"請輸入帳號"
                        MessageBoxButtons.OK,                                   //  顯示"OK"按鈕
                        MessageBoxIcon.Error                                    //  顯示錯誤標誌
                    );                                                          //  結束錯誤訊息MessageBox設定
                return;                                                         //  結束button1_Click副程式
            }                                                                   //  結束if敘述
            if (textBox2.Text == "")                                            //  若密碼資訊(textBox2欄位)為空白
            {                                                                   //  進入if敘述
                Form1.Error_Code = 040002;                                      //  記錄Error_Code
                var Error = MessageBox.Show                                     //  顯示錯誤訊息
                    (                                                           //  進入錯誤訊息MessageBox設定
                        "請輸入密碼，Error_Code=" + Form1.Error_Code,           //  顯示錯誤訊息"請輸入密碼"，同時顯示Error_Code
                        "請輸入密碼",                                           //  顯示錯誤訊息標題為"請輸入密碼"
                        MessageBoxButtons.OK,                                   //  顯示"OK"按鈕
                        MessageBoxIcon.Error                                    //  顯示錯誤標誌
                    );                                                          //  結束錯誤訊息MessageBox設定
                return;                                                         //  結束button1_Click副程式
            }                                                                   //  結束if敘述
            Debug_Login_Account_Input.Debug_Login_Account = textBox1.Text;      //  將輸入之帳號資訊(textBox1.Text欄位)填入Debug_Login_Account_Input.Debug_Login_Account
            Debug_Login_Account_Input.Debug_Login_Password = textBox2.Text;     //  將輸入之密碼資訊(textBox2.Text欄位)填入Debug_Login_Account_Input.Debug_Login_Password
            if (Debug_Login_Account_Input.Debug_Login_Account ==                //  檢測輸入帳號，若輸入帳號正確則進入if敘述
                Form1.Debug_Account1.Debug_Login_Account)                       //  檢測輸入帳號，若輸入帳號正確則進入if敘述
            {                                                                   //  進入if敘述
                if (Debug_Login_Account_Input.Debug_Login_Password ==           //  檢測輸入密碼，若輸入密碼正確則進入if敘述
                Form1.Debug_Account1.Debug_Login_Password)                      //  檢測輸入密碼，若輸入密碼正確則進入if敘述
                {                                                               //  進入if敘述
                    var warning = MessageBox.Show                               //  顯示通知訊息
                    (                                                           //  進入警告訊息MessageBox設定
                        "已成功登入" + Form1.Debug_Account1.Debug_Login_Account,//  顯示"已成功登入"，並顯示登入帳號名稱
                        "登入成功",                                             //  訊息標題為"登入成功"
                        MessageBoxButtons.OK,                                   //  顯示"OK"按鈕
                        MessageBoxIcon.Information                              //  顯示information標誌
                    );                                                          //  結束警告訊息MessageBox設定
                    Login_Date = DateTime.Now;                                  //  記錄除錯模式登入時間
                    Form1.Program_Work_Mode = 1;                                //  進入除錯模式，設定Program_Work_Mode值為1
                    Form5 Debug_form = new Form5();                             //  宣告Debug_form代表Form5
                    Debug_form.Show();                                          //  顯示Debug_form
                    Close();                                                    //  關閉本表單
                }                                                               //  結束if敘述
                else                                                            //  若密碼輸入錯誤，則進入else敘述
                {                                                               //  進入else敘述
                    Form1.Error_Code = 040004;                                  //  記錄Error_Code
                    var warning = MessageBox.Show                               //  顯示錯誤訊息
                    (                                                           //  進入錯誤訊息MessageBox設定
                        "密碼錯誤，Error_Code=" + Form1.Error_Code,             //  顯示錯誤訊息"密碼錯誤"，同時顯示Error_Code
                        "密碼錯誤",                                             //  顯示錯誤訊息標題為"密碼錯誤"
                        MessageBoxButtons.OK,                                   //  顯示"OK"按鈕
                        MessageBoxIcon.Error                                    //  顯示錯誤標誌
                    );                                                          //  結束警告訊息MessageBox設定
                    textBox1.Text = "";                                         //  清空帳號輸入欄位(textBox1)
                    textBox2.Text = "";                                         //  清空密碼輸入欄位(textBox2)
                    return;                                                     //  結束button1_Click副程式
                }                                                               //  結束else敘述
            }                                                                   //  結束if敘述
            else                                                                //  若帳號輸入錯誤，則進入else敘述
            {                                                                   //  進入else敘述
                Form1.Error_Code = 040003;                                      //  記錄Error_Code
                var warning = MessageBox.Show                                   //  顯示錯誤訊息
                (                                                               //  進入錯誤訊息MessageBox設定
                    "帳號錯誤，Error_Code=" + Form1.Error_Code,                 //  顯示錯誤訊息"帳號錯誤"，同時顯示Error_Code
                    "帳號錯誤",                                                 //  顯示錯誤訊息標題為"帳號錯誤"
                    MessageBoxButtons.OK,                                       //  顯示"OK"按鈕
                    MessageBoxIcon.Error                                        //  顯示錯誤標誌
                );                                                              //  結束警告訊息MessageBox設定
                textBox1.Text = "";                                             //  清空帳號輸入欄位(textBox1)
                textBox2.Text = "";                                             //  清空密碼輸入欄位(textBox2)
                return;                                                         //  結束button1_Click副程式
            }                                                                   //  結束else敘述
        }                                                                       //  結束button1_Click副程式

    }                                                                           //  結束Form4類別
}                                                                               //  結束命名空間

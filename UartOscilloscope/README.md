# UartOscilloscope(Uart介面示波器)

##功能說明：
軟體執行模式分為正常(Normal)模式與除錯(Debug)模式。正常模式下提供下列功能：
- 可執行Uart連線。
- 可調整Uart連線設定(鮑率、同位位元)。
- 可調整一般操作介面配置(Uart資料顯示字型大小、粗體、斜體等)。
除錯模式下除包含正常模式全部功能外，更提供以下額外資訊進行除錯測試與調整設定：
- 顯示已連線(可供程式使用)的SerialPort(串列通訊埠)數量。
- 顯示「button1_Click」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「button2_Click」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「button3_Click」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「設定_傳輸設定ToolStripMenuItem_Click」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「設定_介面設定ToolStripMenuItem_Click」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「list_SerialPort」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「comport_DataReceived」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「Uart_comport_handle」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「DisplayText」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 可於執行comport_DataReceived副程式時顯示Uart傳輸之Buffer大小。
- 可於執行comport_DataReceived副程式時顯示Uart傳輸之Buffer資料(ASCII編碼值)。
- 顯示錯誤資訊編碼(Error_Code)。

##版本資訊：
- 2016.8.12(五)
	- 宣告Analysis_Graphic_Mode靜態全域變數，控制程式分析與繪圖方法。
	- 設計編碼可參考副程式架構圖。
	- DisplayText副程式中textBox1顯示資料方法改進：
	textBox1.Text += System.Text.Encoding.ASCII.GetString(buffer);改為textBox1.AppendText(System.Text.Encoding.ASCII.GetString(buffer));
	- comport資料接收處理副程式中以try方法執行invoke
- 2016.11.13(日)
	- 宣告警告訊息類別(Error_code_message)，統整錯誤訊息資訊。
					於警告訊息類別(Error_code_message)建立Error_010001_Message、Error_010001_Title、Error_010001_MessageBoxButton、Error_010001_MessageBoxIcon四項靜態物件
					結構化錯誤訊息，建立Error_message_struct(錯誤訊息結構)，
					且將錯誤訊息內容封裝於Error_message_struct(錯誤訊息結構)中，外部無法任意修改，
					另錯誤訊息顯示不再直接呼叫MessageBox.Show，而是由Error_code_message類別中的Error_Message_Show副程式執行錯誤訊息顯示
- 2016.12.23(五)	重新命名專案為UartOscilloscope，並上傳至GitHub
- 2016.12.24(六)	調整命名空間(namespace)為UartOscilloscope
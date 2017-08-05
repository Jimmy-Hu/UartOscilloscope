# UartOscilloscope(Uart介面示波器)

## 功能說明：
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
- 顯示「UartComport_handle」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 顯示「DisplayText」副程式自程式開始運行時之執行次數，可手動重置(歸零)。
- 可於執行comport_DataReceived副程式時顯示Uart傳輸之Buffer大小。
- 可於執行comport_DataReceived副程式時顯示Uart傳輸之Buffer資料(ASCII編碼值)。
- 顯示錯誤資訊編碼(ErrorCode)。


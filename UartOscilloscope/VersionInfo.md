## Visual Studio C#程式版本資訊：
- 2016.8.12(五)
	- 宣告Analysis_Graphic_Mode靜態全域變數，控制程式分析與繪圖方法。
	- 設計編碼可參考方法架構圖。
	- DisplayText方法中textBox1顯示資料方法改進：
	textBox1.Text += System.Text.Encoding.ASCII.GetString(buffer);改為textBox1.AppendText(System.Text.Encoding.ASCII.GetString(buffer)); 。
	- comport資料接收處理方法中以try方法執行invoke。
- 2016.11.13(日)
	- 宣告警告訊息類別(ErrorCodeMessage)，統整錯誤訊息資訊。
	- 於警告訊息類別(ErrorCodeMessage)建立Error_010001_Message、Error_010001_Title、Error_010001_MessageBoxButton、Error_010001_MessageBoxIcon四項靜態物件
		結構化錯誤訊息，建立Error_message_struct(錯誤訊息結構)，
		且將錯誤訊息內容封裝於Error_message_struct(錯誤訊息結構)中，外部無法任意修改，
		另錯誤訊息顯示不再直接呼叫MessageBox.Show，而是由ErrorCodeMessage類別中的Error_Message_Show方法執行錯誤訊息顯示。
- 2016.12.23(五)
	- 重新命名專案為UartOscilloscope，並上傳至GitHub－https://github.com/60071jimmy/UartOscilloscope
- 2016.12.24(六)
	- 調整命名空間(namespace)為UartOscilloscope
- 2017.7.7(五)
	- 上傳方法架構圖至doc/IMG目錄
- 2017.7.8(六)
	- 新增ErrorCodeMessage.cs檔案，並將ErrorCodeMessage類別提取移動至ErrorCodeMessage.cs檔案中
	- 新增OscilloscopeFunctionVariable.cs檔案，並將OscilloscopeFunctionVariable類別提取移動至OscilloscopeFunctionVariable.cs檔案中
- 2017.7.9(日)
	- 於OscilloscopeFunctionVariable.cs檔案中新增Get_ADC_Raw_Data_Max方法，用以取得ADC_Raw_Data_Max數值，並將ADC_Raw_Data_Max變數設定為private
	- 建立CSharpFiles資料夾存放自訂程式檔
	- 建立VersionInfo.cs檔案並

未解決issue：
	1、COM port中斷連線有時會導致程式當機
	2、以Queue資料結構分析字串有時會發生錯誤
	3、
## Visual Studio C#程式版本資訊：
- 2016.8.12(五)
	- 宣告Analysis_Graphic_Mode靜態全域變數，控制程式分析與繪圖方法。
	- 設計編碼可參考副程式架構圖。
	- DisplayText副程式中textBox1顯示資料方法改進：
	textBox1.Text += System.Text.Encoding.ASCII.GetString(buffer);改為textBox1.AppendText(System.Text.Encoding.ASCII.GetString(buffer)); 。
	- comport資料接收處理副程式中以try方法執行invoke。
- 2016.11.13(日)
	- 宣告警告訊息類別(ErrorCode_message)，統整錯誤訊息資訊。
	- 於警告訊息類別(ErrorCode_message)建立Error_010001_Message、Error_010001_Title、Error_010001_MessageBoxButton、Error_010001_MessageBoxIcon四項靜態物件
		結構化錯誤訊息，建立Error_message_struct(錯誤訊息結構)，
		且將錯誤訊息內容封裝於Error_message_struct(錯誤訊息結構)中，外部無法任意修改，
		另錯誤訊息顯示不再直接呼叫MessageBox.Show，而是由ErrorCode_message類別中的Error_Message_Show副程式執行錯誤訊息顯示。
- 2016.12.23(五)
	- 重新命名專案為UartOscilloscope，並上傳至GitHub－https://github.com/60071jimmy/UartOscilloscope
- 2016.12.24(六)
	- 調整命名空間(namespace)為UartOscilloscope
- 2017.7.7(五)
	- 上傳副程式架構圖至doc/IMG目錄
- 2017.7.8(六)
	- 新增ErrorCode_message.cs檔案，並將ErrorCode_message類別提取移動至ErrorCode_message.cs檔案中
	- 新增Oscilloscope_function_variable.cs檔案，並將Oscilloscope_function_variable類別提取移動至Oscilloscope_function_variable.cs檔案中
- 2017.7.9(日)
	- 於Oscilloscope_function_variable.cs檔案中新增Get_ADC_Raw_Data_Max方法，用以取得ADC_Raw_Data_Max數值，並將ADC_Raw_Data_Max變數設定為private
	- 建立CSharpFiles資料夾存放自訂程式檔

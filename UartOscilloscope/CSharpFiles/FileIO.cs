///   <summary>
///   C#實作Uart接收程式，By Jimmy Hu
///   This program is licensed under the Apache License 2.0.
///   </summary>
using System;
using System.Collections.Generic;
/*	System.IO函式庫定義檔案讀寫相關函式
 */
using System.IO;                                                                //	使用System.IO函式庫
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope
{                                                                               //	進入命名空間
	public class FileIO                                                         //	FileIO類別
	{                                                                           //	進入FileIO類別
		/// <summary>
		/// FileWrite方法
		/// FileName為欲寫入檔案名稱
		/// InputString為欲寫入檔案之字串資料
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="InputString"></param>
		public void FileWrite(string FileName, string InputString)
		{                                                                       //  進入FileWrite方法
			FileStream file_stream = new FileStream(FileName, FileMode.Append);
			//  建立檔案指標，指向指定檔案名稱，模式為傳入之File_mode
			byte[] Input_data = System.Text.Encoding.Default.GetBytes(InputString);
			//  將填入資料轉為位元陣列
			file_stream.Write(Input_data, 0, Input_data.Length);                //  寫入資料至檔案中
			file_stream.Flush();                                                //  清除緩衝區
			file_stream.Close();                                                //  關閉檔案
		}                                                                       //  結束FileWrite方法
		/// <summary>
		/// 宣告FileWrite方法，將資料寫入檔案
		/// FileName為欲寫入檔案名稱
		/// InputString為欲寫入檔案之字串資料
		/// File_mode為開啟檔案模式
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="InputString"></param>
		/// <param name="File_mode"></param>
		public void FileWrite(string FileName, string InputString, FileMode File_mode)
		{                                                                       //  進入FileWrite方法
			FileStream file_stream = new FileStream(FileName, File_mode);       //  建立檔案指標，指向指定檔案名稱，模式為傳入之File_mode
			byte[] Input_data = System.Text.Encoding.Default.GetBytes(InputString);
			//  將填入資料轉為位元陣列
			file_stream.Write(Input_data, 0, Input_data.Length);                //  寫入資料至檔案中
			file_stream.Flush();                                                //  清除緩衝區
			file_stream.Close();                                                //  關閉檔案
		}                                                                       //  結束FileWrite方法
		public string ReadTxTFile(string FileName, Encoding encoding)			//  宣告ReadTxTFile方法
		{                                                                       //  進入ReadTxTFile方法
			//***區域變數宣告***
			System.IO.StreamReader textreader;                                  //  宣告textreader為System.IO.StreamReader物件
			string InputString;                                                 //  宣告讀入字串
			InputString = "";                                                   //  初始化InputString為空字串
			textreader = new System.IO.StreamReader(FileName, encoding);        //	以指定encoding讀取檔案FileName
			InputString = textreader.ReadToEnd();                               //  讀取檔案至結尾，將檔案內容填入InputString
			textreader.Close();                                                 //	關閉檔案
			return InputString;                                                 //  回傳讀取得字串資料
		}                                                                       //  結束ReadTxTFile方法
	}                                                                           //	結束FileIO類別
}                                                                               //	結束命名空間

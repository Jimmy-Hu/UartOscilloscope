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
		public void File_Write(string File_name, string Input_string)
		//  宣告File_Write副程式，將資料寫入檔案
		//  File_name為欲寫入檔案名稱
		//  Input_string為欲寫入檔案之字串資料
		{                                                                       //  進入File_Write副程式
			FileStream file_stream = new FileStream(File_name, FileMode.Append);
			//  建立檔案指標，指向指定檔案名稱，模式為傳入之File_mode
			byte[] Input_data = System.Text.Encoding.Default.GetBytes(Input_string);
			//  將填入資料轉為位元陣列
			file_stream.Write(Input_data, 0, Input_data.Length);                //  寫入資料至檔案中
			file_stream.Flush();                                                //  清除緩衝區
			file_stream.Close();                                                //  關閉檔案
		}                                                                       //  結束File_Write副程式
		public void File_Write(string File_name, string Input_string, FileMode File_mode)
		//  宣告File_Write副程式，將資料寫入檔案
		//  File_name為欲寫入檔案名稱
		//  Input_string為欲寫入檔案之字串資料
		//  File_mode為開啟檔案模式
		{                                                                       //  進入File_Write副程式
			FileStream file_stream = new FileStream(File_name, File_mode);      //  建立檔案指標，指向指定檔案名稱，模式為傳入之File_mode
			byte[] Input_data = System.Text.Encoding.Default.GetBytes(Input_string);
			//  將填入資料轉為位元陣列
			file_stream.Write(Input_data, 0, Input_data.Length);                //  寫入資料至檔案中
			file_stream.Flush();                                                //  清除緩衝區
			file_stream.Close();                                                //  關閉檔案
		}                                                                       //  結束File_Write副程式
	}                                                                           //	結束FileIO類別
}                                                                               //	結束命名空間

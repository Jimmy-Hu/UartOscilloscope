using System;																	//	使用System函式庫
using System.Collections.Generic;												//	使用System.Collections.Generic函式庫
using System.Linq;																//	使用System.Linq函式庫
using System.Threading.Tasks;													//	使用System.Threading.Tasks函式庫
using System.Windows.Forms;														//	使用System.Windows.Forms函式庫

namespace UartOscilloscope														//	命名空間為本程式
{
    static class Program														//	Program類別
	{																			//	進入Program類別
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()														//	Main(主程式)
		{																		//	進入Main(主程式)
			Application.EnableVisualStyles();									//	為應用程式啟用視覺化樣式
			Application.SetCompatibleTextRenderingDefault(false);				//	為部分控制項上定義的 UseCompatibleTextRendering 屬性設定應用程式範圍的預設值
			Application.Run(new Form1());										//	執行Form1方法
		}																		//	結束Main(主程式)
	}																			//	結束Program類別
}

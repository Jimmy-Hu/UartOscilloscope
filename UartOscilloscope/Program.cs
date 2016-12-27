using System;																	//	使用System函式庫
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;														//	使用System.Windows.Forms函式庫

namespace UartOscilloscope														//	命名空間為本程式
{
    static class Program                                                        //	Program類別
	{																			//	進入Program類別
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()														//	Main(主程式)
		{																		//	進入Main(主程式)
			Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
		}                                                                       //	結束Main(主程式)
	}                                                                           //	結束Program類別
}

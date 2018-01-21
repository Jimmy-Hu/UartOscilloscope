using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayDataGraphic
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//	Add channels
			List<string> TestList = new List<string>();
			TestList.Add("Channel1");
			TestList.Add("Channel2");
			TestList.Add("Channel3");

			//	Create ArrayDataGraphic object
			CSharpFiles.ArrayDataGraphic ArrayDataGraphic1 = new CSharpFiles.ArrayDataGraphic(TestList);

			//	Add datas
			for (int Loopnum = 0; Loopnum < 500; Loopnum++)
			{
				ArrayDataGraphic1.AddData("Channel1", Loopnum * 2);
			}

			//	Set graph width and height
			ArrayDataGraphic1.SetWidth(panel1.Size.Width);
			ArrayDataGraphic1.SetHeight(panel1.Size.Height);

			panel1.Paint += new PaintEventHandler(ArrayDataGraphic1.DrawGraph);
			panel1.Refresh();
		}
	}
}

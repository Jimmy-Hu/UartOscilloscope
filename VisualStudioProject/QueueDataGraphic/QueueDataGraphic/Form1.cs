using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueueDataGraphic
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

			//	Create QueueDataGraphic object
			CSharpFiles.QueueDataGraphic QueueDataGraphic1 = new CSharpFiles.QueueDataGraphic(TestList);

			//	Add datas
			for (int Loopnum = 0; Loopnum < 500; Loopnum++)
			{
				QueueDataGraphic1.AddData("Channel1", Loopnum*2);
			}

			//	Set graph width and height
			QueueDataGraphic1.SetWidth(panel1.Size.Width);
			QueueDataGraphic1.SetHeight(panel1.Size.Height);

			panel1.Paint += new PaintEventHandler(QueueDataGraphic1.DrawGraph);
			panel1.Refresh();
		}
	}
}

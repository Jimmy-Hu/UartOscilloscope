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

			List<string> TestList = new List<string>();
			TestList.Add("Channel1");
			TestList.Add("Channel2");
			TestList.Add("Channel3");

			CSharpFiles.QueueDataGraphic QueueDataGraphic1 = new CSharpFiles.QueueDataGraphic(TestList);

			for(int Loopnum = 0; Loopnum < 500; Loopnum++)
			{
				QueueDataGraphic1.AddData("Channel1", Loopnum*2);
			}

			QueueDataGraphic1.SetWidth(panel1.Size.Width);
			QueueDataGraphic1.SetHeight(panel1.Size.Height);

			panel1.Paint += new PaintEventHandler(QueueDataGraphic1.DrawGraph);
			panel1.Refresh();

		}
	}
}

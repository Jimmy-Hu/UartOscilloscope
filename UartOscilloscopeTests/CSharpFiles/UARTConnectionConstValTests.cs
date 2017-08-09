using Microsoft.VisualStudio.TestTools.UnitTesting;
using UartOscilloscope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UartOscilloscope.Tests
{                                                                               //	進入命名空間
	[TestClass()]
	public class UARTConnectionConstValTests
	{
		[TestMethod()]
		public void GetDefaultBaudRateTest()
		{
			int expected = 9600;
			int actual;
			actual = UARTConnectionConstVal.GetDefaultBaudRate();
			Assert.AreEqual(expected, actual);
		}
	}
}                                                                               //	結束命名空間
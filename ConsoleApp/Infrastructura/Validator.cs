using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructura
{
	public class Validator
	{
		public bool IsPositiveInt(string str)
		{
			int temp;
			if (int.TryParse(str, out temp) && temp >= 0)
				return true;

			return false;

		}
	}
}

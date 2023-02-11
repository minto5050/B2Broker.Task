using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Broker.Task.Logic
{
	sealed class FactorialCheck
	{
		public int CheckFactorialsInFile(string filePath,int number)
		{
			List<int> factorialOf = new List<int>();
			var numbersFromFile = ReadNumbersFromFile(filePath);
			int result = CalculateReverseFactorial(number);
			if (result != 0)
			{
				if (numbersFromFile.Contains(result))
				{
					return result;
				}
			}
			return 0;
		}
		int[] ReadNumbersFromFile(string filePath)
		{
			string[] lines = File.ReadAllLines(filePath);
			List<int> numbers = new List<int>();
			foreach (string line in lines)
			{
				string[] parts = line.Split(' ');
				foreach (string part in parts)
				{
					int n;
					if (int.TryParse(part, out n))
					{
						numbers.Add(n);
					}
				}
			}
			return numbers.ToArray();
		}

		int CalculateReverseFactorial(int number)
		{
			int i = 1;
			int factorial = 1;
			while (factorial < number)
			{
				i++;
				factorial *= i;
			}
			return factorial == number ? i : 0;
		}
	}
}

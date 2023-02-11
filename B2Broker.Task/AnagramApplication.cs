using B2Broker.Task.Common;
using B2Broker.Task.Logic;
using Fclp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace B2Broker.Task
{
	sealed class AnagramApplication
	{
		public AnagramApplication() { }
		public	void Run(FluentCommandLineParser<ApplicationArguments> args)
		{
			if (string.IsNullOrEmpty(args.Object.InputWordList)&&string.IsNullOrEmpty(args.Object.Word)&&args.Object.Number==0)
			{
				Console.WriteLine("B2Broker Coding test");
				Console.WriteLine("=====================");
				Console.WriteLine("B2Broker.Task.exe --word <word> for generating the anagrams for a word");
				Console.WriteLine("B2Broker.Task.exe --input <filepath> --output <filepath> for analysing anagram file");
				Console.WriteLine("B2Broker.Task.exe --input <filepath> --number <number> to check if the number is a factorial of any numbers in the input file");
			}
			else
			{
				var anagramChecks = new AnagramChecks();
				if (args.Object.InputWordList != string.Empty&&string.IsNullOrEmpty(args.Object.Word)&&args.Object.Number==0) {
					anagramChecks.StartAnalysis(args.Object.InputWordList, args.Object.OutputWordList);
					return;
				}
				if (!string.IsNullOrEmpty(args.Object.Word) && !string.IsNullOrEmpty(args.Object.OutputWordList))
				{
					anagramChecks.GenerateAnagramsFromWord(args.Object.Word,args.Object.OutputWordList);
					return;
				}
				if (args.Object.Number > 0 && !string.IsNullOrEmpty(args.Object.InputWordList))
				{
					var existing = new FactorialCheck().CheckFactorialsInFile(args.Object.InputWordList, args.Object.Number);
					if (existing > 0)
					{
						Console.WriteLine($"{args.Object.Number} is the factorial of the number {existing} in the file");
					}
				}
			}
		}
	}
}

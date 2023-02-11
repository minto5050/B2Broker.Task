using B2Broker.Task;
using B2Broker.Task.Common;
using Fclp;
using static System.Net.Mime.MediaTypeNames;

class Program
{
	
	public static void Main(string[] args)
	{
		var p = new FluentCommandLineParser<ApplicationArguments>();
		p.Setup(arg => arg.InputWordList).As('i', "input").SetDefault(@".\input.txt").WithDescription("The input file to process");
		p.Setup(arg => arg.OutputWordList).As('o', "output").SetDefault(@".\output.txt").WithDescription("The output file to write");
		p.Setup(arg => arg.Number).As('n', "number").SetDefault(0).WithDescription("The number to check the reverse factorial exists in the file");
		p.Setup(arg => arg.Word).As('w', "word").SetDefault("").WithDescription("Word for generating all the possible anagrams");
		p.Setup(arg => arg.ChunkSizeMB).As('s', "size").SetDefault(500).WithDescription("The chunk size in bytes to process the ");
		var result = p.Parse(args);
		if (result.HasErrors == false)
		{
			// use the instantiated ApplicationArguments object from the Object property on the parser.
			new AnagramApplication().Run(p);
		}
		else
		{
			Console.WriteLine(result.ErrorText);
		}
		
		
	}
}
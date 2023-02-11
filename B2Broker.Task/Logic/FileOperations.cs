using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Broker.Task.Logic
{
	public static class FileOperations
	{
		// 500 MB in bytes
		const int chunkSize = 536870912;

		public static void ProcessFile(string inputFilePath,string outputFilePath,Func<List<string>,string,int> callback)
		{
			if (!File.Exists(inputFilePath))
			{
				Console.WriteLine("The file does not exist.");
				return;
			}
			// Open the file for reading
			using (FileStream stream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
			{
				// Calculate the number of chunks
				int numberOfChunks = (int)Math.Ceiling((double)stream.Length / chunkSize);
					// Read the file in chunks
					for (int i = 0; i < numberOfChunks; i++)
					{
						// Calculate the size of the current chunk
						int currentChunkSize = (int)Math.Min(chunkSize, stream.Length - (long)i * chunkSize);
						byte[] buffer = new byte[currentChunkSize];
						stream.Read(buffer, 0, currentChunkSize);
						var text = System.Text.Encoding.Default.GetString(buffer);
						var words = text.Split(' ').ToList();
						callback(words,outputFilePath);
					}
				
			}
		}
	}
}

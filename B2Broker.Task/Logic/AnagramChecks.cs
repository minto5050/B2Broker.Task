using B2Broker.Task.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Broker.Task.Logic
{
	public class AnagramChecks
	{
		public void StartAnalysis(string inputFilePath,string outputFilePath,int chunkSize)
		{
			int chunkSizeBytes = chunkSize * 1048576;
			FileOperations.ProcessFile(inputFilePath, outputFilePath,FindAndWriteAnagrams,chunkSizeBytes);
		}
		/// <summary>
		/// The method writes all words in the input file which are anagrams of other words in the input file to a different output file.
		/// </summary>
		/// <param name="inputWordList">input file</param>
		/// <param name="outputFile">the output of the method</param>
		internal int FindAndWriteAnagrams(List<string> words, string outputFile)
		{
			// Find all anagrams in the word list
			Dictionary<string, List<string>> anagrams = FindAnagrams(words);

			// Write anagrams to output file
			using (StreamWriter writer = new StreamWriter(outputFile,true))
			{
				foreach (var item in anagrams)
				{
					var anagramGroup = item.Value;
					if (anagramGroup.Count > 1)
					{
						foreach (string anagram in anagramGroup)
						{
							writer.WriteLine(anagram);
						}
						writer.WriteLine();
					}
				}
			}
			return 0;
		}
		/// <summary>
		/// Finding anagrams, Each word in the word list will be alphabetically sorted and checked whether it exists ub a grouped list.
		/// </summary>
		/// <param name="words"></param>
		/// <returns></returns>
		internal Dictionary<string, List<string>> FindAnagrams(List<string> words)
		{
			Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
			foreach (string word in words)
			{
				char[] wordArray = word.ToCharArray();
				//Arrange the characters in alphabetical order which helps us to 
				Array.Sort(wordArray);
				string sortedWord = new string(wordArray);
				if (anagrams.ContainsKey(sortedWord))
				{
					anagrams[sortedWord].Add(word);
				}
				else
				{
					anagrams[sortedWord] = new List<string> { word };
				}
			}
			return anagrams;
		}

		private List<string> FindAllWords(string inputWordList)
		{
			string[] lines = File.ReadAllLines(inputWordList);
			var words = new List<string>();
			foreach (string line in lines)
			{
				string[] parts = line.Split(' ');
				foreach (string part in parts)
				{
					words.Add(part);
				}
			}
			return words;
		}

		internal void GenerateAnagramsFromWord(string word, string outputWordList)
		{
			using (StreamWriter writer = new StreamWriter(outputWordList))
			{
				var anagrams = GetAllPossibleWords(word);
				foreach (var anagram in anagrams)
				{
					writer.WriteLine(anagram);
				}
			}
		}
		private List<string> GetAllPossibleWords(string word)
		{
			List<string> anagrams = new List<string>();

			if (word.Length == 1)
			{
				anagrams.Add(word);
				return anagrams;
			}
			for (int i = 0; i < word.Length; i++)
			{
				string currentChar = word[i].ToString();
				string remainingChars = word.Substring(0, i) + word.Substring(i + 1);
				foreach (string anagram in GetAllPossibleWords(remainingChars))
				{
					anagrams.Add(currentChar + anagram);
				}
			}
			return anagrams;
		}
	}
}

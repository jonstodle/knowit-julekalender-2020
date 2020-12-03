using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Luke03
{
	class Program
	{
		static void Main(string[] args)
		{
			var matrix = File.ReadAllLines("matrix.txt").ToList();
			Console.WriteLine(string.Join(",", 
				File.ReadAllLines("wordlist.txt")
				// words
				.AsParallel()
				.Where(word =>
				{
					var reverse = string.Join("", word.Reverse());

					return
						!(SearchHorizontal(matrix, word) || SearchHorizontal(matrix, reverse) ||
						SearchVertical(matrix, word) || SearchVertical(matrix, reverse) ||
						SearchRightDiagonal(matrix, word) || SearchRightDiagonal(matrix, reverse) ||
						SearchLeftDiagonal(matrix, word) || SearchLeftDiagonal(matrix, reverse));
				})
				.OrderBy(word => word)));
		}

		private static bool SearchHorizontal(List<string> matrix, string word) => 
			matrix.Any(line => line.Contains(word));

		private static bool SearchVertical(List<string> matrix, string word)
		{
			for (int i = 0; i < matrix.Count - word.Length; i++)
			{
				for (int j = 0; j < matrix.Count; j++)
				{
					var hits = new bool[word.Length];
					for (int k = 0; k < word.Length; k++)
					{
						if (word[k] == matrix[i + k][j])
						{
							hits[k] = true;
						}
					}

					if (hits.All(h => h))
						return true;
				}
			}

			return false;
		}

		private static bool SearchRightDiagonal(List<string> matrix, string word)
		{
			for (int i = 0; i < matrix.Count - word.Length; i++)
			{
				for (int j = 0; j < matrix.Count - word.Length; j++)
				{
					var hits = new bool[word.Length];
					for (int k = 0; k < word.Length; k++)
					{
						if (word[k] == matrix[i + k][j + k])
						{
							hits[k] = true;
						}
					}

					if (hits.All(h => h))
						return true;
				}
			}

			return false;
		}

		private static bool SearchLeftDiagonal(List<string> matrix, string word)
		{
			for (int i = 0; i < matrix.Count - word.Length; i++)
			{
				for (int j = word.Length; j < matrix.Count; j++)
				{
					var hits = new bool[word.Length];
					for (int k = 0; k < word.Length; k++)
					{
						if (word[k] == matrix[i + k][j - k])
						{
							hits[k] = true;
						}
					}

					if (hits.All(h => h))
						return true;
				}
			}

			return false;
		}
	}
}

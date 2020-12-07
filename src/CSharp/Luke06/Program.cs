using System;
using System.IO;
using System.Linq;

namespace CSharp.Luke06
{
	public static class Program
	{
		public static void Run()
		{
			var bags = File.ReadAllText(Path.Combine("Luke06", "godteri.txt"))
				.Split(',', StringSplitOptions.TrimEntries)
				.Select(int.Parse)
				.ToList();

			var totalPieces = bags.Sum();

			for (var i = bags.Count - 1; i >= 0; i--)
			{
				totalPieces -= bags[i];
				if (totalPieces % 127 == 0)
				{
					Console.WriteLine(totalPieces / 127);
					break;
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke09
{
	public static class Program
	{
		public static void Run()
		{
			var elves = File.ReadAllLines(Path.Combine("Luke09", "elves.txt"))
					.Select(s => s.ToCharArray())
					.ToList();
			var newInfected = new List<(int, int)>();
			var day = 0;

			do
			{
				newInfected.Clear();
				day++;
				for (int row = 0; row < elves.Count; row++)
				{
					for (int col = 0; col < elves[0].Length; col++)
					{
						if (elves[row][col] == 'S')
							continue;

						var infected = new[]
						{
							row == 0 ? 'F' : elves[row - 1][col],
							row == elves.Count - 1 ? 'F' : elves[row + 1][col],
							col == 0 ? 'F' : elves[row][col - 1],
							col == elves[0].Length - 1 ? 'F' : elves[row][col + 1],
						}.Count(c => c == 'S');

						if (infected > 1)
							newInfected.Add((row, col));
					}
				}

				foreach (var (row, col) in newInfected)
				{
					elves[row][col] = 'S';
				}
			} while (newInfected.Count > 0);
			
			Console.WriteLine(day);
		}
	}
}

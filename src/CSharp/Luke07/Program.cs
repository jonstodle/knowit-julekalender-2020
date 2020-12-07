using System;
using System.IO;
using System.Linq;

namespace CSharp.Luke07
{
	public static class Program
	{
		public static void Run()
		{
			var trees = File.ReadAllLines(Path.Combine("Luke07", "forest.txt"));

			var count = 0;
			var treeStart = 0;
			for (var i = 0; i < trees[0].Length - 1; i++)
			{
				if (!Enumerable.Range(0, trees.Length)
					.All(j => trees[j][i] == ' ' && trees[j][i + 1] == ' '))
					continue;

				if (trees
					.Select(line => line.Substring(treeStart, i - treeStart))
					.All(line => line == new string(line.Reverse().ToArray())))
					count++;

				treeStart = i + 2;
			}
			
			Console.WriteLine(count);
		}
	}
}

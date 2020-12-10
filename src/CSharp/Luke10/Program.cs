using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke10
{
	public static class Program
	{
		public static void Run()
		{
			var results = File.ReadAllLines(Path.Combine("Luke10", "leker.txt"));

			var scores = new Dictionary<string, int>();

			foreach (var resultList in results)
			{
				var split = resultList.Split(',');
				for (var i = 0; i < split.Length; i++)
				{
					var score = split.Length - (i + 1);
					if (!scores.ContainsKey(split[i]))
						scores[split[i]] = score;
					else
						scores[split[i]] += score;
				}
			}
			
			Console.WriteLine(scores
				.OrderByDescending(kvp => kvp.Value)
				.Select(kvp => $"{kvp.Key}-{kvp.Value}")
				.First());
		}
	}
}

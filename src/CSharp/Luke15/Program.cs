using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke15
{
	public static class Program
	{
		public static void Run()
		{
			var wordPairs = File.ReadLines(Path.Combine("Luke15", "riddles.txt"))
				.Select(l =>
				{
					var split = l.Split(',', StringSplitOptions.TrimEntries);
					return (Pre: split[0], Post: split[1]);
				})
				.ToList();
			var wordlist = new HashSet<string>(File.ReadLines(Path.Combine("Luke15", "wordlist.txt"))
				.Select(l => l.Trim()));

			var glueWords = new Dictionary<string, List<string>>();
			foreach (var (pre, post) in wordPairs)
			{
				glueWords[pre] = new List<string>();
				glueWords[post] = new List<string>();
			}
			
			foreach (var word in wordlist)
			{
				foreach (var (pre, post) in wordPairs)
				{
					if (word.StartsWith(pre))
					{
						var glueWord = word.Substring(pre.Length);
						if (wordlist.Contains(glueWord))
						{
							glueWords[pre].Add(glueWord);
							break;
						}
					}

					if (word.EndsWith(post))
					{
						var glueWord = word.Substring(0, word.Length - post.Length);
						if (wordlist.Contains(glueWord))
						{
							glueWords[post].Add(glueWord);
							break;
						}
					}
				}
			}

			Console.WriteLine(
			wordPairs
				.SelectMany(wp => glueWords[wp.Pre].Intersect(glueWords[wp.Post]))
				.Distinct()
				.Sum(w => w.Length));
		}
	}
}

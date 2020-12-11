using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke11
{
	public static class Program
	{
		public static void Run()
		{
			var hints = File.ReadAllLines(Path.Combine("Luke11", "hint.txt"));

			foreach (var hint in hints.Select(h => h.Trim()).Where(h => h.Length >= 6))
			{
				var transformations = new List<string> {hint};
				while (transformations.Last().Length > 1)
				{
					transformations.Add(Transform(transformations.Last()));
				}

				if (!hint
					.Where((t1, i) => new string(
							transformations
								.Select(t => t.ElementAtOrDefault(i))
								.Where(c => c != null)
								.ToArray())
						.Contains("eamqia"))
					.Any())
					continue;

				Console.WriteLine(hint);
				return;
			}
		}

		private static string Transform(string input)
		{
			var result = input.Substring(1);
			result = new string(result.Select(c => (char) (c == 122 ? 97 : c + 1)).ToArray());
			return new string(result.Select((c, i) => (char) ((((c - 97) + input[i] - 97) % 26) + 97)).ToArray());
		}
	}
}

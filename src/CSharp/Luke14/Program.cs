using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke14
{
	public static class Program
	{
		public static void Run()
		{
			var sequence = new List<long> {0, 1};
			var unique = new HashSet<long> {0, 1};

			while (sequence.Count < 1800813)
			{
				var n = sequence.Count;
				var n2 = sequence[n - 2];
				var sub = n2 - n;
				if (sub < 0 || unique.Contains(sub))
				{
					sequence.Add(n + n2);
					unique.Add(n + n2);
				}
				else
				{
					sequence.Add(sub);
					unique.Add(sub);
				}
			}

			var primes = new HashSet<long>(File.ReadAllText(Path.Combine("Luke14", "primes.txt"))
				.Split(' ')
				.Select(s => s.Trim())
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.Select(long.Parse));

			Console.WriteLine(sequence.Count(primes.Contains));
		}
	}
}

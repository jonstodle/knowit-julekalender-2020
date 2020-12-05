using System;
using System.IO;
using System.Linq;

namespace Luke01
{
	public static class Program
	{
		public static void Run()
		{
			Console.WriteLine(
				File.ReadAllText("numbers.txt")
					.Split(',')
					.Select(s => s.Trim())
					.Select(s => int.Parse(s))
					.OrderBy(i => i)
					.Where(((i, idx) => idx + 1 != i))
					.Select(i => i - 1)
					.FirstOrDefault());

			Console.WriteLine(
				Enumerable.Range(1, 100_000)
					.Except(
						File.ReadAllText("numbers.txt")
							.Split(',')
							.Select(s => s.Trim())
							.Select(s => int.Parse(s)))
					.FirstOrDefault());
		}
	}
}

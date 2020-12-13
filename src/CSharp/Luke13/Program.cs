using System;
using System.IO;
using System.Linq;

namespace CSharp.Luke13
{
	public static class Program
	{
		public static void Run()
		{
			var count = new int[26];
			Console.WriteLine(new string(File.ReadAllText(Path.Combine("Luke13", "text.txt")).Trim()
				.Where(c =>
				{
					count[c - 97]++;
					return count[c - 97] == c - 96;
				})
				.ToArray()));
		}
	}
}

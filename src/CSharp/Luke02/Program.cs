﻿using System;
using System.IO;
using System.Linq;

namespace CSharp.Luke02
{
	public static class Program
	{
		public static void Run()
		{
			var primes = File.ReadAllText("primes.txt")
				.Split(' ')
				.Select(s => s.Trim())
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.Select(int.Parse)
				.Reverse()
				.ToList();

			var count = 0;
			var baseNo = 0;
			for (var i = 0; i < 5_433_000; i++)
			{
				if (i.ToString().Contains('7'))
				{
					var prime = primes.First(p => p <= i);
					i += prime;
				}
				else
				{
					count++;
				}
			}
			
			Console.WriteLine(count);
		}
	}
}

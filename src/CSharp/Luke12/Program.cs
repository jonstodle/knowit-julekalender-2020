using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke12
{
	public static class Program
	{
		public static void Run()
		{
			var familyTree = File.ReadAllText(Path.Combine("Luke12", "family.txt"));

			var currentLevel = 0;
			var count = new Dictionary<int, int>();
			var prevWasLetter = false;

			for (int i = 0; i < familyTree.Length; i++)
			{
				var c = familyTree[i];
				if (char.IsLetter(c))
				{
					continue;
				}
				
				if (c == ' ' && char.IsLetter(familyTree[i - 1]))
				{
					Add();
				}
				else if (c == ')')
				{
					if (char.IsLetter(familyTree[i - 1]))
						Add();
					currentLevel--;
				}
				else if (c == '(')
				{
					currentLevel++;
				}
			}
			
			Console.WriteLine(count.OrderByDescending(kvp => kvp.Value).First().Value);

			void Add() => count[currentLevel] = count.GetValueOrDefault(currentLevel) + 1;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp.Luke05
{
	public static class Program
	{
		public static void Run()
		{
			var (_, _, coordinates) = File.ReadAllText(Path.Combine("Luke05", "rute.txt")).Trim()
				.Aggregate((X: 1, Y: 1, Coordinates: new List<(int X, int Y)>()), (acc, curr) =>
				{
					acc.Coordinates.Add((acc.X, acc.Y));
					switch (curr)
					{
						case 'H':
							acc.X += 1;
							break;
						case 'V':
							acc.X -= 1;
							break;
						case 'O':
							acc.Y += 1;
							break;
						case 'N':
							acc.Y -= 1;
							break;
					}

					return acc;
				});

			long horizontal = 0, vertical = 0;
			for (var i = 0; i < coordinates.Count; i++)
			{
				var point = coordinates[i];
				var next = coordinates[(i + 1) % coordinates.Count];
				horizontal += point.X * next.Y;
				vertical += point.Y * next.X;
			}
			
			Console.WriteLine("H: {0}, V: {1}", horizontal, vertical);

			Console.WriteLine(Math.Abs(horizontal - vertical) / 2);
		}
	}
}

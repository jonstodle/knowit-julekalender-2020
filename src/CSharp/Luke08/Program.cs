using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp.Luke08
{
	public static class Program
	{
public static void Run()
{
	var lines = File.ReadAllLines(Path.Combine("Luke08", "input.txt"));

	var locations = lines
		.Take(50)
		.Select(line =>
		{
			var matches = Regex.Matches(line, @"([-\w ']+)");

			return new Location
			{
				Name = matches[0].Value.Trim(),
				X = int.Parse(matches[2].Value.Trim()),
				Y = int.Parse(matches[3].Value.Trim()),
			};
		})
		.ToDictionary(kvp => kvp.Name);

	int x = 0, y = 0;

	foreach (var locationName in lines.Skip(50))
	{
		var destination = locations[locationName];

		while (x != destination.X)
		{
			x += destination.X - x > 0 ? 1 : -1;
			foreach (var location in locations.Values)
				location.AddTime(x, y);
		}

		while (y != destination.Y)
		{
			y += destination.Y - y > 0 ? 1 : -1;
			foreach (var location in locations.Values)
				location.AddTime(x, y);
		}
	}

	Console.WriteLine(locations.Values.Select(l => l.TimePassed).Max() -
					  locations.Values.Select(l => l.TimePassed).Min());
}

public class Location
{
	public string Name { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
	public double TimePassed { get; set; }

	public void AddTime(int x, int y)
	{
		TimePassed += CalculateDistance(x, y) switch
		{
			0 => 0,
			< 5 => .25,
			< 20 => .5,
			< 50 => .75,
			_ => 1,
		};
	}

	private int CalculateDistance(int x, int y) =>
		Math.Abs(x - X) + Math.Abs(y - Y);
}
	}
}

using System;
using System.IO;
using System.Linq;

namespace Luke04
{
	class Program
	{
		static void Main(string[] args)
		{
			var totalIngredients = File.ReadAllLines("leveringsliste.txt")
				.Select(ParseLine)
				.Aggregate(new Delivery(), (acc, curr) =>
				{
					acc.Sugar += curr.Sugar;
					acc.Flour += curr.Flour;
					acc.Milk += curr.Milk;
					acc.Eggs += curr.Eggs;
					return acc;
				});

			var count = 0;
			while (true)
			{
				if (totalIngredients.Sugar >= 2 &&
				    totalIngredients.Flour >= 3 &&
				    totalIngredients.Milk >= 3 &&
				    totalIngredients.Eggs >= 1)
				{
					count++;
					
					totalIngredients.Sugar -= 2;
				    totalIngredients.Flour -= 3;
				    totalIngredients.Milk -= 3;
				    totalIngredients.Eggs -= 1;
				}
				else
				{
					break;
				}
			}
			
			Console.WriteLine(count);
		}

		private static Delivery ParseLine(string line) =>
			line.Split(',')
				.Aggregate(new Delivery(), (acc, curr) =>
				{
					var split = curr.Split(':').Select(s => s.Trim(' ', ',')).ToList();
					switch (split[0])
					{
						case "sukker":
							acc.Sugar = int.Parse(split[1]);
							break;
						case "mel":
							acc.Flour = int.Parse(split[1]);
							break;
						case "melk":
							acc.Milk = int.Parse(split[1]);
							break;
						case "egg":
							acc.Eggs = int.Parse(split[1]);
							break;
					}

					return acc;
				});
	}

	class Delivery
	{
		public int Sugar { get; set; }
		public int Flour { get; set; }
		public int Milk { get; set; }
		public int Eggs { get; set; }
	}
}

using System;
using System.Linq;

namespace CSharp
{
	class Program
	{
		static void Main(string[] args)
		{
            switch (args.FirstOrDefault())
            {
                case "1": Luke01.Program.Run(); break;
                case "2": Luke02.Program.Run(); break;
                case "3": Luke03.Program.Run(); break;
                case "4": Luke04.Program.Run(); break;
                case "5": Luke05.Program.Run(); break;
                case "6": Luke06.Program.Run(); break;
                case "7": Luke07.Program.Run(); break;
                default: throw new ArgumentException("Requires one (1) argument. Must be number between 1 and 24");
            }
		}
	}
}

using System;

namespace CSharp
{
	class Program
	{
		static void Main(string[] args)
		{
            if (args.Length != 1)
            {
                throw new ArgumentException("Wrong number of arguments. Needs to be one.");
            }
            
            switch (args[0])
            {
                case "1": Luke01.Program.Run(); break;
                case "2": Luke02.Program.Run(); break;
                case "3": Luke03.Program.Run(); break;
                case "4": Luke04.Program.Run(); break;
                case "5": Luke05.Program.Run(); break;
            }
		}
	}
}

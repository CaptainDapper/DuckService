using DuckLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckConsole {
	class DuckConsole {
		static void Main(string[] args) {
			ListenLoop();

			Console.WriteLine("The End! Press enter to exit...");
			Console.ReadLine();
		}

		private static void ListenLoop() {
			bool keepLooping = true;
			do {
				Console.WriteLine("Awaiting Input!");
				string input = Console.ReadLine();
				switch (input.Trim()) {
					case "Goose":
						if (DuckDuck.Goose()) {
							Console.WriteLine("Update Sent!");
						} else {
							Console.WriteLine("Something Went Wrong...");
						}
						break;
					default:
						Console.WriteLine("I do not recognize that input. Quack.");
						break;
				}
			} while (keepLooping);
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuckLib {
	public static class ErrorLog {
		public static void WriteLines(string message) {
			WriteLines(new string[] { message });
		}

		public static void WriteLines(string[] messages) {
			try {
				string thePath = "ErrorLog.txt";
				using (StreamWriter w = File.AppendText(thePath)) {
					w.WriteLine("-----------------------");
					w.WriteLine("--- " + DateTime.Now);
					w.WriteLine("-----------------------");
					foreach (string item in messages) {
						w.WriteLine(item);
					}
					w.WriteLine("-----------------------");
					w.WriteLine("");
				}
			} catch {

			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DuckService {
	static class DuckServiceEntry {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() {
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
            { 
                new DuckService() 
            };
			ServiceBase.Run(ServicesToRun);
		}
	}
}

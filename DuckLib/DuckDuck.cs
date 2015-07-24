using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DuckLib {
	public static class DuckDuck {
		private const string REGISTRY_SUB_KEY_NAME = "SOFTWARE\\DuckService";

		private static string SDomain = "";
		private static string SToken = "";
		private static int SInterval = 5;

		private static bool SRegistryLoaded = false;

		public static string Domain {
			get {
				RegistryLoad();
				return SDomain;
			}
			set {
				SDomain = value;
			}
		}

		public static string Token {
			get {
				RegistryLoad();
				return SToken;
			}
			set {
				SToken = value;
			}
		}

		public static int Interval {
			get {
				RegistryLoad();
				return SInterval;
			}
			set {
				SInterval = value;
			}
		}

		public static int IntervalMS {
			get {
				return Interval * 60 * 1000;
			}
		}

		public static bool Goose() {
			bool ok = false;
			ok = RegistryLoad();
			if (ok) {
				ok = Goose(SDomain, SToken);
			}
			return ok;
		}

		public static bool Goose(string prmDomain, string prmToken) {
			bool ok = false;
			try {
				string URL = String.Format("https://www.duckdns.org/update?domains={0}&token={1}", prmDomain, prmToken);
				HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
					using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
						string responseStr = stream.ReadToEnd();
						if (responseStr.Trim() == "OK") {
							ok = true;
						} else {
							string[] messageLines = new string[3];
							messageLines[0] = "Some crap happened while trying to update DuckDNS";
							messageLines[1] = String.Format("URL tried: {0}", URL);
							messageLines[2] = String.Format("Response from duckdns.org: {0}", responseStr);

							ErrorLog.WriteLines(messageLines);
						}
					}
				}
			} catch (Exception ex) {
				ErrorLog.WriteLines(ex.ToString());
			}

			return ok;
		}

		public static bool Install(string prmLocation) {
			bool ok = true;
			try {
				//We don't need to load this first, do we?
				//ok = RegistryLoad();

				//if (ok) {
					Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_SUB_KEY_NAME, true);
					if (key == null) {
						key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(REGISTRY_SUB_KEY_NAME);
						key.OpenSubKey(REGISTRY_SUB_KEY_NAME, true);
					}
					key.SetValue("domain", SDomain);
					key.SetValue("token", SToken);
					key.SetValue("interval", SInterval);
					key.SetValue("installed", "true");

					ManagedInstallerClass.InstallHelper(new string[] { prmLocation });

					SRegistryLoaded = false;
				//}
			} catch (Exception ex) {
				ErrorLog.WriteLines(ex.ToString());
				ok = false;
			}

			return ok;
		}

		public static bool Uninstall(string prmLocation) {
			bool ok = true;
			try {
				Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_SUB_KEY_NAME, true);
				key.SetValue("installed", "false");

				ManagedInstallerClass.InstallHelper(new string[] { "/u", prmLocation });

				SRegistryLoaded = false;
			} catch (Exception ex) {
				ErrorLog.WriteLines(ex.ToString());
				ok = false;
			}

			return ok;
		}

		private static bool RegistryLoad() {
			bool ok = true;

			if (!SRegistryLoaded) {
				try {
					Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_SUB_KEY_NAME);
					SDomain = (string)key.GetValue("domain");
					SToken = (string)key.GetValue("token");
					SInterval = (int)key.GetValue("interval");
				} catch (NullReferenceException ex) {
					ok = false;
				} catch (Exception ex) {
					ErrorLog.WriteLines(ex.ToString());
					ok = false;
				}

				SRegistryLoaded = true;
			}

			return ok;
		}

		public static bool IsInstalled {
			get {
				bool installed = false;
				try {
					Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(REGISTRY_SUB_KEY_NAME);
					if ((string)key.GetValue("installed") == "true") {
						installed = true;
					} else {
						installed = false;
					}
				} catch (Exception ex) {
					ErrorLog.WriteLines(ex.ToString());
				}
				return installed;
			}
		}
	}
}

using DuckLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuckSetup {
	public partial class DuckSetup : Form {
		public DuckSetup() {
			InitializeComponent();
		}

		private void btnInstall_Click(object sender, EventArgs e) {
			string domain = txtDomain.Text.ToLower();
			string token = txtToken.Text;
			int interval = 5;
			bool intervalOK = int.TryParse(numInterval.Text, out interval);
			if (String.IsNullOrWhiteSpace(domain)) {
				MessageBox.Show("You must enter something for the Domain.");
			} else if (String.IsNullOrWhiteSpace(token)) {
				MessageBox.Show("You must enter something for the Token.");
			} else if (!intervalOK) {
				MessageBox.Show("You must enter something for the Interval.");
			} else if (domain.Contains(".duckdns.org")) {
				domain = domain.Replace(".duckdns.org", "");
			}

			bool ok = DuckDuck.Goose(domain, token);

			if (ok) {
				DuckDuck.Domain = domain;
				DuckDuck.Token = token;
				DuckDuck.Interval = interval;
				ok = DuckDuck.Install(System.Reflection.Assembly.GetAssembly(typeof(DuckService.DuckService)).Location);
			}

			LoadStuff();
			if (!ok) {
				ShowErrorMessage();
			}
		}

		private void btnUninstall_Click(object sender, EventArgs e) {
			bool ok = DuckDuck.Uninstall(System.Reflection.Assembly.GetAssembly(typeof(DuckService.DuckService)).Location);

			LoadStuff();
			if (!ok) {
				ShowErrorMessage();
			}
		}

		private void ShowErrorMessage() {
			MessageBox.Show("Something went wrong. Are your domain and token correct? (You may need to check the ErrorLog.txt, although it probably won't be useful.)");
		}

		private string lblInstalledOrigText;
		private void DuckSetup_Load(object sender, EventArgs e) {
			lblInstalledOrigText = lblInstalled.Text;
			LoadStuff();
		}

		private void LoadStuff() {
			bool isInstalled = DuckDuck.IsInstalled;
			lblInstalled.Text = String.Format(lblInstalledOrigText, (isInstalled ? "Installed" : "Uninstalled"));

			btnInstall.Enabled = !isInstalled;
			btnUninstall.Enabled = isInstalled;

			txtDomain.Text = DuckDuck.Domain;
			txtToken.Text = DuckDuck.Token;
			numInterval.Text = DuckDuck.Interval.ToString();
		}
	}
}

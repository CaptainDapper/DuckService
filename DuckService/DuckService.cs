using DuckLib;
using System;
using System.ServiceProcess;
using System.Threading;

namespace DuckService {
	public partial class DuckService : ServiceBase {
		private Timer timer;
		public DuckService() {
			InitializeComponent();
			InitTimer();
		}

		protected override void OnStart(string[] args) {
			StartTimer();
		}

		protected override void OnStop() {
			StopTimer();
		}

		private void TimerElapsed(object stateInfo) {
			DoStuff();
			timer.Change(DuckDuck.IntervalMS, Timeout.Infinite);
		}

		private void DoStuff() {
			try {
				DuckDuck.Goose();
			} catch {
				this.Stop();
			}
		}

		private void InitTimer() {
			TimerCallback tcb = TimerElapsed;
			timer = new Timer(tcb, null, Timeout.Infinite, Timeout.Infinite);
		}

		private void StartTimer() {
			timer.Change(0, Timeout.Infinite);
		}

		private void StopTimer() {
			timer.Change(Timeout.Infinite, Timeout.Infinite);
		}
	}
}

namespace DuckSetup {
	partial class DuckSetup {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtDomain = new System.Windows.Forms.TextBox();
			this.lblDomain = new System.Windows.Forms.Label();
			this.txtToken = new System.Windows.Forms.TextBox();
			this.lblToken = new System.Windows.Forms.Label();
			this.btnInstall = new System.Windows.Forms.Button();
			this.btnUninstall = new System.Windows.Forms.Button();
			this.lblInstalled = new System.Windows.Forms.Label();
			this.numInterval = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDomain
			// 
			this.txtDomain.Location = new System.Drawing.Point(105, 6);
			this.txtDomain.Name = "txtDomain";
			this.txtDomain.Size = new System.Drawing.Size(215, 20);
			this.txtDomain.TabIndex = 0;
			// 
			// lblDomain
			// 
			this.lblDomain.AutoSize = true;
			this.lblDomain.Location = new System.Drawing.Point(12, 9);
			this.lblDomain.Name = "lblDomain";
			this.lblDomain.Size = new System.Drawing.Size(43, 13);
			this.lblDomain.TabIndex = 1;
			this.lblDomain.Text = "Domain";
			// 
			// txtToken
			// 
			this.txtToken.Location = new System.Drawing.Point(105, 32);
			this.txtToken.Name = "txtToken";
			this.txtToken.Size = new System.Drawing.Size(215, 20);
			this.txtToken.TabIndex = 0;
			// 
			// lblToken
			// 
			this.lblToken.AutoSize = true;
			this.lblToken.Location = new System.Drawing.Point(12, 35);
			this.lblToken.Name = "lblToken";
			this.lblToken.Size = new System.Drawing.Size(38, 13);
			this.lblToken.TabIndex = 1;
			this.lblToken.Text = "Token";
			// 
			// btnInstall
			// 
			this.btnInstall.Location = new System.Drawing.Point(15, 126);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new System.Drawing.Size(100, 23);
			this.btnInstall.TabIndex = 2;
			this.btnInstall.Text = "Install Service";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
			// 
			// btnUninstall
			// 
			this.btnUninstall.Location = new System.Drawing.Point(223, 126);
			this.btnUninstall.Name = "btnUninstall";
			this.btnUninstall.Size = new System.Drawing.Size(100, 23);
			this.btnUninstall.TabIndex = 2;
			this.btnUninstall.Text = "Uninstall Service";
			this.btnUninstall.UseVisualStyleBackColor = true;
			this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
			// 
			// lblInstalled
			// 
			this.lblInstalled.AutoSize = true;
			this.lblInstalled.Location = new System.Drawing.Point(12, 110);
			this.lblInstalled.Name = "lblInstalled";
			this.lblInstalled.Size = new System.Drawing.Size(100, 13);
			this.lblInstalled.TabIndex = 3;
			this.lblInstalled.Text = "DuckService Is: {0}";
			// 
			// numInterval
			// 
			this.numInterval.Location = new System.Drawing.Point(105, 59);
			this.numInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numInterval.Name = "numInterval";
			this.numInterval.Size = new System.Drawing.Size(76, 20);
			this.numInterval.TabIndex = 4;
			this.numInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Interval (minutes)";
			// 
			// DuckSetup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 160);
			this.Controls.Add(this.numInterval);
			this.Controls.Add(this.lblInstalled);
			this.Controls.Add(this.btnUninstall);
			this.Controls.Add(this.btnInstall);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblToken);
			this.Controls.Add(this.txtToken);
			this.Controls.Add(this.lblDomain);
			this.Controls.Add(this.txtDomain);
			this.Name = "DuckSetup";
			this.Text = "Duck Service Setup";
			this.Load += new System.EventHandler(this.DuckSetup_Load);
			((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtDomain;
		private System.Windows.Forms.Label lblDomain;
		private System.Windows.Forms.TextBox txtToken;
		private System.Windows.Forms.Label lblToken;
		private System.Windows.Forms.Button btnInstall;
		private System.Windows.Forms.Button btnUninstall;
		private System.Windows.Forms.Label lblInstalled;
		private System.Windows.Forms.NumericUpDown numInterval;
		private System.Windows.Forms.Label label1;
	}
}


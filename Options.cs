using System;
using System.Drawing;
using Microsoft.Win32;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace VDBatch
{
	/// <summary>
	/// Summary description for Options.
	/// </summary>
	public class Options : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbJobsPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Button btnOutputBrowse;
        private TextBox tbAviOut;
        private Label label2;
        private Button btnSubBrowse;
        private TextBox tbSubFile;
        private Label label3;
        private TextBox tbSubsStop;
        private Label label4;
        private FolderBrowserDialog fbdAviOutDir;
        private OpenFileDialog ofdSubFile;
        private CheckBox chkAltAud;
        private CheckBox chkSubs;
        private TextBox tbExtAud;
        private Button btnExtAud;
        private OpenFileDialog ofdExtAud;
        private Label label5;
        private CheckBox chkFindSubs;
        private CheckBox chkFindAud;
        private Button btnWriteReg;
        private VDBAForm MainForm;
        private CheckBox chkFullPath;
        private CheckBox chkNoDupes;


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;


        public VDBAForm MainGetSet
        {
            get { return MainForm; }
            set { MainForm = value; }
        }

        public string JobsPath
        {
            get { return tbJobsPath.Text; }
            set { tbJobsPath.Text = value; }
        }

        public string AviOutPath
        {
            get { return tbAviOut.Text; }
            set { tbAviOut.Text = value; }
        }

        public string SubEnd
        {
            get { return tbSubsStop.Text; }
            set { tbSubsStop.Text = value; }
        }

        public string SubFilePath
        {
            get { return tbSubFile.Text; }
            set { tbSubFile.Text = value; }
        }

        public string AudFilePath
        {
            get { return tbExtAud.Text; }
            set { tbExtAud.Text = value; }
        }

        public bool AudChk
        {
            get { return chkAltAud.Checked; }
            set { chkAltAud.Checked = value; }
        }

        public bool SubChk
        {
            get { return chkSubs.Checked; }
            set { chkSubs.Checked = value; }
        }

        public bool AudFindChk
        {
            get { return chkFindAud.Checked; }
            set { chkFindAud.Checked = value; }
        }

        public bool SubFindChk
        {
            get { return chkFindSubs.Checked; }
            set { chkFindSubs.Checked = value; }
        }

        public bool FullJobChk
        {
            get { return chkFullPath.Checked; }
            set { chkFullPath.Checked = value; }
        }

        public bool NoDupeChk
        {
            get { return chkNoDupes.Checked; }
            set { chkNoDupes.Checked = value; }
        }

        public Options()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.label1 = new System.Windows.Forms.Label();
            this.tbJobsPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.tbAviOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubBrowse = new System.Windows.Forms.Button();
            this.tbSubFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSubsStop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.fbdAviOutDir = new System.Windows.Forms.FolderBrowserDialog();
            this.ofdSubFile = new System.Windows.Forms.OpenFileDialog();
            this.chkAltAud = new System.Windows.Forms.CheckBox();
            this.chkSubs = new System.Windows.Forms.CheckBox();
            this.tbExtAud = new System.Windows.Forms.TextBox();
            this.btnExtAud = new System.Windows.Forms.Button();
            this.ofdExtAud = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.chkFindSubs = new System.Windows.Forms.CheckBox();
            this.chkFindAud = new System.Windows.Forms.CheckBox();
            this.btnWriteReg = new System.Windows.Forms.Button();
            this.chkFullPath = new System.Windows.Forms.CheckBox();
            this.chkNoDupes = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Default VirtualDub.jobs path:";
            // 
            // tbJobsPath
            // 
            this.tbJobsPath.Location = new System.Drawing.Point(160, 5);
            this.tbJobsPath.Name = "tbJobsPath";
            this.tbJobsPath.Size = new System.Drawing.Size(312, 20);
            this.tbJobsPath.TabIndex = 1;
            this.tbJobsPath.Text = "C:\\Program Files\\VirtualDub\\VirtualDub.jobs";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(480, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(398, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(478, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Close";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Title = "Open output JOBS file";
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(480, 33);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 5;
            this.btnOutputBrowse.Text = "B&rowse";
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // tbAviOut
            // 
            this.tbAviOut.Location = new System.Drawing.Point(160, 31);
            this.tbAviOut.Name = "tbAviOut";
            this.tbAviOut.Size = new System.Drawing.Size(312, 20);
            this.tbAviOut.TabIndex = 4;
            this.tbAviOut.Text = "C:\\Program Files\\VirtualDub\\";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "AVI Output Directory:";
            // 
            // btnSubBrowse
            // 
            this.btnSubBrowse.Location = new System.Drawing.Point(480, 59);
            this.btnSubBrowse.Name = "btnSubBrowse";
            this.btnSubBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSubBrowse.TabIndex = 8;
            this.btnSubBrowse.Text = "Bro&wse";
            this.btnSubBrowse.Click += new System.EventHandler(this.btnSubBrowse_Click);
            // 
            // tbSubFile
            // 
            this.tbSubFile.Location = new System.Drawing.Point(160, 57);
            this.tbSubFile.Name = "tbSubFile";
            this.tbSubFile.Size = new System.Drawing.Size(312, 20);
            this.tbSubFile.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Current Subtitle File:";
            // 
            // tbSubsStop
            // 
            this.tbSubsStop.Location = new System.Drawing.Point(129, 138);
            this.tbSubsStop.Name = "tbSubsStop";
            this.tbSubsStop.Size = new System.Drawing.Size(263, 20);
            this.tbSubsStop.TabIndex = 10;
            this.tbSubsStop.Text = "_Subtitles";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Subtitle File Suffix:";
            // 
            // fbdAviOutDir
            // 
            this.fbdAviOutDir.Description = "Open AVI output directory";
            // 
            // chkAltAud
            // 
            this.chkAltAud.AutoSize = true;
            this.chkAltAud.Checked = true;
            this.chkAltAud.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAltAud.Location = new System.Drawing.Point(122, 114);
            this.chkAltAud.Name = "chkAltAud";
            this.chkAltAud.Size = new System.Drawing.Size(132, 17);
            this.chkAltAud.TabIndex = 11;
            this.chkAltAud.Text = "Auto-fix External Audio";
            this.chkAltAud.UseVisualStyleBackColor = true;
            // 
            // chkSubs
            // 
            this.chkSubs.AutoSize = true;
            this.chkSubs.Checked = true;
            this.chkSubs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubs.Location = new System.Drawing.Point(12, 114);
            this.chkSubs.Name = "chkSubs";
            this.chkSubs.Size = new System.Drawing.Size(104, 17);
            this.chkSubs.TabIndex = 12;
            this.chkSubs.Text = "Auto-fix Subtitles";
            this.chkSubs.UseVisualStyleBackColor = true;
            // 
            // tbExtAud
            // 
            this.tbExtAud.Location = new System.Drawing.Point(160, 88);
            this.tbExtAud.Name = "tbExtAud";
            this.tbExtAud.Size = new System.Drawing.Size(312, 20);
            this.tbExtAud.TabIndex = 13;
            // 
            // btnExtAud
            // 
            this.btnExtAud.Location = new System.Drawing.Point(480, 86);
            this.btnExtAud.Name = "btnExtAud";
            this.btnExtAud.Size = new System.Drawing.Size(75, 23);
            this.btnExtAud.TabIndex = 14;
            this.btnExtAud.Text = "Brow&se";
            this.btnExtAud.UseVisualStyleBackColor = true;
            this.btnExtAud.Click += new System.EventHandler(this.btnExtAud_Click);
            // 
            // ofdExtAud
            // 
            this.ofdExtAud.Title = "Open External Audio";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Current External Audio File:";
            // 
            // chkFindSubs
            // 
            this.chkFindSubs.AutoSize = true;
            this.chkFindSubs.Checked = true;
            this.chkFindSubs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFindSubs.Location = new System.Drawing.Point(260, 114);
            this.chkFindSubs.Name = "chkFindSubs";
            this.chkFindSubs.Size = new System.Drawing.Size(111, 17);
            this.chkFindSubs.TabIndex = 17;
            this.chkFindSubs.Text = "Auto-find Subtitles";
            this.chkFindSubs.UseVisualStyleBackColor = true;
            // 
            // chkFindAud
            // 
            this.chkFindAud.AutoSize = true;
            this.chkFindAud.Checked = true;
            this.chkFindAud.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFindAud.Location = new System.Drawing.Point(377, 114);
            this.chkFindAud.Name = "chkFindAud";
            this.chkFindAud.Size = new System.Drawing.Size(139, 17);
            this.chkFindAud.TabIndex = 16;
            this.chkFindAud.Text = "Auto-find External Audio";
            this.chkFindAud.UseVisualStyleBackColor = true;
            // 
            // btnWriteReg
            // 
            this.btnWriteReg.Location = new System.Drawing.Point(322, 164);
            this.btnWriteReg.Name = "btnWriteReg";
            this.btnWriteReg.Size = new System.Drawing.Size(231, 23);
            this.btnWriteReg.TabIndex = 18;
            this.btnWriteReg.Text = "Write default .jobs path to registry";
            this.btnWriteReg.UseVisualStyleBackColor = true;
            this.btnWriteReg.Click += new System.EventHandler(this.btnWriteReg_Click);
            // 
            // chkFullPath
            // 
            this.chkFullPath.AutoSize = true;
            this.chkFullPath.Checked = true;
            this.chkFullPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFullPath.Location = new System.Drawing.Point(12, 166);
            this.chkFullPath.Name = "chkFullPath";
            this.chkFullPath.Size = new System.Drawing.Size(144, 17);
            this.chkFullPath.TabIndex = 19;
            this.chkFullPath.Text = "Put full template in job list";
            this.chkFullPath.UseVisualStyleBackColor = true;
            // 
            // chkNoDupes
            // 
            this.chkNoDupes.AutoSize = true;
            this.chkNoDupes.Checked = true;
            this.chkNoDupes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoDupes.Location = new System.Drawing.Point(167, 168);
            this.chkNoDupes.Name = "chkNoDupes";
            this.chkNoDupes.Size = new System.Drawing.Size(135, 17);
            this.chkNoDupes.TabIndex = 20;
            this.chkNoDupes.Text = "Prevent Duplicate Files";
            this.chkNoDupes.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(560, 191);
            this.Controls.Add(this.chkNoDupes);
            this.Controls.Add(this.chkFullPath);
            this.Controls.Add(this.btnWriteReg);
            this.Controls.Add(this.chkFindSubs);
            this.Controls.Add(this.chkFindAud);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExtAud);
            this.Controls.Add(this.tbExtAud);
            this.Controls.Add(this.chkSubs);
            this.Controls.Add(this.chkAltAud);
            this.Controls.Add(this.tbSubsStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubBrowse);
            this.Controls.Add(this.tbSubFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOutputBrowse);
            this.Controls.Add(this.tbAviOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.tbJobsPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void Options_Load(object sender, System.EventArgs e)
        {
            ReadFromRegistry();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            //WriteToRegistry();
            //VDBAForm MainForm = new VDBAForm();
            //MainForm.Text = "ass";
            //MainForm.Show();
            MainForm.ReloadVdscript();
            Close();
        }

        private void ReadFromRegistry()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\EDV Software\\VDBatch");
            tbJobsPath.Text = rk.GetValue("JobsPath", tbJobsPath.Text).ToString();
            rk.Close();
        }

        private void WriteToRegistry()
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\EDV Software\\VDBatch");
            rk.SetValue("JobsPath", tbJobsPath.Text);
            rk.Close();
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.FileName = tbJobsPath.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbJobsPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            fbdAviOutDir.SelectedPath = tbAviOut.Text;
            if (fbdAviOutDir.ShowDialog() == DialogResult.OK) 
            {
                tbAviOut.Text = fbdAviOutDir.SelectedPath;
            }
        }

        private void btnSubBrowse_Click(object sender, EventArgs e)
        {
            ofdSubFile.FileName = tbSubFile.Text;
            if (ofdSubFile.ShowDialog() == DialogResult.OK)
            {
                tbSubFile.Text = ofdSubFile.FileName;
            }
        }

        private void btnExtAud_Click(object sender, EventArgs e)
        {
            ofdExtAud.FileName = tbExtAud.Text;
            if (ofdExtAud.ShowDialog() == DialogResult.OK)
            {
                tbExtAud.Text = ofdExtAud.FileName;
            }
        }

        private void btnWriteReg_Click(object sender, EventArgs e)
        {
            WriteToRegistry();
        }

    }
}

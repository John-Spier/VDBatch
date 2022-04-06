using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace VDBatch
{
	/// <summary>
	/// Summary description for VDBAForm.
	/// </summary>
	public class VDBAForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem mi_File;
        private System.Windows.Forms.MenuItem mi_File_Exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader chFilename;
        private System.Windows.Forms.ContextMenu cmEdit;
        private System.Windows.Forms.MenuItem cm_Delete;
        private System.Windows.Forms.MenuItem mi_Edit;
        private System.Windows.Forms.MenuItem mi_Edit_CreateJobs;
        private System.Windows.Forms.SaveFileDialog sfdJobs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.MenuItem mi_File_Open;
        private System.Windows.Forms.MenuItem mi_File_Save;
        private System.Windows.Forms.SaveFileDialog sfdTemplate;
        private System.Windows.Forms.OpenFileDialog ofdTemplate;
        private System.Windows.Forms.TextBox tbTemplate;
        private System.Windows.Forms.Button btnCreateJobsFile;
        private System.Windows.Forms.TextBox tbInstructions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Splitter splitter3;
        private IContainer components;
        private System.Windows.Forms.MenuItem mi_Edit_ClearFileList;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mi_Edit_Options;

        private const string sJobSeparator = "// $job";
        private ColumnHeader chTemplate;
        private Button btnVDStoJob;
        private OpenFileDialog ofdVDScript;
        private ColumnHeader chOutputDir;
        private Button btnReload;
        private Options m_optionsForm = new Options();
        private ColumnHeader chScriptFile;
        private ColumnHeader chSubName;
        private ColumnHeader chAudName;
        private ColumnHeader chSubFix;
        private ColumnHeader chAudFix;
        private bool ScriptLoaded = false;
        //private VDBAForm MainForm;

		public VDBAForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            CreateInstructions();

            lvFiles.Columns[0].Width = -2;

            m_optionsForm.MainGetSet = this;

		}

        public VDBAForm MainGetSet
        {
            get { return this; }
        }

        public void CreateInstructions()
        {
            tbInstructions.Text = "Instructions:\r\n\r\n" + 
"Select AVI files by dropping them onto this window, or by clicking the \"Browse\" button.\r\n\r\n" +
"The job file template to the right will be used when the \"Create Job File\" button is pressed.  The following strings will be replaced upon processing:\r\n\r\n" +
"%p\tThe full source path\r\n" +
"\tExample:  E:\\videos\\source.avi\r\n" +
"\r\n" +
"%P\tThe full source path using \"\\\\\"\r\n" +
"\tExample:  E:\\\\videos\\\\Source.avi\r\n" +
"\r\n" +
"%d\tThe full source directory\r\n" +
"\tExample:  E:\\videos\r\n" +
"\r\n" +
"%D\tThe full source directory, using \"\\\\\"\r\n" +
"\tExample:  E:\\\\videos\r\n" +
"\r\n" +
"%b\tThe full source path, minus extension\r\n" +
"\tExample:  E:\\videos\\source\r\n" +
"\r\n" +
"%B\tThe full source path, no extension, using \"\\\\\"\r\n" +
"\tExample:  E:\\\\videos\\\\source\r\n" +
"\r\n" +
"%f\tThe source filename\r\n" +
"\tExample:  Source.avi\r\n" +
"\r\n" +
"%F\tThe source basename\r\n" +
"\tExample:  Source\r\n" +
"\r\n" +
"%e\tThe source extension\r\n" +
"\tExample:  .avi\r\n" +
"\r\n" +
"%n\tThe current job number\r\n" +
"\r\n" +
"";

            tbTemplate.Text = "// $job \"Job %n\"\r\n" +
"// $input \"%p\"\r\n" +
"// $output \"%b-New.%e\"\r\n" +
@"// $state 0
// $start_time 0 0
// $end_time 0 0
// $script

" + "VirtualDub.Open(\"%P\",0,0);\r\n" +
@"VirtualDub.audio.SetSource(1);
VirtualDub.audio.SetMode(0);
VirtualDub.audio.SetInterleave(1,500,1,0,0);
VirtualDub.audio.SetClipMode(1,1);
VirtualDub.audio.SetConversion(0,0,0,0,0);
VirtualDub.audio.SetVolume();
VirtualDub.audio.SetCompression();
VirtualDub.video.SetDepth(24,24);
VirtualDub.video.SetMode(1);
VirtualDub.video.SetFrameRate(0,1);
VirtualDub.video.SetIVTC(0,0,-1,0);
VirtualDub.video.SetRange(0,0);
VirtualDub.video.SetCompression();
VirtualDub.video.filters.Clear();
VirtualDub.subset.Delete();
" + "VirtualDub.SaveAVI(\"%B-New.%e\");\r\n" +
@"VirtualDub.Close();

// $endjob
//
//--------------------------------------------------";
        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VDBAForm));
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chFilename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOutputDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTemplate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmEdit = new System.Windows.Forms.ContextMenu();
            this.cm_Delete = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mi_File = new System.Windows.Forms.MenuItem();
            this.mi_File_Open = new System.Windows.Forms.MenuItem();
            this.mi_File_Save = new System.Windows.Forms.MenuItem();
            this.mi_File_Exit = new System.Windows.Forms.MenuItem();
            this.mi_Edit = new System.Windows.Forms.MenuItem();
            this.mi_Edit_CreateJobs = new System.Windows.Forms.MenuItem();
            this.mi_Edit_ClearFileList = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mi_Edit_Options = new System.Windows.Forms.MenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTemplate = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbInstructions = new System.Windows.Forms.TextBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnVDStoJob = new System.Windows.Forms.Button();
            this.btnCreateJobsFile = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.sfdJobs = new System.Windows.Forms.SaveFileDialog();
            this.sfdTemplate = new System.Windows.Forms.SaveFileDialog();
            this.ofdTemplate = new System.Windows.Forms.OpenFileDialog();
            this.ofdVDScript = new System.Windows.Forms.OpenFileDialog();
            this.chScriptFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubFix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudFix = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(0, 0);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(51, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lvFiles
            // 
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFilename,
            this.chOutputDir,
            this.chTemplate,
            this.chScriptFile,
            this.chSubName,
            this.chAudName,
            this.chSubFix,
            this.chAudFix});
            this.lvFiles.ContextMenu = this.cmEdit;
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.LabelEdit = true;
            this.lvFiles.Location = new System.Drawing.Point(0, 0);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(656, 131);
            this.lvFiles.TabIndex = 2;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.Resize += new System.EventHandler(this.lvFiles_Resize);
            // 
            // chFilename
            // 
            this.chFilename.Text = "Filename";
            // 
            // chOutputDir
            // 
            this.chOutputDir.Text = "Output Directory";
            this.chOutputDir.Width = 81;
            // 
            // chTemplate
            // 
            this.chTemplate.Text = "Job Template";
            this.chTemplate.Width = 81;
            // 
            // cmEdit
            // 
            this.cmEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cm_Delete});
            // 
            // cm_Delete
            // 
            this.cm_Delete.Index = 0;
            this.cm_Delete.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.cm_Delete.Text = "&Delete";
            this.cm_Delete.Click += new System.EventHandler(this.cm_Delete_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 534);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(656, 22);
            this.statusBar1.TabIndex = 4;
            this.statusBar1.Text = "Ready.";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mi_File,
            this.mi_Edit});
            // 
            // mi_File
            // 
            this.mi_File.Index = 0;
            this.mi_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mi_File_Open,
            this.mi_File_Save,
            this.mi_File_Exit});
            this.mi_File.Text = "&File";
            // 
            // mi_File_Open
            // 
            this.mi_File_Open.Index = 0;
            this.mi_File_Open.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.mi_File_Open.Text = "&Open job file template...";
            this.mi_File_Open.Click += new System.EventHandler(this.mi_File_Open_Click);
            // 
            // mi_File_Save
            // 
            this.mi_File_Save.Index = 1;
            this.mi_File_Save.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.mi_File_Save.Text = "&Save job file template...";
            this.mi_File_Save.Click += new System.EventHandler(this.mi_File_Save_Click);
            // 
            // mi_File_Exit
            // 
            this.mi_File_Exit.Index = 2;
            this.mi_File_Exit.Text = "E&xit";
            this.mi_File_Exit.Click += new System.EventHandler(this.mi_File_Exit_Click);
            // 
            // mi_Edit
            // 
            this.mi_Edit.Index = 1;
            this.mi_Edit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mi_Edit_CreateJobs,
            this.mi_Edit_ClearFileList,
            this.menuItem1,
            this.mi_Edit_Options});
            this.mi_Edit.Text = "&Edit";
            this.mi_Edit.Popup += new System.EventHandler(this.mi_Edit_Popup);
            // 
            // mi_Edit_CreateJobs
            // 
            this.mi_Edit_CreateJobs.Index = 0;
            this.mi_Edit_CreateJobs.Shortcut = System.Windows.Forms.Shortcut.CtrlJ;
            this.mi_Edit_CreateJobs.Text = "&Create .jobs file...";
            this.mi_Edit_CreateJobs.Click += new System.EventHandler(this.mi_Edit_CreateJobs_Click);
            // 
            // mi_Edit_ClearFileList
            // 
            this.mi_Edit_ClearFileList.Index = 1;
            this.mi_Edit_ClearFileList.Text = "C&lear file list";
            this.mi_Edit_ClearFileList.Click += new System.EventHandler(this.mi_Edit_ClearFileList_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // mi_Edit_Options
            // 
            this.mi_Edit_Options.Index = 3;
            this.mi_Edit_Options.Text = "&Options...";
            this.mi_Edit_Options.Click += new System.EventHandler(this.mi_Edit_Options_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbTemplate);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 400);
            this.panel2.TabIndex = 6;
            // 
            // tbTemplate
            // 
            this.tbTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTemplate.Location = new System.Drawing.Point(347, 0);
            this.tbTemplate.MaxLength = 65535;
            this.tbTemplate.Multiline = true;
            this.tbTemplate.Name = "tbTemplate";
            this.tbTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTemplate.Size = new System.Drawing.Size(309, 400);
            this.tbTemplate.TabIndex = 4;
            this.tbTemplate.WordWrap = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(344, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 400);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbInstructions);
            this.panel1.Controls.Add(this.splitter3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 400);
            this.panel1.TabIndex = 2;
            // 
            // tbInstructions
            // 
            this.tbInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInstructions.Location = new System.Drawing.Point(0, 0);
            this.tbInstructions.Multiline = true;
            this.tbInstructions.Name = "tbInstructions";
            this.tbInstructions.ReadOnly = true;
            this.tbInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInstructions.Size = new System.Drawing.Size(344, 373);
            this.tbInstructions.TabIndex = 6;
            this.tbInstructions.Text = "Instructions:";
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 373);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(344, 3);
            this.splitter3.TabIndex = 8;
            this.splitter3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReload);
            this.panel3.Controls.Add(this.btnVDStoJob);
            this.panel3.Controls.Add(this.btnBrowse);
            this.panel3.Controls.Add(this.btnCreateJobsFile);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 376);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 24);
            this.panel3.TabIndex = 7;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(264, 1);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(65, 23);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "&Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnVDStoJob
            // 
            this.btnVDStoJob.Location = new System.Drawing.Point(161, 1);
            this.btnVDStoJob.Name = "btnVDStoJob";
            this.btnVDStoJob.Size = new System.Drawing.Size(97, 23);
            this.btnVDStoJob.TabIndex = 6;
            this.btnVDStoJob.Text = "Open &VDScript";
            this.btnVDStoJob.Click += new System.EventHandler(this.btnVDStoJob_Click);
            // 
            // btnCreateJobsFile
            // 
            this.btnCreateJobsFile.Location = new System.Drawing.Point(57, 1);
            this.btnCreateJobsFile.Name = "btnCreateJobsFile";
            this.btnCreateJobsFile.Size = new System.Drawing.Size(98, 23);
            this.btnCreateJobsFile.TabIndex = 5;
            this.btnCreateJobsFile.Text = "&Create Jobs File";
            this.btnCreateJobsFile.Click += new System.EventHandler(this.btnCreateJobsFile_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 131);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(656, 3);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.Filter = "AVI files (*.avi)|*.avi|All files (*.*)|*.*";
            this.ofdBrowse.Multiselect = true;
            this.ofdBrowse.Title = "Select the video files to include in the batch operation";
            // 
            // sfdJobs
            // 
            this.sfdJobs.DefaultExt = "jobs";
            this.sfdJobs.FileName = "VirtualDub.jobs";
            this.sfdJobs.Filter = "VirtualDub Job file (*.jobs)|*.jobs|All files (*.*)|*.*";
            this.sfdJobs.Title = "Select the location for the .jobs file";
            // 
            // sfdTemplate
            // 
            this.sfdTemplate.DefaultExt = "job";
            this.sfdTemplate.FileName = "Template.job";
            this.sfdTemplate.Filter = "Job templates (*.job)|*.job|All files (*.*)|*.*";
            this.sfdTemplate.Title = "Select a filename for this job template";
            // 
            // ofdTemplate
            // 
            this.ofdTemplate.FileName = "Template.job";
            this.ofdTemplate.Filter = "Job templates (*.job)|*.job|All files (*.*)|*.*";
            this.ofdTemplate.Title = "Select a job template to open";
            // 
            // ofdVDScript
            // 
            this.ofdVDScript.Filter = "VirtualDub Scripts|*.vdscript|Old VirtualDub Scripts|*.vcf|All files|*.*";
            this.ofdVDScript.Title = "Select a VDScript to convert to a template";
            // 
            // chScriptFile
            // 
            this.chScriptFile.Text = "VDScript Job";
            // 
            // chSubName
            // 
            this.chSubName.Text = "Subtitle File";
            // 
            // chAudName
            // 
            this.chAudName.Text = "External Audio File";
            // 
            // chSubFix
            // 
            this.chSubFix.Text = "Fix Subtitles?";
            // 
            // chAudFix
            // 
            this.chAudFix.Text = "Fix Audio?";
            // 
            // VDBAForm
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 556);
            this.Controls.Add(this.lvFiles);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "VDBAForm";
            this.Text = "VirtualDub Batch Assistant v1.2.2";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.VDBAForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.VDBAForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VDBAForm_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new VDBAForm());
		}

        private void mi_File_Exit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void SetReadyStatus()
        {
            SetStatus("Ready.");
        }

        private void SetStatus(string sText)
        {
            statusBar1.Text = sText;
        }

        private void SetStatusWarning(string sText)
        {
            SetStatus("Warning: " + sText);
        }

        private void SetStatusError(string sText)
        {
            SetStatus("Error: " + sText);
        }

        private void AddFileToList(string sFile)
        {
            SetReadyStatus();

            if (!File.Exists(sFile))
            {
                SetStatusWarning("File does not exist - " + sFile);
                return;
            }

            foreach(ListViewItem lvItem in lvFiles.Items)
            {
                if (m_optionsForm.NoDupeChk && lvItem.SubItems[0].Text == sFile)
                    return;
            }
            ListViewItem sItem = new ListViewItem(sFile);
            sItem.SubItems.Add(m_optionsForm.AviOutPath);
            //sItem.SubItems.Add(m_optionsForm.SubFilePath);
            if (m_optionsForm.FullJobChk)
            {
                sItem.SubItems.Add(tbTemplate.Text);
            }
            else
            {
                sItem.SubItems.Add("");
            }
            
            //sItem.SubItems.Add(m_optionsForm.FullJobChk.ToString());
            sItem.SubItems.Add(ofdVDScript.FileName);
            sItem.SubItems.Add(m_optionsForm.SubFilePath);
            sItem.SubItems.Add(m_optionsForm.AudFilePath);
            sItem.SubItems.Add(m_optionsForm.SubChk.ToString());
            sItem.SubItems.Add(m_optionsForm.AudChk.ToString());
            lvFiles.Items.Add(sItem);
            //MessageBox.Show(sItem.SubItems[3].Text);
        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {
            if (ofdBrowse.ShowDialog() == DialogResult.OK)
            {
                foreach (string sFile in ofdBrowse.FileNames)
                {
                    AddFileToList(sFile);
                }
            }
        }

        private void lvFiles_Resize(object sender, System.EventArgs e)
        {
            lvFiles.Columns[0].Width = -2;
        }

        private void AddDirectory(string sDir)
        {
            foreach (string sFile in Directory.GetFiles(sDir, "*.avi"))
            {
                AddFileToList(sFile);
            }

            foreach (string sSubdir in Directory.GetDirectories(sDir))
            {
                AddDirectory(sSubdir);
            }
        }

        private void VDBAForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] saFiles = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (saFiles.Length == 1) 
            {
                string sTest = Path.GetExtension(saFiles[0]).ToLower();
                if (sTest == ".job")
                {
                    ReadJobTemplate(saFiles[0]);
                    return;
                }
            }

            lvFiles.SuspendLayout();
            foreach (string sFile in saFiles)
            {
                if (Directory.Exists(sFile))
                    AddDirectory(sFile);
                else
                    AddFileToList(sFile);
            }
            lvFiles.ResumeLayout();
        }

        private void VDBAForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void VDBAForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        
        }

        private void DeleteSelectedFiles()
        {
            lvFiles.SuspendLayout();
            foreach(ListViewItem lvItem in lvFiles.SelectedItems)
                lvItem.Remove();
            lvFiles.ResumeLayout();
        }

        private void cm_Delete_Click(object sender, System.EventArgs e)
        {
            DeleteSelectedFiles();
        }

        private void mi_Edit_CreateJobs_Click(object sender, System.EventArgs e)
        {
            CreateJobFile();
        }

        private void CreateJobFile()
        {
            sfdJobs.FileName = m_optionsForm.JobsPath;

            if (sfdJobs.ShowDialog() == DialogResult.OK)
            {
                CreateJobsFile(sfdJobs.FileName);
            }
        }

        private void mi_File_Open_Click(object sender, System.EventArgs e)
        {
            OpenTemplateFile();
        }

        private void OpenTemplateFile()
        {
            if (ofdTemplate.ShowDialog() == DialogResult.OK)
            {
                ReadJobTemplate(ofdTemplate.FileName);
            }
        }

        private void ReadJobTemplate(string sJobFile)
        {
            SetReadyStatus();
            StreamReader reader;
            try
            {
                reader = new StreamReader(sJobFile);
            }
            catch(Exception e)
            {
                DisplayReadError(e, sJobFile);
                return;
            }
            if (reader.BaseStream.Length > tbTemplate.MaxLength)
            {
                MessageBox.Show("The file \"" + sJobFile + "\" is too large to be used as a template.\r\n" +
                    "It is " + 
                    reader.BaseStream.Length + " bytes, and the maximum size is " + tbTemplate.MaxLength + " bytes.\r\n\r\n" + 
                    "Please verify that you selected the correct file.",
                    "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                SetStatusError("File too large - " + sJobFile);
            } 
            else
            {
                tbTemplate.Text = reader.ReadToEnd();
            }
            reader.Close();
        }

        private void mi_File_Save_Click(object sender, System.EventArgs e)
        {
            SaveTemplateFile();
        }

        private void SaveTemplateFile()
        {
            if (sfdTemplate.ShowDialog() == DialogResult.OK)
            {
                SetReadyStatus();
                StreamWriter writer;
                try
                {
                    writer = new StreamWriter(sfdTemplate.FileName, false);
                }
                catch(Exception e)
                {
                    DisplayWriteError(e, sfdTemplate.FileName);
                    return;
                }
                writer.Write(tbTemplate.Text);
                writer.Close();
            }
        }

        private void btnCreateJobsFile_Click(object sender, System.EventArgs e)
        {
            CreateJobFile();
        }

        private void DisplayWriteError(Exception e, string sFile)
        {
            MessageBox.Show("Could not open file for writing:\r\n\r\n" + sFile + 
                "\r\n\r\nReason: " + e.Message, "Error opening file",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
            SetStatusError("Could not create file - " + sFile);
        }

        private void DisplayReadError(Exception e, string sFile)
        {
            MessageBox.Show("Could not open file for reading:\r\n\r\n" + sFile + 
                "\r\n\r\nReason: " + e.Message, "Error opening file",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
            SetStatusError("Could not open file - " + sFile);
        }

        private void CreateJobsFile(string sFile)
        {
            SetReadyStatus();
            int iIndex = 1;
            string sJob;
            StreamWriter writer;

            // Open file for writing
            try
            {
                writer = new StreamWriter(sFile, false);
            }
            catch(Exception e)
            {
                DisplayWriteError(e, sFile);
                return;
            }

            int iNumJobs = lvFiles.Items.Count;
            int iMultiplier = 0;
            int iFind = 0;
            while (iFind != -1)
            {
                if (iFind + 1 >= tbTemplate.Text.Length)
                    break;
                iFind = tbTemplate.Text.IndexOf(sJobSeparator, iFind+1);
                iMultiplier++;
            }

            // Write global header (including number of jobs)
            writer.Write(@"// VirtualDub job list (Sylia script format)
// This is a program generated file -- edit at your own risk.
//
// $numjobs " + iNumJobs * iMultiplier + @"
//

");

            foreach(ListViewItem lvItem in lvFiles.Items)
            {

                FullReload(lvItem);
                sJob = CreateOneJob(lvItem.SubItems[0].Text, ref iIndex);
                writer.Write(sJob);

            }

            // Write footer
            writer.Write("// $done\r\n");

            // Close file
            writer.Close();
        }

        private string CreateOneJob(string sFile, ref int iIndex)
        {
            int iSubJob = -1;
            int iFind = 0;
            int iOldFind = 0;
            int iNextJob = 0;

            string sJob = "";
            string sBaseFull = Path.GetDirectoryName(sFile);
            if (!sBaseFull.EndsWith("\\"))
                sBaseFull += "\\";
            sBaseFull += Path.GetFileNameWithoutExtension(sFile);
            string sExtension = Path.GetExtension(sFile);
            if (sExtension.Length > 1)
                sExtension = sExtension.Substring(1);

            iNextJob = tbTemplate.Text.IndexOf(sJobSeparator);
            while (iFind > -1)
            {
                iOldFind = iFind;
                iFind = tbTemplate.Text.IndexOf("%", iFind);
                if ((iNextJob > -1) && (iFind > iNextJob))
                {
                    iNextJob = tbTemplate.Text.IndexOf(sJobSeparator, iNextJob+1);
                    iSubJob++;
                }
                if (iFind < 0)
                    break;

                if (iFind + 1 >= tbTemplate.Text.Length)
                {
                    iOldFind = iFind;
                    break;
                }

                sJob += tbTemplate.Text.Substring(iOldFind, iFind - iOldFind);
                switch(tbTemplate.Text[iFind+1])
                {
                    case 'p':
                        sJob += sFile;
                        break;
                    case 'P':
                        sJob += sFile.Replace("\\", "\\\\");
                        break;
                    case 'b':
                        sJob += sBaseFull;
                        break;
                    case 'B':
                        sJob += sBaseFull.Replace("\\", "\\\\");
                        break;
                    case 'd':
                        sJob += Path.GetDirectoryName(sFile);
                        break;
                    case 'D':
                        sJob += Path.GetDirectoryName(sFile).Replace("\\", "\\\\");
                        break;
                    case 'f':
                        sJob += Path.GetFileName(sFile);
                        break;
                    case 'F':
                        sJob += Path.GetFileNameWithoutExtension(sFile);
                        break;
                    case 'e':
                        sJob += sExtension;
                        break;
                    case 'n':
                        sJob += (iIndex + iSubJob).ToString();
                        break;
                    default:
                        sJob += tbTemplate.Text.Substring(iFind+1,1);
                        break;
                }
                iFind += 2;
                iOldFind = iFind;
            }

            if (iOldFind < tbTemplate.Text.Length)
            {
                sJob += tbTemplate.Text.Substring(iOldFind);
            }

            if (iSubJob > -1)
                iIndex += iSubJob;
            iIndex++;

            if (!sJob.EndsWith("\r\n"))
                sJob += "\r\n";

            return sJob;
        }

        private void mi_Edit_ClearFileList_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("This action will remove all files from the file list.  Continue?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                lvFiles.Items.Clear();
            }
        }

        private void mi_Edit_Popup(object sender, System.EventArgs e)
        {
            mi_Edit_ClearFileList.Enabled = (lvFiles.Items.Count > 0);
        }

        private void mi_Edit_Options_Click(object sender, System.EventArgs e)
        {
            m_optionsForm.StartPosition = FormStartPosition.CenterParent;
            m_optionsForm.ShowDialog();
        }

        private void btnVDStoJob_Click(object sender, EventArgs e)
        {
            if (ofdVDScript.ShowDialog() == DialogResult.OK)
            {
                OpenVDScript(ofdVDScript.FileName);
                
            }
        }

        

        private void OpenVDScript(string VDSName)
        {
            ScriptLoaded = false;
            SetReadyStatus();
            StreamReader reader;
            try
            {
                reader = new StreamReader(VDSName);
            }
            catch (Exception e)
            {
                DisplayReadError(e, VDSName);
                return;
            }
            if (reader.BaseStream.Length > tbTemplate.MaxLength)
            {
                MessageBox.Show("The file \"" + VDSName + "\" is too large to be used as a template.\r\n" +
                    "It is " +
                    reader.BaseStream.Length + " bytes, and the maximum size is " + tbTemplate.MaxLength + " bytes.\r\n\r\n" +
                    "Please verify that you selected the correct file.",
                    "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                SetStatusError("File too large - " + VDSName);
            }
            else
            {
                if (!m_optionsForm.AviOutPath.EndsWith("\\"))
                    m_optionsForm.AviOutPath += "\\";
                string JobTemp = reader.ReadToEnd();
                int subPos = -1;
                int audPos = -1;
                int subEnd = -1;
                int audEnd = -1;
                try
                {
                    audPos = JobTemp.IndexOf("VirtualDub.audio.SetSource(\"") + 28;
                    subEnd = JobTemp.IndexOf(m_optionsForm.SubEnd);
                    audEnd = JobTemp.IndexOf('"', audPos);
                    subPos = JobTemp.LastIndexOf('"', subEnd) + 1;
                }
                catch (Exception fuck)
                {
                    tbInstructions.Text += "\r\n" + fuck.Message + "\r\n";
                }
                if (subPos >= 0 && subEnd >= 0 && subEnd < JobTemp.Length)
                {
                    try
                    {
                        string SubTemp = m_optionsForm.SubFilePath;
                        if (m_optionsForm.SubFindChk)
                        {
                            SubTemp = Path.GetFileName(JobTemp.Substring(subPos, subEnd - subPos));
                            m_optionsForm.SubFilePath = SubTemp;
                        } 
                        
                        if (m_optionsForm.SubChk)
                        {
                            JobTemp = JobTemp.Replace(SubTemp, "%F");
                        }
                    }
                    catch (Exception e)
                    {
                        tbInstructions.Text += e.Message;
                    }
                }
                if (audPos >= 0 && audEnd >= 0 && audEnd < JobTemp.Length)
                {
                    try
                    {
                        string AudTemp = m_optionsForm.AudFilePath;
                        if (m_optionsForm.AudFindChk)
                        {
                            AudTemp = Path.GetFileNameWithoutExtension(JobTemp.Substring(audPos, audEnd - audPos));
                            m_optionsForm.AudFilePath = AudTemp;
                        }

                        if (m_optionsForm.AudChk)
                        {
                            JobTemp = JobTemp.Replace(AudTemp, "%F");
                        }
                    }
                    catch (Exception e)
                    {
                        tbInstructions.Text += e.Message;
                    }
                    


                }
                //string OutputDoublePath = Path.GetFullPath(m_optionsForm.AviOutPath).Replace(@"\", "\\");
                tbTemplate.Text = "// $job \"VDSCRIPT Job %n\"\r\n" + 
                    "// $input \"%p\"\r\n" + 
                    "// $output \"" + Path.GetFullPath(m_optionsForm.AviOutPath) + 
                    "%F.avi\"\r\n" + 
                    "// $state 0\r\n" +
                    "// $start_time 0 0\r\n" +
                    "// $end_time 0 0\r\n" +
                    "// $script\r\n\r\n" +
                    "VirtualDub.Open(\"%P\",0,0);\r\n";
                tbTemplate.Text += JobTemp;
                tbTemplate.Text += "VirtualDub.subset.Delete();\r\n" +
                    "VirtualDub.SaveAVI(\"" + Path.GetFullPath(m_optionsForm.AviOutPath).Replace("\\", "\\\\") + "%F.avi\");\r\n" +
                    "VirtualDub.audio.SetSource(1);\r\n" +
                    "VirtualDub.Close();\r\n\r\n" +
                    "// $endjob\r\n" +
                    "//\r\n" +
                    "//--------------------------------------------------";
                ScriptLoaded = true;
            }
            reader.Close();

        }
        

        private void btnReload_Click(object sender, EventArgs e)
        {
            
            try
            {
                //tbTemplate.Text = lvFiles.SelectedItems[0].SubItems[2].Text;
                FullReload(lvFiles.SelectedItems[0]);
            }
            catch (Exception ex)
            {
                tbInstructions.Text += ex.Message;
            }
        }

        private void FullReload (ListViewItem lvItem)
        {
            bool oldSubFind = m_optionsForm.SubFindChk;
            bool oldAudFind = m_optionsForm.AudFindChk;
            //bool subOK, audOK;
            try
            {


                if (lvItem.SubItems[2].Text == "")
                {
                    m_optionsForm.AudFindChk = false;
                    m_optionsForm.SubFindChk = false;
                    /*
                    sItem.SubItems.Add(ofdVDScript.FileName);
                    sItem.SubItems.Add(m_optionsForm.SubFilePath);
                    sItem.SubItems.Add(m_optionsForm.AudFilePath);
                    sItem.SubItems.Add(m_optionsForm.SubChk.ToString());
                    sItem.SubItems.Add(m_optionsForm.AudChk.ToString());
                    */
                    ofdVDScript.FileName = lvItem.SubItems[3].Text;
                    m_optionsForm.SubFilePath = lvItem.SubItems[4].Text;
                    m_optionsForm.AudFilePath = lvItem.SubItems[5].Text;
                    m_optionsForm.SubChk = bool.Parse(lvItem.SubItems[6].Text);
                    m_optionsForm.AudChk = bool.Parse(lvItem.SubItems[7].Text);
                    m_optionsForm.SubFindChk = oldSubFind;
                    m_optionsForm.AudFindChk = oldAudFind;
                    OpenVDScript(ofdVDScript.FileName);
                }
                else
                {
                    tbTemplate.Text = lvItem.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                tbInstructions.Text += ex.StackTrace;
            }
        }



        public void ReloadVdscript()
        {
            if (ScriptLoaded)
            {
                OpenVDScript(ofdVDScript.FileName);
            }
            
        }
    }
}

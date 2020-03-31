namespace ArmaCore_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelsrvName = new System.Windows.Forms.Label();
            this.labelsrvStatus = new System.Windows.Forms.Label();
            this.labelsrvPing = new System.Windows.Forms.Label();
            this.labelsrvOnline = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelWhitelisted = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.text_fileDownloading = new System.Windows.Forms.Label();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.labelPerc = new System.Windows.Forms.Label();
            this.text_speed = new System.Windows.Forms.Label();
            this.checkNoSplash = new System.Windows.Forms.CheckBox();
            this.checkWindow = new System.Windows.Forms.CheckBox();
            this.checkSkipIntro = new System.Windows.Forms.CheckBox();
            this.checkNoPause = new System.Windows.Forms.CheckBox();
            this.checkshowScriptErrors = new System.Windows.Forms.CheckBox();
            this.checknologs = new System.Windows.Forms.CheckBox();
            this.check64Bit = new System.Windows.Forms.CheckBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.text_Sync = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCash = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.Label();
            this.txtPlaytime = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txt_a3path = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.serverCombo = new System.Windows.Forms.ComboBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(751, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(35)))));
            this.panelTop.Controls.Add(this.labelVersion);
            this.panelTop.Controls.Add(this.button2);
            this.panelTop.Controls.Add(this.labelWelcome);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.button1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 42);
            this.panelTop.TabIndex = 3;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTop_MouseDown);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.White;
            this.labelVersion.Location = new System.Drawing.Point(580, 16);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(110, 13);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "Client Version: 0.0.0.0";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(696, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(49, 41);
            this.button2.TabIndex = 4;
            this.button2.Text = "_";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.labelWelcome.Location = new System.Drawing.Point(75, 11);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(281, 18);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome Debug to ArmaCore Client";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ArmaCore_Client.Properties.Resources.armacorelogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 37);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Server Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Server Status:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Server Ping:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Online Player(s):";
            // 
            // labelsrvName
            // 
            this.labelsrvName.AutoSize = true;
            this.labelsrvName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsrvName.ForeColor = System.Drawing.Color.White;
            this.labelsrvName.Location = new System.Drawing.Point(127, 70);
            this.labelsrvName.Name = "labelsrvName";
            this.labelsrvName.Size = new System.Drawing.Size(73, 16);
            this.labelsrvName.TabIndex = 8;
            this.labelsrvName.Text = "Loading...";
            // 
            // labelsrvStatus
            // 
            this.labelsrvStatus.AutoSize = true;
            this.labelsrvStatus.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsrvStatus.ForeColor = System.Drawing.Color.White;
            this.labelsrvStatus.Location = new System.Drawing.Point(127, 106);
            this.labelsrvStatus.Name = "labelsrvStatus";
            this.labelsrvStatus.Size = new System.Drawing.Size(73, 16);
            this.labelsrvStatus.TabIndex = 9;
            this.labelsrvStatus.Text = "Loading...";
            // 
            // labelsrvPing
            // 
            this.labelsrvPing.AutoSize = true;
            this.labelsrvPing.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsrvPing.ForeColor = System.Drawing.Color.White;
            this.labelsrvPing.Location = new System.Drawing.Point(127, 145);
            this.labelsrvPing.Name = "labelsrvPing";
            this.labelsrvPing.Size = new System.Drawing.Size(73, 16);
            this.labelsrvPing.TabIndex = 10;
            this.labelsrvPing.Text = "Loading...";
            // 
            // labelsrvOnline
            // 
            this.labelsrvOnline.AutoSize = true;
            this.labelsrvOnline.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsrvOnline.ForeColor = System.Drawing.Color.White;
            this.labelsrvOnline.Location = new System.Drawing.Point(127, 181);
            this.labelsrvOnline.Name = "labelsrvOnline";
            this.labelsrvOnline.Size = new System.Drawing.Size(73, 16);
            this.labelsrvOnline.TabIndex = 11;
            this.labelsrvOnline.Text = "Loading...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Whitelist Status:";
            // 
            // labelWhitelisted
            // 
            this.labelWhitelisted.AutoSize = true;
            this.labelWhitelisted.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWhitelisted.ForeColor = System.Drawing.Color.White;
            this.labelWhitelisted.Location = new System.Drawing.Point(127, 219);
            this.labelWhitelisted.Name = "labelWhitelisted";
            this.labelWhitelisted.Size = new System.Drawing.Size(73, 16);
            this.labelWhitelisted.TabIndex = 14;
            this.labelWhitelisted.Text = "Loading...";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(0, 398);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            // 
            // text_fileDownloading
            // 
            this.text_fileDownloading.AutoSize = true;
            this.text_fileDownloading.ForeColor = System.Drawing.Color.White;
            this.text_fileDownloading.Location = new System.Drawing.Point(47, 300);
            this.text_fileDownloading.Name = "text_fileDownloading";
            this.text_fileDownloading.Size = new System.Drawing.Size(91, 13);
            this.text_fileDownloading.TabIndex = 32;
            this.text_fileDownloading.Text = "Downloading File:";
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.ForeColor = System.Drawing.Color.White;
            this.labelDownloaded.Location = new System.Drawing.Point(68, 373);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(70, 13);
            this.labelDownloaded.TabIndex = 31;
            this.labelDownloaded.Text = "Downloaded:";
            // 
            // labelPerc
            // 
            this.labelPerc.AutoSize = true;
            this.labelPerc.ForeColor = System.Drawing.Color.White;
            this.labelPerc.Location = new System.Drawing.Point(3, 348);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(135, 13);
            this.labelPerc.TabIndex = 30;
            this.labelPerc.Text = "File Download Percentage:";
            // 
            // text_speed
            // 
            this.text_speed.AutoSize = true;
            this.text_speed.ForeColor = System.Drawing.Color.White;
            this.text_speed.Location = new System.Drawing.Point(46, 324);
            this.text_speed.Name = "text_speed";
            this.text_speed.Size = new System.Drawing.Size(92, 13);
            this.text_speed.TabIndex = 29;
            this.text_speed.Text = "Download Speed:";
            // 
            // checkNoSplash
            // 
            this.checkNoSplash.AutoSize = true;
            this.checkNoSplash.ForeColor = System.Drawing.Color.White;
            this.checkNoSplash.Location = new System.Drawing.Point(683, 333);
            this.checkNoSplash.Name = "checkNoSplash";
            this.checkNoSplash.Size = new System.Drawing.Size(72, 17);
            this.checkNoSplash.TabIndex = 33;
            this.checkNoSplash.Text = "NoSplash";
            this.checkNoSplash.UseVisualStyleBackColor = true;
            this.checkNoSplash.CheckedChanged += new System.EventHandler(this.CheckNoSplash_CheckedChanged);
            // 
            // checkWindow
            // 
            this.checkWindow.AutoSize = true;
            this.checkWindow.ForeColor = System.Drawing.Color.White;
            this.checkWindow.Location = new System.Drawing.Point(683, 310);
            this.checkWindow.Name = "checkWindow";
            this.checkWindow.Size = new System.Drawing.Size(94, 17);
            this.checkWindow.TabIndex = 34;
            this.checkWindow.Text = "Window mode";
            this.checkWindow.UseVisualStyleBackColor = true;
            this.checkWindow.CheckedChanged += new System.EventHandler(this.CheckWindow_CheckedChanged);
            // 
            // checkSkipIntro
            // 
            this.checkSkipIntro.AutoSize = true;
            this.checkSkipIntro.ForeColor = System.Drawing.Color.White;
            this.checkSkipIntro.Location = new System.Drawing.Point(683, 287);
            this.checkSkipIntro.Name = "checkSkipIntro";
            this.checkSkipIntro.Size = new System.Drawing.Size(66, 17);
            this.checkSkipIntro.TabIndex = 35;
            this.checkSkipIntro.Text = "skipIntro";
            this.checkSkipIntro.UseVisualStyleBackColor = true;
            this.checkSkipIntro.CheckedChanged += new System.EventHandler(this.CheckSkipIntro_CheckedChanged);
            // 
            // checkNoPause
            // 
            this.checkNoPause.AutoSize = true;
            this.checkNoPause.ForeColor = System.Drawing.Color.White;
            this.checkNoPause.Location = new System.Drawing.Point(683, 264);
            this.checkNoPause.Name = "checkNoPause";
            this.checkNoPause.Size = new System.Drawing.Size(68, 17);
            this.checkNoPause.TabIndex = 36;
            this.checkNoPause.Text = "noPause";
            this.checkNoPause.UseVisualStyleBackColor = true;
            this.checkNoPause.CheckedChanged += new System.EventHandler(this.CheckNoPause_CheckedChanged);
            // 
            // checkshowScriptErrors
            // 
            this.checkshowScriptErrors.AutoSize = true;
            this.checkshowScriptErrors.ForeColor = System.Drawing.Color.White;
            this.checkshowScriptErrors.Location = new System.Drawing.Point(683, 218);
            this.checkshowScriptErrors.Name = "checkshowScriptErrors";
            this.checkshowScriptErrors.Size = new System.Drawing.Size(105, 17);
            this.checkshowScriptErrors.TabIndex = 37;
            this.checkshowScriptErrors.Text = "showScriptErrors";
            this.checkshowScriptErrors.UseVisualStyleBackColor = true;
            this.checkshowScriptErrors.CheckedChanged += new System.EventHandler(this.CheckshowScriptErrors_CheckedChanged);
            // 
            // checknologs
            // 
            this.checknologs.AutoSize = true;
            this.checknologs.ForeColor = System.Drawing.Color.White;
            this.checknologs.Location = new System.Drawing.Point(683, 241);
            this.checknologs.Name = "checknologs";
            this.checknologs.Size = new System.Drawing.Size(61, 17);
            this.checknologs.TabIndex = 38;
            this.checknologs.Text = "noLogs";
            this.checknologs.UseVisualStyleBackColor = true;
            this.checknologs.CheckedChanged += new System.EventHandler(this.Checknologs_CheckedChanged);
            // 
            // check64Bit
            // 
            this.check64Bit.AutoSize = true;
            this.check64Bit.ForeColor = System.Drawing.Color.White;
            this.check64Bit.Location = new System.Drawing.Point(683, 356);
            this.check64Bit.Name = "check64Bit";
            this.check64Bit.Size = new System.Drawing.Size(87, 17);
            this.check64Bit.TabIndex = 39;
            this.check64Bit.Text = "64Bit ArmA 3";
            this.check64Bit.UseVisualStyleBackColor = true;
            this.check64Bit.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.Color.White;
            this.progressBar2.Location = new System.Drawing.Point(0, 427);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(800, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 40;
            // 
            // text_Sync
            // 
            this.text_Sync.AutoSize = true;
            this.text_Sync.ForeColor = System.Drawing.Color.Black;
            this.text_Sync.Location = new System.Drawing.Point(309, 279);
            this.text_Sync.Name = "text_Sync";
            this.text_Sync.Size = new System.Drawing.Size(0, 13);
            this.text_Sync.TabIndex = 41;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::ArmaCore_Client.Properties.Resources.clock;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(606, 160);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(47, 44);
            this.pictureBox4.TabIndex = 44;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ArmaCore_Client.Properties.Resources.bank;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(606, 110);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 44);
            this.pictureBox3.TabIndex = 43;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::ArmaCore_Client.Properties.Resources.coin;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(606, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 44);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::ArmaCore_Client.Properties.Resources.synchronization_arrows;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(312, 306);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(178, 31);
            this.button5.TabIndex = 17;
            this.button5.Text = "Sync Addons";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::ArmaCore_Client.Properties.Resources.download;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(312, 343);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(178, 31);
            this.button4.TabIndex = 16;
            this.button4.Text = "Stop Download";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::ArmaCore_Client.Properties.Resources.go;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(15, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 31);
            this.button3.TabIndex = 12;
            this.button3.Text = "Join Server";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // txtCash
            // 
            this.txtCash.AutoSize = true;
            this.txtCash.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.ForeColor = System.Drawing.Color.White;
            this.txtCash.Location = new System.Drawing.Point(680, 70);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(70, 16);
            this.txtCash.TabIndex = 45;
            this.txtCash.Text = "Loading...";
            // 
            // txtBank
            // 
            this.txtBank.AutoSize = true;
            this.txtBank.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBank.ForeColor = System.Drawing.Color.White;
            this.txtBank.Location = new System.Drawing.Point(680, 125);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(70, 16);
            this.txtBank.TabIndex = 46;
            this.txtBank.Text = "Loading...";
            // 
            // txtPlaytime
            // 
            this.txtPlaytime.AutoSize = true;
            this.txtPlaytime.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaytime.ForeColor = System.Drawing.Color.White;
            this.txtPlaytime.Location = new System.Drawing.Point(680, 172);
            this.txtPlaytime.Name = "txtPlaytime";
            this.txtPlaytime.Size = new System.Drawing.Size(70, 16);
            this.txtPlaytime.TabIndex = 47;
            this.txtPlaytime.Text = "Loading...";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            this.linkLabel1.Location = new System.Drawing.Point(375, 382);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 13);
            this.linkLabel1.TabIndex = 48;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Clear Bisigns";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // txt_a3path
            // 
            this.txt_a3path.Location = new System.Drawing.Point(572, 375);
            this.txt_a3path.Name = "txt_a3path";
            this.txt_a3path.Size = new System.Drawing.Size(181, 20);
            this.txt_a3path.TabIndex = 49;
            // 
            // button6
            // 
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(751, 375);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(41, 19);
            this.button6.TabIndex = 50;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(478, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 14);
            this.label6.TabIndex = 51;
            this.label6.Text = "ArmA 3 Path:";
            // 
            // serverCombo
            // 
            this.serverCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.serverCombo.FormattingEnabled = true;
            this.serverCombo.Items.AddRange(new object[] {
            "Canada Server #1",
            "EU Server #1 (DEV)"});
            this.serverCombo.Location = new System.Drawing.Point(312, 276);
            this.serverCombo.Name = "serverCombo";
            this.serverCombo.Size = new System.Drawing.Size(178, 21);
            this.serverCombo.TabIndex = 52;
            this.serverCombo.Text = "Canada Server #1";
            this.serverCombo.SelectedIndexChanged += new System.EventHandler(this.ServerCombo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(32)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.serverCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txt_a3path);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtPlaytime);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.text_Sync);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.check64Bit);
            this.Controls.Add(this.checknologs);
            this.Controls.Add(this.checkshowScriptErrors);
            this.Controls.Add(this.checkNoPause);
            this.Controls.Add(this.checkSkipIntro);
            this.Controls.Add(this.checkWindow);
            this.Controls.Add(this.checkNoSplash);
            this.Controls.Add(this.text_fileDownloading);
            this.Controls.Add(this.labelDownloaded);
            this.Controls.Add(this.labelPerc);
            this.Controls.Add(this.text_speed);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelWhitelisted);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelsrvOnline);
            this.Controls.Add(this.labelsrvPing);
            this.Controls.Add(this.labelsrvStatus);
            this.Controls.Add(this.labelsrvName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ArmaCore Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelsrvName;
        private System.Windows.Forms.Label labelsrvStatus;
        private System.Windows.Forms.Label labelsrvPing;
        private System.Windows.Forms.Label labelsrvOnline;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelWhitelisted;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label text_fileDownloading;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.Label text_speed;
        private System.Windows.Forms.CheckBox checkNoSplash;
        private System.Windows.Forms.CheckBox checkWindow;
        private System.Windows.Forms.CheckBox checkSkipIntro;
        private System.Windows.Forms.CheckBox checkNoPause;
        private System.Windows.Forms.CheckBox checkshowScriptErrors;
        private System.Windows.Forms.CheckBox checknologs;
        private System.Windows.Forms.CheckBox check64Bit;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label text_Sync;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label txtCash;
        private System.Windows.Forms.Label txtBank;
        private System.Windows.Forms.Label txtPlaytime;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txt_a3path;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox serverCombo;
    }
}


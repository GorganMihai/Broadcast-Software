using System.Drawing;

namespace Broadcast_Software
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.btn_StartStreaming = new System.Windows.Forms.Button();
            this.btn_inputSettings = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Scenes = new System.Windows.Forms.Button();
            this.btn_StopStreaming = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.Btn_T1Score_Minus = new System.Windows.Forms.Button();
            this.Btn_T1Score_Plus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ResetScore = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_T2Score_Minus = new System.Windows.Forms.Button();
            this.Btn_T2Score_Plus = new System.Windows.Forms.Button();
            this.btn_StartTimer = new System.Windows.Forms.Button();
            this.btn_StopTimer = new System.Windows.Forms.Button();
            this.btn_ResetTimer = new System.Windows.Forms.Button();
            this.TimerFps = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ScoreBarPanel0 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.ScoreBarPanel = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btn_maxMinWindows = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btn_StopPreview = new System.Windows.Forms.Button();
            this.labelAudioSource = new System.Windows.Forms.Label();
            this.labelVideoSource = new System.Windows.Forms.Label();
            this.btn_StartPreview = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ScoreBarPanel0.SuspendLayout();
            this.ScoreBarPanel.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Black;
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxMain.Image = global::Broadcast_Software.Properties.Resources.MainImagePlayer;
            this.pictureBoxMain.Location = new System.Drawing.Point(4, 22);
            this.pictureBoxMain.Margin = new System.Windows.Forms.Padding(29, 33, 29, 33);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(857, 482);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 19;
            this.pictureBoxMain.TabStop = false;
            // 
            // btn_StartStreaming
            // 
            this.btn_StartStreaming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_StartStreaming.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_StartStreaming.Enabled = false;
            this.btn_StartStreaming.FlatAppearance.BorderSize = 0;
            this.btn_StartStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartStreaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartStreaming.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StartStreaming.Image = global::Broadcast_Software.Properties.Resources.StartStreamingBlack;
            this.btn_StartStreaming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StartStreaming.Location = new System.Drawing.Point(2, 5);
            this.btn_StartStreaming.Margin = new System.Windows.Forms.Padding(1);
            this.btn_StartStreaming.Name = "btn_StartStreaming";
            this.btn_StartStreaming.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btn_StartStreaming.Size = new System.Drawing.Size(220, 60);
            this.btn_StartStreaming.TabIndex = 25;
            this.btn_StartStreaming.Text = "  Start Streaming";
            this.btn_StartStreaming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StartStreaming.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_StartStreaming.UseVisualStyleBackColor = false;
            this.btn_StartStreaming.EnabledChanged += new System.EventHandler(this.btn_StartStreaming_EnabledChanged);
            this.btn_StartStreaming.Click += new System.EventHandler(this.btn_StartStreaming_Click);
            // 
            // btn_inputSettings
            // 
            this.btn_inputSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_inputSettings.FlatAppearance.BorderSize = 0;
            this.btn_inputSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inputSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inputSettings.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_inputSettings.Image = global::Broadcast_Software.Properties.Resources.SettingsWhite;
            this.btn_inputSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_inputSettings.Location = new System.Drawing.Point(2, 171);
            this.btn_inputSettings.Margin = new System.Windows.Forms.Padding(1);
            this.btn_inputSettings.Name = "btn_inputSettings";
            this.btn_inputSettings.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btn_inputSettings.Size = new System.Drawing.Size(220, 60);
            this.btn_inputSettings.TabIndex = 0;
            this.btn_inputSettings.Text = "  Settings";
            this.btn_inputSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_inputSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_inputSettings.UseVisualStyleBackColor = false;
            this.btn_inputSettings.EnabledChanged += new System.EventHandler(this.btn_inputSettings_EnabledChanged);
            this.btn_inputSettings.Click += new System.EventHandler(this.btn_inputSettings_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Exit.Image = global::Broadcast_Software.Properties.Resources.Exit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(2, 336);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btn_Exit.Size = new System.Drawing.Size(220, 60);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "  Exit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Scenes
            // 
            this.btn_Scenes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_Scenes.Enabled = false;
            this.btn_Scenes.FlatAppearance.BorderSize = 0;
            this.btn_Scenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Scenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Scenes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_Scenes.Image = global::Broadcast_Software.Properties.Resources.SceneBlack;
            this.btn_Scenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Scenes.Location = new System.Drawing.Point(2, 233);
            this.btn_Scenes.Margin = new System.Windows.Forms.Padding(1);
            this.btn_Scenes.Name = "btn_Scenes";
            this.btn_Scenes.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btn_Scenes.Size = new System.Drawing.Size(220, 60);
            this.btn_Scenes.TabIndex = 2;
            this.btn_Scenes.Text = "  Scene";
            this.btn_Scenes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Scenes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Scenes.UseVisualStyleBackColor = false;
            this.btn_Scenes.EnabledChanged += new System.EventHandler(this.btn_Scenes_EnabledChanged);
            this.btn_Scenes.Click += new System.EventHandler(this.btn_Scenes_Click);
            // 
            // btn_StopStreaming
            // 
            this.btn_StopStreaming.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_StopStreaming.Enabled = false;
            this.btn_StopStreaming.FlatAppearance.BorderSize = 0;
            this.btn_StopStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StopStreaming.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopStreaming.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StopStreaming.Image = global::Broadcast_Software.Properties.Resources.StopStreamingBlack;
            this.btn_StopStreaming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StopStreaming.Location = new System.Drawing.Point(2, 68);
            this.btn_StopStreaming.Margin = new System.Windows.Forms.Padding(1);
            this.btn_StopStreaming.Name = "btn_StopStreaming";
            this.btn_StopStreaming.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.btn_StopStreaming.Size = new System.Drawing.Size(220, 60);
            this.btn_StopStreaming.TabIndex = 24;
            this.btn_StopStreaming.Text = "  Stop Streaming";
            this.btn_StopStreaming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StopStreaming.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_StopStreaming.UseVisualStyleBackColor = false;
            this.btn_StopStreaming.EnabledChanged += new System.EventHandler(this.btn_StopStreaming_EnabledChanged);
            this.btn_StopStreaming.Click += new System.EventHandler(this.btn_StopStreaming_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            // 
            // Btn_T1Score_Minus
            // 
            this.Btn_T1Score_Minus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Btn_T1Score_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_T1Score_Minus.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_T1Score_Minus.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_T1Score_Minus.Location = new System.Drawing.Point(106, 65);
            this.Btn_T1Score_Minus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_T1Score_Minus.Name = "Btn_T1Score_Minus";
            this.Btn_T1Score_Minus.Size = new System.Drawing.Size(135, 30);
            this.Btn_T1Score_Minus.TabIndex = 2;
            this.Btn_T1Score_Minus.Text = "-";
            this.Btn_T1Score_Minus.UseVisualStyleBackColor = false;
            this.Btn_T1Score_Minus.Click += new System.EventHandler(this.Btn_T1Score_Minus_Click);
            // 
            // Btn_T1Score_Plus
            // 
            this.Btn_T1Score_Plus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Btn_T1Score_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_T1Score_Plus.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_T1Score_Plus.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_T1Score_Plus.Location = new System.Drawing.Point(252, 65);
            this.Btn_T1Score_Plus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_T1Score_Plus.Name = "Btn_T1Score_Plus";
            this.Btn_T1Score_Plus.Size = new System.Drawing.Size(135, 30);
            this.Btn_T1Score_Plus.TabIndex = 3;
            this.Btn_T1Score_Plus.Text = "+";
            this.Btn_T1Score_Plus.UseVisualStyleBackColor = false;
            this.Btn_T1Score_Plus.Click += new System.EventHandler(this.Btn_T1Score_Plus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(37, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Team 2";
            // 
            // btn_ResetScore
            // 
            this.btn_ResetScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_ResetScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetScore.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_ResetScore.Location = new System.Drawing.Point(106, 147);
            this.btn_ResetScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ResetScore.Name = "btn_ResetScore";
            this.btn_ResetScore.Size = new System.Drawing.Size(281, 30);
            this.btn_ResetScore.TabIndex = 10;
            this.btn_ResetScore.Text = "Reset Score";
            this.btn_ResetScore.UseVisualStyleBackColor = false;
            this.btn_ResetScore.Click += new System.EventHandler(this.btn_ResetScore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(37, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Team 1 ";
            // 
            // Btn_T2Score_Minus
            // 
            this.Btn_T2Score_Minus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Btn_T2Score_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_T2Score_Minus.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_T2Score_Minus.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_T2Score_Minus.Location = new System.Drawing.Point(106, 105);
            this.Btn_T2Score_Minus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_T2Score_Minus.Name = "Btn_T2Score_Minus";
            this.Btn_T2Score_Minus.Size = new System.Drawing.Size(135, 30);
            this.Btn_T2Score_Minus.TabIndex = 4;
            this.Btn_T2Score_Minus.Text = "-";
            this.Btn_T2Score_Minus.UseVisualStyleBackColor = false;
            this.Btn_T2Score_Minus.Click += new System.EventHandler(this.Btn_T2Score_Minus_Click);
            // 
            // Btn_T2Score_Plus
            // 
            this.Btn_T2Score_Plus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.Btn_T2Score_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_T2Score_Plus.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_T2Score_Plus.ForeColor = System.Drawing.Color.Gainsboro;
            this.Btn_T2Score_Plus.Location = new System.Drawing.Point(252, 105);
            this.Btn_T2Score_Plus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_T2Score_Plus.Name = "Btn_T2Score_Plus";
            this.Btn_T2Score_Plus.Size = new System.Drawing.Size(135, 30);
            this.Btn_T2Score_Plus.TabIndex = 5;
            this.Btn_T2Score_Plus.Text = "+";
            this.Btn_T2Score_Plus.UseVisualStyleBackColor = false;
            this.Btn_T2Score_Plus.Click += new System.EventHandler(this.Btn_T2Score_Plus_Click);
            // 
            // btn_StartTimer
            // 
            this.btn_StartTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_StartTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartTimer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StartTimer.Location = new System.Drawing.Point(471, 65);
            this.btn_StartTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_StartTimer.Name = "btn_StartTimer";
            this.btn_StartTimer.Size = new System.Drawing.Size(170, 30);
            this.btn_StartTimer.TabIndex = 7;
            this.btn_StartTimer.Text = "Start";
            this.btn_StartTimer.UseVisualStyleBackColor = false;
            this.btn_StartTimer.Click += new System.EventHandler(this.btn_StartTimer_Click);
            // 
            // btn_StopTimer
            // 
            this.btn_StopTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_StopTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopTimer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StopTimer.Location = new System.Drawing.Point(651, 65);
            this.btn_StopTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_StopTimer.Name = "btn_StopTimer";
            this.btn_StopTimer.Size = new System.Drawing.Size(170, 30);
            this.btn_StopTimer.TabIndex = 8;
            this.btn_StopTimer.Text = "Pause";
            this.btn_StopTimer.UseVisualStyleBackColor = false;
            this.btn_StopTimer.Click += new System.EventHandler(this.btn_StopTimer_Click);
            // 
            // btn_ResetTimer
            // 
            this.btn_ResetTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.btn_ResetTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ResetTimer.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_ResetTimer.Location = new System.Drawing.Point(471, 106);
            this.btn_ResetTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ResetTimer.Name = "btn_ResetTimer";
            this.btn_ResetTimer.Size = new System.Drawing.Size(348, 30);
            this.btn_ResetTimer.TabIndex = 9;
            this.btn_ResetTimer.Text = "Reset";
            this.btn_ResetTimer.UseVisualStyleBackColor = false;
            this.btn_ResetTimer.Click += new System.EventHandler(this.btn_ResetTimer_Click);
            // 
            // TimerFps
            // 
            this.TimerFps.Interval = 1000;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.panel3.Location = new System.Drawing.Point(23, 149);
            this.panel3.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 1);
            this.panel3.TabIndex = 28;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.panel1);
            this.panelButtons.Controls.Add(this.btn_StartStreaming);
            this.panelButtons.Controls.Add(this.panel3);
            this.panelButtons.Controls.Add(this.btn_StopStreaming);
            this.panelButtons.Controls.Add(this.btn_inputSettings);
            this.panelButtons.Controls.Add(this.btn_Scenes);
            this.panelButtons.Controls.Add(this.btn_Exit);
            this.panelButtons.Location = new System.Drawing.Point(2, 22);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(227, 820);
            this.panelButtons.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.panel1.Location = new System.Drawing.Point(23, 314);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 1);
            this.panel1.TabIndex = 29;
            // 
            // pictureBox2
            // 
            this.pictureBox2.ErrorImage = global::Broadcast_Software.Properties.Resources.IconLogoBroadcasting;
            this.pictureBox2.Image = global::Broadcast_Software.Properties.Resources.IconLogoBroadcasting;
            this.pictureBox2.InitialImage = global::Broadcast_Software.Properties.Resources.IconLogoBroadcasting;
            this.pictureBox2.Location = new System.Drawing.Point(10, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 45);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Broadcast_Software.Properties.Resources.BroadcastingStudioLogo;
            this.pictureBox1.Location = new System.Drawing.Point(44, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ScoreBarPanel0
            // 
            this.ScoreBarPanel0.BackColor = System.Drawing.Color.DimGray;
            this.ScoreBarPanel0.Controls.Add(this.label6);
            this.ScoreBarPanel0.Controls.Add(this.ScoreBarPanel);
            this.ScoreBarPanel0.Location = new System.Drawing.Point(241, 665);
            this.ScoreBarPanel0.Name = "ScoreBarPanel0";
            this.ScoreBarPanel0.Padding = new System.Windows.Forms.Padding(3);
            this.ScoreBarPanel0.Size = new System.Drawing.Size(866, 229);
            this.ScoreBarPanel0.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(371, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Scorebar Settings";
            // 
            // ScoreBarPanel
            // 
            this.ScoreBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ScoreBarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ScoreBarPanel.Controls.Add(this.panel11);
            this.ScoreBarPanel.Controls.Add(this.panel10);
            this.ScoreBarPanel.Controls.Add(this.btn_StartTimer);
            this.ScoreBarPanel.Controls.Add(this.btn_StopTimer);
            this.ScoreBarPanel.Controls.Add(this.Btn_T1Score_Minus);
            this.ScoreBarPanel.Controls.Add(this.btn_ResetTimer);
            this.ScoreBarPanel.Controls.Add(this.label8);
            this.ScoreBarPanel.Controls.Add(this.Btn_T1Score_Plus);
            this.ScoreBarPanel.Controls.Add(this.label7);
            this.ScoreBarPanel.Controls.Add(this.label2);
            this.ScoreBarPanel.Controls.Add(this.panel9);
            this.ScoreBarPanel.Controls.Add(this.btn_ResetScore);
            this.ScoreBarPanel.Controls.Add(this.label1);
            this.ScoreBarPanel.Controls.Add(this.Btn_T2Score_Plus);
            this.ScoreBarPanel.Controls.Add(this.Btn_T2Score_Minus);
            this.ScoreBarPanel.Enabled = false;
            this.ScoreBarPanel.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreBarPanel.Location = new System.Drawing.Point(3, 22);
            this.ScoreBarPanel.Name = "ScoreBarPanel";
            this.ScoreBarPanel.Size = new System.Drawing.Size(860, 203);
            this.ScoreBarPanel.TabIndex = 34;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.panel11.Location = new System.Drawing.Point(471, 41);
            this.panel11.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(350, 1);
            this.panel11.TabIndex = 39;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.panel10.Location = new System.Drawing.Point(37, 41);
            this.panel10.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(350, 1);
            this.panel10.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(627, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "TIME";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(191, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 36;
            this.label7.Text = "SCORE";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DimGray;
            this.panel9.Location = new System.Drawing.Point(426, -1);
            this.panel9.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(5, 200);
            this.panel9.TabIndex = 30;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Controls.Add(this.pictureBox2);
            this.panelTitle.Controls.Add(this.btnCloseWindow);
            this.panelTitle.Controls.Add(this.btn_maxMinWindows);
            this.panelTitle.Controls.Add(this.btnMinimize);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("MS PGothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1111, 43);
            this.panelTitle.TabIndex = 34;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseWindow.FlatAppearance.BorderSize = 0;
            this.btnCloseWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseWindow.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseWindow.Location = new System.Drawing.Point(1077, -1);
            this.btnCloseWindow.Margin = new System.Windows.Forms.Padding(1);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(27, 27);
            this.btnCloseWindow.TabIndex = 2;
            this.btnCloseWindow.Text = "O";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // btn_maxMinWindows
            // 
            this.btn_maxMinWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_maxMinWindows.FlatAppearance.BorderSize = 0;
            this.btn_maxMinWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_maxMinWindows.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_maxMinWindows.Location = new System.Drawing.Point(1050, -1);
            this.btn_maxMinWindows.Margin = new System.Windows.Forms.Padding(1);
            this.btn_maxMinWindows.Name = "btn_maxMinWindows";
            this.btn_maxMinWindows.Size = new System.Drawing.Size(27, 27);
            this.btn_maxMinWindows.TabIndex = 1;
            this.btn_maxMinWindows.Text = "O";
            this.btn_maxMinWindows.UseVisualStyleBackColor = true;
            this.btn_maxMinWindows.Click += new System.EventHandler(this.btn_maxMinWindows_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(1023, -1);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(1);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(27, 27);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "O";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btn_StopPreview
            // 
            this.btn_StopPreview.Enabled = false;
            this.btn_StopPreview.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btn_StopPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StopPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StopPreview.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StopPreview.Image = global::Broadcast_Software.Properties.Resources.StopPreviewBlack;
            this.btn_StopPreview.Location = new System.Drawing.Point(674, 50);
            this.btn_StopPreview.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btn_StopPreview.Name = "btn_StopPreview";
            this.btn_StopPreview.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_StopPreview.Size = new System.Drawing.Size(182, 47);
            this.btn_StopPreview.TabIndex = 4;
            this.btn_StopPreview.Text = " Stop Preview";
            this.btn_StopPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StopPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_StopPreview.UseVisualStyleBackColor = true;
            this.btn_StopPreview.EnabledChanged += new System.EventHandler(this.btn_StopPreview_EnabledChanged);
            this.btn_StopPreview.Click += new System.EventHandler(this.btn_StopPreview_Click);
            // 
            // labelAudioSource
            // 
            this.labelAudioSource.AutoSize = true;
            this.labelAudioSource.BackColor = System.Drawing.Color.DimGray;
            this.labelAudioSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAudioSource.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelAudioSource.Location = new System.Drawing.Point(11, 41);
            this.labelAudioSource.Name = "labelAudioSource";
            this.labelAudioSource.Size = new System.Drawing.Size(24, 18);
            this.labelAudioSource.TabIndex = 33;
            this.labelAudioSource.Text = "....";
            // 
            // labelVideoSource
            // 
            this.labelVideoSource.AutoSize = true;
            this.labelVideoSource.BackColor = System.Drawing.Color.DimGray;
            this.labelVideoSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVideoSource.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelVideoSource.Location = new System.Drawing.Point(11, 12);
            this.labelVideoSource.Name = "labelVideoSource";
            this.labelVideoSource.Size = new System.Drawing.Size(24, 18);
            this.labelVideoSource.TabIndex = 32;
            this.labelVideoSource.Text = "....";
            // 
            // btn_StartPreview
            // 
            this.btn_StartPreview.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btn_StartPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_StartPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_StartPreview.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn_StartPreview.Image = global::Broadcast_Software.Properties.Resources.StartPreviewWhite;
            this.btn_StartPreview.Location = new System.Drawing.Point(674, 0);
            this.btn_StartPreview.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.btn_StartPreview.Name = "btn_StartPreview";
            this.btn_StartPreview.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.btn_StartPreview.Size = new System.Drawing.Size(182, 47);
            this.btn_StartPreview.TabIndex = 1;
            this.btn_StartPreview.Text = " Start Preview";
            this.btn_StartPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_StartPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_StartPreview.UseVisualStyleBackColor = true;
            this.btn_StartPreview.EnabledChanged += new System.EventHandler(this.btn_StartPreview_EnabledChanged);
            this.btn_StartPreview.Click += new System.EventHandler(this.btn_StartPreview_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 898);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1111, 18);
            this.panel2.TabIndex = 35;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DimGray;
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.pictureBoxMain);
            this.panel6.Location = new System.Drawing.Point(241, 48);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(865, 610);
            this.panel6.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(413, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 36;
            this.label5.Text = "Video";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Controls.Add(this.btn_StopPreview);
            this.panel5.Controls.Add(this.labelAudioSource);
            this.panel5.Controls.Add(this.btn_StartPreview);
            this.panel5.Controls.Add(this.labelVideoSource);
            this.panel5.Location = new System.Drawing.Point(4, 508);
            this.panel5.Margin = new System.Windows.Forms.Padding(1);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(857, 97);
            this.panel5.TabIndex = 35;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightGray;
            this.panel8.Location = new System.Drawing.Point(648, 1);
            this.panel8.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1, 98);
            this.panel8.TabIndex = 35;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.Controls.Add(this.label4);
            this.panel7.Controls.Add(this.panelButtons);
            this.panel7.Location = new System.Drawing.Point(5, 48);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(231, 846);
            this.panel7.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(97, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 33;
            this.label4.Text = "Main";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1111, 916);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.ScoreBarPanel0);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ScoreBarPanel0.ResumeLayout(false);
            this.ScoreBarPanel0.PerformLayout();
            this.ScoreBarPanel.ResumeLayout(false);
            this.ScoreBarPanel.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btn_inputSettings;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Scenes;
        private System.Windows.Forms.Button btn_StopStreaming;
        private System.Windows.Forms.Button btn_StartStreaming;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Button btn_ResetTimer;
        private System.Windows.Forms.Button btn_StopTimer;
        private System.Windows.Forms.Button btn_StartTimer;
        private System.Windows.Forms.Button Btn_T2Score_Plus;
        private System.Windows.Forms.Button Btn_T2Score_Minus;
        private System.Windows.Forms.Button Btn_T1Score_Plus;
        private System.Windows.Forms.Button Btn_T1Score_Minus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ResetScore;
        private System.Windows.Forms.Timer TimerFps;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Panel ScoreBarPanel0;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btn_maxMinWindows;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_StopPreview;
        private System.Windows.Forms.Label labelAudioSource;
        private System.Windows.Forms.Label labelVideoSource;
        private System.Windows.Forms.Button btn_StartPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel ScoreBarPanel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
    }
}


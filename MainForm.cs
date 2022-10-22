using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public partial class MainForm : Form
    {
        public const string connectionString = "DataSource = Database.db";
        DeviceHandler devicesHandler;
        static Bitmap imgDefault = Properties.Resources.ScoreBar;
        ImgsOverlayer imgsOverlayer;  // adauga imaginile pe frame prin metoda modFrame 
        ProcessHandler FFmpegProcess;
        ImgsHandler imgsHandler; // gasesti lista de imagini si operatii asupra imaginilor
        Settings settings;
        Size videoRezolution;
        ScoreBar scoreBar;
        infoScorebar defaultInfoScorebars;
        List<infoScorebar> listInfoScorebar;
        public byte[] Content { get; set; }
        public MainForm()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FFmpegProcess = new ProcessHandler();
            this.settings = new Settings();
            this.imgsOverlayer = new ImgsOverlayer(devicesHandler, FFmpegProcess);
            this.imgsHandler = new ImgsHandler(mainTimer, imgsOverlayer);
            //this.DevicesHandler = new DeviceHandler(pctBox, FrameHandler, lb_CameraStatus); camera status label se voui aggiungerla --- riga doppione vedi riga 48
            this.devicesHandler = new DeviceHandler(pictureBoxMain, imgsOverlayer, FFmpegProcess);
            FFmpegProcess.SetDevice(devicesHandler);
            settings.SetLabels(devicesHandler, labelVideoSource, labelAudioSource);
            pictureBoxMain.AllowDrop = true;
            initDeafaultScorebar();
            this.listInfoScorebar = new List<infoScorebar>();
            loadInfoScorebars();
        }

        private void btn_StartPreview_Click(object sender, EventArgs e)
        {
            devicesHandler.SetDevices(settings.GetVideoIndex(), settings.GetVideoModIndex(), settings.GetAudioIndex(), TimerFps);
            devicesHandler.startCamera();

            if (devicesHandler.getDeviceStatus() == true)
            {
                btn_StartPreview.Enabled = false;
                btn_StartStreaming.Enabled = true;
                btn_StopPreview.Enabled = true;
                btn_inputSettings.Enabled = false;
            }
            btn_Scenes.Enabled = false;

        }

        private void btn_StopPreview_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            devicesHandler.stopCamera();
            btn_StopPreview.Enabled = false;
            btn_StartPreview.Enabled = true;
            btn_StartStreaming.Enabled = false;
            btn_inputSettings.Enabled = true;
            pictureBoxMain.Image = Properties.Resources.MainImagePlayer;
            btn_Scenes.Enabled = true;
        }

        private void btn_inputSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsFom(devicesHandler, settings);

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                settingsForm.addSettings(settings);
                imgsHandler.deleteAllFromLists();
                imgsHandler.deleteScorebar();

                videoRezolution = devicesHandler.getVideoRezolution(settings);

                //==========================================================   Adauga o lista DeepCopy de imagini cand modifici setarile 
                imgsOverlayer.setImgList(imgsHandler.getFrameImgListDeepCopy());
            }

            settings.SetLabels(devicesHandler, labelVideoSource, labelAudioSource);
            if (btn_StartPreview.Enabled == true) 
            {
                btn_Scenes.Enabled = true;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_StartStreaming_Click(object sender, EventArgs e)
        {
            if (FFmpegProcess.SetURL(settings.Get_URL_Key()) == true)
            {
                FFmpegProcess.StartLive(videoRezolution, devicesHandler.getAudioDeviceName());

                if (FFmpegProcess.GetLiveStatus() == true)
                {
                    btn_StopPreview.Enabled = false;
                    btn_StartStreaming.Enabled = false;
                    btn_StopStreaming.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Start Live Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid URL or Key", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_StopStreaming_Click(object sender, EventArgs e)
        {
            if (FFmpegProcess.StopLive() == true)
            {
                //imgsOverlayer.clearProcessLists();

                btn_StopPreview.Enabled = true;
                btn_StartStreaming.Enabled = true;
                btn_StopStreaming.Enabled = false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            devicesHandler.stopCamera();
            FFmpegProcess.StopLive();
            FFmpegProcess.StopLive();

        }

        private void btn_Scenes_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            videoRezolution = devicesHandler.getVideoRezolution(settings); //attenzione devi far diventare enable il bottone scene  
            if (videoRezolution == new Size(0, 0)){return;}


            float aspectRatio = (float)videoRezolution.Width / videoRezolution.Height;

            imgsHandler.setRealFrameSize(videoRezolution);

            var sceneForm = new SceneForm(videoRezolution, aspectRatio, imgsHandler, defaultInfoScorebars, this.listInfoScorebar, this);
            
            if (sceneForm.ShowDialog() == DialogResult.OK)
            {
                //Daca nu am bifat scorebar
                if (sceneForm.getScoreBarStatus() == false)
                {
                    imgsHandler.deleteScorebar();

                    ScoreBarPanel.Enabled = false;
                }

                
                imgsOverlayer.setImgList(imgsHandler.getFrameImgListDeepCopy());


                if (imgsHandler.getScoreBarStatus() == true)
                {
                    ScoreBarPanel.Enabled = true;
                    this.scoreBar = imgsHandler.getScoreBar();
                }
                else
                {
                    ScoreBarPanel.Enabled = false;
                }

            }
            else
            {
                if (sceneForm.firstOpen == 2)
                {
                    imgsHandler.deleteScorebar();
                }
                else
                {
                    sceneForm.loadBackUpScoreBar();
                    sceneForm.loadBackupListsFromSceneFormToImgsHandler();
                }

                sceneForm.deleteListsFromImgsHandler();
            }
        }


        private void btn_StartTimer_Click(object sender, EventArgs e)
        {
            mainTimer.Start();
        }

        private void btn_StopTimer_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
        }

        private void btn_ResetTimer_Click(object sender, EventArgs e)
        {
            scoreBar.ResetTime();
        }

        private void Btn_T1Score_Minus_Click(object sender, EventArgs e)
        {
            scoreBar.scoreMinusT1();
        }

        private void Btn_T1Score_Plus_Click(object sender, EventArgs e)
        {
            scoreBar.scorePlusT1();
        }

        private void Btn_T2Score_Minus_Click(object sender, EventArgs e)
        {
            scoreBar.scoreMinusT2();
        }

        private void Btn_T2Score_Plus_Click(object sender, EventArgs e)
        {
            scoreBar.scorePlusT2();
        }

        private void btn_ResetScore_Click(object sender, EventArgs e)
        {
            scoreBar.ResetScore();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maxMinWindows_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_StartStreaming_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_StartStreaming.Enabled == true)
            {
                btn_StartStreaming.Image = Properties.Resources.StartStreamingWhite;
            }
            else
            {
                btn_StartStreaming.Image = Properties.Resources.StartStreamingBlack;
            }
        }

        private void btn_StopStreaming_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_StopStreaming.Enabled == true)
            {
                btn_StopStreaming.Image = Properties.Resources.StopStreamingWhite;
            }
            else
            {
                btn_StopStreaming.Image = Properties.Resources.StopStreamingBlack;
            }
        }

        private void btn_inputSettings_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_inputSettings.Enabled == true)
            {
                btn_inputSettings.Image = Properties.Resources.SettingsWhite;
            }
            else
            {
                btn_inputSettings.Image = Properties.Resources.SettingsBlack;
            }
        }

        private void btn_StartPreview_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_StartPreview.Enabled == true)
            {
                btn_StartPreview.Image = Properties.Resources.StartPreviewWhite;
            }
            else
            {
                btn_StartPreview.Image = Properties.Resources.StartPreviewBlack;
            }
        }

        private void btn_StopPreview_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_StopPreview.Enabled == true)
            {
                btn_StopPreview.Image = Properties.Resources.StopPreviewWhite;
            }
            else
            {
                btn_StopPreview.Image = Properties.Resources.StopPreviewBlack;
            }
        }

        private void initDeafaultScorebar()
        {
            this.defaultInfoScorebars = new infoScorebar("Default Scorebar", imgDefault, 
                                                         new PointF((float)17.5, (float)48),   //Tname1
                                                         new PointF((float)83, (float)48),   //Tname2
                                                         new PointF((float)35.5, (float)32),   //Score1
                                                         new PointF((float)64.3, (float)32),   //Score2
                                                         new PointF((float)50.3, (float)30.0),   //Time
                                                         "Tahoma", //Name
                                                         "Impact", //Score
                                                         "Tahoma", //Time
                                                         "WhiteSmoke",    //Name
                                                         "MediumTurquoise",    //Score
                                                         "WhiteSmoke",    //Time
                                                         14,      //Name  
                                                         23,      //Score
                                                         18       //Time
                                                         );
        }

        private void btn_Scenes_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_Scenes.Enabled == true)
            {
                btn_Scenes.Image = Properties.Resources.Scene;
            }
            else
            {
                btn_Scenes.Image = Properties.Resources.SceneBlack;
            }
        }

        public List<infoScorebar> loadInfoScorebars() 
        {
            this.listInfoScorebar.Clear();

            var query = "SELECT * FROM InfoScorebars ";
            using (var Connection = new SQLiteConnection(connectionString))
            {
                var command = new SQLiteCommand(query, Connection);
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["id"];
                        string name = (string)reader["name"];
                        Bitmap img = (Bitmap)byteArrayToImage((byte[])reader["img"]); 
                        PointF PrcLocationTeamName1 = new PointF((float)(double)reader["team1NameX"], (float)(double)reader["team1NameY"]);
                        PointF PrcLocationTeamName2 = new PointF((float)(double)reader["team2NameX"], (float)(double)reader["team2NameY"]);
                        PointF PrcLocationScoreTeam1 = new PointF((float)(double)reader["scoreTeam1X"], (float)(double)reader["scoreTeam1Y"]);
                        PointF PrcLocationScoreTeam2 = new PointF((float)(double)reader["scoreTeam2X"], (float)(double)reader["scoreTeam2Y"]);
                        PointF PrcLocationTime = new PointF((float)(double)reader["timeX"], (float)(double)reader["timeY"]);
                        string fontTeamNames = (string)reader["fontTeamNames"];
                        string fontScores = (string)reader["fontScores"];
                        string fontTime = (string)reader["fontTime"];
                        string colorTeamNames = (string)reader["colorTeamNames"];
                        string colorScores = (string)reader["colorScores"];
                        string colorTime = (string)reader["colorTime"];
                        int fontSizeTeamNames = (int)(long)reader["fontSizeTeamNames"];
                        int fontSizeScores = (int)(long)reader["fontSizeScores"];
                        int fontSizeTime = (int)(long)reader["fontSizeTime"];

                        this.listInfoScorebar.Add(new infoScorebar((int)id, name, img, 
                            PrcLocationTeamName1, PrcLocationTeamName2, PrcLocationScoreTeam1, PrcLocationScoreTeam2, PrcLocationTime, 
                            fontTeamNames, fontScores, fontTime, 
                            colorTeamNames, colorScores, colorTime,
                            fontSizeTeamNames, fontSizeScores, fontSizeTime));
                    }
                }
            }

                   
            return this.listInfoScorebar;
        }

        private Image byteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                var returnImage = Image.FromStream(ms);

                return returnImage;
            }
        }
    }
}


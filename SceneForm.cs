using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Data.SQLite;

namespace Broadcast_Software
{
    public partial class SceneForm : Form
    {   
        private ScoreBar scoreBar;
        private infoScorebar infoScorebar; //default
        //private infoScorebar infoScorebarMokuit; //Mokuit
        private bool scoreBarStatus;
        private const string connectionString = "DataSource = Database.db";
        public int firstOpen;
        private Size realFrameSize;        
        private ImgsHandler imgsHandler;

        private MainForm main;
        private List<infoScorebar> listInfoScorebar;

        // Pentru BackUp
        private string[] teamName; //0 = Team1 -- 1 = Team2 
        private int seconds;
        private int minutes;
        private int teamScore1;
        private int teamScore2;
        private List<Inmage> backupFinalImgList { get; set; }
        private List<CustomSceneControl> backupControlList { get; set; }
        private int backupID;
        private Size backupScorebarSizeFinalFrame;
        private Size backupScorebarSizeControl;
        private Point backupScorebarLocationFinalFrame;
        private Point backupScorebarLocationControl;
                
       

        public void setScorebarNull() 
        {
            this.scoreBar = null;
        }

        public SceneForm(Size realFrameSize, float aspectRatio, ImgsHandler imgsHandler, infoScorebar defaultinfoScorebar, List<infoScorebar> listInfoScorebar, MainForm main)
        {
            InitializeComponent();
            
            this.realFrameSize = realFrameSize;            
            pictureBoxScene.Width = (int)((float)pictureBoxScene.Height * aspectRatio);            
            this.imgsHandler = imgsHandler;
            imgsHandler.setPicBoxSize(pictureBoxScene.Size);
            this.infoScorebar = defaultinfoScorebar;
            this.listInfoScorebar = listInfoScorebar;
            this.main = main;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void SceneForm_Load(object sender, EventArgs e)
        {
            
            if (imgsHandler.getScoreBarStatus() == true)
            {
                radioButtonScoreBar_Yes.Checked = true;
                this.scoreBar = imgsHandler.getScoreBar();

                tb_teamName1.Text = scoreBar.getT1Name();
                tb_teamName2.Text = scoreBar.getT2Name();

                Nr_ScoreT1.Value = scoreBar.getScoreT1();
                Nr_ScoreT2.Value = scoreBar.getScoreT2();

                Nr_Minutes.Value = scoreBar.getMinutes();
                Nr_Seconds.Value = scoreBar.getSeconds();

                createBackUpInSceneFormForScorebarInImgsHandler(); // creaza backup pentru info din scorebar daca exista


                refreshComboBox();
            }
            else
            {
                radioButtonScoreBar_No.Checked = true;
                this.teamName = new string[2];
                this.teamName[0] = "";
                this.teamName[1] = "";

                this.seconds = 0;
                this.minutes = 0;

                this.teamScore1 = 0;
                this.teamScore2 = 0;                              
            }

            createBackupForLists(); // Creeaza backup pentru listele de imagini, lista de img finala si controls

            pictureBoxScene.AllowDrop = true;
            
            float X = (float)(this.panelScene.Width / 2) - (float)(pictureBoxScene.Width / 2);
            pictureBoxScene.Location = new Point((int)X, pictureBoxScene.Location.Y);

            imgsHandler.displayAllControlsOnPictureBox(pictureBoxScene);
            firstOpen = 0;

        }

        private void picBox_DragDrop(object sender, DragEventArgs e)
        {
            imgsHandler.dragDrop(sender, e, pictureBoxScene);
        }

        private void picBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        public ImgsHandler getLayerBuilder() 
        {
            return this.imgsHandler;
        }

        private void radioButtonScoreBar_Yes_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radioButtonScoreBar_Yes.Checked == true)
            {
                firstOpen ++;
                if (imgsHandler.getScoreBarStatus() != true)
                {
                    //Daca nu o avem o cream
                    imgsHandler.createNewScorebar(pictureBoxScene, infoScorebar);    // crearea unui nou scorebar
                    this.scoreBar = imgsHandler.getScoreBar();
                    scoreBarStatus = true;

                }
                else
                {   //Daca o avem o afisam cu show  ---  de revenit 
                    //foreach (CustomSceneControl customControl in pictureBoxScene.Controls.OfType<CustomSceneControl>())
                    //{
                    //    if (customControl.isScoreBar() == true)
                    //    {
                    //        customControl.Show();
                    //    }
                    //}
                }
                scoreBarStatus = true;
                panelBoxNames.Enabled = true;
                panelBoxScores.Enabled = true;
                panelBoxTime.Enabled = true;
                panelScorebars.Enabled = true;
                refreshComboBox();
            }
            else 
            {
                //foreach (CustomSceneControl customControl in pictureBoxScene.Controls.OfType<CustomSceneControl>())
                //{
                //    if (customControl.isScoreBar() == true)
                //    {

                //        customControl.Hide();
                //    }
                //}
                deleteScoreBarFormEverywhere();
                scoreBarStatus = false;
                resetInputInfo();

                panelBoxNames.Enabled = false;
                panelBoxScores.Enabled = false;
                panelBoxTime.Enabled = false;
                panelScorebars.Enabled = false;
                firstOpen --;
            }
                       
        }
        public void refreshScorebarControlImgInPictureBoxList() 
        {
            foreach (CustomSceneControl customControl in pictureBoxScene.Controls.OfType<CustomSceneControl>())
            {
                if (customControl.isScoreBar() == true)
                {
                    customControl.setLogo(scoreBar.getScorbarImg());
                }
            }
        }

        private void btn_ResetTeamNames_Click(object sender, EventArgs e)
        {
            scoreBar.resetNames();
            refreshScorebarControlImgInPictureBoxList();
            tb_teamName1.Clear();
            tb_teamName2.Clear();
        }

        private void resetInputInfo() 
        {
            tb_teamName1.Text = "TeamName_1";
            tb_teamName2.Text = "TeamName_2";

            Nr_ScoreT1.Value = 0;
            Nr_ScoreT2.Value = 0;

            Nr_Minutes.Value = 0;
            Nr_Seconds.Value = 0;
        }

        private void deleteScoreBarFormEverywhere()
        {

            foreach (CustomSceneControl customControl in pictureBoxScene.Controls.OfType<CustomSceneControl>())
            {
                if (customControl.isScoreBar())
                {
                    
                    customControl.Disp();
                    imgsHandler.deleteScorebar();
                }
            }
            this.scoreBar = null;

        }

        private void createBackUpInSceneFormForScorebarInImgsHandler() 
        {
            this.teamName = new string[2]; //0 = Team1 -- 1 = Team2 
            teamName[0] = scoreBar.getT1Name();
            teamName[1] = scoreBar.getT2Name();

            this.seconds = scoreBar.getSeconds();
            this.minutes = scoreBar.getMinutes();

            this.teamScore1 = scoreBar.getScoreT1(); 
            this.teamScore2 = scoreBar.getScoreT2();

            this.backupScorebarSizeFinalFrame = scoreBar.mainImg.getInmageRealFrameSize();
            this.backupScorebarSizeControl = scoreBar.mainImg.getInmageControlSize();
            
            this.backupScorebarLocationFinalFrame = scoreBar.mainImg.getInmageFramePoint();
            this.backupScorebarLocationControl = scoreBar.mainImg.getInmageControlPoint();
            
        }

        public void loadBackUpScoreBar() 
        {
            if (this.scoreBar != null && this.scoreBarStatus == true) 
            {
                scoreBar.resetInfoBackup(this.teamName, this.seconds, this.minutes, this.teamScore1, this.teamScore2);
                
                scoreBar.mainImg.setInmageRealFrameSize(this.backupScorebarSizeFinalFrame);
                scoreBar.mainImg.setInmageControlSize(this.backupScorebarSizeControl);

                scoreBar.mainImg.setInmageFramePoint(this.backupScorebarLocationFinalFrame);
                scoreBar.mainImg.setInmageControlPoint(this.backupScorebarLocationControl);

                imgsHandler.refreshScorbar();
            }                       
        }

        private void tb_teamName2_TextChanged(object sender, EventArgs e)
        {
            if (this.scoreBar != null) 
            {
               scoreBar.setTeamName1(tb_teamName1.Text.Trim());
               refreshScorebarControlImgInPictureBoxList(); 
            }
            
        }

        private void tb_teamName2_TextChanged_1(object sender, EventArgs e)
        {
            if (this.scoreBar != null)
            {
                scoreBar.setTeamName2(tb_teamName2.Text.Trim());
                refreshScorebarControlImgInPictureBoxList();
            }
        }

        private void Nr_ScoreT1_ValueChanged(object sender, EventArgs e)
        {
            if (this.scoreBar != null)
            {
                scoreBar.setScoreT1((int)Nr_ScoreT1.Value);
                refreshScorebarControlImgInPictureBoxList();
            }
        }

        private void Nr_ScoreT2_ValueChanged(object sender, EventArgs e)
        {
            if (this.scoreBar != null)
            {
                scoreBar.setScoreT2((int)Nr_ScoreT2.Value);
                refreshScorebarControlImgInPictureBoxList();
            }
        }

        private void Nr_Minutes_ValueChanged(object sender, EventArgs e)
        {
            if (this.scoreBar != null)
            {
                scoreBar.setMinutes((int)Nr_Minutes.Value);
                refreshScorebarControlImgInPictureBoxList();
            }
        }

        private void Nr_Seconds_ValueChanged(object sender, EventArgs e)
        {
            if (this.scoreBar != null)
            {
                scoreBar.setSeconds((int)Nr_Seconds.Value);
                refreshScorebarControlImgInPictureBoxList();
            }
        }

        private void btn_ResetScore_Click(object sender, EventArgs e)
        {
            scoreBar.ResetScore();
            refreshScorebarControlImgInPictureBoxList();
            Nr_ScoreT1.ResetText();
            Nr_ScoreT2.ResetText();            
        }

        private void btn_SetTime_Click(object sender, EventArgs e)
        {
            scoreBar.ResetTime();
            refreshScorebarControlImgInPictureBoxList();
            Nr_Minutes.ResetText();
            Nr_Seconds.ResetText();
        }

        public bool getScoreBarStatus()
        {
            return this.scoreBarStatus;
        }                

        public void loadBackupListsFromSceneFormToImgsHandler() 
        {
            imgsHandler.loadBackupLists(this.backupFinalImgList, this.backupControlList);
            imgsHandler.setIndexID(this.backupID);
            
        }

        private void createBackupForLists() 
        {
            this.backupID = imgsHandler.getIndexIDs();

            if (imgsHandler.getNrImgs() > 0)
            {
                this.backupFinalImgList = imgsHandler.getFrameImgListDeepCopy();
            }
            else 
            {
                this.backupFinalImgList = null;
            }

            if (imgsHandler.getFrameCtrNr() > 0)
            {
                this.backupControlList = imgsHandler.getControlListDeepCopy();
            }
            else 
            {
                this.backupControlList = null;
            }            
        }

        public void deleteListsFromImgsHandler()
        {
            if (this.backupFinalImgList == null && this.backupControlList == null)
            {
                imgsHandler.deleteAllFromLists();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            firstOpen++;
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_newScoreBar_Click(object sender, EventArgs e)
        {
            var scorebarForm = new NewScorebarForm(imgsHandler);
            if (scorebarForm.ShowDialog() == DialogResult.OK)
            {
                //this.scorebarList.Add(scorebarForm.createNewInfoScorebar());               
                //comboBoxScoreBars.Items.Add(scorebarForm.createNewInfoScorebar().ToString());
                refreshComboBox();
                
            }          

        }

        private void refreshComboBox()
        {
            comboBoxScoreBars.Items.Clear();

            this.listInfoScorebar = main.loadInfoScorebars();

            foreach (infoScorebar info in this.listInfoScorebar)
            {               
                comboBoxScoreBars.Items.Add(info.ToString());
            }
        }

        private void comboBoxScoreBars_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int selectedIndex = comboBoxScoreBars.SelectedIndex;
                       
            this.scoreBar.updateInfoScorebar(listInfoScorebar[selectedIndex]);    
            this.scoreBar = imgsHandler.getScoreBar();
            
            //deleteScoreBarFormEverywhere();
            //imgsHandler.createNewScorebar(pictureBoxScene, scorebarList[selectedIndex]);
            //this.scoreBar = imgsHandler.getScoreBar();
            //scoreBarStatus = true;

            refreshScorebarControlImgInPictureBoxList();
            this.scoreBar.displayNewImage();
            btn_DeleteScorebar.Enabled = true;
        }

        private void btn_DeleteScorebar_Click(object sender, EventArgs e)
        {
            int Index = comboBoxScoreBars.SelectedIndex;
            int ID = listInfoScorebar[Index].Id;

            try
            {
                string query = " DELETE FROM infoScorebars WHERE ID = @ID; ";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    int RowsMod = command.ExecuteNonQuery();

                    refreshComboBox();
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString(), "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (comboBoxScoreBars.Items.Count > 0)
            {
                comboBoxScoreBars.SelectedIndex = 0;
            }
            else 
            {
                comboBoxScoreBars.Items.Clear();
                radioButtonScoreBar_No.Checked = true;
            }
        }













        //private void initScorebarMokuit()
        //{
        //    this.infoScorebarMokuit = new infoScorebar("Default Scorebar", this.scorebarList[0].Img,
        //                                                 new PointF((float)17.5, (float)48),   //Tname1
        //                                                 new PointF((float)83, (float)48),   //Tname2
        //                                                 new PointF((float)35.5, (float)32),   //Score1
        //                                                 new PointF((float)64.3, (float)32),   //Score2
        //                                                 new PointF((float)50.3, (float)30.0),   //Time
        //                                                 "Tahoma", //Name
        //                                                 "Impact", //Score
        //                                                 "Tahoma", //Time
        //                                                 "WhiteSmoke",    //Name
        //                                                 "MediumTurquoise",    //Score
        //                                                 "WhiteSmoke",    //Time
        //                                                 14,      //Name  
        //                                                 23,      //Score
        //                                                 18       //Time
        //                                                 );
        //}


    }
}

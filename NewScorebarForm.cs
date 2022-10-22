using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public partial class NewScorebarForm : Form
    {
        string scorebarName;
        private const string connectionString = "DataSource = Database.db";
        ImgsHandler imgsHandler;
        bool haveScorebarImg = false;

        static int fontSize = 24;
        static int fontSizeScore = 32;

        CustomLabel labelTeamName1;
        CustomLabel labelScoreT1;
        
        CustomLabel labelTeamName2;
        CustomLabel labelScoreT2;

        CustomLabel labelTime;

        //infoScorebar infoScorebarMokuit;
        public byte[] contentImg { get; set; }

        public infoScorebar createNewInfoScorebar() 
        {
            Size scorBarSize = pictureBoxNewScorebar.Controls[0].Size;

            List<PointF> pointList = new List<PointF>(); // lista efectiva de point procentaj

            var ctrList = pictureBoxNewScorebar.Controls[0].Controls; //lista de labels: nume score time...

            foreach (CustomLabel ctr in pictureBoxNewScorebar.Controls[0].Controls) 
            {
                float Xaux = ctr.Location.X + ctr.Size.Width / 2;
                float Yaux = ctr.Location.Y + ctr.Size.Height / 2;

                PointF point = new PointF((Xaux/scorBarSize.Width) *100, (Yaux/scorBarSize.Height) *100);
                //PointF point = new PointF(Xaux, Yaux);
                
                pointList.Add(point);
            }
            CustomScorebarControl control = (CustomScorebarControl)pictureBoxNewScorebar.Controls[0];
            Bitmap logo = new Bitmap((Image)control.getLogo(), new Size(control.Size.Width, control.Size.Height));
                        
            return new infoScorebar(tb_ScorebarName.Text.Trim(), logo,
                                                         pointList[0],   //Tname1
                                                         pointList[1],   //Tname2
                                                         pointList[2],   //Score1
                                                         pointList[3],   //Score2
                                                         pointList[4],   //Time
                                                         labelTeamName1.getFont(), //Name
                                                         labelScoreT1.getFont(), //Score
                                                         labelTime.getFont(), //Time
                                                         labelTeamName1.getColor(),    //Name
                                                         labelScoreT1.getColor(),    //Score
                                                         labelTime.getColor(),    //Time
                                                         labelTeamName1.getFontSize() ,      //Name   +4 prova
                                                         labelScoreT1.getFontSize() ,      //Score    +4
                                                         labelTime.getFontSize()       //Time         +4
                                                         );

        }

        

       

        public NewScorebarForm(ImgsHandler imgsHandler)
        {
            InitializeComponent();
            this.imgsHandler = imgsHandler;
        }
        
        private void NewScorebarForm_Load(object sender, EventArgs e)
        {
            pictureBoxNewScorebar.AllowDrop = true;
            addColorsToCmbs();
            addFontToCmbx();

            createNameTimeScoreControl();         

        }

        public void addNamesTimeScoreControlsToScorebarImgControl()
        {
            Control ScorBarControl = pictureBoxNewScorebar.Controls[0];
                        
            ScorBarControl.Controls.Add(labelTeamName1);                        
            ScorBarControl.Controls.Add(labelTeamName2);
            ScorBarControl.Controls.Add(labelScoreT1);
            ScorBarControl.Controls.Add(labelScoreT2);
            ScorBarControl.Controls.Add(labelTime);

            SetCmbxsDefaultValues();
        }

        public void createNameTimeScoreControl() 
        {
            this.labelTeamName1 = new CustomLabel("TeamName_1", fontSize);
            labelTeamName1.Show();
            labelTeamName1.Size = new Size(178, 33);
            labelTeamName1.Location = new Point(30, 67);

            this.labelScoreT1 = new CustomLabel("0", fontSizeScore);
            labelScoreT1.Show();
            labelScoreT1.Size = new Size(32, 41);
            labelScoreT1.Location = new Point(238, 67);

            this.labelTeamName2 = new CustomLabel("TeamName_2", fontSize);
            labelTeamName2.Show();
            labelTeamName2.Size = new Size(178, 33);
            labelTeamName2.Location = new Point(510, 67);

            this.labelScoreT2 = new CustomLabel("0", fontSizeScore);
            labelScoreT2.Show();
            labelScoreT2.Size = new Size(32, 41);
            labelScoreT2.Location = new Point(718, 67);

            this.labelTime = new CustomLabel("00:00", fontSize);
            labelTime.Show();
            labelTime.Size = new Size(75, 33);
            labelTime.Location = new Point(355, 67);

        }




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }                

        private void cbx_namesFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawItemInCbxs(sender, e);
        }

        private void cbx_scoreFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawItemInCbxs(sender, e);
        }

        private void cbx_timeFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawItemInCbxs(sender, e);
        }

        private void addFontToCmbx() 
        {
            foreach (FontFamily font in FontFamily.Families) 
            {
                this.cbx_namesFont.Items.Add(font.Name.ToString());
                this.cbx_timeFont.Items.Add(font.Name.ToString());
                this.cbx_scoreFont.Items.Add(font.Name.ToString());
            }
        }

        private void SetCmbxsDefaultValues()
        {
            var listFont = this.cbx_namesFont.Items.Cast<string>().ToList();
            var listColor = this.cbx_namesFontColor.Items.Cast<string>().ToList();

            this.cbx_namesFont.SelectedIndex = listFont.FindIndex(c => c.StartsWith("Arial"));
            this.cbx_scoreFont.SelectedIndex = listFont.FindIndex(c => c.StartsWith("Arial"));
            this.cbx_timeFont.SelectedIndex = listFont.FindIndex(c => c.StartsWith("Arial"));

            this.cbx_namesFontColor.SelectedIndex = listColor.FindIndex(c => c.StartsWith("Blue"));
            this.cbx_scoreFontColor.SelectedIndex = listColor.FindIndex(c => c.StartsWith("Blue"));
            this.cbx_timeFontColor.SelectedIndex = listColor.FindIndex(c => c.StartsWith("Blue"));

            this.nr_namesFontSize.Value = fontSize;
            this.nr_scoreFontSize.Value = fontSizeScore;
            this.nr_timeFontSize.Value = fontSize;

        }


        private void addColorsToCmbs() 
        {
            ArrayList ColorList = new ArrayList();
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static |
                                          BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.cbx_namesFontColor.Items.Add(c.Name);
                this.cbx_scoreFontColor.Items.Add(c.Name);
                this.cbx_timeFontColor.Items.Add(c.Name);
            }
        }

        private void drawItemInCbxs(object sender, DrawItemEventArgs e) 
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Gainsboro, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IconInfo tmp = new IconInfo();
            GetIconInfo(bmp.GetHicon(), ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            return new Cursor(CreateIconIndirect(ref tmp));
        }


        private void pictureBoxNewScorebar_DragEnter(object sender, DragEventArgs e)
        {

            if (!haveScorebarImg)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else 
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBoxNewScorebar_DragDrop(object sender, DragEventArgs e)
        {
            if (!haveScorebarImg) 
            {
                pictureBoxNewScorebar.Image = Properties.Resources.trsPat;
                
                imgsHandler.dragDropNewScorebar(sender, e, pictureBoxNewScorebar);
                haveScorebarImg = true;
                
                addNamesTimeScoreControlsToScorebarImgControl();
                btn_Reset.Enabled = true;
            }
            
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            imgsHandler.resetScorebarControls();
            pictureBoxNewScorebar.Controls.Clear();
            haveScorebarImg = false;
            pictureBoxNewScorebar.Image = Properties.Resources.DragAndDropImg;
            btn_Reset.Enabled = false;
            btn_saveScorebar.Enabled = false;
        }

        private void cbx_namesFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fName = (string)((ComboBox)sender).SelectedItem;

            labelTeamName1.changeFontName(fName);
            labelTeamName2.changeFontName(fName);

        }

        private void cbx_scoreFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fName = (string)((ComboBox)sender).SelectedItem;

            labelScoreT1.changeFontName(fName);
            labelScoreT2.changeFontName(fName);
        }

        private void cbx_timeFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fName = (string)((ComboBox)sender).SelectedItem;
            labelTime.changeFontName(fName);
        }

        private void cbx_namesFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontColorName = (string)((ComboBox)sender).SelectedItem;
            labelTeamName1.changeFontColor(fontColorName);
            labelTeamName2.changeFontColor(fontColorName);
        }

        private void cbx_scoreFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontColorName = (string)((ComboBox)sender).SelectedItem;
            labelScoreT1.changeFontColor(fontColorName);
            labelScoreT2.changeFontColor(fontColorName);
        }

        private void cbx_timeFontColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontColorName = (string)((ComboBox)sender).SelectedItem;
            labelTime.changeFontColor(fontColorName);
        }

        private void nr_namesFontSize_ValueChanged(object sender, EventArgs e)
        {
            labelTeamName1.changeFontSize(((int)nr_namesFontSize.Value));
            labelTeamName2.changeFontSize(((int)nr_namesFontSize.Value));
        }

        private void nr_scoreFontSize_ValueChanged(object sender, EventArgs e)
        {
            labelScoreT1.changeFontSize(((int)nr_scoreFontSize.Value));
            labelScoreT2.changeFontSize(((int)nr_scoreFontSize.Value));
        }

        private void nr_timeFontSize_ValueChanged(object sender, EventArgs e)
        {
            labelTime.changeFontSize(((int)nr_timeFontSize.Value));
            
        }

        private void btn_alignNamesHorizontally_Click(object sender, EventArgs e)
        {
            labelTeamName2.setYLocation(labelTeamName1.getYLocation());
        }

        private void btn_alignScoresHorizontally_Click(object sender, EventArgs e)
        {
            labelScoreT2.setYLocation(labelScoreT1.getYLocation());
        }

        private void btn_centerTheTime_Click(object sender, EventArgs e)
        {
            labelTime.setXLocation(this.Width/2 - labelTime.Width/2);
        }        

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();

        }        

        private void tb_teamName1_TextChanged(object sender, EventArgs e)
        {
            if (tb_ScorebarName.Text.Trim().Length > 3)
            {
                
                if (btn_Reset.Enabled) 
                {                    
                    btn_saveScorebar.Enabled = true;
                }
            }
            else 
            {
                btn_OK.Enabled = false;
                btn_saveScorebar.Enabled = false;
            }

            this.scorebarName = tb_ScorebarName.Text.Trim();
        }


        private void btn_saveScorebar_Click(object sender, EventArgs e)
        {
            btn_OK.Enabled = true;
            addToDatabase(createNewInfoScorebar());
        }

        private void addToDatabase(infoScorebar info) 
        {
            if (tb_ScorebarName.Text.Trim().Length > 3)
            {
                contentImg = ImageToByteArray(info.Img);


                var query = "INSERT INTO InfoScorebars(name, img, team1NameX, team1NameY, team2NameX, team2NameY, scoreTeam1X, scoreTeam1Y, scoreTeam2X, scoreTeam2Y, timeX, timeY, fontTeamNames, fontScores, fontTime, colorTeamNames, colorScores, colorTime, fontSizeTeamNames, fontSizeScores, fontSizeTime) " +
                            " VALUES (@name, @img, @team1NameX, @team1NameY, @team2NameX, @team2NameY, @scoreTeam1X, @scoreTeam1Y, @scoreTeam2X, @scoreTeam2Y, @timeX, @timeY, @fontTeamNames, @fontScores, @fontTime, @colorTeamNames, @colorScores, @colorTime, @fontSizeTeamNames, @fontSizeScores, @fontSizeTime); ";
                
                using (var connection = new SQLiteConnection(connectionString))
                {
                    var command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("@name", info.ScorebarName);
                    command.Parameters.AddWithValue("@img", contentImg);
                    command.Parameters.AddWithValue("@team1NameX", info.PrcLocationTeamName1.X);
                    command.Parameters.AddWithValue("@team1NameY", info.PrcLocationTeamName1.Y);
                    command.Parameters.AddWithValue("@team2NameX", info.PrcLocationTeamName2.X);
                    command.Parameters.AddWithValue("@team2NameY", info.PrcLocationTeamName2.Y);
                    command.Parameters.AddWithValue("@scoreTeam1X", info.PrcLocationScoreTeam1.X);
                    command.Parameters.AddWithValue("@scoreTeam1Y", info.PrcLocationScoreTeam1.Y);
                    command.Parameters.AddWithValue("@scoreTeam2X", info.PrcLocationScoreTeam2.X);
                    command.Parameters.AddWithValue("@scoreTeam2Y", info.PrcLocationScoreTeam2.Y);
                    command.Parameters.AddWithValue("@timeX", info.PrcLocationTime.X);
                    command.Parameters.AddWithValue("@timeY", info.PrcLocationTime.Y);
                    command.Parameters.AddWithValue("@fontTeamNames", info.FontTeamNames);
                    command.Parameters.AddWithValue("@fontScores", info.FontScores);
                    command.Parameters.AddWithValue("@fontTime", info.FontTime);
                    command.Parameters.AddWithValue("@colorTeamNames", info.ColorTeamNames);
                    command.Parameters.AddWithValue("@colorScores", info.ColorScores);
                    command.Parameters.AddWithValue("@colorTime", info.ColorTime);
                    command.Parameters.AddWithValue("@fontSizeTeamNames", info.SizeTeamName);
                    command.Parameters.AddWithValue("@fontSizeScores", info.SizesScores);
                    command.Parameters.AddWithValue("@fontSizeTime", info.SizeTime);

                    connection.Open();
                    
                    try
                    {
                        int Rows = command.ExecuteNonQuery();
                                                
                        MessageBox.Show("The item has been added.", "Item Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show("Please insert a new name", "Add item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Too short name (the name must have more than 3 letters)", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);

                return ms.ToArray();
            }
        }


    }
}

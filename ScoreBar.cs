using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class ScoreBar
    {
        public  Inmage mainImg;
        private Bitmap scoreBarImg;   
        private Bitmap newImg;
        private Timer timer;

        private ImgsHandler imgsHandler;
        private ImgsOverlayer imgsOverlayer;

        private int teamScore1 = 0;   //aici de adaugat ce scrie in forms sau reset in forms 
        private int teamScore2 = 0; 
        private string teamName1 = "TeamName_1";
        private string teamName2 = "TeamName_2";
        private int seconds = 0;
        private int minutes = 0;

        // Satic Locations Float Point
        private PointF fLocationTeamName1;
        private PointF fLocationTeamName2;
        private PointF fLocationScoreTeam1;
        private PointF fLocationScoreTeam2;
        private PointF fLocationTime;

        // Final Locations
        private Point locationTeamName1;
        private Point locationTeamName2;
        private Point locationScoreTeam1;
        private Point locationScoreTeam2;
        private Point locationTime;
        
        // Font
        private string fontTeamNames;
        private string fontScores;
        private string fontTime;

        // Color
        private Brush colorTeamNames;
        private Brush colorScores;
        private Brush colorTime;

        // Size
        private int sizeTeamName;
        private int sizesScores;
        private int sizeTime;



        public ScoreBar(Timer timer, ImgsHandler imgsHandler, ImgsOverlayer imgsOverlayer, infoScorebar defaultInfoScorebar) 
        {
            
            this.imgsHandler = imgsHandler;
            this.imgsOverlayer = imgsOverlayer;
            this.timer = timer;
            timer.Tick += Timer_Tick;
           
            this.scoreBarImg = Properties.Resources.ScoreBar;

            this.fLocationTeamName1 = defaultInfoScorebar.PrcLocationTeamName1;
            this.fLocationTeamName2 = defaultInfoScorebar.PrcLocationTeamName2;
            this.fLocationScoreTeam1 = defaultInfoScorebar.PrcLocationScoreTeam1;
            this.fLocationScoreTeam2 = defaultInfoScorebar.PrcLocationScoreTeam2;
            this.fLocationTime = defaultInfoScorebar.PrcLocationTime;
            
            this.fontTeamNames = defaultInfoScorebar.FontTeamNames;
            this.fontScores = defaultInfoScorebar.FontScores;
            this.fontTime = defaultInfoScorebar.FontTime;
            
            this.colorTeamNames = new SolidBrush(Color.FromName(defaultInfoScorebar.ColorTeamNames));
            this.colorScores = new SolidBrush(Color.FromName(defaultInfoScorebar.ColorScores)); 
            this.colorTime = new SolidBrush(Color.FromName(defaultInfoScorebar.ColorTime)); 
            
            this.sizeTeamName = defaultInfoScorebar.SizeTeamName;
            this.sizesScores = defaultInfoScorebar.SizesScores;
            this.sizeTime = defaultInfoScorebar.SizeTime;
            
            setLocation(defaultInfoScorebar);
            
            generateNewImg();            
        }
        

        public void generateNewImg() 
        {
            newImg = new Bitmap(scoreBarImg); 
            Graphics g = Graphics.FromImage(newImg);

            g.DrawString($"{this.teamName1}", new Font(this.fontTeamNames, this.sizeTeamName), this.colorTeamNames, this.locationTeamName1);
            g.DrawString($"{this.teamName2}", new Font(this.fontTeamNames, this.sizeTeamName), this.colorTeamNames, this.locationTeamName2);

            g.DrawString($"{this.teamScore1}", new Font(this.fontScores, this.sizesScores), this.colorScores, this.locationScoreTeam1);
            g.DrawString($"{this.teamScore2}", new Font(this.fontScores, this.sizesScores), this.colorScores, this.locationScoreTeam2);           

            g.DrawString($"{GetTime(minutes)}:{GetTime(seconds)}", new Font(this.fontTime, this.sizeTime), this.colorTime, this.locationTime);
           
            g.Flush();
            g.Dispose();
            GC.Collect();

            
        }

        private void setLocation(infoScorebar defaultInfoScorebar) 
        {
            this.locationTeamName1 = getCenterLocation(this.fLocationTeamName1, this.teamName1, this.fontTeamNames, this.sizeTeamName);
            this.locationTeamName2 = getCenterLocation(this.fLocationTeamName2, this.teamName2, this.fontTeamNames, this.sizeTeamName);
            
            this.locationScoreTeam1 = getCenterLocation(this.fLocationScoreTeam1, this.teamScore1.ToString(), this.fontScores, this.sizesScores);
            this.locationScoreTeam2 = getCenterLocation(this.fLocationScoreTeam2, this.teamScore2.ToString(), this.fontScores, this.sizesScores);

            this.locationTime = getCenterLocation(this.fLocationTime, $"{GetTime(minutes)}:{GetTime(seconds)}", this.fontTime, this.sizeTime);
        
        }

        private Point getCenterLocation(PointF startPoint, string _string, string font, int size) 
        {
            Point result = new Point(0, 0);
            
            SizeF Fsize = new SizeF();
            using (var imageBuffer = new Bitmap(350, 150))
            {
                using (var graphics = Graphics.FromImage(imageBuffer))
                {
                    Fsize = graphics.MeasureString(_string, new Font(font, size));
                }
            }

            float realX = this.scoreBarImg.Width * startPoint.X / 100;           
            float realY = this.scoreBarImg.Height * startPoint.Y / 100; 

            result.X = (int)(realX - Fsize.Width / 2);
            result.Y = (int)(realY - Fsize.Height / 2);
            
            return result;
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            
            if (seconds > 59)
            {
                minutes++;
                seconds = 0;
            }

            displayNewImage();
        }


        private string GetTime(double str)
        {
            if (str <= 9)
            {
                return "0" + str;
            }
            else
            {
                return str.ToString();
            }
        }
        public void refreshImg()
        {
            mainImg.setInmagePngImg(this.newImg);
            imgsOverlayer.updateImgScorebar(this.newImg);
        }      

        

        public void scorePlusT1() 
        {
            this.teamScore1++;

            this.locationScoreTeam1 = getCenterLocation(this.fLocationScoreTeam1, this.teamScore1.ToString(), this.fontScores, this.sizesScores);

            displayNewImage();
        }

        public void scorePlusT2()
        {
            this.teamScore2++;

            this.locationScoreTeam2 = getCenterLocation(this.fLocationScoreTeam2, this.teamScore2.ToString(), this.fontScores, this.sizesScores);

            displayNewImage();
        }

        public void scoreMinusT1() 
        {
            if (this.teamScore1 > 0) 
            {
                this.teamScore1--;

                this.locationScoreTeam1 = getCenterLocation(this.fLocationScoreTeam1, this.teamScore1.ToString(), this.fontScores, this.sizesScores);

                displayNewImage();
            }            
        }

        public void scoreMinusT2()
        {
            if (this.teamScore2 > 0)
            {
                this.teamScore2--;

                this.locationScoreTeam2 = getCenterLocation(this.fLocationScoreTeam2, this.teamScore2.ToString(), this.fontScores, this.sizesScores);

                displayNewImage();
            }
        }        

        public void setTeamName1(string TeamName)
        {
            this.teamName1 = TeamName;

            this.locationTeamName1 = getCenterLocation(this.fLocationTeamName1, this.teamName1, this.fontTeamNames, this.sizeTeamName);

            displayNewImage();
        }

        public void setTeamName2(string TeamName)
        {
            this.teamName2 = TeamName;

            this.locationTeamName2 = getCenterLocation(this.fLocationTeamName2, this.teamName2, this.fontTeamNames, this.sizeTeamName);

            displayNewImage();
        }

       
        public void resetInfoBackup(string[] teamName, int seconds, int minutes, int Teamscore1, int TeamScore2) 
        {
            if (imgsHandler.getScoreBarStatus() == true) 
            {
                this.teamName1 = teamName[0];
                this.teamName2 = teamName[1];

                this.seconds = seconds;
                this.minutes = minutes;

                this.teamScore1 = Teamscore1;
                this.teamScore2 = TeamScore2;

                displayNewImage();
            }            
        }

        

        public void setScoreT1(int score)
        {
            this.teamScore1 = score;
            this.locationScoreTeam1 = getCenterLocation(this.fLocationScoreTeam1, this.teamScore1.ToString(), this.fontScores, this.sizesScores);
            displayNewImage();
        }

        public void setScoreT2(int score)
        {
            this.teamScore2 = score;
            this.locationScoreTeam2 = getCenterLocation(this.fLocationScoreTeam2, this.teamScore2.ToString(), this.fontScores, this.sizesScores);
            displayNewImage();
        }


        private void msgBox()
        {
            MessageBox.Show("TeamName1 : " + this.locationTeamName1.ToString() + ".\n" +
                           "TeamName2 : " + this.locationTeamName2.ToString() + ".\n\n" +
                           "TeamScore1: " + this.locationScoreTeam1.ToString() + ".\n" +
                           "TeamScore2: " + this.locationScoreTeam2.ToString() + ".\n\n" +
                           "Time      : " + this.locationTime.ToString() + ".\n" +
                           "Ctr Size  : " + this.scoreBarImg.Size.ToString() + ".");
        }

        public void updateInfoScorebar(infoScorebar newInfoScorebar) 
        {
            this.scoreBarImg = newInfoScorebar.Img;

            this.fLocationTeamName1 = newInfoScorebar.PrcLocationTeamName1;
            this.fLocationTeamName2 = newInfoScorebar.PrcLocationTeamName2;
            this.fLocationScoreTeam1 = newInfoScorebar.PrcLocationScoreTeam1;
            this.fLocationScoreTeam2 = newInfoScorebar.PrcLocationScoreTeam2;
            this.fLocationTime = newInfoScorebar.PrcLocationTime;

            this.fontTeamNames = newInfoScorebar.FontTeamNames;
            this.fontScores = newInfoScorebar.FontScores;
            this.fontTime = newInfoScorebar.FontTime;

            this.colorTeamNames = new SolidBrush(Color.FromName(newInfoScorebar.ColorTeamNames));
            this.colorScores = new SolidBrush(Color.FromName(newInfoScorebar.ColorScores));
            this.colorTime = new SolidBrush(Color.FromName(newInfoScorebar.ColorTime));

            this.sizeTeamName = newInfoScorebar.SizeTeamName;
            this.sizesScores = newInfoScorebar.SizesScores;
            this.sizeTime = newInfoScorebar.SizeTime;

            setLocation(newInfoScorebar);

            generateNewImg();
        }




        public void Dispose()
        {
            this.mainImg.disposeInmagePngImg();
            this.mainImg = null;
            scoreBarImg.Dispose();
            this.newImg = null;
        }


        public void displayNewImage()
        {
            generateNewImg();
            this.imgsHandler.refreshScorbar();
        }

        public void ResetTime()
        {
            seconds = minutes = 0;
            displayNewImage();
        }

        public void ResetScore()
        {
            this.teamScore1 = 0;
            this.teamScore2 = 0;

            displayNewImage();
        }

        public void resetNames()
        {
            this.teamName1 = "";
            this.teamName2 = "";
            displayNewImage();
        }


        public Inmage getInmageScorePoints()
        {
            return mainImg;
        }

        public void setInmageSizePoints(Inmage img)
        {
            this.mainImg = img;
        }

        public int getSeconds()
        {
            return this.seconds;
        }

        public int getMinutes()
        {
            return this.minutes;
        }

        public int getScoreT1()
        {
            return this.teamScore1;
        }

        public int getScoreT2()
        {
            return this.teamScore2;
        }

        public string getT1Name()
        {
            return this.teamName1;
        }

        public string getT2Name()
        {
            return this.teamName2;
        }

        public void setMinutes(int min)
        {
            this.minutes = min;
            displayNewImage();
        }

        public void setSeconds(int sec)
        {
            this.seconds = sec;
            displayNewImage();
        }

        public Bitmap getScorbarImg()
        {
            return newImg;
        }

        public Bitmap getFinalImg()
        {
            return mainImg.getInmagePngImg();
        }

        
    }
}

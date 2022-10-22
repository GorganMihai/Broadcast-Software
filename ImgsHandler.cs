using Accord.IO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class ImgsHandler
    {
        private ScoreBar scoreBar;
        private bool scoreBarStatus;
        
        //private FrameControl Control { get; set; }
        private List<CustomSceneControl> ControlList { get; set; }
        private List<Inmage> finalFrameImgList { get; set; }
        private Inmage imgScorebar = null;

        private int indexIDs;
                
        private Timer timer;
        private ImgsOverlayer imgsOverlayer;

        private Size realFrameSize;
        private Size pictureBoxSizeScene;
        private Size pictureBoxNewScorebarSize;


        public ImgsHandler(Timer timer, ImgsOverlayer imgsOverlayer)
        {
            this.imgsOverlayer = imgsOverlayer;

            finalFrameImgList = new List<Inmage>();
            
            ControlList = new List<CustomSceneControl>();
            
            this.timer = timer;            
            
            scoreBarStatus = false;

            this.pictureBoxNewScorebarSize = new Size(780, 165);
            
            indexIDs = 0;            
        }


        // Din dragDrop init inmagine adaugare in lista de img si creare control peste pictureBox
        public void dragDrop(object sender, DragEventArgs ev, PictureBox pictureBoxMain)
        {
            var data = ev.Data.GetData(DataFormats.FileDrop);
            var file = data as string[];
            Bitmap Logo = new Bitmap(Image.FromFile(file[0]));

            if (file.Length > 0)
            {
                var percentLocation = getPercentLocation((Point)pictureBoxMain.PointToClient(Cursor.Position), pictureBoxMain); //locatia a cursorului in procentaje

                var img = new Inmage(
                    indexIDs,
                    Logo,
                    SetSize(realFrameSize, Logo.Size), //backround
                    SetSize(pictureBoxSizeScene, Logo.Size), //control
                    setPoint(percentLocation, realFrameSize, SetSize(realFrameSize, Logo.Size)), //BackgroundPoint
                    setPoint(percentLocation, pictureBoxSizeScene, SetSize(pictureBoxSizeScene, Logo.Size)) //controlpoint
                    );
                indexIDs++;
                finalFrameImgList.Add(img);

                CustomSceneControl Control = new CustomSceneControl(Logo, img.getInmageID(), pictureBoxMain, realFrameSize, finalFrameImgList, this);
                Control.Show();
                Control.Size = img.getInmageControlSize();
                Control.Location = img.getInmageControlPoint();
                
                pictureBoxMain.Controls.Add(Control);
                ControlList.Add(Control);
            }
            else
            {
                MessageBox.Show("Eroare File.Lenght", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void dragDropNewScorebar(object sender, DragEventArgs ev, PictureBox pictureBoxNewScorebar)
        {
            var data = ev.Data.GetData(DataFormats.FileDrop);
            var file = data as string[];
            
            Bitmap logo = new Bitmap(Image.FromFile(file[0]));

            if (file.Length > 0)
            {
                var percentLocation = getPercentLocation((Point)pictureBoxNewScorebar.PointToClient(Cursor.Position), pictureBoxNewScorebar); //locatia a cursorului in procentaje

                var scoreBarImg = new Inmage
                (
                    indexIDs,
                    logo,
                    SetSize(realFrameSize, logo.Size), //backround
                    SetSize(pictureBoxSizeScene, logo.Size), //pentru pictureBoxScene 
                    SetControlNewScorebarSize(pictureBoxNewScorebarSize, logo.Size),
                    setPoint(percentLocation, realFrameSize, SetSize(realFrameSize, logo.Size)), //BackgroundPoint
                    setPoint(percentLocation, pictureBoxNewScorebarSize, SetSize(pictureBoxNewScorebarSize, logo.Size)) //controlpoint
                );
                this.imgScorebar = scoreBarImg;


                CustomScorebarControl Control = new CustomScorebarControl(logo, scoreBarImg.getInmageID(), pictureBoxNewScorebar, realFrameSize, finalFrameImgList, this);
                Control.Show();
                Control.Size = scoreBarImg.getInmageControlNewScorebarSize();
                Control.Location = scoreBarImg.centerTheImgControl(pictureBoxNewScorebarSize);
                pictureBoxNewScorebar.Controls.Add(Control);
                
            }
            else
            {
                MessageBox.Show("Eroare File.Lenght", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

       




        // Sterge elementul din liste
        public void removeElement(int index)
        {
            //finalFrameImgList[index].disposeInmagePngImg();
            ControlList[index].Disp();

            finalFrameImgList.RemoveAt(index);
            ControlList.RemoveAt(index);
            // la creare img scorebar trebie sa folosesc un id non hardcodat !!!!!!!!!!
            indexIDs--;
            //MessageBox.Show("ID: " + indexIDs);
            for (int i = 0; i < indexIDs; i++)
            {
               finalFrameImgList[i].setInmageID(i);
               ControlList[i].setID(i);
            }                   
        }

        internal void resetScorebarControls()
        {
            this.imgScorebar = null;            
        }


        // nu ma folosesc de asta
        //private Bitmap GetLogoLayer() //Scrive sul layer che andra sopvrappos
        //{
        //    if (ImgList.Count > 0)
        //    {
        //        Bitmap LayerLogo = new Bitmap(BackgroundSize.Width, BackgroundSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //        LayerLogo.MakeTransparent();

        //        Graphics g = Graphics.FromImage(LayerLogo);
        //        foreach (var i in ImgList)
        //        {
        //            if (i.GetId() != -1)
        //            {
        //                g.DrawImage(i.getinmage(), i.getBackgroundPoint().X, i.getBackgroundPoint().Y, i.getBackgroundSize().Width, i.getBackgroundSize().Height);
        //            }
        //        }

        //        g.Dispose();
        //        GC.Collect();
        //        return LayerLogo;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        //public void setNewScorebarLayer() 
        //{
        //    if (ScoreBarStatus == true)
        //    {

        //        var ScorebarLayer = new Bitmap(BackgroundSize.Width, BackgroundSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        //        ScorebarLayer.MakeTransparent();

        //        Graphics g = Graphics.FromImage(ScorebarLayer);

        //        var i = ScoreBarClass.getInmageScorePoints();
        //        g.DrawImage(i.getinmage(), i.getBackgroundPoint().X, i.getBackgroundPoint().Y, i.getBackgroundSize().Width, i.getBackgroundSize().Height);

        //        g.Dispose();
        //        GC.Collect();

        //        this.ScoreBarLayer = ScorebarLayer;
        //    }
        //    else 
        //    {
        //        this.ScoreBarLayer = null;
        //    }

        //}


        public void displayAllControlsOnPictureBox(PictureBox picBox)
        {
            //if (ScoreBarStatus == true)
            //{
            //    //forse var img inutile puoi usare ScorebarClass dappertutto
            //    var img = ScoreBarClass.getInmageScorePoints();
            //    FrameControl Control = new FrameControl(ScoreBarClass.getScorbarImg(), img.GetId(), picBox, BackgroundSize, ImgList, this);
            //    Control.Show();
            //    Control.Size = img.getControlSize();
            //    Control.Location = img.getControlPoint();
            //    picBox.Controls.Add(Control);
            //}

            if (ControlList.Count > 0)
            {
                foreach (CustomSceneControl frameControl in ControlList)
                {
                    picBox.Controls.Add(frameControl);
                }
            }
        }

        public void createNewScorebar(PictureBox pictureBoxScene, infoScorebar infoScorebar)
        {
            scoreBar = new ScoreBar(timer, this, imgsOverlayer, infoScorebar);
            scoreBarStatus = true;
            var percentLocation = getPercentLocation(new Point(pictureBoxScene.Width / 2, pictureBoxScene.Location.Y + 20), pictureBoxScene); //Scorebar point
            Bitmap scorebarImg = new Bitmap(scoreBar.getScorbarImg());
            
            Inmage img = new Inmage(
                indexIDs,
                scoreBar.getScorbarImg(),
                SetSize(realFrameSize, scorebarImg.Size),//backround
                SetSize(pictureBoxSizeScene, scorebarImg.Size),//control
                setPoint(percentLocation, realFrameSize, SetSize(realFrameSize, scorebarImg.Size)), //BackgroundPoint
                setPoint(percentLocation, pictureBoxSizeScene, SetSize(pictureBoxSizeScene, scorebarImg.Size)) //controlpoint
                );
            img.setIsScoreBar(true);
            indexIDs++;
            scoreBar.setInmageSizePoints(img);
            finalFrameImgList.Add(img);

            CustomSceneControl control = new CustomSceneControl(scorebarImg, img.getInmageID(), pictureBoxScene, realFrameSize, finalFrameImgList, this);
            control.Show();
            control.Size = img.getInmageControlSize();
            control.Location = img.getInmageControlPoint();
            control.setIsScoreBar(true);

            pictureBoxScene.Controls.Add(control);
            ControlList.Add(control);


        }

        public void setScorebarPoint(float[] percentLocation, PictureBox picBox) 
        {        
            scoreBar.getInmageScorePoints().setInmageNewLocation(
                                ImgsHandler.setPoint(percentLocation, realFrameSize, scoreBar.getInmageScorePoints().getInmageRealFrameSize()),
                                ImgsHandler.setPoint(percentLocation, picBox.Size, scoreBar.getInmageScorePoints().getInmageControlSize())
                                );
        }

        public void setScorebarSize(Size Controlsize, Size picBoxSize, Size backgrSize) 
        {
            scoreBar.getInmageScorePoints().resizeInmagePngImg(Controlsize, picBoxSize, backgrSize);
        }

        public void deleteScorebar() 
        {
            if (scoreBar != null) 
            {
                scoreBar.Dispose();
            }
            
            scoreBar = null;
            scoreBarStatus = false;
        }

       

        public void refreshScorbar()
        {
            if (scoreBarStatus == true)
            {
                scoreBar.refreshImg();
            }
            else
            {
                //this.ScoreBarLayer = null;
            }
        }

        //public Bitmap getScorebarLayer() 
        //{
        //    if (ScoreBarStatus == true)
        //    {
        //        //return this.ScoreBarLayer;
        //    }
        //    else 
        //    {
        //        //return null;
        //    }




        //    return null;

        //}



        //public List<Size> BkSize() 
        //{
        //    var list = new List<Size>();
        //    foreach (Inmage img in ImgList) 
        //    {
        //        list.Add(img.getBackgroundSize());
        //        list.Add(img.getControlSize());
        //    }
        //    return list;
        //}

        //public List<Point> BkPoint() 
        //{
        //    var list = new List<Point>();
        //    foreach (var l in ImgList)
        //    {
        //        list.Add(l.getBackgroundPoint());
        //        list.Add(l.getControlPoint());
        //    }
        //    return list;
        //}

        public void LoadSize(List<Size> list) 
        {
            int index = 0;
            foreach (Inmage img in finalFrameImgList) 
            {
                img.setInmageRealFrameSize(list[index]);
                index++;
                img.setInmageControlSize(list[index]);
                index++;
            }
        }

        public void LoadPoint(List<Point> list) 
        {
            int index = 0;
            foreach (var l in finalFrameImgList)
            {
                l.setInmageFramePoint(list[index]);
                index++;
                l.setInmageControlPoint(list[index]);
                index++;
            }
        }

        public int getNrImgs() 
        {
            if (finalFrameImgList != null)
            {
                return finalFrameImgList.Count;
            }
            else 
            {
                return 0;
            }            
        }

        public void deleteAllFromLists() 
        {
            this.ControlList.Clear();
            this.finalFrameImgList.Clear();
        }

        public int getFrameCtrNr()
        {
            if (ControlList != null)
            {
                return ControlList.Count;
            }
            else
            {
                return 0;
            }
        }

        // Attenzione imaginea nu este deep copy !!!!!!!!!!!!!!!!!!!!
        public List<Inmage> getFrameImgListDeepCopy() 
        {
            var list = new List<Inmage>();
            foreach (Inmage img in finalFrameImgList)
            {
                try 
                {       
                    list.Add(img.DeepClone());

                } catch (Exception e) 
                {
                
                }
                
            }
            //list = finalFrameImgList;
            return list;            
        }

        public List<CustomSceneControl> getControlListDeepCopy()
        {
            var list = new List<CustomSceneControl>();
            foreach (CustomSceneControl control in ControlList)
            {
                CustomSceneControl Control = new CustomSceneControl(control.getLogo(), control.GetId(), control.getPicBox(), realFrameSize, finalFrameImgList, this);                
                Control.Size = control.Size;
                Control.Location = control.Location;                
                list.Add(Control);
            }
            return list;
        }

        public void loadBackupLists(List<Inmage> backframeImglist, List<CustomSceneControl> backupControlList)
        {
            if (backframeImglist != null)
            {
                if (this.finalFrameImgList.Count > 0)
                {
                    finalFrameImgList.Clear();
                }

                foreach (var i in backframeImglist)
                {
                    this.finalFrameImgList.Add(i);
                }
            }

            if (backupControlList != null)
            {
                if (this.ControlList.Count > 0)
                {
                    ControlList.Clear();
                }

                foreach (var i in backupControlList)
                {
                    this.ControlList.Add(i);
                }
            }
        }


        //=========================================================================================================
        public ScoreBar getScoreBar()
        {
            return this.scoreBar;
        }

        public List<Inmage> getImgList()
        {
            return this.finalFrameImgList;
        }

        public int getIndexIDs()
        {
            return this.indexIDs;
        }

        public void setIndexID(int NewID)
        {
            this.indexIDs = NewID;
        }

        public string getIndexIDToString()
        {
            return this.indexIDs.ToString();
        }

        public bool getScoreBarStatus()
        {
            return this.scoreBarStatus;
        }

        public void setScoreBarStatus(bool status)
        {
            this.scoreBarStatus = status;
        }

        public void setRealFrameSize(Size BackgroundSize)
        {
            this.realFrameSize = BackgroundSize;
        }
        public void setPicBoxSize(Size PictureBoxSize)
        {
            this.pictureBoxSizeScene = PictureBoxSize;
        }

        //calculeaza locatia in procentaj
        public static float[] getPercentLocation(Point cursorPoint, PictureBox picBox)
        {
            var p = new float[2];
            p[0] = ((float)cursorPoint.X / picBox.Width) * 100;
            p[1] = ((float)cursorPoint.Y / picBox.Height) * 100;
            return p;
        }

        public static Point getPercentLocationNewScorebar(Point cursorPoint)
        {
            var p = new Point(0,0);
            p.X = (int)((float)cursorPoint.X / 780) * 100;
            p.Y = (int)((float)cursorPoint.Y / 165) * 100;
            return p;
        }

        //calculeaza marimea 
        public static Size SetSize(Size backgroundOrPicturebox, Size LogoSize)
        {
            float aspectRatio = ((float)LogoSize.Width / LogoSize.Height);
            var s = new Size();
            
            if (aspectRatio != 1)
            {
                s.Height = (int)((float)backgroundOrPicturebox.Height / 9);
                s.Width = (int)((float)s.Height * aspectRatio);
            }
            else
            {
                s.Height = (int)((float)backgroundOrPicturebox.Height / 7);
                s.Width = (int)((float)s.Height * aspectRatio);
            }

            return s;
        }

        public static Size SetControlNewScorebarSize(Size backgroundOrPicturebox, Size logoSize)
        {
            float aspect = ((float)logoSize.Height / logoSize.Width);
            float aspect2 = ((float)logoSize.Width / logoSize.Height);
            var auxSize = new Size();


            if (aspect != 1)
            {
                auxSize.Width = backgroundOrPicturebox.Width;
                auxSize.Height = (int)((float)backgroundOrPicturebox.Width * aspect);                
            }
            else
            {
                auxSize.Height = (int)((float)backgroundOrPicturebox.Height);
                auxSize.Width = (int)((float)auxSize.Height * aspect);                
            }

            if (auxSize.Height > backgroundOrPicturebox.Height) 
            {
                auxSize.Height = backgroundOrPicturebox.Height;
                auxSize.Width = (int)((float)backgroundOrPicturebox.Height * aspect2);                
            }            
            
            return auxSize;
        }



        //calc point
        public static Point setPoint(float[] percentLocation, Size backgroundOrPicturebox, Size ImgbackgroundOrPictureBox)
        {
            var p = new Point(0, 0);
            float X = ((float)((float)backgroundOrPicturebox.Width / 100) * percentLocation[0]) - (ImgbackgroundOrPictureBox.Width / 2);
            float Y = ((float)((float)backgroundOrPicturebox.Height / 100) * percentLocation[1]) - (ImgbackgroundOrPictureBox.Height / 2);
            p.X = (int)Math.Round((decimal)X, 0);
            p.Y = (int)Math.Round((decimal)Y, 0);
            return p;
        }









    }
}
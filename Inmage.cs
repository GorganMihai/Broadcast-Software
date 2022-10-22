using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Broadcast_Software
{
    [Serializable]
    public class Inmage
    {
        private int ID;
        private Bitmap PngImg;

        private Size realFrameSize;
        private Size controlSize;
        private Size controlNewScorebarSize;

        private Point realFramePoint;
        private Point controlPoint;

        private bool isImgScorebar = false;

        public bool isScoreBar()
        {
            return this.isImgScorebar;
        }

        public void setIsScoreBar(bool isScorebar)
        {
            this.isImgScorebar = isScorebar;
        }

        public Inmage(int ID, Bitmap PngImg, Size realFrameSize, Size controlSize, Point realFramePoint, Point controlPoint)
        {
            this.ID = ID;
            this.PngImg = new Bitmap(PngImg); // attenzione forse possiamo non usare new (shallow copy)

            this.realFrameSize = realFrameSize;
            if (controlSize.Width % 2 == 0)
            {
                this.controlSize = controlSize;
            }
            else
            {
                var s = new Size(0, 0);
                s.Height = controlSize.Height + 1;
                s.Width = controlSize.Width + 1;
                this.controlSize = s;
            }


            this.realFramePoint = realFramePoint;
            this.controlPoint = controlPoint;
        }

        public Inmage(int ID, Bitmap PngImg, Size realFrameSize, Size controlSize, Size controlNewScorebarSize, Point realFramePoint, Point controlPoint)
        {
            this.ID = ID;
            this.PngImg = new Bitmap(PngImg); // attenzione forse possiamo non usare new (shallow copy)

            this.realFrameSize = realFrameSize;
            if (controlSize.Width % 2 == 0)
            {
                this.controlSize = controlSize;
                this.controlNewScorebarSize = controlNewScorebarSize;
            }
            else
            {
                var s1 = new Size(0, 0);
                var s2 = new Size(0, 0);

                s1.Height = controlSize.Height + 1;
                s1.Width = controlSize.Width + 1;

                s2.Height = controlNewScorebarSize.Height + 1;
                s2.Width = controlNewScorebarSize.Width + 1;

                this.controlSize = s1;
                this.controlNewScorebarSize = s2;

            }

            this.realFramePoint = realFramePoint;
            this.controlPoint = controlPoint;
        }


        public Bitmap getInmagePngImg()
        {            
            return this.PngImg;
        }

        public void setInmagePngImg(Bitmap PngImg) 
        {
            this.PngImg = PngImg;
        }       

        public void setInmageID(int id)
        {
            this.ID = id;
        }
        public int getInmageID()
        {
            return this.ID;
        }

        public void setInmageNewLocation(Point NewRealFrameLocation, Point NewControlLocation)
        {
            this.realFramePoint = NewRealFrameLocation;
            this.controlPoint = NewControlLocation;
        }

        public void disposeInmagePngImg() 
        {
            PngImg.Dispose();            
        }

        public void resizeInmagePngImg(Size newControlSize, Size newPictureBoxSize, Size newRealFrameSize)
        {
            var perc = new float[2]; //size in percent after resizing X=0 Y=1
            perc[0] = ((float)newControlSize.Width / newPictureBoxSize.Width) * 100;
            perc[1] = ((float)newControlSize.Height / newPictureBoxSize.Height) * 100;

            var Bk = new float[2]; //Size for background X=0 Y=1
            Bk[0] = ((float)newRealFrameSize.Width / 100) * perc[0];
            Bk[1] = ((float)newRealFrameSize.Height / 100) * perc[1];

            this.realFrameSize.Width = (int)Bk[0];
            this.realFrameSize.Height = (int)Bk[1];

            var Ctr = new float[2]; //Size of the control in the pictureBox X=0 Y=1
            Ctr[0] = ((float)newPictureBoxSize.Width / 100) * perc[0];
            Ctr[1] = ((float)newPictureBoxSize.Height / 100) * perc[1];

            this.controlSize.Width = (int)Ctr[0];
            this.controlSize.Height = (int)Ctr[1];            
        }

        public Size getInmageRealFrameSize()
        {
            return this.realFrameSize;
        }

        internal Point centerTheImgControl(Size pictureBoxSize)
        {
            Point centerPoint = new Point(0, 0);

            centerPoint.X = (pictureBoxSize.Width / 2) - (controlNewScorebarSize.Width / 2);
            centerPoint.Y = (pictureBoxSize.Height / 2) - (controlNewScorebarSize.Height / 2);


            return centerPoint;
            
        }

        public void setInmageRealFrameSize(Size newRealFrameSize) 
        {
            this.realFrameSize = newRealFrameSize;
        }

        public Size getInmageControlSize()
        {
            return this.controlSize;
        }

        public Size getInmageControlNewScorebarSize()
        {
            return this.controlNewScorebarSize;
        }

        public void setInmageControlSize(Size newControlSize) 
        {
            this.controlSize = newControlSize;
        }

        public Point getInmageFramePoint()
        {
            return this.realFramePoint;
        }

        public void setInmageFramePoint(Point newFramePoint) 
        {
            this.realFramePoint = newFramePoint;
        }

        public Point getInmageControlPoint()
        {
            return this.controlPoint;
        }
        public void setInmageControlPoint(Point newControlPoint) 
        {
            this.controlPoint = newControlPoint;
        }
    }
}
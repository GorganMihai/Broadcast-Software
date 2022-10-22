using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class CustomSceneControl : Control
    {
        private int ID;
        private PictureBox picBox;
        private Bitmap logo;
        private Size realFrameSize;
        private ImgsHandler imgsHandler;
        private List<Inmage> ImgList { get; set; }

        const int WM_NCHITTEST = 0x84;
        const int WM_SETCURSOR = 0x20;
        const int WM_NCLBUTTONDBLCLK = 0xA3;
        
        private bool isImgScorebar = false;

        public bool isScoreBar()
        {
            return this.isImgScorebar;
        }

        public void setIsScoreBar(bool isScorebar)
        {
            this.isImgScorebar = isScorebar;
        }
        public Bitmap getLogo() 
        {
            var l = new Bitmap(this.logo);
            return l;
        }

        public int GetId() 
        {
            return ID;
        }

        public PictureBox getPicBox() 
        {
            return this.picBox;
        }


        public CustomSceneControl(Bitmap Logo, int ID, PictureBox picBox, Size BackgroundSize, List<Inmage> ImgList, ImgsHandler layerBuilder)
        {            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;
            this.logo = Logo;
            this.ID = ID;
            this.picBox = picBox;
            this.realFrameSize = BackgroundSize;
            this.ImgList = ImgList;
            this.imgsHandler = layerBuilder;
        }
           

        public void setID(int newID) 
        {
            this.ID = newID;
        }        
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var p = new Pen(Color.Red, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                e.Graphics.DrawImage(logo, 0, 0, Width, Height);
            }
        }

        

        protected override void WndProc(ref Message m)
        {
            int borderWidth = 10;

            if (m.Msg == 164) // Click dreapta
            {
                //if (ID == 500)
                //{
                //    //layerBuilder.deleteScorebar();
                //    //this.Dispose();

                //}
                //else 
                //{
                //    imgsHandler.removeElement(ID);
                //}

                if (isImgScorebar == false) 
                {
                    imgsHandler.removeElement(ID);
                }
                

                
                GC.Collect();
                return;
            }

            if (m.Msg == 562) // miscare control
            {
                Point controlLocation = this.Location;
                controlLocation.X = controlLocation.X + (this.Size.Width / 2);
                controlLocation.Y = controlLocation.Y + (this.Size.Height / 2);

                var percentLocation = ImgsHandler.getPercentLocation(controlLocation, picBox);
                if (ID == 500)
                {
                    imgsHandler.setScorebarPoint(percentLocation, picBox);
                }
                else 
                {
                    foreach (var i in ImgList)
                    {
                        if (i.getInmageID() == this.ID)
                        {
                            i.setInmageNewLocation(
                                ImgsHandler.setPoint(percentLocation, realFrameSize, i.getInmageRealFrameSize()),
                                ImgsHandler.setPoint(percentLocation, picBox.Size, i.getInmageControlSize())
                                );

                            return;
                        }
                    }
                }
                
                return;
            }

            if (m.Msg == WM_SETCURSOR)  /*Setting cursor to SizeAll*/
            {
                if ((m.LParam.ToInt32() & 0xffff) == 0x2 /*Move*/)
                {
                    Cursor.Current = Cursors.SizeAll;
                    m.Result = (IntPtr)1;
                    return;
                }
            }

            if ((m.Msg == WM_NCLBUTTONDBLCLK))
            {
                m.Result = (IntPtr)1;
                return;
            }

            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
            {
                var pos = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));

                if (pos.X <= ClientRectangle.Left + borderWidth && pos.Y <= ClientRectangle.Top + borderWidth)
                {
                    m.Result = new IntPtr(13); //TOPLEFT                    
                }

                else if (pos.X >= ClientRectangle.Right - borderWidth && pos.Y <= ClientRectangle.Top + borderWidth)
                {
                    m.Result = new IntPtr(14); //TOPRIGHT
                }

                else if (pos.X <= ClientRectangle.Left + borderWidth && pos.Y >= ClientRectangle.Bottom - borderWidth)
                {
                    m.Result = new IntPtr(16); //BOTTOMLEFT
                }

                else if (pos.X >= ClientRectangle.Right - borderWidth && pos.Y >= ClientRectangle.Bottom - borderWidth)
                {
                    m.Result = new IntPtr(17); //BOTTOMRIGHT
                }

                else if (pos.X <= ClientRectangle.Left + borderWidth)
                {
                    m.Result = new IntPtr(10); //LEFT
                }

                else if (pos.Y <= ClientRectangle.Top + borderWidth)
                {
                    m.Result = new IntPtr(12); //TOP
                }

                else if (pos.X >= ClientRectangle.Right - borderWidth)
                {
                    m.Result = new IntPtr(11); //RIGHT
                }

                else if (pos.Y >= ClientRectangle.Bottom - borderWidth)
                {
                    m.Result = new IntPtr(15); //Bottom
                }

                else
                {
                    m.Result = new IntPtr(2); //Move
                }
            }

            if (m.Msg == 34) //Resize 
            {
                if (ID == 500)
                {
                    imgsHandler.setScorebarSize(this.Size, picBox.Size, realFrameSize);
                }
                else 
                {
                   foreach (var i in ImgList)
                   {
                       if (i.getInmageID() == this.ID)
                       {                        
                           i.resizeInmagePngImg(this.Size, picBox.Size, realFrameSize);
                           return;
                       }
                   } 
                }                
            }
        }

        public int getID() 
        {
            return this.ID;
        }

        public void Disp() 
        {
            this.Dispose();
        }

        public void setLogo(Bitmap Logo)
        {
            this.logo = Logo;
            this.Refresh();
        }
    }
}
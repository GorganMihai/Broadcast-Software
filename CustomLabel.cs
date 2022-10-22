using System;
using System.Collections.Generic;
using System.Data;
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
    class CustomLabel : Control
    {
        public int id;
        
        const int WM_NCHITTEST = 0x84;
        const int WM_SETCURSOR = 0x20;
        const int WM_NCLBUTTONDBLCLK = 0xA3;


        private string bColor = "Blue";
        private string name;
        private Font font;
        private Brush brushColor;
        private int fontSize;
        private string fontName;

        public CustomLabel(string name, int fontSize ) 
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            ResizeRedraw = true;
            BackColor = Color.Transparent;

            this.name = name;
            this.fontSize = fontSize;
            this.font = new Font("Arial", fontSize);
            this.brushColor = new SolidBrush(Color.FromName("Blue"));

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var dashedPen = new Pen(Color.Blue, 1))
            {
                //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;


                dashedPen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(dashedPen, 0, 0, Width - 1, Height - 1);                
                e.Graphics.DrawString(name, font, brushColor, new Point(0, 0));
                setControlSize(e);
                
            }
        }

        internal string getColor()
        {
            return this.bColor;
        }

        internal int getFontSize()
        {
            return this.fontSize;
        }

        internal string getFont()
        {
            return this.fontName;
        }

        public void refresh()
        {            
            this.Refresh();
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
                
                //if (isImgScorebar == false)
                //{
                //    imgsHandler.removeElement(ID);
                //}



                GC.Collect();
                return;
            }

            if (m.Msg == 562) // miscare control
            {
                Point controlLocation = this.Location;
                controlLocation.X = controlLocation.X + (this.Size.Width / 2);
                controlLocation.Y = controlLocation.Y + (this.Size.Height / 2);

                //var percentLocation = ImgsHandler.getPercentLocation(controlLocation, picBox);

                //if (ID == 500)
                //{
                //    imgsHandler.setScorebarPoint(percentLocation, picBox);
                //}
                //else
                //{
                //    foreach (var i in ImgList)
                //    {
                //        if (i.getInmageID() == this.ID)
                //        {
                //            i.setInmageNewLocation(
                //                ImgsHandler.setPoint(percentLocation, realFrameSize, i.getInmageRealFrameSize()),
                //                ImgsHandler.setPoint(percentLocation, picBox.Size, i.getInmageControlSize())
                //                );

                //            return;
                //        }
                //    }
                //}



                
                return;
            }

            if (m.Msg == WM_SETCURSOR)  /*Setting cursor to SizeAll*/ //Forma cursor
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
               m.Result = new IntPtr(2); //Move                                          
            }

            if (m.Msg == 34) //Resize 
            {
                //if (ID == 500)
                //{
                //    imgsHandler.setScorebarSize(this.Size, picBox.Size, realFrameSize);
                //}
                //else
                //{
                //    foreach (var i in ImgList)
                //    {
                //        if (i.getInmageID() == this.ID)
                //        {
                //            i.resizeInmagePngImg(this.Size, picBox.Size, realFrameSize);
                //            return;
                //        }
                //    }
                //}
            }
        }

        public void changeFontName(string fontName) 
        {
            this.fontName = fontName;
            this.font = new Font(this.fontName, fontSize);
            this.refresh();            
        }

        public void changeFontColor(string fontColor)
        {
            this.bColor = fontColor; 
            this.brushColor = new SolidBrush(Color.FromName(fontColor));
            this.refresh();
           
        }

        public void changeFontSize(int fontSize) 
        {
            this.fontSize = fontSize;
            this.font = new Font(this.fontName, fontSize);
            this.refresh();
        }

        private void setControlSize(PaintEventArgs e) 
        {
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(this.name, this.font);

            this.Width = (int)stringSize.Width;
            this.Height = (int)stringSize.Height;
        }

        public void setYLocation(int newYLocation) 
        {
            this.Location = new Point(this.Location.X, newYLocation);
            this.refresh();
        }

        public int getYLocation()
        {
            return this.Location.Y; 
        }

        public void setXLocation(int newXLocation) 
        {
            this.Location = new Point(newXLocation, this.Location.Y);
            this.refresh();
        }

        


















    }

}

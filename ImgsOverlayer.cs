using Accord.IO;
using Accord.Video.DirectShow;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Broadcast_Software
{
    public class ImgsOverlayer
    {
        private ProcessHandler processHandler;        
        private List<Inmage> imgList; 
        
        private ConcurrentQueue<Bitmap> processedframesQueue;                        
        

        public ImgsOverlayer(DeviceHandler devicesHandler, ProcessHandler processHandler) 
        {
            this.processHandler = processHandler;                      
            processedframesQueue = new ConcurrentQueue<Bitmap>();           
            imgList = new List<Inmage>();            
        }
             


        public Task processFrame(Bitmap img, PictureBox pictureBoxMain)
        {           
            return Task.Factory.StartNew(() =>
            {
                lock (this)
                {
                    using (Graphics g = Graphics.FromImage(img))
                    {
                        foreach (var i in imgList)
                        {
                        
                                g.DrawImage(i.getInmagePngImg(),
                                    i.getInmageFramePoint().X,
                                    i.getInmageFramePoint().Y,
                                    i.getInmageRealFrameSize().Width,
                                    i.getInmageRealFrameSize().Height);
                        
                        }

                        processedframesQueue.Enqueue(img);
                        GC.Collect();
                    }
                }

                startSendAsync(pictureBoxMain);
            });                       
        }

        private Task startSendAsync(PictureBox pictureBoxMain) 
        {
            return Task.Factory.StartNew(() =>
            {
                changePictureBoxMainAndSendToFFmpegProcess(pictureBoxMain);
            });
        }

        public async void changePictureBoxMainAndSendToFFmpegProcess(PictureBox pictureBoxMain)
        {
            Bitmap img;

            if (processedframesQueue.TryDequeue(out img))
            {

                if (processHandler.GetLiveStatus())
                {
                    await processHandler.SendAsync(img);
                }

                try
                {
                    pictureBoxMain.Image = img;
                }
                catch (Exception e)
                {
                    // MessageBox.Show(e.ToString());
                }

            }

        }




        public async void modFrameAllInOne(Bitmap NewFrame, PictureBox pictureBoxMain)
        {
            Bitmap newFrame = NewFrame.Clone(new Rectangle(0, 0, NewFrame.Width, NewFrame.Height), PixelFormat.Format24bppRgb);

            try
            {
                using (Graphics g = Graphics.FromImage(newFrame))
                {
                    foreach (var i in imgList)
                    {
                        g.DrawImage(i.getInmagePngImg(),
                            i.getInmageFramePoint().X,
                            i.getInmageFramePoint().Y,
                            i.getInmageRealFrameSize().Width,
                            i.getInmageRealFrameSize().Height);
                    }

                    GC.Collect();
                }
            }
            catch (Exception)
            {


            }


            if (processHandler.GetLiveStatus())
            {
                await processHandler.SendAsync(newFrame.Clone(new Rectangle(0, 0, NewFrame.Width, NewFrame.Height), PixelFormat.Format24bppRgb));
            }

            //pictureBoxMain.Image = null;

            try
            {
                //pictureBoxMain.Image = null;
                pictureBoxMain.Image = newFrame;
            }
            catch (Exception e)
            {}  


            GC.Collect();
        }

        internal void setImgList(ConcurrentQueue<Inmage> inmages)
        {
            throw new NotImplementedException();
        }

        private void clearProcessList()
        {
            Bitmap item;

            while (processedframesQueue.TryDequeue(out item))
            {
                item.Dispose();
            }

            item = null;
        }

        public void setImgList(List<Inmage> imgList) 
        {
            
            this.imgList.Clear();
            this.imgList = imgList;
        }

        public void updateImgScorebar(Bitmap newScoreBarImg) 
        {
            foreach (Inmage img in imgList) 
            {
                if (img.isScoreBar() == true) 
                {
                    img.setInmagePngImg(newScoreBarImg);
                }
            }
        }

        public string getNrElementinQueue() 
        {
            return processedframesQueue.Count.ToString();
        }


    }       
      
   
}
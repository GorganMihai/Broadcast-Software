using Accord.IO;
using Accord.Video;
using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class DeviceHandler
    {
        public readonly List<FilterInfo> videoDeviceList;
        public readonly List<FilterInfo> audioDeviceList;
        Stopwatch cronometro;
        private VideoCaptureDevice videoDevice;
        private PictureBox pictureBoxMain;
        private bool isRunning = false;
        private ImgsOverlayer imgsOverlayer;
        private ProcessHandler processHandler;
        //private ToolStripStatusLabel labelCameraStatus;
        
        private int videoDeviceIndex = 0;
        private int videoSettingsIndex = 0;
        private int audioDeviceIndex = 0;

        
        private int frameIndexFps;
        

        



        public DeviceHandler(PictureBox pictureBoxMain, ImgsOverlayer imgsOverlayer, ProcessHandler processHandler)
        {
            //this.labelCameraStatus = labelCameraStatus;
            this.pictureBoxMain = pictureBoxMain;
            this.imgsOverlayer = imgsOverlayer;
            this.processHandler = processHandler;
            videoDeviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            audioDeviceList = new FilterInfoCollection(FilterCategory.AudioInputDevice);

            cronometro = new Stopwatch();
        }

        
        public bool getDeviceStatus() 
        {
            return this.isRunning;       
        }

        public void CreateNewDevice() 
        {            
            try 
            {
                videoDevice = new VideoCaptureDevice(videoDeviceList[videoDeviceIndex].MonikerString);
            } 
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateDeviceForSettings(int index)
        {
            try
            {
                videoDevice = new VideoCaptureDevice(videoDeviceList[index].MonikerString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public VideoCapabilities[] GetVideoCapabilities() 
        {
            return videoDevice.VideoCapabilities;            
        }


        public void startCamera()
        {
            
            
            try 
            {
                videoDevice = new VideoCaptureDevice(videoDeviceList[videoDeviceIndex].MonikerString);
                videoDevice.VideoResolution = videoDevice.VideoCapabilities[videoSettingsIndex];
            } 
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            videoDevice.NewFrame += ModFrame;

                    

            
            if (videoDevice.IsRunning == false)
            {                
                try
                {
                    videoDevice.Start();
                    isRunning = true;
                    //labelCameraStatus.ForeColor = Color.Green;
                    //labelCameraStatus.Text = "Camera ON";
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("The camera is already on", "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        public void stopCamera()
        {
            
            if (isRunning == true)
            {
                try
                {
                    videoDevice.SignalToStop();
                    pictureBoxMain.Image = null;
                    
                    videoDevice.NewFrame -= ModFrame;
                                        
                    GC.Collect();

                    //labelCameraStatus.ForeColor = Color.Red;
                    //labelCameraStatus.Text = "Camera OFF";
                    isRunning = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }  
        }




        //private async void ModFrame(object sender, NewFrameEventArgs eventArgs)
        //{
        //    frameIndexFps++;

        //    await frameHandler.ModFrame(eventArgs.Frame.Clone(new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height), PixelFormat.Format24bppRgb), pictureBoxMain);

        //}




       ////=====================================================================================================================================================================================================================

        private async void ModFrame(object sender, NewFrameEventArgs eventArgs)
        {
            frameIndexFps++;

            imgsOverlayer.modFrameAllInOne(eventArgs.Frame.Clone(new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height), PixelFormat.Format24bppRgb), pictureBoxMain);

            //await imgsOverlayer.processFrame(eventArgs.Frame.Clone(new Rectangle(0, 0, eventArgs.Frame.Width, eventArgs.Frame.Height), PixelFormat.Format24bppRgb), pictureBoxMain);  

            //imgsOverlayer.changePictureBoxMainAndSendToFFmpegProcess(pictureBoxMain);  
        }



        public void SetDevices(int VideoIndex, int VideoModIndex, int AudioIndex, Timer timerFps)
        {
            this.videoDeviceIndex = VideoIndex;
            this.videoSettingsIndex = VideoModIndex;
            this.audioDeviceIndex = AudioIndex;

           
        }

        

        public int GetVideoIndex() 
        {
            return videoDeviceIndex;
        }

        public int GetAudioIndex() 
        {
            return audioDeviceIndex;
        }

        public Size getVideoRezolution(Settings settings)
        {
            try
            {
                var Cam2 = new VideoCaptureDevice(videoDeviceList[settings.GetVideoIndex()].MonikerString);
                if (Cam2.VideoCapabilities.Length > 0)
                {
                    Cam2.VideoResolution = videoDevice.VideoCapabilities[settings.GetVideoModIndex()];
                    return Cam2.VideoResolution.FrameSize;
                }
                else 
                {
                    MessageBox.Show("Please choose a valid video mode", "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Size(0, 0);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Size(0,0);
            }            
        }

        public string getAudioDeviceName() 
        {
            return audioDeviceList[audioDeviceIndex].Name;
        }
        
    }
}
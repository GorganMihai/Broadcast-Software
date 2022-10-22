using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class ProcessHandler
    {
        private string URL;
        private string rezolution;
        private string audioDevice;

        private string FFmpegCommand;

        private bool isLive = false;
        private Process FFmpegProcess;
        private ProcessStartInfo startInfo;
        private DeviceHandler deviceHandler;
        private object _locker = new object();
        

        public ProcessHandler() {}

        public void SetDevice(DeviceHandler Device) 
        {
            this.deviceHandler = Device;            
        }

        public Process getFFmpegProcess() 
        {
            return this.FFmpegProcess;
        }

        public void StartLive(Size rezolution, string AudioDevice)
        {
            BuildCommand(rezolution, AudioDevice);

            startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "ffmpeg.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = FFmpegCommand + URL;
            startInfo.RedirectStandardInput = true;

            if (deviceHandler.getDeviceStatus() == true)
            {
                try
                {
                    FFmpegProcess = Process.Start(startInfo);
                    isLive = true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isLive = false;
                }
            }
        }

        public bool StopLive()
        {
            if (deviceHandler.getDeviceStatus() && isLive)
            {   
                isLive = false;
                FFmpegProcess.Kill();
                
                return true;
            }
            else 
            {
                return false;
            }            
        }

        public Task SendAsync(Bitmap img) 
        {

            return Task.Factory.StartNew(() =>
            {
                try
                {
                    BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                    byte[] buf = new byte[bitmapData.Stride * img.Height];
                    Marshal.Copy(bitmapData.Scan0, buf, 0, buf.Length);
                    FFmpegProcess.StandardInput.BaseStream.Write(buf, 0, buf.Length);
                    FFmpegProcess.StandardInput.BaseStream.Flush();
                    
                    img.UnlockBits(bitmapData);
                    img = null;
                    bitmapData = null;
                    
                }
                catch (Exception exe)
                {
                    //MessageBox.Show("eroare la scriere in process ffmpeg send");
                    //StopLive();
                }
                GC.Collect();
            });


        }

        

        public bool GetLiveStatus() 
        {
            return isLive;
        }

        public bool SetURL(string URL) 
        {
            if (URL.Length > 10)
            {
                this.URL = URL;
                return true;
            }
            else 
            {
                return false;
            } 
        }

        private void BuildCommand(Size Rez, string AudioDevice) 
        {
            this.rezolution = null;
            this.rezolution = $"{Rez.Width}x{Rez.Height}";

            this.audioDevice = AudioDevice;

            // De facut un Case pentru diferitele VideoCamere

            //FFmpegCommand =
            //" -threads:v 2 -threads:a 8 -filter_threads 2 -thread_queue_size 16 -y -f rawvideo -pix_fmt bgr24 -video_size " + this.rezolution + " -r 30 -i - " +
            //"-f dshow -rtbufsize 10M -i audio=\"" + this.audioDevice + "\" " +
            //"-vcodec libx264 -preset ultrafast -tune zerolatency -x264-params keyint=60:scenecut=0 -b:v 5000k -maxrate 5500k -bufsize 50M -pix_fmt yuv420p -c:a aac -b:a 128k -ac 2 -f flv ";

            //OK
            //FFmpegCommand = " -threads:v 2 -threads:a 8 -filter_threads 2 -thread_queue_size 8 -y -f rawvideo -pix_fmt bgr24 -rtbufsize 50M -video_size " + this.rezolution + " -r 25 -i - -f dshow -i audio=\"" + this.audioDevice + "\" " +
            //    "-vcodec libx264 -preset ultrafast -tune zerolatency -x264-params keyint=60:scenecut=0 -b:v 4500k -maxrate 5000k -bufsize 6M -pix_fmt yuvj422p -c:a aac -b:a 128k -ac 2 -g 2 -strict experimental -f flv ";


            
            FFmpegCommand = " -threads:v 2 -threads:a 8 -filter_threads 2 -thread_queue_size 2048 -y -f rawvideo -pix_fmt bgr24 -rtbufsize 512M -video_size " + this.rezolution + " -r 25 -i - -f dshow -i audio=\"" + this.audioDevice + "\" " +
                "-vcodec libx264 -preset ultrafast -tune zerolatency -x264-params keyint=60:scenecut=0 -b:v 4500k -maxrate 5000k -bufsize 512M -pix_fmt yuvj422p -c:a aac -b:a 128k -ac 2 -f flv ";


        }
    }









































    // Ultimo ok
    //FFmpegCommand = " -threads:v 2 -threads:a 8 -filter_threads 2 -thread_queue_size 128 -y -f rawvideo -pix_fmt bgr24 -rtbufsize 128M -video_size " + this.rezolution + " -r 25 -i - -f dshow -i audio=\"" + this.audioDevice + "\" " +
    //    "-vcodec libx264 -preset ultrafast -tune zerolatency -x264-params keyint=60:scenecut=0 -b:v 4500k -maxrate 5000k -bufsize 128M -pix_fmt yuvj422p -c:a aac -b:a 128k -ac 2 -f flv ";


    //Da ffmpeg provato
}
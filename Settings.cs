using Accord.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    public class Settings
    {
        private int ID;
        private string Name;
        private string URL = null;
        private string Key = null;
        private int VideoIndex = 0;
        private int VideoModIndex = 0;
        private int AudioIndex = 0;

        public int GetID() 
        {
            return this.ID;
        }

        public void SetID(int ID) 
        {
            this.ID = ID;
        }

        public string GetName() 
        {
            return this.Name;
        }

        VideoCaptureDevice Cam;
        public Settings() { }
        public Settings(int ID, string Name, string URL, string Key, int VideoIndex, int VideoModIndex, int AudioIndex) 
        {
            this.ID = ID;
            this.Name = Name;
            this.URL = URL;
            this.Key = Key;
            this.VideoIndex = VideoIndex;
            this.VideoModIndex = VideoModIndex;
            this.AudioIndex = AudioIndex;        
        }
        public Settings(string Name, string URL, string Key, int VideoIndex, int VideoModIndex, int AudioIndex)
        {
            this.Name = Name;
            this.URL = URL;
            this.Key = Key;
            this.VideoIndex = VideoIndex;
            this.VideoModIndex = VideoModIndex;
            this.AudioIndex = AudioIndex;
        }

        public void SetURL(string URL) 
        {
            this.URL = URL;
        }
        public void SetKey(string Key)
        {
            this.Key = Key;
        }

        public string GetURL() 
        {
            return this.URL;
        }

        public string GetKey() 
        {
            return this.Key;
        }


        public void SetVideoIndex(int VideoIndex)
        {
            this.VideoIndex = VideoIndex;
        }
        public int GetVideoIndex()
        {
            return this.VideoIndex;
        }

        public void SetVideoModIndex(int VideoModIndex)
        {
            this.VideoModIndex = VideoModIndex;
        }
        public int GetVideoModIndex()
        {
            return this.VideoModIndex;
        }

        public void SetAudioIndex(int AudioIndex)
        {
            this.AudioIndex = AudioIndex;
        }
        public int GetAudioIndex()
        {
            return this.AudioIndex;
        }

        public string Get_URL_Key()
        {
            return URL + "/" + Key;
        }

        public override string ToString()
        {
            return string.Format(this.Name);
        }

        public void SetLabels(DeviceHandler deviceHandler, Label labelVideoSource, Label labelAudioSource)
        {
            try
            {
                Cam = new VideoCaptureDevice(deviceHandler.videoDeviceList[VideoIndex].MonikerString);                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Video Device Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Cam.VideoCapabilities.Length <= 0)
            {
                labelVideoSource.ForeColor = Color.Red;
                labelVideoSource.Text = "Video Source:  INVALID VIDEO DEVICE (" + deviceHandler.videoDeviceList[VideoIndex].Name + ")";
            }
            else
            {
                labelVideoSource.ForeColor = Color.Gainsboro;
                labelVideoSource.Text = "Video Source:  " + deviceHandler.videoDeviceList[VideoIndex].Name + "  " + Cam.VideoCapabilities[VideoModIndex].ToString() + ".";
            }

            labelAudioSource.Text = "Audio Source:  " + deviceHandler.audioDeviceList[AudioIndex].Name + ".";
        }
    }
}
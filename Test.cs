using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadcast_Software
{
    class Test
    {
        private int nrFrame = 1;
        private Stopwatch Crono;
        private ListBox ListBox;
        private List<string> listString; 
        private List<int> AverageTime;

        public Test(ListBox ListBox) 
        {
            this.ListBox = ListBox;
            Crono = new Stopwatch();
            listString = new List<string>();
            AverageTime = new List<int>();
        }

        public void StartCrono() 
        {
           Crono.Start();
        }

        
        public void StopCrono() 
        {
            Crono.Stop();
            listString.Add("Frame nr. " + nrFrame + "__     " + Crono.ElapsedMilliseconds.ToString());
            Crono.Reset();
            nrFrame++;
        }
        public void GetAvarege() 
        {
            try 
            {
            foreach (var s in listString)
            {
                ListBox.Items.Add(s);
                AverageTime.Add(Convert.ToInt32(s.Substring((s.Length - 2), 2)));
            }
            MessageBox.Show("AverageTime= " +  Decimal.Truncate((decimal)AverageTime.Average()) + " ms.\n" +
                "Min= " + AverageTime.Min() + "\n" +
                "Max= " + AverageTime.Max() + "\n",
                "Frame Average Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) 
            {
                MessageBox.Show("Average Error \n" + e.ToString());
            }            
        }
    }
}
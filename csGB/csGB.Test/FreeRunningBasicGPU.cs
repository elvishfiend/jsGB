using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csGB.Test
{
    public partial class FreeRunningBasicGPU : Form
    {
        private int currentFrame;
        private int prevFrame;

        private Timer frameTimer;

        public FreeRunningBasicGPU()
        {
            var gpu = new GPUs.BasicGpu();
            gpu.InitializeScreen();

            new System.Threading.Thread(() => {
                while (true)
                {
                    gpu.DrawScreen();
                    currentFrame++;
                }
            }).Start();

            frameTimer = new Timer();
            frameTimer.Interval = 5000;
            frameTimer.Tick += Timer_Tick;

            frameTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var frameDelta = currentFrame - prevFrame;

            var frameRate = frameDelta / (frameTimer.Interval / 1000);

            this.Text = frameRate + " fps";
            this.Name = frameRate + " fps";

            prevFrame = currentFrame;
        }
    }
}

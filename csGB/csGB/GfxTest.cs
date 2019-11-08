using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csGB
{
    public partial class GfxTest : Form
    {
        int frameCount = 0;
        int lastFrameCount = 0;

        private GPUs.BasicGpu gpu;

        private Bitmap bmp;

        private Timer timer;

        public GfxTest()
        {
            //new LogForm().Show();
            gpu = new GPUs.BasicGpu();

            bmp = gpu.InitializeScreen();

            // set up a checker-board pattern
            SetLargeCheckerboardPattern();

            this.Paint += new PaintEventHandler(DrawScreen);

            this.Invalidate();

            timer = new Timer();
            timer.Interval = 1_000;
            timer.Tick += Timer_Tick;
            timer.Start();

            var frameTimer = new Timer();
            frameTimer.Interval = 2000;
            frameTimer.Tick += FrameTimer_Tick;
            frameTimer.Start();
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            var currentFrameCount = frameCount;

            var frameDelta = currentFrameCount - lastFrameCount;
            this.Name = $"{ frameCount / 2} fps";
            this.Text = $"{ frameCount / 2} fps";

            this.lastFrameCount = currentFrameCount;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var palette = gpu.ReadByte(0xFF47);
            palette = ~palette;

            gpu.WriteByte(0xFF47, palette);
        }

        public void DrawScreen(object src, PaintEventArgs e)
        {
            gpu.DrawScreen();

            e.Graphics.ScaleTransform(4, 4);
            e.Graphics.DrawImage(bmp, Point.Empty);

            frameCount += 1;

            //this.Invalidate();
        }

        public void SetLargeCheckerboardPattern()
        {
            // set palette
            gpu.WriteByte(0xFF47, 0b00011011);

            // set the tile data

            for (int i = 0; i < 16; i++)
            {
                // tile -127
                gpu.VRAM[i] = 0;

                // tile -126
                gpu.VRAM[i+16] = 255;

                // tile 0
                gpu.VRAM[i + 128 * 16] = 0;
                // tile 1
                gpu.VRAM[i + 129 * 16] = 255;
            }
            // height
            for (int i = 0; i < 32; i++)
            {
                // if i is even, we want to start black and alternate
                var color1 = i % 2 == 0 ? 1 : 0;
                var color2 = i % 2 == 0 ? 0 : 1;

                // width
                for (int j = 0; j < 32; j++)
                {
                    var color = j % 2 == 0 ? color1 : color2;

                    gpu.bgMapLower[i * 32 + j] = color;
                    gpu.bgMapHigher[i * 32 + j] = color;
                }
            }
        }
    }
}

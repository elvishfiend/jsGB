using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csGB.GPUs;
using csGB;

namespace csGB
{
    public partial class Display : Form
    {
        public static Bitmap buf;

        public static System.Timers.Timer timer = new System.Timers.Timer()
        {
            AutoReset = true,
            Interval = 20,
        };

        public Display()
        {
            InitializeComponent();

            this.Text = "GB";
            this.ClientSize = new Size(160, 144);
            this.MaximizeBox = false;
            this.BackColor = Color.Black;
            this.SetStyle(ControlStyles.Opaque, true);
            this.DoubleBuffered = true;

            this.Paint += Display_Paint;

            buf = new Bitmap(160, 144, PixelFormat.Format8bppIndexed);

            var pal = buf.Palette;

            for (int i = 0; i<256; i++)
            {
                pal.Entries[i] = Color.FromArgb(i, i, i);
            }

            MMU.load("Roms/ttt.gb");
        }

        private void Display_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(buf, Point.Empty);
        }

        private void Display_Load(object sender, EventArgs e)
        {

        }

        public static void Reset()
        {
            LOG.reset(); GPU.reset(); MMU.reset(); Z80.reset(); KEY.reset(); TIMER.reset();
            Z80._r.pc = 0x100; MMU._inbios = true; Z80._r.sp = 0xFFFE; Z80._r.h = 0x01; Z80._r.l = 0x4D;
            Z80._r.c = 0x13; Z80._r.e = 0xD8; Z80._r.a = 1;
        }

        public static void step()
        {
            if (Z80._r.ime != 0 && MMU._ie != 0 && MMU._if != 0)
            {
                Z80._halt = false; Z80._r.ime = 0;

                if (((MMU._ie & 1) != 0) && ((MMU._if & 1) != 0))
                {
                    MMU._if &= 0xFE; Z80._ops.RST40();
                }
            }
            else
            {
                if (Z80._halt) { Z80._r.m = 1; }
                else
                {
                    Z80._r.r = (Z80._r.r + 1) & 127;
                    Z80._map[MMU.rb(Z80._r.pc++)]();
                    Z80._r.pc &= 65535;
                }
            }
            Z80._clock.m += Z80._r.m; Z80._clock.t += (Z80._r.m * 4);
            GPU.checkline();
            if (Z80._stop)
            {
                pause();
            }
            //dbgupdate();
        }

        public static void run()
        {
            Z80._stop = false;
            timer.Start();// (jsGB.frame, 1);
            //document.getElementById('op_run').innerHTML = 'Pause';
            //document.getElementById('op_run').onclick = jsGB.pause;
        }

        public static void frame()
        {
            var fclock = Z80._clock.m + 17556;
            //var brk = document.getElementById('breakpoint').value;
            //var t0 = new Date();
            do
            {
                if (Z80._halt) Z80._r.m = 1;
                else
                {
                    //  Z80._r.r = (Z80._r.r+1) & 127;
                    Z80._map[MMU.rb(Z80._r.pc++)]();
                    Z80._r.pc &= 65535;
                }
                if (Z80._r.ime != 0 && MMU._ie != 0 && MMU._if != 0)
                {
                    Z80._halt = false; Z80._r.ime = 0;
                    var ifired = MMU._ie & MMU._if;
                    if ((ifired & 1) != 0) { MMU._if &= 0xFE; Z80._ops.RST40(); }
                    else if ((ifired & 2) != 0) { MMU._if &= 0xFD; Z80._ops.RST48(); }
                    else if ((ifired & 4) != 0) { MMU._if &= 0xFB; Z80._ops.RST50(); }
                    else if ((ifired & 8) != 0) { MMU._if &= 0xF7; Z80._ops.RST58(); }
                    else if ((ifired & 16) != 0) { MMU._if &= 0xEF; Z80._ops.RST60(); }
                    else { Z80._r.ime = 1; }
                }
                //jsGB.dbgtrace();
                Z80._clock.m += Z80._r.m;
                GPU.checkline();
                TIMER.inc();
                //if ((brk && parseInt(brk, 16) == Z80._r.pc) || Z80._stop)
                //{
                //    jsGB.pause();
                //    break;
                //}
            } while (Z80._clock.m < fclock);
            //var t1 = new Date();
            //document.getElementById('fps').innerHTML = Math.round(10000 / (t1 - t0)) / 10;
        }

        public static void pause()
        {
            timer.Stop();
            Z80._stop = true;
            //jsGB.dbgupdate();

            //document.getElementById('op_run').innerHTML = 'Run';
            //document.getElementById('op_run').onclick = jsGB.run;
            //XHR.connect('/log.php', {trace:jsGB.trace}, {success:function(x){}});
        }

        private void Step_Click(object sender, EventArgs e)
        {
            step();
        }

        private void LoadRom_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "*.rom",
            };

            openFile.ShowDialog();

            MMU.load(openFile.FileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

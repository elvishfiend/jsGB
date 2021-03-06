﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csGB
{
    public partial class Display : Form
    {
        public static Bitmap buf = new Bitmap(160,144);

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

            new Bitmap(160, 144, PixelFormat.Format8bppIndexed);

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

        /// <summary>
        /// this is what causes the whole thing to run.
        /// </summary>
        public static void step()
        {
            // interrupt master flag enabled 
            // and MMU interrupt enabled && MM interrupt flag
            if (Z80._r.ime && MMU._ie != 0 && MMU._if != 0)
            {
                // don't halt, disable master interrupt flag
                Z80._halt = false; Z80._r.ime = false;

                // if interrupt enable bit 1 set and interrupt flag 1 set
                if (((MMU._ie & 1) != 0) && ((MMU._if & 1) != 0))
                {
                    // clear interrupt flag 1, trigger reset to 0x40
                    MMU._if &= 0xFE; Z80._ops.RST40();
                }
            }
            else
            {
                // halted - do nothing
                if (Z80._halt) { Z80._r.m = 1; }
                else
                {

                    Z80._r.r = (Z80._r.r + 1) & 127;
                    Z80._map[MMU.rb(Z80._r.pc++)]();

                    // wrap PC to 16 bits
                    //Z80._r.pc &= 0xFF; // handled in PC setter
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
            // a frame takes 17556 clock cycles to render. we're stuck here until it's complete.
            var fclock = Z80._clock.m + 17556;
            //var brk = document.getElementById('breakpoint').value;
            //var t0 = new Date();
            do
            {
                // if halted, do nothing and increment m
                if (Z80._halt) Z80._r.m = 1;
                else
                {
                    
                    //  Z80._r.r = (Z80._r.r+1) & 127;
                    // increment and execute PC
                    Z80._map[MMU.rb(Z80._r.pc++)]();
                    // wrap PC to 16 bits - now handled in PC setter
                    //Z80._r.pc &= 65535;
                }

                // if interrupt master enabled and any interrupts enabled and any interrupts triggered
                if (Z80._r.ime && MMU._ie != 0 && MMU._if != 0)
                {
                    // disable interrupts
                    Z80._halt = false; Z80._r.ime = false;

                    // get fired interrupts that are enabled
                    var ifired = MMU._ie & MMU._if;

                    // interrupts get triggered according to priority (see page 40)
                    if ((ifired & (1 << 0)) != 0) { MMU._if &= 0xFE; Z80._ops.RST40(); } // V-Blank
                    else if ((ifired & (1 << 1)) != 0) { MMU._if &= 0xFD; Z80._ops.RST48(); } // LCDC (see STAT)
                    else if ((ifired & (1 << 2)) != 0) { MMU._if &= 0xFB; Z80._ops.RST50(); } // Timer Overflow
                    else if ((ifired & (1 << 3)) != 0) { MMU._if &= 0xF7; Z80._ops.RST58(); } // Serial I/O Complete
                    else if ((ifired & (1 << 4)) != 0) { MMU._if &= 0xEF; Z80._ops.RST60(); } // P10-P13 transition H => L
                    else { Z80._r.ime = true; } // otherwise, re-enable IME
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

        private void button1_Click(object sender, EventArgs e)
        {
            step();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using csGB;

namespace GPUTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            TestPattern();
        }

        static void TestPattern()
        {
            GPU.reset();

            GPU._bgon = 1; // turn Background on
            GPU._lcdon = 1; // turn LCD on
            GPU._winon = 1; // turn Window on

            GPU._xscrl = 0;
            GPU._yscrl = 0;

            // tile pattern tables are 0x8000 => 0x8FFF, or 0x8800 => 0x97FF
            // set tile 0 to all 0
            for (int i = 0; i < 4; i++)
            {
                MMU.wb(0x8000 + i, 0); // low bit
                MMU.wb(0x8001 + i, 0); // high bit
            }

            // set tile 1 to all 1
            MMU.wb(0x8002, 0xFF); // low bit
            MMU.wb(0x8003, 0); // high bit

            // set tile 2 to all 2
            MMU.wb(0x8004, 0x00); // low bit
            MMU.wb(0x8005, 0xFF); // high bit

            // set tile 3 to all 3
            MMU.wb(0x8004, 0xFF); // low bit
            MMU.wb(0x8005, 0xFF); // high bit

            // set the background tiles to all be tile 3 (all 0x3)
            // Map Display Select Mode 0 0x9800 => 0x9BFF (32 * 32)
            for (int i = 0; i < 32 * 32; i++)
                MMU.wb(0x9800 + i, i % 4);

            GPU.RenderTiles();

        }
    }
}

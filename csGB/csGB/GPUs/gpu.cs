using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csGB.GPUs;

namespace csGB
{
    public static class GPU
    {
        public static GPUs.IGPU gpu = gpuImpl;

        public static fullGPU gpuImpl = new fullGPU();

        public static int[] _vram { get; } = gpu.VRAM;
        public static int[] _oam { get; } = gpu.OAM;
        public static int[] _reg { get; } = gpu.REG;


        public static void checkline()
        {
            gpuImpl.Step();
        }

        public static void reset()
        {
            gpu.Reset();
        }

        public static int rb(int addr)
        {
            return gpu.ReadByte(addr);
        }

        public static void wb(int addr, int val)
        {
            gpu.WriteByte(addr, val);
        }

        public static void updatetile(int addr, int val)
        {
            gpuImpl.updatetile(addr, val);
        }

        public static void updateoam(int addr, int val)
        {
            gpuImpl.updateoam(addr, val);
        }
    }
}
